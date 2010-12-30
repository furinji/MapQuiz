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
    /// InterfacePanel.xaml の相互作用ロジック
    /// </summary>
    public partial class InterfacePanel : UserControl
    {
        public InterfacePanel()
        {
            InitializeComponent();
            //checkBox_AddNewItem.Checked += new RoutedEventHandler(checkBox_AddNewItem_Checked);
            //button1.Click += new RoutedEventHandler(button1_Click);
        }

        public void OnChangedList()
        {
            var qitemList = MainWindow.EditModeViewModel.EditModeMapAreaInnerViewModel.ProblemModel.QuestionList;
            //listView1.Items.Clear();
            foreach (var item in qitemList)
            {
                //var text = item.AnswerList.FirstOrDefault() ?? "";
                //listView1.Items.Add(text);
            }
        }

    }
}
