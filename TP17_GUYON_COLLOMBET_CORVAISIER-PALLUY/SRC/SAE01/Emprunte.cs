/**
 * @file Emprunte.cs
 * Classe d'emprunt.
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
    /// Permet de cr�er des objet Emprunte et de les ajouter, modifier ou supprimer de la base de donn�e.
    /// Impl�mente le CRUD
    /// </summary>
    public class Emprunte : CRUD<Emprunte>
    {
        /// <summary>
        /// Getter et setter de l'Employe (long)
        /// </summary>
        public long IdEmploye { get; set; }

        /// <summary>
        /// Getter et setter de l'IdVehicule (long)
        /// </summary>
		public long IdVehicule { get; set; }

        /// <summary>
        /// Getter et setter de la Mission (string)
        /// </summary>
		public string Mission { get; set; }

        /// <summary>
        /// Getter et setter de Vehicule (on a pas seulement besoin de l'id, on a parfois besoin de l'objet pour des m�thodes)
        /// </summary>
        public Vehicule Vehicule { get; set; }

        /// <summary>
        /// Getter et setter de Employe (on a pas seulement besoin de l'id, on a parfois besoin de l'objet pour des m�thodes)
        /// </summary>
        public Employe Employe { get; set; }

        /// <summary>
        /// Getter et setter de la Date
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Permet de cr�er un objet Emprunt vide
        /// </summary>
        public Emprunte() { }


        /// <summary>
        /// Va chercher les donn�es dans la table emprunte et les met dans une liste d'objet emprunts
        /// </summary>
        /// <returns>Une liste contenant tous les emprunts de la base de donn�e</returns>
		public List<Emprunte> FindAll()
        {
            return FindBySelection("select * from [IUT-ACY\\guyonr].emprunte;");
        }

        /// <summary>
        /// Va chercher les donn�es dans la table emprunte (en faisant une requ�te sp�cifique, comme un WHERE par exemple) et les met dans une liste d'objet Emprunt
        /// </summary>
        /// <param name="criteres">Requ�te SQL permettant d'ins�rer, supprimer ou modifier des donn�es.</param>
        /// <exception cref="System.Exception">D�clench�e si la connexion, la lecture en base ou la d�connexion �chouent.</exception> 
        /// <returns>Une liste contenant les emprunts selectionn�s par la requ�te</returns>
        public List<Emprunte> FindBySelection(string criteres)
        {
            List<Emprunte> listeGroupes = new List<Emprunte>();
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
                            Emprunte unEmprunt = new Emprunte();
                            //employe
                            Employe unEmploye = new Employe();
                            unEmprunt.IdEmploye = reader.GetInt32(0);
                            unEmprunt.Employe = unEmploye.FindByID(unEmprunt.IdEmploye)[0];
                            //vehicule
                            Vehicule leVehicule = new Vehicule();
                            unEmprunt.IdVehicule = reader.GetInt32(1);
                            unEmprunt.Vehicule = leVehicule.FindByID(unEmprunt.IdVehicule);
                            //date
                            unEmprunt.Date = reader.GetDateTime(2);
                            //mission
                            unEmprunt.Mission = reader.GetString(3);
                            //on rajoute � la liste l'emprunt que l'on vient de cr�er
                            listeGroupes.Add(unEmprunt);
                        }
                    }
                    else
                    {
                        //System.Windows.MessageBox.Show("No rows found for emprunte", "Pas de lignes");
                    }
                    reader.Close();
                    access.closeConnection();
                }
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message, "Emprunte exception");
            }
            return listeGroupes;
        }

        /// <summary>
        /// Utilise l'objet courant (this) pour supprimer une ligne dans la table Emprunte de la base de donn�e.
        /// </summary>
        /// <exception cref="System.Exception">D�clench�e si la connexion, la modification en base ou la d�connexion �chouent.</exception> 
        public void Delete() 
        {
            DataAccess access = new DataAccess();
            try
            {
                if (access.openConnection())
                {
                    //la requ�te
                    string requete = $"DELETE FROM [IUT-ACY\\guyonr].Emprunte WHERE " +
                        $"idEmploye={this.IdEmploye}" +
                        $" and idVehicule={this.IdVehicule}"+
                        $" and date='{this.Date.ToShortDateString()}';";
                    //envoie de le requ�te
                    access.setData(requete);
                    //fermer la connexion
                    access.closeConnection();
                }

            }
            //si exception
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message, "Emprunte exception delete");
            }
        }

        /// <summary>
        /// Permet de mettre � jour la base de donn�e (celle-ci n'est pas utilis�e car il faut passer en param�tres les nouvelles donn�es)
        /// </summary>
        public void Update()
        {
            //not used
        }

        /// <summary>
        /// Permet de mettre � jour la base de donn�e
        /// </summary>
        /// <param name="updateIdVehicule">Long contenant le nouvel id du v�hicule de l'emprunt � modifier</param>
        /// <param name="updateIdEmploye">Long contenant le nouvel id de l'employ� de l'emprunt � modifier</param>
        /// <param name="updateDate">string contenant la nouvelle date de l'emprunt � modifier (format: AAAA/MM/JJ)</param>
        /// <param name="updateMission">string contenant la nouvelle mission de l'emprunt � modifier</param>
        /// <exception cref="System.Exception">D�clench�e si la connexion, la modification en base ou la d�connexion �chouent.</exception> 
        /// <returns>Un bool�en indiquant si des lignes ont �t� ajout�es/supprim�es/modifi�es.</returns>
        public void Update(long updateIdVehicule, long updateIdEmploye, string updateDate, string updateMission) 
        {
            DataAccess access = new DataAccess();
            try
            {
                if (access.openConnection())
                {
                    //la requ�te
                    string requete = $"UPDATE [IUT-ACY\\guyonr].Emprunte SET" +
                        $" IDVEHICULE={updateIdVehicule}," +
                        $" IDEMPLOYE={updateIdEmploye}," +
                        $" DATE='{updateDate}'," +
                        $" MISSION='{updateMission}'" +
                        $" WHERE IDEMPLOYE={this.IdEmploye}" +
                        $" AND DATE='{this.Date.ToShortDateString()}'" +
                        $" AND IDVEHICULE={this.IdVehicule};";
                    //envoi requete
                    access.setData(requete);
                    //fermer la connexion
                    access.closeConnection();
                }
            }
            //si exception
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message, "Emprunte exception update");
            }

        }
        /// <summary>
        /// Inutilis�e
        /// </summary>
		public void Read() {
            //not used
			throw new System.NotImplementedException("Not implemented");
		}

        /// <summary>
        /// Utilise l'objet courant (this) pour cr�er une ligne dans la table Emprunte de la base de donn�e.
        /// </summary>
		public void Create()
        {
            DataAccess access = new DataAccess();
            try
            {
                if (access.openConnection())
                {
                    //la requete
                    string requete = $"INSERT into [IUT-ACY\\guyonr].Emprunte (IDEMPLOYE,IDVEHICULE,DATE,MISSION) values (" +
                        $"{this.IdEmploye},"+
                        $"{this.IdVehicule}," +
                        $"'{this.Date.ToShortDateString()}'," +
                        $"'{this.Mission}');";
                    //envoi requete
                    access.setData(requete);
                    //fermer la connexion
                    access.closeConnection();
                }
            }
            //si exception
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message, "Emprunte exception create");
            }
        }


        

	}

}
