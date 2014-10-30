using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GM241.Classes
{
    class PorteOutils
    {
        public virtual int idCollet { get; set; }
        public virtual int idTypePorteOutil { get; set; }
        public virtual int idEmplacement { get; set; }
        public virtual int idAttachement { get; set; }
        public virtual int idCone { get; set; }
        public virtual string nom { get; set; }
        public virtual string quantite { get; set; }
        public virtual string image { get; set; }

        public PorteOutils()
        {
            idCollet = 0;
            idTypePorteOutil = 0;
            idEmplacement = 0;
            idAttachement = 0;
            idCone = 0;
            nom = "";
            quantite = "";
            image = "";
        }

        public PorteOutils(int idCol, int idTypePO, int idEm, int idAtt, int idCon, string n, string quant, string img)
        {
            idCollet = idCol;
            idTypePorteOutil = idTypePO;
            idEmplacement = idEm;
            idAttachement = idAtt;
            idCone = idCon;
            nom = n;
            quantite = quant;
            image = img;
        }

        public static List<PorteOutils> chargerlstPorteOutils()
        {
            int idCollet;
            int idTypePorteOutil;
            int idEmplacement;
            int idAttachement;
            int idCone;
            string nom;
            string quantite;
            string image;

            BDService BDporteOutils = new BDService();
            String request = "SELECT * FROM PorteOutils";

            List<string>[] tabPorteOutils;
            int nombreRange = 0;
            tabPorteOutils = BDporteOutils.selection(request, 8, ref nombreRange);

            List<PorteOutils> listeporteOutils = new List<PorteOutils>();

            if (nombreRange >= 1)
            {
                for (int i = 0; i < nombreRange; i++)
                {
                    idCollet = Convert.ToInt32(tabPorteOutils[i][1]);
                    idTypePorteOutil = Convert.ToInt32(tabPorteOutils[i][2]);
                    idEmplacement = Convert.ToInt32(tabPorteOutils[i][3]);
                    idAttachement = Convert.ToInt32(tabPorteOutils[i][4]);
                    idCone = Convert.ToInt32(tabPorteOutils[i][5]);
                    nom = tabPorteOutils[i][6];
                    quantite = tabPorteOutils[i][7];
                    image = tabPorteOutils[i][8];

                    listeporteOutils.Add(new PorteOutils(idCollet, idTypePorteOutil, idEmplacement, idAttachement, idCone, nom, quantite, image));
                }
            }

            return listeporteOutils;
        }
    }
}
