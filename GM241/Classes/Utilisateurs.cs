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
            public virtual int idUtilisateur { get; set; }
            public virtual string usager { get; set; }
            public virtual string prenom { get; set; }
            public virtual string nom { get; set; }
            public virtual string motDePasse { get; set; }
            public virtual bool estAdmin { get; set; }
        #endregion

        /*
        // Aller chercher la liste des utilisateurs dans la BD
        public List<string>[] BDUtilisateurs(string usager)
        {
            BDService BD = new BDService();

            // Valider l'utilisateur et le mot de passe en BD
            string requete = "SELECT * FROM Utilisateurs WHERE usager = " + "'" + usager + "'";
            List<string>[] tabRes;
            int nombreRange = 0;
            return tabRes = BD.selection(requete, 6, ref nombreRange);
        }
        */
    }
}
