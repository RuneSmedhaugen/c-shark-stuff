using System.ComponentModel;
using RollRadar.Models;
using System.Data.SqlClient;
using System.Runtime.InteropServices.JavaScript;

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
                    command.Parameters.AddWithValue("@UserId", (object)score.UserId ?? DBNull.Value);
                    command.Parameters.AddWithValue("@TotalScore", score.TotalScore);
                    command.Parameters.AddWithValue("@Strikes", score.Strikes);
                    command.Parameters.AddWithValue("@Spares", score.Spares);
                    command.Parameters.AddWithValue("@Holes", score.Holes);
                    command.Parameters.AddWithValue("@BowlingAlley", (object)score.BowlingAlleyId ?? DBNull.Value);
                    command.Parameters.AddWithValue("@ScoreDate", score.ScoreDate);
                    command.Parameters.AddWithValue("@Image", (object)score.Image ?? DBNull.Value);
                    command.Parameters.AddWithValue("@Comments", (object)score.Comments ?? DBNull.Value);
                    command.Parameters.AddWithValue("@Name", (object)score.Name ?? DBNull.Value);

                    command.ExecuteNonQuery();
                }
            }
        }


        public void CreateScore()
        {
            string GetValidInput(string prompt)
            {
                string input;
                while (true)
                {
                    Console.WriteLine(prompt);
                    input = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(input))
                    {
                        return input;
                    }
                    Console.WriteLine("Please provide a valid input.");
                }
            }

            int GetValidIntInput(string prompt)
            {
                int result;
                while (true)
                {
                    Console.WriteLine(prompt);
                    string input = Console.ReadLine();
                    if (int.TryParse(input, out result))
                    {
                        return result;
                    }
                    Console.WriteLine("Please provide a valid number.");
                }
            }

            string name = GetValidInput("Name your score:");
            int totalScore = GetValidIntInput("Write the total score:");
            int strikes = GetValidIntInput("Strikes:");
            int spares = GetValidIntInput("Spares:");
            int holes = GetValidIntInput("Holes:");
            string bowlingAlley = GetValidInput("Bowling Alley played in:");

            DateTime date;
            while (true)
            {
                Console.WriteLine("Date played (DD-MM-YYYY):");
                if (DateTime.TryParseExact(Console.ReadLine(), "dd-MM-yyyy", null, System.Globalization.DateTimeStyles.None, out date))
                {
                    break;
                }
                Console.WriteLine("Please provide a valid date in DD-MM-YYYY format.");
            }

            Console.WriteLine("Image (Optional):");
            string image = Console.ReadLine();

            Console.WriteLine("Comments (Optional):");
            string comments = Console.ReadLine();

            Score newScore = new Score(name, totalScore, strikes, spares, holes, date,bowlingAlley,image,comments);

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

                            string formattedDate = scoreDate.ToString("dd-MM-yyyy");

                            Console.WriteLine(
                                $"Score: {totalScore}, Strikes: {strikes}, Spares: {spares}, Holes: {holes}, Date played: {formattedDate}, Image: {image}, Alley: {bowlingAlley}" +
                                $"Comments: {comments}");
                        }
                    }
                }
            }
        }
    }
}
