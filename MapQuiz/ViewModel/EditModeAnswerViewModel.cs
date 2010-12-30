using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace MapQuiz
{
    /// <summary>
    /// EditModeのAnswerViewに対するViewModel
    /// </summary>
    public sealed class EditModeAnswerViewModel : INotifyPropertyChanged
    {
        private EditModeAnswerViewModel()
        {
        }

        public static EditModeAnswerViewModel CreateInstance(
            EditModeAnswerView answerView)
        {
            var instance = new EditModeAnswerViewModel();
            instance.ConnectView(answerView);
            return instance;
        }

        public EditModeAnswerView View { get; private set; }
        public AnswerModel AnswerModel { get; private set; }

        public void EndEdit()
        {
            this.View.dataGrid_Answer.CommitEdit();
            this.View.dataGrid_Answer.CancelEdit();
        }

        public void OnChangedActive(AnswerModel model)
        {
            ConnectModel(model);
        }

        private void ConnectView(EditModeAnswerView answerView)
        {
            this.View = answerView;
            this.View.SetViewModel(this);
        }

        private void ConnectModel(AnswerModel model)
        {
            EndEdit();
            this.AnswerModel = model;
            OnAnswerListChanged();
        }

        private void OnAnswerListChanged()
        {
            OnPropertyChanged("AnswerModel.Items");
            this.View.dataGrid_Answer.Items.Refresh();
            MainWindow.EditModeViewModel.EditModeQuestionListViewModel.ReloadModel();
        }


        #region Viewイベント

        public void OnClickedUpBtn()
        {
            var selectIdx = View.dataGrid_Answer.SelectedIndex;
            var upIdx = selectIdx - 1;
            if (this.AnswerModel.InRangeIdx(selectIdx) &&
                this.AnswerModel.InRangeIdx(upIdx))
            {
                this.AnswerModel.ExchangeItemsAt(selectIdx, upIdx);
                OnAnswerListChanged();
            }
        }

        public void OnClickedDownBtn()
        {
            var selectIdx = this.View.dataGrid_Answer.SelectedIndex;
            var downIdx = selectIdx + 1;
            if (this.AnswerModel.InRangeIdx(selectIdx) &&
                this.AnswerModel.InRangeIdx(downIdx))
            {
                this.AnswerModel.ExchangeItemsAt(selectIdx, downIdx);
                OnAnswerListChanged();
            }
        }

        public void OnClickedDeleteBtn()
        {
            var selectIdx = this.View.dataGrid_Answer.SelectedIndex;
            if (this.AnswerModel.InRangeIdx(selectIdx))
            {
                this.AnswerModel.Items.RemoveAt(selectIdx);
                OnAnswerListChanged();
            }
        }

        #endregion //Viewイベント


        #region INotifyPropertyChangedメンバ

        public event PropertyChangedEventHandler PropertyChanged = delegate { };
        private void OnPropertyChanged(string name)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(name));
        }

        #endregion //INotifyPropertyChangedメンバ

    }
}
