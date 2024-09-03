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
                    command.Parameters.AddWithValue("@Age", (object)user.Age ?? DBNull.Value);
                    command.Parameters.AddWithValue("@Hand", user.Hand);
                    command.Parameters.AddWithValue("@ProfilePic", (object)user.ProfilePic ?? DBNull.Value);

                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
