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
                    command.Parameters.AddWithValue("@Name", bowlingAlley.Name);
                    command.Parameters.AddWithValue("@Location", bowlingAlley.location);
                    command.Parameters.AddWithValue("@Review", bowlingAlley.Comments);
                    command.Parameters.AddWithValue("@Image", (object)bowlingAlley.Image ?? DBNull.Value);

                    command.ExecuteNonQuery();
                }
            }
        }

        public void CreateBowlingAlley()
        {
            string name;
            do
            {
                Console.WriteLine("Name of the bowling alley:");
                name = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(name))
                {
                    Console.WriteLine("Please provide a name of the bowling alley you are reviewing.");
                }
            } while (string.IsNullOrWhiteSpace(name));

            string location;
            do
            {
                Console.WriteLine("Location:");
                location = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(location))
                {
                    Console.WriteLine("Please provide a location for the bowling alley.");
                }
            } while (string.IsNullOrWhiteSpace(location));

            string comments;
            do
            {
                Console.WriteLine("Your review:");
                comments = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(comments))
                {
                    Console.WriteLine("Please write a review of the bowling alley.");
                }
            } while (string.IsNullOrWhiteSpace(comments));

            Console.WriteLine("Image url (Optional):");
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
