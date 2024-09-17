using System.Data.SqlClient;
using System.Reflection.Metadata.Ecma335;

namespace RollRadar.Services
{
    public abstract class BaseService<T>
    {
        private readonly string _connectionString;

        protected BaseService(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void Add(string query, Dictionary<string, object?> parameters)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    foreach (var param in parameters)
                    {
                        command.Parameters.AddWithValue(param.Key, param.Value ?? DBNull.Value);
                    }

                    command.ExecuteNonQuery();
                }
            }
        }

        public void Edit(string query, Dictionary<string, object?> parameters)
        {
            Add(query, parameters);
        }

        public void Delete(string query, Dictionary<string, object?> parameters)
        {
            Add(query, parameters); 

        }

        public void Print(string query, Action<SqlDataReader> printAction)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            printAction(reader);
                        }
                    }
                }
            }
        }

        public T GetSingle(string query, Dictionary<string, object?> parameters, Func<SqlDataReader, T> mapToEntity)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    foreach (var param in parameters)
                    {
                        command.Parameters.AddWithValue(param.Key, param.Value ?? DBNull.Value);
                    }

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return mapToEntity(reader);
                        }
                    }
                }

                throw new Exception("Record not found");
            }
        }

        public abstract void Create();
    }
}
