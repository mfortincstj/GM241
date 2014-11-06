using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GM241.Classes
{
    public class TypeAttachements
    {
        public virtual string nom { get; set; }
        public virtual string diametreExterieur { get; set; }

        public TypeAttachements()
        {
            nom = "";
            diametreExterieur = "";
        }

        public TypeAttachements(string n, string dE)
        {
            nom = n;
            diametreExterieur = dE;
        }

        public static List<TypeAttachements> chargerlstTypeAttachements()
        {
            string nom;
            string diametreExterieur;

            BDService BDtypeAttachements = new BDService();
            String request = "SELECT * FROM TypeAttachements";

            List<string>[] tabTypeAttachements;
            int nombreRange = 0;
            tabTypeAttachements = BDtypeAttachements.selection(request, 3, ref nombreRange);

            List<TypeAttachements> listeTypeAttachements = new List<TypeAttachements>();

            if (nombreRange >= 1)
            {
                for (int i = 0; i < nombreRange; i++)
                {
                    nom = tabTypeAttachements[i][1];
                    diametreExterieur = tabTypeAttachements[i][2];

                    listeTypeAttachements.Add(new TypeAttachements(nom, diametreExterieur));
                }
            }

            return listeTypeAttachements;
        }
    }
}
