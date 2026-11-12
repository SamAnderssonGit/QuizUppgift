using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace QuizUppgiften1.Managers
{
    public class QuestionManager
    {
        private List<Question> questions = new List<Question>();    //gör listan åtkomlig för klassens metoder
        
        
        public List<Question> LoadQuestions()   
        {
            string json = File.ReadAllText("Data/Questions.json");      //läser in json-fil

            questions = JsonSerializer.Deserialize<List<Question>>(json)
                       ?? new List<Question>();                             //omvandlar json-filens innehåll till objekt.

            return questions;
        }

        public List<Question> FilterCategory(string selectedCategory)       // filtrerar frågor baserat på vald kategori
        {
            return questions
                .Where(q => q.Categories.Contains(selectedCategory))        
                .ToList();                                              //ger ny, filtrerad lista
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

            categoryQuestions.RemoveAt(index);      //tar bort använda frågor. 

            return selectedQuestion;
        }


    }
}