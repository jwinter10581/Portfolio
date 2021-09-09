USE master
GO

IF EXISTS(SELECT * FROM sys.databases WHERE name='MovieCatalog')
DROP DATABASE MovieCatalog
GO

CREATE DATABASE MovieCatalog
GO

USE MovieCatalog
GO

-- Tables
IF EXISTS(SELECT * FROM sys.tables WHERE name='Movie')
	DROP TABLE Movie
GO

IF EXISTS(SELECT * FROM sys.tables WHERE name='Rating')
	DROP TABLE Rating
GO

IF EXISTS(SELECT * FROM sys.tables WHERE name='Genre')
	DROP TABLE Genre
GO

CREATE TABLE Genre (
	GenreId int identity(1,1) primary key not null,
	GenreType varchar(50) not null
)

CREATE TABLE Rating (
	RatingId int identity(1,1) primary key not null,
	RatingName varchar(50) not null
)

CREATE TABLE Movie (
	MovieId int identity(1,1) primary key not null,
	RatingId int foreign key references Rating(RatingId) null,
	GenreId int foreign key references Genre(GenreId) not null,
	Title varchar(50) not null
)

-- Stored Procedures
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'MovieSelectAll')
      DROP PROCEDURE MovieSelectAll
GO

CREATE PROCEDURE MovieSelectAll
AS
	SELECT MovieId, Title, GenreType, RatingName
	FROM Movie m 
		INNER JOIN Genre g ON m.GenreId = g.GenreId
		LEFT JOIN Rating r ON m.RatingId = r.RatingId
	ORDER BY Title
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'MovieSelectById')
      DROP PROCEDURE MovieSelectById
GO

CREATE PROCEDURE MovieSelectById (
	@MovieId int
)
AS
	SELECT MovieId, Title, GenreId, RatingId
	FROM Movie
	WHERE MovieId = @MovieId
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'MovieInsert')
      DROP PROCEDURE MovieInsert
GO

CREATE PROCEDURE MovieInsert (
	@MovieId int output,
	@GenreId int,
	@RatingId int,
	@Title Varchar(50)
)
AS
	INSERT INTO Movie (GenreId, RatingId, Title)
	VALUES (@GenreId, @RatingId, @Title)

	SET @MovieId = SCOPE_IDENTITY()
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'MovieUpdate')
      DROP PROCEDURE MovieUpdate
GO

CREATE PROCEDURE MovieUpdate (
	@MovieId int,
	@GenreId int,
	@RatingId int,
	@Title Varchar(50)
)
AS
	UPDATE Movie
		SET GenreId = @GenreId,
		RatingID = @RatingId,
		Title = @Title
	WHERE MovieId = @MovieId
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'MovieDelete')
      DROP PROCEDURE MovieDelete
GO

CREATE PROCEDURE MovieDelete (
	@MovieId int
)
AS
	DELETE FROM Movie
	WHERE MovieId = @MovieId
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'RatingSelectAll')
      DROP PROCEDURE RatingSelectAll
GO

CREATE PROCEDURE RatingSelectAll
AS
	SELECT RatingId, RatingName
	FROM Rating
	ORDER BY RatingName
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'GenreSelectAll')
      DROP PROCEDURE GenreSelectAll
GO

CREATE PROCEDURE GenreSelectAll
AS
	SELECT GenreId, GenreType
	FROM Genre
	ORDER BY GenreType
GO

-- Sample Data
SET IDENTITY_INSERT Genre ON

INSERT INTO Genre (GenreId, GenreType)
VALUES (1, 'Action'),
	(2, 'Horror'),
	(3, 'Kids'),
	(4, 'Mystery'),
	(5, 'Romance'),
	(6, 'Sci-Fi')

SET IDENTITY_INSERT Genre OFF

SET IDENTITY_INSERT Rating ON

INSERT INTO Rating (RatingId, RatingName)
VALUES (1, 'G'),
	(2, 'PG'),
	(3, 'PG-13'),
	(4, 'R')

SET IDENTITY_INSERT Rating OFF

SET IDENTITY_INSERT Movie ON

INSERT INTO Movie (MovieId, RatingId, GenreId, Title)
VALUES (1, 1, 3, 'The Lion King'),
	(2, 4, 6, 'Terminator'),
	(3, 4, 2, 'Friday the 13th'),
	(4, null, 6, 'This movie has no rating')

SET IDENTITY_INSERT Movie OFF