CREATE PROCEDURE [dbo].[CreateEmp]
	@FirstName NVARCHAR(20),
	@LastName NVARCHAR(20),
	@EmployeeCode INT,
	@Contact NVARCHAR(10),
	@DoB DATE,
	@Address NVARCHAR(10)
AS
BEGIN
	INSERT INTO 
		[Employee] 
			(
				[FirstName], 
				[LastName], 
				[EmployeeCode], 
				[Contact],
				[DoB], 
				[Address]
			) 
	VALUES 
		(
			@FirstName, 
			@LastName, 
			@EmployeeCode, 
			@Contact, 
			@DoB, 
			@Address
		);

	SELECT  @@IDENTITY AS Id;
END
