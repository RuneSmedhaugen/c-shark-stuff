using RollRadar.Models;
using System;

public class BowlingBallService : BaseService
{
    private readonly Users _currentUser;

    public BowlingBallService(string connectionString, Users currentUser) : base(connectionString)
    {
        _currentUser = currentUser;
    }

    public void AddBowlingBall(int userId)
    {
        Console.Write("Enter ball name: ");
        string name = Console.ReadLine();

        Console.Write("Enter ball brand: ");
        string brand = Console.ReadLine();

        Console.Write("Enter ball cost: ");
        decimal cost = decimal.Parse(Console.ReadLine());

        Console.Write("Enter surface material: ");
        string surface = Console.ReadLine();

        Console.Write("Enter hook potential (0-100): ");
        int hookPotential = int.Parse(Console.ReadLine());

        Console.Write("Enter ball type: ");
        string type = Console.ReadLine();

        Console.Write("Enter an image URL (optional): ");
        string image = Console.ReadLine();

        Console.Write("Enter any comments (optional): ");
        string comments = Console.ReadLine();

        string query = "INSERT INTO BowlingBalls (Name, Brand, Cost, Surface, HookPotential, Type, Image, Comments, UserId) " +
                       "VALUES (@Name, @Brand, @Cost, @Surface, @HookPotential, @Type, @Image, @Comments, @UserId)";
        ExecuteNonQuery(query, (cmd) =>
        {
            cmd.Parameters.AddWithValue("@Name", name);
            cmd.Parameters.AddWithValue("@Brand", brand);
            cmd.Parameters.AddWithValue("@Cost", cost);
            cmd.Parameters.AddWithValue("@Surface", surface);
            cmd.Parameters.AddWithValue("@HookPotential", hookPotential);
            cmd.Parameters.AddWithValue("@Type", type);
            cmd.Parameters.AddWithValue("@Image", image);
            cmd.Parameters.AddWithValue("@Comments", comments);
            cmd.Parameters.AddWithValue("@UserId", _currentUser.Id);
        });

        Console.WriteLine("Bowling ball added successfully.");
    }

    public void EditBowlingBall(int id)
    {
        // Query to get the existing bowling ball by ID
        string selectQuery = "SELECT * FROM BowlingBalls WHERE Id = @Id AND UserId = @UserId";

        BowlingBalls existingBall = null;

        // Step 1: Retrieve the existing bowling ball
        using (var reader = ExecuteReader(selectQuery, cmd =>
        {
            cmd.Parameters.AddWithValue("@Id", id);
            cmd.Parameters.AddWithValue("@UserId", _currentUser.Id);
        }))
        {
            if (reader.Read())
            {
                existingBall = new BowlingBalls
                {
                    Id = reader.GetInt32(reader.GetOrdinal("Id")),
                    Name = reader.GetString(reader.GetOrdinal("Name")),
                    Brand = reader.GetString(reader.GetOrdinal("Brand")),
                    Cost = reader.GetDecimal(reader.GetOrdinal("Cost")),
                    Surface = reader.GetString(reader.GetOrdinal("Surface")),
                    HookPotential = reader.GetInt32(reader.GetOrdinal("HookPotential")),
                    Type = reader.GetString(reader.GetOrdinal("Type"))
                };
            }
        }

        if (existingBall == null)
        {
            Console.WriteLine("Bowling ball not found or you do not have permission to edit.");
            return;
        }

        // Step 2: Prompt user to edit fields (or handle updates programmatically)
        Console.Write("Enter new name (current: {0}): ", existingBall.Name);
        string newName = Console.ReadLine();
        existingBall.Name = !string.IsNullOrEmpty(newName) ? newName : existingBall.Name;

        Console.Write("Enter new brand (current: {0}): ", existingBall.Brand);
        string newBrand = Console.ReadLine();
        existingBall.Brand = !string.IsNullOrEmpty(newBrand) ? newBrand : existingBall.Brand;

        Console.Write("Enter new cost (current: {0}): ", existingBall.Cost);
        decimal newCost;
        if (decimal.TryParse(Console.ReadLine(), out newCost))
        {
            existingBall.Cost = newCost;
        }

        Console.Write("Enter new surface (current: {0}): ", existingBall.Surface);
        string newSurface = Console.ReadLine();
        existingBall.Surface = !string.IsNullOrEmpty(newSurface) ? newSurface : existingBall.Surface;

        Console.Write("Enter new hook potential (current: {0}): ", existingBall.HookPotential);
        int newHookPotential;
        if (int.TryParse(Console.ReadLine(), out newHookPotential))
        {
            existingBall.HookPotential = newHookPotential;
        }

        Console.Write("Enter new type (current: {0}): ", existingBall.Type);
        string newType = Console.ReadLine();
        existingBall.Type = !string.IsNullOrEmpty(newType) ? newType : existingBall.Type;

        // Step 3: Update the bowling ball in the database
        string updateQuery = @"
        UPDATE BowlingBalls 
        SET Name = @Name, Brand = @Brand, Cost = @Cost, Surface = @Surface, 
            HookPotential = @HookPotential, Type = @Type
        WHERE Id = @Id AND UserId = @UserId";

        ExecuteNonQuery(updateQuery, cmd =>
        {
            cmd.Parameters.AddWithValue("@Id", existingBall.Id);
            cmd.Parameters.AddWithValue("@UserId", _currentUser.Id);
            cmd.Parameters.AddWithValue("@Name", existingBall.Name);
            cmd.Parameters.AddWithValue("@Brand", existingBall.Brand);
            cmd.Parameters.AddWithValue("@Cost", existingBall.Cost);
            cmd.Parameters.AddWithValue("@Surface", existingBall.Surface);
            cmd.Parameters.AddWithValue("@HookPotential", existingBall.HookPotential);
            cmd.Parameters.AddWithValue("@Type", existingBall.Type);
        });

        Console.WriteLine("Bowling ball updated successfully.");
    }


    public void DeleteBowlingBall(int id)
    {
        string query = "DELETE FROM BowlingBalls WHERE Id = @Id AND UserId = @UserId";
        
        ExecuteNonQuery(query, (cmd) =>
        {
            cmd.Parameters.AddWithValue("@Id", id);
            cmd.Parameters.AddWithValue("@UserId", _currentUser.Id);
        });

        Console.WriteLine("Bowling ball deleted successfully.");
    }

    public List<BowlingBalls> ViewAllBowlingBalls()
    {
        List<BowlingBalls> bowlingBalls = new List<BowlingBalls>();

        string query = @"
    SELECT b.*, u.Name AS UserName 
    FROM BowlingBalls b
    JOIN Users u ON b.UserId = u.Id";

        using (var reader = ExecuteReader(query, cmd => { }))
        {
            while (reader.Read())
            {
                BowlingBalls ball = new BowlingBalls
                {
                    Id = reader.GetInt32(reader.GetOrdinal("Id")),
                    UserId = reader.GetInt32(reader.GetOrdinal("UserId")),
                    Name = reader.GetString(reader.GetOrdinal("Name")),
                    Brand = reader.GetString(reader.GetOrdinal("Brand")),
                    Cost = reader.GetDecimal(reader.GetOrdinal("Cost")),
                    Surface = reader.GetString(reader.GetOrdinal("Surface")),
                    HookPotential = reader.GetInt32(reader.GetOrdinal("HookPotential")),
                    Type = reader.GetString(reader.GetOrdinal("Type")),
                };

                bowlingBalls.Add(ball);
            }
        }

        return bowlingBalls;
    }

}
