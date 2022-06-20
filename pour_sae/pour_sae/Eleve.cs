using System;
using System.Collections.Generic;
using System.Text;

namespace pour_sae
{
    public class Eleve : Crud<Eleve>
    {
        public long NEleve
        {
            get; set;
        }
        public string NomEleve
        {
            get; set;
        }
        public string PrenomEleve
        {
            get; set;
        }
        public Eleve()
        {
        }
        public void Create()
        {
            throw new NotImplementedException();
        }

        public void Delete()
        {
            throw new NotImplementedException();
        }

        public List<Eleve> FindAll()
        {
            throw new NotImplementedException();
        }

        public List<Eleve> FindBySelection(string criteres)
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
    }
}
