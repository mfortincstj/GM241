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
        public string MPestAmin;

        public MenuPrincipal()
        {
            InitializeComponent();

            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;

            authentifie.Content = "";
        }

        private void btnQuitter_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Voulez-vous quitter le programme ?", "Attention !", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No) == MessageBoxResult.Yes)
                Application.Current.Shutdown();
        }

        private void btnInventaireGestion_Click(object sender, RoutedEventArgs e)
        {
            // Ouverture du menu d'inventaire et de gestion de produits
            InventaireGestion.InventaireGestion InventaireGestion = new InventaireGestion.InventaireGestion(MPestAmin);
            InventaireGestion.Show();
        }

        private void btnDeconnexion_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Voulez-vous vous déconnectez ?", "Attention !", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No) == MessageBoxResult.Yes)
                this.Close();
        }
    }
}
