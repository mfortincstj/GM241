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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GM241
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }

        // Clic sur le bouton authentification
        private void authentification_Click(object sender, RoutedEventArgs e)
        {
            // Valider le nom d'utilisatuer en BD
            string usagerRecu = usager.Text;

            // Voir en BD si ce nom d'usager est valide ?


            // Valider le mot de passe en BD
            string motDePasseRecu = motDePasse.Text;

            // Si tout est valide, on passe au menu principal
            Login pageLogin = new Login();
            pageLogin.Close();


        }

        // Clic sur quitter
        private void quitter_Click(object sender, RoutedEventArgs e)
        {
            // Fermeture du projet
            Application.Current.Shutdown();
        }
    }
}
