   M S B A M L   `   `   `  ����A  =WpfApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:WpfApp.ComponentsWpfApp.Components  5   	   5clr-namespace:WpfApp.ViewModelsWpfApp.ViewModels  5   	       WpfApp.SearchRoute   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   6
componentsclr-namespace:WpfApp.Components     5   	   6
viewmodelsclr-namespace:WpfApp.ViewModels     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	     � Title$  Search Route��5
   	    � WindowState$ 	Maximized=�5   	    � WindowStartupLocation$ CenterScreen=�5   	    � 	Resources 5         BoolToVisibilityConverter��%   &	        �� 5   
   6'   5      .��5      � ��5   
   �� 5       �� ImageSource 6   ��     WpfApp.Components.Resource   umbrelas �� Source# Z .+�5   
   �� -   5         ��Name$ MapImage��5      $��Uniform=�5      $��Center=�5      $��Center=�5      ��5   	   ��    default_map_new# Z 	 � Cursor	 5      �� *Cursor+
 � Triggers
 5      :� 5        :� RoutedEvent$ 
MouseEnter��6   .[�5!      �� .��5"      �� .��5#      T�  �� TargetProperty$ Cursor�6<   ..�5$   "   i�  R� KeyTime$ 0:0:0��69    R� Value 6I   �� *Cursor+5%      5&      5'      5(      5*      �� 5-   
   
�������
�������$��1q�5/   	   $��Right=�50   	   $	��Top=�51   	   $��5q�52   	   $	��360��53   	   $	��500��54   	    �� CornerRadius$ 15��55   	    �� Padding$ 10q�56   	   ._�57      �� .+�59      �� $
��Auto=�6   .��5:      �� ��6#   �� *Routes+��5;      �� 5<      .R�5=   "   �� 
���   �$��14(�5>   $   $
��Bold"�5?   $   $��5,2,0,2q�5A   $   ��5@   $   �� 5A   $   5B      5D      5E      �� 5H      -   5         ��Name$ GoButton��5H      $��GO��5I      $	��100��5J      $��30��5K      $��0,0,0,10q�5L      ��5M      �� *GoButtonCommand+y�5N      �� *ShowGoButton+ �� 	Converter# [  �� 5Q      -   5         ��Name$ AttributeComboBox��5Q      $	��150��5T      $��30��5U      ��5R      �� *AvailableAttributes+ �� SelectedItem 5S      �� *SelectedAttribute+y�5V      �� *IsGoButtonClicked+# [  �� 5Y      $��
USE TICKET��6   $	��150��5[      $��5q�5\      $��Center=�5]      ��5Z      �� *UseTicketCommand+y�5^      �� *IsGoButtonClicked+# [  5_      5`      �� 5e   
   -   5         ��Name$ 	PinCanvas��5e      $��Center=�5f      $��Center=�5g       J� IsHitTestVisible .  ��5i      �� *ActualWidth+ �� ElementName$ MapImage����5j      �� *ActualHeight+$ MapImage��5k      �� 5m   
   -   5         ��Name$ InstructionBorder��5m      $��Center=�5n   	   $	��Top=�5o   	   
��� E��$ 10��5q   	   $ 10q�5r   	   $��0,10,0,0q�5s   	   ._�5t      �� -   5         ��Name$ InstructionTextBlock��5t      $��16(�5u      
����  � �� TextAlignment$ Center=�5x      ��5w      �� *InstructionText+5x      5z      �� 5}   
    �� Orientation$ 
Horizontal=�6   $
��Left=�5~      $	��Top=�5      $��	10,50,0,0q�5�      .+�5�      �� -   5        $ ResetButton��5�      $��Reset Selection��5�      $
��10,5q�5�      $��16(�5�      $
��Bold"�5�      
����������#007ACC���#005F99$��1q�5�      ��5�      �� *ResetCommand+��5�      �� 5�       �� 
TargetType" ��6   .�5�      ��  �� Property �@J�Effect �� Value 5�      3  -System.Windows.Media.Effects.DropShadowEffect  5�   "      ShadowDepth$ 3Q�63       
BlurRadius$  6Q�6C   !   Color$
! Gray��6R   "   Opacity$	" 0.3Q�6_   5�      # �� Triggers# 5�      P� 5�      $ P� Property$ �@J�IsMouseOver% P� Value% . . �5�   "   ��  � �� �#005F996?   5�      P� 5�      $ � ��% . . �5�   "   ��  � �� �#004A7C6?   �� 5�   "    �@J�Effect 5�   &     5�   *   $ 0Q�6;   $  0Q�6K   $! Transparent��6Z   5�   #   5�      5�      5�      �� 5�      -   5        $ GenerateRouteButton��5�      $��Generate my route!��5�   	   $
��10,5q�5�   	   $��16(�5�   	   $
��Bold"�5�   	   
����������#007ACC���#005F99$��1q�5�   	   $��10,0,0,0q�5�   	   ��5�   	   �� *GenerateRouteCommand+y�5�   	   �� *IsGenerateRouteButtonVisible+# [  ��5�      �� 5�      " ��6   .�5�      ��  �@J�Effect 5�        5�   "   $ 3Q�63   $  6Q�6C   $
! Gray��6R   $	" 0.3Q�6_   5�      # 5�      P� 5�      $ �@J�IsMouseOver% . . �5�   "   ��  � �� �#005F996?   5�      P� 5�      $ � ��% . . �5�   "   ��  � �� �#004A7C6?   �� 5�   "    �@J�Effect 5�   &     5�   *   $ 0Q�6;   $  0Q�6K   $! Transparent��6Z   5�   #   5�      5�      5�      5�      �� 5�   
   ���#FFFFFF���#007ACC$��1q�5�      $ 5��5�      $��10q�5�      $ 5q�5�      $	��Top=�5�      $
��Left=�5�      ._�5�      �� -	   5        $ CoordinatesTextBlock��5�      
���   �$��14(�5�      $
��Bold"�5�      ��5�      �� *MousePosition+5�      5�      5�      