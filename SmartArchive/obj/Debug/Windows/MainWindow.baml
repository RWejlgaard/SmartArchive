   M S B A M L   `   `   `  ����T  PMahApps.Metro, Version=1.2.4.0, Culture=neutral, PublicKeyToken=f4fb5a3c4d1e5b4fV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls  5       SmartArchive%   SmartArchive.Windows.MainWindow   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Pcontrols;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro     5      U QMaterialDesignThemes.Wpf, Version=2.1.0.657, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5        � Title$  Smart Archive��5      $	��600��6-   $	��800��6:    � WindowStartupLocation$ CenterScreen=�5       � Icon$F @/SmartArchive;component/Assets/Icons/icon_32x32-experimental.png��5      $2��,/SmartArchive;component/Assets/#Futura Bk BT)�5	      $��14.667(�6Q      WindowTitleColorBrush(   "MahApps.Metro.Controls.MetroWindow   	GlowBrush# �   5
      $��1q�6K    � 	Resources 5        ArchiveEmptyButton �� 
TargetType �� Property �� Value �� 
TargetType	 �� Padding
 �� Triggers P� Property P� Value �� 
TargetName��%-  &	       �� 5   
   " ��6+   .�5      ��  �@�OverridesDefaultStyle . 66   �� 5       � �� 5      �� 5      " ��6&   .R�5      �� $��border��6!   $��0q�5   !   $	 0q�5   !   
������ 
������ ._�5      �� $��Center=�6/   $��Center=�6L   5      
 5      P� 5       �@J�IsMouseOver . . �5   "   �� $ border��6)    � ��
 ���� 6T   5      P� 5       � �� . . �5   "   �� $ border��6)    � �� �	#FFCBECF76S   5      5!      5#      5$      5%         Flyouts 5(      +   %MahApps.Metro.Controls.FlyoutsControl  5)   
   .@�5*      #   MahApps.Metro.Controls.Flyout  -   5          Name$ 
FlyOutMenu��5*         Position$
 Left=�62   $	��190��6B   $��0,15,0,0q�6N      TitleVisibility$ 	Collapsed=�5+         CloseButtonVisibility$ 	Collapsed=�6:   .��5,      � -   5         �Name$ 
FlyOutGrid��5,      $��	0,-35,0,0q�6+    � RowDefinitions 5-      �� 5.      $
��Auto �6(   �� 5/      $��* �6(   �� 50      $��1 �6(   �� 51      $
��Auto �6(   �� 52      $
��Auto �6(   .+�56      d� -   5         d�Name$ FlyOutCloser��56   #    ' #MaterialDesignHamburgerToggleButton#���  57   #   $��Right=�58   #   $	��Top=�6?   #���   6W   �� 59      -   5         ��Name$ FilterLabel��59      $��Filter by type��61   $��0��6J   $��21.333(�6W   $
��Left=�5:      $��Bottom=�67   �� 5=      -   5         ��Name$ FileTypeSelection��5=      $��1��6:   $��Stretch=�5>      $��Stretch=�6D   
���   �$��0q�5?   _   ��5=   G   ��  �� Path$ FileTypeList���5?      Z� ��6I   Z� ��5@      �� 5A      " ��6$   .�5B   "   ��  � |� .  6>   5C      ��5E      �� 5F      .R�5G   "   �� $��Stretch=�6-   $��Stretch=�6K   .+�5H   &   ��  d� 	IsChecked$
 TrueY�6J   ��6/   �� $ .�6J   5I   #   5J      5L      �� 5O      $��2��6#   $��Stretch=�60   {�.  
���   �5P   5   � 5S      -   5        $ UserSection��5S      $��3��60    � ColumnDefinitions 5T      �� 5U      $
��Auto �6/   �� 5V      $
��Auto �6/   .+�5Z      �� $��0��6    $@��:/SmartArchive;component/Assets/Generic Profile Picture.png��60   $��32��5[       $��32��6+   $��10,5,0,5q�67   �� 5\      $��1��6    $��Center=�6M   $
��Bold"�5]       $��16(�62   ��5\   0   �� *
Username+5]   2   5^      �� 5a      $��4��6!   $��0,0,0,1q�6.   .+�5b      �� $��Account��6!     MaterialDesignFlatButton#���  63   $
��Left=�5c   !   
���   �6C   �� 5d      $��Settings��6!   #���  64   $
��Left=�5e   !   
���   �6C   �� 5f      $��About��6!   #���  61   $
��Left=�5g   !   
���   �6C   �� 5h      -   5         ��Name$ 
SignOutBtn��5h   !   $��Sign out��65   #���  5i   !   $
��Left=�6T   
���   �5j   4   5k      5m      5n      5o      .��5s      � -   5        $ MainGrid��5s       5t   
   �� 5u      $
��Auto �6   �� 5v      $��* �6    5x   
   �� 5y      $��40 �6   �� 5z      $��1 �6   �� 5{      $��* �6   .+�5   
   d� -	   5        $ FlyOutOpener��5      $��0��6J   $��0��6W   #���  5�      $	��Top=�6U   $��Center=�5�      #���   64   �� 5�   
   $��0��6   $��2��6$   $��1��65   $��Stretch=�6E   {�.  
���   �5�   )   �� 5�   
   -
   5        $ FileView��5�      $��0��6%   $��2��62   $��2��6C   $��0q�5�   C   ��6   �� $ FileListCollection���5�      �� 5�      .R�5�      ��  �� Orientation$ 
Horizontal=�6!   .+�5�      � $��56��6    5�      �� 5�   "   $��* �60   �� 5�   "   $
��Auto �60    5�      �� 5�   "   $��64 �63   �� 5�   "   $
��Auto �63   .+�5�      �� $��0��6$   $��2��61   $��0��6B   $��86��6R   $��64��6a   $��3,5,0,5q�5�   $   $��Center=�5�   E   $��Stretch=�5�   $   ��5�   $   �� $ FileIcon�5�   $   �� 5�      $��0��6(   $��1��65   $��7,11,0,0q�6E   $	��Top=�5�   G   ��6(   �� $ FileName�6G   �� 5�      $��1��6(   $��1��65   $��7,0,0,11q�6E   $��Bottom=�5�   G   ��6(   �� $ FileSize�6G   5�      5�      5�      5�      �� 5�   
   -   5        $ ArchiveEmptyBtn��5�      $��0��6*   $��2��67   $��2��6H   #��[ 6X   ��5�      �� 5�      $��0,0,5,0q�6   .+�5�      �� $��Archive is empty��6    
�������$��20(�6J   $��Center=�6X   $��Center=�5�       �� 5�      $��Click here to add files.��6    
�������$��Center=�6R   $��Center=�5�       5�      5�      � 5�   
   $��	0,0,25,25q�6   $��1��6"   $��2��6/   $��Bottom=�6?   $��Right=�6Z    5�      �� 5�      $
��Auto �6#   �� 5�      $
��Auto �6#   .+�5�      �� -   5        $ FloatActionLabel��5�      $�� ��6.   $��0��69   $��Right=�6I   $��Center=�6e   �� 5�      -   5        $ FloatingActionBtn��5�      $��1��60   $��Right=�5�      $��Bottom=�61    & "MaterialDesignFloatingActionButton#���  5�      .��5�      '  !MaterialDesignThemes.Wpf.PopupBox  -   5         - )MaterialDesignMultiFloatingActionPopupBox#���  5�   *      	PopupMode$ Click=�5�   &   $��1��68   $��2��6E      PlacementMode$ TopAndAlignRightEdges=�5�   &   $��56��6L   $��56��6X    ^� 	Placement$ Right=�5�   &     � ToolTip$  Actions��6G   $��Center=�5�   \   $��Center=�6y   !   PopupContent.! 5�      � $��0,0,0,2q�6    5�      �� 5�      $
��Auto �6,   �� 5�      $
��Auto �6,   �� 5�      $
��Auto �6,    5�      �� 5�      $
��Auto �6/   �� 5�      $��4 �6/   �� 5�      $
��Auto �6/   .+�5�      �� $	��Add��6    $��0��6.   $��0��6;   $��Right=�6K   $��Center=�6g   �� 5�      -   5        $ 	AddAction��5�   !   $��0��64   $��2��6A   $��45��6Q   $��45��6\   $	��0,6q�6h   #���  5�   !   .��5�      '  !MaterialDesignThemes.Wpf.PackIcon  �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.1.0.657, Culture=neutral, PublicKeyToken=null]]"   Kind$" 
PlusCircle=�66   $��24��6H   $��24��6T   5�      �� 5�      $��Remove��6    $��1��61   $��0��6>   $��Right=�6N   $��Center=�6j   �� 5�      -   5        $ RemoveAction��5�   !   $��1��67   $��2��6D   $��45��6T   $��45��6_   $	��0,6q�6k   #���  5�   !   .��5�        $" MinusCircle=�66   $��24��6I   $��24��6U   5�      �� 5�      $��Settings��6    $��2��63   $��0��6@   $��Right=�6P   $��Center=�6l   �� 5�      -   5        $ SettingsAction��5�   !   $��2��69   $��2��6F   $��45��6V   $��45��6a   $	��0,6q�6m   #���  5�   !   .��5�        $" Settings=�66   $��24��6F   $��24��6R   5�      5�      5�      5�      5�      5�      5�      