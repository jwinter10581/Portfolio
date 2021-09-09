USE MovieCatalogue;
GO

UPDATE Movie SET
	Title = 'Ghostbusters (1984)',
	ReleaseDate = '1984-06-08'
WHERE Title = 'Ghostbusters';

UPDATE Genre SET
	GenreName = 'Action/Adventure'
WHERE GenreName = 'Action';