   M S B A M L   `   `   `  ���� C  ?CardFlip, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:CardFlip.UserControlsCardFlip.UserControls  '    !LucidDesk.UserControls.MessageBox   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5local#clr-namespace:CardFlip.UserControls       � WindowStyle$
  None=� � WindowStartupLocation$ CenterScreen=� � AllowsTransparency .  � ShowInTaskbar .   � Title$ 
MessageBox��$	��200��$	��400��.��� -   $��MainContainer�� � RowDefinitions �� $��40 ��� $��* ��� $��50 ��� $��50 �.+�� $��1��.+��� $��Center=�$��15q�.+��� -   $��MessageText��$��0 0 0 5q�$
��Wrap=�
�������$��17(�$��SemiBold"�$��Center=�$��Center=�]� -      MainColorBrush#��[  $��0��.+��� -   $��
HeaderText�� �� Padding$ 10q�
�������$��Medium"�$��18(�Information�� -   $��40��$��Right=�  CloseButton#��[  � ToolTip _� $��Close��.��F� $��Stretch=�$��14��$��14��$��Stretch=�
�������$	��1.5�� 
 Cancel#��[ � $��2�� � ColumnDefinitions �� $��* ��� $��* �.+��� $��0��._��� -   $��NoButton��$��16(�$��Center=�$��1q�
�������$��No��
���   �
�������  NormalButton#��[ $��45 0 0 0q�$
��Left=�$	��125��$��35���� $��1��._��� -   $��	YesButton��$��16(�$��Center=�$	��Yes��#��[ #��[  $��0 0 45 0q�$	��125��$��35���� $��3��._��� -   $��OkButton��$��16(�$��Center=�$��2q�
�������$��Ok��
���   �
�������#��[ $��3q�$
��Left=�$	��125��$��35��