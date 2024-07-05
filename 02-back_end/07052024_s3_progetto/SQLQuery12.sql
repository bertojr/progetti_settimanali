-- 12) Cognome, Nome, Indirizzo, Data violazione, Importo e punti decurtati --
-- per tutte le violazioni che superino l’importo di 400 euro --
SELECT a.Nome, a.Cognome, a.Indirizzo, v.DataViolazione, v.Importo, v.DecurtamentoPunti
FROM Anagrafica as a JOIN Verbale as v ON a.IdAnagrafica = v.FK_Anagrafica
WHERE v.Importo > 400