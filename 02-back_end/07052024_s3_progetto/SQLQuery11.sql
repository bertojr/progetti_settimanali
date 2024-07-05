-- 11) Cognome, Nome, Indirizzo, Data violazione, Importo e punti decurtati --
-- per tutte le violazioni che superino il decurtamento di 5 punti --
SELECT a.Nome, a.Cognome, v.IndirizzoViolazione, v.DataViolazione, v.Importo, v.DecurtamentoPunti
FROM Verbale as v JOIN Anagrafica as a ON v.FK_Anagrafica = a.IdAnagrafica
WHERE v.DecurtamentoPunti > 5