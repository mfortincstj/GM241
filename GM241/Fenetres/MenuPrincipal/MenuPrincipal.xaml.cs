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
using GM241.Fenetres.InventaireGestion;

namespace GM241.Fenetres.MenuPrincipal
{
    /// <summary>
    /// Logique d'interaction pour MenuPrincipal.xaml
    /// </summary>
    public partial class MenuPrincipal : Window
    {
        public MenuPrincipal()
        {
            InitializeComponent();

            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;

            // Admin
            Login Login = new Login();
            string test = "test";
            //test = Login.adminAuthentifie();
            authentifie.Text = "test";
        }

        private void btnQuitter_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btnInventaireGestion_Click(object sender, RoutedEventArgs e)
        {
            // Ouverture du menu principal
            InventaireGestion.InventaireGestion InventaireGestion = new InventaireGestion.InventaireGestion();
            InventaireGestion.Show();
        }

        private void btnDeconnexion_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

