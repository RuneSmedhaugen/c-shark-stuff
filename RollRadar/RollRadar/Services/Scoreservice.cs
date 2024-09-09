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

                string query = @"INSERT INTO Scores(UserId, TotalScore, Strikes, Spares, Holes, BowlingAlley, ScoreDate, Image, Comments, Name)
                         VALUES (@UserId, @TotalScore, @Strikes, @Spares, @Holes, @BowlingAlley, @ScoreDate, @Image, @Comments, @Name)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserId", (object)score.userId ?? DBNull.Value);
                    command.Parameters.AddWithValue("@TotalScore", score.totalScore);
                    command.Parameters.AddWithValue("@Strikes", score.strikes);
                    command.Parameters.AddWithValue("@Spares", score.spares);
                    command.Parameters.AddWithValue("@Holes", score.holes);
                    command.Parameters.AddWithValue("@BowlingAlley", (object)score.bowlingAlleyId ?? DBNull.Value);
                    command.Parameters.AddWithValue("@ScoreDate", score.scoreDate);
                    command.Parameters.AddWithValue("@Image", (object)score.image ?? DBNull.Value);
                    command.Parameters.AddWithValue("@Comments", (object)score.comments ?? DBNull.Value);
                    command.Parameters.AddWithValue("@Name", (object)score.name ?? DBNull.Value);

                    command.ExecuteNonQuery();
                }
            }
        }


        public void CreateScore()
        {
            Console.WriteLine("Name your score:");
            var name = Console.ReadLine();
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

            Score newScore = new Score(name, score, strikes, spares, holes, date,bowlingAlley,image,comments);

            AddScore(newScore);
        }

        public void PrintAllScores()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string query = @"SELECT * FROM Scores";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int totalScore = reader.GetInt32(reader.GetOrdinal("TotalScore"));
                            int strikes = reader.GetInt32(reader.GetOrdinal("Strikes"));
                            int spares = reader.GetInt32(reader.GetOrdinal("Spares"));
                            int holes = reader.GetInt32(reader.GetOrdinal("Holes"));
                            DateTime scoreDate = reader.GetDateTime(reader.GetOrdinal("ScoreDate"));
                            string image = reader["Image"].ToString();
                            string comments = reader["Comments"].ToString();
                            string bowlingAlley = reader["BowlingAlley"].ToString();

                            Console.WriteLine(
                                $"Score: {totalScore}, Strikes: {strikes}, Spares: {spares}, Holes: {holes}, Date played: {scoreDate}, Image: {image}, Alley: {bowlingAlley}" +
                                $"Comments: {comments}");
                        }
                    }
                }
            }
        }
    }
}
