   M S B A M L   `   `   `  ����G  CSmartArchive, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:SmartArchiveSmartArchive  5      &     SmartArchive.Windows.LoginWindow   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      ,localclr-namespace:SmartArchive     5      T PMahApps.Metro, Version=1.2.4.0, Culture=neutral, PublicKeyToken=f4fb5a3c4d1e5b4f;controls,http://metro.mahapps.com/winfx/xaml/controls  5      $	��155��5   (     � Title$  Login��5	      $	��400��6%   $	��400��62    � 
ResizeMode$ NoResize=�5
       � WindowStartupLocation$ CenterScreen=�6-   $2��,/SmartArchive;component/Assets/#Futura Bk BT)�5      $��14.667(�6Q      WindowTitleColorBrush(  "MahApps.Metro.Controls.MetroWindow   	GlowBrush# �   5      $��1q�6K   .��5      � -   5         �Name$ MainGrid��5      $��Center=�6   $	��155��6:    � RowDefinitions 5   
   �� 5      $��20 �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��20 �6   .+�5   
   �� $A��;/SmartArchive;component/Assets/Icons/icon_256x256-plain.png��6   $��1��6U   �� 5   
   $��2��6   $��Smart Archive��6   $��22.667(�65   $2��,/SmartArchive;component/Assets/#Futura Bk BT)�5      $��
0,-10,0,12q�5      $��Center=�6$   �� 5"   
   ���#2196f3$	��0.5q�6'    �� CornerRadius$ 2��6=   $��3��6N   $��0,0,0,0q�6[   ._�5#      �� -   5         ��Name$ UsernameInput��5#      $��Username...��6-   
������ $��Italic$�6Z   $��Stretch=�5$      $��3,0,0,0q�5%      6L   5&      �� 5'   
   ���#2196f3$	��0.5q�6'   $ 2��6=   $��4��6N   $��0,5,0,3q�6[   ._�5(      G� -   5         G�Name$ PasswordInput��5(      	 G� Password$	 Password��61   
������ $��Italic$�6_   $��Stretch=�5)      $��3,0,0,0q�5*      5+      5,      �� 5/   
   -   5        
 ��Name$
 RememberCheckBox��5/      $��5��6-   $��Remember me��6:   �� 52   
   -   5         ��Name$ LoginBtn��52      $��6��6#   $��30��60   $��Sign in / Register��6<   $��0,10,0,0q�53      $��0q�6#   54      56      