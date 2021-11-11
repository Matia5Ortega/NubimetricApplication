CREATE PROCEDURE [dbo].[GetCountryByCountryId]
	@CountryId VARCHAR(4)
AS
BEGIN
   SELECT 
   C.CountryId,
   C.CurrencyId,
   C.Locale,
   C.Name
   FROM [dbo].Countries C
   WHERE C.CountryId = @CountryId
END
