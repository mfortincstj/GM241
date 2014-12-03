using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GM241.Classes
{
    public class Extensions
    {
        public virtual int idExtension { get; set; }
        public virtual int idPorteOutil { get; set; }
        public virtual int idEmplacement { get; set; }
        public virtual int idCollet { get; set; }
        public virtual string longueurShank { get; set; }
        public virtual string diametreShank { get; set; }
        public virtual string longueurTotale { get; set; }
        public virtual int quantite { get; set; }
        public virtual string image { get; set; }
        public virtual bool estSupprime { get; set; }

        public Extensions()
        {
            idExtension = 0;
            idPorteOutil = 0;
            idEmplacement = 0;
            idCollet = 0;
            longueurShank = "";
            diametreShank = "";
            longueurTotale = "";
            quantite = 0;
            image = "";
            estSupprime = false;
        }

        public Extensions(int idExt, int idPO, int idEmp, int idCol, string longShank, string diamShank, string longTotal, int quant, string img, bool estSupp)
        {
            idExtension = idExt;
            idPorteOutil = idPO;
            idEmplacement = idEmp;
            idCollet = idCol;
            longueurShank = longShank;
            diametreShank = diamShank;
            longueurTotale = longTotal;
            quantite = quant;
            image = img;
            estSupprime = estSupp;
        }

        public static List<Extensions> chargerlstExtensions()
        {
            int idExtension;
            int idPorteOutil;
            int idEmplacement;
            int idCollet;
            string longueurShank;
            string diametreShank;
            string longueurTotale;
            int quantite;
            string image;
            bool estSupprime;

            BDService BDExtensions = new BDService();
            String request = "SELECT * FROM Extensions";

            List<string>[] tabExtensions;
            int nombreRange = 0;
            tabExtensions = BDExtensions.selection(request, 10, ref nombreRange);

            List<Extensions> listeExtensions = new List<Extensions>();

            if (nombreRange >= 1)
            {
                for (int i = 0; i < nombreRange; i++)
                {
                    idExtension = Convert.ToInt32(tabExtensions[i][0]);
                    idPorteOutil = Convert.ToInt32(tabExtensions[i][1]);
                    idEmplacement = Convert.ToInt32(tabExtensions[i][2]);
                    idCollet = Convert.ToInt32(tabExtensions[i][3]);
                    longueurShank = tabExtensions[i][4];
                    diametreShank = tabExtensions[i][5];
                    longueurTotale = tabExtensions[i][6];
                    quantite = Convert.ToInt32(tabExtensions[i][7]);
                    image = tabExtensions[i][8];
                    estSupprime = Convert.ToBoolean(tabExtensions[i][9]);

                    listeExtensions.Add(new Extensions(idExtension, idPorteOutil, idEmplacement, idCollet, longueurShank, diametreShank, longueurTotale, quantite, image, estSupprime));
                }
            }

            return listeExtensions;
        }

        public bool ajoutExtension(int idPorteOutil, int idEmplacement, int idCollet, string longueurShank, string diametreShank, string longueurTotale, int quantite, string image)
        {
            BDService BDExtension = new BDService();
            String request = "INSERT INTO Extensions (idPorteOutil, idEmplacement, idCollet, longueurShank, diametreShank, longueurTotale, quantite, image) VALUES" +
                             "( " + idPorteOutil +
                             ", " + idEmplacement +
                             ", " + idCollet +
                             ", " + "'" + longueurShank.ToLower() + "'" +
                             ", " + "'" + diametreShank.ToLower() + "'" +
                             ", " + "'" + longueurTotale.ToLower() + "'" +
                             ", " + quantite +
                             ", " + "'" + image.ToLower() + "'" + ");";

            if (BDExtension.Insertion(request) == true)
                return true;
            else
                return false;
        }

        public bool deleteExtension(int id)
        {
            BDService BD = new BDService();
            String request = "UPDATE Extensions SET estSupprime = true WHERE idExtension = " + id + ";";

            if (BD.delete(request) == true)
                return true;
            else
                return false;
        }
    }
}
