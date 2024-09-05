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
                    command.Parameters.AddWithValue("@UserID", score.UserId);
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
            var score = Console.ReadLine();
            Console.WriteLine("Strikes:");
            var strikes = Console.ReadLine();
            Console.WriteLine("Spares:");
            var spares = Console.ReadLine();
            Console.WriteLine("Holes:");
            var holes = Console.ReadLine();
            Console.WriteLine("Bowling Alley:");
            var bowlingAlley = Console.ReadLine();
            Console.WriteLine("Date played:");
            var date = Console.ReadLine();
            Console.WriteLine("Image:");
            var image = Console.ReadLine();
            Console.WriteLine("Your own comment:");
            var comments = Console.ReadLine();

            Score newScore = new Score(score, strikes, spares, holes, bowlingAlley, date, image, comments);
        }
    }
}
