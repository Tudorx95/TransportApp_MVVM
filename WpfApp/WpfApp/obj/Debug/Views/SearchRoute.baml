   M S B A M L   `   `   `  ����A  =WpfApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:WpfApp.ComponentsWpfApp.Components  5   	   5clr-namespace:WpfApp.ViewModelsWpfApp.ViewModels  5   	       WpfApp.SearchRoute   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   6
componentsclr-namespace:WpfApp.Components     5   	   6
viewmodelsclr-namespace:WpfApp.ViewModels     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	     � Title$  Search Route��5
   	    � WindowState$ 	Maximized=�5   	    � WindowStartupLocation$ CenterScreen=�5   	   .��5      � ��5   
   �� 5       �� ImageSource 6   ��     WpfApp.Components.Resource   umbrelas �� Source# Z .+�5   
   �� -   5         ��Name$ MapImage��5      $��Uniform=�5      $��Center=�5      $��Center=�5      ��5   	   ��    default_map_new# Z  � Cursor 5      �� *Cursor+	 � Triggers	 5      :� 5      
 :� RoutedEvent$
 
MouseEnter��6   .[�5      �� .��5       �� .��5!      T�  �� TargetProperty$ Cursor�6<   ..�5"   "   i�  R� KeyTime$ 0:0:0��69    R� Value 6I   �� *Cursor+5#      5$      5%      5&      5(      �� 5+   
   
�������
�������$��1q�5-   	   $��Right=�5.   	   $	��Top=�5/   	   $��5q�50   	   $	��360��51   	   $	��500��52   	    �� CornerRadius$ 15��53   	    �� Padding$ 10q�54   	   ._�55      �� $
��Auto=�6   .��56      �� ��6   �� *Routes+��57      �� 58      .R�59      �� 
���   �$��14(�5:       $
��Bold"�5;       $��5,2,0,2q�5=       ��5<       �� 5=       5>      5@      5A      5B      �� 5G   
   -   5         ��Name$ 	PinCanvas��5G      $��Center=�5H      $��Center=�5I       J� IsHitTestVisible .  ��5K      �� *ActualWidth+ �� ElementName$ MapImage����5L      �� *ActualHeight+$ MapImage��5M      �� 5O   
   -   5         ��Name$ InstructionBorder��5O      $��Center=�5P   	   $	��Top=�5Q   	   
��� E��$ 10��5S   	   $ 10q�5T   	   $��0,10,0,0q�5U   	   ._�5V      �� -   5         ��Name$ InstructionTextBlock��5V      $��16(�5W      
����  � �� TextAlignment$ Center=�5Z      ��5Y      �� *InstructionText+5Z      5\      �� 5_   
    �� Orientation$ 
Horizontal=�6   $
��Left=�5`      $	��Top=�5a      $��	10,50,0,0q�5b      .+�5d      �� -   5         ��Name$ ResetButton��5d      $��Reset Selection��5e      $
��10,5q�5f      $��16(�5g      $
��Bold"�5h      
����������#007ACC���#005F99$��1q�5l      ��5m      �� *ResetCommand+��5n      �� 5o       �� 
TargetType" ��6   .�5p      ��  �� Property �@J�Effect �� Value 5q      3  -System.Windows.Media.Effects.DropShadowEffect  5r   "      ShadowDepth$ 3Q�63      
BlurRadius$ 6Q�6C      Color$
 Gray��6R      Opacity$	 0.3Q�6_   5t       �� Triggers 5u      P� 5v        P� Property  �@J�IsMouseOver! P� Value! . . �5w   "   ��  � �� �#005F996?   5x      P� 5y        � ��! . . �5z   "   ��  � �� �#004A7C6?   �� 5{   "    �@J�Effect 5|   &     5}   *   $ 0Q�6;   $ 0Q�6K   $ Transparent��6Z   5   #   5�      5�      5�      �� 5�      -   5        $ GenerateRouteButton��5�      $��Generate my route!��5�   	   $
��10,5q�5�   	   $��16(�5�   	   $
��Bold"�5�   	   
����������#007ACC���#005F99$��1q�5�   	   $��10,0,0,0q�5�   	   ��5�   	   �� *GenerateRouteCommand+��5�      �� 5�      " ��6   .�5�      ��  �@J�Effect 5�        5�   "   $ 3Q�63   $ 6Q�6C   $
 Gray��6R   $	 0.3Q�6_   5�       5�      P� 5�        �@J�IsMouseOver! . . �5�   "   ��  � �� �#005F996?   5�      P� 5�        � ��! . . �5�   "   ��  � �� �#004A7C6?   �� 5�   "    �@J�Effect 5�   &     5�   *   $ 0Q�6;   $ 0Q�6K   $ Transparent��6Z   5�   #   5�      5�      5�      5�      �� 5�   
   ���#FFFFFF���#007ACC$��1q�5�      $ 5��5�      $��10q�5�      $ 5q�5�      $	��Top=�5�      $
��Left=�5�      ._�5�      �� -   5        $ CoordinatesTextBlock��5�      
���   �$��14(�5�      $
��Bold"�5�      ��5�      �� *MousePosition+5�      5�      5�      