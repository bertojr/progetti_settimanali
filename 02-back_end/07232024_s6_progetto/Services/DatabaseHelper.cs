using System; // Namespace per tipi base come Exception
using System.Data.SqlClient; // Namespace per interagire con SQL Server

namespace _07232024_s6_progetto.Services // Namespace dell'applicazione
{
    public class DatabaseHelper // Classe helper per interagire con il database
    {
        private readonly string _connectionString; // Stringa di connessione al database
        private readonly ILogger<DatabaseHelper> _logger;

        // Costruttore che accetta una stringa di connessione
        public DatabaseHelper(string connectionString, ILogger<DatabaseHelper> logger)
        {
            _connectionString = connectionString;
            _logger = logger;
        }

        // Metodo privato per ottenere una connessione al database
        private SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }

        // Metodo generico per eseguire query che restituiscono dati
        public List<T> ExecuteQuery<T>(string query, Func<SqlDataReader, T> mapFunction, SqlParameter[] parameters = null)
        {
            var results = new List<T>(); // Lista per memorizzare i risultati della query
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                using (var command = new SqlCommand(query, connection))
                {
                    if (parameters != null)
                    {
                        command.Parameters.AddRange(parameters);
                    }

                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            results.Add(mapFunction(reader));
                        }
                    }
                }

                return results;
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, $"Error executing query: {query}");
                throw;
            } 
        }

        // Metodo per eseguire comandi SQL che non restituiscono righe (INSERT, UPDATE, DELETE)
        public int ExecuteNonQuery(string query, params SqlParameter[] parameter)
        {
            try
            {
                using (var conn = GetConnection()) // Using per garantire che la connessione venga chiusa correttamente
                {
                    var cmd = new SqlCommand(query, conn); // Creazione del comando SQL
                    cmd.Parameters.AddRange(parameter); // Aggiunta dei parametri al comando
                    conn.Open(); // Apertura della connessione
                    return cmd.ExecuteNonQuery(); // Esecuzione del comando e ritorno del numero di righe interessate
                }
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, $"Error executing non-query: {query}");
                throw;
            }
            
        }

        // Metodo per eseguire comandi SQL che restituiscono un singolo valore
        public object ExecuteScalar(string query, params SqlParameter[] parameters)
        {
            try
            {
                using (var conn = GetConnection()) // Using per garantire che la connessione venga chiusa correttamente
                {
                    var cmd = new SqlCommand(query, conn); // Creazione del comando SQL
                    cmd.Parameters.AddRange(parameters); // Aggiunta dei parametri al comando
                    conn.Open(); // Apertura della connessione
                    return cmd.ExecuteScalar(); // Esecuzione del comando e ritorno del primo valore della prima riga
                }
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, $"Error executing scalar: {query}");
                throw;
            }
            
        }
    }
}

