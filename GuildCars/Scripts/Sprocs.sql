USE GuildCars

/*==================== BodyStyle ====================*/
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'BodyStyleSelectAll')
      DROP PROCEDURE BodyStyleSelectAll
GO

CREATE PROCEDURE BodyStyleSelectAll AS
BEGIN
	SELECT BodyStyleId, BodyStyleType
	FROM BodyStyle
END
GO

/*==================== Color ====================*/
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'ColorSelectAll')
      DROP PROCEDURE ColorSelectAll
GO

CREATE PROCEDURE ColorSelectAll AS
BEGIN
	SELECT ColorId, ColorName
	FROM Color
END
GO

/*==================== Contact ====================*/
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'ContactSelectAll')
      DROP PROCEDURE ContactSelectAll
GO

CREATE PROCEDURE ContactSelectAll AS
BEGIN
	SELECT ContactId, VINNumber, [Name], Email, Phone, [Message]
	FROM Contact
END
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'ContactInsert')
      DROP PROCEDURE ContactInsert
GO

CREATE PROCEDURE ContactInsert (
	@ContactId tinyint output,
	@VINNumber char(17),
	@Name varchar(100),
	@Email varchar(200),
	@Phone varchar(15),
	@Message varchar(500)
) AS
BEGIN
	INSERT INTO Contact(VINNumber, [Name], Email, Phone, [Message])
	VALUES (@VINNumber, @Name, @Email, @Phone, @Message)
	SET @ContactId = SCOPE_IDENTITY();
END
GO

/*==================== Employee ====================*/
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'EmployeeSelectAll')
      DROP PROCEDURE EmployeeSelectAll
GO

CREATE PROCEDURE EmployeeSelectAll AS
BEGIN
	SELECT EmployeeId, RoleName, EmployeeFirstName, EmployeeLastName, EmployeeEmail
	FROM Employee e
		INNER JOIN Role r ON e.RoleId = r.RoleId
END
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'EmployeeSelectByEmail')
      DROP PROCEDURE EmployeeSelectByEmail
GO

CREATE PROCEDURE EmployeeSelectByEmail (
	 @EmployeeEmail varchar(256)
)
AS
BEGIN
	SELECT EmployeeId, RoleName, EmployeeFirstName, EmployeeLastName, EmployeeEmail
	FROM Employee e
		INNER JOIN Role r ON e.RoleId = r.RoleId
	WHERE EmployeeEmail = @EmployeeEmail
END
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'EmployeeSelectById')
      DROP PROCEDURE EmployeeSelectById
GO

CREATE PROCEDURE EmployeeSelectById (
	 @EmployeeId tinyint
)
AS
BEGIN
	SELECT EmployeeId, RoleName, EmployeeFirstName, EmployeeLastName, EmployeeEmail
	FROM Employee e
		INNER JOIN Role r ON e.RoleId = r.RoleId
	WHERE EmployeeId = @EmployeeId
END
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'EmployeeInsert')
      DROP PROCEDURE EmployeeInsert
GO

CREATE PROCEDURE EmployeeInsert (
	@EmployeeId tinyint output,
	@RoleName varchar(8), 
	@EmployeeFirstName varchar(50), 
	@EmployeeLastName varchar(50), 
	@EmployeeEmail varchar(256)
) AS
BEGIN
	INSERT INTO Employee(RoleId, EmployeeFirstName, EmployeeLastName, EmployeeEmail)
	SELECT (SELECT RoleId FROM [Role] r WHERE r.RoleName = @RoleName), @EmployeeFirstName, @EmployeeLastName, @EmployeeEmail
	SET @EmployeeId = SCOPE_IDENTITY();
END
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'EmployeeUpdate')
      DROP PROCEDURE EmployeeUpdate
GO

CREATE PROCEDURE EmployeeUpdate (
	@EmployeeId tinyint,
	@RoleName varchar(8), 
	@EmployeeFirstName varchar(50), 
	@EmployeeLastName varchar(50), 
	@EmployeeEmail varchar(256)
) AS
BEGIN
	UPDATE Employee SET 
		RoleId = (SELECT RoleId FROM [Role] r WHERE r.RoleName = @RoleName),
		EmployeeFirstName = @EmployeeFirstName, 
		EmployeeLastName = @EmployeeLastName, 
		EmployeeEmail = @EmployeeEmail
	WHERE 
		EmployeeId = @EmployeeId
END
GO

/*==================== Interior ====================*/
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'InteriorSelectAll')
      DROP PROCEDURE InteriorSelectAll
GO

