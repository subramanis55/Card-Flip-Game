   M S B A M L   `   `   `  ���� C  ?CardFlip, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:CardFlip.UserControls.CommonCardFlip.UserControls.Common  7    1LucidDesk.UserControls.Common.NotificationControl   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     <local*clr-namespace:CardFlip.UserControls.Common       � WindowStyle$
  None=� � WindowStartupLocation$ Manual=� � ShowInTaskbar .   � Title$ NotificationControl�� � AllowsTransparency . 
������ $	��160��$	��380��.��� -   $��MainGrid��   SubColorBrush#��[   � RowDefinitions �� $��35 ��� $��* ��� $��50 ��� $��7 �.+�]� $��0������ *
ThemeBrush+.+��� -   $��
HeaderText�� �� Padding$ 10q�
�������$��Medium"�$��18(�Information�� -   $��40��$��Right=�  CloseButton#��[  � ToolTip _� $��Close��.��F� $��Stretch=�$��14��$��14��$��Stretch=�
�������$	��1.5�� 
 Cancel#��[ � $��1��.+��� $��Center=�$��15q�.+��� -   $��MessageText��$��0 0 0 5q�$
��Wrap=�
�������$��17(�$��SemiBold"�$��Center=�$��Center=�hello� $��2�� � ColumnDefinitions �� $��* ��� $��* �.+��� $��0��._��� -   $��Reject��$��16(�$��Center=�$��1q�
�������$��Reject��
���   �
�������  NormalButton#��[ $��35 0 0 0q�$
��Left=�$	��125��$��35���� $��1��._��� -   $��Accept��$��16(�$��Center=�$��Accept��#��[ $��0 0 35 0q�$	��125��$��35������ *
ThemeBrush+�� -   $��IncreaseLine��	 �� CornerRadius$	 2��$
��Left=�$��10��$��3������ *
ThemeBrush+