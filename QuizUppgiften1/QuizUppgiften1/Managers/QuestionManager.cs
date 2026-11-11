using System.Text.Json;

namespace QuizUppgiften1
{
    public class QuestionManager
    {
        public List<Question> LoadQuestions()
        {
            string json = File.ReadAllText("Data/Questions.json");

            List<Question> questions =
                JsonSerializer.Deserialize<List<Question>>(json); //omvandlar Questions.json till objekt.

            return questions ?? new List<Question>(); // returnerar lista


        }

        
        
        
    }
}