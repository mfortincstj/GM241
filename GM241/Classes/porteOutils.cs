using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GM241.Classes
{
    class PorteOutils
    {
        public virtual int idTypePorteOutil { get; set; }
        public virtual int idEmplacement { get; set; }
        public virtual int quantite { get; set; }
        public virtual string image { get; set; }

        public PorteOutils()
        {
            idTypePorteOutil = 0;
            idEmplacement = 0;
            quantite = 0;
            image = "";
        }

        public PorteOutils(int idTypePO, int idEm, int quant, string img)
        {
            idTypePorteOutil = idTypePO;
            idEmplacement = idEm;
            quantite = quant;
            image = img;
        }

        public static List<PorteOutils> chargerlstPorteOutils()
        {
            int idTypePorteOutil;
            int idEmplacement;
            int quantite;
            string image;

            BDService BDporteOutils = new BDService();
            String request = "SELECT * FROM PorteOutils";

            List<string>[] tabPorteOutils;
            int nombreRange = 0;
            tabPorteOutils = BDporteOutils.selection(request, 5, ref nombreRange);

            List<PorteOutils> listePorteOutils = new List<PorteOutils>();

            if (nombreRange >= 1)
            {
                for (int i = 0; i < nombreRange; i++)
                {
                    idTypePorteOutil = Convert.ToInt32(tabPorteOutils[i][1]);
                    idEmplacement = Convert.ToInt32(tabPorteOutils[i][2]);
                    quantite = Convert.ToInt32(tabPorteOutils[i][3]);
                    image = tabPorteOutils[i][4];

                    listePorteOutils.Add(new PorteOutils(idTypePorteOutil, idEmplacement, quantite, image));
                }
            }

            return listePorteOutils;
        }
    }
}
