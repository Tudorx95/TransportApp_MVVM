   M S B A M L   `   `   `  ����A  =WpfApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:WpfAppWpfApp  5      5clr-namespace:WpfApp.ViewModelsWpfApp.ViewModels  5      5clr-namespace:WpfApp.ComponentsWpfApp.Components  5	          WpfApp.Search   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      &localclr-namespace:WpfApp     5      5	viewModelclr-namespace:WpfApp.ViewModels     5      6
componentsclr-namespace:WpfApp.Components     5	        � DataContext  5      '   !WpfApp.ViewModels.SearchViewModel  5   
   .��5      � ��5   
   �� 5       j� Stretch$ UniformToFill=�6b    �� ImageSource 6   ��     WpfApp.Components.Resource   
simple_map �� Source# Z 6b   .+�5   
   �� .+�5      �� -   5         ��Name$ 	LeftImage��5      $	��401��5      $	��562��6     �� Left$ 12��5      
 �� Top$	 100��6%   $
��Fill=�5      y�5      �� *IsLeftImageVisible+��5      �� *LeftImagePath+5      5      � 5!   
   -   5         �Name$ 
ImagePopup��5!      	 � 	StaysOpen	 .  $��Center=�66   
 � HorizontalOffset$
 0��5"       � VerticalOffset$ 0��6%   ��68   �� *IsPopupOpen+.��5#      �� 
���   � J� Opacity$	 0.8Q�6(   ._�5$      �� $	��800��5%      $	��800��6$   $��Center=�5&      $��Center=�65   ��5$      �� *LeftImagePath+5&   5   5'      5(      �� 5+   
   $��1��6   $��Center=�6%   $��Center=�6@   $	��600��6]   .+�5,      �� $��Discover Your Next Ride��6   $��30(�67   $
��Bold"�6E   
���   �$��Center=�5-      $��0,0,0,20q�65   �� 5.      ���#fff �� Padding$ 15q�6'   $	��450��64   $
��0,10q�6@    �� CornerRadius$ 15��6N    J� Effect 5/      3  -System.Windows.Media.Effects.DropShadowEffect  50         Color$
 Gray��6'      
BlurRadius$ 20Q�64      ShadowDepth$ 2Q�6D      Opacity$	 0.3Q�6T   ._�53      � .+�55      �� $)��#Enter location or transport type...��6    $��14(�56       ���#888$	��Top=�6@   $��15,0,0,0q�57       y�58       �� *IsFloatingLabelVisible+�� 5<      $��18(�5=      
������ $��0q�6E   $��Center=�5>      $��10,15,45,15q�69   ��5<      �� *SearchQuery+ �� UpdateSourceTrigger$ PropertyChanged=�5>   9   �� 5A      $��45��6   $��45��6(   ���#4A90E2
�������$��Right=�5B      $��Center=�69   
������  � Cursor$
 Hand��5C   7   $��0,0,10,0q�6E   ��5D      �� *SearchCommand+.��5E      �� $��Segoe MDL2 Assets)�6$   $	����6C   $��20(�6S   5F      5G      5H      �� 5K      $	��450��5M      $��0,5,0,0q�6"   $y�	Collapsed=�5N      ��5K      �� *FilteredSuggestions+ �� SelectedItem 5L      �� *SelectedSuggestion+ �� Mode$ TwoWay=�5N      �� 5R      $��Find path to destination��6   $	��200��5S      $��40��6!   ���#4A90E2
�������$��Center=�5T      $	��Top=�62   $��0,20,0,0q�5U      $
 Hand��6'   ��5V      �� *FindPathCommand+5W      � 5Z   
   $��Right=�6   $��Stretch=�6+   $��2��6G   .+�5[      �� $	��500��6   ���#ccc$��Stretch=�64   $��Stretch=�6P   ._�5]      �� -   5         ��Name$ RouteDisplay��5]       �� Orientation$ Vertical=�6Y   $��10q�6p   y�63   �� *IsRouteVisible+.+�5_      &   System.Windows.Controls.DataGrid     AutoGenerateColumns .  "   VerticalScrollBarVisibility$
 Auto=�5`   ;   $   HorizontalScrollBarVisibility$
 Auto=�5a      $	��300��6D   $	��340��6T   ��5_      �� *StationArrivals+   Columns 5b      0  *System.Windows.Controls.DataGridTextColumn  5c      ,  &System.Windows.Controls.DataGridColumn   Header$ Station Name��61   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6G   �� *StationName+  5d      $ Arrival Times��61    6H   �� *ArrivalTimesDisplay+5f      �� 5i      ���#007ACC$��5q�63   $ 10��6G   ���#F0F0F0$��20q�5j   2   $	��400��6>   $ 10q�6K   ._�5k      r�   r� LoadedBehavior$  Manual=�5l   '   ! r� UnloadedBehavior$
! Stop=�6?   " r� Source" 5k   '   �� *	VideoPath+# r� 
MediaEnded# 5m   '   �� *Media_MediaEnded+5n      5o      5p      5q      5r      5s      