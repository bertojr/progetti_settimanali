using _07192024_s5_progetto.Interface;
using _07192024_s5_progetto.Models;
using System.Data.SqlClient;
using System.Linq.Expressions;

namespace _07192024_s5_progetto.DAO
{
    public class VerbaleDAO : BaseDAO, IVerbaleDAO
    {
        private const string INSERT_VERBALE =
            "INSERT INTO Verbale(DataViolazione, IndirizzoViolazione, NominativoAgente, Importo, DecurtamentoPunti, AnagraficaID, ViolazioneID) " +
            "OUTPUT INSERTED.IdVerbale " +
            "VALUES(@dataViolazione, @indirizzoViolazione, @nominativoAgente, @importo, @decurtamentoPunti, @anagraficaId, @violazioneId)";
        private const string SELECT_ALL_VERBALI =
            "SELECT * " +
            "FROM Verbale " +
            "   JOIN Anagrafica " +
            "       ON Verbale.AnagraficaID = Anagrafica.AnagraficaID " +
            "   JOIN Tipo_Violazione " +
            "       ON Verbale.ViolazioneID = Tipo_Violazione.ViolazioneID";
        private const string QUERY_GET_TOTAL_POINT_DEDUCTED_GROUPE_BY_TRANSGRESSOR =
            "SELECT a.AnagraficaID, a.Nome, a.Cognome, a.CF, SUM(v.DecurtamentoPunti) as TotalPointsDeducted " +
            "FROM Verbale as v " +
            "   RIGHT JOIN Anagrafica as a " +
            "       ON v.AnagraficaID = a.AnagraficaID " +
            "GROUP BY a.AnagraficaID, a.Nome, a.Cognome, a.CF " +
            "ORDER BY TotalPointsDeducted DESC";
        private const string QUERY_GET_TOTAL_VIOLATIONS_GROUPE_BY_TRANSGRESSOR =
            "SELECT a.AnagraficaID, a.Nome, a.Cognome, a.CF, COUNT(v.IdVerbale) as TotalViolations " +
            "FROM Verbale as v " +
            "   RIGHT JOIN Anagrafica as a " +
            "       ON v.AnagraficaID = a.AnagraficaID " +
            "GROUP BY a.AnagraficaID, a.Nome, a.Cognome, a.CF " +
            "ORDER BY TotalViolations DESC";
        private const string QUERY_GET_VIOLATIONS_WITH_AMOUNT_GREATER_THAN_400 =
            "SELECT * " +
            "FROM Verbale as v " +
            "   INNER JOIN Anagrafica as a " +
            "       ON v.AnagraficaID = a.AnagraficaID " +
            "WHERE v.DecurtamentoPunti > 10 " +
            "ORDER BY v.DecurtamentoPunti DESC";
        private const string QUERY_GET_VIOLATIONS_WITH_POINTS_GREATER_THAN_10 =
            "SELECT * " +
            "FROM Verbale as v " +
            "   INNER JOIN Anagrafica as a " +
            "       ON v.AnagraficaID = a.AnagraficaID " +
            "WHERE v.Importo > 400 " +
            "ORDER BY v.Importo DESC";

        public VerbaleDAO(ILogger<IAnagraficaDAO> logger, IConfiguration config) : base(logger, config)
        {
        }

        public Verbale Create(Verbale newVerbale)
        {
            try
            {
                using var conn = new SqlConnection(connectionString);
                conn.Open();
                using var cmd = new SqlCommand(INSERT_VERBALE, conn);
                cmd.Parameters.AddWithValue("@dataViolazione", newVerbale.DataViolazione);
                cmd.Parameters.AddWithValue("@indirizzoViolazione", newVerbale.IndirizzoViolazione);
                cmd.Parameters.AddWithValue("@nominativoAgente", newVerbale.NominativoAgente);
                cmd.Parameters.AddWithValue("@importo", newVerbale.Importo);
                cmd.Parameters.AddWithValue("@decurtamentoPunti", newVerbale.DecurtamentoPunti);
                cmd.Parameters.AddWithValue("@anagraficaId", newVerbale.AnagraficaID);
                cmd.Parameters.AddWithValue("@violazioneId", newVerbale.ViolazioneID);
                newVerbale.Id = (int)cmd.ExecuteScalar();
                return newVerbale;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Exception creating new violation");
                throw;
            }
        }

        public List<Verbale> GetAll()
        {
            var result = new List<Verbale>();
            try
            {
                using var conn = new SqlConnection(connectionString);
                conn.Open();
                using var cmd = new SqlCommand(SELECT_ALL_VERBALI ,conn);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var anagrafica = new Anagrafica
                    {
                        AnagraficaID = reader.GetInt32(9),
                        Cognome = reader.GetString(10),
                        Nome = reader.GetString(11),
                        Indirizzo = reader.GetString(12),
                        Citta = reader.GetString(13),
                        CAP = reader.GetString(14),
                        CF = reader.GetString(15),
                    };

                    var tipoViolazione = new TipoViolazione
                    {
                        ViolazioneID = reader.GetInt32(16),
                        Descrizione = reader.GetString(17),
                    };

                    result.Add(new Verbale
                    {
                        Id = reader.GetInt32(0),
                        DataViolazione = reader.GetDateTime(1),
                        IndirizzoViolazione = reader.GetString(2),
                        NominativoAgente = reader.GetString(3),
                        DataTrascrizioneVerbale = reader.GetDateTime(4),
                        Importo = reader.GetDecimal(5),
                        DecurtamentoPunti = reader.GetInt32(6),
                        AnagraficaID = reader.GetInt32(7),
                        ViolazioneID = reader.GetInt32(8),
                        Anagrafica = anagrafica,
                        TipoViolazione = tipoViolazione
                    });
                }
                return result;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Exception select all violations");
                throw;
            }
        }

