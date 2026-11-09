using System;
using System.Collections.Generic;
using System.Text;

namespace QuizUppgiften1
{

    public abstract class Question //abstract så att det ej går att skapa objekt direkt från denna klass, utan måste göras via en av subklasserna. 
    {
        public string Text { get; set; }
        public string Difficulty { get; set; }
        public int Points { get; set; }

        public abstract bool CheckAnswer(string answer);
    }
}

//ALLA subklasser + denna klass måste kollas så props matchar json. + lägg till constructor 