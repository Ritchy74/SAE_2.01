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
        public List<Emprunte> ListeEmprunts
        {
            get;
            set;
        }
        public void loadApplicationData()
        {
            //Emprunte unEmprunt = new Emprunte();
            //ListeEmprunts = unEmprunt.FindAll();
            Emprunte unEmprunt = new Emprunte();
            ListeEmprunts = unEmprunt.FindAll();

            CategorieVehicule uneCat = new CategorieVehicule();
            ListeCategoriesVehicule = uneCat.FindAll();



        }

        //public static List<string> ListeTest
        //{
        //    get;
        //    set;
        //}
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
        public static List<CategorieVehicule> ListeCategoriesVehicule
        {
            get;
            set;
        }


    }
}
