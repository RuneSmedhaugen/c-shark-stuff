using System;
using RollRadar;

//Users.Hand kan bare v�re Lefty eller Righty, m� finne ut hvor og hvordan jeg reverserer det
//GUI
//Fikse Add metod og Edit metoder
//Edit profil seksjon
class Program
{
    public static void Main(string[] args)
    {
        string connectionString = "Server=localhost\\SQLEXPRESS;Database=BowlingDB;Integrated Security=True;";
        var app = new Run(connectionString);
        app.Start();
    }
}