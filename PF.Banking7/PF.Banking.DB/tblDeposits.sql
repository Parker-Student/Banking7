﻿CREATE TABLE [dbo].[tblDeposits](
	[Id] [int] NOT NULL,
	[CustomerId] [int] NOT NULL,
	[Amount] [decimal](18, 2) NOT NULL,
	[TransDate] [datetime] NOT NULL
)