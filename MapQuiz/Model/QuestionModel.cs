using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace MapQuiz
{
    public sealed class QuestionModel
    {
        public QuestionModel()
        {
            Answer = new AnswerModel();
        }

        public Point Position { get; set; }
        public AnswerModel Answer { get; set; }
    }
}
