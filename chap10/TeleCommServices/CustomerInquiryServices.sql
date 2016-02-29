use TeleCommunication
go
/*验证卡号是否正确*/
if exists(select name
	from sysobjects
	where name='usp_VerifyCard'
		and type='P'
	)
	drop proc usp_VerifyCard
go
create proc usp_VerifyCard
(
	@CardNo char(11),
	@PIN	varchar(8),
	@Result int output
)
as
	select *
	from SIMCard
	where CardNo=@CardNo
		and PIN=@PIN
		and Status='Open'
	set @Result=@@RowCount
go
/*查询余额*/
if exists(select name
	from sysobjects
	where name='usp_QueryBalance'
	and type='P'
	)
	drop proc usp_QueryBalance
go
create proc usp_QueryBalance
(
	@CardNo char(11)
)
as
	select Balance 
	from SIMCard
	where CardNo=@CardNo
go
/*查询一个月的通话话费*/
if exists(select name
	from sysobjects
	where name='usp_QueryCallBill'
		and type='P'
	)
	drop proc usp_QueryCallBill
go
create proc usp_QueryCallBill
(
	@CardNo char(11),
	@Year int,
	@Month int,
	@Total decimal(10,2) output
)
as
	declare @tot decimal(10,2)

	/*计算呼出话费*/
	select @Total=sum(CallAmount)
	from Call
	where FromCard=@CardNo
		and Year(StartTime)=@Year
		and Month(StartTime)=@Month

	if @Total is null
		set @Total=0
	/*计算接入话费*/
	select @tot=sum(ReceiveAmount)
	from Call
	where ToCard=@CardNo
		and Year(StartTime)=@Year
		and Month(StartTime)=@Month
	if @tot is null
		set @tot=0
	/*计算总话费*/
	set @Total=@Total+@tot
go	
/*查询一个月的短信话费*/
if exists(select name
	from sysobjects
	where name='usp_QuerySMBill'
		and type='P'
	)
	drop proc usp_QuerySMBill
go
create proc usp_QuerySMBill
(
	@CardNo char(11),
	@Year int,
	@Month int,
	@Total decimal(10,2) output
)
as
	select @Total=sum(Amount)
	from SM
	where CardNo=@CardNo
		and Year(Time)=@Year
		and Month(Time)=@Month
	if @Total is null
		set @Total=0
go
/*修改PIN码*/
if exists(select name
	from sysobjects
	where name='usp_UpdatePIN'
	and type='P'
	)
	drop proc usp_UpdatePIN
go
create proc usp_UpdatePIN
(
	@CardNo char(11),
	@pwd varchar(8)
)
as
	update SIMCard
	set PIN=@pwd
	where CardNo=@CardNo
go
/*验证冲值卡号是否正确*/
if exists(select name
	from sysobjects
	where name='usp_VerifyRechargeCardNo'
	and type='P'
	)
	drop proc usp_VerifyRechargeCardNo
go
create proc usp_VerifyRechargeCardNo
(
	@RechargeCardNo varchar(10) output,
	@Pwd varchar(10),
	@Result int output,
	@FaceValue decimal(3,0) output,
	@Duration smallint output
)
as
	select @FaceValue=RechargeCard.FaceValue,
		@Duration=Duration
	from	RechargeCard
	inner join PeriodOfValidation
		on	PeriodOfValidation.FaceValue=RechargeCard.FaceValue
	where CardNo=@RechargeCardNo 
		and Password=@Pwd
		and Status='New'
	set @Result=@@RowCount
go
/*进行冲值*/
if exists(select name
	from sysobjects
	where name='usp_Recharge'
	and type='P'
	)
	drop proc usp_Recharge
go
create proc usp_Recharge
(
	@CardNo char(11),
	@RechargeCardNo varchar(10),
	@FaceValue decimal,
	@Duration smallint,
	@Result int output
)
as
	update SIMCard
	set Expiration=dateadd(month,@Duration,Expiration),
		Balance=Balance+@FaceValue
	where CardNo=@CardNo
	/*冲值成功，将冲值卡从数据库重删除*/
	if @@RowCount>0
	update RechargeCard
	set Status='Used'
	where CardNo=@RechargeCardNo
	set @Result=@@RowCount
go
/*解除暂时锁定*/
if exists(select name
	from sysobjects
	where name='usp_Unlock'
	and type='P'
	)
	drop proc usp_Unlock
go
create proc usp_Unlock
(
	@CardNo char(11),
	@PUK char(6),
	@Result int output
)
as
	update SIMCard
	set Status='Open'
	where CardNo=@CardNo
		and PUK=@PUK
		and Status='Locked'
	set @Result=@@RowCount
go
/*挂失*/
if exists(select name
	from sysobjects
	where name='usp_ReportOfLost'
	and type='P'
	)
	drop proc usp_ReportOfLost
go
create proc usp_ReportOfLost
(
	@CardNo char(11),
	@Result int output
)
as
	update SIMCard
	set Status='Suspending'
	where CardNo=@CardNo
		and Status='Open'
	set @Result=@@RowCount
go