CREATE PROCEDURE InteriorSelectAll AS
BEGIN
	SELECT InteriorId, InteriorName
	FROM Interior
END
GO

/*==================== Make ====================*/
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'MakeSelectAll')
      DROP PROCEDURE MakeSelectAll
GO

CREATE PROCEDURE MakeSelectAll AS
BEGIN
	SELECT MakeId, mk.EmployeeId, e.EmployeeEmail, MakeName, DateAdded
	FROM Make mk
		INNER JOIN Employee e ON mk.EmployeeId = e.EmployeeId
	ORDER BY MakeName
END
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'MakeSelectById')
      DROP PROCEDURE MakeSelectById
GO

CREATE PROCEDURE MakeSelectById (
	@MakeId tinyint
) AS
BEGIN
	SELECT MakeId, mk.EmployeeId, e.EmployeeEmail, MakeName, DateAdded
	FROM Make mk
		INNER JOIN Employee e ON mk.EmployeeId = e.EmployeeId
	WHERE MakeId = @MakeId
END
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'MakeInsert')
      DROP PROCEDURE MakeInsert
GO

CREATE PROCEDURE MakeInsert (
	@MakeId tinyint output,
	@EmployeeId tinyint, 
	@MakeName varchar(20)
) AS
BEGIN
	INSERT INTO Make(EmployeeId, MakeName, DateAdded)
	VALUES (@EmployeeId, @MakeName, GETDATE())
	SET @MakeId = SCOPE_IDENTITY();
END
GO

/*==================== Model ====================*/
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'ModelSelectAll')
      DROP PROCEDURE ModelSelectAll
GO

CREATE PROCEDURE ModelSelectAll AS
BEGIN
	SELECT ModelId, md.EmployeeId, e.EmployeeEmail, MakeName, ModelName, md.DateAdded
	FROM Model md
		INNER JOIN Employee e ON md.EmployeeId = e.EmployeeId
		INNER JOIN Make mk ON md.MakeId = mk.MakeId
	ORDER BY MakeName, ModelName
END
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'ModelSelectById')
      DROP PROCEDURE ModelSelectById
GO

CREATE PROCEDURE ModelSelectById (
	@ModelId tinyint
) AS
BEGIN
	SELECT ModelId, ModelName, md.EmployeeId, e.EmployeeEmail, MakeName, md.DateAdded
	FROM Model md
		INNER JOIN Employee e ON md.EmployeeId = e.EmployeeId
		INNER JOIN Make mk ON md.MakeId = mk.MakeId
	WHERE ModelId = @ModelId
END
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'ModelInsert')
      DROP PROCEDURE ModelInsert
GO

CREATE PROCEDURE ModelInsert (
	@ModelId tinyint output,
	@ModelName varchar(25),
	@EmployeeId tinyint, 
	@MakeName varchar(20)
) AS
BEGIN
	INSERT INTO Model(ModelName, EmployeeId, MakeId)
	SELECT @ModelName, @EmployeeId, (SELECT MakeId FROM Make mk WHERE mk.MakeName = @MakeName)
	SET @ModelId = SCOPE_IDENTITY();
END
GO

/*==================== Purchase ====================*/
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'PurchaseSelectAll')
      DROP PROCEDURE PurchaseSelectAll
GO

CREATE PROCEDURE PurchaseSelectAll AS
BEGIN
	SELECT PurchaseId, p.EmployeeId, CONCAT(e.EmployeeFirstName, ' ', e.EmployeeLastName) AS EmployeeName, p.PurchaseTypeId, StateAbbreviation, 
			VINNumber, [Name], Email, Phone, Street1, Street2, City, ZipCode, PurchasePrice, PurchaseDate
	FROM Purchase p
	INNER JOIN Employee e ON p.EmployeeId = e.EmployeeId
	INNER JOIN PurchaseType pt ON  p.PurchaseTypeId = pt.PurchaseTypeId
END
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'PurchaseSelectById')
      DROP PROCEDURE PurchaseSelectById
GO

CREATE PROCEDURE PurchaseSelectById (
	@PurchaseId smallint
) AS
BEGIN
	SELECT PurchaseId, p.EmployeeId, CONCAT(e.EmployeeFirstName, ' ', e.EmployeeLastName) AS EmployeeName, p.PurchaseTypeId, StateAbbreviation, 
			VINNumber, [Name], Email, Phone, Street1, Street2, City, ZipCode, PurchasePrice, PurchaseDate
	FROM Purchase p
	INNER JOIN Employee e ON p.EmployeeId = e.EmployeeId
	INNER JOIN PurchaseType pt ON  p.PurchaseTypeId = pt.PurchaseTypeId
	WHERE p.PurchaseId = @PurchaseID
