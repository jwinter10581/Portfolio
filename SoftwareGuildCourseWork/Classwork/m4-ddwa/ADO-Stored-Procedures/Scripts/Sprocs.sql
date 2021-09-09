USE SWCCorp;
GO

IF EXISTS(
   SELECT *
   FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'EmployeeRatesSelect')
BEGIN
   DROP PROCEDURE EmployeeRatesSelect
END
GO

CREATE PROCEDURE EmployeeRatesSelect
AS

	SELECT e.EmpID, e.FirstName, e.LastName, pr.HourlyRate,
		pr.MonthlySalary, pr.YearlySalary 
    FROM Employee e 
		INNER JOIN PayRates pr ON e.EmpID = pr.EmpID

GO

IF EXISTS(
   SELECT *
   FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'EmployeeRatesSelectByCity')
BEGIN
   DROP PROCEDURE EmployeeRatesSelectByCity
END
GO

CREATE PROCEDURE EmployeeRatesSelectByCity (
	@City varchar(20)
)
AS
	SELECT e.EmpID, e.FirstName, e.LastName, pr.HourlyRate,
		   pr.MonthlySalary, pr.YearlySalary
    FROM Employee e 
		INNER JOIN PayRates pr ON e.EmpID = pr.EmpID 
        INNER JOIN [Location] l on e.LocationID = l.LocationID 
    WHERE l.City = @City
GO