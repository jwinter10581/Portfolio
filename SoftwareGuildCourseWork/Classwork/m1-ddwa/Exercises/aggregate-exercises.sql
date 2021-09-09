USE PersonalTrainer
GO

-- Use an aggregate to count the number of Clients.
-- 500 rows
--------------------

USE PersonalTrainer
GO
SELECT COUNT(ClientID)
FROM Client;

-- Use an aggregate to count Client.BirthDate.
-- The number is different than total Clients. Why?  There are 37 clients who's birthday is listed as null.
-- 463 rows
--------------------

USE PersonalTrainer
GO
SELECT COUNT(BirthDate)
FROM Client;

-- Group Clients by City and count them.
-- Order by the number of Clients desc.
-- 20 rows
--------------------

USE PersonalTrainer
GO
SELECT
	City CityName,
	Count(City) CityCount
FROM Client c
GROUP BY c.City
Order BY Count(City) DESC;

-- Calculate a total per invoice using only the InvoiceLineItem table.
-- Group by InvoiceId.
-- You'll need an expression for the line item total: Price * Quantity.
-- Aggregate per group using SUM().
-- 1884 rows
--------------------

USE PersonalTrainer
GO
SELECT
	InvoiceId,
	SUM(Price *  Quantity) Total
FROM InvoiceLineItem
GROUP BY InvoiceId;

-- Calculate a total per invoice using only the InvoiceLineItem table.
-- (See above.)
-- Only include totals greater than $500.00.
-- Order from lowest total to highest.
-- 234 rows
--------------------

USE PersonalTrainer
GO
SELECT
	InvoiceId,
	SUM(Price * Quantity) Total
FROM InvoiceLineItem
GROUP BY InvoiceId
HAVING SUM(Price * Quantity) > 500;

-- Calculate the average line item total
-- grouped by InvoiceLineItem.Description.
-- 3 rows
--------------------

USE PersonalTrainer
GO
SELECT 
	Description,
	AVG(Price * Quantity)
FROM InvoiceLineItem
GROUP BY Description;

-- Select ClientId, FirstName, and LastName from Client
-- for clients who have *paid* over $1000 total.
-- Paid is Invoice.InvoiceStatus = 2.
-- Order by LastName, then FirstName.
-- 146 rows
--------------------

USE PersonalTrainer
GO
SELECT
	c.ClientId,
	c.FirstName,
	c.LastName,
	SUM(ili.Price * Quantity) TotalPaid
FROM Client c
INNER JOIN Invoice i ON c.ClientId = i.ClientId
INNER JOIN InvoiceLineItem ili ON i.InvoiceId = ili.InvoiceId
GROUP BY c.ClientId, c.FirstName, c.LastName, I.InvoiceStatus
HAVING SUM(ili.Price * ili.Quantity) > 1000 AND I.InvoiceStatus = 2;


-- Count exercises by category.
-- Group by ExerciseCategory.Name.
-- Order by exercise count descending.
-- 13 rows
--------------------

USE PersonalTrainer
GO
SELECT
	ec.Name,
	COUNT(ec.ExerciseCategoryId) ExerciseCount
FROM Exercise e
INNER JOIN ExerciseCategory ec ON e.ExerciseCategoryId = ec.ExerciseCategoryId
GROUP BY ec.Name, ec.ExerciseCategoryId
ORDER BY COUNT(e.ExerciseCategoryId) DESC;

-- Select Exercise.Name along with the minimum, maximum,
-- and average ExerciseInstance.Sets.
-- Order by Exercise.Name.
-- 64 rows  -- I feel like this should be 61... There's 2 copies of Curl & 3 Copies of Squat which would add the extra 3 exercises.  Those three additional rows get grouped together when you group by name.
--------------------

USE PersonalTrainer
GO
SELECT
	e.Name ExerciseName,
	MIN(ei.Sets) MinSets,
	MAX(ei.Sets) MaxSets,
	AVG(ei.Sets) AvgSets
FROM Exercise e
INNER JOIN ExerciseInstance ei ON e.ExerciseId = ei.ExerciseId
GROUP BY e.Name
ORDER BY e.Name;
	
USE PersonalTrainer
GO
SELECT
	Exercise.Name
FROM Exercise
ORDER BY Exercise.Name

-- Find the minimum and maximum Client.BirthDate
-- per Workout.
-- 26 rows
-- Sample: 
-- WorkoutName, EarliestBirthDate, LatestBirthDate
-- '3, 2, 1... Yoga!', '1928-04-28', '1993-02-07'
--------------------

USE PersonalTrainer
GO
SELECT
	w.Name WorkoutName,
	MIN(c.BirthDate) EarliestBirthDate,
	MAX(c.BirthDate) LatestBirthDate
