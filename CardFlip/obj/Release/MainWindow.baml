   M S B A M L   `   `   `  ���� C  ?CardFlip, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:CardFlip.UserControlsCardFlip.UserControls      CardFlip.MainWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5local#clr-namespace:CardFlip.UserControls     
������   � WindowStyle$
  None=�$	��500��$	��500�� � Title$ 
MainWindow��$	��550��$	��600��.��� .+���    SubColorBrush#��[   �� CornerRadius$ 8��._�� -   $��TabPanel��#��[   � RowDefinitions �� $��40 ��� $��* �.+�� $��0�� � ColumnDefinitions �� $	��100 ��� $��* ��� $	��120 �.+��� $��0�� �� Orientation$ 
Horizontal=�.+��� $��1��$��16(�$
��Left=� �� Padding$ 10 0 0 0q�$��DemiBold"�  MainColorBrush#��[ $��Center=�	Card Flip]� $��2��$��Right=�$��40��.+��� $	��120��$��Right=�$ 
Horizontal=�.+��� -   $��40��  RectangleButton#��[  � ToolTip _� $��Minimize��.��F� $��Stretch=�$��12��$��12��$��Stretch=�
�������$	��1.5������    �pr � � �pr 	�� -   $��40��#��[  _� $��Maximize��.��F� $��Stretch=�$��13��$��13��$��Stretch=�
�������$	��1.5��X����    @B �    @B � � @B �    @B �    �ا � � @B � � �ا р�� �ا �    �ا 	�� -   $��40��  CloseButton#��[  _� $��Close��.��F� $��Stretch=�$��12��$��12��$��Stretch=�
�������$	��1.5��+����        � �  � �     � � �     	� -   $��ContentGrid��$��1�� �� $��50 ��� $��* ��� $��80 � �� $��* �.+�� $��0��.+�+   %CardFlip.UserControls.AnimatedTextBox  -     Name$ AnimatedTextBox��$	��200��$��11(�$��40��$��15,0,0,0q�	   AnimatedTextBoxFontSize$	 14Q�"
   AnimatedTextBoxBorderRadius$
 10Q�$
��Left=�    AnimatedTextBoxBackground
 �����!   AnimatedTextBoxPlaceHolder$ Enter your name��    AnimatedTextBoxForeground# [ �� -   $��Submit��$��Right=�$
��25 3q�$��40��  NormalButton#��[ $��15(�$��Submit��
�������#��[ $	��120��� $��1��.+��� $��Stretch=�$	��700��$	��900��$ 13��
�������$��1q�$��15q�._�� -   $��gameGrid��� $��2��.+�]� $	��Top=���. .+��� -	   $��Restart��$
��Left=�$
��25 3q�$��40��#��[ $��15(�
�������#��[ $	��120��.��(� $��24��$��24��.��F� $��Stretch=�$	��500��$	��500��$��Stretch=�#��[  
�������$��20�� 	 Reset#��[ �� -
   $��Start��$��Right=�$
��25 3q�$��40��#��[ $��15(�$��Start��
�������#��[ $	��120��