using RollRadar.Models;
using RollRadar.Services;

namespace RollRadar
{
    public class Run
    {
        private readonly string _connectionString;
        private BowlingBallService _bowlingBallService;
        private UserService _userService;
        private BowlingAlleyService _bowlingAlleyService;
        private ScoreService _scoreService;
        private AuthenticationService _authenticationService;
        private User? _currentUser;

        public Run(string connectionString)
        {
            _connectionString = connectionString;
            _bowlingBallService = new BowlingBallService(_connectionString);
            _userService = new UserService(_connectionString);
            _bowlingAlleyService = new BowlingAlleyService(_connectionString);
            _scoreService = new ScoreService(_connectionString);
            _authenticationService = new AuthenticationService(_connectionString);
        }

        public void RunAll()
        {
            MainMenu();
        }

        private void MainMenu()
        {
            Console.WriteLine("Welcome to RollRadar! Please log in or create an account.");

            
            HandleUserLogin();

            
            while (true)
            {
                Console.WriteLine($@"Here is your menu:
1: Bowling Ball Menu
2: Score Menu
3: Bowling Alley Menu
4: User Menu
5: Exit App
");

                var mainMenuAnswer = Console.ReadLine();

                switch (mainMenuAnswer)
                {
                    case "1":
                        BowlingBallMenu();
                        break;
                    case "2":
                        ScoreMenu();
                        break;
                    case "3":
                        BowlingAlleyMenu();
                        break;
                    case "4":
                        UserMenu();
                        break;
                    case "5":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Please select an option between 1 and 5.");
                        break;
                }
            }
        }

        private void HandleUserLogin()
        {
            while (_currentUser == null)
            {
                Console.WriteLine("1: Log in");
                Console.WriteLine("2: Create a new account");
                var loginOption = Console.ReadLine();

                switch (loginOption)
                {
                    case "1":
                        _currentUser = _authenticationService.Login(email, password);
                        break;
                    case "2":
                         _authenticationService.Register();
                        break;
                    default:
                        Console.WriteLine("Please choose either 1 or 2.");
                        break;
                }
            }

            Console.WriteLine($"Welcome, {_currentUser.Name}!");
        }

        private void BowlingBallMenu()
        {
            while (true)
            {
                Console.WriteLine($@"Bowling Ball Menu:
1: View All Bowling Balls
2: Edit Your Bowling Ball
3: Delete Your Bowling Ball
4: Back to Main Menu
");

                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        break;
                    case "2":
                        break;
                    case "3":
                        break;
                    case "4":
                        return; 
                    default:
                        Console.WriteLine("Please choose an option between 1 and 4.");
                        break;
                }
            }
        }

        private void ScoreMenu()
        {
            while (true)
            {
                Console.WriteLine($@"Score Menu:
1: View All Scores
2: Edit Your Score
3: Delete Your Score
4: Back to Main Menu
");

                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        
                        break;
                    case "2":
                        break;
                    case "3":
                        break;
                    case "4":
                        return;
                    default:
                        Console.WriteLine("Please choose an option between 1 and 4.");
                        break;
                }
            }
        }

        private void BowlingAlleyMenu()
        {
            while (true)
            {
                Console.WriteLine($@"Bowling Alley Menu:
1: View All Bowling Alleys
2: Edit Your Bowling Alley
3: Delete Your Bowling Alley
4: Back to Main Menu
");

                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        break;
                    case "2":
                        break;
                    case "3":
                        break;
                    case "4":
                        return;
                    default:
                        Console.WriteLine("Please choose an option between 1 and 4.");
                        break;
                }
            }
        }

        private void UserMenu()
        {
            Console.WriteLine("User Menu: Under construction.");
        }
    }
}
