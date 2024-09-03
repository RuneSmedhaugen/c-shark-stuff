using System;
using System.Data;
using BookStore;
using Microsoft.Data.SqlClient;

var connectionString = "Server=BEAST\\SQLEXPRESS;Database=AquariumDB;Trusted_Connection=True;";

BookRepository library = new BookRepository(connectionString);

library.TestConnection();