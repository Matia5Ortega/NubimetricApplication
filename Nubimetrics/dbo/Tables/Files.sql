﻿CREATE TABLE [dbo].[Files]
(
	[FileId] INT IDENTITY (1, 1) NOT NULL,
	[FileContent] VARCHAR(MAX) NOT NULL,
	CONSTRAINT [PK_FileId] PRIMARY KEY CLUSTERED ([FileId] ASC)
)
