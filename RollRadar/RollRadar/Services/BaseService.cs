using System;
using System.Data.SqlClient;

public abstract class BaseService
{
    protected readonly string _connectionString;

    protected BaseService(string connectionString)
    {
        _connectionString = connectionString;
    }

    protected SqlConnection GetConnection()
    {
        return new SqlConnection(_connectionString);
    }

    protected void ExecuteNonQuery(string query, Action<SqlCommand> paramConfigurer)
    {
        using (var connection = GetConnection())
        {
            connection.Open();
            using (var command = new SqlCommand(query, connection))
            {
                paramConfigurer(command);
                command.ExecuteNonQuery();
            }
        }
    }

    protected SqlDataReader ExecuteReader(string query, Action<SqlCommand> paramConfigurer)
    {
        var connection = GetConnection();
        connection.Open();
        using (var command = new SqlCommand(query, connection))
        {
            paramConfigurer(command);
            return command.ExecuteReader();
        }
    }
}