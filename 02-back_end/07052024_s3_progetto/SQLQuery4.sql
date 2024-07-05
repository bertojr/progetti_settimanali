-- 4) Totale dei punti decurtati per ogni anagrafe --
SELECT a.Nome, a.Cognome, SUM(v.DecurtamentoPunti) as [Decurtamento punti totali]
FROM Anagrafica as a JOIN  Verbale as v ON a.IdAnagrafica = v.FK_Anagrafica
GROUP BY a.Nome, a.Cognome