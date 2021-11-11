CREATE PROCEDURE [dbo].[UpdateUsers]
	@UserId INT,
	@Name VARCHAR(200),
	@LastName VARCHAR(200),
	@Mail VARCHAR(100) = NULL,
	@Password VARCHAR(50)
AS
BEGIN
  UPDATE [dbo].[Users] SET Name = @Name, LastName = @LastName, Mail = @Mail, Password = @Password WHERE Id = @UserId

   RETURN @@ROWCOUNT
END
