   M S B A M L   `   `   `  ����A  =WpfApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:WpfAppWpfApp  5   	   5clr-namespace:WpfApp.ViewModelsWpfApp.ViewModels  5   	       WpfApp.Complains_Request   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   &localclr-namespace:WpfApp     5   	   5	ViewModelclr-namespace:WpfApp.ViewModels     5   	     � Title$  Complain Request��5	   	   $	��484��6"   $	��806��6/    � DataContext 5      2   ,WpfApp.ViewModels.Complains_RequestViewModel  5   
   .��5      � $��20,20,27,13q�6   
����ح�.+�5   
   �� $��Complain Request��6   $��24(�6,   $
��Bold"�6:   $��Center=�6L   $��	0,20,0,40q�6i   �� 5   
   $+��%Select the service to complain about:��6   $��Center=�6A   $	��Top=�6^   $��0,70,0,0q�6v   �� 5   
   $	��300��6]   $��Center=�6i   $��0,100,0,273q�6�   ��6   �� *
Services+ �� SelectedItem 64   �� *SelectedService+6�   �� 5   
   $��Enter your complaint:��6   $��Center=�61   $	��Top=�6N   $��	0,150,0,0q�6f   �� 5   
   $	��600��60   $	��150��6<   $��	0,180,0,0q�6I   $��Center=�6\   $	��Top=�6y    �� AcceptsReturn .  �� TextWrapping$
 Wrap=�6�   $��16(�6�   ��6   �� *ComplainText+6�   �� 5   
   $��Send Complaint��6   $	��200��6*   $��21��66   $
��Left=�6B   $��Bottom=�6]   $��
278,0,0,19q�6x   ��6�   �� *SubmitCommand+5      5      