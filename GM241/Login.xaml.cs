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

        string admin = "";

        // Clic sur le bouton authentification
        private void btnAuthentification_Click(object sender, RoutedEventArgs e)
        {
            BDService BDUtilisateur = new BDService();

            string usagerFournit = usager.Text;
            string passwordFournit = motDePasse.Password;
            string usagerEnBD;
            string motDePasseEnBD;

            // Valider l'utilisateur et le mot de passe en BD
            string requete = "SELECT * FROM Utilisateurs WHERE usager = " + "'" + usagerFournit + "'";
            List<string>[] tabRes;
            int nombreRange = 0;
            tabRes = BDUtilisateur.selection(requete, 6, ref nombreRange);

            // Si le select en BD a capté quelque chose
            if (nombreRange >= 1)
            {
                usagerEnBD = tabRes[0][1];
                motDePasseEnBD = tabRes[0][2];
                admin = tabRes[0][5];
            }
            else // Ici, rien trouvé dans la BD
            {
                usagerEnBD = "erreur";
                motDePasseEnBD = "erreur";
            }

            // Si tout est valide, on passe au menu principal
            if (usagerFournit == usagerEnBD && passwordFournit == motDePasseEnBD)
            {
                // Fermeture du login
                Login Login = new Login();
                Login.Close();
                motDePasse.Password = "";

                // Ouverture du menu principal
                MenuPrincipal MenuPrincipal = new MenuPrincipal();
                MenuPrincipal.Show();
            }
            else // Le nom d'usager ou le mot de passe est invalide
            {
                // Afficher un message d'erreur
                MessageBox.Show("Nom d'usager ou mot de passe invalide", "Erreur !", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK);

                motDePasse.Password = "";
            }
        }

        // Retourn si l'utilisateur est admin ou pas
        public string adminAuthentifie()
        {
            if (admin == "True")
                return admin = "Admin";
            else if (admin == "False")
                return admin = "Usager";
            else
                return null;
        }

        // Clic sur quitter
        private void btnQuitter_Click(object sender, RoutedEventArgs e)
        {
            // Fermeture du projet
            Application.Current.Shutdown();
        }
    }
}
