using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using GM241.Fenetres.Inventaire;

namespace GM241.Fenetres.Menu
{
    /// <summary>
    /// Logique d'interaction pour MenuRapport.xaml
    /// </summary>
    public partial class MenuRapport : Window
    {
        public MenuRapport()
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
        }

        private void btnFermer_Click(object sender, RoutedEventArgs e)
        {
            //Inventaire.Inventaire inventaire = new Inventaire.Inventaire(estAdmin);
            //inventaire.Show();
            this.Close();   // Fermeture du login
        }
    }
}
