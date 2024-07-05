-- 2) Conteggio dei verbali trascritti raggruppati per anagrafe --
SELECT a.Nome, a.Cognome, COUNT(v.IdVerbale) as [Verbali]
FROM Verbale as v RIGHT JOIN Anagrafica as a ON v.FK_Anagrafica = a.IdAnagrafica
GROUP BY a.Nome, a.Cognome