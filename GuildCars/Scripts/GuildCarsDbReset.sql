IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'GuildCarsDbReset')
      DROP PROCEDURE GuildCarsDbReset
GO

CREATE PROCEDURE GuildCarsDbReset AS
BEGIN
	DELETE FROM Special;
	DELETE FROM Purchase;
	DELETE FROM [State];
	DELETE FROM PurchaseType;
	DELETE FROM Contact;
	DELETE FROM Vehicle;
	DELETE FROM Interior;
	DELETE FROM Color;
	DELETE FROM VehicleType;
	DELETE FROM BodyStyle;
	DELETE FROM Transmission;
	DELETE FROM Model;
	DELETE FROM Make;
	DELETE FROM Employee;
	DELETE FROM [Role];

	DBCC CHECKIDENT ('Special', RESEED, 1);
	DBCC CHECKIDENT ('Employee', RESEED, 1);
	DBCC CHECKIDENT ('Make', RESEED, 1);
	DBCC CHECKIDENT ('Model', RESEED, 1);
	DBCC CHECKIDENT ('Contact', RESEED, 1);
	DBCC CHECKIDENT ('Purchase', RESEED, 1);

	SET IDENTITY_INSERT Special ON;
	INSERT INTO Special (SpecialId, Title, [Description])
	VALUES
		(1, 'Special Title 1', 'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Praesent venenatis vitae enim vel facilisis. Mauris dictum purus tincidunt, sagittis quam id, 
		varius lectus. Maecenas in sem sodales, auctor diam id, egestas ligula. Cras at cursus erat. Praesent eleifend ex orci, quis lacinia elit consequat vitae. Nunc faucibus vel lorem 
		ut iaculis. Suspendisse risus orci, aliquet nec euismod quis, euismod ut nisi. Etiam feugiat quam a leo egestas commodo vel nec erat.'),
		(2, 'Special Title 2', 'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Praesent venenatis vitae enim vel facilisis. Mauris dictum purus tincidunt, sagittis quam id,
		varius lectus. Maecenas in sem sodales, auctor diam id, egestas ligula. Cras at cursus erat. Praesent eleifend ex orci, quis lacinia elit consequat vitae. Nunc faucibus vel lorem
		ut iaculis. Suspendisse risus orci, aliquet nec euismod quis, euismod ut nisi. Etiam feugiat quam a leo egestas commodo vel nec erat.'),
		(3, 'Special Title 3', 'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Praesent venenatis vitae enim vel facilisis. Mauris dictum purus tincidunt, sagittis quam id,
		varius lectus. Maecenas in sem sodales, auctor diam id, egestas ligula. Cras at cursus erat. Praesent eleifend ex orci, quis lacinia elit consequat vitae. Nunc faucibus vel lorem
		ut iaculis. Suspendisse risus orci, aliquet nec euismod quis, euismod ut nisi. Etiam feugiat quam a leo egestas commodo vel nec erat.');
	SET IDENTITY_INSERT Special OFF;

	INSERT INTO [Role](RoleId, RoleName)
	VALUES
		(1, 'Admin'),
		(2, 'Sales'),
		(3, 'Disabled');

	SET IDENTITY_INSERT Employee ON;
	INSERT INTO Employee (EmployeeId, RoleId, EmployeeFirstName, EmployeeLastName, EmployeeEmail)
	VALUES
		(1, 1, 'System', 'Administrator', 'admin@guildcars.com'),
		(2, 2, 'Sales', 'Person', 'sales@guildcars.com'),
		(3, 3, 'Disabled', 'User', 'disabled@guildcars.com');
	SET IDENTITY_INSERT Employee OFF;

	SET IDENTITY_INSERT Make ON;
	INSERT INTO Make (MakeId, MakeName, DateAdded, EmployeeId)
	VALUES
		(1, 'Kia', '7/22/2021', 1),
		(2, 'Mazda', '7/22/2021', 1),
		(3, 'Audi', '7/22/2021', 2),
		(4, 'Subaru', '7/22/2021', 2),
		(5, 'Volkswagen', '7/22/2021', 3);
	SET IDENTITY_INSERT Make OFF;

	SET IDENTITY_INSERT Model ON;
	INSERT INTO Model (ModelId, ModelName, DateAdded, MakeId, EmployeeId)
	VALUES
		(1, 'Soul', '7/22/2021', 1, 1), /* Car */
		(2, 'Sportage', '7/22/2021', 1, 1), /* SUV */
		(3, 'Sorento', '7/22/2021', 1, 1), /* SUV */
		(4, 'Rio', '7/22/2021', 1, 1), /* Car */
		(5, 'Carnival', '7/22/2021', 1, 1), /* Van */
		(6, '3', '7/22/2021', 2, 1), /* Car */
		(7, '6', '7/22/2021', 2, 1), /* Car */
		(8, 'CX-5', '7/22/2021', 2, 1), /* SUV */
		(9, 'CX-9', '7/22/2021', 2, 1), /* SUV */
		(10, 'BT-50', '7/22/2021', 2, 1), /* Truck */
		(11, 'Q5', '7/22/2021', 3, 2), /* SUV */
		(12, 'A3', '7/22/2021', 3, 2), /* Car */
		(13, 'A6', '7/22/2021', 3, 2), /* Car */
		(14, 'R8 V10', '7/22/2021', 3, 2), /* Car */
		(15, 'Q7', '7/22/2021', 3, 2), /* SUV */
		(16, 'Outback', '7/22/2021', 4, 2), /* SUV */
		(17, 'Forester', '7/22/2021', 4, 2), /* SUV */
		(18, 'Impreza', '7/22/2021', 4, 2), /* Car */
		(19, 'Crosstrek', '7/22/2021', 4, 2), /* SUV */
		(20, 'Baja', '7/22/2021', 4, 2), /* Truck */
		(21, 'Atlas', '7/22/2021', 5, 3), /* SUV */
		(22, 'Jetta', '7/22/2021', 5, 3), /* Car */
		(23, 'Golf', '7/22/2021', 5, 3), /* Car */
		(24, 'Amarok', '7/22/2021', 5, 3), /* Truck */
		(25, 'Bus', '7/22/2021', 5, 3); /* Van */
	SET IDENTITY_INSERT Model OFF;

	INSERT INTO BodyStyle (BodyStyleId, BodyStyleType)
	VALUES
		(1, 'Car'),
		(2, 'SUV'),
		(3, 'Truck'),
		(4, 'Van');

	INSERT INTO Color (ColorId, ColorName)
	VALUES
		(1, 'White'),
		(2, 'Black'),
		(3, 'Grey'),
		(4, 'Red'),
		(5, 'Yellow'),
		(6, 'Blue');

	INSERT INTO Interior (InteriorId, InteriorName)
	VALUES
		(1, 'White'),
		(2, 'Black'),
		(3, 'Grey'),
		(4, 'Red'),
		(5, 'Yellow'),
		(6, 'Blue');
		
	INSERT INTO Transmission (TransmissionId, TransmissionType)
	VALUES
		(1, 'Automatic'),
		(2, 'Manual');

	INSERT INTO VehicleType (VehicleTypeId, VehicleTypeName)
	VALUES
		(1, 'New'),
		(2, 'Used');

	INSERT INTO Vehicle (VINNumber, BodyStyleId, ColorId, InteriorId, ModelId, TransmissionId, VehicleTypeId, DateAdded, DateSold, [Description], FeaturedStatus, ImageFilePath, Mileage, MSRP, SalePrice, SoldStatus, [Year])
	VALUES
		('3MZBM1U76FM220997', 1, 6, 2, 6, 1, 2, '7/22/2021', null, 'It''s my car!', 1, 'inventory-3MZBM1U76FM220997.jpg', 50000, 12000, 11400, 0, 2015),
		('KNDJT2A59C7444605', 1, 1, 3, 1, 1, 2, '7/22/2021', null, 'It''s my other car!', 1, 'inventory-KNDJT2A59C7444605.jpg', 100000, 8000, 7600, 0, 2012),
		('3VW6T7AU7MM007118', 1, 1, 2, 23, 2, 1, '7/22/2021', null, 'It''s got a bunch of super new nice features!', 1, 'inventory-3VW6T7AU7MM007118.jpg', 150, 35135, 34000, 0, 2021),
		('4S4BSACC2J3216989', 2, 6, 2, 16, 1, 2, '7/22/2021', '8/2/2021', 'People like to take these camping!', 0, 'inventory-4S4BSACC2J3216989.jpg', 98463, 20000, 19000, 1, 2018),
		('WV1ZZZ2HZHH018327', 4, 2, 2, 24, 1, 2, '8/1/2021', '8/3/2021', 'It''s a truck that you can haul stuff in!', 0, 'inventory-WV1ZZZ2HZHH018327.jpg', 111174, 45000, 44800, 1, 2017),
		('JF2SKADC3MH567373', 2, 6, 3, 17, 1, 1, '8/1/2021', null, 'The Forester is the perfect vehicle to expore nature with!', 1, 'inventory-JF2SKADC3MH567373.jpg', 200, 28282, 28000, 0, 2021),
		('KNDMB5C16L6633732', 4, 1, 6, 5, 1, 2, '8/1/2021', null, 'The Sedona is also known as the Carnival in some places!', 1, 'inventory-KNDMB5C16L6633732.jpg', 4175, 33000, 31350, 0, 2020),
		('MM0UP0YF100227000', 3, 3, 4, 10, 2, 2, '8/1/2021', null, 'This truck is equipped for all kinds of things!', 1, 'inventory-MM0UP0YF100227000.jpg', 135204, 30000, 29000, 0, 2014),
		('WA1AAAFY0M2129834', 2, 2, 5, 11, 1, 1, '8/1/2021', null, 'This is a premium tier SUV!', 1, 'inventory-WA1AAAFY0M2129834.jpg', 999, 49000, 46999, 0, 2021),
		('WA1AJAF71MD040415', 2, 1, 1, 15, 1, 1, '8/1/2021', null, 'Bigger, better, and more premium than all other SUVs!', 1, 'inventory-WA1AJAF71MD040415.jpg', 333, 60000, 57499, 0, 2021);
		
		/* ('11111111111111111', 4, 2, 2, 25, 1, 1, '8/11/2021', null, 'NEW Placeholder Vehicle!', 0, 'inventory-11111111111111111.jpg', 100, 100000, 95000, 0, 2021);*/
		/* ('AAAAAAAAAAAAAAAAA', 3, 1, 1, 20, 2, 2, '8/11/2021', null, 'USED Placeholder Vehicle!', 0, 'inventory-11111111111111111.jpg', 200000, 2000, 1900, 0, 2006);*/

	SET IDENTITY_INSERT Contact ON;
	INSERT INTO Contact (ContactId, [Name], Email, Phone, [Message], VINNumber)
	VALUES
		(1, 'John Smith', 'johnsmith@email.com', '555-555-5555', 'Hello, I would like one car please!', '3MZBM1U76FM220997');
	SET IDENTITY_INSERT Contact OFF;

	INSERT INTO PurchaseType (PurchaseTypeId, PurchaseTypeName)
	VALUES
		(1, 'Bank Finance'),
		(2, 'Cash'),
		(3, 'Dealer Finance');		

	INSERT INTO [State] (StateAbbreviation, StateName)
	VALUES
		('AL', 'Alabama'),
		('AK', 'Alaska'),
		('AZ', 'Arizona'),
		('AR', 'Arkansas'),
		('CA', 'California'),
		('CO', 'Colorado'),
		('CT', 'Connecticut'),
		('DE', 'Delaware'),
		('FL', 'Florida'),
		('GA', 'Georgia'),
		('HI', 'Hawaii'),
		('ID', 'Idaho'),
		('IL', 'Illinois'),
		('IN', 'Indiana'),
		('IA', 'Iowa'),
		('KS', 'Kansas'),
		('KY', 'Kentucky'),
		('LA', 'Louisiana'),
		('ME', 'Maine'),
		('MD', 'Maryland'),
		('MA', 'Massachusetts'),
		('MI', 'Michigan'),
		('MN', 'Minnesota'),
		('MS', 'Mississippi'),
		('MO', 'Missouri'),
		('MT', 'Montana'),
		('NE', 'Nebraska'),
		('NV', 'Nevada'),
		('NH', 'New Hampshire'),
		('NJ', 'New Jersey'),
		('NM', 'New Mexico'),
		('NY', 'New York'),
		('NC', 'North Carolina'),
		('ND', 'North Dakota'),
		('OH', 'Ohio'),
		('OK', 'Oklahoma'),
		('OR', 'Oregon'),
		('PA', 'Pennsylvania'),
		('RI', 'Rhode Island'),
		('SC', 'South Carolina'),
		('SD', 'South Dakota'),
		('TN', 'Tennessee'),
		('TX', 'Texas'),
		('UT', 'Utah'),
		('VT', 'Vermont'),
		('VA', 'Virginia'),
		('WA', 'Washington'),
		('WV', 'West Virginia'),
		('WI', 'Wisconsin'),
		('WY', 'Wyoming');

	SET IDENTITY_INSERT Purchase ON;
	INSERT INTO Purchase (PurchaseId, EmployeeId, PurchaseTypeId, StateAbbreviation, VINNumber, [Name], Email, Phone, Street1, Street2, City, ZipCode, PurchasePrice, PurchaseDate)
	VALUES
		(1, 3, 1, 'MN', '4S4BSACC2J3216989', 'Stephen', 'stephen@email.com', '111-111-1111', '100 Main Street', null, 'Minneapolis', '55111', 19000, '8/2/2021'),
		(2, 2, 2, 'KY', 'WV1ZZZ2HZHH018327', 'Mark', 'mark@email.com', '222-222-2222', '2000 Big Road', 'Apt 234', 'Louisville', '40018', 44800, '8/3/2021');
	SET IDENTITY_INSERT Purchase OFF;
END	