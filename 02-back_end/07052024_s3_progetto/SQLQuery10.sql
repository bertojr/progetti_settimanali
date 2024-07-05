-- 10) Conteggio delle violazioni contestate raggruppate per Nominativo dell’agente di Polizia
SELECT v.Nominativo_Agente, COUNT(v.IdVerbale) as [Totali verbali contestati]
FROM Verbale as v
GROUP BY V.Nominativo_Agente