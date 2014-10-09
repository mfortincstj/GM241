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
using GM241.Fenetres.MenuPrincipal;
using GM241.Classes;
using MySql.Data.MySqlClient;
using System.Data;

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

            // Centrer la fenêtre à l'ouverture de l'écran
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
        }

        // Clic sur le bouton authentification
        private void btnAuthentification_Click(object sender, RoutedEventArgs e)
        {
            Utilisateurs user = new Utilisateurs();
            string usagerFournit = usager.Text;
            string passwordFournit = motDePasse.ToString();

            bool matriculeValide = false;
            bool motDePasseValide = false;

            // Valider l'utilisateur en BD
            user.RetrieveUtilisateur(usagerFournit);

            MessageBox.Show(user.usager);

            // Si tout est valide, on passe au menu principal
            if (matriculeValide == true && motDePasseValide == true)
            {
                // Fermeture du login
                Login fLogin = new Login();   // fLogin pour fenêtre de login
                fLogin.Close();

                // Ouverture du menu principal
                MenuPrincipal fMenuPrincipal = new MenuPrincipal();
                fMenuPrincipal.Show();
            }
            else // Le nom d'usager ou le mot de passe est invalide
            {
                // Afficher un message d'erreur
                MessageBox.Show("Nom d'usager ou mot de passe invalide", "Erreur !", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK);

                motDePasse.Password = "";
            }
        }

        // Clic sur quitter
        private void btnQuitter_Click(object sender, RoutedEventArgs e)
        {
            // Fermeture du projet
            Application.Current.Shutdown();
        }
    }
}
