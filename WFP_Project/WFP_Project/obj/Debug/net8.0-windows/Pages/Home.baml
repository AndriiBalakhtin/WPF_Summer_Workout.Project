   M S B A M L   `   `   `  ����U  QLiveCharts.Wpf, Version=0.9.7.0, Culture=neutral, PublicKeyToken=0bc1f845d1ebb8dfG4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.WpfLiveCharts.Wpf  5   	    WFP_Project   WFP_Project.Pages.Home   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   Dlvc4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.Wpf     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -   5          �Name$  WindowHeight��5   	    � Title$
 Home��5   	   ��5      �� 5   
    �� Color$ Transparent��6   .��5      � .+�5   
   �� -   5         ��Name$ TextBlockDataUser��5      $
��Left=�5      $��	10,10,0,0q�5       �� TextAlignment$
 Left=�5       $��Data from Json : N/A��5!      $	��Top=�5"      $	��500��6%   �� 5#   
   -   5        $ TextBlockMqttData��5$      $
��Left=�5%      $��	10,31,0,0q�5&      $
 Left=�5'      $��Data from sensor : N/A��5(      $	��Top=�5)      $	��500��6%   #   LiveCharts.Wpf.CartesianChart  5*   
   -   5        $"��cartesianChartWaterLevelData��5+      $��	0,52,0,10q�5,      &    LiveCharts.Wpf.Charts.Base.Chart   Series 5-      �� *SeriesCollection+   AxisY 5/         LiveCharts.Wpf.Axis  -   5        $
��Axis��5/         Sections 51          LiveCharts.Wpf.AxisSection     Value$	 8.5Q�52      	   StrokeThickness$	 3Q�6)   
   Stroke
 �#F9D648   Fill 53      �� 54   "   $ #A3A3FF��62    �� Opacity$ .4Q�6B   56        57      $ 4Q�6*      SectionWidth$ 8Q�64      Label$
 Good��6E    58      �� 59   "   $ #CDCDCD��62   $ .4Q�6B   5;        5<      $ 0Q�6*   $ 4Q�64   $	 Bad��6E    5=      �� 5>   "   $ #FF8585��62   $ .4Q�6B   5@      5B      5D      5E      5F      