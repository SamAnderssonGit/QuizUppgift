using QuizUppgiften1;

while (true)
{
    HighScoreManager highScoreManager = new HighScoreManager();


    Console.WriteLine("=== Quiz Battle ===");
    Console.WriteLine("1. Spela");
    Console.WriteLine("2. Poängtavla ");
    Console.WriteLine("3. Avsluta");
    Console.Write("Val: ");

    int MyChoice = int.Parse(Console.ReadLine());

    if (MyChoice == 1)
    {
        
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
    else
    {
        Console.WriteLine("Felaktig inmatning, välj 1-3");
        return;
    }
}