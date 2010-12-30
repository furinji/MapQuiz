using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.ComponentModel;
using System.Windows.Controls;

namespace MapQuiz
{
    public class QuestionItemViewModel : INotifyPropertyChanged
    {
        protected QuestionItemViewModel()
        {
        }

        //protected static QuestionItemViewModel CreateInstance(
        //    QuestionItemView view,
        //    Panel rootPanel)
        //{
        //    var instance = new QuestionItemViewModel();
        //    instance._id = _nextId++;
        //    instance.View = view;
        //    instance.Model = new QuestionModel();
        //    instance.View.SetViewModel(instance);
        //    instance.RootPanel = rootPanel;
        //    return instance;
        //}

        protected void Init(
            QuestionItemView view,
            Panel rootPanel)
        {
            this._id = _nextId++;
            this.View = view;
            this.Model = new QuestionModel();
            this.View.SetViewModel(this);
            this.RootPanel = rootPanel;
        }

        private Size _size;

        public QuestionItemView View { get; protected set; }
        public QuestionModel Model { get; protected set; }
        public Panel RootPanel { get; protected set; }
        public Point RelativeCenterPoint
        {
            get { return Model.Position; }
            set 
            { 
                Model.Position = value;
                Replace();
            }
        }
        public Size Size { 
            get { return _size; }
            set
            {
                _size = value;
                View.Width = _size.Width;
                View.Height = _size.Height;
            }
        }
        public int Idx { get; set; }

        public virtual QuestionItemState ItemState { get; set; }
        public virtual void OnMouseLeftDown()
        {
        }
        public virtual void OnMouseMove(Point mousePos)
        {
        }
        public virtual void OnMouseUp()
        {
        }

        protected static uint _nextId = 0;
        protected uint _id;

        public void Replace()
        {
            //var rootW = RootPanel.ActualWidth;
            //var rootH = RootPanel.ActualHeight;
            var rootW = MainWindow.EditModePanel.EditModeMapAreaOuterPanel.MapAreaInnerView.Width;
            var rootH = MainWindow.EditModePanel.EditModeMapAreaOuterPanel.MapAreaInnerView.Height;
            var x = rootW * RelativeCenterPoint.X - Size.Width / 2.0;
            var y = rootH * RelativeCenterPoint.Y - Size.Height / 2.0;
            View.Margin = new Thickness(x, y, 0, 0);
        }

        public Point ConvertRelativeToAbsolutePoint(Point relativePoint)
        {
            var x = RootPanel.ActualWidth * relativePoint.X;
            var y = RootPanel.ActualHeight * relativePoint.Y;
            return new Point(x, y);
        }

        public Point ConvertAbsoluteToRelativePoint(Point absolutePoint)
        {
            var x = absolutePoint.X / RootPanel.ActualWidth;
            var y = absolutePoint.Y / RootPanel.ActualHeight;
            return new Point(x, y);
        }


        #region INotifyPropertyChanged メンバ

        public event PropertyChangedEventHandler PropertyChanged = delegate { };
        protected void OnPropertyChanged(string name)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(name));
        }

        #endregion // INotifyPropertyChanged メンバ

    }
}
