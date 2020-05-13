using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GESTION_BIBLIOTHEQUE.Services
{
    public class Fonction
    {
        public string GetNextCode(string sLastCode)
        {
            // Fait attention aux bornes inf et sup
            if (String.IsNullOrEmpty(sLastCode) || sLastCode == "Z9999")
            {
                return "A0001";
            }
            // Suivant
            string sNextCode = string.Empty;
            if (Convert.ToInt32(sLastCode.Substring(1, 4)) == 9999)
            {
                sNextCode = (((char)((int)sLastCode[0]) == 'Z') ? 'A' : (char)((int)sLastCode[0]
                + 1)) + "0001";
            }
            else
            {
                sNextCode = (char)((int)sLastCode[0]) + (Convert.ToInt32(sLastCode.Substring(1, 4))
                    + 1).ToString("0000");
            }

            return sNextCode;
        }

    }
}
