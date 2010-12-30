using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace MapQuiz
{
    public sealed class QuizModeAnswerListViewModel : INotifyPropertyChanged
    {
        private QuizModeAnswerListViewModel()
        {
            QuizModeAnswerListModel = new QuizModeAnswerListModel();
        }

        public static QuizModeAnswerListViewModel CreateInstance(
            QuizModePanel view)
        {
            var instance = new QuizModeAnswerListViewModel();
            instance.QuizModePanel = view;
            view.SetViewModel(instance);
            return instance;
        }

        public QuizModeAnswerListModel QuizModeAnswerListModel { get; set; }
        public QuizModePanel QuizModePanel { get; set; }
        public ProblemModel ProblemModel { 
            get { return MainWindow.QuizModeManager.ProblemModel; } }
        private Random _random = new Random();

        //public void Test()
        //{
        //    for (int i = 0; i < 10; i++)
        //    {
        //        QuizModeAnswerListModel.Items.Add(new QuizModeAnswerListModel.Item(i.ToString()));
        //    }
        //    OnPropertyChanged("QuizModeAnswerListModel.Items");
        //    QuizModePanel.dataGrid_AnswerList.Items.Refresh();
        //}

        public void CreateAnswerList()
        {
            QuizModeAnswerListModel.Items.Clear();
            foreach (var item in ProblemModel.QuestionList)
            {
                QuizModeAnswerListModel.Items.Add(
                    new QuizModeAnswerListModel.Item(
                        item.Answer.GetFirstValue()));
            }
            for (int i = 0; i < QuizModeAnswerListModel.Items.Count; i++)
            {
                int j = _random.Next(QuizModeAnswerListModel.Items.Count - 1);
                if (j >= i) { j += 1; }
                Util.ListExchangeAt(QuizModeAnswerListModel.Items, i, j);
            }
            OnPropertyChanged("QuizModeAnswerListModel.Items");
            QuizModePanel.dataGrid_AnswerList.Items.Refresh();
        }
        public void RemoveAt(int idx)
        {
            QuizModeAnswerListModel.Items.RemoveAt(idx);
            OnPropertyChanged("QuizModeAnswerListModel.Items");
            QuizModePanel.dataGrid_AnswerList.Items.Refresh();
        }

        #region INotifyPropertyChanged メンバ

        public event PropertyChangedEventHandler PropertyChanged = delegate { };
        private void OnPropertyChanged(string name)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(name));
        }

        #endregion

    }
}
