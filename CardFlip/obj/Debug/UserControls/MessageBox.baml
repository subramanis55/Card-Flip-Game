   M S B A M L   `   `   `  ����C  ?CardFlip, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:CardFlip.UserControlsCardFlip.UserControls  5   	   '    !LucidDesk.UserControls.MessageBox   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   5local#clr-namespace:CardFlip.UserControls     5   	     � WindowStyle$
  None=�5       � WindowStartupLocation$ CenterScreen=�6/    � AllowsTransparency .  � ShowInTaskbar .   � Title$ 
MessageBox��5   	   $	��200��6   $	��400��6)   .��5	      � -   5        $��MainContainer��5	       � RowDefinitions 5
   
   �� 5      $��40 �6   �� 5      $��* �6   �� 5      $��50 �6   �� 5      $��50 �6   .+�5   
   � $��1��6   .+�5      �� $��Center=�6   $��15q�65   .+�5      �� -   5        $��MessageText��5   C   $��0 0 0 5q�6   $
��Wrap=�6/   
�������$��17(�6h   $��SemiBold"�6v   $��Center=�6�   $��Center=�6�   5      5      5      ]� 5   
   -   5           MainColorBrush#��[  5   2   $��0��6_   .+�5      �� -   5        $��
HeaderText��5       �� Padding$ 10q�6+   
�������$��Medium"�6K   $��18(�6_   Information6z   �� 5      -   5        $��40��5   .   $��Right=�69     CloseButton#��[ 6U    � ToolTip 5      _� 5      $��Close��6   60   .��5      F� $��Stretch=�6   $��14��63   $��14��6?   $��Stretch=�6K   
�������$	��1.5��6x    
 Cancel#��[ 6�   6�   5      5      � 5    
   $��2��6    � ColumnDefinitions 5!      �� 5"      $��* �6#   �� 5#      $��* �6#   .+�5&      �� $��0��6   ._�5'      �� -   5        $��NoButton��5'      $��16(�6*   $��Center=�69   $��1q�6V   
�������$��No��6�   
���   �
�������  NormalButton#��[ 6�   $��45 0 0 0q�6�   $
��Left=�6�   $	��125��6  $��35��6'  65  5(      �� 5)      $��1��6   ._�5*      �� -   5        $��	YesButton��5*      $��16(�6*   $��Center=�6O   $	��Yes��6m   #��[ 6{   #��[  6�   $��0 0 45 0q�6�   $	��125��6�   $��35��6�   6�   5+      5,      �� 5-   
   $��3��6   ._�5.      �� -   5        $��OkButton��5.      $��16(�6&   $��Center=�65   $��2q�6R   
�������$��Ok��6   
���   �
�������#��[ 6�   $��3q�6�   $
��Left=�6�   $	��125��6  $��35��6  6*  5/      50      51      