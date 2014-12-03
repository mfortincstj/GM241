using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GM241.Classes
{
    public class PlateauMachines
    {
        public virtual int idPlateauMachine { get; set; }
        public virtual string nom { get; set; }
        public virtual bool axeSuppA { get; set; }
        public virtual bool axeSuppB { get; set; }
        public virtual bool estSupprime { get; set; }

        public PlateauMachines()
        {
            idPlateauMachine = 0;
            nom = "";
            axeSuppA = false;
            axeSuppB = false;
            estSupprime = false;
        }

        public PlateauMachines(int idPlateauM, string n, bool axeSuA, bool axeSuB, bool estSupp)
        {
            idPlateauMachine = idPlateauM;
            nom = n;
            axeSuppA = axeSuA;
            axeSuppB = axeSuB;
            estSupprime = estSupp;
        }

        public static List<PlateauMachines> chargerlstPlateauMachines()
        {
            int idPlateauMachine;
            string nom;
            bool axeSuppA;
            bool axeSuppB;
            bool estSupprime;

            BDService BDPlateauMachines = new BDService();
            String request = "SELECT * FROM PlateauMachines";

            List<string>[] tabPlateauMachines;
            int nombreRange = 0;
            tabPlateauMachines = BDPlateauMachines.selection(request, 5, ref nombreRange);

            List<PlateauMachines> listePlateauMachines = new List<PlateauMachines>();

            if (nombreRange >= 1)
            {
                for (int i = 0; i < nombreRange; i++)
                {
                    idPlateauMachine = Convert.ToInt32(tabPlateauMachines[i][0]);
                    nom = tabPlateauMachines[i][1];
                    axeSuppA = Convert.ToBoolean(tabPlateauMachines[i][2]);
                    axeSuppB = Convert.ToBoolean(tabPlateauMachines[i][3]);
                    estSupprime = Convert.ToBoolean(tabPlateauMachines[i][4]);

                    listePlateauMachines.Add(new PlateauMachines(idPlateauMachine, nom, axeSuppA, axeSuppB, estSupprime));
                }
            }

            return listePlateauMachines;
        }

        public bool ajoutPlateauMachine(string nom, bool axeSuppA, bool axeSuppB)
        {
            BDService BDPlateauMachines = new BDService();
            String request = "INSERT INTO PlateauMachines (nom, axeSuppA, axeSuppB) VALUES" +
                             "( " + "'" + nom.ToLower() + "'" + 
                             ", " + axeSuppA +
                             ", " + axeSuppB + ");";

            if (BDPlateauMachines.Insertion(request) == true)
                return true;
            else
                return false;
        }

        public bool deletePlateauMachine(int id)
        {
            BDService BD = new BDService();
            String request = "UPDATE PlateauMachines SET estSupprime = true WHERE idPlateauMachine = " + id + ";";

            if (BD.delete(request) == true)
                return true;
            else
                return false;
        }
    }
}
