using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace QuizUppgiften1
{
   
    public class Question 
    {
        public string name { get; set; }
        public string type { get; set; }
        public string text { get; set; }
        public string difficulty { get; set; }
        

       public bool CheckAnswer(string answer);

        
    }

}

//ALLA subklasser + denna klass måste kollas så props matchar json. + lägg till constructor 
