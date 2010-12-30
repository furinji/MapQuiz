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
    /// EditModeAnswerView.xaml の相互作用ロジック
    /// </summary>
    public partial class EditModeAnswerView : UserControl
    {
        public EditModeAnswerView()
        {
            InitializeComponent();
            button_Up.Click += new RoutedEventHandler(button_Up_Click);
            button_Down.Click += new RoutedEventHandler(button_Down_Click);
            button_Delete.Click += new RoutedEventHandler(button_Delete_Click);
            dataGrid_Answer.CurrentCellChanged += new EventHandler<EventArgs>(dataGrid_Answer_CurrentCellChanged);
        }

        public EditModeAnswerViewModel AnswerViewModel { get; private set; }

        public void SetViewModel(EditModeAnswerViewModel answerViewModel)
        {
            if (AnswerViewModel != null)
            {
                AnswerViewModel.EndEdit();
            }
            AnswerViewModel = answerViewModel;
            DataContext = AnswerViewModel;
            //dataGrid_Answer.Items.Refresh();
        }


        #region イベント

        void button_Delete_Click(object sender, RoutedEventArgs e)
        {
            AnswerViewModel.OnClickedDeleteBtn();
        }

        void button_Down_Click(object sender, RoutedEventArgs e)
        {
            AnswerViewModel.OnClickedDownBtn();
        }

        void button_Up_Click(object sender, RoutedEventArgs e)
        {
            AnswerViewModel.OnClickedUpBtn();
        }

        void dataGrid_Answer_CurrentCellChanged(object sender, EventArgs e)
        {
            MainWindow.EditModeViewModel.EditModeQuestionListViewModel.ReloadModel();
        }

        #endregion //イベント


    }
}
