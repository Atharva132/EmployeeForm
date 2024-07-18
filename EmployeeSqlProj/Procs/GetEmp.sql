CREATE PROCEDURE [dbo].[GetEmp]

AS
BEGIN
	SELECT Firstname, LastName, EmployeeCode, Contact, DoB, Address
	FROM Employee;
END