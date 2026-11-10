using System.Text.Json;

namespace QuizUppgiften1
{
    public class HighScoreManager
    {
        public List<HighScore> LoadHighScores()
        {
            string json = File.ReadAllText("Data/highscores.json");

            List<HighScore> scores =
                JsonSerializer.Deserialize<List<HighScore>>(json);

            return scores ?? new List<HighScore>();
        }

        public void ShowScoreboard()
        {
            List<HighScore> scores = LoadHighScores();

            Console.WriteLine("\n--- SCOREBOARD ---");

            foreach (HighScore score in scores)
            {
                Console.WriteLine($"{score.Name}: {score.Score} poäng");
            }
        }
    }
}