END
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'PurchaseInsert')
      DROP PROCEDURE PurchaseInsert
GO

CREATE PROCEDURE PurchaseInsert (
	@PurchaseId smallint output,
	@EmployeeId tinyint,
	@PurchaseTypeId tinyint,
	@StateAbbreviation char(2),
	@VINNumber char(17),
	@Name varchar(100),
	@Email varchar(200),
	@Phone varchar(15),
	@Street1 varchar(200),
	@Street2 varchar(50),
	@City varchar(100),
	@ZipCode char(5),
	@PurchasePrice decimal(10,2)
) AS
BEGIN
	INSERT INTO Purchase(EmployeeId, PurchaseTypeId, StateAbbreviation, VINNumber, [Name], Email, Phone, 
			Street1, Street2, City,	ZipCode, PurchasePrice, PurchaseDate)
	VALUES (@EmployeeId, @PurchaseTypeId, @StateAbbreviation, @VINNumber, @Name, @Email, @Phone, 
			@Street1, @Street2, @City, @ZipCode, @PurchasePrice, DEFAULT)
	SET @PurchaseId = SCOPE_IDENTITY();
END
GO

--IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
--   WHERE ROUTINE_NAME = 'PurchaseSelectReport')
--      DROP PROCEDURE PurchaseSelectReport
--GO

--CREATE PROCEDURE PurchaseSelectReport AS
--BEGIN
--	SELECT e.EmployeeFirstName, e.EmployeeLastName, PurchasePrice, PurchaseId
--	FROM Purchase p
--	INNER JOIN Employee e ON p.EmployeeId = e.EmployeeId
--END
--GO

/*==================== PurchaseType ====================*/
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'PurchaseTypeSelectAll')
      DROP PROCEDURE PurchaseTypeSelectAll
GO

CREATE PROCEDURE PurchaseTypeSelectAll AS
BEGIN
	SELECT PurchaseTypeId, PurchaseTypeName
	FROM PurchaseType
END
GO

/*==================== Role ====================*/
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'RoleSelectAll')
      DROP PROCEDURE RoleSelectAll
GO

CREATE PROCEDURE RoleSelectAll AS
BEGIN
	SELECT RoleId, RoleName
	FROM [Role]
END
GO

/*==================== Special ====================*/
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'SpecialDelete')
      DROP PROCEDURE SpecialDelete
GO

CREATE PROCEDURE SpecialDelete (
	@SpecialId tinyint
) AS
BEGIN
	DELETE FROM Special
	WHERE SpecialId = @SpecialId
END
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'SpecialSelectAll')
      DROP PROCEDURE SpecialSelectAll
GO

CREATE PROCEDURE SpecialSelectAll AS
BEGIN
	SELECT SpecialId, Title, [Description]
	FROM Special
END
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'SpecialSelectById')
      DROP PROCEDURE SpecialSelectById
GO

CREATE PROCEDURE SpecialSelectById (
	 @SpecialId tinyint
)
AS
BEGIN
	SELECT SpecialId, Title, [Description]
	FROM Special
	WHERE SpecialId = @SpecialId
END
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'SpecialInsert')
      DROP PROCEDURE SpecialInsert
GO

CREATE PROCEDURE SpecialInsert (
	@SpecialId tinyint output,
	@Title varchar(50),
	@Description varchar(500)
) AS
BEGIN
	INSERT INTO Special(Title, [Description])
	VALUES (@Title, @Description)
	SET @SpecialId = SCOPE_IDENTITY();
END
GO

/*==================== State ====================*/
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'StateSelectAll')
      DROP PROCEDURE StateSelectAll
GO

CREATE PROCEDURE StateSelectAll AS
BEGIN
	SELECT StateAbbreviation, StateName
	FROM [State]
END
GO

/*==================== Transmission ====================*/
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'TransmissionSelectAll')
      DROP PROCEDURE TransmissionSelectAll
GO

CREATE PROCEDURE TransmissionSelectAll AS
BEGIN
	SELECT TransmissionId, TransmissionType
	FROM Transmission
END
GO

/*==================== Vehicle ====================*/
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'VehicleDelete')
      DROP PROCEDURE VehicleDelete
GO

