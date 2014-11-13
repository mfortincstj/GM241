﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GM241.Classes
{
    public class TypeAttachements
    {
        public virtual int idTypeAttachements { get; set; }
        public virtual string nom { get; set; }
        public virtual string diametreExterieur { get; set; }

        public TypeAttachements()
        {
            idTypeAttachements = 0;
            nom = "";
            diametreExterieur = "";
        }

        public TypeAttachements(int idTypeAtt, string n, string dE)
        {
            idTypeAttachements = idTypeAtt;
            nom = n;
            diametreExterieur = dE;
        }

        public static List<TypeAttachements> chargerlstTypeAttachements()
        {
            int idTypeAttachements;
            string nom;
            string diametreExterieur;

            BDService BDtypeAttachements = new BDService();
            String request = "SELECT * FROM TypeAttachements";

            List<string>[] tabTypeAttachements;
            int nombreRange = 0;
            tabTypeAttachements = BDtypeAttachements.selection(request, 3, ref nombreRange);

            List<TypeAttachements> listeTypeAttachements = new List<TypeAttachements>();

            if (nombreRange >= 1)
            {
                for (int i = 0; i < nombreRange; i++)
                {
                    idTypeAttachements = Convert.ToInt32(tabTypeAttachements[i][0]);
                    nom = tabTypeAttachements[i][1];
                    diametreExterieur = tabTypeAttachements[i][2];

                    listeTypeAttachements.Add(new TypeAttachements(idTypeAttachements, nom, diametreExterieur));
                }
            }

            return listeTypeAttachements;
        }
    }
}
