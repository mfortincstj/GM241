using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GM241.Classes
{
    class Plaquettes
    {
        public virtual int idEmplacement { get; set; }
        public virtual string nom { get; set; }
        public virtual string typePlaquette { get; set; }
        public virtual string direction { get; set; }
        public virtual float angle { get; set; }
        public virtual float degagement { get; set; }
        public virtual float grosseur { get; set; }
        public virtual string compagnie { get; set; }
        public virtual int quantite { get; set; }
        public virtual bool disponible { get; set; }
        public virtual string codeAlpha { get; set; }
        public virtual string ordre { get; set; }
        public virtual float tourFraseuse { get; set; }
        public virtual string image { get; set; }

        public Plaquettes()
        {
            idEmplacement = 0;
            nom = "";
            typePlaquette = "";
            direction = "";
            angle = 0;
            degagement = 0;
            grosseur = 0;
            compagnie = "";
            quantite = 0;
            disponible = false;
            codeAlpha = "";
            ordre = "";
            tourFraseuse = 0;
            image = "";
        }

        public Plaquettes(int idEmp, string n, string typePla, string direc, float ang, float dega, float gros,
                          string comp, int quant, bool dispo, string codeA, string ord, float tourFra, string img)
        {
            idEmplacement = idEmp;
            nom = n;
            typePlaquette = typePla;
            direction = direc;
            angle = ang;
            degagement = dega;
            grosseur = gros;
            compagnie = comp;
            quantite = quant;
            disponible = dispo;
            codeAlpha = codeA;
            ordre = ord;
            tourFraseuse = tourFra;
            image = img;
        }

        public static List<Plaquettes> chargerlstPlaquettes()
        {
            int idEmplacement;
            string nom;
            string typePlaquette;
            string direction;
            float angle;
            float degagement;
            float grosseur;
            string compagnie;
            int quantite;
            bool disponible;
            string codeAlpha;
            string ordre;
            float tourFraseuse;
            string image;

            BDService BDPlaquettes = new BDService();
            String request = "SELECT * FROM Plaquettes";

            List<string>[] tabPlaquettes;
            int nombreRange = 0;
            tabPlaquettes = BDPlaquettes.selection(request, 15, ref nombreRange);

            List<Plaquettes> listePlaquettes = new List<Plaquettes>();

            if (nombreRange >= 1)
            {
                for (int i = 0; i < nombreRange; i++)
                {
                    idEmplacement = Convert.ToInt32(tabPlaquettes[i][1]);
                    nom = tabPlaquettes[i][2];
                    typePlaquette = tabPlaquettes[i][3];
                    direction = tabPlaquettes[i][4];
                    angle = float.Parse(tabPlaquettes[i][5], CultureInfo.InvariantCulture.NumberFormat);
                    degagement = float.Parse(tabPlaquettes[i][6], CultureInfo.InvariantCulture.NumberFormat);
                    grosseur = float.Parse(tabPlaquettes[i][7], CultureInfo.InvariantCulture.NumberFormat);
                    compagnie = tabPlaquettes[i][8];
                    quantite = Convert.ToInt32(tabPlaquettes[i][9]);
                    disponible = Convert.ToBoolean(tabPlaquettes[i][10]);
                    codeAlpha = tabPlaquettes[i][11];
                    ordre = tabPlaquettes[i][12];
                    tourFraseuse = float.Parse(tabPlaquettes[i][13], CultureInfo.InvariantCulture.NumberFormat);
                    image = tabPlaquettes[i][14];

                    listePlaquettes.Add(new Plaquettes(idEmplacement, nom, typePlaquette, direction, angle, degagement, grosseur, compagnie, quantite, 
                                                        disponible, codeAlpha, ordre, tourFraseuse, image));
                }
            }

            return listePlaquettes;
        }
    }
}
