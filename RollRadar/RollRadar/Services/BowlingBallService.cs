using System.Data.SqlClient;
using RollRadar.Models;

namespace RollRadar.Services
{
    public class BowlingBallService : BaseService<BowlingBalls>
    {

        public BowlingBallService(string connectionString ,AuthenticationService authService) 
            : base(connectionString, authService)
        {

        }

        protected override BowlingBalls MapFromReader(SqlDataReader reader)
        {
            return new BowlingBalls(
                reader["Brand"].ToString(),
                reader.IsDBNull(reader.GetOrdinal("Cost")) ? null : reader.GetDecimal(reader.GetOrdinal("Cost")),
                reader["Surface"].ToString(),
                reader.GetInt32(reader.GetOrdinal("HookPotential")),
                reader["Type"].ToString(),
                reader["Name"].ToString(),
                reader["Image"].ToString(),
                reader["Comments"].ToString()
            );
        }

        public void CreateBowlingBall(int currentUserId)
        {
            var columnPrompts = new Dictionary<string, string>
            {
                { "Brand", "Enter the brand of the ball:" },
                { "Name", "Enter the name of the ball:" },
                { "Cost", "Enter the cost of the ball (optional):" },
                { "Surface", "Enter the surface of the ball:" },
                { "HookPotential", "Enter the hook potential (0-100):" },
                { "Type", "Enter the coverstock type:" },
                { "Image", "Enter the image URL (optional):" },
                { "Comments", "Enter your review of the ball:" }
            };

            ManageRecord(null, "Add", columnPrompts, currentUserId);
        }

        public void PrintBowlingBalls()
        {
            string query = "SELECT * FROM BowlingBalls";

            Print(query, reader =>
            {
                Console.WriteLine($"Brand: {reader["Brand"]}, Name: {reader["Name"]}, Cost: {reader["Cost"]}, " +
                                  $"Surface: {reader["Surface"]}, HookPotential: {reader["HookPotential"]}, " +
                                  $"Type: {reader["Type"]}, Image: {reader["Image"]}, Comments: {reader["Comments"]}, " +
                                  $"CreatedBy: {reader["UserId"]}");
            });
        }

        public void EditBowlingBall(int id)
        {
            var columnPrompts = new Dictionary<string, string>
            {
                { "Brand", "Enter the new brand of the ball (or press Enter to keep current):" },
                { "Name", "Enter the new name of the ball (or press Enter to keep current):" },
                { "Cost", "Enter the new cost of the ball (or press Enter to keep current):" },
                { "Surface", "Enter the new surface of the ball (or press Enter to keep current):" },
                { "HookPotential", "Enter the new hook potential (0-100) (or press Enter to keep current):" },
                { "Type", "Enter the new coverstock type (or press Enter to keep current):" },
                { "Image", "Enter the new image URL (or press Enter to keep current):" },
                { "Comments", "Enter the new review of the ball (or press Enter to keep current):" }
            };

            ManageRecord(id, "Edit", columnPrompts);
        }

        public void DeleteBowlingBall(int id)
        {
            ManageRecord(id, "Delete", null);
        }

        public void GetAllBowlingBalls()
        {
            GetAll("BowlingBalls");
        }
    }
}
