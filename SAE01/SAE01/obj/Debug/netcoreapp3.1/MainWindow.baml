   M S B A M L   `   `   `  ����@  <SAE01, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:SAE01SAE01  5          SAE01.MainWindow   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      %localclr-namespace:SAE01     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5        � Title$  
MainWindow��5      $
��1000��5	      $	��800��5
      $
��1000��5      $	��800��5       � 
ResizeMode$ 	CanResize=�5       � DataContext 5         SAE01.ApplicationData  5   
   .��5      �  � ColumnDefinitions 5   
   �� 5      $
��201* �6   �� 5      $
��199* �6   .+�5   
   �� -   5         ��Name$ lsCatVehicule��5      $	��200��5      $	��206��5      $��
10,244,0,0q�5      $
��Left=�5      $	��Top=�5      ��5       �� *ListeCategoriesVehicule+ �� View 5!      �� 5"      .P�5#      ��  �� Width$	 200��5$      $��Catégorie véhicule��5&       �� DisplayMemberBinding 5%      �� *LibelleCategorie+5&      5'      5)      �� 5*   
   -   5        $ 
lsVehicule��5+      $	��200��5,      $	��206��5-      $��282,244,0,0q�5.      $
��Left=�5/      $	��Top=�50      ��51      �� *ListeCategoriesVehicule+ 52      �� 53      .P�54      �� $	 200��55      $��	Véhicule��57       56      �� *LibelleCategorie+57      58      5:      � 5;   
   $��1��6   .+�5=      �� $	��244��5>      $��	68,28,0,0q�5?      $
��Left=�5@      $	��Top=�5A      $!��Enregistrement d'un emprunt��5B      $��18(�5C      �� 5D      $��
33,110,0,0q�5E      $
��Left=�5F      $	��Top=�5G      $��
Vehicule :��5H      �� 5I      $��
33,160,0,0q�5J      $
��Left=�5K      $	��Top=�5L      $��
Employé :��5M      �� 5N      $��
33,227,0,0q�5O      $
��Left=�5P      $	��Top=�5Q      $��Date :��5R      �� 5S      $��
33,312,0,0q�5T      $
��Left=�5U      $	��Top=�5V      $��	Mission :��5W      �� 5X      -   5         ��Name$ txtBoxMission��5Y      $	��427��5Z      $��81��5[      $��
33,343,0,0q�5\      $
��Left=�5]      $	��Top=�5^      $�� ��5_      	 �� TextWrapping$
	 Wrap=�5`      �� 5a      -   5        
 ��Name$
 
cbVehicule��5b      $	��170��5c      $��26��5d      $��190,110,0,0q�5e      $
��Left=�5f      $	��Top=�5g      �� 5h      -   5        $
 	cbEmploye��5i      $	��170��5j      $��26��5k      $��190,160,0,0q�5l      $
��Left=�5m      $	��Top=�5n      (  "System.Windows.Controls.DatePicker  5o      -   5          Name$ dpDate��5p      $	��170��5q      $��26��5r      $��190,227,0,0q�5s      $
��Left=�5t      $	��Top=�5u      �� 5v      $	��130��5w      $��44��5x      $��318,452,0,0q�5y      $
��Left=�5z      $	��Top=�5{      $��Valider��5|      5}      &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ 	dgConcess��5�      $	��217��5�      $��10,472,10,0q�5�      $	��Top=�5�         AutoGenerateColumns$ False��5�      ��5�      �� *ListeEmprunts+   Columns 5�      0  *System.Windows.Controls.DataGridTextColumn  5�      ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$	 100 5�         Header$ num Employé��5�      1  +System.Windows.Controls.DataGridBoundColumn   Binding 5�      �� *	IdEmploye+5�        5�      $	 100 5�      $ num Vehicule��5�       5�      �� *
IdVehicule+5�        5�      $ * 5�      $ Mission��5�       5�      �� *	Mission+5�        5�      $ * 5�      $
 Date��5�       5�      �� *IdDate+5�      5�      �� 5�   
   -   5         ��Name$ logo_voiture��5�      $��10,10,234,672q�5�      $#��/logo-de-voiture-50683558.jpg��5�      $
��Fill=�5�      �� 5�   
   $	��185��5�      $��46��5�      $��
297,38,0,0q�5�      $
��Left=�5�      $	��Top=�5�      $��EMPRUNT 3000��5�      $��24(�5�      5�      5�      