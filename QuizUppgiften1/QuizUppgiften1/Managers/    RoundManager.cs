namespace QuizUppgiften1.Managers
{
    public class RoundManager
    {
        public int TotalRounds { get; private set; }

        public int CurrentRound { get; private set; }

        public int CurrentPlayerIndex { get; private set; }

        public RoundManager(int totalRounds)
        {
            TotalRounds = totalRounds;
            CurrentRound = 1;
            CurrentPlayerIndex = 0;
        }

        public bool HasMoreRounds()
        {
            return CurrentRound <= TotalRounds;
        }

        public void NextPlayer(int numberOfPlayers)
        {
            CurrentPlayerIndex++;

            if (CurrentPlayerIndex >= numberOfPlayers)
            {
                CurrentPlayerIndex = 0;
                CurrentRound++;
            }
        }

        public string GetRoundInfo()
        {
            return $"Round {CurrentRound} of {TotalRounds}";
        }
    }
}