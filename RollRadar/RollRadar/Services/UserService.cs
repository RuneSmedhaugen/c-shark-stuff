using System.Data.SqlClient;
using RollRadar.Models;

namespace RollRadar.Services
{
    public class UserService : BaseService<User>
    {
        public UserService(string connectionString) : base(connectionString) { }

        protected override User MapFromReader(SqlDataReader reader)
        {
            return new User(
                reader["Name"].ToString(),
                reader["Email"].ToString(),
                reader["PasswordHash"].ToString(),
                reader.IsDBNull(reader.GetOrdinal("Age")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("Age")),
                reader["Hand"].ToString(),
                reader["Image"].ToString(),
                reader.IsDBNull(reader.GetOrdinal("Comments")) ? null : reader["Comments"].ToString()
            );
        }

        public void PrintUsers()
        {
            string query = "SELECT * FROM Users";

            Print(query, reader =>
            {
                Console.WriteLine($"Name: {reader["Name"]}, About: {reader["Comments"]}");
            });
        }

        public void EditUser(int id)
        {
            var columnPrompts = new Dictionary<string, string>
            {
                { "Username", "Enter the new username (or press Enter to keep current):" },
                { "Password", "Enter the new password (or press Enter to keep current):" },
                { "Comments", "Enter the new comments about the user (or press Enter to keep current):" }
            };

            ManageRecord(id, "Edit", columnPrompts);
        }

        public void DeleteUser(int id)
        {
            ManageRecord(id, "Delete");
        }
    }
}