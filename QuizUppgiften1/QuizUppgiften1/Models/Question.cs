using QuizUppgiften1.Models;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace QuizUppgiften1
{
    [JsonPolymorphic(TypeDiscriminatorPropertyName = "type")]           //anger att subklasser finns. Skillnaden avgörs av prop "type"
    [JsonDerivedType(typeof(QuestionMultipleChoice), "multipleChoice")]     // anger vilken subklass som gäller för vilken typ av fråga
    [JsonDerivedType(typeof(QuestionTrueFalse), "trueFalse")]
    public abstract class Question : IQuestion
    {
        public string Category { get; set; }
        public string Type { get; set; }
        public string Text { get; set; }
        public string Difficulty { get; set; }
        
            public abstract List<string> GetOptions();
            public abstract bool IsCorrect(int answerNumber);
    }
}


