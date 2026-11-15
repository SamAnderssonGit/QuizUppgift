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
        public ScoreManager ScoreManager { get; set; }


        public void StartGame()
        {
            int playerCount = GetPlayerCount();

            Players = CreatePlayers(playerCount);
            ScoreManager = new ScoreManager();

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
        public string SelectedCategory()
        {
            Console.WriteLine("Välj kategori:");
            Console.WriteLine("1. Programmering");
            Console.WriteLine("2. Geografi");
            Console.WriteLine("3. Allmänbildning");
            Console.WriteLine("4. Slumpa");

            int choice;

            while (!int.TryParse(Console.ReadLine(), out choice) ||
                   choice < 1 || choice > 4)
            {
                Console.WriteLine("Ogiltigt val. Välj 1-4:");
            }

            if (choice == 1)
                return "Programmering";
            else if (choice == 2)
                return "Geografi";
            else if (choice == 3)
                return "Allmänbildning";
            else
            {
                int randomCategory = Random.Shared.Next(1, 4); //Slumpar val 1-3

                if (randomCategory == 1)
                    return "Programmering";
                else if (randomCategory == 2)
                    return "Geografi";
                else
                    return "Allmänbildning";
            }
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
                if (QuestionManager.AvailableCategories().Count == 0)
                {
                    Console.WriteLine("Alla frågor är slut! Spelet avslutas...");
                    break;
                }
                Console.WriteLine(RoundManager.GetRoundInfo());

                Player currentPlayer = Players[RoundManager.CurrentPlayerIndex];

                Console.WriteLine($"Din tur: {currentPlayer.Name}");

                QuestionManager.ShowRemainingQuestions();

                string category = SelectedCategory();

                List<Question> categoryQuestions = QuestionManager.FilterCategory(category); //anropar FilterCategory-metod + ger variabel till LINQ-filtrerad lista.

                Question question = QuestionManager.PickRandomQuestion(categoryQuestions);

                while (question == null) //Stoppar programmet från krasch ifall alla frågor redan blivit användna
                {
                    Console.WriteLine("Frågorna är slut i denna kategori... välj ett annat ämne");
                    category = SelectedCategory();
                    categoryQuestions = QuestionManager.FilterCategory(category);

                    question = QuestionManager.PickRandomQuestion(categoryQuestions);
                }

                bool isCorrect = PlayQuestion(question);

                if (isCorrect)
                {
                    Console.WriteLine($"{currentPlayer.Name}, svarade RÄTT");
                }
                else
                {
                    Console.WriteLine($"{currentPlayer.Name}, svarade FEL");
                    Console.WriteLine($"Rätt svar var: {question.GetCorrectAnswer()}");
                }
                int points = ScoreManager.RegisterAnswer(currentPlayer, isCorrect, question.Difficulty);

                Console.WriteLine($"{currentPlayer.Name}, fick {points} poäng!");
                Console.WriteLine($"{currentPlayer.Name}s Totalpoäng: {currentPlayer.Score}");

                RoundManager.NextPlayer(Players.Count);

            }
            Console.WriteLine("=========== SPELET ÄR SLUT =============");
            Console.WriteLine("===========   RESULTAT  ================");
            foreach (Player player in Players)
            {
                Console.WriteLine($"{player.Name}: {player.Score} poäng");
            }
            Console.WriteLine("========================================");

          
        }

        public bool PlayQuestion(IQuestion question)
        {
            if (question is Question myQuestion)
            {
                Console.WriteLine($"Kategori: {myQuestion.Category}");
                if (myQuestion.Difficulty == "easy")
                {
                    Console.WriteLine("Nivå: Lätt");
                    Console.WriteLine("Poäng: 10");
                }
                else if (myQuestion.Difficulty == "medium")
                {
                    Console.WriteLine("Nivå: Medel");
                    Console.WriteLine("Poäng: 20");
                }
                else if (myQuestion.Difficulty == "hard")
                {
                    Console.WriteLine("Nivå: Svårt");
                    Console.WriteLine("Poäng: 30");
                }
            }


            Console.WriteLine(question.Text);
            Console.WriteLine($"Välj ett svar: ");

            List<string> options = question.GetOptions();

            for (int i = 0; i < options.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {options[i]}");
            }

            int answer;
            Console.Write($"Ditt svar (1-{options.Count}): ");
            while (!int.TryParse(Console.ReadLine(), out answer) ||
                   answer < 1 || answer > options.Count)
            {
                Console.WriteLine($"Ogiltigt svar. Ange en siffra mellan 1 och {options.Count}:");
            }

            return question.IsCorrect(answer);
        }
    }
}

