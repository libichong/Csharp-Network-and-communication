create database TeleCommunication

go

use TeleCommunication
go
create table Customer
(
	CustomerID int identity,
	Name varchar(20),
	Gender char(2),
	Address varchar(30),
	Phone varchar(30),
	Birthday datetime,
	
	constraint pk_Customer
		primary key (CustomerID)
)

go

create table SIMCard 
(
	CardNo char(11)
		check(CardNo like '13[0-9]'
			+'[0-9][0-9][0-9][0-9]'
			+'[0-9][0-9][0-9][0-9]'),
	CustomerID int not null
		references Customer(CustomerID),
	PUK char(6) not null,
	PIN varchar(8) not null,
	UserPwd varchar(8) not null,
	Balance numeric(5,2) not null,
	Status varchar(10) not null
		check(Status in ('Open',
		'Close','Stop','Locked','Suspending')),
	Expiration datetime not null,
	
	constraint pk_SIMCard 
		primary key (CardNo)
)

go

create table PeriodOfValidation
(
	FaceValue numeric(3,0)
		check(FaceValue in (30,50,100)),
	Duration smallint not null
		check(Duration>0),
	
	constraint pk_PrriodOfValidation
		primary key (FaceValue)
)

go

create table RechargeCard
(
	CardNo varchar(10),
	Password varchar(10) not null,
	Status varchar(4) not null
		check(Status in ('New','Used')),
	FaceValue numeric(3,0) not null
		references PeriodOfValidation(FaceValue),
	
	constraint pk_RechargeCard
		primary key (CardNo)
)

go

create table SM
(
	SMID int identity(1,1),
	CardNo char(11) not null
		references SIMCard(CardNo),
	Time datetime not null
		default getdate(),
	SMStatus varchar(15) not null
		check(SMStatus in (
			'InterCell','InCell')),
	Amount	decimal(5,2) not null
		check(Amount>0),
	
	constraint pk_SM
 		primary key (SMID)
)

go

create table Call
(
	CallID int identity(1,1),
	StartTime datetime not null
		default getdate(),
	/*通话长度，单位是秒*/
	Duration	int not null 
		check(Duration>0),
	FromCard char(11) not null
		references SIMCard(CardNo),
	ToCard char(11) not null
		references SIMCard(CardNo),
	CallStatus varchar(15) not null
		check(CallStatus in(
			'InCell','InterCell','Roaming')),
	ReceiveStatus varchar(15) not null
		check(ReceiveStatus in(
			'InCell','InterCell','Roaming')),
	CallAmount decimal(5,2) not null
		check(CallAmount>0),
	ReceiveAmount decimal(5,2) not null
		check(ReceiveAmount>0),
	
	constraint pk_Call
		primary key (CallID)
)

go

create table Charge
(
	/*服务区内每分钟的通话费,单位是元*/
	CallInCell numeric(5,2)
		check(CallInCell>0),
	/*漫游费，单位是元*/
	CallRoaming numeric(5,2)
		check(CallRoaming>0),
	/*服务区间通话费，单位是元/6秒*/
	CallInterCell numeric(5,2)
		check(CallInterCell>0),
	/*服务区内短信收费，单位是元*/
	SMInCell numeric(5,2)
		check(SMInCell>0),
	/*服务区间短信收费，单位是元*/
	SMInterCell numeric(5,2)
		check(SMInterCell>0),

	constraint pk_Charge
		primary key (CallInCell,
		CallRoaming,CallInterCell,SMInCell,SMInterCell)
)
go
	
	
	
	
	

