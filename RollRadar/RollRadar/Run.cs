using System.Data.Common;
using System.Runtime.CompilerServices;
using RollRadar.Models;
using RollRadar.Services;

namespace RollRadar
{
    public class Run
    {
        private readonly string _connectionString;
        private BowlingBallService Bowlingball;
        private UserService user;
        private BowlingAlleyService BowlingAlley;
        private Scoreservice series;

        public Run(string connectionString)
        {
            _connectionString = connectionString;
            Bowlingball = new BowlingBallService(_connectionString);
            user = new UserService(_connectionString);
            BowlingAlley = new BowlingAlleyService(_connectionString);
            series = new Scoreservice(_connectionString);
        }


        public void RunAll()
        {
            mainMenu();
        }

        public void mainMenu()
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
                        user.CreateUser();
                        break;
                    case "2": Bowlingball.CreateBowlingBall();
                        break;
                    case "3":
                        series.CreateScore();
                        break;
                    case "4":
                        BowlingAlley.CreateBowlingAlley();
                        break;
                    case "5":
                        user.PrintUsers();
                        break;
                    case "6": Bowlingball.PrintBalls();
                        break;
                    case "7":
                        series.PrintAllScores();
                        break;
                    case "8":
                        BowlingAlley.PrintAllAlleys();
                        break;
                    case "9":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("1-7 fool, try again");
                        break;
                }
            }
        }
    }
}
