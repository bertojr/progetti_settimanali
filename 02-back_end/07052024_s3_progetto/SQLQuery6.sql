-- 6) Cognome, Nome, Indirizzo, Data violazione, importo e punti decurtati 
-- per le violazioni fatte tra il febbraio 2009 e luglio 2009
SELECT a.Nome, a.Cognome, a.Indirizzo, v.DataViolazione, v.Importo, v.DecurtamentoPunti
FROM Anagrafica as a JOIN Verbale as v ON v.FK_Anagrafica = a.IdAnagrafica
WHERE v.DataViolazione BETWEEN '2009-02-01' AND '2009-07-31'