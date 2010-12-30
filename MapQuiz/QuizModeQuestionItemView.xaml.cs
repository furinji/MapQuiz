using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MapQuiz
{
    /// <summary>
    /// QuizModeQuestionItemView.xaml の相互作用ロジック
    /// </summary>
    public partial class QuizModeQuestionItemView : UserControl
    {
        public QuizModeQuestionItemView()
        {
            InitializeComponent();
        }

        public QuizModeQuestionItemViewModel QuizModeQuestionItemViewModel { 
            get; private set; }

        public void SetViewModel(QuizModeQuestionItemViewModel viewModel)
        {
            QuizModeQuestionItemViewModel = viewModel;
        }

        private void Root_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            QuizModeQuestionItemViewModel.OnMouseLeftDown();
        }
    }
}
