CREATE TABLE [dbo].[Employee]
(
	[Id] INT NOT NULL PRIMARY KEY identity(1, 1),
	[FirstName] nvarchar(20) NOT NULL,
	[LastName] nvarchar(20) NOT NULL,
	[EmployeeCode] int NOT NULL,
	[Contact] nvarchar(10) NOT NULL,
	[DoB] date NOT NULL,
	[Address] nvarchar(10) NOT NULL
)
