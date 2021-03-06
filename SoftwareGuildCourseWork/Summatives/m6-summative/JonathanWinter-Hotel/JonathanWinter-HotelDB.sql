USE [master];
GO

if exists (select * from sys.databases where name = N'HotelDatabase')
begin
	EXEC msdb.dbo.sp_delete_database_backuphistory @database_name = N'HotelDatabase';
	ALTER DATABASE HotelDatabase SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
	DROP DATABASE HotelDatabase;
end

CREATE DATABASE HotelDatabase;
GO

USE HotelDatabase

CREATE TABLE Amenity (
	AmenityID TINYINT PRIMARY KEY,
	AmenityName VARCHAR(12) NOT NULL,
	AmenityPrice DECIMAL(4,2) NULL
	)

CREATE TABLE RoomType (
	RoomTypeID TINYINT PRIMARY KEY,
	RoomTypeName VARCHAR(6) NOT NULL,
	StandardOccupancy SMALLINT NOT NULL,
	MaxOccupancy SMALLINT NOT NULL,
	BasePrice DECIMAL(6,2) NOT NULL,
	ExtraPersonPrice DECIMAL(4,2) NULL
	)

CREATE TABLE Guest (
	GuestID INT PRIMARY KEY IDENTITY (1,1),
	FirstName VARCHAR(50) NOT NULL,
	LastName VARCHAR(50) NOT NULL,
	Address VARCHAR(250) NOT NULL,
	City VARCHAR(100) NOT NULL,
	StateAbbreviation CHAR(2) NOT NULL,
	PostalCode CHAR(5) NOT NULL,
	PhoneNumber CHAR(12) NOT NULL
	)

CREATE TABLE Room (
	RoomID SMALLINT PRIMARY KEY,
	RoomTypeID TINYINT,
	ADAAccessible BIT NOT NULL,

	CONSTRAINT fk_room_roomtype FOREIGN KEY (RoomTypeID) REFERENCES RoomType (RoomTypeID)
	)

CREATE TABLE RoomAmenity (
	AmenityID TINYINT NOT NULL,
	RoomID SMALLINT NOT NULL,

	CONSTRAINT pk_roomamenity PRIMARY KEY (AmenityID, RoomID),
	CONSTRAINT fk_roomamenity_amenity FOREIGN KEY (AmenityID) REFERENCES Amenity (AmenityID),
	CONSTRAINT fk_roomamenity_room FOREIGN KEY (RoomID) REFERENCES Room (RoomID)
	)

CREATE TABLE Reservation (
	ReservationID INT PRIMARY KEY IDENTITY (1,1),
	RoomID SMALLINT,
	GuestID INT,
	NumberOfAdults TINYINT NOT NULL,
	NumberOfChildren TINYINT NOT NULL,
	StartDate DATE NOT NULL,
	EndDate DATE NOT NULL,
	TotalReservationCost DECIMAL(6,2) NOT NULL,

	CONSTRAINT fk_reservation_guest FOREIGN KEY (GuestID) REFERENCES Guest (GuestID),
	CONSTRAINT fk_reservation_room FOREIGN KEY (RoomID) REFERENCES Room (RoomID)
	)
