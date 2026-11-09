namespace QuizUppgiften1
{
        public class Player
        {
            public string Name { get; set; }
            public int Score { get; set; }
            public int CorrectAnswers { get; set; }

            public Player(string name, int score, int correctanswers)
            {
            Name = name;
            Score = score;
            CorrectAnswers = correctanswers;
            }
        }
    }
}
