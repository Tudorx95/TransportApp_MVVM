   M S B A M L   `   `   `  ����A  =WpfApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:WpfApp.ViewModelsWpfApp.ViewModels  5          WpfApp.Register   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      5	ViewModelclr-namespace:WpfApp.ViewModels     5        � DataContext  5
      )   #WpfApp.ViewModels.RegisterViewModel  5   
   .��5      � .+�5   
   � 
�������$	��412��6&   $	��450��62   $��Center=�6?   $��Center=�6Z   .+�5      �� $��Center=�6   $��Center=�64   $��20q�6Q   .+�5      �� $��Register��6   $��24(�6,   $��Center=�6:   $��0,0,0,20q�6W   �� 5      $��
First Name��6   $
��Bold"�6.   $��0,0,0,0q�6@   �� 5      $	��198��6Z   $��18��6f   $��0,0,0,10q�6r   ��6   �� *	FirstName+ �� UpdateSourceTrigger$ PropertyChanged=�6r   �� 5      $��	Last Name��6   $
��Bold"�6-   $��0,0,0,0q�6?   �� 5      $	��202��6Y   $��20��6e   $��0,0,0,10q�6q   ��6   �� *
LastName+$ PropertyChanged=�6q   �� 5      $��Email��6   $
��Bold"�6)   $��0,0,0,0q�6;   �� 5      $	��201��6V   $��21��6b   $��0,0,0,10q�6n   ��6   �� *Email+$ PropertyChanged=�6n   �� 5       $��Username��6   $
��Bold"�6,   $��0,0,0,0q�6>   �� 5!      $��0,0,0,10q�6Y   ��6   �� *
Username+$ PropertyChanged=�6Y   �� 5$      $��Password��6   $
��Bold"�6,   $��0,0,0,0q�6>   �� 5%      $	��202��6Y   $��21��6e   $��0,0,0,10q�6q   ��6   �� *
Password+$ PropertyChanged=�6q   �� 5&      $��Password Again��6   $
��Bold"�62   $��0,0,0,0q�6D   �� 5'      $	��202��6`   $��22��6l   $��0,0,0,10q�6x   ��6   �� *ConfirmPassword+$ PropertyChanged=�6x   �� 5*      $��Register��6   $	��200��6,   $��30��68   ��6D   �� *RegisterCommand+�� 5-      $��Back to Login��6   $	��200��61   $��30��6=   $��0,10,0,0q�6p   ��6I   �� *BackToLoginCommand+6p   5.      5/      50      51      