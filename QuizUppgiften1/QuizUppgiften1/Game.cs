using QuizUppgiften1.Managers;
using QuizUppgiften1.Models;
using System.Linq;

namespace QuizUppgiften1
{
    public class Game
    {
        public List<Player> Players { get; set; }
        public RoundManager RoundManager { get; set; }


        public void StartGame()
        {
            int playerCount = GetPlayerCount();

            List<Player> players = CreatePlayers(playerCount);

            int totalRounds = GetTotalRounds();

            RoundManager roundManager = new RoundManager(totalRounds);

            PlayRounds();
        }




        public List<Player> CreatePlayers(int playerCount)
        {
            List<Player> players = new List<Player>();

            for (int i = 0; i < playerCount; i++)
            {
                Console.Write($"Ange namn för spelare {i + 1}: ");
                string name = Console.ReadLine();

                while (name == null || name == "" ||
                players.Any(p => p.Name.ToLower() == name.ToLower()))
                {
                    Console.WriteLine("Namnet är tomt eller används redan. Försök igen.");
                    Console.Write($"Ange namn för spelare {i + 1}: ");
                    name = Console.ReadLine();
                }

                Player player = new Player(name);
                players.Add(player);
            }

            return players;
        }
        public void selectedCategory()
        {
            Console.WriteLine("Välj kategori:");
            Console.WriteLine("1. Geografi");
            Console.WriteLine("2. Historia");
            Console.WriteLine("3. Sport");
            Console.WriteLine("4. Slumpmässig kategori");

            //if sats sen
        }
        public int GetPlayerCount()
        {
            int playerCount = 0;

            Console.Write("Ange antal spelare (2-4): ");

            while (!int.TryParse(Console.ReadLine(), out playerCount)
                   || playerCount < 2
                   || playerCount > 4)
            {
                Console.Write("Felaktig inmatning. Ange siffra mellan 2-4: ");
            }

            return playerCount;
        }

        public int GetTotalRounds()
        {
            int totalRounds = 0;

            Console.Write("Ange antal rundor (1-10): ");

            while (!int.TryParse(Console.ReadLine(), out totalRounds) ||
                   totalRounds < 1 || totalRounds > 10)
            {
                Console.Write("Ogiltigt val. Ange antal rundor (1-10): ");
            }

            return totalRounds;
        }

        public void PlayRounds()
        {
            while (RoundManager.HasMoreRounds())
            {
                Console.WriteLine(RoundManager.GetRoundInfo());

                Player currentPlayer = Players[RoundManager.CurrentPlayerIndex];

                Console.WriteLine($"Det är {currentPlayer.Name}s tur!");

                RoundManager.NextPlayer(Players.Count);
            }
        }


    }
}


/*




    


        public void PlayGame();


        public void ShowResult();


        public bool Winstreak(List????);


     (playerBlackjack)

    decimal bonus = decimal.Floor(bet * 1.5m); //Floor gör avrundning till heltal
    player poäng ska bli (score + bonus);
*/