   M S B A M L   `   `   `  ����?  ;ways, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:waysways  5   	   $    ways.OrientationQuestionWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   $localclr-namespace:ways     5   	     � Title$$  Test d'orientation - Questions��5	   	    � WindowStyle$
 None=�5
   	    � WindowStartupLocation$ CenterScreen=�6    � WindowState$ 	Maximized=�5   	   ��5      �� 5   
    �� ImageSource$ Resources/office.jpg��6   6:   .��5      � .+�5   
   �� -   5         ��Name$ numberOfQuestionsLabel��5      $	��Top=�60   $��Center=�6H   $��0,60,0,0q�6e   $y�Hidden=�6w   �� 5   
   -   5        $ resultsListLabel��5      $	��Top=�6*   $��Center=�6B   $��	0,120,0,0q�6_   $y�Hidden=�6r   �� 5   
   $��Center=�6   $��Center=�61   
������� J� Opacity$	 0.6Q�6Y   $	��400��6g   $	��800��6t   �� 5   
   $��Center=�6   $��Center=�62   $	��400��6M   $	��800��6Z   .+�5      �� -   5        $ 
countLabel��5      $	��Top=�6(   $��Right=�6@   �� 5      -   5         ��Name$ questionTitleLabel��5      $��Center=�64    �� TextAlignment$ Center=�6O   $��25(�6f   $��20,50,20,20q�6t   $
��Wrap=�6�   �� 5      -   5        	 ��Name$	 answersStackPanel��5      
 �� Orientation$
 Vertical=�64   $��Center=�6K   $��
10,0,10,20q�6h   6~   �� 5      -   5        $ invalidAnswerLabel��5   ?   $(��"Merci de répondre à la question.��6   $��Center=�6[   $��Bottom=�6x   
���  ��$y�Hidden=�6�   �� 5      -   5        $��Valider��5      $��Center=�6'   $��Bottom=�6D   $��25��6_   $	��192��6k   6w   5      5      5      