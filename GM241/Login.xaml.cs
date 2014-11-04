﻿using System;
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
using GM241.Fenetres.Menu;
using GM241.Classes;

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

        // Authentification
        private void btnAuthentification_Click(object sender, RoutedEventArgs e)
        {
            string usagerFournit = usager.Text;
            string motDePasseFournit = motDePasse.Password;

            Utilisateurs user = new Utilisateurs();
            user.genereUtilisateurs(usagerFournit);

            // Validation de l'utilisateur
            if (user.userValide(usagerFournit, motDePasseFournit) == true)   // L'utilisateur est valide on passe au menu principal
            {
                // Ouverture du menu principal
                MenuPrincipal MenuPrincipal = new MenuPrincipal(user.estAdmin);
                MenuPrincipal.Show();

                this.Close();   // Fermeture du login
            }
            else   // L'utilisateur n'est pas valide message d'erreur
            {
                MessageBox.Show("Nom d'usager ou mot de passe invalide", "Erreur!", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK);

                motDePasse.Password = "";
            }
        }

        private void btnQuitter_Click(object sender, RoutedEventArgs e)
        {
            

            if(MessageBox.Show("Êtes-vous sûr de vouloir quitter?", "Attention!", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.Yes) == MessageBoxResult.Yes)
            { 
                Application.Current.Shutdown();
            }
        }
    }
}
