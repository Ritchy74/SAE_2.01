   M S B A M L   `   `   `  ����@  <SAE01, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:SAE01SAE01  5          SAE01.MainWindow   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      %localclr-namespace:SAE01     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5        � Title$  Emprunt vehicule��5      $
��1200��5	      $	��700��5
      $
��1200��5      $	��700��5       � 
ResizeMode$ 	CanResize=�5      
�������.��5      �  � ColumnDefinitions 5   
   .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ 	dgConcess��5      $��10,363,10,93q�5         AutoGenerateColumns$ False��5         CanUserAddRows$ False��5         CanUserDeleteRows$ False��5         CanUserReorderColumns$ False��5         CanUserResizeColumns$ False��5      	   CanUserResizeRows$	 False��5      
   CanUserSortColumns$
 False��5      
�������   
IsReadOnly$
 True��5         Columns 5       0  *System.Windows.Controls.DataGridTextColumn  5!      ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$ 1* 5"         Header$	 Nom��5$      1  +System.Windows.Controls.DataGridBoundColumn   Binding 5#      �� *Employe.Nom+5$        5%      $ 1* 5&      $ Prénom��5(       5'      �� *Employe.Prenom+5(        5)      $ 2* 5*      $
 Mail��5,       5+      �� *Employe.Mail+5,        5-      $ 1* 5.      $	 Tel��50       5/      �� *Employe.TelEmploye+50        51      $ 2* 52      $ Vehicule��54       53      �� *Vehicule.LibelleVehicule+54        55      $ 3* 56      $ Mission��58       57      �� *	Mission+58        59      $ * 5:      $
 Date��5<       5;      �� *Date+ �� StringFormat$ dd MMM yyyy��5<      5>      �� 5?   
   -   5         ��Name$ logo_voiture��5@      $	��285��5A      $	��127��5B      $��	0,10,10,0q�5C      $��Right=�5D      $	��Top=�5E      $#��/logo-de-voiture-50683558.jpg��5F      $
��Fill=�5G      �� 5H   
   $��74��5I      $��0,51,0,0q�5J      $��Center=�5K      $	��Top=�5L      $��Consultation des emprunts��5M      $��36(�5N      $
��Bold"�5O      �� 5P   
   -   5         ��Name$ txtBoxTriPrenom��5Q      $	��163��5R      $��38��5S      $��
69,257,0,0q�5T      $
��Left=�5U      $	��Top=�5V      
�������$�� ��5Y       �� TextWrapping$
 Wrap=�5Z      �� 5[   
   $��112,226,0,0q�5\      $
��Left=�5]      $	��Top=�5^      $��Tri par nom :��5_      �� 5`   
   $��390,226,0,0q�5a      $
��Left=�5b      $	��Top=�5c      $��Date début :��5d      �� 5e   
   $��670,226,0,0q�5f      $
��Left=�5g      $	��Top=�5h      $��
Date fin :��5i      �� 5j   
   -   5         ��Name$ buttonSupprimerSelection��5k      $	��125��5l      $��39��5m      $��942,252,0,0q�5n      $
��Left=�5o      $	��Top=�5p      $��Supprimer sélection��5r      (  "System.Windows.Controls.DatePicker  5s   
   -   5          Name$ dateDebutTri��5t      $	��167��5u      $��38��5v      $��344,257,0,0q�5w      $
��Left=�5x      
�������$	��Top=�5z      5{        5|   
   -   5        $ 
dateFinTri��5}      $	��167��5~      $��38��5      $��625,257,0,0q�5�      $
��Left=�5�      $	��Top=�5�      
�������5�      �� 5�   
   -   5        $ buttonEditEmprunt��5�      $	��216��5�      $��53��5�      $��
0,0,327,21q�5�      $��Right=�5�      $��Bottom=�5�      $$��Modifier emprunt sélectionné��5�      �� 5�   
   -   5        $ buttonSupprEmprunt��5�      $	��216��5�      $��53��5�      $��	0,0,42,21q�5�      $��Right=�5�      $��Bottom=�5�      $%��Supprimer emprunt sélectionné��5�      �� 5�   
   -	   5        $ buttonAddEmpunt��5�      $	��216��5�      $��53��5�      $��
0,0,608,21q�5�      $��Right=�5�      $��Bottom=�5�      $��Ajouter un emprunt��5�      �� 5�   
   -
   5        $ buttonRefresh��5�      $��38��5�      $��39��5�      $��	42,35,0,0q�5�      $
��Left=�5�      $	��Top=�5�      .��5�      �� -   5        $ imageRefresh��5�      $��/refresh2.jpg��6*   5�      �� 5�   
   $��	31,70,0,0q�5�      $
��Left=�5�      $	��Top=�5�      $��Rafraîchir��5�      5�      5�      