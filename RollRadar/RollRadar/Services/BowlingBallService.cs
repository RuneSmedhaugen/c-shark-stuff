using System.Data.SqlClient;
using RollRadar.Models;

namespace RollRadar.Services
{
    public class BowlingBallService
    {
        private readonly string _connectionString;

        public BowlingBallService(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void AddBowlingBall(BowlingBall bowlingBall)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string query = @"INSERT INTO Users (Brand, Cost, Surface, HookPotential, Type, Image )" +
                               "VALUES (@Brand, @Cost, @Surface, @HookPotential, @Type, @Image)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Brand", bowlingBall.Brand);
                    command.Parameters.AddWithValue("@Cost", bowlingBall.Cost);
                    command.Parameters.AddWithValue("@Surface", bowlingBall.Surface);
                    command.Parameters.AddWithValue("@HookPotential", bowlingBall.HookPotential);
                    command.Parameters.AddWithValue("@Type", bowlingBall.Type);
                    command.Parameters.AddWithValue("@Image", (object)bowlingBall.Image ?? DBNull.Value);

                    command.ExecuteNonQuery();
                }
            }
        }

        public void CreateBowlingBall()
        {
            Console.WriteLine("Write the brand/name of the ball:");
            var brand = Console.ReadLine();

            Console.WriteLine("Write the cost of the ball:");
            var cost = Console.ReadLine();

            Console.WriteLine("Write the surface of the ball:");
            var surface = Console.ReadLine();
        }
    }
}
