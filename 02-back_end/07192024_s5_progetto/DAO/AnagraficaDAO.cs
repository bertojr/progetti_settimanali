using _07192024_s5_progetto.Interface;
using _07192024_s5_progetto.Models;
using System.Data.SqlClient;

namespace _07192024_s5_progetto.DAO
{
    public class AnagraficaDAO : BaseDAO, IAnagraficaDAO
    {
        private const string INSERT_ANAGRAFICA =
            "INSERT INTO Anagrafica(Cognome, Nome, Indirizzo, Citta, CAP, CF) " +
            "OUTPUT INSERTED.AnagraficaID " +
            "VALUES(@cognome, @nome, @indirizzo, @citta, @cap, @cf)";
        private const string SELECT_ALL_TRANSGRESSOR =
            "SELECT * " +
            "FROM Anagrafica";

        public AnagraficaDAO(ILogger<IAnagraficaDAO> logger, IConfiguration config) : base(logger, config)
        {
        }

        public Anagrafica Create(Anagrafica newTransgressor)
        {
            try
            {
                using var conn = new SqlConnection(connectionString);
                conn.Open();
                using var cmd = new SqlCommand(INSERT_ANAGRAFICA, conn);
                cmd.Parameters.AddWithValue("@cognome", newTransgressor.Cognome);
                cmd.Parameters.AddWithValue("@nome", newTransgressor.Nome);
                cmd.Parameters.AddWithValue("@indirizzo", newTransgressor.Indirizzo);
                cmd.Parameters.AddWithValue("@citta", newTransgressor.Citta);
                cmd.Parameters.AddWithValue("@cap", newTransgressor.CAP);
                cmd.Parameters.AddWithValue("@cf", newTransgressor.CF);
                newTransgressor.AnagraficaID = (int)cmd.ExecuteScalar();
                return newTransgressor;
            } 
            catch(Exception ex)
            {
                logger.LogError(ex, "Exception creating transgressor");
                throw;
            }
        }

        public List<Anagrafica> GetAll()
        {
            var result = new List<Anagrafica>();
            try
            {
                using var conn = new SqlConnection(connectionString);
                conn.Open();
                using var cmd = new SqlCommand(SELECT_ALL_TRANSGRESSOR, conn);
                using var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    result.Add(new Anagrafica
                    {
                        AnagraficaID = reader.GetInt32(0),
                        Cognome = reader.GetString(1),
                        Nome = reader.GetString(2),
                        Indirizzo = reader.GetString(3),
                        Citta = reader.GetString(4),
                        CAP = reader.GetString(5),
                        CF = reader.GetString(6),
                    });   
                }
                return result;
            }
            catch(Exception ex)
            {
                logger.LogError(ex, "Exception reading all trasgressor");
                throw;
            }
        }
    }
}
