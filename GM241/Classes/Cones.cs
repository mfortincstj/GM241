﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GM241.Classes
{
    class Cones
    {
        public virtual string nom { get; set; }
        public virtual string typeCone { get; set; }
        public virtual string typeMachine { get; set; }

        public Cones()
        {
            nom = "";
            typeCone = "";
            typeMachine = "";
        }

        public Cones(string n, string typeC, string typeM)
        {
            nom = n;
            typeCone = typeC;
            typeMachine = typeM;
        }

        public static List<Cones> chargerlstCones()
        {
            string nom;
            string typeCone;
            string typeMachine;

            BDService BDCones = new BDService();
            String request = "SELECT * FROM Cones";

            List<string>[] tabCones;
            int nombreRange = 0;
            tabCones = BDCones.selection(request, 4, ref nombreRange);

            List<Cones> listeCones = new List<Cones>();

            if (nombreRange >= 1)
            {
                for (int i = 0; i < nombreRange; i++)
                {
                    nom = tabCones[i][1];
                    typeCone = tabCones[i][2];
                    typeMachine = tabCones[i][3];

                    listeCones.Add(new Cones(nom, typeCone, typeMachine));
                }
            }

            return listeCones;
        }
    }
}