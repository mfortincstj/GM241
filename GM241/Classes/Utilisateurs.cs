using System;
using System.Collections.Generic;
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
            private string motDePasse { get; set; }
            public virtual bool estAdmin { get; set; }
        #endregion


    }
}
