using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using QuizUppgiften1.Models;

namespace QuizUppgiften1.Managers
{
public class LeaderboardManager
{
private readonly string filePath = Path.Combine("Data", "highscores.json");

    // Spara en spelares resultat
    public void SaveResult(Player player)
    {
        if (player == null)
        {
            throw new ArgumentNullException(nameof(player));
        }
        List<PlayerResult> results = LoadResults();
        results.Add(new PlayerResult
        {
            Name = player.Name,
            Score = player.Score,
            CorrectAnswers = player.CorrectAnswers,
            Date = DateTime.Now
        });
        // Sortera efter poäng, antal rätt och datum
        results = results
            .OrderByDescending(r => r.Score)
            .ThenByDescending(r => r.CorrectAnswers)
            .ThenByDescending(r => r.Date)
            .Take(10)
            .ToList();
        string? directory = Path.GetDirectoryName(filePath);
        if (!string.IsNullOrEmpty(directory))
        {
            Directory.CreateDirectory(directory);
        }
        string json = JsonSerializer.Serialize(
            results,
            new JsonSerializerOptions
            {
                WriteIndented = true
            });
        File.WriteAllText(filePath, json);
    }
    // Läsa sparade resultat
    public List<PlayerResult> LoadResults()
    {
        if (!File.Exists(filePath))
        {
            return new List<PlayerResult>();
        }
        string json = File.ReadAllText(filePath);
        return JsonSerializer.Deserialize<List<PlayerResult>>(json)
               ?? new List<PlayerResult>();
    }
    // Visa topplistan
    public void ShowLeaderboard()
    {
        List<PlayerResult> ranking = LoadResults()
            .OrderByDescending(r => r.Score)
            .ThenByDescending(r => r.CorrectAnswers)
            .ThenByDescending(r => r.Date)
            .Take(10)
            .ToList();
        Console.WriteLine("\n========== TOPPLISTA ==========");
        if (ranking.Count == 0)
        {
            Console.WriteLine("Det finns inga sparade resultat ännu.");
            return;
        }
        for (int i = 0; i < ranking.Count; i++)
        {
            PlayerResult result = ranking[i];
            Console.WriteLine(
                $"{i + 1}. {result.Name} - " +
                $"{result.Score} poäng - " +
                $"{result.CorrectAnswers} rätt - " +
                $"{result.Date:yyyy-MM-dd}");
        }
        Console.WriteLine("===============================");
    }
}
// Beskriver ett sparat spelarresultat
public class PlayerResult
{
    public string Name { get; set; } = "";
    public int Score { get; set; }
    public int CorrectAnswers { get; set; }
    public DateTime Date { get; set; }
}

}