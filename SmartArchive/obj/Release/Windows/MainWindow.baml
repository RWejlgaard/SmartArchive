   M S B A M L   `   `   `  ���� T  PMahApps.Metro, Version=1.2.4.0, Culture=neutral, PublicKeyToken=f4fb5a3c4d1e5b4fV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls   SmartArchive%   SmartArchive.Windows.MainWindow   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Pcontrols;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro       � Title$  Smart Archive��$	��600��$	��800�� � WindowStartupLocation$ CenterScreen=� � Icon$F @/SmartArchive;component/Assets/Icons/icon_32x32-experimental.png��$2��,/SmartArchive;component/Assets/#Futura Bk BT)�$��14.667(�(   "MahApps.Metro.Controls.MetroWindow   	GlowBrush
 �   �$��1q�   Flyouts +   %MahApps.Metro.Controls.FlyoutsControl  .@�#   MahApps.Metro.Controls.Flyout  -     Name$ 
FlyOutMenu��   Position$
 Left=�$	��190��$��0,15,0,0q�   TitleVisibility$ 	Collapsed=�   CloseButtonVisibility$ 	Collapsed=�.��� -   	 �Name$	 
FlyOutGrid��$��	0,-35,0,0q�
 � RowDefinitions
 �� $
��Auto ��� $��* ��� $	��2.5 ��� $
��Auto ��� $
��Auto �.+�d� -    d�Name$ FlyOutCloser�� '  #MaterialDesignHamburgerToggleButton#���   $��Right=�$	��Top=��� -    ��Name$ FilterLabel��$��Filter by type��$��0��$��21.333(�$
��Left=�$��Bottom=��� -    ��Name$ FileTypeSelection��$��1��$��Stretch=�$��Stretch=�
���   �����  �� Path$ FileTypeList���Z� ��Z� ����  �� 
TargetType" ��.���  �� Property � |� �� Value .  ���� .R��� $��Stretch=�$��Stretch=�.+���  d� 	IsChecked$
 TrueY����� $ .��� $��2��$��Stretch=�{�.  ���	#7F000000� -   $	 UserSection��$��3�� � ColumnDefinitions �� $
��Auto ��� $
��Auto �.+��� $��0��$@��:/SmartArchive;component/Assets/Generic Profile Picture.png��$��32��$��32��$��10,5,0,5q��� $��1��$��Center=�$
��Bold"�$��16(����� *
Username+�� $��4��$��0,0,0,1q�.+��� $��Account��  MaterialDesignFlatButton#���  $
��Left=�
���   ��� $��Settings��#���  $
��Left=�
���   ��� $��About��#���  $
��Left=�
���   ��� -    ��Name$ 
SignOutBtn��$��Sign out��#���  $
��Left=�
���   �.��� -   $	 MainGrid��
 �� $
��Auto ��� $��* � �� $��40 ��� $	��2.5 ��� $��* ��� $	��150 �.+�d� -	   $ FlyOutOpener��$��0��$��0��#���   $	��Top=�$��Center=��� $��0��$��2��$��1��$	��2.5��$��Stretch=�{�.  ���	#7F000000