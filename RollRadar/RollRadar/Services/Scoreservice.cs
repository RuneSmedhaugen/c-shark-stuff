using System.ComponentModel;
using RollRadar.Models;
using System.Data.SqlClient;

namespace RollRadar.Services
{
    public class Scoreservice
    {
        private readonly string _connectionString;

        public Scoreservice(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void AddScore(Score score)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string query = "INSERT * INTO Scores(UserID, TotalScore, Strikes, Spares, Holes, BowlingAlley, ScoreDate, Image, Comments)" +
                               "VALUES (@UserID, @TotalScore, @Strikes, @Spares, @Holes, @BowlingAlley @ScoreDate, @Image, @Comments)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserID", (object) score.UserId ?? DBNull.Value);
                    command.Parameters.AddWithValue("BowlingAlleyId", (object)score.BowlingAlleyId ?? DBNull.Value);
                    command.Parameters.AddWithValue("@TotalScore", score.TotalScore);
                    command.Parameters.AddWithValue("@Strikes", score.Strikes);
                    command.Parameters.AddWithValue("@Spares", score.Spares);
                    command.Parameters.AddWithValue("@Holes", score.Holes);
                    command.Parameters.AddWithValue("@BowlingAlley", score.BowlingAlleyId);
                    command.Parameters.AddWithValue("@ScoreDate", score.ScoreDate);
                    command.Parameters.AddWithValue("@Image", score.Image);
                    command.Parameters.AddWithValue("@Comments", score.Comments);

                    command.ExecuteNonQuery();
                }
            }
        }

        public void CreateScore()
        {
            Console.WriteLine("Write the total score:");
            var score = int.Parse(Console.ReadLine());
            Console.WriteLine("Strikes:");
            var strikes = int.Parse(Console.ReadLine());
            Console.WriteLine("Spares:");
            var spares = int.Parse(Console.ReadLine());
            Console.WriteLine("Holes:");
            var holes = int.Parse(Console.ReadLine());
            Console.WriteLine("Bowling Alley:");
            var bowlingAlley = Console.ReadLine();
            Console.WriteLine("Date played (YYYY-MM-DD):");
            var date = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Image:");
            var image = Console.ReadLine();
            Console.WriteLine("Your own comment:");
            var comments = Console.ReadLine();

            Score newScore = new Score(score, strikes, spares, holes, date, image, comments, bowlingAlley);

            AddScore(newScore);
        }
    }
}
