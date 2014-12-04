using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GM241.Classes
{
    public class TypeOutils
    {
        public virtual int idTypeOutil { get; set; }
        public virtual string nom{ get; set; }

        public TypeOutils()
        {
            idTypeOutil = 0;
            nom = "";
        }

        public TypeOutils(int idTypeOul, string n)
        {
            idTypeOutil = idTypeOul;
            nom = n;
        }

        public static List<TypeOutils> chargerlstTypeOutils()
        {
            int idTypeOutil;
            string nom;

            BDService BDTypeOutils = new BDService();
            String request = "SELECT * FROM TypeOutils";

            List<string>[] tabTypeOutils;
            int nombreRange = 0;
            tabTypeOutils = BDTypeOutils.selection(request, 3, ref nombreRange);

            List<TypeOutils> listeTypeOutils = new List<TypeOutils>();

            if (nombreRange >= 1)
            {
                for (int i = 0; i < nombreRange; i++)
                {
                    if (Convert.ToBoolean(tabTypeOutils[i][2]) == false)
                    {
                        idTypeOutil = Convert.ToInt32(tabTypeOutils[i][0]);
                        nom = tabTypeOutils[i][1];

                        listeTypeOutils.Add(new TypeOutils(idTypeOutil, nom));
                    }
                }
            }

            return listeTypeOutils;
        }

        public bool ajoutTypeOutil(string nom)
        {
            BDService BDTypeOutil = new BDService();
            String request = "INSERT INTO TypeOutils (nom) VALUES" +
                             "( " + "'" + nom.ToLower() + "'" + ");";

            if (BDTypeOutil.Insertion(request) == true)
                return true;
            else
                return false;
        }

        public bool deleteTypeOutil(int id)
        {
            BDService BD = new BDService();
            String request = "UPDATE TypeOutils SET estSupprime = true WHERE idTypeOutil = " + id + ";";

            if (BD.delete(request) == true)
                return true;
            else
                return false;
        }
    }
}
