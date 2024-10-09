using System;
using System.Data;
using System.Data.SqlClient;

namespace VisionHub.Services
{
    public abstract class BaseService
    {
        private readonly string _connectionString;

        protected BaseService(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void ExecuteNonQuery(string query, SqlParameter[] parameters = null)
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    using (var command = new SqlCommand(query, connection))
                    {
                        if (parameters != null)
                        {
                            command.Parameters.AddRange(parameters);
                        }
                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();
                        Console.WriteLine($"Rows affected: {rowsAffected}"); // Log number of affected rows
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in ExecuteNonQuery: " + ex.Message); // Log the error
            }
        }


        public DataTable ExecuteQuery(string query, SqlParameter[] parameters = null)
        {
            DataTable dataTable = new DataTable();

            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    using (var  cmd = new SqlCommand(query, connection))
                    {
                        if (parameters != null)
                        {
                            cmd.Parameters.AddRange(parameters);
                        }
                        connection.Open();
                        using (var reader = cmd.ExecuteReader())
                        {
                            dataTable.Load(reader);
                        }
                    }
                }
            }
            catch (SqlException ex) 
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            return dataTable;
        }
    }
}
