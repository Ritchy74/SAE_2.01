/**
 * @file ApplicationData.cs
 * Fichier contenant les listes d'objets utilisées pour le binding.
 * @author Guyon Remy
 * @author Collombet Nathan
 * @author Corvaisier-Palluy Leo
 * @date Juin 2022
 * @version 1.0
 */

using System;
using System.Collections.Generic;
using System.Text;

namespace SAE01
{
    /// <summary>
    /// Classe servant de DataContexte pour le binding.
    /// On y retrouve nos listes d'objets.
    /// </summary>
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
        public static List<Vehicule> ListeVehiculesBinding
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
            ListeEmpruntsBinding = new List<Emprunte>(ListeEmprunts);

            //catégories
            CategorieVehicule uneCat = new CategorieVehicule();
            ListeCategoriesVehicule = uneCat.FindAll();

            //employés
            Employe unEmploye = new Employe();
            ListeEmployes = unEmploye.FindAll();
            ListeEmployesBinding = new List<Employe>(ListeEmployes);

            //véhicules
            Vehicule leVehicule = new Vehicule();
            ListeVehicules = leVehicule.FindAll();
            ListeVehiculesBinding = new List<Vehicule>(ListeVehicules);


        }


        


    }
}
