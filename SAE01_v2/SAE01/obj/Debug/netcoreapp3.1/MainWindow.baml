   M S B A M L   `   `   `  ����@  <SAE01, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:SAE01SAE01  5          SAE01.MainWindow   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      %localclr-namespace:SAE01     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5        � Title$  Emprunt vehicule��5      $
��1200��5	      $	��700��5
      $
��1200��5      $	��700��5       � 
ResizeMode$ 	CanResize=�5       � DataContext 5         SAE01.ApplicationData  5   
   .��5      �  � ColumnDefinitions 5   
   .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ 	dgConcess��5      $��10,363,10,93q�5         AutoGenerateColumns$ False��5         
IsReadOnly$
 True��5      ��5      �� *ListeEmpruntsBinding+   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$ 1* 5       	   Header$		 Nom��5"      1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 5!      �� *Employe.Nom+5"        5#      $ 1* 5$      $	 Prénom��5&      
 5%      �� *Employe.Prenom+5&        5'      $ 2* 5(      $
	 Mail��5*      
 5)      �� *Employe.Mail+5*        5+      $ 1* 5,      $		 Tel��5.      
 5-      �� *Employe.TelEmploye+5.        5/      $ 2* 50      $	 Vehicule��52      
 51      �� *Vehicule.LibelleVehicule+52        53      $ 3* 54      $	 Mission��56      
 55      �� *	Mission+56        57      $ * 58      $
	 Date��5:      
 59      �� *Date+ �� StringFormat$ dd MMM yyyy��5:      5<      �� 5=   
   -   5         ��Name$ logo_voiture��5>      $	��285��5?      $	��127��5@      $��	10,10,0,0q�5A      $
��Left=�5B      $	��Top=�5C      $#��/logo-de-voiture-50683558.jpg��5D      $
��Fill=�5E      �� 5F   
   $��74��5G      $��0,51,0,0q�5H      $��Center=�5I      $	��Top=�5J      $��Consultation des emprunts��5K      $��36(�5L      $
��Bold"�5M      �� 5N   
   -   5         ��Name$ txtBoxTriPrenom��5O      $	��163��5P      $��38��5Q      $��
69,257,0,0q�5R      $
��Left=�5S      $	��Top=�5T      $�� ��5V       �� TextWrapping$
 Wrap=�5W      �� 5X   
   $��112,226,0,0q�5Y      $
��Left=�5Z      $	��Top=�5[      $��Tri par nom :��5\      �� 5]   
   $��390,226,0,0q�5^      $
��Left=�5_      $	��Top=�5`      $��Date début :��5a      �� 5b   
   $��670,226,0,0q�5c      $
��Left=�5d      $	��Top=�5e      $��
Date fin :��5f      �� 5g   
   -   5         ��Name$ buttonSupprimerSelection��5h      $	��125��5i      $��39��5j      $��942,252,0,0q�5k      $
��Left=�5l      $	��Top=�5m      $��Supprimer sélection��5o      (  "System.Windows.Controls.DatePicker  5p   
   -   5          Name$ dateDebutTri��5q      $	��167��5r      $��38��5s      $��344,257,0,0q�5t      $
��Left=�5u      $	��Top=�5v      5w        5x   
   -   5        $ 
dateFinTri��5y      $	��167��5z      $��38��5{      $��625,257,0,0q�5|      $
��Left=�5}      $	��Top=�5~      5      �� 5�   
   -   5        $ buttonEditEmprunt��5�      $	��216��5�      $��53��5�      $��
0,0,327,21q�5�      $��Right=�5�      $��Bottom=�5�      $$��Modifier emprunt sélectionné��5�      �� 5�   
   -   5        $ buttonSupprEmprunt��5�      $	��216��5�      $��53��5�      $��	0,0,42,21q�5�      $��Right=�5�      $��Bottom=�5�      $%��Supprimer emprunt sélectionné��5�      �� 5�   
   -	   5        $ buttonAddEmpunt��5�      $	��216��5�      $��53��5�      $��
0,0,608,21q�5�      $��Right=�5�      $��Bottom=�5�      $��Ajouter un emprunt��5�      5�      5�      