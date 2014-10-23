using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GM241.Classes;

namespace GM241.Classes
{
    class RequetesBD
    {
        public List<String>[] function_SelectOutils()
        {

            BDService BDoutils = new BDService();
            String request = "SELECT * FROM Outils";

                List<string>[] tabOut;
                int nombreRange = 0;
                tabOut = BDoutils.selection(request, 5, ref nombreRange);

            return tabOut;      
        }

        public List<String>[] function_SelectCollets()
        {

            BDService BDCollets = new BDService();
            String request = "SELECT * FROM Collets";

                List<string>[] tabCol;
                int nombreRange = 0;
                tabCol = BDCollets.selection(request, 7, ref nombreRange);

            return tabCol;
        }
    }
}
