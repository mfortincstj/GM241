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
            public virtual int? matricule { get; set; }
            public virtual string prenom { get; set; }
            public virtual string nom { get; set; }
            public virtual string motDePasse { get; set; }
            public virtual bool estAdmin { get; set; }
        #endregion

        private MySqlConnexion connexion;

        // Aller chercher les infos sur l'usager demandé par l'utilisateur
        public Utilisateurs RetrieveUtilisateur(string matricule)
        {
            try
            {
                connexion = new MySqlConnexion();

                string requete = string.Format("SELECT * FROM Utilisateurs WHERE matricule = " + matricule);
                DataSet dataset = connexion.Query(requete);

                return ConstructUtilisateur(dataset.Tables[0].Rows[0]);
            }
            catch (MySqlException)
            {
                throw;
            }
        }

        private Utilisateurs ConstructUtilisateur(DataRow row)
        {
            return new Utilisateurs()
            {
                matricule = (int)row["matricule"],
                motDePasse = (string)row["motDePasse"],
                prenom = (string)row["prenom"],
                nom = (string)row["nom"],
                estAdmin = (bool)row["estAdmin"]
            };
        }
    }
}
