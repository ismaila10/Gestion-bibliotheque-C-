using GESTION_BIBLIOTHEQUE.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GESTION_BIBLIOTHEQUE.Services
{
    public class NiveauEtudeImpl : INiveauEtude
    {
        bibliothequeEntities db = new bibliothequeEntities();

        public bool AddNiveauEtude(niveau_etude ne)
        {
            db.niveau_etude.Add(ne);
            if (db.SaveChanges() != 0)
                return true;
            else
                return false;
        }

        public bool DeleteNiveauEtude(niveau_etude ne)
        {
            db.niveau_etude.Remove(ne);

            if (db.SaveChanges() != 0)
                return true;
            else
                return false;
        }

        public niveau_etude FindNiveauEtudeById(int id)
        {
            niveau_etude result = (from niv in db.niveau_etude
                                   where niv.id == id
                                 select niv).FirstOrDefault();
            return result;
        }

        public niveau_etude FindNiveauEtudeByLib(string lib)
        {
            niveau_etude result = (from niv in db.niveau_etude
                                   where niv.libelle_niveau_etude == lib
                                   select niv).FirstOrDefault();
            return result;
        }

        public List<niveau_etude> ListNiveauEtude(int id)
        {
            return db.niveau_etude.ToList();
        }

        public bool UpdateNiveauEtude(niveau_etude ne)
        {
            if (db.SaveChanges() != 0)
                return true;
            else
                return false;
        }
    }
}
