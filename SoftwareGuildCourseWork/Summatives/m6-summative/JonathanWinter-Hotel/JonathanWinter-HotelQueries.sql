--1. Write a query that returns a list of reservations that end in July 2023, including the name of the guest, the room number(s), and the reservation dates.
USE HotelDatabase
GO

SELECT
	g.FirstName,
	g.LastName,
	r.RoomID RoomNumber,
	r.StartDate,
	r.EndDate
FROM Reservation r
INNER JOIN Guest g ON r.GuestID = g.GuestID
WHERE EndDate BETWEEN '2023-07-01' AND '2023-07-31';

/*
	Jonathan	Winter	205	2023-06-28	2023-07-02
	Walter	Holaway	204	2023-07-13	2023-07-14
	Wilfred	Vise	401	2023-07-18	2023-07-21
	Bettyann	Seery	303	2023-07-28	2023-07-29
*/

--2. Write a query that returns a list of all reservations for rooms with a jacuzzi, displaying the guest's name, the room number, and the dates of the reservation.
USE HotelDatabase
GO

SELECT
	g.FirstName,
	g.LastName,
	rv.RoomID,
	rv.StartDate,
	rv.EndDate
	--a.AmenityName
FROM Reservation rv
INNER JOIN Guest g ON rv.GuestID = g.GuestID
INNER JOIN Room rm ON rv.RoomID = rm.RoomID
INNER JOIN RoomAmenity ra ON rm.RoomID = ra.RoomID
--INNER JOIN Amenity a ON ra.AmenityID = a.AmenityID -- Checking for Jacuzzi
WHERE AmenityID = 3

/*
	Bettyann	Seery	203	2023-02-05	2023-02-10
	Duane	Cullison	305	2023-02-22	2023-02-24
	Karie	Yang	201	2023-03-06	2023-03-07
	Jonathan	Winter	307	2023-03-17	2023-03-20
	Walter	Holaway	301	2023-04-09	2023-04-13
	Wilfred	Vise	207	2023-04-23	2023-04-24
	Maritza	Tilton	401	2023-05-30	2023-06-02
	Jonathan	Winter	205	2023-06-28	2023-07-02
	Wilfred	Vise	401	2023-07-18	2023-07-21
	Bettyann	Seery	303	2023-07-28	2023-07-29
	Bettyann	Seery	305	2023-08-30	2023-09-01
	Karie	Yang	203	2023-09-13	2023-09-15
	Duane	Cullison	401	2023-11-22	2023-11-25
	Mack	Simmer	301	2023-11-22	2023-11-25
*/