FROM Workout w
INNER JOIN ClientWorkout cw ON w.WorkoutId = cw.WorkoutId
INNER JOIN Client c ON cw.ClientId = c.ClientId
GROUP BY w.Name
ORDER BY w.Name;

-- Count client goals.
-- Be careful not to exclude rows for clients without goals.
-- 500 rows total
-- 50 rows with no goals
--------------------
/*
		USE PersonalTrainer
		GO
		SELECT
			g.Name GoalName,
			COUNT(g.Name)
		FROM Goal g
		INNER JOIN ClientGoal cg ON g.GoalId = cg.GoalId
		INNER JOIN Client c ON cg.ClientId = c.ClientId
		GROUP BY g.Name
*/

-- Select Exercise.Name, Unit.Name, 
-- and minimum and maximum ExerciseInstanceUnitValue.Value
-- for all exercises with a configured ExerciseInstanceUnitValue.
-- Order by Exercise.Name, then Unit.Name.
-- 82 rows
--------------------

/*
		USE PersonalTrainer
		GO
		SELECT
			e.Name ExerciseName,
			u.Name UnitName,
			MIN(eiuv.Value) MinValue,
			MAX(eiuv.Value) MaxValue
		FROM Exercise e
		INNER JOIN ExerciseInstance ei ON e.ExerciseId = ei.ExerciseId
		INNER JOIN ExerciseInstanceUnitValue eiuv ON ei.ExerciseInstanceId = eiuv.ExerciseInstanceId
		INNER JOIN Unit u ON eiuv.UnitId = u.UnitId
		GROUP BY u.Name, e.Name
		ORDER BY e.Name, u.Name
*/ 

-- Modify the query above to include ExerciseCategory.Name.
-- Order by ExerciseCategory.Name, then Exercise.Name, then Unit.Name.
-- 82 rows
--------------------

-- Select the minimum and maximum age in years for
-- each Level.
-- To calculate age in years, use the T-SQL function DATEDIFF.
-- 4 rows
--------------------

USE PersonalTrainer
GO
SELECT
	l.Name LevelName,
	MIN(c.BirthDate) MinAge,
	MAX(c.BirthDate) MaxAge,
	DATEDIFF(year, MIN(c.BirthDate), MAX(c.BirthDate)) AS AgeRange
FROM CLIENT c
INNER JOIN ClientWorkout cw ON c.ClientId = cw.ClientId
INNER JOIN Workout w ON cw.WorkoutId = w.WorkoutId
INNER JOIN [Level] l ON w.LevelId = l.LevelId
GROUP BY l.[Name], l.LevelId
ORDER BY l.LevelId

-- Stretch Goal!
-- Count logins by email extension (.com, .net, .org, etc...).
-- Research SQL functions to isolate a very specific part of a string value.
-- 27 rows (27 unique email extensions)
--------------------

USE PersonalTrainer
GO
SELECT DISTINCT CASE WHEN CHARINDEX('.',SUBSTRING(l.EmailAddress, CHARINDEX('.', l.EmailAddress)+1, LEN(l.EmailAddress)-CHARINDEX('.', l.EmailAddress))) > 0 
				THEN SUBSTRING(SUBSTRING(l.EmailAddress, CHARINDEX('.', l.EmailAddress)+1, LEN(l.EmailAddress)-CHARINDEX('.', l.EmailAddress)), 0, CHARINDEX('.',SUBSTRING(l.EmailAddress, CHARINDEX('.', l.EmailAddress)+1, LEN(l.EmailAddress)-CHARINDEX('.', l.EmailAddress))))
				ELSE SUBSTRING(l.EmailAddress, CHARINDEX('.', l.EmailAddress)+1, LEN(l.EmailAddress)-CHARINDEX('.', l.EmailAddress))
				END AS EmailExtension
FROM Login l

/*
SELECT
	SUBSTRING(SUBSTRING(l.EmailAddress, CHARINDEX('.', l.EmailAddress)+1, LEN(l.EmailAddress)-CHARINDEX('.', l.EmailAddress)), -- original string
			  0, -- start at 0
			  0 -- Grab a substring from 0 to .)
*/

	--SUBSTRING(l.EmailAddress, CHARINDEX('.', l.EmailAddress)+1, LEN(l.EmailAddress) - CHARINDEX('.', l.EmailAddress)) EmailExtension -- Selects everything after . in Login EmailAddress
	--SUBSTRING(l.EmailAddress, CHARINDEX('@', l.EmailAddress)+1, LEN(l.EmailAddress) - CHARINDEX('@', l.EmailAddress)) EmailExtension -- Selects everything after @ sign in Login EmailAddress

-- Stretch Goal!
-- Match client goals to workout goals.
-- Select Client FirstName and LastName and Workout.Name for
-- all workouts that match at least 2 of a client's goals.
-- Order by the client's last name, then first name.
-- 139 rows
--------------------