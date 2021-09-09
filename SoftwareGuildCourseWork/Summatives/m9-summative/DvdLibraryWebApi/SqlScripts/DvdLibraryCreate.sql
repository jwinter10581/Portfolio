USE master
GO

IF EXISTS(SELECT * FROM sys.databases WHERE name='DvdLibrary')
DROP DATABASE DvdLibrary
GO

CREATE DATABASE DvdLibrary
GO

/*
==================================================
*/

USE DvdLibrary
GO

IF EXISTS(SELECT * FROM sys.tables WHERE name='Dvds')
	DROP TABLE Dvds
GO

CREATE TABLE Dvds (
	Id int identity(1,1) not null primary key,
	Title varchar(100) not null,
	ReleaseYear int not null,
	Director varchar(100) null,
	Rating varchar(5) null,
	Notes varchar(200)  null
)