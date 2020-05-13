using GESTION_BIBLIOTHEQUE.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GESTION_BIBLIOTHEQUE.Services
{
    public interface INiveauEtude
    {
        bool AddNiveauEtude(niveau_etude ne);
        bool UpdateNiveauEtude(niveau_etude ne);
        bool DeleteNiveauEtude(niveau_etude ne);
        niveau_etude FindNiveauEtudeById(int id);
        niveau_etude FindNiveauEtudeByLib(string lib);
        List<niveau_etude> ListNiveauEtude(int id);
    }
}
