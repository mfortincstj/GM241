using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GM241.Classes
{
    class PlateauMachines
    {
        public virtual string nom { get; set; }
        public virtual bool axeSuppA { get; set; }
        public virtual bool axeSuppB { get; set; }

        public PlateauMachines()
        {
            nom = "";
            axeSuppA = false;
            axeSuppB = false;
        }

        public PlateauMachines(string n, bool axeSuA, bool axeSuB)
        {
            nom = n;
            axeSuppA = axeSuA;
            axeSuppB = axeSuB;
        }

        public static List<PlateauMachines> chargerlstPlateauMachines()
        {
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
                    nom = tabPlateauMachines[i][1];
                    axeSuppA = Convert.ToBoolean(tabPlateauMachines[i][2]);
                    axeSuppB = Convert.ToBoolean(tabPlateauMachines[i][3]);

                    listePlateauMachines.Add(new PlateauMachines(nom, axeSuppA, axeSuppB));
                }
            }

            return listePlateauMachines;
        }
    }
}
