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

        public Run(string connectionString)
        {
            _connectionString = connectionString;
            Bowlingball = new BowlingBallService(_connectionString);
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
3: Review a bowling alley
4: See all users
5: See all bowling balls
6: See all bowling alley reviews
7: Exit program");

                var mainMenuAnswer = Console.ReadLine();

                switch (mainMenuAnswer)
                {
                    case "2": Bowlingball.CreateBowlingBall();
                        break;

                    case "5": Bowlingball.PrintBalls();
                        break;
                }
            }
        }
    }
}
