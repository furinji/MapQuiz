using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Media.Imaging;
using System.Windows.Media;

namespace MapQuiz
{
    public class MapAreaInnerViewModel
    {
        public MapAreaInnerViewModel()
        {
            QuestionItemViewModelList = new List<QuestionItemViewModel>();
        }

        public MapAreaInnerView View { get; protected set; }
        public virtual void OnMapAreaMouseLeftBtnUp()
        {
        }
        public virtual void OnMouseMove()
        {
        }

        public void SetView(
            MapAreaInnerView mapAreaInnerView)
        {
            View = mapAreaInnerView;
            View.SetViewModel(this);
        }

        public IList<QuestionItemViewModel> QuestionItemViewModelList { get; protected set; }

        public Size MapImageOriginalSize { get; protected set; }

        public void ReloadImage(string relativePath)
        {
            string absPath;
            BitmapImage bitmap;
            Brush brush;
            try
            {
                absPath = Util.ConvertToAbsolutePath(relativePath);
                bitmap = new BitmapImage(new Uri(absPath));
                brush = new ImageBrush(bitmap);
                MapImageOriginalSize = new Size(bitmap.Width, bitmap.Height);
            }
            catch
            {
                brush = new SolidColorBrush(Colors.Gray);
                MapImageOriginalSize = new Size(200, 200);
            }
            View.Width = MapImageOriginalSize.Width;
            View.Height = MapImageOriginalSize.Height;
            View.ImageRect.Fill = brush;
            ChangeMapSizeFit();
        }



        public void ChangeMapSizeFit()
        {
            double rootW = EditModeMapAreaOuterPanel.scrollViewer1.ActualWidth;
            double rootH = EditModeMapAreaOuterPanel.scrollViewer1.ActualHeight;
            double resW = rootW;
            double resH = resW * MapImageOriginalSize.Height / MapImageOriginalSize.Width;
            if (resH > rootH)
            {
                resH = rootH;
                resW = resH * MapImageOriginalSize.Width / MapImageOriginalSize.Height;
            }
            View.Width = resW;
            View.Height = resH;
            ReplaceQItems();
        }

        public EditModeMapAreaOuterPanel EditModeMapAreaOuterPanel
        { get { return MainWindow.EditModePanel.EditModeMapAreaOuterPanel; } }

        public void ReplaceQItems()
        {
            foreach (var item in QuestionItemViewModelList)
            {
                item.Replace();
            }
        }

    }
}
