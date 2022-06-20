/**
 * @file Emprunte.cs
 * Classe de categorie de vehicule.
 * @author Guyon Remy
 * @author Collombet Nathan
 * @author Corvaisier-Palluy Leo
 * @date Juin 2022
 * @version 1.0
 */
using SAE01;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace SAE01 {

    /// <summary>
    /// Permet de créer des objet CategorieVehicule et de les ajouter, modifier ou supprimer de la base de donnée.
    /// Implémente le CRUD
    /// </summary>
	public class CategorieVehicule : CRUD<CategorieVehicule>  {
		public long IdCategorie { get; set; }
		public string LibelleCategorie { get; set; }


		public CategorieVehicule() { }
		public void Delete() {
			throw new System.NotImplementedException("Not implemented");
		}
		public void Update() {
			throw new System.NotImplementedException("Not implemented");
		}
		public void Read() {
			throw new System.NotImplementedException("Not implemented");
		}
		public void Create() {
			throw new System.NotImplementedException("Not implemented");
		}

        public List<CategorieVehicule> FindAll()
		{
            return this.FindBySelection("select * from [IUT-ACY\\guyonr].categorieVehicule;");
        }


        //faire une recherche avec l'id de la catégorie
        public CategorieVehicule FindByID(long idCategorie)
        {
            string requete = "select * from [IUT-ACY\\guyonr].categorieVehicule WHERE idcategorie = " + idCategorie.ToString() + " ;";
            return this.FindBySelection(requete)[0];
        }

        public List<CategorieVehicule> FindBySelection(string criteres)
        {
            List<CategorieVehicule> listeGroupes = new List<CategorieVehicule>();
            DataAccess access = new DataAccess();
            SqlDataReader reader;
            try
            {
                if (access.openConnection())
                {
                    reader = access.getData(criteres);
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            CategorieVehicule uneCat = new CategorieVehicule();
                            uneCat.IdCategorie = reader.GetInt32(0);
                            uneCat.LibelleCategorie = reader.GetString(1);
                            listeGroupes.Add(uneCat);
                        }
                    }
                    else
                    {
                        System.Windows.MessageBox.Show("No rows found.", "Pas de lignes");
                    }
                    reader.Close();
                    access.closeConnection();
                }
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message, "Categorie exception");
            }
            return listeGroupes;
        }

        

        //private List<Vehicule> vehicules;
		//public List<Vehicule> Vehicules { get; set; }

	}

}
