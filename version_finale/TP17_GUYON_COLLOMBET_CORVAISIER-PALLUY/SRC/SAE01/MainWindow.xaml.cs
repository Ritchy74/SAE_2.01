/**
 * @file MainWindow.xaml.cs
 * Fenetre principale de l'IHM
 * @author Guyon Remy
 * @author Collombet Nathan
 * @author Corvaisier-Palluy Leo
 * @date Juin 2022
 * @version 1.0
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Text.RegularExpressions;
using System.Windows.Controls.Primitives;

namespace SAE01
{
    /// <summary>
    /// Classe de notre fenêtre principale
    /// </summary>
    public partial class MainWindow : Window
    {
        public enum FenetreAcive { FENETRE_CONSULTATION, FENETRE_CREER, FENETRE_EDIT }
        public FenetreAcive laFenetreActive;

        /// <summary>
        /// créer une fenêtre MainWindow et initialise tous les composants, fait le binding...
        /// </summary>
        public MainWindow()
        {
            //initialize components
            InitializeComponent();
            //load la BDD en mémoire
            ApplicationData.loadApplicationData();
            //initialisation de la fenêtre courante
            this.laFenetreActive = FenetreAcive.FENETRE_CONSULTATION;
            //binding
            this.dgConcess.ItemsSource = ApplicationData.ListeEmpruntsBinding;

        }

        /// <summary>
        /// Permet de rafraîchir le datagrid contenant les emprunts
        /// Fais une comparaison avec les emprunts stockés en mémoire et la date de début, la date de fin, et le nom écrit (dans les filtres)
        /// </summary>
        public void updateListeEmprunts()
        {
            //récupérer le nom
            string leNom = txtBoxTriPrenom.Text.ToUpper().ToString();
            //créer un regex à partir du nom (pour afficher des propositions même si la personne n'a pas fini d'écrire)
            Regex regex = new Regex(@"" + leNom);
            //vider la liste bind
            ApplicationData.ListeEmpruntsBinding.Clear();
            //récupération de la date
            DateTime dateDebut = DateTime.MinValue, dateFin = DateTime.MaxValue;
            //si la date est nulle
            if (!(dateDebutTri.SelectedDate is null)) { dateDebut = dateDebutTri.SelectedDate.Value; }
            if (!(dateFinTri.SelectedDate is null)) { dateFin = dateFinTri.SelectedDate.Value; }

            //on fait une boucle sur tous les emprunts stockés en mémoire
            foreach (Emprunte unEmprunt in ApplicationData.ListeEmprunts)
            {
                //vérif sur le nom
                if (regex.IsMatch(unEmprunt.Employe.Nom.ToUpper()) || string.IsNullOrEmpty(leNom))
                {
                    //vérif sur la date
                    if (unEmprunt.Date >= dateDebut && unEmprunt.Date <= dateFin)
                    {
                        //on ajoute l'objet à la liste bind pour pouvoir l'afficher
                        ApplicationData.ListeEmpruntsBinding.Add(unEmprunt);
                    }
                }
            }
            List<Emprunte> test = ApplicationData.ListeEmpruntsBinding;
            List<Emprunte> test2 = ApplicationData.ListeEmprunts;
            //rafraichir le datagrid
            dgConcess.Items.Refresh();
        }

        /// <summary>
        /// Permet de rafraichir les données en mémoire:
        ///     On refait une requête pour aller récupérer toutes les données de la base de donnée
        /// </summary>
        public void RefreshData() //pour quand une donnée de la BDD est modifiée, supprimée, ajoutée
        {
            //on remet en mémoire tt les tables
            ApplicationData.loadApplicationData();
            //on redonne le datacontexte à dgconcess 
            this.dgConcess.ItemsSource = ApplicationData.ListeEmpruntsBinding;
            //on update la datagrid
            this.updateListeEmprunts();
        }

        /// <summary>
        /// Evênement click sur le bouton de suppression de la sélection
        /// Permet de réinitialiser tous les filtres
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSupprimerSelection_Click(object sender, RoutedEventArgs e)
        {
            dateDebutTri.Text = "";
            dateFinTri.Text = "";
            txtBoxTriPrenom.Text = "";
            updateListeEmprunts();
        }



        /// <summary>
        /// Evênement quand l'utilisateur écrit dans le textbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtBoxTriPrenom_KeyUp(object sender, KeyEventArgs e)
        {
            updateListeEmprunts();
        }

        /// <summary>
        /// Evenement quand l'utilisateur sélectionne une date de début
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dateDebutTri_LostFocus(object sender, RoutedEventArgs e)
        {
            updateListeEmprunts();
        }

        /// <summary>
        /// Evenement quand l'utilisateur sélectionne une date de fin
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dateFinTri_LostFocus(object sender, RoutedEventArgs e)
        {
            updateListeEmprunts();
        }

        /// <summary>
        /// Evenement quand l'utilisateur clique sur le bouton supprimer
        /// Ouverture d'un messagebox au cas où c'est un missclick
        /// On vérifie qu'on a bien sélectionné au moins 1 élément
        /// Si oui, on supprime les éléments en question
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSupprEmprunt_Click(object sender, RoutedEventArgs e)
        {
            //on fait une demande au cas où il s'agit d'un missclick
            MessageBoxResult validSuppr = MessageBox.Show("Etes-vous sûr de vouloir supprimer cet emprunt ?", "Supression", MessageBoxButton.YesNo, MessageBoxImage.Exclamation);
            if (validSuppr == MessageBoxResult.Yes)
            {
                //si aucun item sélectionné
                if (dgConcess.SelectedItem is null)
                {
                    MessageBox.Show("Vous n'avez sélectionné aucune ligne", "Supression", MessageBoxButton.OK, MessageBoxImage.Error);

                }
                else
                {
                    //supprimer tt les lignes
                    foreach (Emprunte lEmprunt in dgConcess.SelectedItems)
                    {
                        lEmprunt.Delete();
                    }
                    //on remet à jour les données en mémoire
                    this.RefreshData();
                }
            }
        }



        /// <summary>
        /// Evenement quand l'utilisateur clique sur le bouton d'ajout d'emprunt
        /// Fais un changement sur l'enum de la fenetre en cours
        /// Créer la nouvelle fenêtre et l'affiche
        /// Cache la fenêtre actuelle
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonAddEmpunt_Click(object sender, RoutedEventArgs e)
        {
            //changement de fenêtre (créer)
            this.laFenetreActive = FenetreAcive.FENETRE_CREER;
            //création de la nouvelle fenêtre
            var window = new WindowCreer(this);
            //on cache la courante
            this.Hide();
            //on affiche la nouvelle
            window.Show();
        }

        /// <summary>
        /// Evenement quand l'utilisateur clique sur le bouton de modification d'emprunt
        /// Vérification qu'il y a bien un et un seul élément sélectionné
        /// Fais un changement sur l'enum de la fenetre en cours
        /// Créer la nouvelle fenêtre et l'affiche
        /// Cache la fenêtre actuelle
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonEditEmprunt_Click(object sender, RoutedEventArgs e)
        {
            if (dgConcess.SelectedItem is null)
            {
                MessageBox.Show("Vous n'avez sélectionné aucune ligne", "Supression", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (dgConcess.SelectedItems.Count > 1)
            {
                MessageBox.Show("Vous avez selectionné plusieurs lignes. Merci d'en sélectionner qu'une seule à la fois", "Modification", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                //changement de fenêtre (édit)
                this.laFenetreActive = FenetreAcive.FENETRE_EDIT;
                //création de la nouvelle fenêtre
                var window = new WindowCreer(this);
                //on cache la courante
                this.Hide();
                //on show la nouvelle
                window.Show();

            }
        }

        /// <summary>
        /// Evenement quandl'utilisateur appuie sur le bouton refresh
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonRefresh_Click(object sender, RoutedEventArgs e)
        {
            RefreshData();
        }


    }
}
