using RollRadar.Models;
using RollRadar.Services;

namespace RollRadar
{
    public class Run
    {
        private BowlingBallService Bowlingball = new BowlingBallService(connectionString);

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
                    case "1": Bowlingball.c
                }
            }
        }
    }
}
