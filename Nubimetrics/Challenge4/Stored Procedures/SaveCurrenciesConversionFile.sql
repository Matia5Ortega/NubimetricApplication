CREATE PROCEDURE [dbo].[SaveCurrenciesConversionFile]
	@FileContent VARCHAR(MAX)
AS
BEGIN
  INSERT INTO [dbo].[Files] VALUES(@FileContent)

   RETURN @@ROWCOUNT
END
