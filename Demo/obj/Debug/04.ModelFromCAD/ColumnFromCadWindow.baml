   M S B A M L   `   `   `  ����  Demo!    Ankobim.ColumnFromCadWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -   5          �Name$  
MainWindow��5   	    � Title$ Settings��5   	    � 
ResizeMode$ NoResize=�5	   	    � ShowInTaskbar .  � WindowStartupLocation$ CenterScreen=�5   	   $	��225��5   	   $	��550��6    � Topmost .  � 	Resources 5       �� Source�� 5   
   $ Resource/Styles.xaml?�6   %    .��5      �� .+�5   
   �  � RowDefinitions 5      �� 5      $��35 �6    �� 5      $��35 �6    �� 5      $��35 �6    �� 5      $��35 �6    	 � ColumnDefinitions	 5      �� 5      $��90 �6#   �� 5      $	��200 �6$   �� 5       $	��100 �6#   �� 5!      .+�5$      �� $��Layer of Hatch��6   �� 5%      $��1��6   $��Column Family��5&      �� 5'      $��2��6   $��
Base Level��5(      �� 5)      $��2��6   $��2��6%   $��Base offset (mm)��5*      �� 5+      $��3��6   $��	Top Level��5,      �� 5-      $��3��6   $��2��6%   $��
Top offset��5.      �� 50      $��1��6   $��3��6'      ComboBoxStyle#���   51      
 �� 
IsEditable
 .  � ToolTip$&  Layer of hatch column in autoCAD��55      ��52      �� *	AllLayers+ �� SelectedItem 53      �� *SelectedLayer+55      �� 57      $��1��6   $��1��6'   $��3��64   #���   58       �� DisplayMemberPath$
 Name��5;      
 . ��59      �� *AllFamiliesColumn+ 5:      �� *SelectedFamilyColumn+5<      �� 5>      $��2��6   $��1��6$   #���   5?      $
 Name��5B      
 . ��5@      �� *
AllLevel+ 5A      �� *	BaseLevel+5C      �� 5G      $��2��6   $��3��6#     TextBoxStyle#���  5H      $ The unit is millimeters��5I      ��5J      �� *
BaseOffset+�� 5M      $��3��6   $��1��6$   #���   5N      $
 Name��5Q      
 . ��5O      �� *
AllLevel+ 5P      �� *
TopLevel+5R      �� 5V      $��3��6   $��3��6#   #���  5W      $	��0,1q�5X      $ The unit is millimeters��5Y      ��5Z      �� *	TopOffset+5]      ]� 5^   
   $��Bottom=�6   $��40��6"   $��Bottom=�5_      ��. .+�5c      �� -   5        $��Right=�5c      $��Cancel��5d      $	��100��5e        ButtonStyle#���  5g       �� IsCancel . 5h      �� 5i      -   5        $��Right=�5i      $��Right=�5j      $��OK��5k      $	��100��5l      #���  5n      � 5p      $��Right=�6    5q      �� 5r      $��35 �6%   .+�5u      � -   5        $��ProgressWindow��5u      $��4,8,6,0q�5v        ProgressBarStyle#���  5w      �� 5z      $��2��6   $��Center=�5|      $��Center=�5}      ��5{      �� *	Percent+ �� StringFormat$ {0:0}%��5}      5      5�      5�      5�      