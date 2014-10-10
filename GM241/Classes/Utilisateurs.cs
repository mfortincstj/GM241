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


    }
}
