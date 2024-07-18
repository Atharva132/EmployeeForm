CREATE PROCEDURE [dbo].[UpdateEmp]
	@Id int,
	@FirstName nvarchar(20),
	@LastName nvarchar(20),
	@EmployeeCode int,
	@Contact nvarchar(10),
	@DoB date,
	@Address nvarchar(10)
AS
BEGIN
	UPDATE Employee 
	SET  FirstName = @FirstName, LastName = @LastName, EmployeeCode = @EmployeeCode, Contact = @Contact, DoB = @DoB, Address = @Address 
	WHERE Id = @Id;
END
