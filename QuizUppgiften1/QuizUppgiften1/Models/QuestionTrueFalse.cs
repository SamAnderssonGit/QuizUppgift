using System;
using System.Collections.Generic;
using System.Text;

namespace QuizUppgiften1
{
    public class QuestionTrueFalse : Question
    {
        public bool correct { get; set; }

        public override bool CheckAnswer(string answer)
        {
            return bool.TryParse(answer, out bool result)
                   && result == Correct;

        }
    }

}
