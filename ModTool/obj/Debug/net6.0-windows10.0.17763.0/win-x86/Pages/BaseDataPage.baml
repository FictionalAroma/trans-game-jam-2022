   M S B A M L   `   `   `  ����  ModTool     ModTool.Pages.BaseDataPage   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5        � DataContext  5      ��  �� RelativeSource �� *Self+ � 	Resources 5	       �� Source�� 5
   
   $  ../FormLayoutTemplate.xaml?�6   %    6C   .��5      � ���	#FFE5E5E5 � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $��2* �6   .+�5   
   �� .+�5      �� -   5        $��+��5      6!   �� 5      $ �� IsSynchronizedWithCurrentItem$
 TrueY�6      ListBoxItem#��[  5       �� SelectionMode$ Single=�5      $
��Auto=�5      ��5      ��  �� Path$ FormData� �� SelectedItem 5      �� $ FormData.SelectedItem�5      5      �� 5   
   $��1��6     FormDataItem#��[ 5       ��5      �� $+ %FormData.SelectedItem.GetFormBindings� 5#        FilePathSelectorTemplate	 �� Orientation
 ��Name �� 
IsReadOnly ��Name��%z  &	       �� 5$      .R�5%      �� $��Stretch=�6!   $	 
Horizontal=�6?   .+�5&      �� $
 FilePathText��6@   $��Stretch=�6"   $
 True��6{   ��6W   �� $ PropertyValue�6{   �� 5'      $ browseFileButton��6N   -   5        $	��...��5'   !   6N   �� 5(      $	��300��6F   $	��300��6V   ��6    �� $ PropertyValue�6g   5)      5*      5,      5-      5.      5/      