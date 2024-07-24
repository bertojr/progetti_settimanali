using System;
using System.Data.SqlClient;

namespace _07232024_s6_progetto.Services
{
	public class DatabaseHelper
	{
		private readonly string _connectionString;

		public DatabaseHelper(string connectionString)
		{
			_connectionString = connectionString;
		}

		private SqlConnection GetConnection()
		{
			return new SqlConnection(_connectionString);
		}

		public List<T> ExecuteQuery<T>(string query, Func<SqlDataReader, T> mapFunction)
		{
			var results = new List<T>();
			using (var conn = GetConnection())
			{
                var cmd = new SqlCommand(query, conn);
                conn.Open();
                using (var reader = cmd.ExecuteReader())
				{
                    while (reader.Read())
                    {
                        results.Add(mapFunction(reader));
                    }
                }
            }
			return results;
		}

		public int ExecuteNonQuery(string query, params SqlParameter[] parameter)
		{
			using(var conn = GetConnection())
			{
				var cmd = new SqlCommand(query, conn);
				cmd.Parameters.AddRange(parameter);
				conn.Open();
				return cmd.ExecuteNonQuery();
			}
		}

		public object ExecuteScalar(string query, params SqlParameter[] parameters)
		{
			using(var conn = GetConnection())
			{
				var cmd = new SqlCommand(query, conn);
				cmd.Parameters.AddRange(parameters);
				conn.Open();
				return cmd.ExecuteScalar();
			}
		}
	}
}