CREATE PROCEDURE VehicleDelete (
	@VINNumber char(17)
) AS
BEGIN
	BEGIN TRANSACTION
		DELETE FROM Purchase WHERE VINNumber = @VINNumber;
		DELETE FROM Contact WHERE VINNumber = @VINNumber;
		DELETE FROM Vehicle WHERE VINNumber = @VINNumber;
	COMMIT TRANSACTION
END
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'VehicleSelectAll')
      DROP PROCEDURE VehicleSelectAll
GO

CREATE PROCEDURE VehicleSelectAll AS
BEGIN
	SELECT VINNumber, BodyStyleType, ColorName, InteriorName, MakeName, ModelName, TransmissionType, VehicleTypeName,
	ImageFilePath, Mileage, MSRP, SalePrice, [Year], [Description], SoldStatus, FeaturedStatus, v.DateAdded, DateSold
	FROM Vehicle v
		INNER JOIN BodyStyle bs ON v.BodyStyleId = bs.BodyStyleId
		INNER JOIN Color c ON v.ColorId = c.ColorId
		INNER JOIN Interior i ON v.InteriorId = i.InteriorId
		INNER JOIN Model md ON v.ModelId = md.ModelId
		INNER JOIN Make mk ON mk.MakeId = md.MakeId
		INNER JOIN Transmission t ON v.TransmissionId = t.TransmissionId
		INNER JOIN VehicleType vt ON v.VehicleTypeId = vt.VehicleTypeId
END
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'VehicleSelectById')
      DROP PROCEDURE VehicleSelectById
GO

CREATE PROCEDURE VehicleSelectById (
	@VINNumber char(17)
) AS
BEGIN
	SELECT VINNumber, BodyStyleType, ColorName, InteriorName, MakeName, ModelName, TransmissionType, VehicleTypeName, 
	ImageFilePath, Mileage, MSRP, SalePrice, [Year], [Description], SoldStatus, FeaturedStatus, v.DateAdded, v.DateSold
	FROM Vehicle v
		INNER JOIN BodyStyle bs ON v.BodyStyleId = bs.BodyStyleId
		INNER JOIN Color c ON v.ColorId = c.ColorId
		INNER JOIN Interior i ON v.InteriorId = i.InteriorId
		INNER JOIN Model md ON v.ModelId = md.ModelId
		INNER JOIN Make mk ON mk.MakeId = md.MakeId
		INNER JOIN Transmission t ON v.TransmissionId = t.TransmissionId
		INNER JOIN VehicleType vt ON v.VehicleTypeId = vt.VehicleTypeId
	WHERE VINNumber = @VINNumber
END
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'VehicleSelectDetails')
      DROP PROCEDURE VehicleSelectDetails
GO

CREATE PROCEDURE VehicleSelectDetails (
	@VINNumber char(17)
) AS
BEGIN
	SELECT VINNumber, BodyStyleType, ColorName, InteriorName, MakeName, ModelName, TransmissionType, 
			VehicleTypeName, ImageFilePath, Mileage, MSRP, SalePrice, [Year], [Description], SoldStatus
	FROM Vehicle v
		INNER JOIN BodyStyle bs ON v.BodyStyleId = bs.BodyStyleId
		INNER JOIN Color c ON v.ColorId = c.ColorId
		INNER JOIN Interior i ON v.InteriorId = i.InteriorId
		INNER JOIN Model md ON v.ModelId = md.ModelId
		INNER JOIN Make mk ON mk.MakeId = md.MakeId
		INNER JOIN Transmission t ON v.TransmissionId = t.TransmissionId
		INNER JOIN VehicleType vt ON v.VehicleTypeId = vt.VehicleTypeId
	WHERE VINNumber = @VINNumber
END
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'VehicleSelectFeatured')
      DROP PROCEDURE VehicleSelectFeatured
GO

CREATE PROCEDURE VehicleSelectFeatured AS
BEGIN
	SELECT VINNumber, MakeName, ModelName, ImageFilePath, SalePrice, [Year]
	FROM Vehicle v
		INNER JOIN Model md ON v.ModelId = md.ModelId
		INNER JOIN Make mk ON mk.MakeId = md.MakeId
	WHERE FeaturedStatus = 1
END
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'VehiclePurchase')
      DROP PROCEDURE VehiclePurchase
GO

CREATE PROCEDURE VehiclePurchase (
	@VINNumber char(17)
) AS
BEGIN
	UPDATE Vehicle SET
		DateSold = GETDATE(),
		FeaturedStatus = 0,
		SoldStatus = 1
	WHERE VINNumber = @VINNumber
END
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'VehicleInventoryReport')
      DROP PROCEDURE VehicleInventoryReport
GO

