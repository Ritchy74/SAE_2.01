using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace SAE01
{
    public class Vehicule : CRUD<Vehicule>
    {
        public long IdVehicule { get; set; }
        public string LibelleVehicule { get; set; }
        

		public Vehicule() { }
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
        public List<Vehicule> FindAll()
        {
            return this.FindBySelection("select * from [IUT-ACY\\guyonr].vehicule;");
        }


        //faire une recherche avec l'id du véhicule
        public Vehicule FindByID(long idVehicule)
        {
            string requete = "select * from [IUT-ACY\\guyonr].vehicule WHERE idvehicule = " + idVehicule.ToString() + " ;";
            return this.FindBySelection(requete)[0];
        }
        public List<Vehicule> FindBySelection(string criteres)
        {
            List<Vehicule> listeGroupes = new List<Vehicule>();
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
                            Vehicule unVehicule = new Vehicule();
                            CategorieVehicule uneCat = new CategorieVehicule();
                            unVehicule.IdVehicule = reader.GetInt32(0);
                            unVehicule.CategorieVehicule = uneCat.FindByID(reader.GetInt32(1));
                            unVehicule.LibelleVehicule = reader.GetString(2);
                            listeGroupes.Add(unVehicule);
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
                System.Windows.MessageBox.Show(ex.Message, "Vehicule exception");
            }
            return listeGroupes;
        }

		public CategorieVehicule CategorieVehicule { get; set; }

		//public Emprunte[] Emprunts { get; set; }

	}

}
