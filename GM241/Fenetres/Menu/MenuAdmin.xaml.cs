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
using GM241.Fenetres.Produit;

namespace GM241.Fenetres.Menu
{
    /// <summary>
    /// Logique d'interaction pour menuAdmin.xaml
    /// </summary>
    public partial class MenuAdmin : Window
    {
        public MenuAdmin()
        {
            InitializeComponent();

            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
        }

        private void btnFermer_Click(object sender, RoutedEventArgs e)
        {
            bool estAdmin = true;

            MenuPrincipal menuPrincipal = new MenuPrincipal(estAdmin);
            menuPrincipal.Show();

            this.Close();
        }

        private void btnCollets_Click(object sender, RoutedEventArgs e)
        {
            Collet fenetreCollet = new Collet();
            fenetreCollet.Show();
        }

        private void btnOutils_Click(object sender, RoutedEventArgs e)
        {
            Outil fenetreOutil = new Outil();
            fenetreOutil.Show();
        }

        private void btnPlaquettes_Click(object sender, RoutedEventArgs e)
        {
            Plaquette fenetrePlaquette = new Plaquette();
            fenetrePlaquette.Show();
        }

        private void bntPorteOutils_Click(object sender, RoutedEventArgs e)
        {
            PorteOutil fenetrePorteOutil = new PorteOutil();
            fenetrePorteOutil.Show();
        }
    }
}
