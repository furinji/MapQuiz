using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace MapQuiz
{
    public sealed class EditModeQuestionLIstViewModel : INotifyPropertyChanged
    {
        public EditModeQuestionLIstViewModel()
        {
            AnswerList = new List<Item>();
        }

        public List<Item> AnswerList { get; set; }
        public int SelectedIdx { get; set; }

        public EditModeQuestionListView EditModeQuestionListView { get; private set; }
        public ProblemModel ProblemModel
            { get { return MainWindow.EditModeViewModel.ProblemModel; } }
        public EditModeViewModel EditModeViewModel 
            { get { return MainWindow.EditModeViewModel; } }

        public static EditModeQuestionLIstViewModel CreateInstance(
            EditModeQuestionListView view)
        {
            var instance = new EditModeQuestionLIstViewModel();
            instance.ConnectView(view);
            return instance;
        }

        private void ConnectView(EditModeQuestionListView view)
        {
            EditModeQuestionListView = view;
            EditModeQuestionListView.SetViewModel(this);
        }

        public void ReloadModel()
        {
            AnswerList.Clear();
            foreach (var item in ProblemModel.QuestionList)
            {
                var answerItem = item.Answer.Items.FirstOrDefault();
                var answer = (answerItem != null) ? answerItem.Value : "";
                AnswerList.Add(new Item(answer));
            }
            OnPropertyChanged("AnswerList");
            EditModeQuestionListView.dataGrid_QuestionList.Items.Refresh();
        }

        public void ToActiveAt(int idx)
        {
            var selectIdx = idx;
            if (InRangeListIdx(idx) == false)
            {
                selectIdx = -1;
            }
            EditModeQuestionListView.dataGrid_QuestionList.SelectedIndex = selectIdx;
        }

        public void OnClickedUpBtn()
        {
            var idx = EditModeQuestionListView.dataGrid_QuestionList.SelectedIndex;
            var upIdx = idx - 1;
            if (InRangeListIdx(idx) && InRangeListIdx(upIdx))
            {
                EditModeViewModel.ExchangeAt(idx, upIdx);
                EditModeViewModel.ToActiveQuestionItemAt(upIdx);
            }
        }

        public void OnClickedDownBtn()
        {
            var idx = EditModeQuestionListView.dataGrid_QuestionList.SelectedIndex;
            var downIdx = idx + 1;
            if (InRangeListIdx(idx) && InRangeListIdx(downIdx))
            {
                EditModeViewModel.ExchangeAt(idx, downIdx);
                EditModeViewModel.ToActiveQuestionItemAt(downIdx);
            }
        }

        public void OnClickedDeleteBtn()
        {
            var idx = EditModeQuestionListView.dataGrid_QuestionList.SelectedIndex;
            if (InRangeListIdx(idx))
            {
                EditModeViewModel.DeleteAt(idx);
                EditModeViewModel.ToActiveQuestionItemAt(-1);
            }
        }

        private bool InRangeListIdx(int idx)
        {
            if (0 <= idx && idx < EditModeQuestionListView.dataGrid_QuestionList.Items.Count)
            {
                return true;
            }
            return false;
        }

        public sealed class Item
        {
            public Item(string value)
            {
                Value = value;
            }

            public string Value { get; set; }
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
