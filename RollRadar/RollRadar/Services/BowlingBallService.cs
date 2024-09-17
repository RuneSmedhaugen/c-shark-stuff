using System.Data.SqlClient;
using RollRadar.Models;

namespace RollRadar.Services
{
    public abstract class BowlingBallService : BaseService<BowlingBall>
    {
        private readonly string _connectionString;

        public BowlingBallService(string connectionString) : base(connectionString)
        {
            _connectionString = connectionString;
        }

        public void AddBowlingBall(BowlingBall ball)
        {
            string query = @"INSERT INTO BowlingBalls (Brand, Cost, Surface, HookPotential, Type, Name, Image, Comments)
                         VALUES (@Brand, @Cost, @Surface, @HookPotential, @Type, @Name, @Image, @Comments)";

            var parameters = new Dictionary<string, object?>
            {
                { "@Brand", ball.Brand },
                { "@Cost", ball.Cost },
                { "@Surface", ball.Surface },
                { "@HookPotential", ball.HookPotential },
                { "@Type", ball.Type },
                { "@Name", ball.Name },
                { "@Image", ball.Image },
                { "@Comments", ball.Comments }
            };

            Add(query, parameters);
        }

        public void PrintBowlingBalls()
        {
            string query = "SELECT * FROM BowlingBalls";

            Print(query, reader =>
            {
                Console.WriteLine($"Brand: {reader["Brand"]}, Name: {reader["Name"]}, Cost: {reader["Cost"]}, " +
                                  $"Surface: {reader["Surface"]}, HookPotential: {reader["HookPotential"]}, " +
                                  $"Type: {reader["Type"]}, Image: {reader["Image"]}, Comments: {reader["Comments"]}");
            });
        }

        public void EditBowlingBall(int id)
        {
            string query = "SELECT * FROM BowlingBalls WHERE ID = @ID";
            var parameters = new Dictionary<string, object?>
            {
                { "@ID", id }
            };

            BowlingBall ball = GetSingle(query, parameters, reader =>
            {
                return new BowlingBall(
                    reader["Brand"].ToString(),
                    reader.IsDBNull(reader.GetOrdinal("Cost")) ? null : reader.GetDecimal(reader.GetOrdinal("Cost")),
                    reader["Surface"].ToString(),
                    reader.GetInt32(reader.GetOrdinal("HookPotential")),
                    reader["Type"].ToString(),
                    reader["Name"].ToString(),
                    reader["Image"].ToString(),
                    reader["Comments"].ToString()
                );
            });

            if (ball == null)
            {
                Console.WriteLine($"No record found with ID {id}");
                return;
            }


        }
    }
}
