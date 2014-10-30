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
using GM241.Fenetres.Menu;
using GM241.Classes;

namespace GM241.Fenetres.Menu
{
    /// <summary>
    /// Logique d'interaction pour MenuPrincipal.xaml
    /// </summary>
    public partial class MenuPrincipal : Window
    {
        bool admin;

        public MenuPrincipal(bool estAdmin)
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;

            // L'utilisateur connecté est-il un admin ou pas ?
            if (estAdmin == true)
            {
                admin = true;
                authentifie.Content = "Administrateur";
                btnMenuAdmin.IsEnabled = true;
                btnMenuRapport.IsEnabled = true;
            }
            else
            {
                admin = false;
                authentifie.Content = "Usager";
            }
        }

        private void btnQuitter_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Voulez-vous quitter le programme ?", "Attention !", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No) == MessageBoxResult.Yes)
                Application.Current.Shutdown();
        }

        private void btnInventaireGestion_Click(object sender, RoutedEventArgs e)
        {
            // Ouverture du menu d'inventaire et de gestion de produits
            InventaireGestion.InventaireGestion InventaireGestion = new InventaireGestion.InventaireGestion(admin);
            InventaireGestion.Show();
        }

        private void btnDeconnexion_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Voulez-vous vous déconnectez ?", "Attention !", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No) == MessageBoxResult.Yes)
            {
                Login login = new Login();
                login.Show();

                this.Close();
            }
        }

        private void btnMenuRapport_Click(object sender, RoutedEventArgs e)
        {
            MenuRapport menuRapport = new MenuRapport();
            menuRapport.Show();

            this.Close();
        }

        private void btnMenuAdmin_Click(object sender, RoutedEventArgs e)
        {
            MenuAdmin menuAdmin = new MenuAdmin();
            menuAdmin.Show();

            this.Close();
        }
    }
}
