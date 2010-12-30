using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;

namespace MapQuiz
{
    public class QuestionItemView : UserControl
    {
        public QuestionItemViewModel ViewModel { get; protected set; }
        public virtual void SetViewModel(QuestionItemViewModel viewModel)
        {
        }
    }
}
