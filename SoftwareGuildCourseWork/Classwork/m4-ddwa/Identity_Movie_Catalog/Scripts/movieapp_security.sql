USE master
GO

CREATE LOGIN MovieApp WITH PASSWORD='Testing123'
GO

USE MovieCatalog
GO

CREATE USER MovieApp FOR LOGIN MovieApp
GO

GRANT EXECUTE ON MovieSelectAll TO MovieApp
GRANT EXECUTE ON MovieSelectById TO MovieApp
GRANT EXECUTE ON MovieInsert TO MovieApp
GRANT EXECUTE ON MovieUpdate TO MovieApp
GRANT EXECUTE ON MovieDelete TO MovieApp
GRANT EXECUTE ON GenreSelectAll TO MovieApp
GRANT EXECUTE ON RatingSelectAll TO MovieApp
GO