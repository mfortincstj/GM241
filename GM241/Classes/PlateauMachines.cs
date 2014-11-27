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

        public PlateauMachines()
        {
            idPlateauMachine = 0;
            nom = "";
            axeSuppA = false;
            axeSuppB = false;
        }

        public PlateauMachines(int idPlateauM, string n, bool axeSuA, bool axeSuB)
        {
            idPlateauMachine = idPlateauM;
            nom = n;
            axeSuppA = axeSuA;
            axeSuppB = axeSuB;
        }

        public static List<PlateauMachines> chargerlstPlateauMachines()
        {
            int idPlateauMachine;
            string nom;
            bool axeSuppA;
            bool axeSuppB;

            BDService BDPlateauMachines = new BDService();
            String request = "SELECT * FROM PlateauMachines";

            List<string>[] tabPlateauMachines;
            int nombreRange = 0;
            tabPlateauMachines = BDPlateauMachines.selection(request, 4, ref nombreRange);

            List<PlateauMachines> listePlateauMachines = new List<PlateauMachines>();

            if (nombreRange >= 1)
            {
                for (int i = 0; i < nombreRange; i++)
                {
                    idPlateauMachine = Convert.ToInt32(tabPlateauMachines[i][0]);
                    nom = tabPlateauMachines[i][1];
                    axeSuppA = Convert.ToBoolean(tabPlateauMachines[i][2]);
                    axeSuppB = Convert.ToBoolean(tabPlateauMachines[i][3]);

                    listePlateauMachines.Add(new PlateauMachines(idPlateauMachine, nom, axeSuppA, axeSuppB));
                }
            }

            return listePlateauMachines;
        }

        public bool ajoutPlateauMachine(string nom, bool axeSuppA, bool axeSuppB)
        {
            BDService BDPlateauMachines = new BDService();
            String request = "INSERT INTO PlateauMachines (nom, axeSuppA, axeSuppB) VALUES" +
                             "( " + "'" + nom + "'" + 
                             ", " + axeSuppA +
                             ", " + axeSuppB + ");";

            if (BDPlateauMachines.Insertion(request) == true)
                return true;
            else
                return false;
        }
    }
}
