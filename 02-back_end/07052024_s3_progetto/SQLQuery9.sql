-- 9) Query che visualizzi Data violazione, Importo e decurtamento punti relativi ad una certa data --
SELECT v.DataViolazione, v.Importo, v.DecurtamentoPunti
FROM Verbale as v
WHERE CONVERT(DATE, v.DataViolazione) = '2023-10-25'