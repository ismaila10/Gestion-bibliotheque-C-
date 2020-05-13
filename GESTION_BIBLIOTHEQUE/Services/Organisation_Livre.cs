using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GESTION_BIBLIOTHEQUE.Services
{
    class Organisation_Livre
    {
        private string idLivre;
        private string titre_Livre;
        private string auteur;
        
        //private string maison_Edition;
        private string categorie;
        private string niveau_Etude;
        private int nombre_Livres;

        public string Titre_Livre
        {
            get
            {
                return titre_Livre;
            }

            set
            {
                titre_Livre = value;
            }
        }

        public string Auteur
        {
            get
            {
                return auteur;
            }

            set
            {
                auteur = value;
            }
        }

    

        public string Categorie
        {
            get
            {
                return categorie;
            }

            set
            {
                categorie = value;
            }
        }

        public string Niveau_Etude
        {
            get
            {
                return niveau_Etude;
            }

            set
            {
                niveau_Etude = value;
            }
        }

        public int Nombre_Livres
        {
            get
            {
                return nombre_Livres;
            }

            set
            {
                nombre_Livres = value;
            }
        }

        public string IdLivre {
            get
            {
                return idLivre;
            }

            set
            {
                idLivre = value;
            }
        }
    }
}
