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
            string GetValidInput(string prompt)
            {
                string input;
                while (true)
                {
                    Console.WriteLine(prompt);
                    input = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(input))
                    {
                        return input;
                    }
                    Console.WriteLine("Please provide a valid input.");
                }
            }

            decimal? GetOptionalDecimal(string prompt)
            {
                while (true)
                {
                    Console.WriteLine(prompt);
                    var input = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(input)) return null;
                    if (decimal.TryParse(input, out decimal result)) return result;
                    Console.WriteLine("Please provide a valid number.");
                }
                
            }

            int GetIntRange(string prompt, int min, int max)
            {
                int value;
                while (true)
                {
                    Console.WriteLine(prompt);
                    var input = Console.ReadLine();
                    if (int.TryParse(input, out value) && value >= min && value <= max)
                    {
                        return value;
                    }

                    Console.WriteLine($"please write a number between {min} and {max}.");
                }
            }

            string brand = GetValidInput("Write the brand of the ball:");
            string name = GetValidInput("Write the name of the ball:");
            decimal? cost = GetOptionalDecimal("Write the cost of the ball (Optional):");
            string surface = GetValidInput("Write the surface of the ball:");
            int hookPotential = GetIntRange("Write the hook potential of the ball (0-100):", 0, 100);
            string type = GetValidInput("Coverstock of the ball:");
            string review = GetValidInput("Your review of the ball:");

            Console.WriteLine("Link to image(Optional):");
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
