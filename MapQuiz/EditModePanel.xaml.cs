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
    /// EditModePanel.xaml の相互作用ロジック
    /// </summary>
    public partial class EditModePanel : UserControl
    {
        public EditModePanel()
        {
            InitializeComponent();
            SetEvent();
            EditModeMapAreaOuterPanel = new EditModeMapAreaOuterPanel();
            MapViewArea.Children.Add(EditModeMapAreaOuterPanel);
            InterFacePanel = new InterfacePanel();
            InterfacePanelArea.Children.Add(InterFacePanel);
            ToolMode = EditToolMode.Select;
        }

        private EditToolMode _toolMode;

        public InterfacePanel InterFacePanel { get; private set; }
        public EditModeMapAreaOuterPanel EditModeMapAreaOuterPanel { get; private set; }

        public bool IsAddMode
        {
            get { return ToolMode == EditToolMode.Add; }
        }

        public EditToolMode ToolMode
        {
            get { return _toolMode; }
            set
            {
                _toolMode = value;
                switch (_toolMode)
                {
                    case EditToolMode.Select:
                        toggle_Select.IsActive = true;
                        toggle_Add.IsActive = false;
                        toggle_Hand.IsActive = false;
                        //Mouse.OverrideCursor = Cursors.Arrow;
                        EditModeMapAreaOuterPanel.MapAreaInnerView.Cursor = Cursors.Arrow;
                        break;
                    case EditToolMode.Add:
                        toggle_Select.IsActive = false;
                        toggle_Add.IsActive = true;
                        toggle_Hand.IsActive = false;
                        //Mouse.OverrideCursor = Cursors.Pen;
                        EditModeMapAreaOuterPanel.MapAreaInnerView.Cursor = Cursors.Pen;
                        break;
                    default: //case EditToolMode.Hand:
                        toggle_Select.IsActive = false;
                        toggle_Add.IsActive = false;
                        toggle_Hand.IsActive = true;
                        //Mouse.OverrideCursor = Cursors.Hand;
                        EditModeMapAreaOuterPanel.MapAreaInnerView.Cursor = Cursors.Hand;
                        break;
                }
            }
        }

        private void SetEvent()
        {
            mapOperationPane1.button_Small.Click += new RoutedEventHandler(button_small_Click);
            mapOperationPane1.button_Large.Click += new RoutedEventHandler(button_large_Click);
            mapOperationPane1.button_Fit.Click += new RoutedEventHandler(button_fit_Click);
            mapOperationPane1.button_OriginalSize.Click += new RoutedEventHandler(button_original_Click);
            toggle_Select.button.Click += new RoutedEventHandler(selectButton_Click);
            toggle_Add.button.Click += new RoutedEventHandler(addButton_Click);
            toggle_Hand.button.Click += new RoutedEventHandler(handButton_Click);
            button_Save.Click += new RoutedEventHandler(button_Save_Click);
            button_Load.Click += new RoutedEventHandler(button_Load_Click);
            button_LoadImage.Click += new RoutedEventHandler(button_LoadImage_Click);
        }


        #region イベント

        void button_Save_Click(object sender, RoutedEventArgs e)
        {
            var dlog = new System.Windows.Forms.SaveFileDialog();
            dlog.InitialDirectory = System.Windows.Forms.Application.StartupPath;
            dlog.Filter = "xmlファイル(*.xml)|*.xml|すべてのファイル(*.*)|*.*";
            var resDlog = dlog.ShowDialog();
            if (resDlog != System.Windows.Forms.DialogResult.OK) { return; }
            var resSave = ProblemForSerialize.SaveToFile(MainWindow.EditModeViewModel.ProblemModel, dlog.FileName);
            //var resSave = FileManager.SaveToFile(MainWindow.EditModeViewModel.ProblemModel, dlog.FileName);
            if (resSave)
            {
                System.Windows.Forms.MessageBox.Show("保存しました");
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("保存できませんでした");
            }
        }

        void button_Load_Click(object sender, RoutedEventArgs e)
        {
            var dlog = new System.Windows.Forms.OpenFileDialog();
            dlog.InitialDirectory = System.Windows.Forms.Application.StartupPath;
            dlog.Filter = "xmlファイル(*.xml)|*.xml|すべてのファイル(*.*)|*.*";
            var res = dlog.ShowDialog();
            if (res != System.Windows.Forms.DialogResult.OK) { return; }
            var problem = ProblemForSerialize.LoadFromFile(dlog.FileName);
            //var problem = FileManager.LoadFromFile(dlog.FileName);
            if (problem == null) { problem = new ProblemModel(); }
            MainWindow.EditModeViewModel.ProblemModel = problem;
            MainWindow.EditModeViewModel.EditModeMapAreaInnerViewModel.ReloadModel();
        }

        void selectButton_Click(object sender, RoutedEventArgs e)
        {
            ToolMode = EditToolMode.Select;
        }

        void addButton_Click(object sender, RoutedEventArgs e)
        {
            ToolMode = EditToolMode.Add;
        }

        void handButton_Click(object sender, RoutedEventArgs e)
        {
            ToolMode = EditToolMode.Hand;
        }

        void button_original_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.EditModeViewModel.EditModeMapAreaInnerViewModel.ChangeMapSizeOriginal();
        }

        void button_fit_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.EditModeViewModel.EditModeMapAreaInnerViewModel.ChangeMapSizeFit();
        }

        void button_large_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.EditModeViewModel.EditModeMapAreaInnerViewModel.ChangeMapSizeLarge();
        }

        void button_small_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.EditModeViewModel.EditModeMapAreaInnerViewModel.ChangeMapSizeSmall();
        }

        void button_LoadImage_Click(object sender, RoutedEventArgs e)
        {
            var dlog = new System.Windows.Forms.OpenFileDialog();
            dlog.InitialDirectory = System.Windows.Forms.Application.StartupPath;
            dlog.Filter = "Imageファイル(*.png;*.jpg;*.bmp)|*.png;*.jpg;*.bmp|すべてのファイル(*.*)|*.*";
            var res = dlog.ShowDialog();
            if (res != System.Windows.Forms.DialogResult.OK) { return; }
            MainWindow.EditModeViewModel.SetMapImage(dlog.FileName);
        }

        #endregion // イベント


    }
}
