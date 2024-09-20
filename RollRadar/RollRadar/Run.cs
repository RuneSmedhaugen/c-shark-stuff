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
            _authenticationService = new AuthenticationService(_connectionString);
            _bowlingBallService = new BowlingBallService(_connectionString, _authenticationService);
            _userService = new UserService(_connectionString, _authenticationService);
            _bowlingAlleyService = new BowlingAlleyService(_connectionString, _authenticationService);
            _scoreService = new ScoreService(_connectionString, _authenticationService);
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
                        Console.Write("Enter email: ");
                        var email = Console.ReadLine();
                        Console.Write("Enter password: ");
                        var password = Console.ReadLine();

                        if (_authenticationService.Login(email, password))
                        {
                            _currentUser = _userService.GetUserByEmail(email);
                            Console.WriteLine($"Welcome, {_currentUser.Name}!");
                        }
                        else
                        {
                            Console.WriteLine("Invalid email or password. Please try again.");
                        }
                        break;

                    case "2":
                        Console.Write("Enter name: ");
                        var name = Console.ReadLine();

                        Console.Write("Enter email: ");
                        var newEmail = Console.ReadLine();

                        Console.Write("Enter password: ");
                        var newPassword = Console.ReadLine();

                        Console.Write("Enter age (optional): ");
                        var ageInput = Console.ReadLine();
                        int? age = string.IsNullOrWhiteSpace(ageInput) ? (int?)null : int.Parse(ageInput);

                        Console.Write("Enter hand (optional): ");
                        var hand = Console.ReadLine();

                        Console.Write("Enter profile picture URL (optional): ");
                        var image = Console.ReadLine();

                        Console.Write("Enter about (optional): ");
                        var about = Console.ReadLine();

                        _authenticationService.Register(name, newEmail, newPassword, age, hand, image, about);
                        Console.WriteLine("Account successfully created!");
                        break;

                }
            }
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
                        _bowlingBallService.GetAllBowlingBalls();
                        break;
                    case "2":
                        // Get the ID of the bowling ball to edit
                        Console.Write("Enter the ID of the bowling ball you want to edit: ");
                        if (int.TryParse(Console.ReadLine(), out int bowlingBallId))
                        {
                            // Pass the bowling ball ID and the current user ID
                            _bowlingBallService.EditBowlingBall(bowlingBallId, _currentUser.Id);
                        }
                        else
                        {
                            Console.WriteLine("Invalid ID. Please enter a numeric value.");
                        }
                        break;
                    case "3":
                        Console.Write("Enter the ID of the bowling ball you want to delete: ");
                        if (int.TryParse(Console.ReadLine(), out int deletebowlingBallId))
                        {
                            _bowlingBallService.DeleteBowlingBall(deletebowlingBallId, _currentUser.Id, _currentUser.Email);
                        }
                        else
                        {
                            Console.WriteLine("Invalid ID. Please enter a numeric value.");
                        }
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
                        _scoreService.GetAllScores();
                        break;
                    case "2":
                        _scoreService.EditScore(_currentUser.Id);
                        break;
                    case "3":
                        _scoreService.DeleteScore(_currentUser.Id);
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
                        _bowlingAlleyService.GetAllBowlingAlleys();
                        break;
                    case "2":
                        _bowlingAlleyService.EditBowlingAlley(_currentUser.Id);
                        break;
                    case "3":
                        _bowlingAlleyService.DeleteBowlingAlley(_currentUser.Id);
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
