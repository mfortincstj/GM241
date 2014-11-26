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

    /// <summary>
    /// Class Armoires
    /// </summary>
    class Armoires : Emplacements
    {
        public virtual string noArmoire { get; set; }

        public Armoires()
        {
            noArmoire = "";
        }

        public Armoires(string noArm)
        {
            noArmoire = noArm;
        }

        public static List<Armoires> chargerlstArmoires()
        {
            string noArmoire;

            BDService BDArmoire = new BDService();
            String request = "SELECT * FROM Armoires";

            List<string>[] tabArmoires;
            int nombreRange = 0;
            tabArmoires = BDArmoire.selection(request, 2, ref nombreRange);

            List<Armoires> listeArmoires = new List<Armoires>();

            if (nombreRange >= 1)
            {
                for (int i = 0; i < nombreRange; i++)
                {
                    noArmoire = tabArmoires[i][1];

                    listeArmoires.Add(new Armoires(noArmoire));
                }
            }

            return listeArmoires;
        }
    }

    /// <summary>
    /// Class Tiroirs
    /// </summary>
    class Tiroirs : Emplacements
    {
        public virtual string noTiroir { get; set; }

        public Tiroirs()
        {
            noTiroir = "";
        }

        public Tiroirs(string noTir)
        {
            noTiroir = noTir;
        }

        public static List<Tiroirs> chargerlstTiroirs()
        {
            string noTiroir;

            BDService BDTiroirs  = new BDService();
            String request = "SELECT * FROM Tiroirs";

            List<string>[] tabTiroirs;
            int nombreRange = 0;
            tabTiroirs = BDTiroirs.selection(request, 2, ref nombreRange);

            List<Tiroirs> listeTiroirs = new List<Tiroirs>();

            if (nombreRange >= 1)
            {
                for (int i = 0; i < nombreRange; i++)
                {
                    noTiroir = tabTiroirs[i][1];

                    listeTiroirs.Add(new Tiroirs(noTiroir));
                }
            }

            return listeTiroirs;
        }
    }

    /// <summary>
    /// Class Casiers
    /// </summary>
    class Casiers : Emplacements
    {
        public virtual string noCasier { get; set; }

        public Casiers()
        {
            noCasier = "";
        }

        public Casiers(string noCas)
        {
            noCasier = noCas;
        }

        public static List<Casiers> chargerlstCasiers()
        {
            string noCasier;

            BDService BDCasiers = new BDService();
            String request = "SELECT * FROM Casiers";

            List<string>[] tabCasiers;
            int nombreRange = 0;
            tabCasiers = BDCasiers.selection(request, 2, ref nombreRange);

            List<Casiers> listeCasiers = new List<Casiers>();

            if (nombreRange >= 1)
            {
                for (int i = 0; i < nombreRange; i++)
                {
                    noCasier = tabCasiers[i][1];

                    listeCasiers.Add(new Casiers(noCasier));
                }
            }

            return listeCasiers;
        }
    }
}
