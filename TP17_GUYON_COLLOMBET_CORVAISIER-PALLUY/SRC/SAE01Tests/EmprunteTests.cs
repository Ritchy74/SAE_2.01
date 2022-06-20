using Microsoft.VisualStudio.TestTools.UnitTesting;
using SAE01;
using System;
using System.Collections.Generic;
using System.Text;

namespace SAE01.Tests
{
    [TestClass()]
    public class EmprunteTests
    {
        private Emprunte emprunt1;
        private List<Emprunte> recupLesEmpruntsSelect;
        private List<Emprunte> recupLesEmpruntsFindAll;
        private Emprunte empruntRecupere;

        [TestInitialize()]
        public void MainTest()
        {
            emprunt1 = new Emprunte() { Date = new DateTime(2000, 01, 01), IdVehicule = 1, IdEmploye = 1, Mission="test create"};
            recupLesEmpruntsSelect = new List<Emprunte>();
            recupLesEmpruntsFindAll = new List<Emprunte>();
            empruntRecupere = new Emprunte();
        }

        [TestMethod()]
        public void EmprunteTest()
        {
            //inuntile de tester un constructeur qui créé un objet vide
        }

        [TestMethod()]
        public void CreateTest()
        {
            //on insère l'objet de référence dans la BDD
            emprunt1.Create();
            //on récupère l'emprunt avec un WHERE comportant les valeurs de l'objet référence
            recupLesEmpruntsSelect = emprunt1.FindBySelection("select * from [IUT-ACY\\guyonr].Emprunte where idvehicule=1 and idemploye=1 and date='2000-01-01';");

            //On test à la fois si l'objet a bien été créé et s'il a bien été récupéré par le findall()
            Assert.AreEqual(1, recupLesEmpruntsSelect.Count, "on vérifie qu'on a bien renvoyé 1 et 1 seul emprunt");
            //on stock l'emprunt qu'on a récupéré
            empruntRecupere = recupLesEmpruntsSelect[0];
            //on test pour les 4 champs
            Assert.AreEqual(empruntRecupere.IdEmploye, 1, "Test de récupération de l'id employé");
            Assert.AreEqual(empruntRecupere.IdVehicule, 1, "Test de récupération de l'id véhicule");
            Assert.AreEqual(empruntRecupere.Date, new DateTime(2000, 01, 01), "Test de récupération de la date");
            Assert.AreEqual(empruntRecupere.Mission, "test create", "Test de récupération de la mission");
        }

        [TestMethod()]
        public void FindBySelectionTest()
        {
            //on teste cette méthode dans le CreateTest()
            //comme on modifie constamment la BDD, on est obligé de tester findBySelection sur une ligne que l'on vient de créer
        }

        [TestMethod()]
        public void FindAllTest()
        {
            //on va test le findall avec le findbyselection (qu'on a testé juste au dessus)

            //on récupère une liste avec le findBySelection()
            recupLesEmpruntsSelect = emprunt1.FindBySelection("select * from [IUT-ACY\\guyonr].Emprunte;");
            //on récupère une liste avec le findAll()
            recupLesEmpruntsFindAll = emprunt1.FindAll();

            //on vérifie déjà la taille
            Assert.AreEqual(recupLesEmpruntsSelect.Count, recupLesEmpruntsFindAll.Count, "on vérifie qu'on a bien renvoyé le même nombre d'emprunts");

            //on compare un par un chaque valeurs
            for (int i=0; i<recupLesEmpruntsSelect.Count;i++)
            {
                Assert.AreEqual(recupLesEmpruntsSelect[i].IdEmploye, recupLesEmpruntsFindAll[i].IdEmploye, "Test de récupération de l'id employé");
                Assert.AreEqual(recupLesEmpruntsSelect[i].IdVehicule, recupLesEmpruntsFindAll[i].IdVehicule, "Test de récupération de l'id véhicule");
                Assert.AreEqual(recupLesEmpruntsSelect[i].Date, recupLesEmpruntsFindAll[i].Date, "Test de récupération de la date");
                Assert.AreEqual(recupLesEmpruntsSelect[i].Mission, recupLesEmpruntsFindAll[i].Mission, "Test de récupération de la mission");
            }
        }


        [TestMethod()]
        public void UpdateTest()
        {
            //objet de référence
            emprunt1.Update(2, 4, "2002/06/12", "test update");
            //on récupère l'emprunt avec un WHERE comportant les valeurs de l'objet référence
            recupLesEmpruntsSelect = emprunt1.FindBySelection("select * from [IUT-ACY\\guyonr].Emprunte where idvehicule=2 and idemploye=4 and date='2002-06-12';");
            //on stock l'emprunt qu'on a récupéré
            empruntRecupere = recupLesEmpruntsSelect[0];

            //on test pour les 4 champs
            Assert.AreEqual(empruntRecupere.IdVehicule, 2, "Test de l'update de l'id véhicule");
            Assert.AreEqual(empruntRecupere.IdEmploye, 4, "Test de l'update de l'id employé");
            Assert.AreEqual(empruntRecupere.Date, new DateTime(2002, 06, 12), "Test de l'update de la date");
            Assert.AreEqual(empruntRecupere.Mission, "test update", "Test de l'update de la mission");
        }

        [TestMethod()]
        public void DeleteTest()
        {
            //on va delete notre objet de référence
            emprunt1.Delete();

            //on recupère toutes les lignes
            recupLesEmpruntsFindAll = emprunt1.FindAll();

            //on teste si aucune n'est égale à l'objet de référence (que l'on a supprimé)
            foreach (Emprunte emprunt in recupLesEmpruntsFindAll)
            {
                if (emprunt1.IdEmploye == emprunt.IdEmploye && emprunt1.IdVehicule == emprunt.IdVehicule && emprunt1.Date == emprunt.Date)
                    Assert.Fail("Test si l'emprunt a bien été supprimé");
                    //si c'est le cas on fail
            }
        }

        [TestMethod()]
        public void ReadTest()
        {
            //méthode inutilisée (et a supprimer d'après Mme Gruson)
        }

        
    }
}