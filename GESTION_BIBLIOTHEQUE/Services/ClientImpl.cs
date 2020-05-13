using GESTION_BIBLIOTHEQUE.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GESTION_BIBLIOTHEQUE.Services
{
    public class ClientImpl : IClient
    {
        bibliothequeEntities db = new bibliothequeEntities();
        public bool AddClient(client cl)
        {
            db.client.Add(cl);
            if (db.SaveChanges() != 0)
                return true;
            else
                return false;
        }

        public bool DeleteClient(client cl)
        {
            db.client.Remove(cl);

            if (db.SaveChanges() != 0)
                return true;
            else
                return false;
        }

        public client FindClientById(int id)
        {
            client result = (from cl in db.client
                             where cl.id == id
                             select cl).FirstOrDefault();
            return result;
        }

        public List<client> ListClient()
        {
            return db.client.ToList();
        }

        public bool UpdateClient(client cl)
        {
            db.client.Remove(cl);
            if (db.SaveChanges() != 0)
                return true;
            else
                return false;
        }
    }
}
