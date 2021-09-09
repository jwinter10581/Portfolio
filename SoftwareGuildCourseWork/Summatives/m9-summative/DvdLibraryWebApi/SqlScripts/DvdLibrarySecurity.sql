/*
The DvdLibrarySecurity.sql file must perform the following actions.

    Create a server login named 'DvdLibraryApp' with a password of 'testing123'.
    Create a database account for 'DvdLibraryApp'.
    Grant Execute on all used stored procedures to 'DvdLibraryApp'
    Grant SELECT, INSERT, UPDATE, and DELETE on all used tables to 'DvdLibraryApp'
*/

USE MASTER
GO

CREATE LOGIN DvdLibraryApp WITH PASSWORD='testing123'
GO

USE DvdLibrary
GO

CREATE USER DvdLibraryApp FOR LOGIN DvdLibraryApp
GO

GRANT EXECUTE ON DvdsInsert TO DvdLibraryApp
GRANT EXECUTE ON DvdsUpdate TO DvdLibraryApp
GRANT EXECUTE ON DvdsDelete TO DvdLibraryApp
GRANT EXECUTE ON DvdsSelectAll TO DvdLibraryApp
GRANT EXECUTE ON DvdsSelectById TO DvdLibraryApp
GRANT EXECUTE ON DvdsSelectByTitle TO DvdLibraryApp
GRANT EXECUTE ON DvdsSelectByReleaseYear TO DvdLibraryApp
GRANT EXECUTE ON DvdsSelectByDirector TO DvdLibraryApp
GRANT EXECUTE ON DvdsSelectByRating TO DvdLibraryApp
GO