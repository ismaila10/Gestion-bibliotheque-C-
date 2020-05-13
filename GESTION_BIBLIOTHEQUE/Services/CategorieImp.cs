using GESTION_BIBLIOTHEQUE.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GESTION_BIBLIOTHEQUE.Services
{
    class CategorieImp : ICategorie
    {
        bibliothequeEntities db=new bibliothequeEntities();
        public bool AddCategorie(categorie a)
        {
            db.categorie.Add(a);
            if (db.SaveChanges() != 0)
                return true;
            else
                return false;
        }

        public bool DeleteCategorie(categorie a)
        {
            db.categorie.Remove(a);

            if (db.SaveChanges() != 0)
                return true;
            else
                return false;
        }

        public categorie FindCategorieById(int id)
        {
            categorie result = (from cl in db.categorie
                                where cl.id == id
                            select cl).FirstOrDefault();
            return result;
        }

        public List<categorie> ListCategorie(int id)
        {
            return db.categorie.ToList();
        }

        public bool UpdateCategorie(categorie a)
        {
            db.categorie.Remove(a);
            if (db.SaveChanges() != 0)
                return true;
            else
                return false;
        }
    }
}
