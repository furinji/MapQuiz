using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MapQuiz
{
    public sealed class QuizModeAnswerListModel
    {
        public QuizModeAnswerListModel()
        {
            Items = new List<Item>();
        }

        public IList<Item> Items { get; set; }

        public sealed class Item
        {
            public Item(string value)
            {
                Value = value;
            }
            public string Value { get; set; }
        }
    }
}
