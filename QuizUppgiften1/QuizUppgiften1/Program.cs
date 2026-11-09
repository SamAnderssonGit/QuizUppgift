while (true)
{
    Console.WriteLine("=== Quiz Battle ===");
    Console.WriteLine("1. Spela111");
    Console.WriteLine("2. Topplista");
    Console.WriteLine("3. Avsluta");
    Console.Write("Val: ");

    int MyChoice = int.Parse(Console.ReadLine());

    if (MyChoice == 1)
    {
        // LÄGG IN SEN
    }

    else if (MyChoice == 2)
    {
        // LÄGG IN SEN
    }
    else if (MyChoice == 3)
    {
        break;
    }
    else
    {
        Console.WriteLine("Ogiltigt val");
        return;
    }
}