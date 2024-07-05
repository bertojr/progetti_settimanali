-- 7) Totale degli importi per ogni anagrafico --
SELECT a.Nome, a.Cognome, SUM(v.Importo) as [Totale importi multe]
FROM Anagrafica as a LEFT JOIN Verbale as v ON a.IdAnagrafica = v.FK_Anagrafica
GROUP BY a.Nome, a.Cognome