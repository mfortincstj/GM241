using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GM241.Classes
{
    public class TypeEmplacements
    {
        public virtual int idTypeEmplacement { get; set; }
        public virtual string nom { get; set; }
        public virtual bool estSupprime { get; set; }

        public TypeEmplacements()
        {
            idTypeEmplacement = 0;
            nom = "";
            estSupprime = false;
        }

        public TypeEmplacements(int idTypeEmp, string n, bool estSupp)
        {
            idTypeEmplacement = idTypeEmp;
            nom = n;
            estSupprime = estSupp;
        }

        public static List<TypeEmplacements> chargerlstTypeEmplacements()
        {
            int idTypeEmplacement;
            string nom;
            bool estSupprime;

            BDService BDTypeEmplacements = new BDService();
            String request = "SELECT * FROM TypeEmplacements";

            List<string>[] tabTypeEmplacements;
            int nombreRange = 0;
            tabTypeEmplacements = BDTypeEmplacements.selection(request, 3, ref nombreRange);

            List<TypeEmplacements> listeTypeEmplacements = new List<TypeEmplacements>();

            if (nombreRange >= 1)
            {
                for (int i = 0; i < nombreRange; i++)
                {
                    idTypeEmplacement = Convert.ToInt32(tabTypeEmplacements[i][0]);
                    nom = tabTypeEmplacements[i][1];
                    estSupprime = Convert.ToBoolean(tabTypeEmplacements[i][2]);

                    listeTypeEmplacements.Add(new TypeEmplacements(idTypeEmplacement, nom, estSupprime));
                }
            }

            return listeTypeEmplacements;
        }

        public bool ajoutTypeEmplacement(string nom)
        {
            BDService BDTypeEmplacement = new BDService();
            String request = "INSERT INTO TypeEmplacements (nom) VALUES" +
                             "( " + "'" + nom + "'" + ");";

            if (BDTypeEmplacement.Insertion(request) == true)
                return true;
            else
                return false;
        }

        public bool deleteTypeEmplacement(int id)
        {
            BDService BD = new BDService();
            String request = "UPDATE TypeEmplacements SET estSupprime = true WHERE idTypeEmplacement = " + id + ";";

            if (BD.delete(request) == true)
                return true;
            else
                return false;
        }
    }
}
