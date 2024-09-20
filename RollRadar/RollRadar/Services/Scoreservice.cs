using System.Data.SqlClient;
using RollRadar.Models;

namespace RollRadar.Services
{
    public class ScoreService : BaseService<Score>
    {
        public ScoreService(string connectionString, AuthenticationService authService) : base(connectionString, authService) { }

        protected override Score MapFromReader(SqlDataReader reader)
        {
            return new Score(
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

        public void CreateScore()
        {
            var columnPrompts = new Dictionary<string, string>
            {
                { "Points", "Enter the points scored:" },
                { "ScoreDate", "Enter the date of the score (yyyy-mm-dd):" }
            };

            ManageRecord(null, "Add", columnPrompts);
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