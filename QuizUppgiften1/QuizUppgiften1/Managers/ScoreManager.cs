using System;
using QuizUppgiften1.Models;

namespace QuizUppgiften1.Managers
{
    public class ScoreManager
    {
        public int RegisterAnswer(
            Player player,
            bool isCorrect,
            string difficulty)
        {
            // Om spelaren svarar fel
            if (!isCorrect)
            {
                player.CorrectStreak = 0;
                return 0;
            }

            // Om spelaren svarar rätt
            player.CorrectAnswers++;
            player.CorrectStreak++;

            // Beräkna grundpoäng
            int points = CalculatePoints(difficulty);

            // Beräkna streakbonus
            int bonus = Math.Min(
                (player.CorrectStreak - 1) * 5, 20);

            // Räkna ut totala poäng
            int totalPoints = points + bonus;

            // Uppdatera spelarens poäng
            player.Score += totalPoints;

            return totalPoints;
        }

        private int CalculatePoints(string difficulty)
        {
            return difficulty?.ToLower() switch
            {
                "easy" => 10,
                "medium" => 20,
                "hard" => 30,
                _ => 0
            };
        }
    }
}