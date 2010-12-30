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
    /// EditModeQuestionListView.xaml の相互作用ロジック
    /// </summary>
    public partial class EditModeQuestionListView : UserControl
    {
        public EditModeQuestionListView()
        {
            InitializeComponent();
            dataGrid_QuestionList.MouseLeftButtonUp += 
                new MouseButtonEventHandler(dataGrid_QuestionList_MouseLeftButtonUp);
            button_Up.Click += new RoutedEventHandler(button_Up_Click);
            button_Down.Click += new RoutedEventHandler(button_Down_Click);
            button_Delete.Click += new RoutedEventHandler(button_Delete_Click);
        }

        private EditModeQuestionLIstViewModel _editModeQuestionLIstViewModel;

        void button_Up_Click(object sender, RoutedEventArgs e)
        {
            _editModeQuestionLIstViewModel.OnClickedUpBtn();
        }

        void button_Down_Click(object sender, RoutedEventArgs e)
        {
            _editModeQuestionLIstViewModel.OnClickedDownBtn();
        }

        void button_Delete_Click(object sender, RoutedEventArgs e)
        {
            _editModeQuestionLIstViewModel.OnClickedDeleteBtn();
        }

        void dataGrid_QuestionList_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            int selectIdx = dataGrid_QuestionList.SelectedIndex;
            MainWindow.EditModeViewModel.ToActiveQuestionItemAt(selectIdx);
        }

        public void SetViewModel(EditModeQuestionLIstViewModel viewModel)
        {
            _editModeQuestionLIstViewModel = viewModel;
            DataContext = viewModel;
        }
    }
}
