using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace BookStore
{
    internal class BookRepository
    {
        private readonly string _connectionstring;

        public BookRepository(string connectionstring)
        {
            _connectionstring = connectionstring;
        }

        public void AddBook(string title, string author, int publishedlDate)
        {
            using var connection = new SqlConnection(_connectionstring);

            var command =
                new SqlConnection(
                    "INSERT INTO Books (Title, Author, publishedDate) VALUES (@Title, @Author, @PublishedDate)",
                    connection);

            command.Parameters.AddWithValue("@Title", title);
            command.Parameters.AddWithValue("@Author", author);
            command.Parameters.AddWithValue("@PublishedDate", publishedDate);

            connection.Open();
            command.ExecutenonQuery();
        }
    }
}