CREATE PROCEDURE VehicleInventoryReport (
	@VehicleTypeName varchar(4)
) AS
BEGIN
	SELECT [Year], MakeName, ModelName, VehicleCount = COUNT(ModelName), StockValue = SUM(MSRP)
	FROM Vehicle v
		INNER JOIN Model md ON v.ModelId = md.ModelId
		INNER JOIN Make mk ON mk.MakeId = md.MakeId
		INNER JOIN VehicleType vt ON v.VehicleTypeId = vt.VehicleTypeId
	WHERE vt.VehicleTypeName = @VehicleTypeName AND SoldStatus = 0
	GROUP BY [Year], MakeName, ModelName
	ORDER BY [Year] DESC
END
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'VehicleInsert')
      DROP PROCEDURE VehicleInsert
GO

CREATE PROCEDURE VehicleInsert (
	@VINNumber char(17),
	@BodyStyleType varchar(5),
	@ColorName varchar(10),
	@InteriorName varchar(10),
	@ModelName varchar(25),
	@TransmissionType varchar(9),
	@VehicleTypeName varchar(4),
	@DateSold date,
	@Description varchar(500),
	@ImageFilePath varchar(100),
	@Mileage int,
	@MSRP decimal(10,2),
	@SalePrice decimal(10,2),
	@Year smallint
) AS
BEGIN
	INSERT INTO Vehicle (VINNumber, BodyStyleId, ColorId, InteriorId, ModelId, TransmissionId, VehicleTypeId, 
			DateSold, [Description], ImageFilePath, Mileage, MSRP, SalePrice, [Year])
	SELECT 
		@VINNumber, 
		(SELECT BodyStyleId FROM Bodystyle bs WHERE bs.BodyStyleType = @BodyStyleType), 
		(SELECT ColorId FROM Color c WHERE c.ColorName = @ColorName), 
		(SELECT InteriorId FROM Interior i WHERE i.InteriorName = @InteriorName), 
		(SELECT ModelId FROM Model md WHERE md.ModelName = @ModelName), 
		(SELECT TransmissionId FROM Transmission t WHERE t.TransmissionType = @TransmissionType), 
		(SELECT VehicleTypeId FROM VehicleType vt WHERE vt.VehicleTypeName = @VehicleTypeName),
		@DateSold,
		@Description,
		@ImageFilePath, 
		@Mileage, 
		@MSRP, 
		@SalePrice, 
		@Year
END
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'VehicleUpdate')
      DROP PROCEDURE VehicleUpdate
GO

CREATE PROCEDURE VehicleUpdate (
	@OldVINNumber char(17),
	@VINNumber char(17),
	@BodyStyleType varchar(5),
	@ColorName varchar(10),
	@InteriorName varchar(10),
	@ModelName varchar(25),
	@TransmissionType varchar(9),
	@VehicleTypeName varchar(4),
	@Description varchar(500),
	@ImageFilePath varchar(100),
	@Mileage int,
	@MSRP decimal(10,2),
	@SalePrice decimal(10,2),
	@Year smallint,
	@FeaturedStatus bit
) AS
BEGIN
	UPDATE Vehicle 
	SET
		VINNumber = @VINNumber,
		BodyStyleId = (SELECT BodyStyleId FROM Bodystyle bs WHERE bs.BodyStyleType = @BodyStyleType),
		ColorId = (SELECT ColorId FROM Color c WHERE c.ColorName = @ColorName),
		InteriorId = (SELECT InteriorId FROM Interior i WHERE i.InteriorName = @InteriorName),
		ModelId = (SELECT ModelId FROM Model md WHERE md.ModelName = @ModelName),
		TransmissionId = (SELECT TransmissionId FROM Transmission t WHERE t.TransmissionType = @TransmissionType),
		VehicleTypeId = (SELECT VehicleTypeId FROM VehicleType vt WHERE vt.VehicleTypeName = @VehicleTypeName),
		[Description] = @Description,
		ImageFilePath = @ImageFilePath,
		Mileage = @Mileage,
		MSRP = @MSRP,
		SalePrice = @SalePrice,
		[Year] = @Year,
		FeaturedStatus = @FeaturedStatus
	WHERE VINNumber = @OldVINNumber
END
GO

/*==================== VehicleType ====================*/
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'VehicleTypeSelectAll')
      DROP PROCEDURE VehicleTypeSelectAll
GO

CREATE PROCEDURE VehicleTypeSelectAll AS
BEGIN
	SELECT VehicleTypeId, VehicleTypeName
	FROM VehicleType
END
GO