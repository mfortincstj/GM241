﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GM241.Classes
{
    class Machines
    {
        public virtual int idPlateauMachine { get; set; }
        public virtual string nom { get; set; }
        public virtual int nombreOutilMagasin { get; set; }
        public virtual string precisionMachine { get; set; }
        public virtual string formatCone { get; set; }
        public virtual int nombreOutilPrep { get; set; }
        public virtual int numeroMachine { get; set; }
        public virtual string axeXMin { get; set; }
        public virtual string axeXMAX { get; set; }
        public virtual string axeYMin { get; set; }
        public virtual string axeYMAX { get; set; }
        public virtual bool axeZ { get; set; }
        public virtual string axeZMin { get; set; }
        public virtual string axeZMAX { get; set; }

        public Machines()
        {
            idPlateauMachine = 0;
            nom = "";
            nombreOutilMagasin = 0;
            precisionMachine = "";
            formatCone = "";
            nombreOutilPrep = 0;
            numeroMachine = 0;
            axeXMin = "";
            axeXMAX = "";
            axeYMin = "";
            axeYMAX = "";
            axeZ = false;
            axeZMin = "";
            axeZMAX = "";
        }

        public Machines(int idPlatMach, string n, int nbOutilMag, string precMach, string formatCo, int nbOutilPr, int noMach,
                        string axeXMi, string axeXMa, string axeYMi, string axeYMa, bool axZ, string axeZMi, string axeZMa)
        {
            idPlateauMachine = idPlatMach;
            nom = n;
            nombreOutilMagasin = nbOutilMag;
            precisionMachine = precMach;
            formatCone = formatCo;
            nombreOutilPrep = nbOutilPr;
            numeroMachine = noMach;
            axeXMin = axeXMi;
            axeXMAX = axeXMa;
            axeYMin = axeYMi;
            axeYMAX = axeYMa;
            axeZ = axZ;
            axeZMin = axeZMi;
            axeZMAX = axeZMa;
        }

        public static List<Machines> chargerMachines()
        {
            int idPlateauMachine;
            string nom;
            int nombreOutilMagasin;
            string precisionMachine;
            string formatCone;
            int nombreOutilPrep;
            int numeroMachine;
            string axeXMin;
            string axeXMAX;
            string axeYMin;
            string axeYMAX;
            bool axeZ;
            string axeZMin;
            string axeZMAX;

            BDService BDMachines = new BDService();
            String request = "SELECT * FROM Machines";

            List<string>[] tabMachines;
            int nombreRange = 0;
            tabMachines = BDMachines.selection(request, 15, ref nombreRange);

            List<Machines> listeMachines = new List<Machines>();

            if (nombreRange >= 1)
            {
                for (int i = 0; i < nombreRange; i++)
                {
                    idPlateauMachine = Convert.ToInt32(tabMachines[i][1]);
                    nom = tabMachines[i][2];
                    nombreOutilMagasin = Convert.ToInt32(tabMachines[i][3]);
                    precisionMachine = tabMachines[i][4];
                    formatCone = tabMachines[i][5];
                    nombreOutilPrep = Convert.ToInt32(tabMachines[i][6]);
                    numeroMachine = Convert.ToInt32(tabMachines[i][7]);
                    axeXMin = tabMachines[i][8];
                    axeXMAX = tabMachines[i][9];
                    axeYMin = tabMachines[i][10];
                    axeYMAX = tabMachines[i][11];
                    axeZ = Convert.ToBoolean(tabMachines[i][12]);
                    axeZMin = tabMachines[i][13];
                    axeZMAX = tabMachines[i][14];

                    listeMachines.Add(new Machines(idPlateauMachine, nom, nombreOutilMagasin, precisionMachine, formatCone, nombreOutilPrep, 
                                                numeroMachine, axeXMin, axeXMAX, axeYMin, axeYMAX, axeZ, axeZMin, axeZMAX));
                }
            }

            return listeMachines;
        }
    }
}