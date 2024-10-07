using RollRadar.Models;

public class ScoreService : BaseService
{
    private readonly Users _currentUser;

    public ScoreService(string connectionString, Users currentUser) : base(connectionString)
    {
        _currentUser = currentUser;
    }

    public void AddScore()
    {
        Console.Write("Enter total score: ");
        int totalScore = int.Parse(Console.ReadLine());

        Console.Write("Enter number of strikes: ");
        int strikes = int.Parse(Console.ReadLine());

        Console.Write("Enter number of spares: ");
        int spares = int.Parse(Console.ReadLine());

        Console.Write("Enter number of holes: ");
        int holes = int.Parse(Console.ReadLine());

        Console.Write("Enter the date the score was recorded (yyyy-mm-dd): ");
        DateTime scoreDate = DateTime.Parse(Console.ReadLine());

        Console.Write("Enter the name of the bowling alley: ");
        string bowlingAlley = Console.ReadLine();

        Console.Write("Enter an image URL (optional): ");
        string image = Console.ReadLine();

        Console.Write("Enter any comments (optional): ");
        string comments = Console.ReadLine();

        string query = "INSERT INTO Scores (UserId, TotalScore, Strikes, Spares, Holes, ScoreDate, Image, Comments, BowlingAlley, Name) " +
                       "VALUES (@UserId, @TotalScore, @Strikes, @Spares, @Holes, @ScoreDate, @Image, @Comments, @BowlingAlley, @Name)";
        ExecuteNonQuery(query, (cmd) =>
        {
            cmd.Parameters.AddWithValue("@UserId", _currentUser.Id);
            cmd.Parameters.AddWithValue("@TotalScore", totalScore);
            cmd.Parameters.AddWithValue("@Strikes", strikes);
            cmd.Parameters.AddWithValue("@Spares", spares);
            cmd.Parameters.AddWithValue("@Holes", holes);
            cmd.Parameters.AddWithValue("@ScoreDate", scoreDate);
            cmd.Parameters.AddWithValue("@Image", image);
            cmd.Parameters.AddWithValue("@Comments", comments);
            cmd.Parameters.AddWithValue("@BowlingAlley", bowlingAlley);
            cmd.Parameters.AddWithValue("@Name", _currentUser.Name);
        });

        Console.WriteLine("Score added successfully.");
    }

    public void EditScore(int id)
    {
        //TO DO
    }

    public void DeleteScore(int id)
    {
        string query = "DELETE FROM Scores WHERE Id = @Id AND UserId = @UserId";
        ExecuteNonQuery(query, (cmd) =>
        {
            cmd.Parameters.AddWithValue("@Id", id);
            cmd.Parameters.AddWithValue("@UserId", _currentUser.Id);
        });

        Console.WriteLine("Score deleted successfully.");
    }

    public List<Scores> ViewAllScores()
    {
        string query = "SELECT * FROM Scores WHERE UserId = @UserId";
        List<Scores> scores = new List<Scores>();

        using (var reader = ExecuteReader(query, (cmd) => cmd.Parameters.AddWithValue("@UserId", _currentUser.Id)))
        {
            while (reader.Read())
            {
                var score = new Scores
                {
                    Id = reader.GetInt32(reader.GetOrdinal("Id")),
                    UserId = reader.GetInt32(reader.GetOrdinal("UserId")),
                    Name = reader.GetString(reader.GetOrdinal("Name")),
                    TotalScore = reader.GetInt32(reader.GetOrdinal("TotalScore")),
                    Strikes = reader.GetInt32(reader.GetOrdinal("Strikes")),
                    Spares = reader.GetInt32(reader.GetOrdinal("Spares")),
                    Holes = reader.GetInt32(reader.GetOrdinal("Holes")),
                    ScoreDate = reader.GetDateTime(reader.GetOrdinal("ScoreDate")),
                    Comments = reader.GetString(reader.GetOrdinal("Comments")),
                    BowlingAlleyName = reader.GetString(reader.GetOrdinal("BowlingAlley"))
                };

                scores.Add(score);
            }
        }

        return scores;
    }

}
