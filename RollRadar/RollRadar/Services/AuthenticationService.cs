using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using RollRadar.Models;

namespace RollRadar.Services
{
    public class AuthenticationService
    {
        private readonly string _connectionString;
        

        public AuthenticationService(string connectionString)
        {
            _connectionString = connectionString;
        }

        public int? GetLoggedInUserId(string email)
        {
            string query = "SELECT Id FROM Users WHERE Email = @Email";
            var parameters = new Dictionary<string, object?>
            {
                { "@Email", email }
            };

            return GetSingle(query, parameters, r => (int?)r["Id"]);
        }

        public int ExecuteNonQuery(string query, Dictionary<string, object?> parameters)
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

                    return command.ExecuteNonQuery();
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

        public int? Login(string email, string password)
        {
            int? currentUserId;
            string query = "SELECT PasswordHash FROM Users WHERE Email = @Email";
            var parameters = new Dictionary<string, object?>
            {
                { "@Email", email }
            };

            var result = GetSingle(query, parameters, r => new { PasswordHash = r["PasswordHash"].ToString(), UserId = (int?)r["Id"] });
            if (result == null)
            {
                Console.WriteLine("User not found.");
                return null;
            }

            if (VerifyPassword(password, result.PasswordHash))
            {
                Console.WriteLine("Login successful.");
                return result.UserId;
            }

            Console.WriteLine("Invalid password.");
            return null;
        }


        public bool VerifyPassword(string inputPassword, string storedHash)
        {
            string inputHash = HashPassword(inputPassword);
            return inputHash == storedHash;
        }

        public void Register(string name, string email, string password, int? age, string hand, string image, string about)
        {
            
            string passwordHash = HashPassword(password);

            string query = "INSERT INTO Users (Email, PasswordHash, Name, Age, Hand, ProfilePic, About) VALUES (@Email, @PasswordHash, @Name, @Age, @Hand, @ProfilePic, @About)";
            var parameters = new Dictionary<string, object?>
            {
                { "@Email", email },
                { "@PasswordHash", passwordHash },
                { "@Name", name },
                { "@Age", age },
                { "@Hand", hand },
                { "@ProfilePic", image },
                { "@About", about }
            };

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                ExecuteNonQuery(query, parameters);
            }

            Console.WriteLine("User registered successfully.");
        }

        private string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
               
                byte[] passwordBytes = Encoding.UTF8.GetBytes(password);

                
                byte[] hashBytes = sha256.ComputeHash(passwordBytes);

                
                StringBuilder sb = new StringBuilder();
                foreach (byte b in hashBytes)
                {
                    sb.Append(b.ToString("x2"));
                }

                return sb.ToString();
            }
        }
    }
}
