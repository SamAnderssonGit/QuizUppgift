using QuizUppgiften1.Managers;
using QuizUppgiften1.Models;
using System.Linq;

namespace QuizUppgiften1
{
    public class Game
    {
        public List<Player> Players { get; set; }
        public RoundManager RoundManager { get; set; }
        public QuestionManager QuestionManager { get; set; }


        public void StartGame()
        {
            int playerCount = GetPlayerCount();

            Players = CreatePlayers(playerCount);

            QuestionManager = new QuestionManager();
            QuestionManager.LoadQuestions();

            int totalRounds = GetTotalRounds();

            RoundManager = new RoundManager(totalRounds);

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

                List<Question> categoryQuestions = QuestionManager.FilterCategory("Programmering");

                Question question = QuestionManager.PickRandomQuestion(categoryQuestions);

                PlayQuestion(question);

                RoundManager.NextPlayer(Players.Count);
            }
        }


        public void PlayQuestion(Question question)
        {
            Console.WriteLine(question.Text);

            int answer;

            if (question is QuestionMultipleChoice multipleChoice)
            {
                Console.WriteLine("Välj ett svar:");

                for (int i = 0; i < multipleChoice.Options.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {multipleChoice.Options[i]}");
                }

                while (!int.TryParse(Console.ReadLine(), out answer) ||
                       answer < 1 || answer > multipleChoice.Options.Count)
                {
                    Console.WriteLine("Ogiltigt svar. Försök igen:");
                }
            }
            else if (question is QuestionTrueFalse)
            {
                Console.WriteLine("1. Sant");
                Console.WriteLine("2. Falskt");

                while (!int.TryParse(Console.ReadLine(), out answer) ||
                       answer < 1 || answer > 2)
                {
                    Console.WriteLine("Ogiltigt svar. Ange 1 eller 2:");
                }
            }
        }
    }
}


/*




    


        public void PlayGame();


        public void ShowResult();
*/