CREATE TYPE [dbo].[CurrenciesTvp] AS TABLE
(
    [CurrencyId] VARCHAR(10) NOT NULL PRIMARY KEY,
	[Symbol] NVARCHAR(10) NOT NULL,
	[Description] NVARCHAR(100) NOT NULL,
	[DecimalPlace] INT NOT NULL,
	[CurrencyBase] VARCHAR(10) NULL,
	[CurrencyQuote] VARCHAR(10) NULL,
	[Ratio] NVARCHAR (11) NULL,
	[Rate] NVARCHAR (11) NULL,
	[InvRate] NVARCHAR (11) NULL,
	[CreationDate] DATETIME NULL,
	[ValidUntil] DATETIME NULL
)
