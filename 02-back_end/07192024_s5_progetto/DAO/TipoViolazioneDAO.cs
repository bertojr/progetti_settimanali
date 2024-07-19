using _07192024_s5_progetto.Interface;
using _07192024_s5_progetto.Models;
using System.Data.SqlClient;

namespace _07192024_s5_progetto.DAO
{
    public class TipoViolazioneDAO : BaseDAO, ITipoViolazioneDAO
    {
        private const string SELECT_ALL_VIOLAZIONI =
            "SELECT * " +
            "FROM Tipo_Violazione";
        public TipoViolazioneDAO(ILogger<IAnagraficaDAO> logger, IConfiguration config) : base(logger, config)
        {
        }

        public List<TipoViolazione> GetAll()
        {
            var result = new List<TipoViolazione>();
            try
            {
                using var conn = new SqlConnection(connectionString);
                conn.Open();
                using var cmd = new SqlCommand(SELECT_ALL_VIOLAZIONI, conn);
                using var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    result.Add(new TipoViolazione
                    {
                        ViolazioneID = reader.GetInt32(0),
                        Descrizione = reader.GetString(1),
                    });
                }
                return result;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Exception reading all tipi violazione");
                throw;
            }
        }
    }
}
