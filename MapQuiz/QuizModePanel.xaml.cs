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
    /// QuizModePanel.xaml の相互作用ロジック
    /// </summary>
    public partial class QuizModePanel : UserControl
    {
        public QuizModePanel()
        {
            InitializeComponent();
            quizModeInterfacePanel1.button_Check.Click += new RoutedEventHandler(button_Check_Click);
            SetEvent();
        }

        void button_Check_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.QuizModeManager.OnClickedCheckBtn();
        }

        public void SetViewModel(QuizModeAnswerListViewModel viewModel)
        {
            _quizModeAnswerListViewModel = viewModel;
            DataContext = viewModel;
        }

        private void SetEvent()
        {
            mapOperationPanel1.button_Fit.Click += new RoutedEventHandler(button_Fit_Click);
            mapOperationPanel1.button_Small.Click += new RoutedEventHandler(button_Small_Click);
            mapOperationPanel1.button_OriginalSize.Click += new RoutedEventHandler(button_OriginalSize_Click);
            mapOperationPanel1.button_Large.Click += new RoutedEventHandler(button_Large_Click);
        }


        #region イベント

        void button_Fit_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.QuizModeManager.OnClickedFitBtn();
        }

        void button_Small_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.QuizModeManager.OnClickedSmallBtn();
        }

        void button_OriginalSize_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.QuizModeManager.OnClickedOriginalSizeBtn();
        }

        void button_Large_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.QuizModeManager.OnClickedLargeBtn();
        }

        #endregion //イベント


        private QuizModeAnswerListViewModel _quizModeAnswerListViewModel;
    }
}
