   M S B A M L   `   `   `  ����   MapQuiz&     MapQuiz.EditModeQuestionListView   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     .��� -   $
��Root��.+��   � RowDefinitions  �� $��25 ��� $��3 ��� .+�]� $��0��.+��� -   $��	button_Up��$
��Left=�$	��▲��$��25���� -   $��button_Down��$
��Left=�$	��▼��$��25���� -   $��button_Delete��$
��Left=�$	��Del��$��30��� $��Right=�� $��2��.+�&   System.Windows.Controls.DataGrid  -   $��dataGrid_QuestionList��
�������   HorizontalGridLinesBrush
 �����   VerticalGridLinesBrush
 �����   CanUserSortColumns .     AutoGenerateColumns .     HeadersVisibility$
 None=�   
IsReadOnly . ����  �� Path$ 
AnswerList�   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn	   Header$	 Value��
   Width5  /System.Windows.Controls.DataGridLengthConverter$
 * 1  +System.Windows.Controls.DataGridBoundColumn   Binding �� $ Value