using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GM241.Classes
{
    public class TypePorteOutils
    {
        public virtual int idTypePorteOutil { get; set; }
        public virtual int idCone { get; set; }
        public virtual int idTypeAttachement { get; set; }
        public virtual string nom { get; set; }

        public TypePorteOutils()
        {
            idTypePorteOutil = 0;
            idCone = 0;
            idTypeAttachement = 0;
            nom = "";
        }

        public TypePorteOutils(int idTypePorteOut, int idCo, int idTA, string n)
        {
            idTypePorteOutil = idTypePorteOut;
            idCone = idCo;
            idTypeAttachement = idTA;
            nom = n;
        }

        public static List<TypePorteOutils> chargerlstTypePorteOutils()
        {
            int idTypePorteOutil;
            int idCone;
            int idTypeAttachement;
            string nom;

            BDService BDtypePorteOutils = new BDService();
            String request = "SELECT * FROM TypePorteOutils";

            List<string>[] tabTypePorteOutils;
            int nombreRange = 0;
            tabTypePorteOutils = BDtypePorteOutils.selection(request, 4, ref nombreRange);

            List<TypePorteOutils> listeTypePorteOutils = new List<TypePorteOutils>();

            if (nombreRange >= 1)
            {
                for (int i = 0; i < nombreRange; i++)
                {
                    idTypePorteOutil = Convert.ToInt32(tabTypePorteOutils[i][0]);
                    idCone = Convert.ToInt32(tabTypePorteOutils[i][1]);
                    idTypeAttachement = Convert.ToInt32(tabTypePorteOutils[i][2]);
                    nom = tabTypePorteOutils[i][3];

                    listeTypePorteOutils.Add(new TypePorteOutils(idTypePorteOutil, idCone, idTypeAttachement, nom));
                }
            }

            return listeTypePorteOutils;
        }
    }
}
