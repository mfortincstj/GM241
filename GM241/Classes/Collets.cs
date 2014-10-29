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
        public virtual string nom { get; set; }
        public virtual string dimension { get; set; }
        public virtual string attachement { get; set; }
        public virtual int quantite { get; set; }
        public virtual string image { get; set; }

        public Collets()
        {
            idCollet = 0;
            idEmplacement = 0;
            nom = "";
            dimension = "";
            attachement = "";
            quantite = 0;
            image = "";
        }

        public Collets(int idCol, int idEmp, string n, string dim, string att, int quant, string img)
        {
            idCollet = idCol;
            idEmplacement = idEmp;
            nom = n;
            dimension = dim;
            attachement = att;
            quantite = quant;
            image = img;
        }

        public List<Collets> listeCollets()
        {
            BDService BDCollets = new BDService();
            String request = "SELECT * FROM Collets";

            List<string>[] tabCol;
            int nombreRange = 0;
            tabCol = BDCollets.selection(request, 7, ref nombreRange);

            List<Collets> listeCollets = new List<Collets>();

            if (nombreRange >= 1)
            {
                for (int i = 0; i < nombreRange; i++)
                {
                    idCollet = Convert.ToInt32(tabCol[i][0]);
                    idEmplacement = Convert.ToInt32(tabCol[i][1]);
                    nom = tabCol[i][2];
                    dimension = tabCol[i][3];
                    attachement = tabCol[i][4];
                    quantite = Convert.ToInt32(tabCol[i][5]);
                    image = tabCol[i][6];

                    listeCollets.Add(new Collets(idCollet, idEmplacement, nom, dimension, attachement, quantite, image));
                }
            }

            return listeCollets;
        }
    }
}
