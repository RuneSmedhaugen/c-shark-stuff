using Bossfight;

GameCharacter player = new GameCharacter(100, 20, 40);
Boss boss = new Boss(400, 10);
Game game = new Game(boss, player);

game.PlayingGame();
