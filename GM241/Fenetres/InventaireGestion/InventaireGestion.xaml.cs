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
                btnDetail.Visibility = Visibility.Hidden;
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
            }

            // Section Porte outil
            if (cboxCategorie.SelectedIndex == 2)
            {
                boiteResultats.Items.Clear();   // Vider la liste avant

                List<PorteOutils> listPorteOutil = PorteOutils.chargerlstPorteOutils();

                foreach (PorteOutils p in listPorteOutil)
                    boiteResultats.Items.Add(p.idTypePorteOutil + ", " + p.idEmplacement + ", " + p.quantite + ", " + p.image);
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
            }

            // Section plaquettes
            if (cboxCategorie.SelectedIndex == 4)
            {
                boiteResultats.Items.Clear();   // Vider la liste avant

                List<Plaquettes> listPlaquettes = Plaquettes.chargerlstPlaquettes();

                foreach (Plaquettes p in listPlaquettes)
                {
                    boiteResultats.Items.Add(p.idEmplacement + ", " + p.nom + ", " + p.typePlaquette + ", " + p.direction + ", " + p.angle 
                                             + ", " + p.degagement + ", " + p.grosseur + ", " + p.compagnie + ", " + p.quantite + ", " + p.disponible 
                                             + ", " + p.codeAlpha + ", " + p.unitePouce + ", " + p.tourFraseuse + ", " + p.image);
                }
            }

            btnDetail.IsEnabled = false;
        }

        private void boiteResultats_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            btnDetail.IsEnabled = true;
        }

        private void btnDetail_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnRecherche_Click(object sender, RoutedEventArgs e)
        {
            boiteResultats.Items.Clear();   // Vider la liste avant

            string nomFournit = champNom.Text.ToLower();
            string descriptionFournit = champDescription.Text.ToLower();

            List<Outils> listOutil = Outils.chargerLstOutils();

            foreach (Outils o in listOutil) 
            {
                if (o.nom == nomFournit || o.idTypeOutil.ToString() == descriptionFournit || o.idEmplacement.ToString() == descriptionFournit
                    || o.idPlaquette.ToString() == descriptionFournit || o.diametreUsinage == descriptionFournit || o.diametreSerrage == descriptionFournit 
                    || o.longueurCoupe == descriptionFournit || o.longueurTotal == descriptionFournit || o.longueurShank == descriptionFournit
                    || o.rayonCoin == descriptionFournit || o.anglePointe == descriptionFournit || o.nombreFlute.ToString() == descriptionFournit)
                {
                    boiteResultats.Items.Add(o.idTypeOutil + ", " + o.idEmplacement + ", " + o.idPlaquette + ", " + o.nom + ", " + o.quantite + ", " +
                                             o.diametreUsinage + ", " + o.diametreSerrage + ", " + o.longueurCoupe + ", " + o.longueurTotal + ", " +
                                             o.longueurShank + ", " + o.rayonCoin + ", " + o.anglePointe + ", " + o.nombreFlute + ", " +
                                             o.disponible + ", " + o.unitePouce + ", " + o.image);
                }         
            }

            List<Plaquettes> listPlaquettes = Plaquettes.chargerlstPlaquettes();

            foreach (Plaquettes p in listPlaquettes)
            {
                if(p.nom == nomFournit || p.idEmplacement.ToString() == descriptionFournit || p.typePlaquette == descriptionFournit 
                   || p.direction == descriptionFournit || p.angle == descriptionFournit || p.degagement == descriptionFournit 
                   || p.grosseur == descriptionFournit || p.compagnie == descriptionFournit || p.codeAlpha == descriptionFournit 
                   || p.tourFraseuse == descriptionFournit)
                {
                    boiteResultats.Items.Add(p.idEmplacement + ", " + p.nom + ", " + p.typePlaquette + ", " + p.direction + ", " + p.angle 
                                             + ", " + p.degagement + ", " + p.grosseur + ", " + p.compagnie + ", " + p.quantite + ", " + p.disponible 
                                             + ", " + p.codeAlpha + ", " + p.unitePouce + ", " + p.tourFraseuse + ", " + p.image);
                }
            }

            List<Collets> listCollets = Collets.chargerlstCollets();

            foreach (Collets c in listCollets)
            {
                if(c.idEmplacement.ToString() == descriptionFournit || c.idTypeAttachement.ToString() == descriptionFournit || c.diametreInterieur == descriptionFournit
                   || c.quantite.ToString() == descriptionFournit || c.image == descriptionFournit)
                {
                    boiteResultats.Items.Add(c.idEmplacement + ", " + c.idTypeAttachement + ", " + c.diametreInterieur + ", " + c.quantite + ", " + c.image);
                }
            }

            List<PorteOutils> listPorteOutils = PorteOutils.chargerlstPorteOutils();

            foreach (PorteOutils po in listPorteOutils)
            {
                if(po.idTypePorteOutil.ToString() == descriptionFournit || po.idEmplacement.ToString() == descriptionFournit
                   || po.quantite.ToString() == descriptionFournit || po.image == descriptionFournit)
                {
                    boiteResultats.Items.Add(po.idTypePorteOutil + ", " + po.idEmplacement + ", " + po.quantite + ", " + po.image);
                }
            }
        }
    }
}
