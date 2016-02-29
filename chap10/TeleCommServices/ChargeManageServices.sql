use TeleCommunication
/*计算在服务区内的通话费*/
if exists(select name
	from sysobjects
	where name='usp_ComputeCallInCell'
	and type='P'
	)
	drop proc usp_ComputeCallInCell
go
create proc usp_ComputeCallInCell
(
	@Duration int,
	@Amount decimal(5,2) output
)
as
	select @Amount=((@Duration+59)/60)*CallInCell
	from Charge
go
/*计算跨服务区通话费*/
if exists(select name
	from sysobjects
	where name='usp_ComputeCallInterCell'
	and type='P'
	)
	drop proc usp_ComputeCallInterCell
go
create proc usp_ComputeCallInterCell
(
	@Duration int,
	@Amount decimal(5,2) output
)
as
	select @Amount=CallInterCell*((@Duration+5)/6)
		+((@Duration+59)/60)*CallInCell
	from Charge
go
/*计算漫游通话费*/
if exists(select name
	from sysobjects
	where name='usp_ComputeCallRoaming'
	and type='P'
	)
	drop proc usp_ComputeCallRoaming
go
create proc usp_ComputeCallRoaming
(
	@Duration int,
	@Amount decimal(5,2) output
)
as
	select @Amount=CallInterCell*((@Duration+5)/6)
		+((@Duration+59)/60)*(CallInCell+CallRoaming)
	from Charge
go
/*计算发送短信的收费*/
if exists(select name
	from sysobjects
	where name='usp_SendSM'
		and type='P'
	)
	drop proc usp_SendSM
go
create proc usp_SendSM
(
	@CardNo char(11),
	@SMStatus varchar(15),
	@Time DateTime,
	@Result int output
)
as
	declare @Amount decimal(5,2)
	/*验证卡号是否存在*/
	select * 
	from SIMCard
	where CardNo=@CardNo
	if @@RowCount=0
	begin
		set @Result=0
		return
	end
	/*同一时间一个卡号不能发两条短信*/
	select *
	from SM
	where CardNo=@CardNo
		and Time=@Time
	if @@RowCount>0
	begin
		set @Result=0
		return
	end
	/*获取短信的话费*/
	if @SMStatus='InCell'
		select @Amount=SMInCell
		from Charge
	else if @SMStatus='InterCell'
		select @Amount=SMInterCell
		from Charge
	else
		set @Result=0
	if @Amount is null
		set @Amount=0
	/*插入短信*/
	insert 
	into SM
	values(@CardNo,@Time,@SMStatus,@Amount)
	set @Result=@@RowCount
go
/*计算通话的收费*/
if exists(select name
	from sysobjects
	where name='usp_Call'
		and type='P'
	)
	drop proc usp_Call
go
create proc usp_Call
(
	@FromCard char(11),
	@ToCard char(11),
	@StartTime DateTime,
	@Duration int,
	@CallStatus varchar(15),
	@ReceiveStatus varchar(15),
	@Result int output
)
as
	declare @CallAmount decimal(5,2)
	declare @ReceiveAmount decimal(5,2)
	/*验证呼出卡号是否存在*/
	select * 
	from SIMCard
	where CardNo=@FromCard
	if @@RowCount=0
	begin
		set @Result=0
		return
	end
	/*验证接听卡号是否存在*/
	select * 
	from SIMCard
	where CardNo=@ToCard
	if @@RowCount=0
	begin
		set @Result=0
		return
	end
	/*同一时间，一个号不能参与两个通话*/
	select *
	from Call
	where StartTime=@StartTime
		and (FromCard=@FromCard
			or ToCard=@ToCard)
	if @@RowCount>0
	begin
		set @Result=0
		return 
	end
	/*计算呼出号收费*/
	if @CallStatus='InCell'
		exec usp_ComputeCallInCell @Duration,
			@CallAmount output
	else if @CallStatus='InterCell'
		exec usp_ComputeCallInterCell @Duration,
			@CallAmount output
	else if @CallStatus='Roaming'
		exec usp_ComputeCallRoaming @Duration,
			@CallAmount output
	else
	begin
		set @Result=0
		return
	end
	/*计算接听号收费*/
	if @ReceiveStatus='InCell'
		exec usp_ComputeCallInCell @Duration,
			@ReceiveAmount output
	else if @ReceiveStatus='InterCell'
		exec usp_ComputeCallInterCell @Duration,
			@ReceiveAmount output
	else if @ReceiveStatus='Roaming'
		exec usp_ComputeCallRoaming @Duration,
			@ReceiveAmount output
	else 
	begin
		set @Result=0
		return 
	end
	/*插入通话记录*/
	insert
	into Call
	values(@StartTime,@Duration,@FromCard,@ToCard,
		@CallStatus,@ReceiveStatus,@CallAmount,
		@ReceiveAmount
	)
	set @Result=@@RowCount
go