using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GESTION_BIBLIOTHEQUE.Model;

namespace GESTION_BIBLIOTHEQUE.Services
{
    public class AuteurImpl : IAuteur
    {
        bibliothequeEntities db = new bibliothequeEntities();
        public bool AddAuteur(auteur aut)
        {
            db.auteur.Add(aut);
            if (db.SaveChanges() != 0)
                return true;
            else
                return false;
        }

        public bool DeleteAuteur(auteur aut)
        {
            db.auteur.Remove(aut);

            if (db.SaveChanges() != 0)
                return true;
            else
                return false;
        }

        public auteur FindAuteurById(int id)
        {
            auteur result = (from aut in db.auteur
                            where aut.id == id
                            select aut).FirstOrDefault();
            return result;
        }

        public List<auteur> ListAuteur(int id)
        {
            return db.auteur.ToList();
        }

        public bool UpdateAuteur(auteur aut)
        {
            if (db.SaveChanges() != 0)
                return true;
            else
                return false;
        }
    }
}
