USE PersonalTrainer
GO

-- Select all rows and columns from the Exercise table.
-- 64 rows
--------------------
SELECT *
FROM Exercise

-- Select all rows and columns from the Client table.
-- 500 rows
--------------------

USE PersonalTrainer
GO
SELECT *
FROM Client;

-- Select all columns from Client where the City is Metairie.
-- 29 rows
--------------------

USE PersonalTrainer
GO
SELECT *
FROM Client
WHERE City = 'Metairie';

-- Is there a Client with the ClientId '818a7faf-7b4b-48a2-bf12-7a26c92de20c'?
-- nope
--------------------

USE PersonalTrainer
GO
SELECT *
FROM Client
WHERE ClientId = '818a7faf-7b4b-48a2-bf12-7a26c92de20c';

-- How many rows in the Goal table?
-- 17 rows
--------------------

USE PersonalTrainer
GO
--SELECT *
SELECT COUNT (*)
FROM Goal;

-- Select Name and LevelId from the Workout table.
-- 26 rows
--------------------

USE PersonalTrainer
GO
SELECT Name, LevelId
FROM Workout;

-- Select Name, LevelId, and Notes from Workout where LevelId is 2.
-- 11 rows
--------------------

USE PersonalTrainer
GO
SELECT Name, LevelId, Notes
From Workout
WHERE LevelId = 2;

-- Select FirstName, LastName, and City from Client 
-- where City is Metairie, Kenner, or Gretna.
-- 77 rows
--------------------

USE PersonalTrainer
GO
SELECT FirstName, LastName, City
FROM CLIENT
WHERE City IN ('Metairie', 'Kenner', 'Gretna');

-- Select FirstName, LastName, and BirthDate from Client
-- for Clients born in the 1980s.
-- 72 rows
--------------------

USE PersonalTrainer
GO
SELECT FirstName, LastName, BirthDate
FROM Client
WHERE BirthDate BETWEEN '1980-01-01' AND '1989-12-31';

-- Write the query above in a different way. 
-- If you used BETWEEN, you can't use it again.
-- If you didn't use BETWEEN, use it!
-- Still 72 rows
--------------------

USE PersonalTrainer
GO
SELECT FirstName, LastName, BirthDate
FROM Client
WHERE BirthDate >= '1980-01-01' AND BirthDate <= '1989-12-31';

-- How many rows in the Login table have a .gov EmailAddress?
-- 17 rows
--------------------

USE PersonalTrainer
GO
--SELECT *
SELECT COUNT (*)
FROM Login
WHERE EmailAddress LIKE '%.gov';

-- How many Logins do NOT have a .com EmailAddress?
-- 122 rows
--------------------

USE PersonalTrainer
GO
--SELECT *
SELECT Count (*)
FROM Login
WHERE EmailAddress NOT LIKE '%.com';

-- Select first and last name of Clients without a BirthDate.
-- 37 rows
--------------------

USE PersonalTrainer
GO
SELECT FirstName, LastName
FROM Client
WHERE BirthDate IS Null;

-- Select the Name of each ExerciseCategory that has a parent.
-- (ParentCategoryId value is not null)
-- 12 rows
--------------------

USE PersonalTrainer
GO
SELECT Name
FROM ExerciseCategory
WHERE ParentCategoryId IS NOT NULL;

-- Select Name and Notes of each level 3 Workout that
-- contains the word 'you' in its Notes.
-- 4 rows
--------------------

USE PersonalTrainer
GO
SELECT Name, Notes
FROM Workout
WHERE LevelId = 3 AND Notes LIKE '%you%';

-- Select FirstName, LastName, City from Clients who have a LastName
-- that starts with L,M, or N and who live in LaPlace.
-- 5 rows
--------------------

USE PersonalTrainer
GO
SELECT FirstName, LastName, City
FROM Client
WHERE City = 'LaPlace' 
AND (LastName LIKE 'L%' OR LastName LIKE 'M%' OR LastName LIKE 'N%');

-- Select InvoiceId, Description, Price, Quantity, ServiceDate 
-- and the line item total, a calculated value, where the line item total
-- is between 15 and 25 dollars.
-- 667 rows
--------------------

USE PersonalTrainer
GO
SELECT InvoiceId, Description, Price, Quantity, ServiceDate, (Price*Quantity) as Total
FROM InvoiceLineItem
WHERE (PRICE*Quantity) BETWEEN 15 AND 25;

-- Does the Client, Estrella Bazely, have a Login? 
-- If so, what is her email address?
-- This requires two queries:
-- First, select a Client record for Estrella Bazely. Does it exist?
-- Second, if it does, select a Login record that matches its ClientId.
--------------------

USE PersonalTrainer
GO
SELECT EmailAddress
FROM Login
WHERE ClientId = (SELECT ClientId
					FROM Client
					Where FirstName = 'Estrella' AND LastName = 'Bazely');

-- What are the Goals of the Workout with the Name 'This Is Parkour'?
-- You need three queries!:
-- 1. Select the WorkoutId from Workout where Name equals 'This Is Parkour'.
-- 2. Select GoalId from WorkoutGoal where the WorkoutId matches the WorkoutId
--    from your first query.
-- 3. Select everything from Goal where the GoalId is one of the GoalIds from your
--    second query.
-- 1 row, 3 rows, 3 rows
--------------------

USE PersonalTrainer
GO
SELECT *
FROM Goal
WHERE GoalID IN (SELECT GOALId
				 From WorkoutGoal
				 Where WorkoutID = (SELECT WorkoutId
								    FROM Workout
								    WHERE Name = 'This Is Parkour'));

-- IN for multiple results query, = for single result query