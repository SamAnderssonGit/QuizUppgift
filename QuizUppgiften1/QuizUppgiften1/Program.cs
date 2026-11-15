using QuizUppgiften1;
Game game = new Game();

while (true)
{
    HighScoreManager highScoreManager = new HighScoreManager();

    Console.WriteLine("===== Quiz Battle =====");
    Console.WriteLine("1. Spela");
    Console.WriteLine("2. Poängtavla");
    Console.WriteLine("3. Avsluta");
    Console.Write("Ditt Val: ");

    int MyChoice;

    if (!int.TryParse(Console.ReadLine(), out MyChoice) ||
        MyChoice < 1 || MyChoice > 3)
    {
        Console.WriteLine("Felaktig inmatning, välj 1-3");
        continue;
    }

    if (MyChoice == 1)
    {
        game.StartGame();
    }
    else if (MyChoice == 2)
    {
        highScoreManager.ShowScoreboard();
    }
    else if (MyChoice == 3)
    {
        Console.WriteLine("Avslutar programmet...");
        break;
    }
}