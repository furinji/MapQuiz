using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using System.Windows;

namespace MapQuiz
{
    public sealed class QuizModeManager
    {
        public QuizModeManager()
        {
            ProblemModel = new ProblemModel();
            QuizModeAnswerListViewModel =
                QuizModeAnswerListViewModel.CreateInstance(
                MainWindow.QuizModePanel);
            QItemList = new List<QuizModeQuestionItemViewModel>();
            //QuizModeAnswerListViewModel.CreateAnswerList();
        }


        public ProblemModel ProblemModel { get; set; } //{ get; private set; }
        public QuizModeAnswerListViewModel QuizModeAnswerListViewModel {
            get; private set; }
        public IList<QuizModeQuestionItemViewModel> QItemList { get; private set; }


        public Size MapImageOriginalSize { get; private set; }


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
            var mapPanel = MainWindow.QuizModePanel.quizModeMapAreaPanel1;
            mapPanel.InnerArea.Width = MapImageOriginalSize.Width;
            mapPanel.InnerArea.Height = MapImageOriginalSize.Height;
            mapPanel.ImageRect.Fill = brush;

            // 描画されるのを待ってサイズを変更
            var delayExe = new DelayExection();
            delayExe.Exect(OnClickedFitBtn, () =>
            {
                return (mapPanel.scrollViewer1.ActualWidth > 0 &&
                    mapPanel.scrollViewer1.ActualHeight > 0);
            });
        }

        public void SetQuestionItems()
        {
            var itemLayer = 
                MainWindow.QuizModePanel.quizModeMapAreaPanel1.QuestionItemLayer;
            itemLayer.Children.Clear();
            QItemList.Clear();
            foreach (var item in ProblemModel.QuestionList)
            {
                var view = new QuizModeQuestionItemView();
                var viewModel = QuizModeQuestionItemViewModel.CreateInstance(
                    view, item);
                viewModel.Replace();
                itemLayer.Children.Add(view);
                QItemList.Add(viewModel);
            }
        }

        public void ReplaceQItems()
        {
            foreach (var item in QItemList)
            {
                item.Replace();
            }
        }

        public void ClearAllActive()
        {
            foreach (var item in QItemList)
            {
                if (item.QuestionItemState == QuestionItemState.Active)
                {
                    item.QuestionItemState = QuestionItemState.Normal;
                }
            }
        }

        public QuizModeQuestionItemViewModel GetActiveQItem()
        {
            foreach (var item in QItemList)
            {
                if (item.QuestionItemState == QuestionItemState.Active)
                {
                    return item;
                }
            }
            return null;
        }

        public string GetSelectAnswer()
        {
            var answers = QuizModeAnswerListViewModel.QuizModeAnswerListModel.Items;
            int selectIdx = MainWindow.QuizModePanel.dataGrid_AnswerList.SelectedIndex;
            if ((0 <= selectIdx && selectIdx < answers.Count) == false) 
            { 
                return null; 
            }
            return answers[selectIdx].Value;
        }

        public void OnClickedCheckBtn()
        {
            var selectQitem = GetActiveQItem();
            var question = (selectQitem != null) ? selectQitem.QuestionModel : null;
            var mapAnswer = (question != null) ? question.Answer.GetFirstValue() : null;
            var listAnswer = GetSelectAnswer();
            if (mapAnswer == null || listAnswer == null) 
            {
                MainWindow.QuizModePanel.quizModeInterfacePanel1.textBlock_1.Text = "選択されていません";
                return; 
            }
            if (mapAnswer == listAnswer)
            {
                MainWindow.QuizModePanel.quizModeInterfacePanel1.textBlock_1.Text = "正解";
                OnCorrectAnswer(selectQitem, MainWindow.QuizModePanel.dataGrid_AnswerList.SelectedIndex);
            }
            else
            {
                MainWindow.QuizModePanel.quizModeInterfacePanel1.textBlock_1.Text = "まちがい";

            }
        }

        public void OnCorrectAnswer(
            QuizModeQuestionItemViewModel qItem,
            int listIdx)
        {
            qItem.QuestionItemState = QuestionItemState.Fixed;
            QuizModeAnswerListViewModel.RemoveAt(listIdx);
        }

        public void MoveToFront(QuizModeQuestionItemViewModel qItem)
        {
            var root = MainWindow.QuizModePanel.quizModeMapAreaPanel1.QuestionItemLayer;
            root.Children.Remove(qItem.QuizModeQuestionItemView);
            root.Children.Add(qItem.QuizModeQuestionItemView);
        }


        #region イベント

        public void OnClickedFitBtn()
        {
            var mapPanel = MainWindow.QuizModePanel.quizModeMapAreaPanel1;
            double rootW = mapPanel.scrollViewer1.ActualWidth;
            double rootH = mapPanel.scrollViewer1.ActualHeight;
            double resW = rootW;
            double resH = resW * MapImageOriginalSize.Height / MapImageOriginalSize.Width;
            if (resH > rootH)
            {
                resH = rootH;
                resW = resH * MapImageOriginalSize.Width / MapImageOriginalSize.Height;
            }
            mapPanel.InnerArea.Width = resW;
            mapPanel.InnerArea.Height = resH;
            ReplaceQItems();
        }

        public void OnClickedSmallBtn()
        {
            var mapPanel = MainWindow.QuizModePanel.quizModeMapAreaPanel1;
            double w = mapPanel.InnerArea.Width;
            double h = mapPanel.InnerArea.Height;
            mapPanel.InnerArea.Width = w * 0.9;
            mapPanel.InnerArea.Height = h * 0.9;
            ReplaceQItems();
        }

        public void OnClickedOriginalSizeBtn()
        {
            var mapPanel = MainWindow.QuizModePanel.quizModeMapAreaPanel1;
            mapPanel.InnerArea.Width = MapImageOriginalSize.Width;
            mapPanel.InnerArea.Height = MapImageOriginalSize.Height;
            ReplaceQItems();
        }

        public void OnClickedLargeBtn()
        {
            var mapPanel = MainWindow.QuizModePanel.quizModeMapAreaPanel1;
            double w = mapPanel.InnerArea.Width;
            double h = mapPanel.InnerArea.Height;
            mapPanel.InnerArea.Width = w * 1.1;
            mapPanel.InnerArea.Height = h * 1.1;
            ReplaceQItems();
        }

        #endregion //イベント


    }
}
