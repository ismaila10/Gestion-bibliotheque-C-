
using GESTION_BIBLIOTHEQUE.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GESTION_BIBLIOTHEQUE.Services
{
    public interface ILivre
    {
        bool AddLivre(livre liv);
        bool DeleteLivre(livre liv);
        livre FindLivreById(int id);
        List<livre> ListLivre(int id);
        bool UpdateLivre(livre liv);
        livre FindLivreByTitreNiveau(string titre, int idniv);
        int ModifQte(livre l, int qte);
        int AjoutPret(livre l, int qte);
        int RendrePret(livre l, int qte);
        int StautDelete(livre l);
    }
}
