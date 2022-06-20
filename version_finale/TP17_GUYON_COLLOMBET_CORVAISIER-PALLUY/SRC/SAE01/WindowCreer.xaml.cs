/**
 * @file WindowCreer.xaml.cs
 * Fenetre secondaire de l'IHM (creer et modifier)
 * @author Guyon Remy
 * @author Collombet Nathan
 * @author Corvaisier-Palluy Leo
 * @date Juin 2022
 * @version 1.0
 */

using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SAE01
{
    /// <summary>
    /// Classe de notre fenêtre de création/ modification.
    /// </summary>
    public partial class WindowCreer : Window
    {
        private MainWindow maMainWindow;
        private Emprunte monEmprunt;

        /// <summary>
        /// créer une fenêtre WindowCreer (ce constructeur n'est jamais utilisé).
        /// </summary>
        public WindowCreer()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Créer une fenêtre WindowCreer et initialise les composants, fait le binding.
        /// Récupération de la fenêtre qui a créée celle-ci pour accèder à ses éléments.
        /// On utilise la même fenêtre pour créer et modifier, seuls les boutons changent et les champs sont pré-remplis.
        /// </summary>
        /// <param name="owner">La fenêtre (objt Window) qui a créé cet objet</param>
        public WindowCreer(Window owner)
        {
            //on initialise
            InitializeComponent();

            //on a passé en parametre la fenêtre qui a créée cet objet (dans notre cas, c'est sytématiquement MainWindow)
            this.Owner = owner;
            //on initialise 2 champs privés qui nous servirons plus tard 
            this.maMainWindow = ((MainWindow)(this.Owner));     //le cast est nécessaire pour pouvoir accéder aux champs & méthodes de notre MainWindow
            this.monEmprunt = ((Emprunte)(this.maMainWindow.dgConcess.SelectedItem));    //idem ici

            //binding combobox catégorie véhicules
            cbCatVehicule.ItemsSource = ApplicationData.ListeCategoriesVehicule;
            //binding listeview véhicules
            lvSaisieVehicule.ItemsSource = ApplicationData.ListeVehiculesBinding;
            //binding listeview employés
            lvSaisieEmploye.ItemsSource = ApplicationData.ListeEmployesBinding;

            //si on est en train d'edit
            if (this.maMainWindow.laFenetreActive == MainWindow.FenetreAcive.FENETRE_EDIT)
            {
                //titre de la fenetre
                this.Title = "Modifier";
                //on cache le label enregistrer pour afficher celui d'édition
                this.labelEnregistrer.Visibility = Visibility.Hidden;
                this.labelEdit.Visibility = Visibility.Visible;
                //pareil pour les boutons de validation
                this.buttonValiderCreation.Visibility = Visibility.Hidden;
                this.buttonValiderEdit.Visibility = Visibility.Visible;

                //pré remplir les champs (avec les valeurs de l'objet qu'on veut modifier)
                this.txtBoxSaisieEmploye.Text = this.monEmprunt.Employe.Nom;
                this.dpSaisieDate.Text = this.monEmprunt.Date.ToString();
                this.txtBoxSaisieMission.Text = this.monEmprunt.Mission;
                //pré remplir le véhicule
                foreach (Vehicule leVehicule in ApplicationData.ListeVehicules)   //on fais une comparaison pour aller chercher l'objet du datacontexte 
                    if (leVehicule.IdVehicule == this.monEmprunt.IdVehicule)      //si on utilise l'objet venant de "monEmprunt", cela ne fonctionnerait pas
                        this.lvSaisieVehicule.SelectedItem = leVehicule;
                //pré remplir la catégorie véhicule
                foreach (CategorieVehicule laCat in ApplicationData.ListeCategoriesVehicule)   //pareil ici
                    if (laCat.IdCategorie == this.monEmprunt.Vehicule.CategorieVehicule.IdCategorie)      
                        this.cbCatVehicule.SelectedItem = laCat;

                //on met à jour le listView des employés
                this.UpdateListeEmploye();
                //on pre-selectionne le premier item de la listeview employé
                this.lvSaisieEmploye.SelectedIndex = 0;
            }
            //si on est en train de créer
            else
            {
                //titre de la fenetre
                this.Title = "Créer";
                //on cache le label d'édition pour afficher celui d'enregistrement
                this.labelEdit.Visibility = Visibility.Hidden;
                this.labelEnregistrer.Visibility = Visibility.Visible;
                //pareil pour les boutons de validation
                this.buttonValiderCreation.Visibility = Visibility.Visible;
                this.buttonValiderEdit.Visibility = Visibility.Hidden;
                //on met à jour le listView des employés
                this.UpdateListeEmploye();
            }
            
        }
               

        /// <summary>
        /// Permet de vérifier si tous les champs sont remplis et d'afficher un message si ce n'est pas le cas
        /// </summary>
        /// <returns>Booléen si un des champs n'est pas remplis</returns>
        private bool IsChampsRemplis()
        {
            bool res = true;
            //vérif employé
            if (lvSaisieEmploye.SelectedItem is null)
            {
                MessageBox.Show("Veuillez sélectionner un employé", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                res = false;
            }
            //vérif véhicule
            else if (lvSaisieVehicule.SelectedItem is null)
            {
                MessageBox.Show("Veuillez sélectionner un véhicule", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                res = false;
            }
            //vérif date
            else if (dpSaisieDate.SelectedDate is null)
            {
                MessageBox.Show("Veuillez sélectionner une date", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                res = false;
            }
            else if (txtBoxSaisieMission.Text.Contains("'"))
            {
                MessageBox.Show("Merci de ne pas écrire de simple guillemets \"  '  \" dans le champ mission", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                res = false;
            }
                
            
            return res;
        }

        /// <summary>
        /// Permet de changer de fenêtre
        /// Ferme la courrante et ré-affiche la principale
        /// </summary>
        private void ChangerFenetre()
        {
            //update
            maMainWindow.RefreshData();
            //changement fenetre
            maMainWindow.laFenetreActive = MainWindow.FenetreAcive.FENETRE_CONSULTATION;
            maMainWindow.Show();
            //fermer la fenêtre actuelle
            this.Close();
        }

        /// <summary>
        /// Permet de rafraîchir la listview contenant les employés
        /// Fais une comparaison avec les Employés stockés en mémoire et le nom écrit (dans le textbox qui sert de filtre)
        /// </summary>
        private void UpdateListeEmploye()
        {
            //regex -> "g" affiche tous les employés qui contiennent un g dans leur Nom
            string leNom = txtBoxSaisieEmploye.Text.ToUpper().ToString();
            Regex regex = new Regex(@"" + leNom);
            //mise à jour de la liste à bind
            ApplicationData.ListeEmployesBinding.Clear();
            foreach (Employe unEmploye in ApplicationData.ListeEmployes)
            {
                //vérif sur le nom
                if (regex.IsMatch(unEmploye.Nom.ToUpper()) || string.IsNullOrEmpty(leNom))
                {
                    ApplicationData.ListeEmployesBinding.Add(unEmploye);
                }
            }
            //refresh items
            lvSaisieEmploye.Items.Refresh();
        }

        /// <summary>
        /// Permet de rafraîchir la listview contenant les véhicules
        /// Fais une comparaison avec les Vehicule stockés en mémoire et la catégorie de véhicule sélectionée (dans le combobox qui sert de filtre)
        /// </summary>
        private void UpdateListeVehicules()
        {
            if (!(cbCatVehicule.SelectedItem is null))
            {
                ApplicationData.ListeVehiculesBinding.Clear();
                foreach (Vehicule leVehicule in ApplicationData.ListeVehicules)
                {

                    if (leVehicule.CategorieVehicule.IdCategorie == ((CategorieVehicule)(cbCatVehicule.SelectedItem)).IdCategorie)
                    {
                        ApplicationData.ListeVehiculesBinding.Add(leVehicule);
                    }
                }
                //refresh du listeview
                lvSaisieVehicule.Items.Refresh();
            }
        }

        /// <summary>
        /// Permet de vérifier si un emprunt passé en paramètres existe déjà dans la mémoire
        /// </summary>
        /// <param name="lEmprunt">L'objet Emprunt qu'on compare à la liste que l'on a en mémoire</param>
        /// <returns>true si l'emprunt existe déjà, sinon false</returns>
        private bool CheckEmprunteDejaExistant(Emprunte lEmprunt)
        {
            bool res = false;
            foreach (Emprunte emprunt in ApplicationData.ListeEmprunts)
            {
                if (emprunt.IdEmploye == lEmprunt.IdEmploye && emprunt.IdVehicule == lEmprunt.IdVehicule && emprunt.Date == lEmprunt.Date)
                {
                    //si on est sur la fenêtre de modification, l'ancien omployé peut être le même que le nouveau (en changeant juste la mission par exemple)
                    if (!(maMainWindow.laFenetreActive == MainWindow.FenetreAcive.FENETRE_EDIT && emprunt.IdEmploye == this.monEmprunt.IdEmploye && emprunt.IdVehicule == this.monEmprunt.IdVehicule && emprunt.Date == this.monEmprunt.Date))
                    {
                        res = true;
                        MessageBox.Show("Cet emprunt existe déjà", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
            return res;
        }

        /// <summary>
        /// Evenement quand l'utilisateur clique sur le bouton de validation de la modification
        /// Vérification si le nouvel emprunt existe déjà
        /// Bascule vers la page principale
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonValiderEdit_Click(object sender, RoutedEventArgs e)
        {
            //ssi tt les champs remplis
            if (IsChampsRemplis())
            {
                //récupération nouvelles valeurs
                string mission = txtBoxSaisieMission.Text;
                long idVehicule = ((Vehicule)(lvSaisieVehicule.SelectedItem)).IdVehicule;
                long idEmploye = ((Employe)(lvSaisieEmploye.SelectedItem)).IdEmploye;
                string laDate = ((DateTime)dpSaisieDate.SelectedDate).ToShortDateString();

                //vérif si emprunt pas déjà existant
                Emprunte empruntVerif = new Emprunte { Date = (DateTime)dpSaisieDate.SelectedDate, IdVehicule = idVehicule, IdEmploye = idEmploye };
                if (!CheckEmprunteDejaExistant(empruntVerif))
                {
                    //update emprunt avec valeurs récupérées
                    this.monEmprunt.Update(idVehicule, idEmploye, laDate, mission);
                    //retourne sur fenetre principale
                    this.ChangerFenetre();
                }
            }
        }

        /// <summary>
        /// Evenement quand l'utilisateur clique sur le bouton de validation de la modification
        /// Vérification si le nouvel emprunt existe déjà
        /// Bascule vers la page principale 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonValiderCreation_Click(object sender, RoutedEventArgs e)
        {
            //ssi tt les champs remplis
            if (IsChampsRemplis())
            {
                //récupération valeurs
                Emprunte toAdd = new Emprunte();
                toAdd.Mission = txtBoxSaisieMission.Text;
                toAdd.IdVehicule = ((Vehicule)(lvSaisieVehicule.SelectedItem)).IdVehicule;
                toAdd.IdEmploye = ((Employe)(lvSaisieEmploye.SelectedItem)).IdEmploye;
                toAdd.Date = (DateTime)dpSaisieDate.SelectedDate;

                //vérif si emprunt pas déjà existant
                if (!CheckEmprunteDejaExistant(toAdd))
                {
                    //création emprunt
                    toAdd.Create();
                    //retour sur fenetre principale
                    this.ChangerFenetre();
                }
                

            }
        }

        /// <summary>
        /// Evênement quand la fenêtre est fermée
        /// Si on a appuyé sur la croix (en haut à droite) pour la fermer, alors on ferme aussi la fenêtre principale
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //si on ferme la fenêtre et qu'on est en train de modifier ou de créer (donc l'utilisateur veut juste fermer le programme)
            if (!(maMainWindow.laFenetreActive == MainWindow.FenetreAcive.FENETRE_CONSULTATION))
                //alors on ferme la première fenêtre (la fenêtre courante se ferme aussi mais automatiquement -> dans le code XAML)
                this.Owner.Close();
        }

        /// <summary>
        /// Evenement quand l'utilisateur écrit dans le filtre sur le nom des employés
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtBoxSaisieEmploye_KeyUp(object sender, KeyEventArgs e)
        {
            this.UpdateListeEmploye();
        }

        /// <summary>
        /// Evènement quand l'utilisateur appuie sur le bouton annuler
        /// On le renvoie sur la page principale
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonReturnToMain_Click(object sender, RoutedEventArgs e)
        {
            this.ChangerFenetre();
        }

        /// <summary>
        /// Evènement quand l'utilisateur appuie sur le logo poubelle à droite de la zone de texte de la mission
        /// Cela supprime ce qu'il y a dans la zone de texte de la mission
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonDeleteMission_Click(object sender, RoutedEventArgs e)
        {
            this.txtBoxSaisieMission.Text = "";
        }

        /// <summary>
        /// Evènement quand l'utilisateur sélectionne une catégorie
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbCatVehicule_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateListeVehicules();
        }
    }
}
