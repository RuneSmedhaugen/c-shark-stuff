using System.Data.SqlClient;
using RollRadar.Models;

namespace RollRadar.Services
{
    public class BowlingAlleyService : BaseService<BowlingAlley>
    {
        public BowlingAlleyService(string connectionString) : base(connectionString) { }

        protected override BowlingAlley MapFromReader(SqlDataReader reader)
        {
            return new BowlingAlley(
                reader["Name"].ToString(),
                reader["Location"].ToString(),
                reader.IsDBNull(reader.GetOrdinal("Review")) ? null : reader["Review"].ToString(),
                reader.IsDBNull(reader.GetOrdinal("Image")) ? null : reader["Image"].ToString(),
                reader.GetInt32(reader.GetOrdinal("UserId"))
            );
        }

        public void CreateBowlingAlley()
        {
            var columnPrompts = new Dictionary<string, string>
            {
                { "Name", "Enter the name of the alley:" },
                { "Location", "Enter the location of the alley:" },
                { "Review", "Enter your review of the alley (optional):" },
                { "Image", "Enter the image URL (optional):" }
            };

            ManageRecord(null, "Add", columnPrompts);
        }

        public void PrintBowlingAlleys()
        {
            string query = "SELECT * FROM BowlingAlleys";

            Print(query, reader =>
            {
                Console.WriteLine($"Name: {reader["Name"]}, Location: {reader["Location"]}, " +
                                  $"Review: {reader["Review"]}, Image: {reader["Image"]}, " +
                                  $"Created By User ID: {reader["UserId"]}");
            });
        }

        public void EditBowlingAlley(int id)
        {
            var columnPrompts = new Dictionary<string, string>
            {
                { "Name", "Enter the new name of the alley (or press Enter to keep current):" },
                { "Location", "Enter the new location of the alley (or press Enter to keep current):" },
                { "Review", "Enter the new review of the alley (or press Enter to keep current):" },
                { "Image", "Enter the new image URL (or press Enter to keep current):" }
            };

            ManageRecord(id, "Edit", columnPrompts);
        }

        public void DeleteBowlingAlley(int id)
        {
            ManageRecord(id, "Delete");
        }
    }
}
