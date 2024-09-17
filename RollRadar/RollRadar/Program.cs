using System;
using System.Data.SqlClient;
using RollRadar;
using RollRadar.Services;

//Oppdatere info
//hjelpemetode, korte ned kode
//endre navn på arveklassen
//UI

class Program
{
    static void Main()
    {
        string connectionString = @"Server=.\SQLEXPRESS;Database=BowlingDB;Trusted_Connection=True;";
        Run run = new Run(connectionString);

        run.RunAll();
    }
}