   M S B A M L   `   `   `  ����C  ?CardFlip, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:CardFlip.UserControls.CommonCardFlip.UserControls.Common  5      1    +LucidDesk.UserControls.Common.CustomTextBox   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      <local*clr-namespace:CardFlip.UserControls.Common     5      $��0q�5   M     � 	Resources  5       �� 
TargetType �� Property �� Value �� 
TargetType ��Name �� Triggers P� Property P� Value   	BorderBox	 �� Binding
 �� ElementName �� Value  MainColorBrush��%�  '��       &	  #    'G� P    �� 5	   
   " ��6   .�5
      ��  � �� 5      �� 5      " ��6&   .R�5      �� #��z��6!   #��z��5      #��z��5      ._�5      �� $ PART_ContentHost��6+   5      5      5       5      P� 5       �@J�IsMouseOver . 5      5      �� 5   
   " ��6"   .�5      ��  � ��
 �����6,   �� 5       � ��$ 	0 0 0 2.4q�60    5      �� 5      	 6   �� *IsKeyboardFocusWithin+$
 Textbox�� True6\   .a�5       ��  � ��# �  64   �� 5!       � ��$ 	0 0 0 2.4q�68   5"      5$      �� 5%   
   " G�6   .�5&      ��  � �� 5'      �� 5(      " G�6&   .R�5)      �� #��z��6!   #��z��5*      #��z��5+      ._�5,      �� $ PART_ContentHost��6+   5-      5.      50       51      P� 52       �@J�IsMouseOver . 54      56      57      .��58      ��  �� CornerRadius$ 4��6   #��[  6s   ��6   �� *TextboxBackground+��6H   �� *TextboxBorderBrush+._�59   
   � $��0q�6   .+�5:      G� -   5         G�Name$ PasswordTextBox��5:      $y�Hidden=�63   ��.  � Cursor$ IBeam��6�   $��0q�6�   ��6�   �� *TextPadding+��6�   ��  �� RelativeSource ��  �� AncestorType" >� �� Path$ FontSize���6'  ��  �� " >�$ 
Foreground���6�  ��  �� " >�$ 
FontFamily�5;      �� 5<      -   5        $��Textbox��5<      $��0q�6&   ��. $ IBeam��6�   $��0q�6�   ��6m   ��  �� " >�$ 
Background���6�   �� *TextPadding+��6  ��  �� " >�$ FontSize���6|  �� *Text+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=���6�  ��  �� " >�$ 
Foreground���6-  ��  �� " >�$ 
FontFamily�.��6�  5=      �� 5>      -   5        $��PlaceholderLabel��5>      $
 Hand��6,   
������ $��20 0 0 0q�6v   $��Center=�6�   ��6;   �� *Placeholder+��6�   ��  �� " >�$ FontSize���6  �� *PlaceholderColor+67  5?      5@      5A      