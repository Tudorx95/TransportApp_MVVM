   M S B A M L   `   `   `  ����A  =WpfApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:WpfApp.ComponentsWpfApp.Components  5      5clr-namespace:WpfApp.ViewModelsWpfApp.ViewModels  5          WpfApp.NavigationBar   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      6
componentsclr-namespace:WpfApp.Components     5      1localclr-namespace:WpfApp.ViewModels     5      $��30��5      $��Stretch=�6   
����  �  � DataContext  5      .   (WpfApp.ViewModels.NavigationBarViewModel  5	   
   .��5      ]� $��Stretch=�6   $	��Top=�6.   ��. .+�5   
   ��  �� Orientation$ 
Horizontal=�6   $��Center=�6.   $��Center=�6K   .+�5      �� $	��123��6,   $��24��68   $��5q�6D   ��6   �� *Logo+6D   �� 5      -   5         ��Name$ 
HomeButton��5      $
��Home��6)   $	��100��68   $
��Home��6h   $��5q�6�   ��6D   �� *NavigateCommand+6�   �� 5      -   5        $ LoginButton��5      $��
Log in/out��6+   $	��100��6@   $��Login��6p   $��5q�6�   ��6L   �� *NavigateCommand+6�   �� 5      -   5        $ SearchButton��5      $��Search for Transport��6+   $	��150��6J   $��Search��6z   $��5q�6�   ��6V   �� *NavigateCommand+6�   5      5      5      