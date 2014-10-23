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
using GM241.Classes;

namespace GM241.Fenetres.InventaireGestion
{
    /// <summary>
    /// Logique d'interaction pour InventaireGestion.xaml
    /// </summary>
    public partial class InventaireGestion : Window
    {
        public InventaireGestion(string estAdmin)
        {
            InitializeComponent();

            authentifie.Content = estAdmin;

            cboxCategorie.Items.Insert(0, "Attachements");
            cboxCategorie.Items.Insert(1, "Collets");
            cboxCategorie.Items.Insert(2, "Outils");
            cboxCategorie.Items.Insert(3, "Plaquettes");
        }

        private void btnFerme_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void cboxCategorie_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Section attachements
            if (cboxCategorie.SelectedIndex == 0)
            {
                boiteResultats.Items.Clear();   // Vider la liste avant

                BDService BDAttachements = new BDService();

                // Valider l'utilisateur et le mot de passe en BD
                string requete = "SELECT * FROM Attachementcolletmachines";
                List<string>[] tabAtt;
                int nombreRange = 0;
                tabAtt = BDAttachements.selection(requete, 5, ref nombreRange);

                for (int i = 0; i < nombreRange; i++)
                {
                    boiteResultats.Items.Add(tabAtt[i][0] + ", " + tabAtt[i][2] + ", " + tabAtt[i][4]);
                }
            }

            // Section collets
            if (cboxCategorie.SelectedIndex == 1)
            {
                boiteResultats.Items.Clear();   // Vider la liste avant

                BDService BDCollets = new BDService();

                // Valider l'utilisateur et le mot de passe en BD
                string requete = "SELECT * FROM Collets";
                List<string>[] tabCol;
                int nombreRange = 0;
                tabCol = BDCollets.selection(requete, 4, ref nombreRange);

                for (int i = 0; i < nombreRange; i++)
                {
                    boiteResultats.Items.Add(tabCol[i][0] + ", " + tabCol[i][1] + ", " + tabCol[i][2] + ", " + tabCol[i][3]);
                }
            }

            // Section outils
            if (cboxCategorie.SelectedIndex == 2)
            {
                boiteResultats.Items.Clear();   // Vider la liste avant

                BDService BDOutils = new BDService();

                // Valider l'utilisateur et le mot de passe en BD
                string requete = "SELECT * FROM Outils";
                List<string>[] tabOutil;
                int nombreRange = 0;
                tabOutil = BDOutils.selection(requete, 15, ref nombreRange);

                for (int i = 0; i < nombreRange; i++)
                {
                    boiteResultats.Items.Add(tabOutil[i][0]  + ", " + tabOutil[i][3]  + ", " + tabOutil[i][4] + ", " + tabOutil[i][5] + ", " + tabOutil[i][6] + ", " + 
                                             tabOutil[i][7]  + ", " + tabOutil[i][8]  + ", " + tabOutil[i][9] + ", " + tabOutil[i][10] + ", " + tabOutil[i][11] + ", " + 
                                             tabOutil[i][12] + ", " + tabOutil[i][13] + ", " + tabOutil[i][14]);
                }
            }

            // Section plaquettes
            if (cboxCategorie.SelectedIndex == 3)
            {
                boiteResultats.Items.Clear();   // Vider la liste avant

                BDService BDPlaquettes = new BDService();

                // Valider l'utilisateur et le mot de passe en BD
                string requete = "SELECT * FROM Plaquettes";
                List<string>[] tabPla;
                int nombreRange = 0;
                tabPla = BDPlaquettes.selection(requete, 14, ref nombreRange);

                for (int i = 0; i < nombreRange; i++)
                {
                    boiteResultats.Items.Add(tabPla[i][0]  + ", " + tabPla[i][2]  + ", " + tabPla[i][3] + ", " + tabPla[i][4] + ", " + tabPla[i][5] + ", " +
                                             tabPla[i][6]  + ", " + tabPla[i][7]  + ", " + tabPla[i][8] + ", " + tabPla[i][9] + ", " + tabPla[i][10] + ", " +
                                             tabPla[i][11] + ", " + tabPla[i][12] + ", " + tabPla[i][13]);
                }
            }

            btnModification.IsEnabled = false;
            btnSupprimer.IsEnabled = false;

            if (cboxCategorie.Text != null)
            {
                btnRecherche.IsEnabled = true;
            }
        }

        private void boiteResultats_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            btnModification.IsEnabled = true;
            btnSupprimer.IsEnabled = true;
        }

        private void btnAjoutProduit_Click(object sender, RoutedEventArgs e)
        {
            // Ouverture du menu d'inventaire et de gestion de produits
            Produit.Produit Produit = new Produit.Produit();
            Produit.Show();
        }
    }
}
