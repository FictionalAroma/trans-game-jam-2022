   M S B A M L   `   `   `  ����B  >ModTool, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:ModTool.Data.DataObjectsModTool.Data.DataObjects  5   	   +clr-namespace:ModTool.DataModTool.Data  5	   	   -clr-namespace:ModTool.PagesModTool.Pages  5
   	       ModTool.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   >dataObjects&clr-namespace:ModTool.Data.DataObjects     5   	   +dataclr-namespace:ModTool.Data     5	   	   -pagesclr-namespace:ModTool.Pages     5
   	   -   5        $��ParentWindow��5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)    � DataContext 5   	   ��  �� RelativeSource �� *Self+ J� CommandBindings 5       � 	Resources 5      -   'ModTool.Data.FormListCharacterConverter   characterDataListConverter,   &ModTool.Data.FormListLocationConverter  locationDataListConverter��%:   &	        &	        5   
   6*     5   
   6)   5      .��5      ]� .+�5   
   o� $	��Top=�6   .@�5      m� $��_File��6   .@�5      m�  m� Command$ Close��6   5      m� 5      $��_Edit��6   .@�5      m� $	 Cut��6   m� 5      $
 Copy��6   m� 5      $ Paste��6   5      m� 5      $��_Collection��6   .@�5      m� $	 Cut��6   m� 5      $
 Copy��6   m� 5       $ Paste��6   5!      5"      �� 5#   
   $��Bottom=�6   .@�5$      �� $��
StatusTest��6   5%      �� 5&   
   .@�5'      �� $��
Characters��6   .��5(          ModTool.Pages.BaseDataPage     FormDataType,   &ModTool.Data.DataObjects.CharacterData"  5)   %      FormData 5(   %   ��  �� Path$ DataLib.Characters�	 �� ElementName$	 ParentWindow��
 �� 	Converter#
 [   �� UpdateSourceTrigger$ PropertyChanged=� �� Mode$ TwoWay=�5)   Y   5*      �� 5+      $��Location��6   .��5,        +   %ModTool.Data.DataObjects.LocationData"  5-   %    5,   %   �� $ DataLib.Locations�$	 ParentWindow��#
 [ $ PropertyChanged=�$ TwoWay=�5-   X   5.      5/      50      51      