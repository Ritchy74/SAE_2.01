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
    /// Permet de créer des objet Emprunte et de les ajouter, modifier ou supprimer de la base de donnée.
    /// Implémente le CRUD
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
        /// Getter et setter de Vehicule (on a pas seulement besoin de l'id, on a parfois besoin de l'objet pour des méthodes)
        /// </summary>
        public Vehicule Vehicule { get; set; }

        /// <summary>
        /// Getter et setter de Employe (on a pas seulement besoin de l'id, on a parfois besoin de l'objet pour des méthodes)
        /// </summary>
        public Employe Employe { get; set; }

        /// <summary>
        /// Getter et setter de la Date
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Permet de créer un objet Emprunt vide
        /// </summary>
        public Emprunte() { }


        /// <summary>
        /// Va chercher les données dans la table emprunte et les met dans une liste d'objet emprunts
        /// </summary>
        /// <returns>Une liste contenant tous les emprunts de la base de donnée</returns>
		public List<Emprunte> FindAll()
        {
            return FindBySelection("select * from [IUT-ACY\\guyonr].emprunte;");
        }

        /// <summary>
        /// Va chercher les données dans la table emprunte (en faisant une requête spécifique, comme un WHERE par exemple) et les met dans une liste d'objet Emprunt
        /// </summary>
        /// <param name="criteres">Requête SQL permettant d'insérer, supprimer ou modifier des données.</param>
        /// <exception cref="System.Exception">Déclenchée si la connexion, la lecture en base ou la déconnexion échouent.</exception> 
        /// <returns>Une liste contenant les emprunts selectionnés par la requête</returns>
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
                            //on rajoute à la liste l'emprunt que l'on vient de créer
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
        /// Utilise l'objet courant (this) pour supprimer une ligne dans la table Emprunte de la base de donnée.
        /// </summary>
        /// <exception cref="System.Exception">Déclenchée si la connexion, la modification en base ou la déconnexion échouent.</exception> 
        public void Delete() 
        {
            DataAccess access = new DataAccess();
            try
            {
                if (access.openConnection())
                {
                    //la requête
                    string requete = $"DELETE FROM [IUT-ACY\\guyonr].Emprunte WHERE " +
                        $"idEmploye={this.IdEmploye}" +
                        $" and idVehicule={this.IdVehicule}"+
                        $" and date='{this.Date.ToShortDateString()}';";
                    //envoie de le requête
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
        /// Permet de mettre à jour la base de donnée (celle-ci n'est pas utilisée car il faut passer en paramètres les nouvelles données)
        /// </summary>
        public void Update()
        {
            //not used
        }

        /// <summary>
        /// Permet de mettre à jour la base de donnée
        /// </summary>
        /// <param name="updateIdVehicule">Long contenant le nouvel id du véhicule de l'emprunt à modifier</param>
        /// <param name="updateIdEmploye">Long contenant le nouvel id de l'employé de l'emprunt à modifier</param>
        /// <param name="updateDate">string contenant la nouvelle date de l'emprunt à modifier (format: AAAA/MM/JJ)</param>
        /// <param name="updateMission">string contenant la nouvelle mission de l'emprunt à modifier</param>
        /// <exception cref="System.Exception">Déclenchée si la connexion, la modification en base ou la déconnexion échouent.</exception> 
        /// <returns>Un booléen indiquant si des lignes ont été ajoutées/supprimées/modifiées.</returns>
        public void Update(long updateIdVehicule, long updateIdEmploye, string updateDate, string updateMission) 
        {
            DataAccess access = new DataAccess();
            try
            {
                if (access.openConnection())
                {
                    //la requête
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
        /// Inutilisée
        /// </summary>
		public void Read() {
            //not used
			throw new System.NotImplementedException("Not implemented");
		}

        /// <summary>
        /// Utilise l'objet courant (this) pour créer une ligne dans la table Emprunte de la base de donnée.
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
