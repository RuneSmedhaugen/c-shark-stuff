using System.Data.SqlClient;
using RollRadar.Models;

namespace RollRadar.Services
{
    public class ScoreService : BaseService<Scores>
    {
        public ScoreService(string connectionString, AuthenticationService authService) : base(connectionString, authService) { }

        protected override Scores MapFromReader(SqlDataReader reader)
        {
            return new Scores(
                reader["Name"].ToString(),
                reader.GetInt32(reader.GetOrdinal("TotalScore")),
                reader.GetInt32(reader.GetOrdinal("Strikes")),
                reader.GetInt32(reader.GetOrdinal("Spares")),
                reader.GetInt32(reader.GetOrdinal("Holes")),
                reader.GetDateTime(reader.GetOrdinal("ScoreDate")),
                reader["BowlingAlleyName"].ToString(),
                reader["Image"].ToString(),
                reader["Comments"].ToString()
            );
        }

        public void CreateScore(int currentUserId)
        {
            var columnPrompts = new Dictionary<string, string>
            {
                { "Name", "Give your score a name:" },
                { "TotalScore", "Enter the points scored:" },
                { "Strikes", "Enter total strikes:" },
                { "Spares", "Enter total spares:" },
                { "Holes", "Enter total holes:" },
                { "ScoreDate", "Enter the date of the score (yyyy-mm-dd):" },
                { "Image", "Enter the link to image(Optional):" },
                { "Comments", "Enter your comments on the series(Optional):" },
                { "BowlingAlleyId", "Enter the bowling alley played in(Optional):" },
                
            };

            ManageRecord(null, "Add", columnPrompts, currentUserId);
        }

        public void PrintScores()
        {
            string query = "SELECT * FROM Scores";

            Print(query, reader =>
            {
                Console.WriteLine($"Points: {reader["Points"]}, ScoreDate: {reader["ScoreDate"]}, " +
                                  $"Created By User ID: {reader["UserId"]}");
            });
        }

        public void EditScore(int id)
        {
            var columnPrompts = new Dictionary<string, string>
            {
                { "Points", "Enter the new points scored (or press Enter to keep current):" },
                { "ScoreDate", "Enter the new date of the score (yyyy-mm-dd) (or press Enter to keep current):" }
            };

            ManageRecord(id, "Edit", columnPrompts);
        }

        public void DeleteScore(int id)
        {
            ManageRecord(id, "Delete");
        }

        public void GetAllScores()
        {
            GetAll("Scores");
        }
    }
}