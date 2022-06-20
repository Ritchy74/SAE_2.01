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
    /// Logique d'interaction pour Window1.xaml
    /// </summary>
    public partial class WindowCreer : Window
    {
        private MainWindow maMainWindow;
        private Emprunte monEmprunt;

        public WindowCreer()
        {
            InitializeComponent();
            

        }
        public WindowCreer(Window owner)
        {
            this.Owner = owner;
            InitializeComponent();

            this.maMainWindow = ((MainWindow)(this.Owner));
            this.monEmprunt = ((Emprunte)(maMainWindow.dgConcess.SelectedItem));

            //véhicules
            cbVehicule.ItemsSource = ApplicationData.ListeVehicules;

            //employés
            lvSaisieEmploye.ItemsSource = ApplicationData.ListeEmployesBinding;

            //si on est en train d'edit
            if (this.maMainWindow.laFenetreActive == MainWindow.FenetreAcive.FENETRE_EDIT)
            {
                //on cache le label enregistrer pour afficher celui d'édition
                this.labelEnregistrer.Visibility = Visibility.Hidden;
                this.labelEdit.Visibility = Visibility.Visible;
                //pareil pour les boutons de validation
                this.buttonValiderCreation.Visibility = Visibility.Hidden;
                this.buttonValiderEdit.Visibility = Visibility.Visible;

                //titre de la fenetre
                this.Title = "Modifier";

                //pré remplir les champs
                this.txtBoxSaisieEmploye.Text = this.monEmprunt.Employe.Nom;
                this.dpSaisieDate.Text = this.monEmprunt.Date.ToString();
                this.txtBoxSaisieMission.Text = this.monEmprunt.Mission;

                //Obligé de faire comme ça pour le véhicule sélectionné dans le combobox
                foreach (Vehicule test in ApplicationData.ListeVehicules)
                    if (test.IdVehicule == this.monEmprunt.IdVehicule)
                        this.cbVehicule.SelectedItem = test;
            }
            else
            {
                //on cache le label d'édition pour afficher celui d'enregistrement
                this.labelEdit.Visibility = Visibility.Hidden;
                this.labelEnregistrer.Visibility = Visibility.Visible;
                //pareil pour les boutons de validation
                this.buttonValiderCreation.Visibility = Visibility.Visible;
                this.buttonValiderEdit.Visibility = Visibility.Hidden;

                //titre de la fenetre
                this.Title = "Créer";

            }

            this.UpdateListeEmploye();
            this.lvSaisieEmploye.SelectedIndex = 0;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (! (maMainWindow.laFenetreActive == MainWindow.FenetreAcive.FENETRE_CONSULTATION))
                this.Owner.Close();
        }


        private void ChangerFenetre()
        {
            //changement fenetre
            maMainWindow.laFenetreActive = MainWindow.FenetreAcive.FENETRE_CONSULTATION;
            maMainWindow.Show();
            //update
            maMainWindow.updateListeEmprunts();
            maMainWindow.InitializeComponent();
            //closing
            this.Close();
        }
        private void buttonValiderEdit_Click(object sender, RoutedEventArgs e)
        {

            //récupération des nouvelles valeurs
            string mission = txtBoxSaisieMission.Text;
            long idVehicule = ((Vehicule)(cbVehicule.SelectedItem)).IdVehicule;
            long idEmploye = ((Employe)(lvSaisieEmploye.SelectedItem)).IdEmploye;
            string laDate = ((DateTime)dpSaisieDate.SelectedDate).ToShortDateString();
            ((Emprunte)(this.maMainWindow.dgConcess.SelectedItem)).Update(idVehicule,idEmploye,laDate,mission);
            //toEdit.Update();
            this.ChangerFenetre();
            
        }
        private void buttonValiderCreation_Click(object sender, RoutedEventArgs e)
        {
            //création emprunt
            Emprunte toAdd = new Emprunte();
            toAdd.Mission = txtBoxSaisieMission.Text;
            toAdd.IdVehicule = ((Vehicule)(cbVehicule.SelectedItem)).IdVehicule;
            toAdd.IdEmploye = ((Employe)(lvSaisieEmploye.SelectedItem)).IdEmploye;
            toAdd.Date = (DateTime)dpSaisieDate.SelectedDate;
            toAdd.Create();
            //retour sur la page principal
            this.ChangerFenetre();
        }

        private void txtBoxSaisieEmploye_KeyUp(object sender, KeyEventArgs e)
        {
            this.UpdateListeEmploye();
        }

        private void UpdateListeEmploye()
        {
            string leNom = txtBoxSaisieEmploye.Text.ToUpper().ToString();
            Regex regex = new Regex(@"" + leNom);
            ApplicationData.ListeEmployesBinding.Clear();

            foreach (Employe unEmploye in ApplicationData.ListeEmployes)
            {
                //vérif sur le nom
                if (regex.IsMatch(unEmploye.Nom.ToUpper()) || string.IsNullOrEmpty(leNom))
                {
                    ApplicationData.ListeEmployesBinding.Add(unEmploye);
                }
            }
            //pour debug
            lvSaisieEmploye.Items.Refresh();
        }

        private void buttonReturnToMain_Click(object sender, RoutedEventArgs e)
        {
            this.ChangerFenetre();
        }
    }
}
