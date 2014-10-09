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

        private MySqlConnexion connexion;

        // Aller chercher les infos sur l'usager demandé par l'utilisateur
        public Utilisateurs RetrieveUtilisateur(string usagerLogin)
        {
            try
            {
                connexion = new MySqlConnexion();

                string requete = string.Format("SELECT * FROM Utilisateurs");
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
                idUtilisateur = (int)row["idUtilisateur"],
                usager = (string)row["usager"],
                motDePasse = (string)row["motDePasse"],
                prenom = (string)row["prenom"],
                nom = (string)row["nom"],
                estAdmin = (bool)row["estAdmin"]
            };
        }
    }
}
