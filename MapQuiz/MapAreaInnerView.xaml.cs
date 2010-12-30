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
    public partial class MapAreaInnerView : UserControl
    {
        public MapAreaInnerView()
        {
            InitializeComponent();
            this.MouseLeftButtonUp += new MouseButtonEventHandler(
                MapAreaView_MouseLeftButtonUp);
            this.MouseMove += new MouseEventHandler(MapAreaView_MouseMove);
        }

        public MapAreaInnerViewModel ViewModel { get; private set; }

        public void SetViewModel(
            MapAreaInnerViewModel viewModel)
        {
            ViewModel = viewModel;
            //DataContext = EditModeMapAreaInnerViewModel;
        }


        #region イベント

        protected void MapAreaView_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            ViewModel.OnMapAreaMouseLeftBtnUp();
        }

        protected void MapAreaView_MouseMove(object sender, MouseEventArgs e)
        {
            ViewModel.OnMouseMove();
        }

        #endregion //イベント

    }
}
