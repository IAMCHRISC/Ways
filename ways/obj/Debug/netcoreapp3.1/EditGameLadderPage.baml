   M S B A M L   `   `   `  ����?  ;ways, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:waysways  5          ways.EditGameLadderPage   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      $localclr-namespace:ways     5        N� Title$7  1Administration - Editer le classement des joueurs��5	       N� 
Background
 �����.��5      � .+�5   
   �� $��Center=�6   $��Center=�60   $	��800��6M   .+�5      �� $��Tableau des scores��6   $
��Bold"�61   $��20(�6C   �� 5      .+�5      �� -   5         ��Name$ ladderListView��5      $��0,20,0,0q�63   $��Center=�6E   $��Center=�6i   $	��800��6�   $	��200��6�    �� View 5      �� 5      .P�5      �� $��Place��6-    �� Width$ 90��6<    �� CellTemplate 5   "   �� 5   &   .R�5   *   ��  �� TextAlignment$ Center=�6J   $��90��6a   ��64   �� *Rank+6a   5   '   5      �� 5      $��Joueur��6-   $	 400��6=    5   "   �� 5   &   .R�5    *   �� $ Center=�6N   $	��400��6e   ��64   �� *
Username+6e   5!   '   5#      �� 5$      $��Score��6-   $	 100��6<    5%   "   �� 5&   &   .R�5'   *   �� $ Center=�6K   $	��100��6b   ��64   �� *Score+6b   5(   '   5*      �� 5+      $
��Date��6-   $	 199��6;    5,   "   �� 5-   &   .R�5.   *   �� $ Center=�6J   $	��199��6a   ��64   �� *Date+6a   5/   '   51      52      54      �� 56      -   5         ��Name$ errorMessage��56   N   $��error��6   
���  ��$y�Hidden=�6:   $��Center=�6d   $��	0,20,0,20q�6�   �� 58      -   5        $��Center=�58      $	��100��66   
��� ���$
��Bold"�6g   .��59      ��  �� Orientation$ 
Horizontal=�6!   .+�5:      �� $!��Resources/edit_question.png��6    $��15��6E   $��	10,0,10,0q�6Q   �� 5;      $��Modifier��6    
�������63   5<      5=      5>      �� 5@      $��	0,20,0,20q�6   �� 5C      $ 
Horizontal=�6   $��Center=�62   $	��800��6O   .+�5D      �� $��Nom de joueur : ��6   $	��100��63   �� 5E      -   5        	 ��Name$	 usernameBox��5E   <   $��Center=�6   $	��300��6Q   �� 5G      $��Score : ��6   $��	100,0,0,0q�6+   �� 5H      -   5        $	 scoreBox��5H   <   $��Center=�6   $��50��6N   �� 5J      -   5        
 ��Name$
 confirmButton��5J   6   $��Center=�6   $	��100��6M   
��� � �$
��Bold"�6�   ${�False��6�   $��	100,0,0,0q�6�   .��5K      �� $ 
Horizontal=�6!   .+�5L      �� $��Resources/ok.png��6    $��15��6:   $��	10,0,10,0q�6F   �� 5M      $��Valider��6    
�������62   5N      5O      5P      5Q      5R      5S      