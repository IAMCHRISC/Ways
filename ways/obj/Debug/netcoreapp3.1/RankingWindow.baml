   M S B A M L   `   `   `  ����?  ;ways, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:waysways  5   	       ways.RankingWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   $localclr-namespace:ways     5   	     � Title$  RankingWindow��5   	   $	��600��6   $	��800��6,    � WindowStyle$
 None=�5	   	    � WindowStartupLocation$ CenterScreen=�6    � WindowState$ 	Maximized=�5
   	   .��5      � .+�5   
   ��  �� Orientation$ 
Horizontal=�6   $	��130��6.   $	��Top=�6;   $��Center=�6S   $��0,0,0,0q�6p   $	��800��6�   .+�5      �� $
��Left=�6   $	��109��6/   $��	10,10,0,0q�6<   $	��Top=�6O   $	��250��6g   $g��ahttps://toulouse.cesi.fr/wp-content/uploads/sites/27/2018/11/Cesi_Logo_ALTERNANCE_RVB-360x187.png��6s   �� 5      $��Classement du test��6   $
��Left=�61   $��
120,43,0,0q�6L   $	��Top=�6`   $��25(�6x   �� 5      -   5        $��Retour a l'accueil��5      $
��Left=�62   $��Center=�6M   $��	50,50,0,0q�6q   $	��Top=�6�   $	��130��6�   $��40��6�   
�������5   $   5      �� 5   
   $ 
Horizontal=�6   $��50��6.   $	��Top=�6:   $��Center=�6R   $��	0,110,0,0q�6o   $	��800��6�   .+�5      �� $��Ton score :��6   $
��Left=�6*   $��	80,10,0,0q�6E   $	��Top=�6X   $��15(�6p   �� 5      -   5         ��Name$ 	lbl_score��5      $�� ��6'   $
��Left=�62   $��0,10,0,0q�6M   $	��Top=�6_   $��15(�6w   
���  ��6�   �� 5      $��Moyenne des scores :��6   $
��Left=�63   $��	80,10,0,0q�6N   $	��Top=�6a   $��15(�6y   �� 5      -   5        $ lbl_moyenne��5      $�� ��6)   $
��Left=�64   $��0,10,0,0q�6O   $	��Top=�6a   $��15(�6y   
���  ��6�   �� 5      $��Nombre de participation :��6   $
��Left=�68   $��	80,10,0,0q�6S   $	��Top=�6f   $��15(�6~   �� 5      -   5        $ lbl_particiation��5      $�� ��6.   $
��Left=�69   $��0,10,0,0q�6T   $	��Top=�6f   $��15(�6~   
���  ��6�   5      �� 5   
   $ Vertical=�6   $	��470��6,   $	��Top=�69   $��Center=�6Q   $��	0,110,0,0q�6n   $	��800��6�   .+�5      �� -   5         ��Name$ 	ListeRank��5      $��10,50,10,73q�6*   $��Center=�6?   $��Center=�6c   $��16(�6�    �� View 5      �� 5      -   5        GridRank��.P�5      �� $��Place��6)    �� Width$	 173��68   	 �� CellTemplate	 5      �� 5    "   .R�5!   &   �� 
 �� TextAlignment$
 Center=�6F   $	��163��6]   ��60   �� *rank+6]   5"   #   5$      �� 5%      $��Username��6)   $	 200��6;   	 5&      �� 5'   "   .R�5(   &   �� $
 Center=�6J   $	��190��6a   ��60   �� *
username+6a   5)   #   5+      �� 5,      $��Score��6)   $	 180��68   	 5-      �� 5.   "   .R�5/   &   �� $
 Center=�6G   $	��170��6^   ��60   �� *score+6^   50   #   52      �� 53      $
��Date��6)   $	 200��67   	 54      �� 55   "   .R�56   &   �� $
 Center=�6F   $	��190��6]   ��60   �� *date+6]   57   #   59      5:      5<      5=      5>      5?      