   M S B A M L   `   `   `  ����A  =WpfApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:WpfAppWpfApp  5      5clr-namespace:WpfApp.ComponentsWpfApp.Components  5      +clr-namespace:WpfApp.ModelWpfApp.Model  5	      5clr-namespace:WpfApp.ViewModelsWpfApp.ViewModels  5
          WpfApp.Search   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      &localclr-namespace:WpfApp     5      6
componentsclr-namespace:WpfApp.Components     5      _ [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a3i+http://schemas.microsoft.com/xaml/behaviors  5      &modelclr-namespace:WpfApp.Model  5	      /	viewmodelclr-namespace:WpfApp.ViewModels  5
      .��5      � ��5   
   �� 5        j� Stretch$  UniformToFill=�6b    �� ImageSource 6   ��     WpfApp.Components.Resource   
simple_map �� Source# Z 6b   .+�5   
   �� .+�5      �� -   5         ��Name$ 	LeftImage��5      $	��401��5      $	��562��6   $
��Fill=�5       �� Left$ 12��5      
 �� Top$	 100��6   ��5      �� *LeftImageSource+y�5      �� *LeftImageVisibility+*  $Microsoft.Xaml.Behaviors.Interaction   Triggers 5      +  %Microsoft.Xaml.Behaviors.EventTrigger  5         	EventName$ MouseLeftButtonUp��6%   *  $Microsoft.Xaml.Behaviors.TriggerBase	   Actions.	 5      2  ,Microsoft.Xaml.Behaviors.InvokeCommandAction  
   Command
 60   �� *OpenPopupCommand+5      5!      5$      � 5'   
   -   5         �Name$ 
ImagePopup��5'       � 	StaysOpen .  $��Center=�5*       � HorizontalOffset$ 0��5+       � VerticalOffset$ 0��6   ��5(      �� *IsPopupOpen+ �� Mode$ TwoWay=�.��5,      �� 
���   � J� Opacity$	 0.8Q�6(   ._�5-      �� $	��800��5.      $	��800��6   $��Center=�5/      $��Center=�6-   ��5-      �� *LeftImageSource+z�50      �� 51       �� ScaleX$ 1Q�6)    �� ScaleY$ 1Q�64   53      54      55      �� 59   
   $��1��6   $��Center=�6%   $��Center=�6@   $	��600��6]   .+�5;      �� $��Discover Your Next Ride��6   $��30(�67   $
��Bold"�6E   
���   �$��Center=�5<      $��0,0,0,20q�61   �� 5>      ���#fff �� Padding$ 15q�6'   $	��450��64   $
��0,10q�6@    �� CornerRadius$ 15��6N    J� Effect 5?      3  -System.Windows.Media.Effects.DropShadowEffect  5@         Color$
 Gray��6'      
BlurRadius$ 20Q�64      ShadowDepth$ 2Q�6D      Opacity$	 0.3Q�6T   ._�5C      � .+�5D      �� -   5         ��Name$ FloatingLabel��5D       $)��#Enter location or transport type...��67   $��14(�5E      ���#888$	��Top=�64   $��15,0,0,0q�5F      $ 1Q�5H      y�5G      �� *FloatingLabelVisibility+z�5I      T� 5J       T� Y$ 15Q�61   5L      �� 5N      -   5         ��Name$ SearchTextBox��5N      $��18(�5P      
������ $��0q�5R      $��Center=�5S      $��10,15,45,15q�5T      ��5O      �� *
SearchText+ �� UpdateSourceTrigger$ PropertyChanged=�5T      �� 5W      $��45��6   $��45��6(   ���#4A90E2
�������$��Right=�5X      $��Center=�65   
������  � Cursor$
 Hand��5Y   3   $��0,0,10,0q�6A   ��5Z      �� *SearchCommand+.��5[      �� $��Segoe MDL2 Assets)�6$   $	����6C   $��20(�6S   5\      5]      5^      �� 5`      -   5         ��Name$ SuggestionsListBox��5`      ��5a      �� *FilteredSuggestions+  �� SelectedItem  5b      �� *SelectedSuggestion+$ TwoWay=��� 5f      $��Find path to destination��6   $	��200��5g      $��40��5h      ���#4A90E2
�������$��Center=�5k      $	��Top=�5l      $��0,20,0,0q�5m      $
 Hand��5n      ��5o      �� *OpenSearchRouteCommand+5q      � 5s   
   $��Right=�6   $��Stretch=�6+   $��2��6G   .+�5u      �� $	��500��6   ���#ccc$��Stretch=�64   $��Stretch=�6P   ._�5v      �� -   5        ! ��Name$! RouteDisplay��5v      " �� Orientation$" Vertical=�6a   $��10q�6x   y�63   �� *RouteDisplayVisibility+.+�5x      &   System.Windows.Controls.DataGrid  -   5        #  Name$# StationsDataGrid��5x      $   AutoGenerateColumns$ .  "%   VerticalScrollBarVisibility$
% Auto=�6U   $&   HorizontalScrollBarVisibility$
& Auto=�5y      $	��300��6@   $	��340��6P   '   AlternatingRowBackground' �#f9f9f9(   RowBackground( �#ffffff)   GridLinesVisibility$
) None=�5}      *   HeadersVisibility$* Column=�5~      $��0q�5      $��Segoe UI)�5�      $��14(�5�      ��5{      �� *
Stations++ � 	Resources+ 5�      =  7System.Windows.Controls.Primitives.DataGridColumnHeader, �� 
TargetType- �� Property. �� Value*	  $System.Windows.Controls.DataGridCell��%m  '        '	  �     �� 5�      ",  6$   .�5�   "   �� - � ��. �#007ACC6?   �� 5�   "   - � ��
. �����6?   �� 5�   "   - � ��$
. Bold"�6?   �� 5�   "   - � ��$
. 10,5q�6<   5�      �� 5�      ", 	 6$   .�5�   "   �� - � ��$. 10q�6<   �� 5�   "   - � ��$. Stretch=�6H   �� 5�   "   - � ��$. Center=�6F   5�      5�      /   Columns/ 5�      0
  *System.Windows.Controls.DataGridTextColumn
  5�      ,  &System.Windows.Controls.DataGridColumn0   Header$0 Station Name��61   1  +System.Windows.Controls.DataGridBoundColumn1   Binding1 6G   �� *StationName+
  5�      $0 Arrival Times��61   1 6H   �� *ArrivalTimesDisplay+5�      �� 5�      ���#007ACC$��5q�5�      $ 10��5�      ���#F0F0F0$��20q�5�      $	��400��5�      $ 10q�5�      ._�5�      r� -   5        2 r�Name$2 Media��5�   '   3 r� LoadedBehavior$3 Manual=�5�      4 r� UnloadedBehavior$
4 Stop=�5�      $	��550��5�      $	��550��5�      $��Center=�5�      $��Stretch=�5�      5 r� Source5 5�      �� *VideoSource+ 5�        5�   "   $ 
MediaEnded��61   .	 5�   &     
 6<   �� *MediaEndedCommand+6   CommandParameter6 5�   $   �� 7 �� ElementName$7 Media��5�   #     5�   "   $ Loaded��61   .	 5�   &     
 6<   �� *MediaStartCommand+6 5�   $   �� $7 Media��5�   #   5�      5�      5�      5�      5�      5�      5�      