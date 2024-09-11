using System.Data.SqlClient;
using RollRadar.Models;

namespace RollRadar.Services
{
    public class UserService
    {
        private readonly string _connectionString;

        public UserService(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void AddUser(User user)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string query = @"INSERT INTO Users (Email, PasswordHash, Name, Age, Hand, ProfilePic)" +
                                "VALUES (@Email, @PasswordHash, @Name, @Age, @Hand, @ProfilePic)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Email", user.Email);
                    command.Parameters.AddWithValue("@PasswordHash", user.PasswordHash);
                    command.Parameters.AddWithValue("@Name", user.Name);
                    command.Parameters.AddWithValue("@Age", user.Age);
                    command.Parameters.AddWithValue("@Hand", user.Hand);
                    command.Parameters.AddWithValue("@ProfilePic", (object)user.Image ?? DBNull.Value);

                    command.ExecuteNonQuery();
                }
            }
        }

        public void CreateUser()
        {
            Console.Write("Enter your email: ");
            string email = Console.ReadLine();

            Console.Write("Enter your password: ");
            string password = Console.ReadLine();

            Console.Write("Enter your name: ");
            string name = Console.ReadLine();

            Console.Write("Enter your age: ");
            string ageInput = Console.ReadLine();
            int? age = string.IsNullOrEmpty(ageInput) ? (int?)null : int.Parse(ageInput);

            Console.Write("Enter your hand (Lefty/Righty): ");
            string hand = Console.ReadLine();

            Console.WriteLine("About yourself:");
            var comments = Console.ReadLine();

            Console.Write("Enter the path to your profile picture (optional): ");
            string image = Console.ReadLine();


            User newUser = new User(name, email, password, age, hand, image, comments);

            AddUser(newUser);
        }

        public void PrintUsers()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string query = @"SELECT * FROM Users";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string email = reader["Email"].ToString();
                            string passwordHash = reader["PasswordHash"].ToString();
                            string name = reader["Name"].ToString();
                            int age = reader.GetInt32(reader.GetOrdinal("Age"));
                            string hand = reader["Hand"].ToString();
                            string profilePic = reader.IsDBNull(reader.GetOrdinal("ProfilePic"))
                                ? "No Image"
                                : reader["ProfilePic"].ToString();


                            Console.WriteLine(
                                $"Email: {email}, Password: {passwordHash}, Age: {age}, Hand: {hand}, Profile Picture: {profilePic}");
                        }
                    }
                }
            }
        }
    }
}
