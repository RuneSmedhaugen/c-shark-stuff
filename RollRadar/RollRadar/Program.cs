using System;
using System.Data.SqlClient;
using RollRadar;
using RollRadar.Services;

class Program
{
    
    static void Main()
    {
        Run run = new Run();
        string connectionString = @"Server=.\SQLEXPRESS;Database=BowlingDB;Trusted_Connection=True;";
        UserService userService = new UserService(connectionString);
        run.CreateUser(userService);
    }
}