CREATE PROCEDURE [dbo].[SaveCurrencies]
	@CurrenciesTvp CurrenciesTvp READONLY
AS
BEGIN
	MERGE INTO [dbo].[Currencies] AS Target
	USING @CurrenciesTvp AS Source
	ON Target.[CurrencyId] = Source.[CurrencyId]
	WHEN MATCHED THEN
	   UPDATE SET Symbol = Source.[Symbol], Description = Source.[Description], DecimalPlace = Source.[DecimalPlace], CurrencyBase = Source.[CurrencyBase], CurrencyQuote = Source.[CurrencyQuote], Ratio = Source.[Ratio], Rate = Source.[Rate], InvRate = Source.[InvRate], CreationDate = Source.[CreationDate], ValidUntil = Source.[ValidUntil]
	WHEN NOT MATCHED BY TARGET THEN
	   INSERT ([CurrencyId],[Symbol],[Description],[DecimalPlace],[CurrencyBase],[CurrencyQuote],[Ratio],[Rate],[InvRate],[CreationDate],[ValidUntil])
	   VALUES (Source.[CurrencyId], Source.[Symbol], Source.[Description], Source.[DecimalPlace], Source.[CurrencyBase], Source.[CurrencyQuote], Source.[Ratio], Source.[Rate], Source.[InvRate], Source.[CreationDate], Source.[ValidUntil])
    WHEN NOT MATCHED BY SOURCE THEN DELETE;
END
