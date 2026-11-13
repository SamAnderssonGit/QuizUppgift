using System;
using System.Collections.Generic;
using System.Text;

namespace QuizUppgiften1.Models
{
    public class QuestionTrueFalse : Question
    {
        public bool correct { get; set; }

        public override List<string> GetOptions()
        {
            return new List<string> { "Sant", "Falskt" };
        }

        public override bool IsCorrect(int answerNumber)
        {
            return (answerNumber == 1) == correct;
        }
    }
}
