using GESTION_BIBLIOTHEQUE.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GESTION_BIBLIOTHEQUE.Services
{
    public interface IPret
    {
        int AddPret(pret p);
        bool DeletePret(pret p);
        pret FindPretById(int id);
        List<pret> ListPret();
        bool UpdatePret(pret p);
    }
}
