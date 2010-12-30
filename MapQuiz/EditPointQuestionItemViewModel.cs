using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows;
using System.Windows.Input;

namespace MapQuiz
{
    public sealed class EditPointQuestionItemViewModel : QuestionItemViewModel
    {
        private EditPointQuestionItemViewModel()
        {
        }

        public static EditPointQuestionItemViewModel CreateInstance(EditModeViewModel parent)
        {
            var instance = new EditPointQuestionItemViewModel();
            instance.Parent = parent;
            instance.Init(
                new EditPointQuestionItemView(),
                MainWindow.EditModePanel.EditModeMapAreaOuterPanel.MapAreaInnerView.Root);
            instance.Size = new Size(16, 16);
            //instance.EditModeAnswerViewModel = EditModeAnswerViewModel.CreateInstance(
            //    instance.Model.Answer,
            //    MainWindow.EditModePanel.InterFacePanel.editModeAnswerView1);
            return instance;
        }

        public EditModeViewModel Parent { get; private set; }

        private QuestionItemState _itemState;
        public override QuestionItemState ItemState
        {
            get { return _itemState; }
            set
            {
                _itemState = value;
                switch (_itemState)
                {
                    case QuestionItemState.Active:
                        ((EditPointQuestionItemView)View).Center.Fill =
                            new SolidColorBrush(Colors.Red);
                        Parent.AnswerViewModel.OnChangedActive(Model.Answer);
                        break;
                    default: // case QuestionItemState.Normal:
                        ((EditPointQuestionItemView)View).Center.Fill =
                            new SolidColorBrush(Colors.Silver);
                        break;
                }
            }
        }

        public bool IsDrag { get; set; }
        //public EditModeAnswerViewModel EditModeAnswerViewModel { get; private set; }



        public override void OnMouseLeftDown()
        {
            MainWindow.EditModeViewModel.EditModeMapAreaInnerViewModel.ClearAllActive();
            MainWindow.EditModeViewModel.EditModeMapAreaInnerViewModel.ReloadIdx();
            MainWindow.EditModeViewModel.ToActiveQuestionItemAt(this.Idx);
            IsDrag = true;
        }

        public override void OnMouseUp()
        {
            IsDrag = false;
        }

        public override void OnMouseMove(Point mousePos)
        {
            bool isLeftBtnDown = (Mouse.LeftButton == MouseButtonState.Pressed);
            if (isLeftBtnDown == false) { IsDrag = false; }
            if (IsDrag == false) { return; }
            RelativeCenterPoint = ConvertAbsoluteToRelativePoint(mousePos);
        }

    }
}
