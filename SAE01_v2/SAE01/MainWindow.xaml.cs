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

namespace SAE01
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public enum FenetreAcive { FENETRE_CONSULTATION, FENETRE_CREER, FENETRE_EDIT}
        public FenetreAcive laFenetreActive;
        public MainWindow()
        {
            //load
            ApplicationData.loadApplicationData();
            //fenetre init
            this.laFenetreActive = FenetreAcive.FENETRE_CONSULTATION;
            
            //initialize components
            InitializeComponent();

        }

        private void buttonValiderSelection_Click(object sender, RoutedEventArgs e)
        {
            updateListeEmprunts();
        }

        private void buttonSupprimerSelection_Click(object sender, RoutedEventArgs e)
        {
            dateDebutTri.Text = "";
            dateFinTri.Text = "";
            txtBoxTriPrenom.Text = "";
            updateListeEmprunts();
        }


        public void updateListeEmprunts()
        {
            string leNom = txtBoxTriPrenom.Text.ToUpper().ToString();
            Regex regex = new Regex(@"" + leNom);
            ApplicationData.ListeEmpruntsBinding.Clear();

            //si la date est nulle
            DateTime dateDebut=DateTime.MinValue,dateFin=DateTime.MaxValue;
            if (!(dateDebutTri.SelectedDate is null)) { dateDebut = dateDebutTri.SelectedDate.Value; }
            if (!(dateFinTri.SelectedDate is null)) { dateFin = dateFinTri.SelectedDate.Value; }

            foreach (Emprunte unEmprunt in ApplicationData.ListeEmprunts)
            {
                //vérif sur le nom
                if (regex.IsMatch(unEmprunt.Employe.Nom.ToUpper()) || string.IsNullOrEmpty(leNom))
                {
                    //vérif sur la date
                    if (unEmprunt.Date >= dateDebut && unEmprunt.Date <= dateFin) 
                    {
                        ApplicationData.ListeEmpruntsBinding.Add(unEmprunt);
                    }
                }
            }
            //pour debug
            dgConcess.Items.Refresh();
        }

        private void txtBoxTriPrenom_KeyUp(object sender, KeyEventArgs e)
        {
            updateListeEmprunts();
        }

        private void dateDebutTri_LostFocus(object sender, RoutedEventArgs e)
        {
            updateListeEmprunts();
        }

        private void dateFinTri_LostFocus(object sender, RoutedEventArgs e)
        {
            updateListeEmprunts();
        }

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
                    //change r
                    //ApplicationData.loadApplicationData();
                    //this.InitializeComponent();
                }
            }
            updateListeEmprunts();
        }

        private void buttonAddEmpunt_Click(object sender, RoutedEventArgs e)
        {
            this.laFenetreActive = FenetreAcive.FENETRE_CREER;
            var window = new WindowCreer(this);
            this.Hide();
            window.Show();
        }

        private void buttonEditEmprunt_Click(object sender, RoutedEventArgs e)
        {
            if (dgConcess.SelectedItem is null)
            {
                MessageBox.Show("Vous n'avez sélectionné aucune ligne", "Supression", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                this.laFenetreActive = FenetreAcive.FENETRE_EDIT;
                var window = new WindowCreer(this);
                this.Hide();
                window.Show();
                
            }
        }

    }
}
