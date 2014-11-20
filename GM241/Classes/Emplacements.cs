using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GM241.Classes
{
    class Emplacements
    {
        public virtual int idTypeEmplacement { get; set; }
        public virtual string noLocal { get; set; }
        public virtual string noArmoire { get; set; }
        public virtual string noTiroir { get; set; }
        public virtual string noCasier { get; set; }

        public Emplacements()
        {
            idTypeEmplacement = 0;
            noLocal = "";
            noArmoire = "";
            noTiroir = "";
            noCasier = "";
        }

        public Emplacements(int idTypeEmp, string noLoc, string noArm, string noTir, string noCas)
        {
            idTypeEmplacement = idTypeEmp;
            noLocal = noLoc;
            noArmoire = noArm;
            noTiroir = noTir;
            noCasier = noCas;
        }

        public static List<Emplacements> chargerlstEmplacements()
        {
            int idTypeEmplacement;
            string noLocal;
            string noArmoire;
            string noTiroir;
            string noCasier;

            BDService BDEmplacements = new BDService();
            String request = "SELECT * FROM Emplacements";

            List<string>[] tabEmplacements;
            int nombreRange = 0;
            tabEmplacements = BDEmplacements.selection(request, 6, ref nombreRange);

            List<Emplacements> listeEmplacements = new List<Emplacements>();

            if (nombreRange >= 1)
            {
                for (int i = 0; i < nombreRange; i++)
                {
                    idTypeEmplacement = Convert.ToInt32(tabEmplacements[i][1]);
                    noLocal = tabEmplacements[i][2];
                    noArmoire = tabEmplacements[i][3];
                    noTiroir = tabEmplacements[i][4];
                    noCasier = tabEmplacements[i][5];

                    listeEmplacements.Add(new Emplacements(idTypeEmplacement, noLocal, noArmoire, noTiroir, noCasier));
                }
            }

            return listeEmplacements;
        }

        public bool ajoutEmplacement(int idTypeEmplacement, string noLocal, string noArmoire, string noTiroir, string noCasier)
        {
            BDService BDCollets = new BDService();
            String request = "INSERT INTO Emplacements (idTypeEmplacement, noLocal, noArmoire, noTiroir, noCasier) VALUES" +
                             "( " + idTypeEmplacement +
                             ", " + "'" + noLocal + "'" +
                             ", " + "'" + noArmoire + "'" +
                             ", " + "'" + noTiroir + "'" +
                             ", " + "'" + noCasier + "'" + ");";

            if (BDCollets.Insertion(request) == true)
                return true;
            else
                return false;
        }
    }
}
