using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace QuizUppgiften1
{
    [JsonPolymorphic(TypeDiscriminatorPropertyName = "type")]           //anger att subklasser finns
    [JsonDerivedType(typeof(QuestionMultipleChoice), "multipleChoice")]     // anger vilkken subklass som ska användas till vilket object.
    [JsonDerivedType(typeof(QuestionTrueFalse), "trueFalse")]
    public abstract class Question : IQuestion
    {
        public string Category { get; set; }
        public string Type { get; set; }
        public string Text { get; set; }
        public List<string> Options { get; set; } = new();
        public string Difficulty { get; set; }

        public abstract void DisplayQuestion();
        public abstract bool CheckAnswer(string userAnswer);
    }
}

