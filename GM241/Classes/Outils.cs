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
        public virtual int idOutil { get; set; }
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
        public virtual int nombreFlutePlaquette { get; set; }
        public virtual bool disponible { get; set; }
        public virtual string  uniteMmPo { get; set; }
        public virtual string image { get; set; }

        public Outils()
        {
            BDService BDOutils = new BDService();
            String request = "SELECT * FROM Outils";

            List<string>[] tabOutil;
            int nombreRange = 0;
            tabOutil = BDOutils.selection(request, 7, ref nombreRange);

            if(nombreRange >= 1)
            {
                
            }
            else
            {
                
            }
        }
    }
}
