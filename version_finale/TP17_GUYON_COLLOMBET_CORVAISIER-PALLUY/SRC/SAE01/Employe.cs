/**
 * @file Emprunte.cs
 * Classe d'employe.
 * @author Guyon Remy
 * @author Collombet Nathan
 * @author Corvaisier-Palluy Leo
 * @date Juin 2022
 * @version 1.0
 */
using System;
using System.Collections.Generic;
using System.Data.SqlClient;


namespace SAE01
{
    /// <summary>
    /// Permet de cr�er des objet Employe et de les ajouter, modifier ou supprimer de la base de donn�e.
    /// Impl�mente le CRUD
    /// </summary>
	public class Employe : CRUD<Employe>  {

        private string nom;
        public string Nom
        {
            get
            {
                return this.nom;
            }

            set
            {
                this.nom = value.ToUpper();
            }
        }
		public long IdEmploye { get; set; }

        public string Prenom { get; set; }
		public string TelEmploye { get; set; }
		public string Mail { get; set; }


        public Employe() { }
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


        /// <summary>
        /// Va chercher les donn�es dans la table Employe et les met dans une liste d'objet emprunts
        /// </summary>
        /// <returns>Une liste contenant tous les employ�s de la base de donn�e</returns>
        public List<Employe> FindAll()
        {
            return this.FindBySelection("select * from [IUT-ACY\\guyonr].employe;");
        }


        /// <summary>
        /// Va chercher les donn�es dans la table Employe avec l'id de l'mploye et les met dans une liste d'objet Employe
        /// </summary>
        /// <param name="idEmploye">Long contenant l'id de l'employ� que l'on veut rechercher</param>
        /// <returns>Une liste contenant tous les employes qui ont l'id donn� de la base de donn�e</returns>
        public List<Employe> FindByID(long idEmploye)
        {
            string requete = "select * from [IUT-ACY\\guyonr].employe WHERE idemploye = " + idEmploye.ToString() + " ;";
            return this.FindBySelection(requete);
        }

        /// <summary>
        /// Permet d'ins�rer, supprimer ou modifier des donn�es
        /// </summary>
        /// <param name="setQuery">Requ�te SQL permettant d'ins�rer, supprimer ou modifier des donn�es.</param>
        /// <exception cref="System.Exception">D�clench�e si la connexion, l'�criture/modification/suppression en base ou la d�connexion �chouent.</exception> 
        /// <returns>Une liste contenant les employ�s selectionn�s par la requ�te</returns>
        public List<Employe> FindBySelection(string criteres)
        {
            List<Employe> listeGroupes = new List<Employe>();
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
                            Employe unEmploye = new Employe();
                            unEmploye.IdEmploye = reader.GetInt32(0);
                            unEmploye.Nom = reader.GetString(1);
                            unEmploye.Prenom = reader.GetString(2);
                            unEmploye.TelEmploye = reader.GetString(3);
                            unEmploye.Mail = reader.GetString(4);
                            listeGroupes.Add(unEmploye);
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
                System.Windows.MessageBox.Show(ex.Message, "Employe exception");
            }
            return listeGroupes;
        }

        //private Emprunte[] emprunts;

        //public Emprunte[] Emprunts { get; set; }

    }

}
