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
        private string usagerConnecte = "";
        private bool estAdmin = false;

        public MenuRapport(bool admin, string user)
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;

            estAdmin = admin;
            usagerConnecte = user;
        }

        private void btnFermer_Click(object sender, RoutedEventArgs e)
        {
            Inventaire.Inventaire inventaire = new Inventaire.Inventaire(estAdmin, usagerConnecte);
            inventaire.Show();
            this.Close();   // Fermeture du login
        }
    }
}
