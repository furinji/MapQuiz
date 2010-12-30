using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Controls;
using System.Windows.Input;

namespace MapQuiz
{
    /// <summary>
    /// EditModeQuestionItemViewに対するViewModel
    /// </summary>
    public sealed class _EditModeQuestionItemViewModel : INotifyPropertyChanged
    {
        public _EditModeQuestionItemViewModel()
        {
        }

        // インスタンス作成 Model,Viewと接続
        public static _EditModeQuestionItemViewModel CreateInstance(
            QuestionModel questionModel,
            EditModeQuestionItemView questionItemView,
            UserControl root)
        {
            var instance = new _EditModeQuestionItemViewModel();
            instance.ConnectMV(questionModel, questionItemView);
            var answerModel = new AnswerModel();
            instance.EditModeAnswerViewModel = EditModeAnswerViewModel.CreateInstance(
                MainWindow.EditModePanel.InterFacePanel.editModeAnswerView1);
            instance.Root = root;
            return instance;
        }

        // Model,Viewと接続
        public void ConnectMV(QuestionModel questionModel,
            EditModeQuestionItemView questionItemView)
        {
            QuestionModel = questionModel;
            EditModeQuestionItemView = questionItemView;
            //EditModeQuestionItemView.SetViewModel(this);
        }

        //private EditModeQuestionItemView _editModeQuestionItemView;
        public EditModeQuestionItemView EditModeQuestionItemView { get; private set; }

        public EditModeMapAreaInnerViewModel EditModeMapAreaViewModel
            { get { return MainWindow.EditModeViewModel.EditModeMapAreaInnerViewModel; } }
        public QuestionModel QuestionModel { get; private set; }
        public EditModeAnswerViewModel EditModeAnswerViewModel { get; private set; }
        public UserControl Root { get; private set; }
        public bool IsDrag { get; set; }

        //TODO: 仮 //////////////////////////////
        public int Idx { get; set; }
        // //////////////////////////////////////

        private Size RootSize
        {
            get
            {
                var w = Root.Width;
                var h = Root.Height;
                return new Size(w, h);
            }
        }

        public Point AbsoluteCenterPoint
        {
            get
            {
                var x = RootSize.Width * QuestionModel.Position.X;
                var y = RootSize.Height * QuestionModel.Position.Y;
                return new Point(x, y);
            }
            set
            {
                double relX = value.X / RootSize.Width;
                double relY = value.Y / RootSize.Height;
                QuestionModel.Position = new Point(relX, relY);
                Replace();
            }
        }

        public Point RelativeCenterPoint
        {
            get
            {
                return QuestionModel.Position;
            }
            set
            {
                QuestionModel.Position = value;
                Replace();
            }
        }

        public void Replace()
        {
            var x = RootSize.Width * QuestionModel.Position.X;
            var y = RootSize.Height * QuestionModel.Position.Y;
            var w = EditModeQuestionItemView.Root.Width;
            var h = EditModeQuestionItemView.Root.Height;
            AbsoluteLeftTopPoint = new Point(
                x - w / 2, y - h / 2);
        }


        #region バインド

        private Point _absoluteLeftTopPoint;
        public Point AbsoluteLeftTopPoint
        {
            get { return _absoluteLeftTopPoint; }
            set
            {
                if (value == _absoluteLeftTopPoint) { return; }
                _absoluteLeftTopPoint = value;
                OnPropertyChanged("AbsoluteLeftTopPoint");
            }
        }

        private bool _isActive;
        public bool IsActive
        {
            get { return _isActive; }
            set
            {
                if (value == _isActive) { return; }
                _isActive = value;
                OnPropertyChanged("IsActive");
                //TODO: 要変更
                if (_isActive)
                {
                    MainWindow.EditModePanel.InterFacePanel.editModeAnswerView1.SetViewModel(EditModeAnswerViewModel);
                }
            }
        }

        #endregion //バインド


        #region イベント

        //public void OnMouseLeftDonw()
        //{
        //    //QLocateionPanel.ClearAllActive();
        //    EditModeMapAreaViewModel.ClearAllActive();
        //    //TODO: 仮 ////////////////////////////////////////////////////////////
        //    MainWindow.EditModeViewModel.EditModeMapAreaInnerViewModel.ReloadIdx();
        //    MainWindow.EditModeViewModel.ToActiveQuestionItemAt(this.Idx);
        //    // ///////////////////////////////////////////////////////////////////
        //    //IsActive = true;
        //    IsDrag = true;
        //}

        //public void OnMouseUp()
        //{
        //    IsDrag = false;
        //}

        //public void OnMouseMove(Point mousePos)
        //{
        //    bool isLeftBtnDown = (Mouse.LeftButton == MouseButtonState.Pressed);
        //    if (isLeftBtnDown == false) { IsDrag = false; }
        //    if (IsDrag == false) { return; }
        //    AbsoluteCenterPoint = mousePos;
        //}

        #endregion //イベント


        #region INotifyPropertyChanged メンバ

        public event PropertyChangedEventHandler PropertyChanged = delegate { };
        private void OnPropertyChanged(string name)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(name));
        }

        #endregion


    }


    #region コンバータ

    public class PointMargineConverter : IValueConverter
    {
        public object Convert(object value, System.Type targetType,
            object parameter, System.Globalization.CultureInfo culture)
        {
            var absPos = (Point)value;
            return new Thickness(absPos.X, absPos.Y, 0, 0);
        }

        public object ConvertBack(object value, System.Type targetType,
            object parameter, System.Globalization.CultureInfo culture)
        {
            var margine = (Thickness)value;
            var x = margine.Left;
            var y = margine.Top;
            return new Point(x, y);
        }

    }

    public class ActiveBrushConverter : IValueConverter
    {
        public object Convert(object value, System.Type targetType,
            object parameter, System.Globalization.CultureInfo culture)
        {
            var isActive = (bool)value;
            if (isActive)
            {
                return new SolidColorBrush(Colors.Red);
            }
            else
            {
                return new SolidColorBrush(Colors.Silver);
            }
        }

        public object ConvertBack(object value, System.Type targetType,
            object parameter, System.Globalization.CultureInfo culture)
        {
            //var brush = (Brush)value;
            return false;
        }

    }

    #endregion //コンバータ

}
