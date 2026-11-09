while (true)
{
    Console.WriteLine("=== Quiz Battle ===");
    Console.WriteLine("1. Spela");
    Console.WriteLine("2. Topplista");
    Console.WriteLine("3. Avsluta");
    Console.Write("Val: ");

    int choice = int.Parse(Console.ReadLine());

    if (choice == 1)
    {
        // LÄGG IN SEN
    }

    else if (choice == 2)
    {
        // LÄGG IN SEN
    }
    else if (choice == 3)
    {
        break;
    }
    else
    {
        Console.WriteLine("Ogiltigt val");
        return;
    }
}