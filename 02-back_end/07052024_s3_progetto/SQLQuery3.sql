-- 3) Conteggio dei verbali trascritti raggruppati per tipo di violazione --
SELECT vi.Descrizione, COUNT(v.IdVerbale) as [Totale verbali]
FROM Tipo_Violazione as vi JOIN Verbale as v ON vi.IdViolazione = v.FK_Violazione
GROUP BY vi.Descrizione