
using GESTION_BIBLIOTHEQUE.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GESTION_BIBLIOTHEQUE.Services
{
    interface ICategorie
    {
        bool AddCategorie(categorie a);
        bool DeleteCategorie(categorie a);
        List<categorie> ListCategorie(int id);
        categorie FindCategorieById(int id);
        bool UpdateCategorie(categorie a);
    }
}
