using QuizUppgiften1;

while (true)
{
    HighScoreManager highScoreManager = new HighScoreManager();


    Console.WriteLine("=== Quiz Battle ===");
    Console.WriteLine("1. Play Game");
    Console.WriteLine("2. Scoreboard ");
    Console.WriteLine("3. Exit");
    Console.Write("Choice: ");

    int MyChoice = int.Parse(Console.ReadLine());

    if (MyChoice == 1)
    {
        // LÄGG IN SEN
       
    }

    else if (MyChoice == 2)
    {
        highScoreManager.ShowScoreboard();
    }
    else if (MyChoice == 3)
    {
        Console.WriteLine("Exiting program...");
        break;
    }
    else
    {
        Console.WriteLine("Invalid choice");
        return;
    }
}