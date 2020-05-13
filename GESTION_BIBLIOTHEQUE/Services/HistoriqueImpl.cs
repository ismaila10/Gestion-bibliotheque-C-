using GESTION_BIBLIOTHEQUE.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GESTION_BIBLIOTHEQUE.Services
{
    public class HistoriqueImpl : IHistorique
    {
        bibliothequeEntities db = new bibliothequeEntities();

        public bool AddHistorique(historique h)
        {
            db.historique.Add(h);
            if (db.SaveChanges() != 0)
                return true;
            else
                return false;
        }

        public bool DeleteHistorique(historique h)
        {
            db.historique.Remove(h);

            if (db.SaveChanges() != 0)
                return true;
            else
                return false;
        }

        public historique FindHistoriqueById(int id)
        {
            historique result = (from his in db.historique
                             where his.id == id
                             select his).FirstOrDefault();
            return result;
        }

        public historique FindLastHistorique()
        {
            historique result = (from his in db.historique
                                 where his.id==1
                                 select his).FirstOrDefault();
            return result;
        }
        public List<historique> ListHistorique()
        {
            return db.historique.ToList();
        }

        public bool UpdateHistorique(historique h)
        {
            if (db.SaveChanges() != 0)
                return true;
            else
                return false;
        }
    }
}
