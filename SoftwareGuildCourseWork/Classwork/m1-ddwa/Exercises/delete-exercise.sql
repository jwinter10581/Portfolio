USE MovieCatalogue;
GO

DELETE FROM CastMembers
	WHERE MovieID = 1;

DELETE FROM Movie
	WHERE Title = 'Rambo: First Blood';
