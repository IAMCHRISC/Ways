   M S B A M L   `   `   `  ����?  ;ways, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:waysways  5          ways.AddQuestionPage   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      $localclr-namespace:ways     5        N� Title$+  %Administration - Ajouter une question��5	       N� 
Background
 �����.��5      � .+�5   
   �� $��Center=�6   $	��Top=�62   $	��950��6J   .+�5      �� $��Center=�6   $	��400��66   $��
0,100,0,50q�6B   .+�5      �� $3��-Veuillez saisir l'énoncé de la question : *��6   �� 5      -   5         ��Name$ questionTitleTextBox��5      $��0,0,0,10q�68   $��Center=�6J   �� 5      $&�� Quel est le type de question ? *��6   �� 5       �� Orientation$ 
Horizontal=�6   .+�5      �� -   5         ��Name$ typesComboBox��5      $	��290��66   ��5      �� 5      .R�5   "   �� ��6,   �� *Type+5      5      �� 5      -   5         ��Name$ continueButton��5   Y   $	��100��6   $��	Continuer��6)   $��10,0,0,0q�6q   5      �� 5       -   5         ��Name$ typeErrorMessage��5    �   $1��+Merci de sélectionner un type de question.��6   
���  ��$��Center=�6_   $y�Hidden=�6|   6�   5!      �� 5$      -   5         ��Name$ orientationStackPanel��5$      $ Vertical=�68   $y�	Collapsed=�6O   $	��950��6f   $��Center=�6r   .+�5%      �� $ 
Horizontal=�6   $	��942��66   $��Center=�6B   .+�5'      �� $	��300��6!   $ Vertical=�6-   .+�5(      �� $��Réponse 1 : *��6    $	��300��68   �� 5)      -   5        $# firstOrientationAnswerTextBox��5)   .   $	��300��6"   $��Center=�6U   $
��Left=�6w   �� 5*      $��Métier(s) lié(s) : *��6    $	��300��6?   �� 5+      -   5        $ myFirstJobsPanel��5+   %   $	��300��6?   6M   5,      �� 5.      #��["�6    $��	10,0,10,0q�6^   �� 51      $	��300��6!   $ Vertical=�6-   .+�52      �� $��Réponse 2 : *��6    $	��300��68   �� 53      -   5        $$ secondOrientationAnswerTextBox��53   .   $	��300��6"   $��Center=�6V   �� 54      $��Métier(s) lié(s) : *��6    $	��300��6?   �� 55      -	   5        $ mySecondJobsPanel��55   %   $	��300��6@   6N   56      �� 58      #��["�6    $��	10,0,10,0q�6^   �� 5;      $	��301��6!   $ Vertical=�6-   .+�5<      �� $��Réponse 3 : *��6    $	��300��68   �� 5=      -
   5        $# thirdOrientationAnswerTextBox��5=   .   $	��300��6"   $��Center=�6U   �� 5>      $��Métier(s) lié(s) : *��6    $	��300��6?   �� 5?      -   5        $ myThirdJobsPanel��5?   %   $	��300��6?   6M   5@      5A      �� 5C      -   5        $ errorMessageOrientation��5C   N   $��error��6   
���  ��$y�Hidden=�6:   $��Center=�6o   $��	0,20,0,20q�6�   �� 5D      -   5        $��Center=�5D      $	��230��66   
��� � �$
��Bold"�6t   .��5E      �� $ 
Horizontal=�6!   .+�5F      �� $��Resources/ok.png��6    $��15��6:   $��	10,0,10,0q�6F   �� 5G      $'��!Ajouter la question 'Orientation'��6    
�������6L   5H      5I      5J      �� 5M      -   5        $ gameStackPanel��5M      $y�	Collapsed=�61   $	��700��6H   .+�5O      �� $ 
Horizontal=�6   .+�5Q      �� $ Vertical=�6!   $	��480��68   .+�5S      �� -   5        $ gameFirstAnswerStackPanel��5S   %   $ Vertical=�6H   $��0,0,0,10q�6_   .+�5T      �� -   5        $$ gameFirstAnswerTitleStackPanel��5T   )   $ 
Horizontal=�6Q   .+�5U   "   �� $��Réponse 1 : *��6(   $	��100��6@   �� 5V   "   -   5        $ gameFirstAnswerTextBox��5V   6   $	��370��6*   $��Center=�6V   5W      5X      �� 5[      -   5        $  gameSecondAnswerStackPanel��5[   %   $ Vertical=�6I   $��0,0,0,10q�6`   .+�5\      �� -   5        $% gameSecondAnswerTitleStackPanel��5\   )   $ 
Horizontal=�6R   .+�5]   "   �� $��Réponse 2 : *��6(   $	��100��6@   �� 5^   "   -   5        $ gameSecondAnswerTextBox��5^   6   $	��370��6*   $��Center=�6W   5_      5`      �� 5c      -   5        $ gameThirdAnswerStackPanel��5c   %   $ Vertical=�6H   $��0,0,0,10q�6_   .+�5d      �� -   5        $$ gameThirdAnswerTitleStackPanel��5d   )   $ 
Horizontal=�6Q   .+�5e   "   �� $��Réponse 3 : *��6(   $	��100��6@   �� 5f   "   -   5        $ gameThirdAnswerTextBox��5f   6   $	��370��6*   $��Center=�6V   5g      5h      �� 5k      -   5        $  gameFourthAnswerStackPanel��5k   %   $ Vertical=�6I   $��0,0,0,10q�6`   .+�5l      �� -   5        $% gameFourthAnswerTitleStackPanel��5l   )   $ 
Horizontal=�6R   .+�5m   "   �� $��Réponse 4 : *��6(   $	��100��6@   �� 5n   "   -   5        $ gameFourthAnswerTextBox��5n   6   $	��370��6*   $��Center=�6W   5o      5p      5q      �� 5s      #��["�6    $��	10,0,10,0q�6^   �� 5v      $ Vertical=�6!   $	��200��68   .+�5x      �� $ 
Horizontal=�6%   .+�5y      �� $��Bonne réponse : *��6$   $	��100��6@   �� 5z      -   5        $ gameGoodAnswerStackPanel��5z   )   $ Vertical=�6K   $	��100��6b   .+�5{   "   	� -   5         	�Name$	 rb1��5{   E   	 	� 	GroupName$	 
goodAnswer��6.   $��
Réponse 1��6R   $��Center=�6f   $��Right=�6�   $��	0,30,0,10q�6�   	� 5|   "   -   5        $	 rb2��5|   E   $	 
goodAnswer��6.   $��
Réponse 2��6R   $��Center=�6f   $��Right=�6�   $��0,0,0,10q�6�   	� 5}   "   -   5        $	 rb3��5}   E   $	 
goodAnswer��6.   $��
Réponse 3��6R   $��Center=�6f   $��Right=�6�   $��0,0,0,10q�6�   	� 5~   "   -   5        $	 rb4��5~   E   $	 
goodAnswer��6.   $��
Réponse 4��6R   $��Center=�6f   $��Right=�6�   $��0,0,0,10q�6�   5      5�      5�      5�      �� 5�      -    5        $ errorMessageGame��5�   N   $��error��6   
���  ��$y�Hidden=�6:   $��Center=�6h   $��	0,20,0,20q�6�   �� 5�      -!   5        $��Center=�5�      $	��230��66   
��� � �$
��Bold"�6m   .��5�      �� $ 
Horizontal=�6!   .+�5�      �� $��Resources/ok.png��6    $��15��6:   $��	10,0,10,0q�6F   �� 5�      $��Ajouter la question 'Jeu'��6    
�������6D   5�      5�      5�      �� 5�      -"   5        $ marketingStackPanel��5�      $y�Hidden=�66   $��Center=�6J   .+�5�      �� -#   5        $ errorMessageMarketing��5�   N   $��error��6   
���  ��$y�Hidden=�6:   $��Center=�6m   $��	0,20,0,20q�6�   �� 5�      -$   5        $��Center=�5�      $	��230��66   
��� � �$
��Bold"�6r   .��5�      �� $ 
Horizontal=�6!   .+�5�      �� $��Resources/ok.png��6    $��15��6:   $��	10,0,10,0q�6F   �� 5�      $%��Ajouter la question 'Marketing'��6    
�������6J   5�      5�      5�      5�      �� 5�   
   $3��-Les champs marqués d'un * sont obligatoires.��6   $��Center=�6H   $��10(�6e   $��Bottom=�6s   $��0,0,0,50q�6�   5�      5�      