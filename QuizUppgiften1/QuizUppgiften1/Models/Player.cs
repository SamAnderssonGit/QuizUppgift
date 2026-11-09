namespace QuizUppgiften1.Models
{
    public class Player
    {
        public string Name { get; set; }

        public int Score { get; set; }

        public int CorrectAnswers { get; set; }

        public int CorrectStreak { get; set; }

        public Player(string name)
        {
            Name = name;
            Score = 0;
            CorrectAnswers = 0;
            CorrectStreak = 0;
        }
    }
}