using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GM241.Classes
{
    public class Emplacements
    {
        public virtual int Emplacement { get; set; }
        public virtual string idTypeEmplacement { get; set; }
        public virtual string noLocal { get; set; }
        public virtual string idArmoire { get; set; }
        public virtual string idTiroir { get; set; }
        public virtual string idCasier { get; set; }

        public Emplacements()
        {
            Emplacement = 0;
            idTypeEmplacement = "";
            noLocal = "";
            idArmoire = "";
            idTiroir = "";
            idCasier = "";
        }

        public Emplacements(int idEmp, string idTypeEmp, string noLoc, string noArm, string noTir, string noCas)
        {
            Emplacement = idEmp;
            idTypeEmplacement = idTypeEmp;
            noLocal = noLoc;
            idArmoire = noArm;
            idTiroir = noTir;
            idCasier = noCas;
        }

        public static List<Emplacements> chargerlstEmplacements()
        {
            int idEmplacement;
            string idTypeEmplacement;
            string noLocal;
            string idArmoire;
            string idTiroir;
            string idCasier;

            BDService BDEmplacements = new BDService();
            String request = "SELECT * FROM Emplacements AS e INNER JOIN TypeEmplacements AS te ON te.idTypeEmplacement = e.idTypeEmplacement";

            List<string>[] tabEmplacements;
            int nombreRange = 0;
            tabEmplacements = BDEmplacements.selection(request, 9, ref nombreRange);

            List<Emplacements> listeEmplacements = new List<Emplacements>();

            if (nombreRange >= 1)
            {
                for (int i = 0; i < nombreRange; i++)
                {
                    if (Convert.ToBoolean(tabEmplacements[i][6]) == false)
                    {
                        idEmplacement = Convert.ToInt32(tabEmplacements[i][0]);
                        idTypeEmplacement = tabEmplacements[i][8];
                        noLocal = tabEmplacements[i][2];
                        idArmoire = tabEmplacements[i][3];
                        idTiroir = tabEmplacements[i][4];
                        idCasier = tabEmplacements[i][5];

                        listeEmplacements.Add(new Emplacements(idEmplacement, idTypeEmplacement, noLocal, idArmoire, idTiroir, idCasier));
                    }
                }
            }

            return listeEmplacements;
        }

        public bool ajoutEmplacement(int idTypeEmplacement, string noLocal, string noArmoire, string noTiroir, string noCasier)
        {
            BDService BDCollets = new BDService();
            String request = "INSERT INTO Emplacements (idTypeEmplacement, noLocal, noArmoire, noTiroir, noCasier) VALUES" +
                             "( " + idTypeEmplacement +
                             ", " + "'" + noLocal.ToLower() + "'" +
                             ", " + "'" + noArmoire.ToLower() + "'" +
                             ", " + "'" + noTiroir.ToLower() + "'" +
                             ", " + "'" + noCasier.ToLower() + "'" + ");";

            if (BDCollets.Insertion(request) == true)
                return true;
            else
                return false;
        }

        public bool deleteEmplacement(int id)
        {
            BDService BD = new BDService();
            String request = "UPDATE Emplacements SET estSupprime = true WHERE idEmplacement = " + id + ";";

            if (BD.delete(request) == true)
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
