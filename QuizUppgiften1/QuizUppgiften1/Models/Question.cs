using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace QuizUppgiften1
{
    [JsonPolymorphic(TypeDiscriminatorPropertyName = "Type")]           //anger att subklasser finns
    [JsonDerivedType(typeof(QuestionMultipleChoice), "MultipleChoice")]     // anger vilkken subklass som ska användas till vilket object.
    [JsonDerivedType(typeof(QuestionTrueFalse), "TrueFalse")]
    public class Question
    {
        public List<string> Categories { get; set; } = new();
        public string Name { get; set; }
        public string Type { get; set; }
        public string Text { get; set; }
        public List<string> Options { get; set; } = new();
        public int Difficulty { get; set; }
    }
}

