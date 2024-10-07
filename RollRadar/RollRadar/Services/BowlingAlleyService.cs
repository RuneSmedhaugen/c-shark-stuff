using RollRadar.Models;

public class BowlingAlleyService : BaseService
{
    private readonly Users _currentUser;

    public BowlingAlleyService(string connectionString, Users currentUser) : base(connectionString)
    {
        _currentUser = currentUser;
    }

    public void AddBowlingAlley(int userId)
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
        // Query to get the existing bowling alley by ID
        string selectQuery = "SELECT * FROM BowlingAlleys WHERE Id = @Id AND UserId = @UserId";

        BowlingAlleys existingAlley = null;

        // Step 1: Retrieve the existing bowling alley
        using (var reader = ExecuteReader(selectQuery, cmd =>
        {
            cmd.Parameters.AddWithValue("@Id", id);
            cmd.Parameters.AddWithValue("@UserId", _currentUser.Id); // Only the owner can edit
        }))
        {
            if (reader.Read())
            {
                existingAlley = new BowlingAlleys
                {
                    Id = reader.GetInt32(reader.GetOrdinal("Id")),
                    Name = reader.GetString(reader.GetOrdinal("Name")),
                    Location = reader.GetString(reader.GetOrdinal("Location")),
                    Comments = reader.GetString(reader.GetOrdinal("Review")),
                    Image = reader.GetString(reader.GetOrdinal("Image")),
                    UserId = reader.GetInt32(reader.GetOrdinal("UserId"))
                };
            }
        }

        if (existingAlley == null)
        {
            Console.WriteLine("Bowling alley not found or you do not have permission to edit.");
            return;
        }

        // Step 2: Prompt user to edit fields (or handle updates programmatically)
        Console.Write("Enter new name (current: {0}): ", existingAlley.Name);
        string newName = Console.ReadLine();
        existingAlley.Name = !string.IsNullOrEmpty(newName) ? newName : existingAlley.Name;

        Console.Write("Enter new location (current: {0}): ", existingAlley.Location);
        string newLocation = Console.ReadLine();
        existingAlley.Location = !string.IsNullOrEmpty(newLocation) ? newLocation : existingAlley.Location;

        // Step 3: Update the bowling alley in the database
        string updateQuery = @"
        UPDATE BowlingAlleys 
        SET Name = @Name, Location = @Location, Image = @Image, Comments = @Review
        WHERE Id = @Id AND UserId = @UserId";

        ExecuteNonQuery(updateQuery, cmd =>
        {
            cmd.Parameters.AddWithValue("@Id", existingAlley.Id);
            cmd.Parameters.AddWithValue("@UserId", _currentUser.Id);
            cmd.Parameters.AddWithValue("@Name", existingAlley.Name);
            cmd.Parameters.AddWithValue("@Location", existingAlley.Location);
            cmd.Parameters.AddWithValue("@Image", existingAlley.Location);
            cmd.Parameters.AddWithValue("@Review", existingAlley.Location);
        });

        Console.WriteLine("Bowling alley updated successfully.");
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

    public List<BowlingAlleys> ViewAllBowlingAlleys()
    {
        List<BowlingAlleys> alleys = new List<BowlingAlleys>();

        string query = "SELECT * FROM BowlingAlleys";
        using (var reader = ExecuteReader(query, cmd => { }))
        {
            while (reader.Read())
            {
                BowlingAlleys alley = new BowlingAlleys
                {
                    Id = reader.GetInt32(reader.GetOrdinal("Id")),
                    Name = reader.GetString(reader.GetOrdinal("Name")),
                    Location = reader.GetString(reader.GetOrdinal("Location")),
                    Comments = reader.GetString(reader.GetOrdinal("Review")),
                    Image = reader.GetString(reader.GetOrdinal("Image")),
                    UserId = reader.GetInt32(reader.GetOrdinal("UserId"))
                };
                alleys.Add(alley);
            }
        }
        return alleys;
    }

}
