   M S B A M L   `   `   `  ����  WFP_Project    WFP_Project.Pages.Session   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -   5          � Title$  Session��5   	   $	��450��5   	   $	��800��6   .��5
      �  � ColumnDefinitions 5   
   �� 5      �� 5      .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ TrainingDataGrid��5         AutoGenerateColumns$ False��5         
IsReadOnly$
 True��5      $��10,68,10,10q�5      $��0��5         Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Training��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6X   1  +System.Windows.Controls.DataGridBoundColumn   Binding 67   �� *TrainingName+6X     5      $ Athlete��6%   $ * 6V    66   �� *AthleteName+6V     5      $ Coach��6%   $ * 6R    64   �� *	CoachName+6R   5        5   
   -   5        $ ExercisesDataGrid��5      $ False��5      $��10,68,10,10q�5      $
 True��5       $��1��5!       5"        5#      $ Exercise��6%   $ * 6X    67   �� *ExerciseName+6X     5$      $
 Reps��6%   $ * 6L    63   �� *Reps+6L     5%      $
 Sets��6%   $ * 6L    63   �� *Sets+6L   5'      �� 5(   
   $��Filter:��5)      $	��Top=�5*      $��
10,0,316,0q�5+      �� 5,   
   -   5        	 ��Name$	 FilterTextBox��5-      $��32��6$   $��10,19,10,383q�5.      $	��Top=�5/      
���   �   CustomTextBoxStyle#��[  51      52      �� 53   
   -   5        $��Create Training��54      $��
0,19,260,0q�55      $	��Top=�56      $��Right=�57      $��32��58      $	��120��6   $��1��59      ��5;      �� 5<      
 �� EndPoint$
 0.5,1&�6&    �� 
StartPoint$ 0.5,0&�67   .��5=      �  � Color$ 	#FF4C961B��6#    � Offset$ 1Q�65   � 5>      $ 	#FF67EA0F��6#   $ 0Q�65   5?      5A      �� 5B   
   -   5        $��Edit Training��5C      $	��Top=�5D      $��Right=�5E      $��32��5F      $	��120��6   $��
0,19,135,0q�5G      $��1��5H      ��5J      �� 5K      $
 0.5,1&�6&   $ 0.5,0&�67   .��5L      � $ #b94d1c��6#   $ 0Q�63   � 5M      $ #f7a634��6#   $ 1Q�63   5N      5P      �� 5Q   
   -   5        $��Delete Training��5R      $	��Top=�5S      $��Right=�5T      $��32��5U      $	��120��6   $��	0,19,10,0q�5V      $��1��5W      ��5Y      �� 5Z      $
 0.5,1&�6&   $ 0.5,0&�67   .��5[      � $ 	#FFB71C1C��6#   $ 0Q�65   � 5\      $ 	#FF8A1A1A��6#   $ 1Q�65   5]      5_      5`      5a      