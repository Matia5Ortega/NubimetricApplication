CREATE PROCEDURE [dbo].[GetUsers]
AS
BEGIN
  SELECT Id, Name, LastName, Mail, Password 
  FROM [dbo].[Users] 
END