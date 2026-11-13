using System;
using System.Collections.Generic;
using System.Text;

namespace QuizUppgiften1.Models
{
    public interface IQuestion
    {
        string Text { get; }
        List<string> GetOptions();
        bool IsCorrect(int answerNumber);
    }
}