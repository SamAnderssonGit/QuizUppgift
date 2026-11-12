using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

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
                    string type = question.GetProperty("type").GetString();
                    Question newQuestion = null;

                    if (type == "multipleChoice")
                    {
                        newQuestion = JsonSerializer.Deserialize<QuestionMultipleChoice>(question.GetRawText(), options);
                    }
                    else if (type == "trueFalse")
                    {
                        newQuestion = JsonSerializer.Deserialize<QuestionTrueFalse>(question.GetRawText(), options);
                    }

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
                .Where(q => q.Category == selectedCategory)
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
            questions.Remove(selectedQuestion);

            categoryQuestions.RemoveAt(index);      //tar bort använda frågor. 

            return selectedQuestion;
        }


    }
}