   M S B A M L   `   `   `  ����@  <SAE01, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:SAE01SAE01  5          SAE01.MainWindow   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      %localclr-namespace:SAE01     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5        � Title$  Emprunt vehicule��5      $
��1250��5	      $	��700��5
      $
��1200��5      $	��700��5       � 
ResizeMode$ 	CanResize=�5       � Icon$ logo-voiture.jpg��5      ���	#FFFBF9EB.��5      �  � ColumnDefinitions 5   
   .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ 	dgConcess��5      $��10,363,10,93q�5         AutoGenerateColumns$ False��5         CanUserAddRows$ False��5         CanUserDeleteRows$ False��5      ���	#FFFBFBD0   
IsReadOnly$
 True��5      	   CanUserSortColumns$	 False��6   
   Columns
 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$ 1* 5         Header$	 Nom��5!      1  +System.Windows.Controls.DataGridBoundColumn   Binding 5       �� *Employe.Nom+5!        5"      $ 1* 5#      $ Prénom��5%       5$      �� *Employe.Prenom+5%        5&      $ 2* 5'      $
 Mail��5)       5(      �� *Employe.Mail+5)        5*      $ 1* 5+      $	 Tel��5-       5,      �� *Employe.TelEmploye+5-        5.      $ 2* 5/      $ Vehicule��51       50      �� *Vehicule.LibelleVehicule+51        52      $
 1.2* 53      $ Catégorie Véhicule��55       54      �� *-+Vehicule.CategorieVehicule.LibelleCategorie+55        56      $ 3* 57      $ Mission��59       58      �� *	Mission+59        5:      $ * 5;      $
 Date��5=       5<      �� *Date+ �� StringFormat$ dd MMM yyyy��5=      5?      �� 5@   
   -   5         ��Name$ logo_voiture��5A      $	��285��5B      $	��127��5C      $��	0,10,10,0q�5D      $��Right=�5E      $	��Top=�5F      $��/logo-voiture.jpg��5G      $
��Fill=�5H       �� StretchDirection$
 Both=�6    J� Opacity$ 0Q�64   �� 5I   
   $��74��5J      $��0,51,0,0q�5K      $��Center=�5L      $	��Top=�5M      $��Consultation des emprunts��5N      $��36(�5O      $
��Bold"�5P      �� 5Q   
   -   5         ��Name$ txtBoxTriPrenom��5R      $	��163��5T      $��38��5U      $��
69,257,0,0q�5V      $
��Left=�5W      $	��Top=�5X      
�������$�� ��5[       �� TextWrapping$
 Wrap=�5\      �� 5]   
   $��112,226,0,0q�5^      $
��Left=�5_      $	��Top=�5`      $��Tri par nom :��5a      �� 5b   
   $��390,226,0,0q�5c      $
��Left=�5d      $	��Top=�5e      $��Date début :��5f      �� 5g   
   $��670,226,0,0q�5h      $
��Left=�5i      $	��Top=�5j      $��
Date fin :��5k      �� 5l   
   -   5         ��Name$ buttonSupprimerSelection��5m      $	��125��5n      $��39��5o      $��942,252,0,0q�5p      
�������$
��Left=�5r      $	��Top=�5s      $��Supprimer sélection��5u      (  "System.Windows.Controls.DatePicker  5v   
   -   5          Name$ dateDebutTri��5w      $	��167��5x      $��38��5y      $��344,257,0,0q�5z      $
��Left=�5{      
�������$	��Top=�5}      5~        5   
   -   5        $ 
dateFinTri��5�      $	��167��5�      $��38��5�      $��625,257,0,0q�5�      $
��Left=�5�      $	��Top=�5�      
�������5�      �� 5�   
   -   5        $ buttonEditEmprunt��5�      $	��216��5�      ���	#FFFBFBD0$��53��5�      $��
0,0,327,21q�5�      $��Right=�5�      $��Bottom=�5�      $$��Modifier emprunt sélectionné��5�      $��14(�64   �� 5�   
   -   5        $ buttonSupprEmprunt��5�      $	��216��5�      $��53��5�      ���	#FFFBFBD0$��	0,0,42,21q�5�      $��Right=�5�      $��Bottom=�5�      $%��Supprimer emprunt sélectionné��5�      $��14(�65   �� 5�   
   -	   5        $ buttonAddEmpunt��5�      $	��216��5�      $��53��5�      $��
0,0,608,21q�5�      $��Right=�5�      $��Bottom=�5�      ���	#FFFBFBD0$��Ajouter un emprunt��5�      $��14(�6*   �� 5�   
   -
   5        $ buttonRefresh��5�      $��38��5�      $��39��5�      $��	42,35,0,0q�5�      $
��Left=�5�      $	��Top=�5�      .��5�      �� -   5        $ imageRefresh��5�      $��/refresh2.jpg��6+   5�      �� 5�   
   $��	31,70,0,0q�5�      $
��Left=�5�      $	��Top=�5�      $��Rafraîchir��5�      5�      5�      