using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace QuizUppgiften1
{
   
    public abstract class Question
    {

        public List<string> Categories { get; set; } = new();
        public string Name { get; set; }
        public string Type { get; set; }
        public string Text { get; set; }
        public List<string> Options { get; set; } = new();
        public int Difficulty { get; set; }
    }


}



