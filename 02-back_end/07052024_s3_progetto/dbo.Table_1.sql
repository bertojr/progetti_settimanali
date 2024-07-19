﻿CREATE TABLE [dbo].[Anagrafica]
(
	[IdAnagrafica] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Cognome] NVARCHAR(50) NOT NULL,
	Nome NVARCHAR(50) NOT NULL,
	Indirizzo NVARCHAR(120) NULL,
	Cita NVARCHAR(80) NULL,
	CAP CHAR(5) NULL,
	CF CHAR(16) NOT NULL,
)