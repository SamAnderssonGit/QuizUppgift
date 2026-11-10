using System;
using System.Collections.Generic;
using System.Text;

namespace QuizUppgiften1
{
    public class QuestionMultipleChoice : Question
    {
        public List<string> options { get; set; }
        public int CorrectIndex {  get; set; }

    }
}
