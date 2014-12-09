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
        public virtual string idCone { get; set; }
        public virtual string idTypeAttachement { get; set; }
        public virtual string nom { get; set; }

        public TypePorteOutils()
        {
            idTypePorteOutil = 0;
            idCone = "";
            idTypeAttachement = "";
            nom = "";
        }

        public TypePorteOutils(int idTypePorteOut, string idCo, string idTA, string n)
        {
            idTypePorteOutil = idTypePorteOut;
            idCone = idCo;
            idTypeAttachement = idTA;
            nom = n;
        }

        public static List<TypePorteOutils> chargerlstTypePorteOutils()
        {
            int idTypePorteOutil;
            string idCone;
            string idTypeAttachement;
            string nom;

            BDService BDtypePorteOutils = new BDService();
            String request = "SELECT * " + 
                             "FROM TypePorteOutils AS tpo " + 
                                "INNER JOIN Cones AS c ON c.idCone = tpo.idCone " +
                                "INNER JOIN TypeAttachements AS ta ON ta.idTypeAttachement = tpo.idTypeAttachement";

            List<string>[] tabTypePorteOutils;
            int nombreRange = 0;
            tabTypePorteOutils = BDtypePorteOutils.selection(request, 12, ref nombreRange);

            List<TypePorteOutils> listeTypePorteOutils = new List<TypePorteOutils>();

            if (nombreRange >= 1)
            {
                for (int i = 0; i < nombreRange; i++)
                {
                    if (Convert.ToBoolean(tabTypePorteOutils[i][4]) == false)
                    {
                        idTypePorteOutil = Convert.ToInt32(tabTypePorteOutils[i][0]); // a ne pas afficher
                        idCone = tabTypePorteOutils[i][6];
                        idTypeAttachement = tabTypePorteOutils[i][11]; // nom du type d'attachement
                        nom = tabTypePorteOutils[i][3];

                        listeTypePorteOutils.Add(new TypePorteOutils(idTypePorteOutil, idCone, idTypeAttachement, nom));
                    }
                }
            }

            return listeTypePorteOutils;
        }

        public bool ajoutTypePorteOutil(int idCone, int idTypeAttachement, string nom)
        {
            BDService BDTypePorteOutil = new BDService();
            String request = "INSERT INTO TypePorteOutils (idCone, idTypeAttachement, nom) VALUES" +
                             "( " + idCone +
                             ", " + idTypeAttachement +
                             ", " + "'" + nom.ToLower() + "'" + ");";

            if (BDTypePorteOutil.Insertion(request) == true)
                return true;
            else
                return false;
        }

        public bool deleteTypePorteOutil(int id)
        {
            BDService BD = new BDService();
            String request = "UPDATE TypePorteOutils SET estSupprime = true WHERE idTypePorteOutil = " + id + ";";

            if (BD.delete(request) == true)
                return true;
            else
                return false;
        }
    }
}