--3. Write a query that returns all the rooms reserved for a specific guest, including the guest's name, the room(s) reserved, 
--the starting date of the reservation, and how many people were included in the reservation. (Choose a guest's name from the existing data.)
USE HotelDatabase
GO

SELECT
	g.FirstName,
	g.LastName,
	rv.RoomID,
	rv.StartDate,
	rv.EndDate,
	SUM(rv.NumberOfAdults + rv.NumberOfChildren) AS NumberOfPeople
FROM Reservation rv
INNER JOIN Guest g ON rv.GuestID = g.GuestID
WHERE g.GuestID = 3
GROUP BY g.GuestID, g.FirstName, g.LastName, rv.RoomID, rv.StartDate, rv.EndDate;

/*
	Bettyann	Seery	203	2023-02-05	2023-02-10	3
	Bettyann	Seery	303	2023-07-28	2023-07-29	3
	Bettyann	Seery	305	2023-08-30	2023-09-01	1
*/

--4. Write a query that returns a list of rooms, reservation ID, and per-room cost for each reservation. The results should include all rooms, whether or not there is a reservation associated with the room.
USE HotelDatabase
GO

SELECT
	rm.RoomID AS RoomNumber,
	ISNULL(rv.ReservationID, 0) AS ReservationID,
	ISNULL(rv.TotalReservationCost, 0) AS ReservationPrice,
	rt.BasePrice AS BaseRoomPrice,
	rt.ExtraPersonPrice AS AddtPricePerPerson,
	IIF ((rv.NumberOfAdults - rt.StandardOccupancy < 0), 0, ISNULL(rv.NumberOfAdults - rt.StandardOccupancy, 0)) AS AddtAdultsForExtraCharge, -- If NumberOfAdults - Standard Occupancy is < 0, no additional adults for charge.
	IIF (rt.RoomTypeID = 3, rt.BasePrice, ISNULL((SUM(rt.BasePrice + ((rv.NumberOfAdults - rt.StandardOccupancy) * rt.ExtraPersonPrice))), rt.BasePrice)) AS PerRoomCost -- If room is a suite, do base price.  Otherwise calculate addt cost.
FROM Room rm
LEFT OUTER JOIN Reservation rv ON rm.RoomID = rv.RoomID
LEFT OUTER JOIN RoomType rt ON rm.RoomTypeID = rt.RoomTypeID
GROUP BY rm.RoomID, rv.ReservationID, rv.TotalReservationCost, rv.NumberOfAdults, rt.RoomTypeID, rt.BasePrice, rt.ExtraPersonPrice, rt.StandardOccupancy, rv.NumberOfAdults
ORDER BY rm.RoomID ASC, rv.ReservationID ASC

/*
	201	4	199.99	174.99	10.00	0	174.99
	202	7	349.98	174.99	10.00	0	174.99
	203	2	999.95	174.99	10.00	0	174.99
	203	21	399.98	174.99	10.00	0	174.99
	204	16	184.99	174.99	10.00	1	184.99
	205	15	699.96	149.99	0.00	0	149.99
	206	12	599.96	149.99	0.00	0	149.99
	206	23	449.97	149.99	0.00	0	149.99
	207	10	174.99	149.99	0.00	0	149.99
	208	13	599.96	149.99	0.00	0	149.99
	208	20	149.99	149.99	0.00	0	149.99
	301	9	799.96	174.99	10.00	0	164.99
	301	24	599.97	174.99	10.00	0	174.99
	302	6	924.95	174.99	10.00	1	184.99
	302	25	699.96	174.99	10.00	0	174.99
	303	18	199.99	174.99	10.00	0	174.99
	304	8	874.95	174.99	10.00	0	174.99
	304	14	184.99	174.99	10.00	1	184.99
	305	3	349.98	149.99	0.00	0	149.99
	305	19	349.98	149.99	0.00	0	149.99
	306	0	0.00	149.99	0.00	0	149.99
	307	5	524.97	149.99	0.00	0	149.99
	308	1	299.98	149.99	0.00	0	149.99
	401	11	1199.97	399.99	20.00	0	399.99
	401	17	1259.97	399.99	20.00	1	399.99
	401	22	1199.97	399.99	20.00	0	399.99
	402	0	0.00	399.99	20.00	0	399.99
*/

--5. Write a query that returns all the rooms accommodating at least three guests and that are reserved on any date in April 2023.
USE HotelDatabase
GO

SELECT
	rv.RoomID,
	(rv.NumberOfAdults + rv.NumberOfChildren) AS NumberOfPeople,
	rv.StartDate,
	rv.EndDate
FROM Reservation rv
WHERE (rv.StartDate BETWEEN '2023-04-01' AND '2023-04-30' OR rv.EndDate BETWEEN '2023-04-01' AND '2023-04-30')
	AND (rv.NumberOfAdults + rv.NumberOfChildren) >= 3;

--GROUP BY rv.RoomID, rv.StartDate, rv.EndDate
--HAVING SUM(rv.NumberOfAdults + rv.NumberOfChildren) >= 3

/*
	There are no reservations ending in April 2023 that have at least 3 guests.  There are three reservations that are in April and they only have 1 or 2 guests.
*/

--6. Write a query that returns a list of all guest names and the number of reservations per guest, sorted starting with the guest with the most reservations and then by the guest's last name.
USE HotelDatabase
GO

SELECT
	g.FirstName,
	g.LastName,
	COUNT(rv.ReservationID) AS NumberOfReservations
FROM Reservation rv
INNER JOIN Guest g ON rv.GuestID = g.GuestID
GROUP BY g.FirstName, g.LastName
ORDER BY COUNT(rv.ReservationID) DESC, g.LastName ASC;

/*
	Mack	Simmer	4
	Bettyann	Seery	3
	Karie	Yang	2
	Jonathan	Winter	2
	Wilfred	Vise	2
	Joleen	Tison	2
	Maritza	Tilton	2
	Aurore	Lipton	2
	Walter	Holaway	2
	Duane	Cullison	2
	Jeremiah	Pendergrass	1
	Zachery	Luechtefeld	1
*/

--7. Write a query that displays the name, address, and phone number of a guest based on their phone number. (Choose a phone number from the existing data.)
USE HotelDatabase
GO

SELECT
	g.FirstName,
	g.LastName,
	g.Address,
	g.PhoneNumber
FROM Guest g
WHERE g.PhoneNumber = '291-553-0508';

/*
	Mack	Simmer	379 Old Shore Street	291-553-0508
*/