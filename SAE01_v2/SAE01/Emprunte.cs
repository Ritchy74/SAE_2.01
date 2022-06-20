using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace SAE01
{
    public class Emprunte : CRUD<Emprunte>
    {
		public long IdEmploye { get; set; }
		//public long IdDate { get; set; }
		public long IdVehicule { get; set; }
		public string Mission { get; set; }
        public Vehicule Vehicule { get; set; }
        public Employe Employe { get; set; }
        public DateTime Date { get; set; }


        public Emprunte() { }
		public List<Emprunte> FindAll()
        {
            return FindBySelection("select * from [IUT-ACY\\guyonr].emprunte;");
        }
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
                            //unEmprunt.Date = leVehicule.FindByID(unEmprunt.IdVehicule);
                            //mission
                            unEmprunt.Mission = reader.GetString(3);
                            //
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
        public void Delete() 
        {
            DataAccess access = new DataAccess();
            try
            {
                if (access.openConnection())
                {
                    string requete = $"DELETE FROM [IUT-ACY\\guyonr].Emprunte WHERE " +
                        $"idEmploye={this.IdEmploye}" +
                        $" and idVehicule={this.IdVehicule}"+
                        $" and date='{this.Date.ToShortDateString()}';";
                    access.setData(requete);
                    access.closeConnection();
                }
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message, "Emprunte exception delete");
            }
            //load la bdd
            ApplicationData.loadApplicationData();
        }

        public void Update()
        {

        }
		public void Update(long updateIdVehicule, long updateIdEmploye, string updateDate, string updateMission) 
        {
            DataAccess access = new DataAccess();
            try
            {
                if (access.openConnection())
                {
                    //UPDATE Emprunte SET IDEMPLOYE = 3 WHERE IDEMPLOYE=4 and IDVEHICULE=1 and DATE='2022-06-10';
                    string requete = $"UPDATE [IUT-ACY\\guyonr].Emprunte SET" +
                        $" IDVEHICULE={updateIdVehicule}," +
                        $" IDEMPLOYE={updateIdEmploye}," +
                        $" DATE='{updateDate}'," +
                        $" MISSION='{updateMission}'" +
                        $" WHERE IDEMPLOYE={this.IdVehicule}," +
                        $" AND DATE='{this.Date.ToShortDateString()}'," +
                        $" AND IDVEHICULE={this.IdVehicule};";
                    access.setData(requete);
                    access.closeConnection();
                }
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message, "Emprunte exception update");
            }
            //load la bdd
            ApplicationData.loadApplicationData();

        }
		public void Read() {
			throw new System.NotImplementedException("Not implemented");
		}
		public void Create()
        {
            DataAccess access = new DataAccess();
            try
            {
                if (access.openConnection())
                {
                    string requete = $"INSERT into [IUT-ACY\\guyonr].Emprunte (IDEMPLOYE,IDVEHICULE,DATE,MISSION) values (" +
                        $"{this.IdEmploye},"+
                        $"{this.IdVehicule}," +
                        $"'{this.Date.ToShortDateString()}'," +
                        $"'{this.Mission}');";
                    access.setData(requete);
                    access.closeConnection();
                }
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message, "Emprunte exception create");
            }
            //load la bdd
            ApplicationData.loadApplicationData();
        }


        

	}

}
