   M S B A M L   `   `   `  ����  WFP_Project%    WFP_Project.Pages.ArchiveWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   -   5          � Title$  Archive Window��5   	   $	��600��5   	   $	��800��6    � 	Resources 5         RoundedButtonStyle �� 
TargetType �� Property �� Value �� 
TargetType �� CornerRadius��%�  &	        �� 5   
   " ��6+   .�5	      ��  � ��$
 10,5q�6(   �� 5
       � ��
 ���� 6+   �� 5       � ��
 �   �6,   �� 5       � ��$ 2q�60   �� 5       � �� 5      �� 5      " ��6&   .R�5      �� #��z��6!   #��z��5   !   #��z��5   !   $ 20��5   !   ._�5      �� $��Center=�6/   $��Center=�6L   5      5      5      5      5      ��5      �� 5   
    �� Color$ Transparent��6   .��5      �  � RowDefinitions 5   
   �� 5       $
��Auto �6   �� 5!      $��* �6   .+�5#   
   � -   5        	 �Name$	 tablesWrapPanel��5$      
 � Orientation$
 
Horizontal=�5%      $��0��5&      $��10q�5'      $	��Top=�5(      &   System.Windows.Controls.DataGrid  5)   
   -   5          Name$ archivedDataGrid��5*      $��1��5+      $��10q�5,         AutoGenerateColumns$
 True��5-      $y�	Collapsed=�5.         
IsReadOnly$
 True��5/      50      51      