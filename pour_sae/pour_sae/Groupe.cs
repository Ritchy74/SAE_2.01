using pour_sae;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
namespace pour_sae
{
    public class Groupe : Crud<Groupe>
    {



        public long NGroupe
        {
            get; set;
        }
        public string LibelleGroupe
        {
            get; set;
        }
        public List<Eleve> Eleves
        {
            get; set;
        }
        public Groupe()
        {
        }
        public void Create()
        {
            throw new NotImplementedException();
        }
        public void Read()
        {
            throw new NotImplementedException();
        }
        public void Update()
        {
            throw new NotImplementedException();
        }
        public void Delete()
        {
            throw new NotImplementedException();
        }
        public List<Groupe> FindAll()
        {
            List<Groupe> listeGroupes = new List<Groupe>();
            DataAccess access = new DataAccess();   
            SqlDataReader reader;
            try
            {
                if (access.openConnection())
                {
                    reader = access.getData("select * from [IUT-ACY\\guyonr].Groupe;");
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Groupe unGroupe = new Groupe();
                            unGroupe.NGroupe = reader.GetInt64(0);
                            unGroupe.LibelleGroupe = reader.GetString(1);
                            listeGroupes.Add(unGroupe);
                        }
                    }
                    else
                    {
                        System.Windows.MessageBox.Show("No rows found.", "Important Message");
                    }
                    reader.Close();
                    access.closeConnection();
                }
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message, "Important Message");
            }
            return listeGroupes;
        }
        public List<Groupe> FindBySelection(string criteres)
        {
            throw new NotImplementedException();
        }
    }
}
