using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GM241.Classes
{
    class Utilisateurs
    {
        #region
            public virtual string usager { get; set; }
            public virtual string motDePasse { get; set; }
            public virtual string prenom { get; set; }
            public virtual string nom { get; set; }
            public virtual bool estAdmin { get; set; }
        #endregion

        public Utilisateurs()
        {
            usager = "DefaultUsager";
            motDePasse = "DefaultMotDePasse";
            prenom = "DefaultPrenom";
            nom = "DefaultNom";
        }

        public void genereUtilisateurs(string usagerFournit)
        {
            BDService BDUtilisateur = new BDService();

            // Valider l'utilisateur et le mot de passe en BD
            string requete = "SELECT * FROM Utilisateurs WHERE usager = " + "'" + usagerFournit + "'";
            List<string>[] tabRes;
            int nombreRange = 0;
            tabRes = BDUtilisateur.selection(requete, 6, ref nombreRange);

            // Si le select en BD a capté quelque chose
            if (nombreRange >= 1)
            {
                usager = tabRes[0][1];
                motDePasse = tabRes[0][2];
                prenom = tabRes[0][3];
                nom = tabRes[0][4];

                if (tabRes[0][5] == "True")
                    estAdmin = true;
                else
                    estAdmin = false;

                usagerEstAdmin();
            }
            else // Ici, rien trouvé dans la BD
            {
                usager = "erreur";
                motDePasse = "erreur";
            }
        }

        // Valide si l'utilisateur qui tente de ce connecter est valide ou pas
        public bool userValide(string usagerFournit, string motDePasseFournit)
        {
            if (usagerFournit == usager && motDePasseFournit == motDePasse)
                return true;
            else
                return false;
        }

        public bool usagerEstAdmin()
        {
            if (estAdmin == true)
                return true;
            else
                return false;
        }
    }
}
