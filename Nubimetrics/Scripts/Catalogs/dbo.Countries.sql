MERGE INTO [dbo].[Countries] AS Target
USING(
   VALUES
      ('AR','Argentina','es_AR','ARS'),
      ('BO','Bolivia','es_BO','BOB'),
      ('BR','Brasil','pt_BR','BRL'),
      ('CL','Chile','es_CL','CLP'),
      ('CN','China','zh_CN','CNY'),
	  ('CO','Colombia','es_CO','COP'),
      ('CR','Costa Rica','es_CR','CRC'),
      ('CBT','Cross Border Trade','es_AR','ARS'),
      ('EC','Ecuador','es_EC','USD'),
      ('SV','El Salvador','es_SV','USD'),
      ('GT','Guatemala','es_GT','GTQ'),
      ('HN','Honduras','es_HN','HNL'),
      ('MX','Mexico','es_MX','MXN'),
      ('NI','Nicaragua','es_NI','NIO'),
      ('PA','Panamá','es_PA','USD'),
      ('PY','Paraguay','es_PY','PYG'),
      ('PE','Peru','es_PE','PEN'),
      ('PT','Portugal','pt_PT','EUR'),
      ('PR','Puerto Rico','es_PR','USD'),
      ('GB','Reino Unido','en_GB','GBP'),
      ('DO','República Dominicana','es_DO','DOP'),
      ('UY','Uruguay','es_UY','UYU'),
      ('VE','Venezuela','es_VE','VES'),
      ('COL','newCOL','es_COL','COLS')
	  ) AS Source (CountryId,Name,Locale,CurrencyId)
	  ON Target.[CountryId] = Source.CountryId
   WHEN MATCHED THEN
      UPDATE SET
	  [CountryId] = Source.CountryId
   WHEN NOT MATCHED BY TARGET THEN
      INSERT ([CountryId],[Name],[Locale],[CurrencyId])
	  VALUES (Source.CountryId,Source.Name,Source.Locale,Source.CurrencyId);