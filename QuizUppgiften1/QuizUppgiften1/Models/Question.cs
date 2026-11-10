using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace QuizUppgiften1
{
   
    public class Question
    {
        
        public List<string> Categories { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Text { get; set; }
        public List<string> Options { get; set; }
        public int Difficulty { get; set; }
    }


}


//ALLA subklasser + denna klass måste kollas så props matchar json. + lägg till constructor 
