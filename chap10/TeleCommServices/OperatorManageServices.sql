use TeleCommunication
/*�����¿�*/
if exists(select name
	from sysobjects
	where name='usp_CreateCard'
		and type='P'
	)
	drop proc usp_CreateCard
go
create proc usp_CreateCard
(
	@CardNo char(11),
	@CustomerID int,
	@PUK char(6),
	@PIN varchar(8),
	@UserPwd varchar(8),
	@Balance numeric(5,2),
	@Expiration datetime
)
as
	select CardNo
	from SIMCard
	where CardNo=@CardNo
	if @@RowCount>0
		update SIMCard
		set CardNo=@CardNO,
			CustomerID=@CustomerID,
			PUK=@PUK,
			PIN=@PIN,
			UserPwd=@UserPwd,
			Balance=@Balance,
			Status='Open',
			Expiration=@Expiration
		where CardNo=@CardNo
	else
		insert 
		into SIMCard
		values
		(
			@CardNo,@CustomerID,@PUK,
			@PIN,@UserPwd,@Balance,
			'Open',@Expiration
		)
go
/*ɾ���Ѵ��ڵľɿ�*/
if exists(select name
	from sysobjects
	where name='usp_DeleteCard'
		and type='P'
	)
	drop proc usp_DeleteCard
go
create proc usp_DeleteCard
(
	@CardNo char(11)
)
as
	delete 
	from SIMCard
	where CardNo=@CardNo
go		
/*�����շѱ�׼*/
if exists(select name
	from sysobjects
	where name='usp_SetCharge'
		and type='P'
	)
	drop proc usp_SetCharge
go
create proc usp_SetCharge
(
	@CallInCell decimal(5,2),
	@CallRoaming decimal(5,2),
	@CallInterCell decimal(5,2),
	@SMInCell decimal(5,2),
	@SMInterCell decimal(5,2)
)
as
	select *
	from Charge
	if @@RowCount>0
		update Charge
		set CallInCell=@CallInCell,
			CallRoaming=@CallRoaming,
			CallInterCell=@CallInterCell,
			SMInCell=@SMInCell,
			SMInterCell=@SMInterCell
	else
		insert
		into Charge
		values
		(

			@CallInCell,@CallRoaming,
			@CallInterCell,@SMInCell,
			@SMInterCell
		)
go
/*�����ʧ*/
if exists(select name
	from sysobjects
	where name='usp_DelistFromBlackList'
		and type='P'
	)
	drop proc usp_DelistFromBlackList
go
create proc usp_DelistFromBlackList
(
	@CardNo char(11),
	@PUK char(6),
	@UserPwd varchar(8),
	@Result int output
)
as
	update SIMCard
	set Status='Open'
	where CardNo=@CardNo
		and PUK=@PUK
		and UserPwd=@UserPwd
		and Status='Suspending'
	set @Result=@@RowCount
go
/*��ѯÿ�µ���ϸͨ������*/
if exists(select name
	from sysobjects
	where name='usp_QueryDetailCallBill'
		and type='P'
	)
	drop proc usp_QueryDetailCallBill
go
create proc usp_QueryDetailCallBill
(
	@CardNo char(11),
	@Year int,
	@Month int
)
as
	select CallID ͨ����ʶ,FromCard ��������,
		ToCard ��������,StartTime ��ʼʱ��,
		Duration ͨ��ʱ��,CallAmount �����շ�,
		CallStatus ����״̬,ReceiveAmount �����շ�,
		ReceiveStatus ����״̬
	from Call
	where (FromCard=@CardNo
		or ToCard=@CardNo)
		and Year(StartTime)=@Year
		and Month(StartTime)=@Month
go
/*��ѯÿ�µ���ϸ���Ż���*/
if exists(select name
	from sysobjects
	where name='usp_QueryDetailSMBill'
		and type='P'
	)
	drop proc usp_QueryDetailSMBill
go
create proc usp_QueryDetailSMBill
(
	@CardNo char(11),
	@Year int,
	@Month int
)
as
 	select SMID ���ű�ʶ,CardNo ���Ϳ���,Time ����ʱ��,
		SMStatus ����״̬,Amount �����շ�
	from SM
	where CardNo=@CardNo
		and Year(Time)=@Year
		and Month(Time)=@Month
go