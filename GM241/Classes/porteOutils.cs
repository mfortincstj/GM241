using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GM241.Classes
{
    public class PorteOutils
    {
        public virtual int idPorteOutil { get; set; }
        public virtual string idTypePorteOutil { get; set; }
        public virtual int idEmplacement { get; set; }
        public virtual int quantite { get; set; }
        public virtual string image { get; set; }

        public PorteOutils()
        {
            idPorteOutil = 0;
            idTypePorteOutil = "";
            idEmplacement = 0;
            quantite = 0;
            image = "";
        }

        public PorteOutils(int idPOut, string idTypePO, int idEm, int quant, string img)
        {
            idPorteOutil = idPOut;
            idTypePorteOutil = idTypePO;
            idEmplacement = idEm;
            quantite = quant;
            image = img;
        }

        public static List<PorteOutils> chargerlstPorteOutils()
        {
            int idPorteOutil;
            string idTypePorteOutil;
            int idEmplacement;
            int quantite;
            string image;

            BDService BDporteOutils = new BDService();
            String request = "SELECT * FROM PorteOutils AS po INNER JOIN TypePorteOutils AS tpo ON tpo.idTypePorteOutil = po.idTypePorteOutil";

            List<string>[] tabPorteOutils;
            int nombreRange = 0;
            tabPorteOutils = BDporteOutils.selection(request, 10, ref nombreRange);

            List<PorteOutils> listePorteOutils = new List<PorteOutils>();

            if (nombreRange >= 1)
            {
                for (int i = 0; i < nombreRange; i++)
                {
                    if (Convert.ToBoolean(tabPorteOutils[i][5]) == false)
                    {
                        idPorteOutil = Convert.ToInt32(tabPorteOutils[i][0]);
                        idTypePorteOutil = tabPorteOutils[i][9];
                        idEmplacement = Convert.ToInt32(tabPorteOutils[i][2]);
                        quantite = Convert.ToInt32(tabPorteOutils[i][3]);
                        image = tabPorteOutils[i][4];

                        listePorteOutils.Add(new PorteOutils(idPorteOutil, idTypePorteOutil, idEmplacement, quantite, image));
                    }
                }
            }

            return listePorteOutils;
        }

        public bool ajoutPorteOutil(int idTypePorteOutil, int idEmplacement, int quantite, string image)
        {
            BDService BDPorteOutils = new BDService();
            String request = "INSERT INTO PorteOutils (idTypePorteOutil, idEmplacement, quantite, image) VALUES" +
                             "( " + idTypePorteOutil +
                             ", " + idEmplacement +
                             ", " + quantite +
                             ", " + "'" + image.ToLower() + "'" + ");";

            if (BDPorteOutils.Insertion(request) == true)
                return true;
            else
                return false;
        }

        public bool deletePorteOutil(int id)
        {
            BDService BD = new BDService();
            String request = "UPDATE PorteOutils SET estSupprime = true WHERE idPorteOutil = " + id + ";";

            if (BD.delete(request) == true)
                return true;
            else
                return false;
        }
    }
}
