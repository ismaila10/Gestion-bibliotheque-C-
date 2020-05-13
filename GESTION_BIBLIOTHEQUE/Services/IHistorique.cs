
using GESTION_BIBLIOTHEQUE.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GESTION_BIBLIOTHEQUE.Services
{
    public interface IHistorique
    {
        bool AddHistorique(historique h);
        bool UpdateHistorique(historique h);
        bool DeleteHistorique(historique h);
        historique FindHistoriqueById(int id);
        historique FindLastHistorique();
        List<historique> ListHistorique();
    }
}
