USE [master]
GO

if exists (select * from sys.databases where name = N'MovieCatalogue')
begin
		EXEC msdb.dbo.sp_delete_database_backuphistory @database_name = N'MovieCatalogue';
		ALTER DATABASE MovieCatalogue SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
		DROP DATABASE MovieCatalogue;
end 

CREATE DATABASE MovieCatalogue;
GO

USE MovieCatalogue;
GO

CREATE TABLE Genre (
	GenreID INT NOT NULL Identity(1, 1) PRIMARY KEY,
	GenreName NVARCHAR(30) NOT NULL
);

CREATE TABLE Director (
	DirectorID INT NOT NULL IDENTITY(1, 1) PRIMARY KEY,
	FirstName NVARCHAR(30) NOT NULL,
	LastName NVARCHAR(30) NOT NULL,
	BirthDate DATE NULL
);

CREATE TABLE Rating (
	RatingID INT NOT NULL IDENTITY(1, 1) PRIMARY KEY,
	RatingName CHAR(5) NOT NULL
);

CREATE TABLE Actor (
	ActorID INT NOT NULL IDENTITY(1, 1) PRIMARY KEY,
	FirstName NVARCHAR(30) NOT NULL,
	LastName NVARCHAR(30) NOT NULL,
	BirthDate DATE NULL
);

CREATE TABLE Movie (
	MovieID INT NOT NULL IDENTITY(1, 1) PRIMARY KEY,
	GenreID INT NOT NULL,
	DirectorId INT NULL,
	RatingID INT NULL,
	Title NVARCHAR(128) NOT NULL,
	ReleaseDate DATE NULL,

	CONSTRAINT fk_Movie_Genre FOREIGN KEY (GenreID)
		REFERENCES Genre(GenreID),
	CONSTRAINT fk_Movie_Director FOREIGN KEY (DirectorID)
		REFERENCES Director(DirectorID),
	CONSTRAINT fk_Movie_Rating FOREIGN KEY (RatingID)
		REFERENCES Rating(RatingID)
);

CREATE TABLE CastMembers (
	CastMemberID INT NOT NULL IDENTITY (1, 1) PRIMARY KEY,
	ActorID INT NOT NULL,
	MovieID INT NOT NULL,
	Role NVARCHAR(50) NOT NULL

	CONSTRAINT fk_CastMembers_Actor FOREIGN KEY	(ActorID)
		REFERENCES Actor(ActorID),
	CONSTRAINT fk_CastMembers_Movie FOREIGN KEY (MovieID)
		REFERENCES Movie(MovieID)
);