        public List<Verbale> GetTotalPointsDeductedGroupeByTransgressor()
        {
            var result = new List<Verbale>();
            try
            {
                using var conn = new SqlConnection(connectionString);
                conn.Open();
                using var cmd = new SqlCommand(QUERY_GET_TOTAL_POINT_DEDUCTED_GROUPE_BY_TRANSGRESSOR, conn);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var anagrafica = new Anagrafica
                    {
                        AnagraficaID = reader.GetInt32(0),
                        Cognome = reader.GetString(2),
                        Nome = reader.GetString(1),
                        CF = reader.GetString(3),
                    };

                    result.Add(new Verbale
                    {
                        Anagrafica = anagrafica,
                        TotalePuntiDecurtati = reader.IsDBNull(4) ? 0 : reader.GetInt32(4),
                    });
                }
                return result;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Exception query GetTotalPointsDeductedGroupeByTransgressor");
                throw;
            }
        }

        public List<Verbale> GetTotalViolationsGroupeByTransgressor()
        {
            var result = new List<Verbale>();
            try
            {
                using var conn = new SqlConnection(connectionString);
                conn.Open();
                using var cmd = new SqlCommand(QUERY_GET_TOTAL_VIOLATIONS_GROUPE_BY_TRANSGRESSOR, conn);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    var anagrafica = new Anagrafica
                    {
                        AnagraficaID = reader.GetInt32(0),
                        Cognome = reader.GetString(2),
                        Nome = reader.GetString(1),
                        CF = reader.GetString(3),
                    };
                    result.Add(new Verbale
                    {
                        Anagrafica = anagrafica,
                        TotaleVerbali = reader.GetInt32(4),
                    });
                }
                return result;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Exception query GetTotalPointsDeductedGroupeByTransgressor");
                throw;
            }
        }

        public List<Verbale> GetViolationsWithAmountGreaterThan400()
        {
            var result = new List<Verbale>();
            try
            {
                using var conn = new SqlConnection(connectionString);
                conn.Open();
                using var cmd = new SqlCommand(QUERY_GET_VIOLATIONS_WITH_AMOUNT_GREATER_THAN_400, conn);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var anagrafica = new Anagrafica
                    {
                        AnagraficaID = reader.GetInt32(9),
                        Cognome = reader.GetString(10),
                        Nome = reader.GetString(11),
                        Indirizzo = reader.GetString(12),
                        Citta = reader.GetString(13),
                        CAP = reader.GetString(14),
                        CF = reader.GetString(15),
                    };

                    result.Add(new Verbale
                    {
                        Id = reader.GetInt32(0),
                        DataViolazione = reader.GetDateTime(1),
                        IndirizzoViolazione = reader.GetString(2),
                        NominativoAgente = reader.GetString(3),
                        DataTrascrizioneVerbale = reader.GetDateTime(4),
                        Importo = reader.GetDecimal(5),
                        DecurtamentoPunti = reader.GetInt32(6),
                        AnagraficaID = reader.GetInt32(7),
                        ViolazioneID = reader.GetInt32(8),
                        Anagrafica = anagrafica,
                    });
                }
                return result;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Exception query GetTotalPointsDeductedGroupeByTransgressor");
                throw;
            }
        }

        public List<Verbale> GetViolationsWithPointsGreaterThan10()
        {
            var result = new List<Verbale>();
            try
            {
                using var conn = new SqlConnection(connectionString);
                conn.Open();
                using var cmd = new SqlCommand(QUERY_GET_VIOLATIONS_WITH_POINTS_GREATER_THAN_10, conn);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var anagrafica = new Anagrafica
                    {
                        AnagraficaID = reader.GetInt32(9),
                        Cognome = reader.GetString(10),
                        Nome = reader.GetString(11),
                        Indirizzo = reader.GetString(12),
                        Citta = reader.GetString(13),
                        CAP = reader.GetString(14),
                        CF = reader.GetString(15),
                    };

                    result.Add(new Verbale
                    {
                        Id = reader.GetInt32(0),
                        DataViolazione = reader.GetDateTime(1),
                        IndirizzoViolazione = reader.GetString(2),
                        NominativoAgente = reader.GetString(3),
                        DataTrascrizioneVerbale = reader.GetDateTime(4),
                        Importo = reader.GetDecimal(5),
                        DecurtamentoPunti = reader.GetInt32(6),
                        AnagraficaID = reader.GetInt32(7),
                        ViolazioneID = reader.GetInt32(8),
                        Anagrafica = anagrafica,
                    });
                }
                return result;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Exception query GetTotalPointsDeductedGroupeByTransgressor");
                throw;
            }
        }
    }
}
