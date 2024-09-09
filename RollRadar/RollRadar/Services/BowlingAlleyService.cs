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

                string query = @"INSERT INTO BowlingAlleys (Name, Location, Review, Image)" +
                               "VALUES (@Name, @Location, @Review, @Image)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Name",bowlingAlley.name);
                    command.Parameters.AddWithValue("@Location",bowlingAlley.location);
                    command.Parameters.AddWithValue("@Review",bowlingAlley.comments);
                    command.Parameters.AddWithValue("@Image", (object)bowlingAlley.image ?? DBNull.Value);

                    command.ExecuteNonQuery();
                }
            }
        }

        public void CreateBowlingAlley()
        {
            Console.WriteLine("Name of the bowling alley");
            var name = Console.ReadLine();
            Console.WriteLine("Location:");
            var location = Console.ReadLine();
            Console.WriteLine("Your review:");
            var comments = Console.ReadLine();
            Console.WriteLine("Image:");
            var image = Console.ReadLine();

            BowlingAlley newBowlingAlley = new BowlingAlley(location, name, image, comments);

            AddBowlingAlley(newBowlingAlley);

        }

        public void PrintAllAlleys()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string query = @"SELECT * FROM BowlingAlleys";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string name = reader["Name"].ToString();
                            string location = reader["Location"].ToString();
                            string review = reader["Review"].ToString();
                            string image = reader.IsDBNull(reader.GetOrdinal("Image"))
                                ? "No Image"
                                : reader["Image"].ToString();


                            Console.WriteLine(
                                $"Name: {name}, Location: {location}, Review: {review}, Image: {image}");
                        }
                    }
                }
            }
        }
    }
}
