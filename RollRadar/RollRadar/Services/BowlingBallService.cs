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

                string query = @"INSERT INTO BowlingBalls (Brand, Cost, Surface, HookPotential, Type, Image, Comments )" +
                               "VALUES (@Brand, @Cost, @Surface, @HookPotential, @Type, @Image, @Comments)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Brand", bowlingBall.Brand);
                    command.Parameters.AddWithValue("@Cost", (object)bowlingBall.Cost ?? DBNull.Value);
                    command.Parameters.AddWithValue("@Surface", bowlingBall.Surface);
                    command.Parameters.AddWithValue("@HookPotential", bowlingBall.HookPotential);
                    command.Parameters.AddWithValue("@Type", bowlingBall.Type);
                    command.Parameters.AddWithValue("@Image", (object)bowlingBall.Image ?? DBNull.Value);
                    command.Parameters.AddWithValue("@Comments", (object)bowlingBall.Comments ?? DBNull.Value);

                    command.ExecuteNonQuery();
                }
            }
        }

        public void CreateBowlingBall()
        {
            Console.WriteLine("Write the brand of the ball:");
            var brand = Console.ReadLine();

            Console.WriteLine("Name of the ball:");
            var name = Console.ReadLine();

            Console.WriteLine("Write the cost of the ball:");
            decimal cost = decimal.Parse(Console.ReadLine());

            Console.WriteLine("Write the surface of the ball:");
            var surface = Console.ReadLine();

            Console.WriteLine("What hookpotential does the ball have (1-100):");
            int hookPotential = int.Parse(Console.ReadLine());

            Console.WriteLine("Coverstock of the ball (reactive, urethane etc):");
            var type = Console.ReadLine();

            Console.WriteLine("Your review:");
            var review = Console.ReadLine();

            Console.WriteLine("Link to image:");
            var image = Console.ReadLine();

            BowlingBall newBall = new BowlingBall(brand, cost, surface, hookPotential, type, name, image, review);

            AddBowlingBall(newBall);
        }

        public void PrintBalls()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string query = @"SELECT * FROM BowlingBalls";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string brand = reader["Brand"].ToString();
                            decimal cost = reader.IsDBNull(reader.GetOrdinal("Cost"))
                                ? 0
                                : reader.GetDecimal(reader.GetOrdinal("Cost"));
                            string surface = reader["Surface"].ToString();
                            int hookPotential = reader.IsDBNull(reader.GetOrdinal("HookPotential"))
                                ? 0
                                : reader.GetInt32(reader.GetOrdinal("HookPotential"));
                            string type = reader["Type"].ToString();
                            string image = reader.IsDBNull(reader.GetOrdinal("Image"))
                                ? "No Image"
                                : reader["Image"].ToString();
                            string review = reader["Comments"].ToString();

                            Console.WriteLine(
                                @$"Brand: {brand}, Cost: {cost}, Surface: {surface}, Hook Potential: {hookPotential}, Coverstock: {type}, Image: {image}
Review: {review}");
                        }
                    }
                }
            }
        }
    }
}
