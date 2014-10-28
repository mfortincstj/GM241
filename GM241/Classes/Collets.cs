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
        public virtual float dimension { get; set; }
        public virtual string attachement { get; set; }
        public virtual int quantite { get; set; }
        public virtual string image { get; set; }

        public Collets()
        {
            BDService BDCollets = new BDService();
            
            String request = "SELECT * FROM Collets";

                List<string>[] tabCol;
                int nombreRange = 0;
                tabCol = BDCollets.selection(request, 7, ref nombreRange);

            if(nombreRange >= 1)
            { 
                idCollet = Convert.ToInt32(tabCol[0][0]);
                idEmplacement = Convert.ToInt32(tabCol[0][1]);
                nom = tabCol[0][2];
                dimension = float.Parse(tabCol[0][3], CultureInfo.InvariantCulture.NumberFormat);
                attachement = tabCol[0][4];
                quantite = Convert.ToInt32(tabCol[0][5]);
                image = tabCol[0][5];
            }
            else
            {
                
            }
        }
    }
}
