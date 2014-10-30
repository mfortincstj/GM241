using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GM241.Classes
{
    public class Collets
    {
        public virtual int idCollet { get; set; }
        public virtual int idEmplacement { get; set; }
        public virtual int idTypeAttachement { get; set; }
        public virtual string diametreInterieur { get; set; }
        public virtual int quantite { get; set; }
        public virtual string image { get; set; }

        public Collets()
        {
            idCollet = 0;
            idEmplacement = 0;
            idTypeAttachement = 0;
            diametreInterieur = "";
            quantite = 0;
            image = "";
        }

        public Collets(int idCol, int idEmp, int idTypeAtt, string diamInt, int quant, string img)
        {
            idCollet = idCol;
            idEmplacement = idEmp;
            idTypeAttachement = idTypeAtt;
            diametreInterieur = diamInt;
            quantite = quant;
            image = img;
        }

        public static List<Collets> chargerlstCollets()
        {
            int idCollet;
            int idEmplacement;
            int idTypeAttachement;
            string diametreInterieur;
            int quantite;
            string image;

            BDService BDCollets = new BDService();
            String request = "SELECT * FROM Collets";

            List<string>[] tabCol;
            int nombreRange = 0;
            tabCol = BDCollets.selection(request, 6, ref nombreRange);

            List<Collets> listeCollets = new List<Collets>();

            if (nombreRange >= 1)
            {
                for (int i = 0; i < nombreRange; i++)
                {
                    idCollet = Convert.ToInt32(tabCol[i][0]);
                    idEmplacement = Convert.ToInt32(tabCol[i][1]);
                    idTypeAttachement = Convert.ToInt32(tabCol[i][2]);
                    diametreInterieur = tabCol[i][3];
                    quantite = Convert.ToInt32(tabCol[i][4]);
                    image = tabCol[i][5];

                    listeCollets.Add(new Collets(idCollet, idEmplacement, idTypeAttachement, diametreInterieur, quantite, image));
                }
            }

            return listeCollets;
        }
    }
}
