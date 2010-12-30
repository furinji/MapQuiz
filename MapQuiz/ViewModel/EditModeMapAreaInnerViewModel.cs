using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Windows.Data;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Input;

namespace MapQuiz
{
    /// <summary>
    /// EditModeMapAreaViewに対するViewModel
    /// </summary>
    public sealed class EditModeMapAreaInnerViewModel : MapAreaInnerViewModel
    {
        private EditModeMapAreaInnerViewModel()
        {
            //QuestionItemViewModelList = new List<QuestionItemViewModel>();
        }

        // インスタンス作成
        public static EditModeMapAreaInnerViewModel CreateInstance(
            MapAreaInnerView mapAreaInnerView,
            EditModeViewModel parent)
        {
            var instance = new EditModeMapAreaInnerViewModel();
            instance.Parent = parent;
            instance.SetView(mapAreaInnerView);
            return instance;
        }

        public EditModeViewModel Parent { get; private set; }

        public EditModeViewModel EditModeViewModel 
            { get { return MainWindow.EditModeViewModel; } }
        public ProblemModel ProblemModel 
            { get { return MainWindow.EditModeViewModel.ProblemModel; } }

        //TODO: 仮 ///////////////////////////////////
        public void ReloadIdx()
        {
            for (int i = 0; i < QuestionItemViewModelList.Count; i++)
            {
                QuestionItemViewModelList[i].Idx = i;
            }
        }
        // ///////////////////////////////////////////

        public void DeleteAt(int idx)
        {
            var item = QuestionItemViewModelList[idx].View;
            QuestionItemViewModelList.RemoveAt(idx);
            View.QuestionItemLayer.Children.Remove(item);
        }

        public void ReloadModel()
        {
            var baseUri = new Uri(System.Windows.Forms.Application.StartupPath);
            QuestionItemViewModelList.Clear();
            View.QuestionItemLayer.Children.Clear();
            string absPath;
            try
            {
                absPath = Util.ConvertToAbsolutePath(ProblemModel.MapImageRelativePath);
            }
            catch
            {
                absPath = null;
            }
            ReloadImage(absPath);
            foreach (var item in EditModeViewModel.ProblemModel.QuestionList)
            {
                AddNewItem(item);
            }
            MainWindow.EditModeViewModel.EditModeQuestionListViewModel.ReloadModel();
            MainWindow.EditModeViewModel.ToActiveQuestionItemAt(-1);
        }

        public void SetImageFile(string fileAbsolutePath)
        {
            string relativeStr = Util.ConvertToRelativePath(fileAbsolutePath);
            ProblemModel.MapImageRelativePath = relativeStr;

            ReloadImage(relativeStr);
        }

        public void AddNewItem(Point pos, QuestionModel qItemModel)
        {
            var qItemViewModel = EditPointQuestionItemViewModel.CreateInstance(this.Parent);
            var relativePoint = qItemViewModel.ConvertAbsoluteToRelativePoint(pos);
            AddNewItem(qItemViewModel, relativePoint);
            qItemViewModel.Replace();
        }

        public void AddNewItem(QuestionModel qItemModel)
        {
            var qItemViewModel = EditPointQuestionItemViewModel.CreateInstance(this.Parent);
            var relativePoint = qItemModel.Position;
            AddNewItem(qItemViewModel, relativePoint);
        }

        private void AddNewItem(EditPointQuestionItemViewModel qItemViewModel, Point relativePoint)
        {
            qItemViewModel.RelativeCenterPoint = relativePoint;
            View.QuestionItemLayer.Children.Add(qItemViewModel.View);
            QuestionItemViewModelList.Add(qItemViewModel);
            EditModeViewModel.ToActiveQuestionItemAt(QuestionItemViewModelList.Count - 1);
        }

        public void ClearAllActive()
        {
            foreach (var item in QuestionItemViewModelList)
            {
                item.ItemState = QuestionItemState.Normal;
            }
        }

        public void ToActiveAt(int idx)
        {
            ClearAllActive();
            MainWindow.EditModePanel.InterFacePanel.editModeAnswerView1.SetViewModel(null);
            if (0 <= idx && idx < QuestionItemViewModelList.Count)
            {
                QuestionItemViewModelList[idx].ItemState = QuestionItemState.Active;
                var itemView = QuestionItemViewModelList[idx].View;
                View.QuestionItemLayer.Children.Remove(itemView);
                View.QuestionItemLayer.Children.Add(itemView);
            }
        }

        public override void OnMouseMove()
        {
            var mousePos = GetMousePos();
            var actQItem = GetActiveQItem();
            if (actQItem != null)
            {
                actQItem.OnMouseMove(mousePos);
            }
        }

        private Point GetMousePos()
        {
            var mousePos = Mouse.GetPosition(View.Root);
            return mousePos;
        }

        public QuestionItemViewModel GetActiveQItem()
        {
            foreach (var item in QuestionItemViewModelList)
            {
                if (item.ItemState == QuestionItemState.Active)
                {
                    return item;
                }
            }
            return null;
        }

        public void ChangeMapSizeSmall()
        {
            double w = View.Width;
            double h = View.Height;
            View.Width = w * 0.9;
            View.Height = h * 0.9;
            ReplaceQItems();
        }

        public void ChangeMapSizeLarge()
        {
            double w = View.Width;
            double h = View.Height;
            View.Width = w * 1.1;
            View.Height = h * 1.1;
            ReplaceQItems();
        }

        public void ChangeMapSizeOriginal()
        {
            View.Width = MapImageOriginalSize.Width;
            View.Height = MapImageOriginalSize.Height;
            ReplaceQItems();
        }

        public override void OnMapAreaMouseLeftBtnUp()
        {
            var area = View.Root;
            if (MainWindow.EditModePanel.IsAddMode)
            {
                var mousePos = Mouse.GetPosition(area);
                EditModeViewModel.AddQuestionItem(mousePos);
            }
            var actQItem = GetActiveQItem();
            if (actQItem != null)
            {
                actQItem.OnMouseUp();
            }
        }


        //#region INotifyPropertyChanged メンバ

        //public event PropertyChangedEventHandler PropertyChanged = delegate { };
        //private void OnPropertyChanged(string name)
        //{
        //    PropertyChanged(this, new PropertyChangedEventArgs(name));
        //}

        //#endregion //INotifyPropertyChanged メンバ


    }

}
