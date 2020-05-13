using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GESTION_BIBLIOTHEQUE.Services
{
    public class Organisation_historique
    {
 
        private string nom;
        private string prenom;
        private string  date_debut;
        private string date_fin;
        private string login;

        public string Nom
        {
            get
            {
                return nom;
            }

            set
            {
                nom = value;
            }
        }

        public string Prenom
        {
            get
            {
                return prenom;
            }

            set
            {
                prenom = value;
            }
        }

        public string Date_debut
        {
            get
            {
                return date_debut;
            }

            set
            {
                date_debut = value;
            }
        }

        public string Date_fin
        {
            get
            {
                return date_fin;
            }

            set
            {
                date_fin = value;
            }
        }

        public string Login
        {
            get
            {
                return login;
            }

            set
            {
                login = value;
            }
        }
    }
}
