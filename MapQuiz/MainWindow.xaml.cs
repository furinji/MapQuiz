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
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            EditModePanel = new EditModePanel();
            QuizModePanel = new QuizModePanel();
            QuizModeManager = new QuizModeManager();
            //QuizModePanel._quizModeAnswerListViewModel =
            //    QuizModeAnswerListViewModel.CreateInstance(QuizModePanel);
            EditModeViewModel = EditModeViewModel.CreateInstance();
            _currentPanel = EditModePanel;
            MainGrid.Children.Add(_currentPanel);
        }

        public static EditModePanel EditModePanel { get; private set; }
        public static QuizModePanel QuizModePanel { get; private set; }
        public static EditModeViewModel EditModeViewModel { get; private set; }
        public static QuizModeManager QuizModeManager { get; private set; }
             
        private UserControl _currentPanel;

        private void Menu_QuizMode_Click(object sender, RoutedEventArgs e)
        {
            MainGrid.Children.Remove(_currentPanel);
            MainGrid.Children.Add(QuizModePanel);
            _currentPanel = QuizModePanel;
            //
            QuizModeManager.ProblemModel = EditModeViewModel.ProblemModel;
            QuizModeManager.QuizModeAnswerListViewModel.CreateAnswerList();
            QuizModeManager.ReloadImage(QuizModeManager.ProblemModel.MapImageRelativePath);
            QuizModeManager.SetQuestionItems();
        }

        private void Menu_EditMode_Click(object sender, RoutedEventArgs e)
        {
            MainGrid.Children.Remove(_currentPanel);
            MainGrid.Children.Add(EditModePanel);
            _currentPanel = EditModePanel;
        }

    }
}
