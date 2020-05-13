using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GESTION_BIBLIOTHEQUE.Services
{
    public class Organisation
    {
        private string matricule;
        private string nom;
        private string prenom;
        private string tel;
        private DateTime date_Inscription;
        private DateTime date_Echeance;
        private string montant;
        private string statut;



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

        public string Tel
        {
            get
            {
                return tel;
            }

            set
            {
                tel = value;
            }
        }

        public DateTime Date_Inscription
        {
            get
            {
                return date_Inscription;
            }

            set
            {
                date_Inscription = value;
            }
        }

        public DateTime Date_Echeance
        {
            get
            {
                return date_Echeance;
            }

            set
            {
                date_Echeance = value;
            }
        }

        public string Montant
        {
            get
            {
                return montant;
            }

            set
            {
                montant = value;
            }
        }

        public string Statut
        {
            get
            {
                return statut;
            }

            set
            {
                statut = value;
            }
        }
    }
}
