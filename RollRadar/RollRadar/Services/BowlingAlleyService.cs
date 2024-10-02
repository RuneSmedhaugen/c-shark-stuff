using RollRadar.Models;

public class BowlingAlleyService : BaseService
{
    private readonly Users _currentUser;

    public BowlingAlleyService(string connectionString, Users currentUser) : base(connectionString)
    {
        _currentUser = currentUser;
    }

    public void AddBowlingAlley()
    {
        Console.Write("Enter alley name: ");
        string name = Console.ReadLine();

        Console.Write("Enter alley location: ");
        string location = Console.ReadLine();

        Console.Write("Enter a review (optional): ");
        string review = Console.ReadLine();

        Console.Write("Enter an image URL (optional): ");
        string image = Console.ReadLine();

        string query = "INSERT INTO BowlingAlleys (Name, Location, Review, Image, UserId) " +
                       "VALUES (@Name, @Location, @Review, @Image, @UserId)";
        ExecuteNonQuery(query, (cmd) =>
        {
            cmd.Parameters.AddWithValue("@Name", name);
            cmd.Parameters.AddWithValue("@Location", location);
            cmd.Parameters.AddWithValue("@Review", review);
            cmd.Parameters.AddWithValue("@Image", image);
            cmd.Parameters.AddWithValue("@UserId", _currentUser.Id);
        });

        Console.WriteLine("Bowling alley added successfully.");
    }

    public void EditBowlingAlley(int id)
    {
        //TO DO
    }

    public void DeleteBowlingAlley(int id)
    {
        string query = "DELETE FROM BowlingAlleys WHERE Id = @Id AND UserId = @UserId";
        ExecuteNonQuery(query, (cmd) =>
        {
            cmd.Parameters.AddWithValue("@Id", id);
            cmd.Parameters.AddWithValue("@UserId", _currentUser.Id);
        });

        Console.WriteLine("Bowling alley deleted successfully.");
    }

    public void ViewAllBowlingAlleys()
    {
        string query = "SELECT * FROM BowlingAlleys WHERE UserId = @UserId";
        using (var reader = ExecuteReader(query, (cmd) => cmd.Parameters.AddWithValue("@UserId", _currentUser.Id)))
        {
            while (reader.Read())
            {
                int id = reader.GetInt32(reader.GetOrdinal("Id"));
                string name = reader.GetString(reader.GetOrdinal("Name"));
                string location = reader.GetString(reader.GetOrdinal("Location"));
                string review = reader.GetString(reader.GetOrdinal("Review"));

                Console.WriteLine($"ID: {id}, Name: {name}, Location: {location}, Review: {review}");
            }
        }
    }
}
