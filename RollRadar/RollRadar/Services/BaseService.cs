using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;

namespace RollRadar.Services
{
    public abstract class BaseService<T>
    {
        private readonly string _connectionString;
        private readonly AuthenticationService _authService;

        protected BaseService(string connectionString, AuthenticationService authService)
        {
            _connectionString = connectionString;
            _authService = authService;
        }


        protected virtual int GetCurrentUserId(string loggedInUserEmail)
        {
            int? userId = _authService.GetLoggedInUserId(loggedInUserEmail);
            if (userId.HasValue)
            {
                return userId.Value;
            }
            throw new InvalidOperationException("No user is currently logged in.");
        }

        public void ManageRecord(int? id = null, string operationType = "Add", Dictionary<string, string>? columnPrompts = null, int? currentUserId = null)
        {
            string query = "";
            var parameters = new Dictionary<string, object?>();

            
            if (operationType == "ViewAll")
            {
                query = $"SELECT * FROM {typeof(T).Name}";

                Print(query, reader =>
                {
                    string creatorQuery = "SELECT Username FROM Users WHERE UserId = @UserId";
                    var creatorParams = new Dictionary<string, object?>
            {
                { "@UserId", reader["UserId"] }
            };

                    string creatorName = GetSingle(creatorQuery, creatorParams, r => r["Name"].ToString());

                    Console.WriteLine($"Record: {reader["Name"]}, created by: {creatorName}");
                });

                return;
            }

            // Add/Edit/Delete stuff
            if (operationType == "Edit" || operationType == "Delete")
            {
                
                if (currentUserId == null)
                {
                    Console.WriteLine("User ID is required for editing or deleting.");
                    return;
                }

                // her filtrerer vi for å få bare records fra logga inn bruker
                query = $"SELECT * FROM {typeof(T).Name} WHERE UserId = @UserId";
                parameters.Add("@UserId", currentUserId);

                var userRecords = new List<T>();

                
                Print(query, reader =>
                {
                    T record = MapFromReader(reader);
                    userRecords.Add(record);

                    Console.WriteLine($"{userRecords.Count}. {reader["Name"]}");
                });

                if (userRecords.Count == 0)
                {
                    Console.WriteLine("No records found for the current user.");
                    return;
                }

                Console.WriteLine($"Choose a record to {operationType}:");
                int selectedIndex = GetIntRange("Enter the record number:", 1, userRecords.Count) - 1;

                id = (int)typeof(T).GetProperty("ID").GetValue(userRecords[selectedIndex]);

                if (operationType == "Edit")
                {
                    // edit
                    foreach (var column in columnPrompts.Keys)
                    {
                        Console.WriteLine($"Enter new {columnPrompts[column]} or press Enter to keep current:");
                        string newValue = Console.ReadLine();
                        if (!string.IsNullOrEmpty(newValue))
                        {
                            parameters.Add($"@{column}", newValue);
                        }
                    }

                    query = $"UPDATE {typeof(T).Name} SET {string.Join(", ", parameters.Keys.Select(k => k.TrimStart('@') + " = @" + k))} WHERE ID = @ID";
                    parameters.Add("@ID", id);
                }
                else if (operationType == "Delete")
                {
                    // delete
                    Console.WriteLine("Are you sure you want to delete this record? (yes/no)");
                    string confirmation = Console.ReadLine();
                    if (confirmation.ToLower() == "yes")
                    {
                        query = $"DELETE FROM {typeof(T).Name} WHERE ID = @ID";
                        parameters.Add("@ID", id);
                    }
                    else
                    {
                        Console.WriteLine("Deletion canceled.");
                        return;
                    }
                }
            }

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                ExecuteNonQuery(query, parameters, connection);
            }

            Console.WriteLine($"{operationType} operation completed successfully.");
        }

        public void Print(string query, Action<SqlDataReader> printAction)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            printAction(reader);
                        }
                    }
                }
            }
        }

        public T? GetSingle<T>(string query, Dictionary<string, object?> parameters, Func<SqlDataReader, T> map)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    foreach (var param in parameters)
                    {
                        command.Parameters.AddWithValue(param.Key, param.Value ?? DBNull.Value);
                    }

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return map(reader);
                        }
                    }
                }
            }

            
            return default(T);
        }

        protected string GetValidInput(string prompt)
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

        protected decimal? GetOptionalDecimal(string prompt)
        {
            while (true)
            {
                Console.WriteLine(prompt);
                var input = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(input)) return null;
                if (decimal.TryParse(input, out decimal result)) return result;
                Console.WriteLine("Please provide a valid number.");
            }
        }

        protected int GetIntRange(string prompt, int min, int max)
        {
            int value;
            while (true)
            {
                Console.WriteLine(prompt);
                var input = Console.ReadLine();
                if (int.TryParse(input, out value) && value >= min && value <= max)
                {
                    return value;
                }
                Console.WriteLine($"Please write a number between {min} and {max}.");
            }
        }

        public static void ExecuteNonQuery(string query, Dictionary<string, object?> parameters, SqlConnection connection)
        {
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                foreach (var param in parameters)
                {
                    command.Parameters.AddWithValue(param.Key, param.Value ?? DBNull.Value);
                }

                command.ExecuteNonQuery();
            }
        }

        protected abstract T MapFromReader(SqlDataReader reader);

        public void GetAll(string tableName)
        {
            string query = $"SELECT * FROM {tableName}";

            Print(query, reader =>
            {
                string creatorQuery = "SELECT Name FROM Users WHERE UserId = @UserId";
                var creatorParams = new Dictionary<string, object?>
                {
                    { "@UserId", reader["UserId"] }
                };

                string creatorName = GetSingle(creatorQuery, creatorParams, r => r["Name"].ToString());

                Console.WriteLine($"Record: {reader["Name"]}, created by: {creatorName}");
            });
        }
    }
}
