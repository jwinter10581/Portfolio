USE DvdLibrary

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'DvdsInsert')
    DROP PROCEDURE DvdsInsert
GO
CREATE PROCEDURE DvdsInsert (
	@Id int output,
	@Title varchar(100),
	@ReleaseYear int,
	@Director varchar(100),
	@Rating varchar(5),
	@Notes varchar(200)
) AS
BEGIN
	INSERT INTO Dvds (Title, ReleaseYear, Director, Rating, Notes)
	VALUES (@Title, @ReleaseYear, @Director, @Rating, @Notes);
	SET @Id = SCOPE_IDENTITY();
END
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'DvdsUpdate')
      DROP PROCEDURE DvdsUpdate
GO

CREATE PROCEDURE DvdsUpdate (
	@Id int,
	@Title varchar(100),
	@ReleaseYear int,
	@Director varchar(100),
	@Rating varchar(5),
	@Notes varchar(200)
) AS
BEGIN
	UPDATE Dvds SET 
		Title = @Title, 
		ReleaseYear = @ReleaseYear, 
		Director = @Director, 
		Rating = @Rating, 
		Notes = @Notes
	WHERE Id = @Id
END
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'DvdsDelete')
      DROP PROCEDURE DvdsDelete
GO
CREATE PROCEDURE DvdsDelete (
	@Id int
) AS
BEGIN
	DELETE FROM Dvds WHERE Id = @Id;
END
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'DvdsSelectAll')
      DROP PROCEDURE DvdsSelectAll
GO

CREATE PROCEDURE DvdsSelectAll AS
BEGIN
	SELECT Id, Title, ReleaseYear, Director, Rating, Notes
	FROM Dvds
	ORDER BY Id
END
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'DvdsSelectById')
      DROP PROCEDURE DvdsSelectById
GO
CREATE PROCEDURE DvdsSelectById (
	@Id int
) AS
BEGIN
	SELECT Id, Title, ReleaseYear, Director, Rating, Notes
	FROM Dvds
	WHERE Id = @Id
END
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'DvdsSelectByTitle')
      DROP PROCEDURE DvdsSelectByTitle
GO
CREATE PROCEDURE DvdsSelectByTitle (
	@Title varchar(100)
) AS
BEGIN
	SELECT Id, Title, ReleaseYear, Director, Rating, Notes
	FROM Dvds
	WHERE Title LIKE '%' + @Title + '%'
END
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'DvdsSelectByReleaseYear')
      DROP PROCEDURE DvdsSelectByReleaseYear
GO
CREATE PROCEDURE DvdsSelectByReleaseYear (
	@ReleaseYear int
) AS
BEGIN
	SELECT Id, Title, ReleaseYear, Director, Rating, Notes
	FROM Dvds
	WHERE ReleaseYear = @ReleaseYear
END
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'DvdsSelectByDirector')
      DROP PROCEDURE DvdsSelectByDirector
GO
CREATE PROCEDURE DvdsSelectByDirector (
	@Director varchar(100)
) AS
BEGIN
	SELECT Id, Title, ReleaseYear, Director, Rating, Notes
	FROM Dvds
	WHERE Director LIKE '%' + @Director + '%'
END
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'DvdsSelectByRating')
      DROP PROCEDURE DvdsSelectByRating
GO
CREATE PROCEDURE DvdsSelectByRating (
	@Rating varchar(5)
) AS
BEGIN
	SELECT Id, Title, ReleaseYear, Director, Rating, Notes
	FROM Dvds
	WHERE Rating = @Rating
END
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'DvdLibaryDbReset')
      DROP PROCEDURE DvdLibaryDbReset
GO

/*
==================================================
Created DbReset for Unit Testing
==================================================
*/

CREATE PROCEDURE DvdLibaryDbReset AS
BEGIN
	DELETE FROM Dvds;

	DBCC CHECKIDENT ('dvds', RESEED, 1)

SET IDENTITY_INSERT Dvds ON;

INSERT INTO Dvds(Id, Title, ReleaseYear, Director, Rating, Notes)
	VALUES (1, 'The Grand Budapest Hotel', 2014, 'Wes Anderson', 'R', 'Comedy-Drama'),
			(2, '2001: A Space Odyssey', 2001, 'Stanley Kubrick', 'G', 'Science Fiction'),
			(3, 'Psycho', 1960, 'Alfred Hitchcock', 'R', 'Horror'),
			(4, 'Interstellar', 2014, 'Christopher Nolan', 'PG-13', 'Science Fiction'),
			(5, 'Big Eyes', 2014, 'Tim Burton', 'PG-13', 'Comedy-Drama'),
			(6, 'The Nightmare Before Christmas', 1993, 'Tim Burton', 'PG', 'Animation')

SET IDENTITY_INSERT Dvds OFF;
END