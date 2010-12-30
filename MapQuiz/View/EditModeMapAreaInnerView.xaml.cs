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
    /// EditModeMapAreaView.xaml の相互作用ロジック
    /// </summary>
    public partial class EditModeMapAreaInnerView : UserControl
    {
        public EditModeMapAreaInnerView()
        {
            InitializeComponent();
            this.MouseLeftButtonUp += new MouseButtonEventHandler(
                EditModeMapAreaView_MouseLeftButtonUp);
            this.MouseMove += new MouseEventHandler(EditModeMapAreaView_MouseMove);
        }

        public EditModeMapAreaInnerViewModel EditModeMapAreaInnerViewModel { get; private set; }

        public void SetViewModel(
            EditModeMapAreaInnerViewModel editModeMapAreaViewModel)
        {
            EditModeMapAreaInnerViewModel = editModeMapAreaViewModel;
            DataContext = EditModeMapAreaInnerViewModel;
        }


        #region イベント

        void EditModeMapAreaView_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            EditModeMapAreaInnerViewModel.OnMapAreaMouseLeftBtnUp();
        }

        void EditModeMapAreaView_MouseMove(object sender, MouseEventArgs e)
        {
            EditModeMapAreaInnerViewModel.OnMouseMove();
        }

        #endregion //イベント

    }
}
