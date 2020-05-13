using GESTION_BIBLIOTHEQUE.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GESTION_BIBLIOTHEQUE.Services
{
    public class PretImpl:IPret
    {
        bibliothequeEntities db = new bibliothequeEntities();

        public int AddPret(pret p)
        {
            db.pret.Add(p);
            if (db.SaveChanges() != 0)
                return 1;
            else
                return 0;
        }

        public bool DeletePret(pret p)
        {
            db.pret.Remove(p);

            if (db.SaveChanges() != 0)
                return true;
            else
                return false;
        }

        public pret FindPretById(int id)
        {
            pret result = (from p in db.pret
                            where p.id == id
                            select p).FirstOrDefault();
            return result;
        }

        public List<pret> ListPret()
        {
            return db.pret.ToList();
        }

        public bool UpdatePret(pret p)
        {
            if (db.SaveChanges() != 0)
                return true;
            else
                return false;
        }
    }
}
