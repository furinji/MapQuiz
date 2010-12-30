using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using System.Windows;
using System.Windows.Media.Imaging;
using System.Windows.Media;

namespace MapQuiz
{
    public sealed class EditModeViewModel
    {
        private EditModeViewModel()
        {
            ProblemModel = new ProblemModel();
            //EditModeMapAreaInnerViewModel =
            //    EditModeMapAreaInnerViewModel.CreateInstance(
            //    MainWindow.EditModePanel.EditModeMapAreaOuterPanel.MapAreaInnerView);
            EditModeQuestionListViewModel =
                EditModeQuestionLIstViewModel.CreateInstance(
                MainWindow.EditModePanel.InterFacePanel.editModeQuestionListView1);
            AnswerViewModel = EditModeAnswerViewModel.CreateInstance(
                MainWindow.EditModePanel.InterFacePanel.editModeAnswerView1);
        }

        // インスタンス作成
        public static EditModeViewModel CreateInstance()
        {
            var instance = new EditModeViewModel();
            instance.EditModeMapAreaInnerViewModel =
                EditModeMapAreaInnerViewModel.CreateInstance(
                MainWindow.EditModePanel.EditModeMapAreaOuterPanel.MapAreaInnerView, instance);
            //instance.ProblemModel = new ProblemModel();
            return instance;
        }

        public ProblemModel ProblemModel { get; set; }
        public EditModeAnswerViewModel AnswerViewModel { get; private set; }
        public EditModeMapAreaInnerViewModel EditModeMapAreaInnerViewModel
            { get; private set; }
        public EditModeQuestionLIstViewModel EditModeQuestionListViewModel 
            { get; private set; }

        public void AddQuestionItem(Point absolutePos)
        {
            var qItemModel = new QuestionModel();
            ProblemModel.QuestionList.Add(qItemModel);
            EditModeMapAreaInnerViewModel.AddNewItem(absolutePos, qItemModel);
            EditModeQuestionListViewModel.ReloadModel();
        }

        public void ToActiveQuestionItemAt(int idx)
        {
            EditModeMapAreaInnerViewModel.ToActiveAt(idx);
            EditModeQuestionListViewModel.ToActiveAt(idx);
        }

        public void ExchangeAt(int idx1, int idx2)
        {
            Util.ListExchangeAt(ProblemModel.QuestionList, idx1, idx2);
            EditModeQuestionListViewModel.ReloadModel();
            Util.ListExchangeAt(EditModeMapAreaInnerViewModel.QuestionItemViewModelList,
                idx1, idx2);
        }

        public void DeleteAt(int idx)
        {
            ProblemModel.QuestionList.RemoveAt(idx);
            EditModeQuestionListViewModel.ReloadModel();
            EditModeMapAreaInnerViewModel.DeleteAt(idx);
        }

        public void ReloadProblemModel()
        {
            EditModeMapAreaInnerViewModel.ReloadModel();
        }

        public void SetMapImage(string fileAbsolutePath)
        {
            EditModeMapAreaInnerViewModel.SetImageFile(fileAbsolutePath);
        }

    }
}
