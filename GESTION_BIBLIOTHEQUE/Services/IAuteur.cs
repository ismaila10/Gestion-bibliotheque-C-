using GESTION_BIBLIOTHEQUE.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GESTION_BIBLIOTHEQUE.Services
{
    public interface IAuteur
    {
        bool AddAuteur(auteur aut);
        bool DeleteAuteur(auteur aut);
        auteur FindAuteurById(int id);
        List<auteur> ListAuteur(int id);
        bool UpdateAuteur(auteur aut);
    }
}
