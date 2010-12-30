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
    /// EditQuestionInformation.xaml の相互作用ロジック
    /// </summary>
    public partial class EditQuestionInformation : UserControl
    {
        //public EditQuestionInformation()
        //{
        //    InitializeComponent();
        //    button_Add.Click += new RoutedEventHandler(button_Add_Click);
        //}

        //void button_Add_Click(object sender, RoutedEventArgs e)
        //{
        //    //ActiveAnswerList.Add(textBox_Input.Text);
        //    //Redraw();
        //    //MainWindow.EditModeViewModel.EditModePanel1.InterFacePanel1.OnChangedList();
        //}

        //public AnswerList ActiveAnswerList
        //{
        //    get
        //    {
        //        var qitem = MainWindow.EditModeViewModel.EditModePanel1.MapViewPanel1.QuestionLocationPanel1.GetActiveQItem();
        //        if (qitem == null) { return new AnswerList(); }
        //        return MainWindow.EditModeViewModel.EditModePanel1.MapViewPanel1.QuestionLocationPanel1.GetActiveQItem().AnswerList;
        //    }
        //}

        //public void Redraw()
        //{
        //    //textBox_Input.Text = ActiveAnswerList.Count > 0 ? ActiveAnswerList[0] : "";
        //    //listBox_AnswerList.Items.Clear();
        //    //foreach (var item in ActiveAnswerList)
        //    //{
        //    //    listBox_AnswerList.Items.Add(item);
        //    //}
        //}

        //public void OnChangedActiveItem()
        //{
        //    Redraw();
        //}

    }
}
