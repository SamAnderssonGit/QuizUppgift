using System;
using System.Collections.Generic;
using System.Text;

namespace QuizUppgiften1
{
        public class QuestionMultipleChoice : Question
        {
            public List<string> Options { get; set; }
            public int CorrectIndex { get; set; }

            public override List<string> GetOptions()
            {
                return Options;
            }

            public override bool IsCorrect(int answerNumber)
            {
                return answerNumber == CorrectIndex + 1;
            }
        }
    
}
