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
    /// MapViewrPanel.xaml の相互作用ロジック
    /// </summary>
    public partial class EditModeMapAreaOuterPanel : UserControl
    {
        public EditModeMapAreaOuterPanel()
        {
            InitializeComponent();
            MapAreaInnerView = new MapAreaInnerView();
            ScrollGrid.Children.Add(MapAreaInnerView);
        }

        public MapAreaInnerView MapAreaInnerView { get; private set; }


    }
}
