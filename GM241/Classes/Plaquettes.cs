using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GM241.Classes
{
    public class Plaquettes
    {
        public virtual int idPlaquette { get; set; }
        public virtual int idEmplacement { get; set; }
        public virtual string nom { get; set; }
        public virtual string typePlaquette { get; set; }
        public virtual string direction { get; set; }
        public virtual string angle { get; set; }
        public virtual string degagement { get; set; }
        public virtual string grosseur { get; set; }
        public virtual string compagnie { get; set; }
        public virtual int quantite { get; set; }
        public virtual bool disponible { get; set; }
        public virtual string codeAlpha { get; set; }
        public virtual string tourFraseuse { get; set; }
        public virtual bool unitePouce { get; set; }
        public virtual string image { get; set; }

        public Plaquettes()
        {
            idPlaquette = 0;
            idEmplacement = 0;
            nom = "";
            typePlaquette = "";
            direction = "";
            angle = "";
            degagement = "";
            grosseur = "";
            compagnie = "";
            quantite = 0;
            disponible = false;
            codeAlpha = "";
            tourFraseuse = "";
            unitePouce = false;
            image = "";
        }

        public Plaquettes(int idPlaq, int idEmp, string n, string typePla, string direc, string ang, string dega, string gros,
                          string comp, int quant, bool dispo, string codeA, string tourFra, bool unitePo, string img)
        {
            idPlaquette = idPlaq;
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
            tourFraseuse = tourFra;
            unitePouce = unitePo;
            image = img;
        }

        public static List<Plaquettes> chargerlstPlaquettes()
        {
            int idPlaquette;
            int idEmplacement;
            string nom;
            string typePlaquette;
            string direction;
            string angle;
            string degagement;
            string grosseur;
            string compagnie;
            int quantite;
            bool disponible;
            string codeAlpha;
            string tourFraseuse;
            bool unitePouce;
            string image;

            BDService BDPlaquettes = new BDService();
            String request = "SELECT * FROM Plaquettes";

            List<string>[] tabPlaquettes;
            int nombreRange = 0;
            tabPlaquettes = BDPlaquettes.selection(request, 16, ref nombreRange);

            List<Plaquettes> listePlaquettes = new List<Plaquettes>();

            if (nombreRange >= 1)
            {
                for (int i = 0; i < nombreRange; i++)
                {
                    if (Convert.ToBoolean(tabPlaquettes[i][15]) == false)
                    {
                        idPlaquette = Convert.ToInt32(tabPlaquettes[i][0]);
                        idEmplacement = Convert.ToInt32(tabPlaquettes[i][1]);
                        nom = tabPlaquettes[i][2];
                        typePlaquette = tabPlaquettes[i][3];
                        direction = tabPlaquettes[i][4];
                        angle = tabPlaquettes[i][5];
                        degagement = tabPlaquettes[i][6];
                        grosseur = tabPlaquettes[i][7];
                        compagnie = tabPlaquettes[i][8];
                        quantite = Convert.ToInt32(tabPlaquettes[i][9]);
                        disponible = Convert.ToBoolean(tabPlaquettes[i][10]);
                        codeAlpha = tabPlaquettes[i][11];
                        tourFraseuse = tabPlaquettes[i][12];
                        unitePouce = Convert.ToBoolean(tabPlaquettes[i][13]);
                        image = tabPlaquettes[i][14];

                        listePlaquettes.Add(new Plaquettes(idPlaquette, idEmplacement, nom, typePlaquette, direction, angle, degagement, grosseur, compagnie, quantite, 
                                                        disponible, codeAlpha, tourFraseuse, unitePouce, image));  
                    }
                }
            }

            return listePlaquettes;
        }

        public bool ajoutPlaquette(int idEmplacement, string nom, string typePlaquette, string direction, string angle, string degagement, string grosseur, string compagnie, int quantite, bool disponible, string codeAlpha, string tourFraseuse, bool unitePouce, string image)
        {
            BDService BDPlaquettes = new BDService();
            String request = "INSERT INTO Plaquettes (idEmplacement, nom, typePlaquette, direction, angle, degagement, grosseur, compagnie, quantite, disponible, codeAlpha, tourFraseuse, unitePouce, image) VALUES" +
                             "( " + idEmplacement +
                             ", " + "'" + nom.ToLower() + "'" +
                             ", " + "'" + typePlaquette.ToLower() + "'" +
                             ", " + "'" + direction.ToLower() + "'" +
                             ", " + "'" + angle.ToLower() + "'" +
                             ", " + "'" + degagement.ToLower() + "'" +
                             ", " + "'" + grosseur.ToLower() + "'" +
                             ", " + "'" + compagnie.ToLower() + "'" +
                             ", " + quantite +
                             ", " + disponible +
                             ", " + "'" + codeAlpha.ToLower() + "'" +
                             ", " + "'" + tourFraseuse.ToLower() + "'" +
                             ", " + unitePouce +
                             ", " + "'" + image.ToLower() + "'" + ");";

            if (BDPlaquettes.Insertion(request) == true)
                return true;
            else
                return false;
        }

        public bool deletePlaquette(int id)
        {
            BDService BD = new BDService();
            String request = "UPDATE Plaquettes SET estSupprime = true WHERE idPlaquette = " + id + ";";

            if (BD.delete(request) == true)
                return true;
            else
                return false;
        }
    }
}
