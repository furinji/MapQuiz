   M S B A M L   `   `   `  ���� B  >MapQuiz, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:MapQuizMapQuiz      MapQuiz.EditModePanel   myclr-namespace:MapQuiz  \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     .��� -   $��MainGrid��  � ColumnDefinitions  �� �� $	��140 �.+�� $��0�� � RowDefinitions �� �� $��30 �.+�� -   $��MapViewArea��$��0��$��5,5,0,5q�]� $��1��$��5,0,0,5q�.+�� $
��Left=�.+�   MapQuiz.MapOperationPanel  -     Name$ mapOperationPane1��� $
��Left=�$��10���� -   $��button_LoadImage��$
��Left=�$	��Img��$��40���� -   $��button_Save��$
��Left=�$
��Save��$��40���� -   $��button_Load��$
��Left=�$
��Load��$��40��   MapQuiz.ToggleButton  -     Name$ toggle_Hand��$��Right=�   Text$
 Hand��$��45��  -   $ 
toggle_Add��$��Right=�$	 Add��$��45��  -	   $ toggle_Select��$��Right=�$ Select��$��45��� $
��Left=�$
��Auto��� -
   $��InterfacePanelArea��$��1��