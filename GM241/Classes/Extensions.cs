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
        public virtual string idPorteOutil { get; set; }
        public virtual int idEmplacement { get; set; }
        public virtual string idCollet { get; set; }
        public virtual string longueurShank { get; set; }
        public virtual string diametreShank { get; set; }
        public virtual string longueurTotale { get; set; }
        public virtual int quantite { get; set; }
        public virtual string image { get; set; }

        public Extensions()
        {
            idExtension = 0;
            idPorteOutil = "";
            idEmplacement = 0;
            idCollet = "";
            longueurShank = "";
            diametreShank = "";
            longueurTotale = "";
            quantite = 0;
            image = "";
        }

        public Extensions(int idExt, string idPO, int idEmp, string idCol, string longShank, string diamShank, string longTotal, int quant, string img)
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
        }

        public static List<Extensions> chargerlstExtensions()
        {
            int idExtension;
            string idPorteOutil;
            int idEmplacement;
            string idCollet;
            string longueurShank;
            string diametreShank;
            string longueurTotale;
            int quantite;
            string image;

            BDService BDExtensions = new BDService();

            String request = "SELECT * " +
                             "FROM Extensions AS e " +
                                "INNER JOIN Collets AS c ON c.idCollet = e.idCollet " +
                                "INNER JOIN PorteOutils AS po ON po.idPorteOutil = e.idPorteOutil";

            List<string>[] tabExtensions;
            int nombreRange = 0;
            tabExtensions = BDExtensions.selection(request, 21, ref nombreRange);

            List<Extensions> listeExtensions = new List<Extensions>();

            if (nombreRange >= 1)
            {
                for (int i = 0; i < nombreRange; i++)
                {
                    if (Convert.ToBoolean(tabExtensions[i][9]) == false)
                    {
                        idExtension = Convert.ToInt32(tabExtensions[i][0]);
                        idPorteOutil = tabExtensions[i][15];
                        idEmplacement = Convert.ToInt32(tabExtensions[i][2]);
                        idCollet = tabExtensions[i][8];
                        longueurShank = tabExtensions[i][4];
                        diametreShank = tabExtensions[i][5];
                        longueurTotale = tabExtensions[i][6];
                        quantite = Convert.ToInt32(tabExtensions[i][7]);
                        image = tabExtensions[i][8];

                        listeExtensions.Add(new Extensions(idExtension, idPorteOutil, idEmplacement, idCollet, longueurShank, diametreShank, longueurTotale, quantite, image));
                    }
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
