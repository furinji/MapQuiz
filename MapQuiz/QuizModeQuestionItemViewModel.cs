using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Media;

namespace MapQuiz
{
    public sealed class QuizModeQuestionItemViewModel
    {
        private QuizModeQuestionItemViewModel()
        {
        }

        public static QuizModeQuestionItemViewModel CreateInstance(
            QuizModeQuestionItemView view,
            QuestionModel model)
        {
            var instance = new QuizModeQuestionItemViewModel();
            instance.QuizModeQuestionItemView = view;
            instance.QuestionModel = model;
            view.SetViewModel(instance);
            return instance;
        }

        public QuizModeQuestionItemView QuizModeQuestionItemView { get; private set; }
        public QuestionModel QuestionModel { get; private set; }

        //public Point RelativePosition { get; set; }

        public void Replace()
        {
            var root = MainWindow.QuizModePanel.quizModeMapAreaPanel1.InnerArea;
            var x = root.Width * QuestionModel.Position.X;
            var y = root.Height * QuestionModel.Position.Y;
            var w = QuizModeQuestionItemView.Width;
            var h = QuizModeQuestionItemView.Height;
            double absPosX = x - w / 2;
            double absPosY = y - h / 2;
            QuizModeQuestionItemView.Margin = 
                new Thickness(absPosX, absPosY, 0, 0);
        }

        private QuestionItemState _questionItemState;
        public QuestionItemState QuestionItemState
        {
            get { return _questionItemState; }
            set
            {
                _questionItemState = value;
                switch (_questionItemState)
                {
                    case QuestionItemState.Active:
                        QuizModeQuestionItemView.Body.Fill =
                            new SolidColorBrush(Colors.Red);
                        QuizModeQuestionItemView.Width = 22;
                        QuizModeQuestionItemView.Height = 22;
                        MainWindow.QuizModeManager.MoveToFront(this);
                        break;
                    case QuestionItemState.Fixed:
                        QuizModeQuestionItemView.Body.Fill =
                            new SolidColorBrush(Colors.Silver);
                        QuizModeQuestionItemView.Width = 16;
                        QuizModeQuestionItemView.Height = 16;
                        break;
                    default: // case QuestionItemState.Normal:
                        QuizModeQuestionItemView.Body.Fill = 
                            new SolidColorBrush(Colors.RoyalBlue);
                        QuizModeQuestionItemView.Width = 16;
                        QuizModeQuestionItemView.Height = 16;
                        break;
                }
                Replace();
            }
        }

        public void OnMouseLeftDown()
        {
            if (QuestionItemState != MapQuiz.QuestionItemState.Normal) { return; }
            MainWindow.QuizModeManager.ClearAllActive();
            QuestionItemState = QuestionItemState.Active;
            MainWindow.QuizModeManager.ReplaceQItems();
        }

    }
}
