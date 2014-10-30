using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GM241.Classes
{
    class Outils
    {
        public virtual int idTypeOutil { get; set; }
        public virtual int idEmplacement { get; set; }
        public virtual int idPlaquette { get; set; }
        public virtual string nom { get; set; }
        public virtual int quantite { get; set; }
        public virtual string diametreUsinage { get; set; }
        public virtual string diametreSerrage { get; set; }
        public virtual string longueurCoupe { get; set; }
        public virtual string longueurTotal { get; set; }
        public virtual string longueurShank { get; set; }
        public virtual string rayonCoin { get; set; }
        public virtual string anglePointe { get; set; }
        public virtual int nombreFlute { get; set; }
        public virtual bool disponible { get; set; }
        public virtual bool  unitePouce { get; set; }
        public virtual string image { get; set; }

        public Outils()
        {
            idTypeOutil = 0;
            idEmplacement = 0;
            idPlaquette = 0;
            nom = "";
            quantite = 0;
            diametreUsinage = "";
            diametreSerrage = "";
            longueurCoupe = "";
            longueurTotal = "";
            longueurShank = "";
            rayonCoin = "";
            anglePointe = "";
            nombreFlute = 0;
            disponible = false;
            unitePouce = false;
            image = "";
        }

        public Outils(int idTO, int idEm, int idPla, string n, int q, string diamUsi, string diamSerr, string longC, string longT, string longS, 
                      string rayC, string angR, int nbFlute, bool dispo, bool unitPo, string img)
        {
            idTypeOutil = idTO;
            idEmplacement = idEm;
            idPlaquette = idPla;
            nom = n;
            quantite = q;
            diametreUsinage = diamUsi;
            diametreSerrage = diamSerr;
            longueurCoupe = longC;
            longueurTotal = longT;
            longueurShank = longS;
            rayonCoin = rayC;
            anglePointe = angR;
            nombreFlute = nbFlute;
            disponible = dispo;
            unitePouce = unitPo;
            image = img;
        }

        /// <summary>
        /// Fait un select sur la BD pour en extraire les outils qu'elle comporte
        /// </summary>
        /// <returns>Une liste de tous les outils que comporte la BD</returns>
        public static List<Outils> chargerLstOutils()
        {
            int idTypeOutil;
            int idEmplacement;
            int idPlaquette;
            string nom;
            int quantite;
            string diametreUsinage;
            string diametreSerrage;
            string longueurCoupe;
            string longueurTotal;
            string longueurShank;
            string rayonCoin;
            string anglePointe;
            int nombreFlute;
            bool disponible;
            bool  unitePouce;
            string image;

            BDService BDOutils = new BDService();
            String request = "SELECT * FROM Outils";

            List<string>[] tabOutil;
            int nombreRange = 0;
            tabOutil = BDOutils.selection(request, 17, ref nombreRange);

            List<Outils> listeOutils = new List<Outils>();

            if(nombreRange >= 1)
            {
                for (int i = 0; i < nombreRange; i++)
                {
                    idTypeOutil = Convert.ToInt32(tabOutil[i][1]);
                    idEmplacement = Convert.ToInt32(tabOutil[i][2]);
                    idPlaquette = Convert.ToInt32(tabOutil[i][3]);
                    nom = tabOutil[i][4];
                    quantite = Convert.ToInt32(tabOutil[i][5]);
                    diametreUsinage = tabOutil[i][6];
                    diametreSerrage = tabOutil[i][7];
                    longueurCoupe = tabOutil[i][8];
                    longueurTotal = tabOutil[i][9];
                    longueurShank = tabOutil[i][10];
                    rayonCoin = tabOutil[i][11];
                    anglePointe = tabOutil[i][12];
                    nombreFlute = Convert.ToInt32(tabOutil[i][13]);
                    disponible = Convert.ToBoolean(tabOutil[i][14]);
                    unitePouce = Convert.ToBoolean(tabOutil[i][15]);
                    image = tabOutil[i][16];

                    listeOutils.Add(new Outils(idTypeOutil, idEmplacement, idPlaquette, nom, quantite, diametreUsinage, diametreSerrage, longueurCoupe,
                                               longueurTotal, longueurShank, rayonCoin, anglePointe, nombreFlute, disponible, unitePouce, image));
                }
            }

            return listeOutils;
        }
    }
}
