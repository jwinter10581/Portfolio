IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'TableReset')
		DROP PROCEDURE TableReset
GO

CREATE PROCEDURE TableReset AS
BEGIN
	IF EXISTS(SELECT * FROM sys.tables WHERE name='Contacts')
		DROP TABLE Contacts

	IF EXISTS(SELECT * FROM sys.tables WHERE name='Favorites')
		DROP TABLE Favorites

	IF EXISTS(SELECT * FROM sys.tables WHERE name='Listings')
		DROP TABLE Listings

	IF EXISTS(SELECT * FROM sys.tables WHERE name='States')
		DROP TABLE States

	IF EXISTS(SELECT * FROM sys.tables WHERE name='BathroomTypes')
		DROP TABLE BathroomTypes

	CREATE TABLE States (
		StateId char(2) not null primary key,
		StateName varchar(15) not null
	)

	CREATE TABLE BathroomTypes (
		BathroomTypeId int identity(1,1) not null primary key,
		BathroomTypeName varchar(15) not null
	)

	CREATE TABLE Listings (
		ListingId int identity(1,1) not null primary key,
		UserId nvarchar(128) not null,
		StateId char(2) not null foreign key references States(StateId),
		BathroomTypeId int null foreign key references BathroomTypes(BathroomTypeId),
		Nickname nvarchar(50) not null,
		City nvarchar(50) not null,
		Rate decimal(7,2) not null,
		SquareFootage decimal(7,2) not null,
		HasElectric bit not null,
		HasHeat bit not null,
		ListingDescription varchar(500) null,
		ImageFileName varchar(50),
		CreatedDate datetime2 not null default(getdate())
	)

	CREATE TABLE Contacts (
		ListingId int not null foreign key references Listings(ListingId),
		UserId nvarchar(128) not null,
		primary key (ListingId, UserId)
	)

	CREATE TABLE Favorites (
		ListingId int not null foreign key references Listings(ListingId),
		UserId nvarchar(128) not null,
		primary key (ListingId, UserId)
	)
END