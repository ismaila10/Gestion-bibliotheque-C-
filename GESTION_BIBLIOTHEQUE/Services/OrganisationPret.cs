using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GESTION_BIBLIOTHEQUE.Services
{
    public class OrganisationPret
    {
        private string numero;
        private string matricule;
        private string nom;
        private string prenom;
        private string niveau_etude;
        private string titre;
        private string auteur;
        private DateTime date_Debut;
        private DateTime date_Fin;
       

        public string Numero
        {
            get
            {
                return numero;
            }

            set
            {
                numero = value;
            }
        }
        public string Matricule
        {
            get
            {
                return matricule;
            }

            set
            {
                matricule = value;
            }
        }

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

        public string Niveau_etude
        {
            get
            {
                return niveau_etude;
            }

            set
            {
                niveau_etude = value;
            }
        }

        public string Titre
        {
            get
            {
                return titre;
            }

            set
            {
                titre = value;
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

        public DateTime Date_Debut
        {
            get
            {
                return date_Debut;
            }

            set
            {
                date_Debut = value;
            }
        }

        public DateTime Date_Fin
        {
            get
            {
                return date_Fin;
            }

            set
            {
                date_Fin = value;
            }
        }

     

        
    }
}
