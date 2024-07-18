CREATE PROCEDURE [dbo].[GetEmpById]
	@Id int
AS
BEGIN
	SELECT Firstname, LastName, EmployeeCode, Contact, DoB, Address
	FROM Employee 
	WHERE Id = @Id;
END
