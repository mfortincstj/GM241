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
using System.Windows.Shapes;
using GM241.Classes;
using GM241.Fenetres.Produit;
using GM241.Fenetres.Menu;

namespace GM241.Fenetres.InventaireGestion
{
    /// <summary>
    /// Logique d'interaction pour InventaireGestion.xaml
    /// </summary>
    public partial class InventaireGestion : Window
    {
        public InventaireGestion(bool estAdmin)
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;

            // L'utilisateur connecté est-il un admin ou pas ?
            if (estAdmin == true)
                authentifie.Content = "Administrateur";
            else   // Section usager seulement, alors pas acces au boutons ajouter, modifier et supprimer
            {
                authentifie.Content = "Usager";
                btnModification.Visibility = Visibility.Hidden;
                btnSupprimer.Visibility = Visibility.Hidden;
                btnAjoutProduit.Visibility = Visibility.Hidden;
            }

            cboxCategorie.Items.Add("Sélectionnez");
            cboxCategorie.Items.Add("Collet");          // Élément #1
            cboxCategorie.Items.Add("Porte outil");     // #2
            cboxCategorie.Items.Add("Outils");          // #3
            cboxCategorie.Items.Add("Plaquettes");      // #4
            cboxCategorie.SelectedIndex = 0;
        }

        private void btnFerme_Click(object sender, RoutedEventArgs e) {this.Close();}

        private void cboxCategorie_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Barrer l'acces au bouton rechercher si il n'y a pas de catégorie de sélectionnée
            if (cboxCategorie.SelectedIndex == 0)
            {
                btnRecherche.IsEnabled = false;
                boiteResultats.Items.Clear();
            }

            // Section Collet
            if (cboxCategorie.SelectedIndex == 1)
            {
                boiteResultats.Items.Clear();   // Vider la liste avant
                
                List<Collets> listCol = Collets.chargerlstCollets();

                foreach (Collets c in listCol)
                {
                    boiteResultats.Items.Add(c.idEmplacement + ", " + c.idTypeAttachement + ", " + c.diametreInterieur + ", " + c.quantite + ", " + c.image);
                }

                btnRecherche.IsEnabled = true;
            }

            // Section Porte outil
            if (cboxCategorie.SelectedIndex == 2)
            {
                boiteResultats.Items.Clear();   // Vider la liste avant

                /*
                List<Outils> listOutil = Outils.chargerLstOutils();

                foreach (Outils o in listOutil)
                {
                    boiteResultats.Items.Add(o.idTypeOutil + ", " + o.idEmplacement + ", " + o.idPlaquette + ", " + o.nom + ", " + o.quantite + ", " + 
                                             o.diametreUsinage + ", " + o.diametreSerrage + ", " + o.longueurCoupe + ", " + o.longueurTotal + ", " + 
                                             o.longueurShank + ", " + o.rayonCoin + ", " + o.anglePointe + ", " + o.nombreFlute + ", " + 
                                             o.disponible + ", " + o.unitePouce + ", " + o.image);
                }
                */
                btnRecherche.IsEnabled = true;
            }

            // Section outils
            if (cboxCategorie.SelectedIndex == 3)
            {
                boiteResultats.Items.Clear();   // Vider la liste avant

                List<Outils> listOutil = Outils.chargerLstOutils();

                foreach (Outils o in listOutil)
                {
                    boiteResultats.Items.Add(o.idTypeOutil + ", " + o.idEmplacement + ", " + o.idPlaquette + ", " + o.nom + ", " + o.quantite + ", " +
                                             o.diametreUsinage + ", " + o.diametreSerrage + ", " + o.longueurCoupe + ", " + o.longueurTotal + ", " +
                                             o.longueurShank + ", " + o.rayonCoin + ", " + o.anglePointe + ", " + o.nombreFlute + ", " +
                                             o.disponible + ", " + o.unitePouce + ", " + o.image);
                }

                btnRecherche.IsEnabled = true;
            }

            // Section plaquettes
            if (cboxCategorie.SelectedIndex == 4)
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

                btnRecherche.IsEnabled = true;
            }

            btnModification.IsEnabled = false;
            btnSupprimer.IsEnabled = false;
        }

        private void boiteResultats_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            btnModification.IsEnabled = true;
            btnSupprimer.IsEnabled = true;
        }

        private void btnAjoutProduit_Click(object sender, RoutedEventArgs e)
        {
            MenuAdmin menuAdmin= new MenuAdmin();
            menuAdmin.Show();

            this.Close();
        }

        private void btnSupprimer_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
