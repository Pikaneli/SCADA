   M S B A M L   `   `   `  ����C  ?ScadaGUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:ScadaGUIScadaGUI  5   	       ScadaGUI.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:ScadaGUI     5   	   -   5          � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)   .��5	      �  � ColumnDefinitions 5
   
   .+�5   
   �� $��10,0,6.334,9.667q�6   
�������$��2��6B   .@�5      �� $��Tagovi��6   
�������
�������.��5      �  5      �� 5      $	��77* �6+   �� 5      $
��312* �6+   .+�5      &   System.Windows.Controls.DataGrid  -   5        $��VelicineGrid��5         
IsReadOnly .    SelectionMode$ Single=�6t      AutoGenerateColumns .  $��10,15,10,55q�6�   $��2��6�    �� SelectedItem 65   �� *SelectedZajednicka+ � 	Resources 5         UpdateBtnIcon �� ImageSource  DeleteBtnIcon��%   &	        &	 �     �� 5      $r lC:\Users\petar\Downloads\wetransfer_psnus_2024-06-06_1424\LARA psnus projekat\ProjekatPSNUS\Icons/update.jpg��6?   �� 5      $r lC:\Users\petar\Downloads\wetransfer_psnus_2024-06-06_1424\LARA psnus projekat\ProjekatPSNUS\Icons/delete.jpg��6?   5         RowStyle 5      �� 5      	 �� 
TargetType)  #System.Windows.Controls.DataGridRow"	  6$   
 �� Triggers
 5   "   �� 5   &    �� Binding 62   �� *	Aktivan+ �� Value True6N   .a�5   *   ��  �� Property � �� �� Value
 �  ��6G   �� 5   *    � ��
 �����6G   5   '   5!         Columns 5#      0  *System.Windows.Controls.DataGridTextColumn  5$      ,  &System.Windows.Controls.DataGridColumn   Header$ Tag ID��61      Width5  /System.Windows.Controls.DataGridLengthConverter$ 1* 6X   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6A   �� *Id+6X     5%      $	 Tip��61   $ 1* 6V    6>   �� *Tip+6V     5&      $
 Opis��61   $ 1* 6_    6?   �� *Description+6_     5'      $ Vrednost��61   $ 1* 6e    6C   �� *Current_value+6e     5(      $ Poruka��61   $ 1* 6\    6A   �� *Poruka+6\   4  .System.Windows.Controls.DataGridTemplateColumn  5*      $ * 65      CellTemplate 5+   "   �� 5,   &   .R�5-   *   ��  �� Orientation$ 
Horizontal=�65   $��Center=�6N   .+�5.   .   �� -   5        #��[  5.   5    � ToolTip$ Azuriraj��6a   $��30��6t   $��30��6�   6�   �� 5/   .   -   5        #��[ 5/   5   $ Obrisi��6a   $��30��6r   $��30��6~   6�   50   +   51   '   53      55      �� 57      -   5        $��Dodaj DI��57      $
��Left=�60   $��Bottom=�6K   $��30��6g   $	��120��6s   $��	10,0,0,10q�6�   �� 58      -   5        $��Dodaj DO��58      $
��Left=�60   $��Bottom=�6K   $��30��6g   $	��120��6s   $��1��6�   $��
147,0,0,10q�6�   �� 59      -   5        $��Dodaj AI��59      $
��Left=�60   $��Bottom=�6K   $��30��6g   $	��120��6s   $��1��6�   $��1,0,0,10q�6�   �� 5:      -   5        $��Dodaj AO��5:      $
��Left=�60   $��Bottom=�6K   $��30��6g   $	��120��6s   $��1��6�   $��
292,0,0,10q�6�   5;      5<      �� 5=      $��Alarmi��6   
�������
�������.��5>      �  5?      �� 5@      $��9* �6+   �� 5A      $	��73* �6+   �� 5B      $
��688* �6+   .+�5E        -	   5        $��
AlarmiGrid��5E       .   . $ Single=�6�   $��
1,15,10,55q�6�   $��2��6�   $��1��6�    61   �� *SelectedAlarm+ 5F      ��%   &	        &	 �     �� 5G      $r lC:\Users\petar\Downloads\wetransfer_psnus_2024-06-06_1424\LARA psnus projekat\ProjekatPSNUS\Icons/update.jpg��6?   �� 5H      $r lC:\Users\petar\Downloads\wetransfer_psnus_2024-06-06_1424\LARA psnus projekat\ProjekatPSNUS\Icons/delete.jpg��6?   5I       5J        5K      $ ID��61   $ * 6=    6G   �� *Id+  5L      $ Poruka��61   $ * 6A    6K   �� *	Message+  5M      $ Rastuca(1) / Opadajuca(0)��61   $ * 6T    6^   �� *H_l+  5N      $ Granica��61   $ * 6B    6L   �� *Limit+  5P      $ * 65    5Q   "   �� 5R   &   .R�5S   *   �� $ 
Horizontal=�65   $��Center=�6N   .+�5T   .   �� -
   5        #��[  5T   5   $ Azuriraj��6a   $��30��6t   $��30��6�   6�   �� 5U   .   -   5        #��[ 5U   5   $ Obrisi��6a   $��30��6r   $��30��6~   6�   5V   +   5W   '   5Y      5[      �� 5\      -   5        $��Dodaj alarm��5\      $
��Left=�63   $��Bottom=�6N   $��30��6j   $	��120��6v   $��2,0,0,10q�6�   $��1��6�   $��2��6�   5]      5^      5_      5`      5a      