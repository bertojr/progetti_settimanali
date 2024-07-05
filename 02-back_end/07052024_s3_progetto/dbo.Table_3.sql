CREATE TABLE [dbo].[Verbale]
(
	[IdVerbale] INT NOT NULL PRIMARY KEY IDENTITY,
	DataViolazione DATETIME2 NOT NULL,
	IndirizzoViolazione NVARCHAR(100) NOT NULL,
	Nominativo_Agente NVARCHAR(100) NOT NULL,
	DataTrascrizioneVerbale DATETIME2 NOT NULL DEFAULT GETDATE(),
	Importo DECIMAL(10, 2) NULL DEFAULT 0,
	DecurtamentoPunti INT NULL DEFAULT 0, 
    [FK_Anagrafica] INT NOT NULL, 
    [FK_Violazione] INT NOT NULL,
)
