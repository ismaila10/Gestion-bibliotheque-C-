using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using GESTION_BIBLIOTHEQUE.Model;

namespace GESTION_BIBLIOTHEQUE.Services
{
    public class AdminsImpl : IAdmin
    {
        bibliothequeEntities db = new bibliothequeEntities();

        public bool AddAdmin(admins ad)
        {
            db.admins.Add(ad);
            if (db.SaveChanges() != 0)
                return true;
            else
                return false;
        }

        public bool DeleteAdmin(admins ad)
        {
            db.admins.Remove(ad);

            if (db.SaveChanges() != 0)
                return true;
            else
                return false;
        }
        

        public admins FindAdminByLoginPassword(string login, string password)
        {
            admins result=new admins();
            try
            {
                result = (from adm in db.admins
                                 where adm.login == login && adm.password == password
                                 select adm).FirstOrDefault();
            }
            catch {
                MessageBox.Show("Vous devez d'abord demarrer les services sql pour se connecter","ERREUR DE CONNEXION");
            }
            return result;
        }

        public admins FindAdminByLogin(string login)
        {
            admins result = null;
            result = (from adm in db.admins
                             where adm.login == login 
                             select adm).FirstOrDefault();
            return result;
        }

        public admins FindAdminById(int id)
        {
            admins result = (from adm in db.admins
                             where adm.id== id
                             select adm).FirstOrDefault();
            return result;
        }

        public List<admins> ListAdmin()
        {
            return db.admins.ToList();
        }

        public int ModifDelete(admins ad)
        {
            var query = db.admins.Where(p => p.id == ad.id).FirstOrDefault();
            query.delete = 1;
            int o = db.SaveChanges();
            return o;
        }

        public bool UpdateAdmin(admins ad)
        {
            if (db.SaveChanges() != 0)
                return true;
            else
                return false;
        }
    }
}
