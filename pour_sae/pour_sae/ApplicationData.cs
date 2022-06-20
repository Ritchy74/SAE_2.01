using System;
using System.Collections.Generic;
using System.Text;

namespace pour_sae
{
    public class ApplicationData
    {
        public ApplicationData()
        {
            loadApplicationData();
        }
        public List<Groupe> ListeGroupes
        {
            get;
            set;
        }
        public void loadApplicationData()
        {
            Groupe unGroupe = new Groupe();
            ListeGroupes = unGroupe.FindAll();
        }
        public static List<Eleve> listeEleves
        {
            get;
            set;
        }
        //public static List<Professeur> listeProfesseurs
        //{
        //    get;
        //    set;
        //}
        public static List<Groupe> listeGroupes
        {
            get;
            set;
        }
        //public static List<EstNote> listeEstNotes
        //{
        //    get;
        //    set;
        //}
        //public static void loadApplicationData()
        //{
        //    //chargement des tables
        //    //Eleve unEleve = new Eleve();
        //    //Professeur unProfesseur = new Professeur();
        //    Groupe unGroupe = new Groupe();
        //    //EstNote unEstNote = new EstNote();
        //    //listeEleves = unEleve.FindAll();
        //    //listeProfesseurs = unProfesseur.FindAll();
        //    listeGroupes = unGroupe.FindAll();
        //    //listeEstNotes = unEstNote.FindAll();
        //    //mapping des relations en mode déconnecté
        //    //relation bi-directionnelle entre eleve et groupe
        //}
        //relation eleve -> note
        //relation note -> professeur
    }
}