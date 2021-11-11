CREATE PROCEDURE [dbo].[AddUser]
	@Name VARCHAR(200),
	@LastName VARCHAR(200),
	@Mail VARCHAR(100) = NULL,
	@Password VARCHAR(50)
AS
BEGIN
  INSERT INTO [dbo].[Users] VALUES (@Name, @LastName, @Mail, @Password)

  RETURN @@ROWCOUNT
END
