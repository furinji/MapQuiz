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
    /// EditPointQuestionItemView.xaml の相互作用ロジック
    /// </summary>
    public partial class EditPointQuestionItemView : QuestionItemView
    {
        public EditPointQuestionItemView()
        {
            InitializeComponent();
            this.MouseLeftButtonDown += new MouseButtonEventHandler(
                EditPointQuestionItemView_MouseLeftButtonDown);
            //this.MouseMove += new MouseEventHandler(EditPointQuestionItemView_MouseMove);
            this.MouseUp += new MouseButtonEventHandler(EditPointQuestionItemView_MouseUp);
        }

        void EditPointQuestionItemView_MouseUp(object sender, MouseButtonEventArgs e)
        {
            ViewModel.OnMouseUp();
        }

        //void EditPointQuestionItemView_MouseMove(object sender, MouseEventArgs e)
        //{
        //    ViewModel.OnMouseMove();
        //}

        void EditPointQuestionItemView_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ViewModel.OnMouseLeftDown();
        }


        #region QuestionItemViewメンバ

        public override void SetViewModel(QuestionItemViewModel viewModel)
        {
            ViewModel = viewModel;
            DataContext = viewModel;
        }

        #endregion //QuestionItemViewメンバ

    }
}
