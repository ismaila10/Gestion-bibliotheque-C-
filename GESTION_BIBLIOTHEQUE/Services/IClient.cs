
using GESTION_BIBLIOTHEQUE.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GESTION_BIBLIOTHEQUE.Services
{
    public interface IClient
    {
        bool AddClient(client cl);
        bool DeleteClient(client cl);
        List<client> ListClient();
        client FindClientById(int id);
        bool UpdateClient(client cl);
    }
}
