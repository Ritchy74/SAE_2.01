using System;
using System.Collections.Generic;
using System.Text;

namespace SAE01
{
    public class ApplicationData
    {
        public ApplicationData()
        {
            loadApplicationData();
        }
        public static List<Emprunte> ListeEmprunts
        {
            get;
            set;
        }
        public static List<Emprunte> ListeEmpruntsBinding
        {
            get;
            set;
        }
        public static List<Vehicule> ListeVehicules
        {
            get;
            set;
        }
        public static List<Employe> ListeEmployes
        {
            get;
            set;
        }
        public static List<Employe> ListeEmployesBinding 
        {
            get;
            set;
        }
        public static List<CategorieVehicule> ListeCategoriesVehicule
        {
            get;
            set;
        }

        public static void loadApplicationData()
        {
            //Emprunte unEmprunt = new Emprunte();
            //ListeEmprunts = unEmprunt.FindAll();

            //emprunts
            Emprunte unEmprunt = new Emprunte();
            ListeEmprunts = unEmprunt.FindAll();
            ListeEmpruntsBinding = unEmprunt.FindAll();

            //catégories
            CategorieVehicule uneCat = new CategorieVehicule();
            ListeCategoriesVehicule = uneCat.FindAll();

            //employés
            Employe unEmploye = new Employe();
            ListeEmployes = unEmploye.FindAll();
            ListeEmployesBinding = unEmploye.FindAll();

            //véhicules
            Vehicule leVehicule = new Vehicule();
            ListeVehicules = leVehicule.FindAll();



        }


        


    }
}
