   M S B A M L   `   `   `  ����A  =WpfApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:WpfApp.ComponentsWpfApp.Components  5   	   5clr-namespace:WpfApp.ViewModelsWpfApp.ViewModels  5   	       WpfApp.SearchRoute   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   6
componentsclr-namespace:WpfApp.Components     5   	   .vmclr-namespace:WpfApp.ViewModels     5   	     � Title$  Search Route��5	   	    � WindowState$ 	Maximized=�5
   	    � WindowStartupLocation$ CenterScreen=�5   	    � DataContext 5      ,   &WpfApp.ViewModels.SearchRouteViewModel  5   
   .��5      � ��5   
   �� 5       �� ImageSource 6   ��     WpfApp.Components.Resource   umbrelas �� Source# Z .+�5   
   �� -   5         ��Name$ MapImage��5      $��Uniform=�5      $��Center=�5      $��Center=�5       � Cursor$
 Hand��5      ��5      �� 	   default_map_new# Z	 
 J� InputBindings
 5      d� 5       d� Gesture$ 	LeftClicka�5        �� Command 5      �� *MapMouseDownCommand+ �� CommandParameter 5      ��  �� RelativeSource �� *Self+ �� Path$ MousePosition�5       5"      �� 5%   
   
�������
�������$��1q�67   $��Right=�5&      $	��Top=�6-   $��5q�5'      $	��360��6   $	��500��6(    �� CornerRadius$ 15��5(      5)      �� 5,   
   -   5         ��Name$ 	PinCanvas��5,      $��Center=�5-      $��Center=�5.       J� IsHitTestVisible .  ��50      �� *ActualWidth+ �� ElementName$ MapImage����51      �� *ActualHeight+$ MapImage��52      �� 55   
   -   5         ��Name$ InstructionBorder��55      $��Center=�56      $	��Top=�57      
��� E��$ 10��59       �� Padding$ 10q�5:      $��0,10,0,0q�5;      ._�5<      �� -   5         ��Name$ InstructionTextBlock��5<      $��16(�5=      
����  �$*��$Please select the starting location.��5?       �� TextAlignment$ Center=�5@      5A      �� 5D   
    �� Orientation$ 
Horizontal=�6   $
��Left=�5E      $	��Top=�5F      $��	10,50,0,0q�5G      .+�5I      �� -   5         ��Name$ ResetButton��5I      $��Reset Selection��5J      $
��10,5q�5K      $��16(�5L      $
��Bold"�5M      
����������#007ACC���#005F99$��1q�5Q      ��5R      �� *ResetCommand+��5S      �� 5T       �� 
TargetType" ��6   .�5U      ��  �� Property �@J�Effect �� Value 5V      3  -System.Windows.Media.Effects.DropShadowEffect  5W   "      ShadowDepth$ 3Q�63      
BlurRadius$ 6Q�6C      Color$
 Gray��6R       Opacity$	  0.3Q�6_   5Y      ! �� Triggers! 5Z      P� 5[      " P� Property" �@J�IsMouseOver# P� Value# . . �5\   "   ��  � �� �#005F996?   5]      P� 5^      " � ��# . . �5_   "   ��  � �� �#004A7C6?   �� 5`   "    �@J�Effect 5a   &     5b   *   $ 0Q�6;   $ 0Q�6K   $ Transparent��6Z   5d   #   5e      5g      5i      �� 5l      -   5        $ GenerateRouteButton��5l      $��Generate my route!��5m      $
��10,5q�5n      $��16(�5o      $
��Bold"�5p      
����������#007ACC���#005F99$��1q�5t      $y�	Collapsed=�5u      $��10,0,0,0q�5v      ��5w      �� *GenerateRouteCommand+��5x      �� 5y      " ��6   .�5z      ��  �@J�Effect 5{        5|   "   $ 3Q�63   $ 6Q�6C   $
 Gray��6R   $	  0.3Q�6_   5~      ! 5      P� 5�      " �@J�IsMouseOver# . . �5�   "   ��  � �� �#005F996?   5�      P� 5�      " � ��# . . �5�   "   ��  � �� �#004A7C6?   �� 5�   "    �@J�Effect 5�   &     5�   *   $ 0Q�6;   $ 0Q�6K   $ Transparent��6Z   5�   #   5�      5�      5�      5�      �� 5�   
   -   5        $��RouteDisplayPanel��5�      $��	10,10,0,0q�6.   $	��Top=�6A   $��Right=�6Y   5�      �� 5�   
   ���#FFFFFF���#007ACC$��1q�5�      $ 5��5�      $��10q�5�      $ 5q�5�      $	��Top=�5�      $
��Left=�5�      ._�5�      �� -   5        $ CoordinatesTextBlock��5�      
���   �$��14(�5�      $
��Bold"�5�      ��5�      �� *CoordinatesDisplay+5�      5�      5�      