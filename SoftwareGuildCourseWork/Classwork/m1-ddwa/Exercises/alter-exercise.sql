USE MovieCatalogue;
GO

--ALTER TABLE Actor
	--ADD DateOfDeath DATE NULL


UPDATE Actor SET
	DateOfDeath = '1994-03-04'
WHERE ActorID = 3;