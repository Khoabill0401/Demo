   M S B A M L   `   `   `  ����?  ;Demo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:AnkobimAnkobim  5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 .  *TreeViewItem.TreeArrow.Static.Checked.Fill  �� Color 0 ,TreeViewItem.TreeArrow.Static.Checked.Stroke + 'TreeViewItem.TreeArrow.MouseOver.Stroke ) %TreeViewItem.TreeArrow.MouseOver.Fill 3 /TreeViewItem.TreeArrow.MouseOver.Checked.Stroke 1 -TreeViewItem.TreeArrow.MouseOver.Checked.Fill  	TreeArrow & "TreeViewItem.TreeArrow.Static.Fill ( $TreeViewItem.TreeArrow.Static.Stroke 	 TreeViewItemFocusVisual �� Property �� Value 
 ExpandCollapseToggleStyle �� 
TargetType �� 
TargetType �� Padding F�Name �� Angle �� CenterY	 �� CenterX
 �� Triggers P� Property P� Value �� 
TargetName ]� 
Conditions �� Property �� Value  TreeViewStyle �� RelativeSource �� AncestorType � ColumnDefinitions � RowDefinitions d�Name �� 	ClickMode d� 	IsChecked ��Name J� SnapsToDevicePixels ��Name ��Name    Ankobim.CustomTreeView �� Triggers�� 5      D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    :x,http://schemas.microsoft.com/winfx/2006/xaml     5      localclr-namespace:Ankobim  5      %�  &	        &	 #     &	 F     &	 i     &	 �     &	 �     &	 �     &	 �     &	 #    &		 F    &	
 �    7  7  7  7   7  7  7  7  7  &	 &    7 	 7 
 �� 5      $  	#FF595959��6I   �� 5      $  	#FF262626��6K   �� 5      $  	#FF1BBBFA��6F   �� 5	      $  Transparent��6D   �� 5
      $  	#FF262626��6N   �� 5      $  	#FF595959��6L   B� 5      $��M0,0 L0,6 L6,0 zC�6%   �� 5      $  Transparent��6A   �� 5      $  	#FF989898��6C   �� 5      .�5   
   ��  � �� 5      �� 5      .R�5      �� 5      5      5      �� 5      " d�6.   .�5   
   ��  � |� .  6&   �� 5   
    � ��$ 16��6"   �� 5   
    � ��$ 16��6#   �� 5   
    � �� 5      �� 5       " d�6"   .R�5!      �� 
������ $��16��66   $ 5,5,5,5q�6B   $��16��6T   ._�5"      F� $ 
ExpandPath��6   8��  8�� 8�� z�5$      �� 5%   "   $	 135Q�62   $ 3Q�6>   $	 3Q�6J   5'      5(      
 5)      P� 5*       �@d�	IsChecked$
 TrueY�67   . �5+      �� $ 
ExpandPath��6@    � z� 5,   "   �� 5-   &   $	 180Q�66   $ 3Q�6B   $	 3Q�6N   5/      �� 50      $ 
ExpandPath��65   8   � ��6M   �� 51      $ 
ExpandPath��67   8   � ��6O   52      P� 53       �@J�IsMouseOver . . �54      �� $ 
ExpandPath��67   8   � ��6O   �� 55      $ 
ExpandPath��65   8   � ��6M   56      ]� 57       58      �� 59   "    �@J�IsMouseOver . 6C   �� 5:   "    �@d�	IsChecked$
 TrueY�6A   ./�5<      �� $ 
ExpandPath��67   8   � ��6O   �� 5=      $ 
ExpandPath��65   8   � ��6M   5>      5@      5B      5C      �� 5E      " Q�6"   .�5F   
   ��  � ��
 ���� 6'   �� 5G   
    � ��
 �����6(   �� 5H   
    � �� 67   �� *HorizontalContentAlignment+ �� " ���� 5I   
    � �� 65   �� *VerticalContentAlignment+ �� " ���� 5J   
    � ��$ 1,0,0,0q�6$   �� 5K   
    �@Q�
IsExpanded .  6'   �� 5L   
    � ��# � ��6'   �� 5M   
    �@�FocusVisualStyle8   6-   �� 5O   
    � �� 5P      �� 5Q      " Q�6"   .R�5R      �  5S      �� 5T      $��19��6/   $
��Auto �6=   �� 5U      $
��Auto �6/   �� 5V      $��* �6/    5X      �� 5Y      $
��Auto �6,   �� 5Z      .+�5\      d� $ Expander��5]   !   $ Press=�5^   !   8��  5_   !   �� *
IsExpanded+ �� *TemplatedParent+5`   !   �� 5a      $ Bd��5b   !   #��z��5c   !   #��z��5d   !   #��z��5e   !   $��1��5f   !   # z��5g   !    . ._�5i      �� $ PART_Header��5j   %   $��Header��5k   %   #��z��5l   %   # z 5m   %   5n      �� 5o      $ 	ItemsHost��5p   !   $��2��5q   !   $��1��5r   !   $��1��5s   !   5t      
 5u      P� 5v       �@Q�
IsExpanded .  . �5w      �� $ 	ItemsHost��6;    � y�$ 	Collapsed=�6R   5x      P� 5y       �@��HasItems .  . �5z      �� $ Expander��6;    � y�$ Hidden=�6Q   5{      P� 5}       �@  
IsSelected . . �5~      �� $ Bd��6;   # � ��6K    � ���� 5      # � ��6;    � ��5�      ]� 5�       5�      �� 5�   "    �@  
IsSelected . 6W   �� 5�   "    �@Q�IsSelectionActive .  6I   ./�5�      �� $ Bd��6;   # � /�6K    � ���� 5�      # � .�6;    � ��5�      P� 5�       � {� .  . �5�      �� # � ��6;    � ��5�      5�      5�       5�   
   P� 5�       �@%�IsVirtualizing . . �5�      ��  � �� 5�      �� 5�      .R�5�      $� 5�      5�      5�      5�      5�      