using System.Text.Json;



namespace QuizUppgiften1.Managers
{
    public class QuestionManager
    {
        public Question LoadQuestions()
        {
            string json = File.ReadAllText("Data/Questions.json");
            List<Question> questions = JsonSerializer.Deserialize<List<Question>>(json); //omvandlar Questions.json till objekt.

        }


  




        public Question FilterCategory(Question questions)
        {

            var selectedCategor
            questions.Where(q => q.Categories == selectedCategory)
            .ToList(); //detta är nog listan som ska skickas till metoden PickRandom Question.

        }

        public void PickRandomQuestion(questions)
        { 
            Random random = new Random();

            int index = random.Next(categoryQuestions.Count);

            Question selectedQuestion = questions.Categories[index];

            questions.Remove(selectedQuestion);

        }


    }
}