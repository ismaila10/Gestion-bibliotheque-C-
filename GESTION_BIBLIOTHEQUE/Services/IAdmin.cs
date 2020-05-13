using GESTION_BIBLIOTHEQUE.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GESTION_BIBLIOTHEQUE.Services
{
    public interface IAdmin
    {
        bool AddAdmin(admins ad);
        bool UpdateAdmin(admins ad);
        bool DeleteAdmin(admins ad);
        admins FindAdminByLoginPassword(string login,string password);
        List<admins> ListAdmin();
        int ModifDelete(admins ad);
        admins FindAdminByLogin(string login);

       admins FindAdminById(int id);
    }
}
