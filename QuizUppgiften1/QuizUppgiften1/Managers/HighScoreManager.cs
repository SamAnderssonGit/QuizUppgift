using System.Text.Json;

namespace QuizUppgiften1
{
    public class HighScoreManager
    {
        public List<HighScore> LoadHighScores()
        {
            string json = File.ReadAllText("Data/highscores.json");

            List<HighScore> scores =
                JsonSerializer.Deserialize<List<HighScore>>(json); //omvandlar vår JSON-text till C# språk.

            return scores ?? new List<HighScore>(); // returnerar listan eller tom listta om den är null

        }

        public void ShowScoreboard()
        {
            List<HighScore> scores = LoadHighScores();

            Console.WriteLine("\n==== LEADERBOARD ====");

            foreach (HighScore score in scores)
            {
                Console.WriteLine($"{score.Name}: {score.Score} points");
            }
        }

        public void SaveHighScores(List<HighScore> scores) //sparar resultaten till JSON-filen.
        {
            string json = JsonSerializer.Serialize(scores); //omvandlar vår lista till JSON-text.

            File.WriteAllText("Data/highscores.json", json); //skriver in i jsonformat i filen.
        }
    }
}