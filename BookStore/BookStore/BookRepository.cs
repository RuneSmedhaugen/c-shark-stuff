using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace BookStore
{
    internal class BookRepository
    {
        private readonly string _connectionString;


        public BookRepository(string connectionstring)
        {
            _connectionString = connectionstring;
        }

        public void AddBook(string title, string author, int publishedYear, string genre, int bookID)
        {
            using var connection = new SqlConnection(_connectionString);

            var command =
                new SqlCommand(
                    "INSERT INTO Books (Title, Author, publishedYear, Genre, BookID) VALUES (@Title, @Author, @PublishedYear, @Genre, @BookID)",
                    connection);

            command.Parameters.AddWithValue("@Title", title);
            command.Parameters.AddWithValue("@Author", author);
            command.Parameters.AddWithValue("@PublishedYear", publishedYear);
            command.Parameters.AddWithValue("@Genre", genre);
            command.Parameters.AddWithValue("@BookID", bookID);

            connection.Open();
            command.ExecuteNonQuery();
        }

        public void ShowAllBooks()
        {
            using var connection = new SqlConnection(_connectionString);
            var query = "SELECT BookID, Title, Author, PublishedYear, Genre FROM Books";
            var command = new SqlCommand(query, connection);

            connection.Open();
            using var reader = command.ExecuteReader();

            while (reader.Read())
            {
                Console.WriteLine($@"ID: {reader["BookID"]}, 
Title: {reader["Title"]}, 
Author: {reader["Author"]}, 
Published Year: {reader["PublishedYear"]}, 
Genre: {reader["Genre"]}");

            }

        }

        public void TestConnection()
        {
            try
            {
                using var connection = new SqlConnection(_connectionString);
                connection.Open();
                Console.WriteLine("Connection successful!");
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"SQL Exception: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"General Exception: {ex.Message}");
            }
        }
    }
}
