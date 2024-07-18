CREATE PROCEDURE [dbo].[DeleteProc]
	@Id int
AS
BEGIN
	DELETE 
	FROM Employee 
	WHERE Id = @Id;
END
