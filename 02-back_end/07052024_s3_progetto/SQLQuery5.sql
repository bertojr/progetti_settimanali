-- 5) Cognome, Nome, Data violazione, Indirizzo violazione, importo e punti decurtati 
-- per tutti gli anagrafici residenti a Palermo
SELECT a.Nome, a.Cognome, v.DataViolazione, v.IndirizzoViolazione, v.Importo, v.DecurtamentoPunti
FROM Anagrafica as a JOIN Verbale as v ON v.FK_Anagrafica = a.IdAnagrafica
WHERE a.Citta LIKE 'palermo'