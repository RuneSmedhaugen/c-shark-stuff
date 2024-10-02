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
        // Update ball details based on user input, similar to AddBowlingBall
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

    public void ViewAllBowlingBalls()
    {
        string query = "SELECT * FROM BowlingBalls WHERE UserId = @UserId";
        using (var reader = ExecuteReader(query, (cmd) => cmd.Parameters.AddWithValue("@UserId", _currentUser.Id)))
        {
            while (reader.Read())
            {
                int id = reader.GetInt32(reader.GetOrdinal("Id"));
                string name = reader.GetString(reader.GetOrdinal("Name"));
                string brand = reader.GetString(reader.GetOrdinal("Brand"));
                decimal cost = reader.GetDecimal(reader.GetOrdinal("Cost"));
                string surface = reader.GetString(reader.GetOrdinal("Surface"));
                int hookPotential = reader.GetInt32(reader.GetOrdinal("HookPotential"));
                string type = reader.GetString(reader.GetOrdinal("Type"));

                Console.WriteLine($"ID: {id}, Name: {name}, Brand: {brand}, Cost: {cost}, Surface: {surface}, Hook Potential: {hookPotential}, Type: {type}");
            }
        }
    }
}
