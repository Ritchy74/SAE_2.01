using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace SAE01
{
	public class Employe : CRUD<Employe>  {
		public long IdEmploye { get; set; }
		public string Nom { get; set; }
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

        public List<Employe> FindAll()
        {
            return this.FindBySelection("select * from [IUT-ACY\\guyonr].employe;");
        }


        //faire une recherche avec l'id de l'employé
        public Employe FindByID(long idEmploye)
        {
            string requete = "select * from [IUT-ACY\\guyonr].employe WHERE idemploye = " + idEmploye.ToString() + " ;";
            return this.FindBySelection(requete)[0];
        }

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
                            unEmploye.Mail = reader.GetString(3);
                            unEmploye.TelEmploye = reader.GetString(4);
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
