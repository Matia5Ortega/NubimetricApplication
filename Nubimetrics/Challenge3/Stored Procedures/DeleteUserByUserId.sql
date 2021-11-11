CREATE PROCEDURE [dbo].[DeleteUser]
   @UserId INT
AS
BEGIN
  DELETE [dbo].[Users] WHERE Id = @UserId

   RETURN @@ROWCOUNT
END
