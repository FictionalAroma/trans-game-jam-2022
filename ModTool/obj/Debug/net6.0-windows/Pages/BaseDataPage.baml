   M S B A M L   `   `   `  ����B  >ModTool, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:ModTool.PagesModTool.Pages  5      ?$clr-namespace:ModTool.Data.SelectorsModTool.Data.Selectors  5           ModTool.Pages.BaseDataPage   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      -pagesclr-namespace:ModTool.Pages     5      :	selectors$clr-namespace:ModTool.Data.Selectors     5        � DataContext  5
      ��  �� RelativeSource �� *Self+ � 	Resources 5      <   6ModTool.Data.Selectors.BaseDataTypeFieldEditorSelector   FieldEditorSelector  ListBoxItem �� Path  FieldContentTemplate  RichTextContentTemplate" �� VerticalScrollBarVisibility �� 	IsEnabled  FilePathSelectorTemplate �� Orientation ��Name �� 
IsReadOnly	 ��Name  FormDataItem
 � ToolTip � ColumnDefinitions��%�  &	        &	      &	 Z     &	 �     &	 &    &	 x    7     5   
   64   �� 5   
   .R�5      �� ��6   �� $ 
EntityName�5      �� 5   
   .R�5      �� ��6   �� $ PropertyValue�5      �� 5   
   .R�5      �� $ Visible=�5      $
 True��5       �5      �� $ PropertyValue�5      5      �� 5      .R�5      �� $��Stretch=�6   $ 
Horizontal=�67   .+�5       �� $ FilePathText��68   $��Stretch=�6   $
 True��6s   ��6O   �� $ PropertyValue�6s   �� 5!      $	 browseFileButton��6F   -   5        $	��...��5!      6F   �� 5"      ��6   �� $ PropertyValue�6@   5#      5$      �� 5&   
   .R�5'      � 
 6   �� *FormBindData.ToolTipText+ 5(      �� 5)      $��* �6'   �� 5*      $��2* �6'   .+�5,      �� ��6   �� $ FormBindData.LabelName��� 5-      $��1��6!   8��  ��6p   �� 5.      5/      51      .��52      � ���	#FFE5E5E5 53   
   �� 54      $��* �6   �� 55      $��2* �6   .+�57   
   �� $ �� IsSynchronizedWithCurrentItem$
 TrueY�6   #��[ 5:       �� SelectionMode$ Single=�5;      ��58      �� $ FormData� �� SelectedItem 59      �� $ FormData.SelectedItem�5=      �� 5>   
   $��1��6   #��[ 5@      ��5?      �� $+ %FormData.SelectedItem.GetFormBindings�5C      5D      5E      