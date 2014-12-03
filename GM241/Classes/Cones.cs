using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GM241.Classes
{
    public class Cones
    {
        public virtual int idCone { get; set; }
        public virtual string nom { get; set; }
        public virtual string typeCone { get; set; }
        public virtual string typeMachine { get; set; }
        public virtual bool estSupprime { get; set; }

        public Cones()
        {
            idCone = 0;
            nom = "";
            typeCone = "";
            typeMachine = "";
            estSupprime = false;
        }

        public Cones(int idCon, string n, string typeC, string typeM, bool estSupp)
        {
            idCone = idCon;
            nom = n;
            typeCone = typeC;
            typeMachine = typeM;
            estSupprime = estSupp;
        }

        public static List<Cones> chargerlstCones()
        {
            int idCone;
            string nom;
            string typeCone;
            string typeMachine;
            bool estSupprime;

            BDService BDCones = new BDService();
            String request = "SELECT * FROM Cones";

            List<string>[] tabCones;
            int nombreRange = 0;
            tabCones = BDCones.selection(request, 5, ref nombreRange);

            List<Cones> listeCones = new List<Cones>();

            if (nombreRange >= 1)
            {
                for (int i = 0; i < nombreRange; i++)
                {
                    idCone = Convert.ToInt32(tabCones[i][0]);
                    nom = tabCones[i][1];
                    typeCone = tabCones[i][2];
                    typeMachine = tabCones[i][3];
                    estSupprime = Convert.ToBoolean(tabCones[i][4]);

                    listeCones.Add(new Cones(idCone, nom, typeCone, typeMachine, estSupprime));
                }
            }

            return listeCones;
        }

        public bool ajoutCone(string nom, string typeCone, string typeMachine)
        {
            BDService BDCones = new BDService();
            String request = "INSERT INTO Cones (nom, typeCone, TypeMachine) VALUES" +
                             "( " + "'" + nom.ToLower() + "'" +
                             ", " + "'" + typeCone.ToLower() + "'" +
                             ", " + "'" + typeMachine.ToLower() + "'" + ");";

            if (BDCones.Insertion(request) == true)
                return true;
            else
                return false;
        }

        public bool deleteCone(int id)
        {
            BDService BD = new BDService();
            String request = "UPDATE Cones SET estSupprime = true WHERE idCone = " + id + ";";

            if (BD.delete(request) == true)
                return true;
            else
                return false;
        }
    }
}
