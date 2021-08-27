USE GuildCars
GO

IF EXISTS(SELECT * FROM sys.tables WHERE NAME='Special')
	DROP TABLE Special
GO

IF EXISTS(SELECT * FROM sys.tables WHERE NAME='Purchase')
	DROP TABLE Purchase
GO

IF EXISTS(SELECT * FROM sys.tables WHERE NAME='State')
	DROP TABLE [State]
GO

IF EXISTS(SELECT * FROM sys.tables WHERE NAME='PurchaseType')
	DROP TABLE PurchaseType
GO

IF EXISTS(SELECT * FROM sys.tables WHERE NAME='Contact')
	DROP TABLE Contact
GO

IF EXISTS(SELECT * FROM sys.tables WHERE NAME='Vehicle')
	DROP TABLE Vehicle
GO

IF EXISTS(SELECT * FROM sys.tables WHERE NAME='Interior')
	DROP TABLE Interior
GO

IF EXISTS(SELECT * FROM sys.tables WHERE NAME='Color')
	DROP TABLE Color
GO

IF EXISTS(SELECT * FROM sys.tables WHERE NAME='VehicleType')
	DROP TABLE VehicleType
GO

IF EXISTS(SELECT * FROM sys.tables WHERE NAME='BodyStyle')
	DROP TABLE BodyStyle
GO

IF EXISTS(SELECT * FROM sys.tables WHERE NAME='Transmission')
	DROP TABLE Transmission
GO

IF EXISTS(SELECT * FROM sys.tables WHERE NAME='Model')
	DROP TABLE Model
GO

IF EXISTS(SELECT * FROM sys.tables WHERE NAME='Make')
	DROP TABLE Make
GO

IF EXISTS(SELECT * FROM sys.tables WHERE NAME='Employee')
	DROP TABLE Employee
GO

IF EXISTS(SELECT * FROM sys.tables WHERE NAME='Role')
	DROP TABLE [Role]
GO

USE GuildCars
GO

CREATE TABLE Special (
	SpecialId tinyint identity(1,1) not null primary key,
	Title varchar(50) not null,
	[Description] varchar(500) not null
)

CREATE TABLE [Role] (
	RoleId tinyint not null primary key,
	RoleName varchar(8) not null
)

CREATE TABLE Employee (
	EmployeeId tinyint identity(1,1) not null primary key,
	RoleId tinyint not null foreign key references [Role](RoleId),
	EmployeeFirstName varchar(50) not null,
	EmployeeLastName varchar(50) not null,
	EmployeeEmail varchar(256) not null
)

CREATE TABLE Make (
	MakeId tinyint identity(1,1) not null primary key,
	EmployeeId tinyint not null foreign key references Employee(EmployeeId),
	MakeName varchar(20) not null,
	DateAdded date not null default(getdate())
)

CREATE TABLE Model (
	ModelId tinyint identity(1,1) not null primary key,
	ModelName varchar(25) not null,
	EmployeeId tinyint not null foreign key references Employee(EmployeeId),
	MakeId tinyint not null foreign key references Make(MakeId),
	DateAdded date not null default(getdate())
)

CREATE TABLE VehicleType (
	VehicleTypeId tinyint not null primary key,
	VehicleTypeName varchar(4) not null
)

CREATE TABLE BodyStyle (
	BodyStyleId tinyint not null primary key,
	BodyStyleType varchar(5) not null
)

CREATE TABLE Transmission (
	TransmissionId tinyint not null primary key,
	TransmissionType varchar(9) not null
)

CREATE TABLE Color (
	ColorId tinyint not null primary key,
	ColorName varchar(10) not null
)

CREATE TABLE Interior (
	InteriorId tinyint not null primary key,
	InteriorName varchar(10) not null
)

CREATE TABLE Vehicle (
	VINNumber char(17) not null primary key,
	BodyStyleId tinyint not null foreign key references BodyStyle(BodyStyleId),
	ColorId tinyint not null foreign key references Color(ColorId),
	InteriorId tinyint not null foreign key references Interior(InteriorId),
	ModelId tinyint not null foreign key references Model(ModelId),
	TransmissionId tinyint not null foreign key references Transmission(TransmissionId),
	VehicleTypeId tinyint not null foreign key references VehicleType(VehicleTypeId),
	DateAdded date not null default(getdate()),
	DateSold date null,
	[Description] varchar(500) null,
	FeaturedStatus bit not null default 0,
	ImageFilePath varchar(100) not null,
	Mileage int not null,
	MSRP decimal(10,2) not null,
	SalePrice decimal(10,2) not null,
	SoldStatus bit not null default 0,	
	[Year] smallint not null
)

CREATE TABLE Contact (
	ContactId tinyint identity(1,1) not null primary key,
	VINNumber char(17) null foreign key references Vehicle(VINNumber),
	[Name] varchar(100) not null,
	Email varchar(200) null,
	Phone varchar(15) null,
	[Message] varchar(500) not null
)

CREATE TABLE PurchaseType (
	PurchaseTypeId tinyint not null primary key,
	PurchaseTypeName varchar(15) not null
)

CREATE TABLE [State] (
	StateAbbreviation char(2) not null primary key,
	StateName varchar(15) not null
)

CREATE TABLE Purchase (
	PurchaseId smallint identity(1,1) not null primary key,
	EmployeeId tinyint not null foreign key references Employee(EmployeeId),
	PurchaseTypeId tinyint not null foreign key references PurchaseType(PurchaseTypeId),
	StateAbbreviation char(2) not null foreign key references [State](StateAbbreviation),
	VINNumber char(17) not null foreign key references Vehicle(VINNumber),
	[Name] varchar(100) not null,
	Email varchar(200) null,
	Phone varchar(15) null,
	Street1 varchar(200) not null,
	Street2 varchar(50) null,
	City varchar(100) not null,
	ZipCode char(5) not null,
	PurchasePrice decimal(10,2) not null,
	PurchaseDate date not null default(getdate())
)