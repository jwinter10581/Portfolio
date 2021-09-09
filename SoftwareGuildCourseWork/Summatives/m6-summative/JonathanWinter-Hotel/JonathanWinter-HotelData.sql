USE HotelDatabase
GO

INSERT INTO Amenity (AmenityID, AmenityName, AmenityPrice) VALUES
	(1, 'Microwave', 0),
	(2, 'Refrigerator', 0),
	(3, 'Jacuzzi', 25.00),
	(4, 'Oven', 0)

INSERT INTO RoomType (RoomTypeID, RoomTypeName, StandardOccupancy, MaxOccupancy, BasePrice, ExtraPersonPrice) VALUES
	(1, 'Single', 2, 2, 149.99, 0.00),
	(2, 'Double', 2, 4, 174.99, 10.00),
	(3, 'Suite', 3, 8, 399.99, 20.00)

INSERT INTO Guest (FirstName, LastName, Address, City, StateAbbreviation, PostalCode, PhoneNumber) VALUES
	('Jonathan', 'Winter', '3925 Valley View Drive North', 'Eagan', 'MN', '55121', '612-357-6424'),
	('Mack', 'Simmer', '379 Old Shore Street',	'Council Bluffs', 'IA',	'51501', '291-553-0508'),
	('Bettyann', 'Seery', '750 Wintergreen Dr.', 'Wasilla', 'AK', '99654', '478-277-9632'),
	('Duane', 'Cullison', '9662 Foxrun Lane', 'Harlingen', 'TX', '78552', '308-494-0198'),
	('Karie', 'Yang', '9378 W. Augusta Ave.', 'West Deptford', 'NJ', '08096', '214-730-0298'),
	('Aurore', 'Lipton', '762 Wild Rose Street', 'Saginaw', 'MI', '48601', '377-507-0974'),
	('Zachery', 'Luechtefeld', '7 Poplar Dr.', 'Arvada', 'CO', '80003', '814-485-2615'),
	('Jeremiah', 'Pendergrass', '70 Oakwood St.', 'Zion', 'IL', '60099', '279-491-0960'),
	('Walter', 'Holaway', '7556 Arrowhead St.', 'Cumberland', 'RI', '02864', '446-396-6785'),
	('Wilfred', 'Vise', '77 West Surrey Street', 'Oswego', 'NY', '13126', '834-727-1001'),
	('Maritza', 'Tilton', '939 Linda Rd.', 'Burke', 'VA', '22015', '446-351-6860'),
	('Joleen', 'Tison', '87 Queen St.', 'Drexel Hill', 'PA', '19026',	'231-893-2755')

INSERT INTO ROOM (RoomID, RoomTypeID, ADAAccessible) VALUES
	(201, 2, 0),
	(202, 2, 1),
	(203, 2, 0),
	(204, 2, 1),
	(205, 1, 0),
	(206, 1, 1),
	(207, 1, 0),
	(208, 1, 1),
	(301, 2, 0),
	(302, 2, 1),
	(303, 2, 0),
	(304, 2, 1),
	(305, 1, 0),
	(306, 1, 1),
	(307, 1, 0),
	(308, 1, 1),
	(401, 3, 1),
	(402, 3, 1)

INSERT INTO RoomAmenity (AmenityID, RoomID) VALUES
	(1, 201),
	(3, 201),
	(2, 202),
	(1, 203),	
	(3, 203),
	(2, 204),	
	(1, 205),
	(2, 205),
	(3, 205),
	(1, 206),
	(2, 206),
	(1, 207),
	(2, 207),
	(3, 207),
	(1, 208),
	(2, 208),
	(1, 301),
	(3, 301),
	(2, 302),
	(1, 303),
	(3, 303),
	(2, 304),
	(1, 305),
	(2, 305),
	(3, 305),
	(1, 306),
	(2, 306),
	(1, 307),
	(2, 307),
	(3, 307),
	(1, 308),
	(2, 308),
	(1, 401),
	(2, 401),
	(4, 401),
	(1, 402),
	(2, 402),
	(4, 402)

INSERT INTO Reservation (RoomID, GuestID, NumberOfAdults, NumberOfChildren, StartDate, EndDate, TotalReservationCost) VALUES
	(308, 2, 1, 0, '2/2/2023', '2/4/2023', 299.98),
	(203, 3, 2, 1, '2/5/2023', '2/10/2023', 999.95),
	(305, 4, 2, 0, '2/22/2023', '2/24/2023', 349.98),
	(201, 5, 2, 2, '3/6/2023', '3/7/2023', 199.99),
	(307, 1, 1, 1, '3/17/2023', '3/20/2023', 524.97),
	(302, 6, 3, 0, '3/18/2023', '3/23/2023', 924.95),
	(202, 7, 2, 2, '3/29/2023', '3/31/2023', 349.98),
	(304, 8, 2, 0, '3/31/2023', '4/5/2023', 874.95),
	(301, 9, 1, 0, '4/9/2023', '4/13/2023', 799.96),
	(207, 10, 1, 1, '4/23/2023', '4/24/2023', 174.99),
	(401, 11, 2, 4, '5/30/2023', '6/2/2023', 1199.97),
	(206, 12, 2, 0, '6/10/2023', '6/14/2023', 599.96),
	(208, 12, 1, 0, '6/10/2023', '6/14/2023', 599.96),
	(304, 6, 3, 0, '6/17/2023', '6/18/2023', 184.99),
	(205, 1, 2, 0, '6/28/2023', '7/2/2023', 699.96),
	(204, 9, 3, 1, '7/13/2023', '7/14/2023', 184.99),
	(401, 10, 4, 2, '7/18/2023', '7/21/2023', 1259.97),
	(303, 3, 2, 1, '7/28/2023', '7/29/2023', 199.99),
	(305, 3, 1, 0, '8/30/2023', '9/1/2023', 349.98),
	(208, 2, 2, 0, '9/16/2023', '9/17/2023', 149.99),
	(203, 5, 2, 2, '9/13/2023', '9/15/2023', 399.98),
	(401, 4, 2, 2, '11/22/2023', '11/25/2023', 1199.97),
	(206, 2, 2, 0, '11/22/2023', '11/25/2023', 449.97),
	(301, 2, 2, 2, '11/22/2023', '11/25/2023', 599.97),
	(302, 11, 2, 0, '12/24/2023', '12/28/2023', 699.96)

	
--Delete Jeremiah Pendergrass (GuestID 8) from Reservation & Guest
USE HotelDatabase
GO


DELETE FROM Reservation
WHERE Reservation.GuestID = 8;

DELETE FROM Guest
WHERE Guest.FirstName = 'Jeremiah' AND Guest.LastName = 'Pendergrass';

SELECT *
FROM Reservation
WHERE Reservation.GuestID = 8;

SELECT *
FROM Guest
WHERE Guest.FirstName = 'Jeremiah' OR Guest.LastName = 'Pendergrass' OR Guest.GuestID = 8;