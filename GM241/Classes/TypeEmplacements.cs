using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GM241.Classes
{
    class TypeEmplacements
    {
        public virtual string nom{ get; set; }

        public TypeEmplacements()
        {
            nom = "";
        }

        public TypeEmplacements(string n)
        { 
            nom = n;
        }

        public static List<string> chargerNom()
        {
            string request;
            List<string>[] tabNom;
            int nombreRange = 0;

            List<Emplacements> listEmplacements = Emplacements.chargerlstEmplacements();
            List<string> lstNom= new List<string>();
            BDService BDTypeEmplacements = new BDService();

            foreach (Emplacements emp in listEmplacements)
            {
                request = "SELECT * FROM TypeEmplacements WHERE idTypeEmplacement = " + emp.idTypeEmplacement;
                tabNom = BDTypeEmplacements.selection(request, 2, ref nombreRange);
                lstNom.Add(tabNom[0][1]);
            }

            return lstNom;
        }
    }
}
