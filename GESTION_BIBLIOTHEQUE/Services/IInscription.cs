
using GESTION_BIBLIOTHEQUE.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GESTION_BIBLIOTHEQUE.Services
{
    public interface IInscription
    {
        int AddInscription(inscription ins);
        int DeleteInscription(inscription ins);
        List<inscription> ListInscription();
        inscription FindInscriptionById(int id);
        int UpdateInscription(inscription ins);
        int ModifStatut(inscription ins);
        int ModifDelete(inscription ins);
        inscription FindInscriptionByMat(string mat);

    }
}
