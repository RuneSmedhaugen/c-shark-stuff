using System.Data.Common;
using System.Runtime.CompilerServices;
using RollRadar.Models;
using RollRadar.Services;

namespace RollRadar
{
    public class Run
    {
        private readonly string _connectionString;
        private BowlingBallService _bowlingball;
        private UserService _user;
        private BowlingAlleyService _bowlingAlley;
        private Scoreservice _series;

        public Run(string connectionString)
        {
            _connectionString = connectionString;
            _bowlingball = new BowlingBallService(_connectionString);
            _user = new UserService(_connectionString);
            _bowlingAlley = new BowlingAlleyService(_connectionString);
            _series = new Scoreservice(_connectionString);
        }


        public void RunAll()
        {
            MainMenu();
        }

        public void MainMenu()
        {
            while (true)
            {
                Console.WriteLine($@"Welcome to RollRadar! Here is your menu:
1: Create user
2: Add a bowling ball
3: Add a series
4: Review a bowling alley
5: See all users
6: See all bowling balls
7: See all series
8: See all bowling alley reviews
9: Exit program");

                var mainMenuAnswer = Console.ReadLine();

                switch (mainMenuAnswer)
                {
                    case "1":
                        _user.CreateUser();
                        break;
                    case "2": _bowlingball.CreateBowlingBall();
                        break;
                    case "3":
                        _series.CreateScore();
                        break;
                    case "4":
                        _bowlingAlley.CreateBowlingAlley();
                        break;
                    case "5":
                        _user.PrintUsers();
                        break;
                    case "6": _bowlingball.PrintBalls();
                        break;
                    case "7":
                        _series.PrintAllScores();
                        break;
                    case "8":
                        _bowlingAlley.PrintAllAlleys();
                        break;
                    case "9":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("1-9, try again");
                        break;
                }
            }
        }
    }
}
