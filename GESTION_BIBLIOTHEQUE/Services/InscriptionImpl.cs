using GESTION_BIBLIOTHEQUE.Model;
using GESTION_BIBLIOTHEQUE.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GESTION_BIBLIOTHEQUE.Services
{
    public class InscriptionImpl : IInscription
    {
        bibliothequeEntities db = new bibliothequeEntities();
        public int AddInscription(inscription ins)
        {
            db.inscription.Add(ins);
            if (db.SaveChanges() != 0)
                return 1;
            else
                return 0;
        }

        public int DeleteInscription(inscription ins)
        {
            db.inscription.Remove(ins);

            if (db.SaveChanges() != 0)
                return 1;
            else
                return 0;
        }

        public inscription FindInscriptionById(int id)
        {
            inscription result = (from cl in db.inscription
                                  where cl.id == id
                                  select cl).FirstOrDefault();
            return result;
        }

        public inscription FindInscriptionByMat(string mat)
        {
            inscription result = (from cl in db.inscription
                                  where cl.matricule == mat
                                  select cl).FirstOrDefault();
            return result;
        }

        public List<inscription> ListInscription()
        {
            return db.inscription.ToList();
        }

        public int ModifDelete(inscription ins)
        {
            var query = db.inscription.Where(p => p.id == ins.id).FirstOrDefault();
            query.delet = 1;
            int o = db.SaveChanges();
            return o;
        }

        public int ModifStatut(inscription ins)
        {
            var query = db.inscription.Where(p => p.id == ins.id).FirstOrDefault();
            query.statut = 0;
            int o = db.SaveChanges();
            return o;
        }

        public int UpdateInscription(inscription ins)
        {
            if (db.SaveChanges() != 0)
                return 1;
            else
                return 0;
        }
    }
}
