using System;
using System.Data.SqlClient;

class Program
{
    static void Main()
    {
        string connectionString = @"Server=.\SQLEXPRESS;Database=BowlingDB;Trusted_Connection=True;";

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            using (SqlCommand command = connection.CreateCommand("SELECT COUNT(*) FROM USERS", connection))
            {
                int usercount = (int)command.ExecuteScalar();
                Console.WriteLine($"Users: ");
            }
        }
    }
}