   M S B A M L   `   `   `  ����B  >MapQuiz, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:MapQuizMapQuiz  5          MapQuiz.EditModePanel   myclr-namespace:MapQuiz  \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      .��5      � -   5        $��MainGrid��5        � ColumnDefinitions  5	   
   �� 5
      �� 5      $	��140 �6   .+�5   
   � $��0��6    � RowDefinitions 5      �� 5      �� 5      $��30 �6    .+�5      � -   5        $��MapViewArea��5       $��0��6   $��5,5,0,5q�63   5      ]� 5      $��1��6   $��5,0,0,5q�6%   .+�5      � $
��Left=�6   .+�5         MapQuiz.MapOperationPanel  -   5          Name$ mapOperationPane1��5   +   5      � 5      $
��Left=�6   $��10��6-   �� 5      -   5        $��button_LoadImage��5   =   $
��Left=�6   $	��Img��6/   $��40��6U   �� 5      -   5        $��button_Save��5   >   $
��Left=�6   $
��Save��6/   $��40��6Q   �� 5       -   5        $��button_Load��5    >   $
��Left=�6   $
��Load��6/   $��40��6Q      MapQuiz.ToggleButton  5!      -   5          Name$ toggle_Hand��5!   9   $��Right=�6"      Text$
 Hand��6N   $��45��6Z     5"      -   5        $ 
toggle_Add��5"   9   $��Right=�6"   $	 Add��6M   $��45��6X     5#      -	   5        $ toggle_Select��5#   9   $��Right=�6"   $ Select��6P   $��45��6^   � 5$      $
��Left=�6   $
��Auto��6-   5%      5&      � 5'   
   -
   5        $��InterfacePanelArea��5'      $��1��6   5)      5*      5+      