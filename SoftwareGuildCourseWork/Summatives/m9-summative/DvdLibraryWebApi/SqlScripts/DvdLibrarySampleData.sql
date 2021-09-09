USE DvdLibrary
GO

SET IDENTITY_INSERT Dvds ON;

INSERT INTO Dvds(Id, Title, ReleaseYear, Director, Rating, Notes)
	VALUES (1, 'The Grand Budapest Hotel', 2014, 'Wes Anderson', 'R', 'Comedy-Drama'),
			(2, '2001: A Space Odyssey', 2001, 'Stanley Kubrick', 'G', 'Science Fiction'),
			(3, 'Psycho', 1960, 'Alfred Hitchcock', 'R', 'Horror'),
			(4, 'Interstellar', 2014, 'Christopher Nolan', 'PG-13', 'Science Fiction'),
			(5, 'Big Eyes', 2014, 'Tim Burton', 'PG-13', 'Comedy-Drama'),
			(6, 'The Nightmare Before Christmas', 1993, 'Tim Burton', 'PG', 'Animation')

SET IDENTITY_INSERT Dvds OFF;