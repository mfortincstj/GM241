using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GM241.Classes
{
    public class TypeAttachements
    {
        public virtual int idTypeAttachement { get; set; }
        public virtual string nom { get; set; }
        public virtual string diametreExterieur { get; set; }
        public virtual bool estSupprime { get; set; }

        public TypeAttachements()
        {
            idTypeAttachement = 0;
            nom = "";
            diametreExterieur = "";
            estSupprime = false;
        }

        public TypeAttachements(int idTypeAtt, string n, string dE, bool estSupp)
        {
            idTypeAttachement = idTypeAtt;
            nom = n;
            diametreExterieur = dE;
            estSupprime = estSupp;
        }

        public static List<TypeAttachements> chargerlstTypeAttachements()
        {
            int idTypeAttachement;
            string nom;
            string diametreExterieur;
            bool estSupprime;

            BDService BDtypeAttachements = new BDService();
            String request = "SELECT * FROM TypeAttachements";

            List<string>[] tabTypeAttachements;
            int nombreRange = 0;
            tabTypeAttachements = BDtypeAttachements.selection(request, 4, ref nombreRange);

            List<TypeAttachements> listeTypeAttachements = new List<TypeAttachements>();

            if (nombreRange >= 1)
            {
                for (int i = 0; i < nombreRange; i++)
                {
                    idTypeAttachement = Convert.ToInt32(tabTypeAttachements[i][0]);
                    nom = tabTypeAttachements[i][1];
                    diametreExterieur = tabTypeAttachements[i][2];
                    estSupprime = Convert.ToBoolean(tabTypeAttachements[i][3]);

                    listeTypeAttachements.Add(new TypeAttachements(idTypeAttachement, nom, diametreExterieur, estSupprime));
                }
            }

            return listeTypeAttachements;
        }

        public bool ajoutTypeAttachement(string nom, string diametreExterieur)
        {
            BDService BDTypeAttachement = new BDService();
            String request = "INSERT INTO TypeAttachements (nom, diametreExterieur) VALUES" +
                             "( " + "'" + nom.ToLower() + "'" +
                             ", " + "'" + diametreExterieur.ToLower() + "'" + ");";

            if (BDTypeAttachement.Insertion(request) == true)
                return true;
            else
                return false;
        }

        public bool deleteTypeAttachement(int id)
        {
            BDService BD = new BDService();
            String request = "UPDATE TypeAttachements SET estSupprime = true WHERE idTypeAttachement = " + id + ";";

            if (BD.delete(request) == true)
                return true;
            else
                return false;
        }
    }
}
