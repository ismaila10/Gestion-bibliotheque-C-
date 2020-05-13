using GESTION_BIBLIOTHEQUE.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GESTION_BIBLIOTHEQUE.Services
{
    public class LivreImpl : ILivre
    {
        bibliothequeEntities db = new bibliothequeEntities();
        public bool AddLivre(livre liv)
        {
            db.livre.Add(liv);
            if (db.SaveChanges() != 0)
                return true;
            else
                return false;
        }

        public bool DeleteLivre(livre liv)
        {
            db.livre.Remove(liv);

            if (db.SaveChanges() != 0)
                return true;
            else
                return false;
        }

        public livre FindLivreById(int id)
        {
            livre result = (from liv in db.livre
                             where liv.id == id
                             select liv).FirstOrDefault();
            return result;
        }

        public livre FindLivreByTitreNiveau(string titre,int idniv)
        {
            livre result = (from liv in db.livre
                            where liv.libelle_livre == titre && liv.niveau_etude_id==idniv
                            select liv).FirstOrDefault();
            return result;
        }

        public List<livre> ListLivre(int id)
        {
            return db.livre.ToList();
        }

        public bool UpdateLivre(livre liv)
        {
            if (db.SaveChanges() != 0)
                return true;
            else
                return false;
        }

        public int ModifQte(livre l, int qte)
        {
            var query = db.livre.Where(p => p.id == l.id).FirstOrDefault();
            query.qte_stock = l.qte_stock + qte;
            int o = db.SaveChanges();
            return o;
        }

        public int StautDelete(livre l)
        {
            var query = db.livre.Where(q => q.id == l.id).FirstOrDefault();
            query.deletee = 1;
            int o = db.SaveChanges();
            return o;
        }

        public int AjoutPret(livre l, int qte)
        {
            var query = db.livre.Where(p => p.id == l.id).FirstOrDefault();
            query.qte_pret = l.qte_pret + qte;
            int o = db.SaveChanges();
            return o;
        }

        public int RendrePret(livre l, int qte)
        {
            var query = db.livre.Where(p => p.id == l.id).FirstOrDefault();
            query.qte_pret = l.qte_pret - qte;
            int o = db.SaveChanges();
            return o;
        }
    }
}
