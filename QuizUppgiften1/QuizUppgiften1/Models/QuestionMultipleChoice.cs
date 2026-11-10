using System;
using System.Collections.Generic;
using System.Text;

namespace QuizUppgiften1
{
    public class QuestionMultipleChoice : Question
    {
        public List<string> Options { get; set; }
        public int CorrectIndex { get; set; }

        public override bool CheckAnswer(string answer)
        {
            return int.TryParse(answer, out int index)
                   && index == CorrectIndex;
        }
    }
}
