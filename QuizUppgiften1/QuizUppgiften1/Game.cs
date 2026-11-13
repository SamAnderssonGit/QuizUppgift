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
        public string SelectedCategory()
        {
            Console.WriteLine("Välj kategori:");
            Console.WriteLine("1. Programmering");
            Console.WriteLine("2. Geografi");
            Console.WriteLine("3. Allmänbildning");

            int choice;

            while (!int.TryParse(Console.ReadLine(), out choice) ||
                   choice < 1 || choice > 3)
            {
                Console.WriteLine("Ogiltigt val. Välj 1-3:");
            }

            if (choice == 1)
                return "Programmering";
            else if (choice == 2)
                return "Geografi";
            else
                return "Allmänbildning";
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

                Console.WriteLine($"{currentPlayer.Name}, Det är din tur!");

                string category = SelectedCategory();

                List<Question> categoryQuestions = QuestionManager.FilterCategory(category); //anropar FilterCategory-metod + ger variabel till LINQ-filtrerad lista.

                Question question = QuestionManager.PickRandomQuestion(categoryQuestions);

                bool isCorrect = PlayQuestion(question);
                if(isCorrect)
                {
                    Console.WriteLine("Rätt svar!");
                }
                else
                {
                    Console.WriteLine("Fel svar!");
                }

                RoundManager.NextPlayer(Players.Count);
            }
            Console.WriteLine("================================");
            Console.WriteLine("SPELET ÄR SLUT!");
            Console.WriteLine("================================");
        }


        public bool PlayQuestion(Question question)
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
                return answer == multipleChoice.CorrectIndex + 1;
            }
            else if (question is QuestionTrueFalse trueFalse)
            {
                Console.WriteLine("1. Sant");
                Console.WriteLine("2. Falskt");

                while (!int.TryParse(Console.ReadLine(), out answer) ||
                       answer < 1 || answer > 2)
                {
                    Console.WriteLine("Ogiltigt svar. Ange 1 eller 2:");
                }

                return (answer == 1) == trueFalse.correct;
            }

            return false;
        }
    }
}


/*




    


        public void PlayGame();


        public void ShowResult();
*/