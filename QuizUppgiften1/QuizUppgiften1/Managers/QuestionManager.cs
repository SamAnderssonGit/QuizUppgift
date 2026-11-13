using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using QuizUppgiften1.Models;

namespace QuizUppgiften1.Managers
{
    public class QuestionManager
    {
        private List<Question> questions = new List<Question>();    //gör listan åtkomlig för klassens metoder


        public List<Question> LoadQuestions()
        {
            string json = File.ReadAllText("Data/Questions.json");
            JsonSerializerOptions options = new()
            {
                PropertyNameCaseInsensitive = true
            };

            using JsonDocument document = JsonDocument.Parse(json);

            foreach (JsonElement category in document.RootElement.GetProperty("categories").EnumerateArray())
            {
                string categoryName = category.GetProperty("name").GetString();
                foreach (JsonElement question in category.GetProperty("questions").EnumerateArray())
                {
                    Question newQuestion = question.Deserialize<Question>(options); //frågan görs av rätt subklass utan if/else pga JsonPolymorphic

                    if (newQuestion != null)
                    {
                        newQuestion.Category = categoryName;
                        questions.Add(newQuestion);
                    }
                }
            }

            return questions;
        }

        public List<Question> FilterCategory(string selectedCategory)
        {
            return questions
                .Where(q => q.Category == selectedCategory) //selectedCategory är identifier för LINQ-filtrerad lista, skapas vid metodanrop i Game-classen.
                .ToList();      
        }

        public Question PickRandomQuestion(List<Question> categoryQuestions) //väljer slumpmässig fråga + kollar vilka frågor som använts
        {
            if (categoryQuestions == null || categoryQuestions.Count == 0)
            {
                return null;
            }

            Random random = new Random();

            int index = random.Next(categoryQuestions.Count);

            Question selectedQuestion = categoryQuestions[index];
            questions.Remove(selectedQuestion);     //tar bort använd fråga från huvudlista.

            categoryQuestions.RemoveAt(index);      //tar bort använda frågor från aktuell spelomgång.

            return selectedQuestion;
        }
    }
}