using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GM241.Classes
{
    class Extensions
    {
        public virtual int idPorteOutil { get; set; }
        public virtual int idEmplacement { get; set; }
        public virtual int idCollet { get; set; }
        public virtual string longueurShank { get; set; }
        public virtual string diametreShank { get; set; }
        public virtual string longueurTotale { get; set; }
        public virtual int quantite { get; set; }
        public virtual string image { get; set; }

        public Extensions()
        {
            idPorteOutil = 0;
            idEmplacement = 0;
            idCollet = 0;
            longueurShank = "";
            diametreShank = "";
            longueurTotale = "";
            quantite = 0;
            image = "";
        }

        public Extensions(int idPO, int idEmp, int idCol, string longShank, string diamShank, string longTotal, int quant, string img)
        {
            idPorteOutil = idPO;
            idEmplacement = idEmp;
            idCollet = idCol;
            longueurShank = longShank;
            diametreShank = diamShank;
            longueurTotale = longTotal;
            quantite = quant;
            image = img;
        }

        public static List<Extensions> chargerlstExtensions()
        {
            int idPorteOutil;
            int idEmplacement;
            int idCollet;
            string longueurShank;
            string diametreShank;
            string longueurTotale;
            int quantite;
            string image;

            BDService BDExtensions = new BDService();
            String request = "SELECT * FROM Extensions";

            List<string>[] tabExtensions;
            int nombreRange = 0;
            tabExtensions = BDExtensions.selection(request, 9, ref nombreRange);

            List<Extensions> listeExtensions = new List<Extensions>();

            if (nombreRange >= 1)
            {
                for (int i = 0; i < nombreRange; i++)
                {
                    idPorteOutil = Convert.ToInt32(tabExtensions[i][1]);
                    idEmplacement = Convert.ToInt32(tabExtensions[i][2]);
                    idCollet = Convert.ToInt32(tabExtensions[i][3]);
                    longueurShank = tabExtensions[i][4];
                    diametreShank = tabExtensions[i][5];
                    longueurTotale = tabExtensions[i][6];
                    quantite = Convert.ToInt32(tabExtensions[i][7]);
                    image = tabExtensions[i][8];

                    listeExtensions.Add(new Extensions(idPorteOutil, idEmplacement, idCollet, longueurShank, diametreShank, longueurTotale, quantite, image));
                }
            }

            return listeExtensions;
        }
    }
}
