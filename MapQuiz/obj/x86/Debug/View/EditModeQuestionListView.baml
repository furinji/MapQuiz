   M S B A M L   `   `   `  ����  MapQuiz&     MapQuiz.EditModeQuestionListView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      .��5      � -   5        $
��Root��5      .+�5	   
   �   � RowDefinitions  5
      �� 5      $��25 �6    �� 5      $��3 �6    �� 5      .+�5      ]� $��0��6   .+�5      �� -   5        $��	button_Up��5   ;   $
��Left=�6   $	��▲��6/   $��25��6L   �� 5      -   5        $��button_Down��5   ;   $
��Left=�6   $	��▼��6/   $��25��6N   �� 5      -   5        $��button_Delete��5   =   $
��Left=�6   $	��Del��6/   $��30��6R   � 5      $��Right=�6   5      � 5      $��2��6   .+�5      &   System.Windows.Controls.DataGrid  -   5        $��dataGrid_QuestionList��5      
�������   HorizontalGridLinesBrush
 �����   VerticalGridLinesBrush
 �����   CanUserSortColumns .     AutoGenerateColumns .     HeadersVisibility$
 None=�5   7      
IsReadOnly . ��5      ��  �� Path$ 
AnswerList�   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn	   Header$	 Value��6-   
   Width5  /System.Windows.Controls.DataGridLengthConverter$
 * 6<   1  +System.Windows.Controls.DataGridBoundColumn   Binding 5   -   �� $ Value�5      5       5!      5"      5#      