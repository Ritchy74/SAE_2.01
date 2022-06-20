using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace SAE01
{
    public class Emprunte : CRUD<Emprunte>
    {
		public long IdEmploye { get; set; }
		public long IdDate { get; set; }
		public long IdVehicule { get; set; }
		public string Mission { get; set; }
		public DateTime Date { get; set; }


		public Emprunte() { }
		public List<Emprunte> FindAll()
        {
            List<Emprunte> listeGroupes = new List<Emprunte>();
            DataAccess access = new DataAccess();
            SqlDataReader reader;
            try
            {
                if (access.openConnection())
                {
                    reader = access.getData("select * from [IUT-ACY\\guyonr].emprunte;");
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Emprunte unEmprunt = new Emprunte();
                            unEmprunt.IdEmploye = reader.GetInt32(0);
                            unEmprunt.IdVehicule = reader.GetInt32(1);
                            unEmprunt.IdDate = reader.GetInt32(2);
                            unEmprunt.Mission = reader.GetString(3);
                            listeGroupes.Add(unEmprunt);
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
                System.Windows.MessageBox.Show(ex.Message, "Emprunte exception");
            }
            return listeGroupes;
        }
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

        public List<Emprunte> FindBySelection(string criteres)
        {
            throw new NotImplementedException();
        }

  //      private Vehicule vehicule;
		//public Vehicule Vehicule { get; set; }
		//private Employe[] employes;
		//public Employe[] Employes { get; set; }

	}

}
