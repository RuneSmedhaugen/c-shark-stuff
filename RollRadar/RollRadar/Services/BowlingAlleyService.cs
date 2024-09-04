using RollRadar.Models;
using System.Data.SqlClient;

namespace RollRadar.Services
{
    public class BowlingAlleyService
    {
        private readonly string _connectionString;

        public BowlingAlleyService(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void AddBowlingAlley(BowlingAlley bowlingAlley) 
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string query = @"INSERT INTO Users (Name, Location, Review, Image,)" +
                               "VALUES (@Name, @Location, @Review, @Image,)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Name",bowlingAlley.Name);
                    command.Parameters.AddWithValue("@Location",bowlingAlley.Location);
                    command.Parameters.AddWithValue("@Review",bowlingAlley.Review);
                    command.Parameters.AddWithValue("@Image", (object)bowlingAlley.Image ?? DBNull.Value);

                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
