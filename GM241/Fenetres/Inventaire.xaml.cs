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
using GM241;
using System.Collections;
using System.Data;

namespace GM241.Fenetres.Inventaire
{
    /// <summary>
    /// Logique d'interaction pour Inventaire.xaml
    /// </summary>
    public partial class Inventaire : Window
    {
        private string usagerConnecte = "";
        private bool estAdmin = false;

        /*private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (MessageBox.Show("Êtes-vous sûr de vouloir quitter?", "Attention!", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.Yes) == MessageBoxResult.Yes)
            {
                Application.Current.Shutdown();
            }
            else
            {
                e.Cancel = true;
            }
        }*/

        public Inventaire(bool admin, string user)
        {
            InitializeComponent();

            champNom.Focus();

            estAdmin = admin;
            usagerConnecte = user;

            // L'utilisateur connecté est-il un admin ou pas ?
            if (estAdmin == true)
            {
                authentifie.Content = "Administrateur";
                usager.Content = usagerConnecte;
            }
            else   // Section usager seulement, alors pas acces au boutons ajouter, modifier et supprimer
            {
                authentifie.Content = "Usager";
                usager.Content = usagerConnecte;
                lstMenu.IsEnabled = false;
                btnDetail.Visibility = Visibility.Hidden;
            }

            // Initialiser la liste des menus
            lstMenu.Items.Add("Inventaire");
            lstMenu.Items.Add("Administration");
            lstMenu.Items.Add("Rapports");
            lstMenu.SelectedIndex = 0;

            List<Collets> listCol = Collets.chargerlstCollets();
            resGrid1.ItemsSource = listCol;

            List<Outils> listOutil = Outils.chargerLstOutils();
            resGrid2.ItemsSource = listOutil;

            List<PorteOutils> listPorteOutil = PorteOutils.chargerlstPorteOutils();
            resGrid3.ItemsSource = listPorteOutil;

            List<Plaquettes> listPlaquette = Plaquettes.chargerlstPlaquettes();
            resGrid4.ItemsSource = listPlaquette;

            List <Cones> listCone = Cones.chargerlstCones();
            resGrid5.ItemsSource = listCone;

            List <Emplacements> listEmplacement = Emplacements.chargerlstEmplacements();
            resGrid6.ItemsSource = listEmplacement;

            List <Extensions> listExtension = Extensions.chargerlstExtensions();
            resGrid7.ItemsSource = listExtension;

            List <Machines> listMachine = Machines.chargerMachines();
            resGrid8.ItemsSource = listMachine;

            List <PlateauMachines> listPlateauMachine = PlateauMachines.chargerlstPlateauMachines();
            resGrid9.ItemsSource = listPlateauMachine;

            List <TypeAttachements> listTypeAttachement = TypeAttachements.chargerlstTypeAttachements();
            resGrid10.ItemsSource = listTypeAttachement;

            List <TypePorteOutils> listTypePorteOutil = TypePorteOutils.chargerlstTypePorteOutils();
            resGrid11.ItemsSource = listTypePorteOutil;

            List <TypeEmplacements> listTypeEmplacement = TypeEmplacements.chargerlstTypeEmplacements();
            resGrid12.ItemsSource = listTypeEmplacement;

            List<TypeOutils> listTypeOutil = TypeOutils.chargerlstTypeOutils();
            resGrid13.ItemsSource = listTypeOutil;
        }

        private void btnQuitter_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Voulez-vous quitter le programme?", "Attention!", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No) == MessageBoxResult.Yes)
                Application.Current.Shutdown();
        }

        void EventRow(object sender, SelectionChangedEventArgs args)
        {
            TabItem lbi = ((sender as TabControl).SelectedItem as TabItem);
            //tb.Text = "   You selected " + lbi.Content.ToString() + ".";
            Console.WriteLine(lbi.Content.ToString());
        }

        public void btnDetail_Click(object sender, RoutedEventArgs e)
        {
            var outil = resGrid.SelectedItem as Outils;

            Outil detailOutil = new Outil(outil);
            detailOutil.Show();
        }

        private void lstMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lstMenu.SelectedIndex == 1)   // Administration
            {
                MenuAdmin menuAdmin = new MenuAdmin(estAdmin, usagerConnecte);
                menuAdmin.Show();
                this.Close();
            }
            else if (lstMenu.SelectedIndex == 2)   // Rapports
            {
                MenuRapport menuRapport = new MenuRapport(estAdmin, usagerConnecte);
                menuRapport.Show();
                this.Close();
            }
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

            /*string nomFournit = champNom.Text.ToLower();
            string descriptionFournit = champDescription.Text.ToLower();

            foreach (Outils o in listOutil)
            {
                if (o.nom == nomFournit || o.idTypeOutil.ToString() == descriptionFournit || o.idEmplacement.ToString() == descriptionFournit
                    || o.diametreUsinage == descriptionFournit || o.diametreSerrage == descriptionFournit
                    || o.longueurCoupe == descriptionFournit || o.longueurTotal == descriptionFournit || o.longueurShank == descriptionFournit
                    || o.rayonCoin == descriptionFournit || o.anglePointe == descriptionFournit || o.nombreFlute.ToString() == descriptionFournit)
                {
                    resGrid2.Items.Add(o.idTypeOutil + ", " + o.idEmplacement + ", " + o.idPlaquette + ", " + o.nom + ", " + o.quantite + ", " +
                                             o.diametreUsinage + ", " + o.diametreSerrage + ", " + o.longueurCoupe + ", " + o.longueurTotal + ", " +
                                             o.longueurShank + ", " + o.rayonCoin + ", " + o.anglePointe + ", " + o.nombreFlute + ", " +
                                             o.disponible + ", " + o.unitePouce + ", " + o.image);
                }
            }

            foreach (Plaquettes p in listPlaquette)
            {
                if (p.nom == nomFournit || p.idEmplacement.ToString() == descriptionFournit || p.typePlaquette == descriptionFournit
                   || p.direction == descriptionFournit || p.angle == descriptionFournit || p.degagement == descriptionFournit
                   || p.grosseur == descriptionFournit || p.compagnie == descriptionFournit || p.codeAlpha == descriptionFournit
                   || p.tourFraseuse == descriptionFournit)
                {
                    resGrid4.Items.Add(p.idEmplacement + ", " + p.nom + ", " + p.typePlaquette + ", " + p.direction + ", " + p.angle
                                             + ", " + p.degagement + ", " + p.grosseur + ", " + p.compagnie + ", " + p.quantite + ", " + p.disponible
                                             + ", " + p.codeAlpha + ", " + p.unitePouce + ", " + p.tourFraseuse + ", " + p.image);
                }
            }

            foreach (Collets c in listCol)
            {
                if (c.idEmplacement.ToString() == descriptionFournit || c.idTypeAttachement.ToString() == descriptionFournit || c.diametreInterieur == descriptionFournit
                   || c.quantite.ToString() == descriptionFournit || c.image == descriptionFournit)
                {
                    resGrid1.Items.Add(c.idEmplacement + ", " + c.idTypeAttachement + ", " + c.diametreInterieur + ", " + c.quantite + ", " + c.image);
                }
            }

            foreach (PorteOutils po in listPorteOutil)
            {
                if (po.idTypePorteOutil.ToString() == descriptionFournit || po.idEmplacement.ToString() == descriptionFournit
                   || po.quantite.ToString() == descriptionFournit || po.image == descriptionFournit)
                {
                    resGrid3.Items.Add(po.idTypePorteOutil + ", " + po.idEmplacement + ", " + po.quantite + ", " + po.image);
                }
            }
        }*/

        private void resGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (resGrid.SelectedItem != null)
            {
                btnDetail.IsEnabled = true;
            }
        }

        private void champNom_TextChanged(object sender, TextChangedEventArgs e)
        {
            string nomFourni = champNom.Text.ToLower();
            List<Outils> listOutil = Outils.chargerLstOutils();
            
            if(nomFourni == "")
            {
                resGrid2.ItemsSource = listOutil;
            }
            else
            {
                resGrid2.ItemsSource = listOutil.Where(o => o.nom.Contains(nomFourni));
            }
        }

        private void champDescription_TextChanged(object sender, TextChangedEventArgs e)
        {
            string descFournie = champDescription.Text.ToLower();
            List<Outils> listOutil = Outils.chargerLstOutils();

            /*if (descFournie == "")
            {
                resGrid2.ItemsSource = listOutil;
            }*/
            //else
            //{
                resGrid2.ItemsSource = listOutil.Where(o => o.idTypeOutil.ToString().Contains(descFournie)
                                                         || o.idEmplacement.ToString().Contains(descFournie)
                                                         || o.idPlaquette.ToString().Contains(descFournie)
                                                         || o.quantite.ToString().Contains(descFournie)
                                                         || o.diametreUsinage.Contains(descFournie)
                                                         || o.diametreSerrage.Contains(descFournie)
                                                         || o.longueurCoupe.Contains(descFournie)
                                                         || o.longueurTotal.Contains(descFournie)
                                                         || o.longueurShank.Contains(descFournie)
                                                         || o.rayonCoin.Contains(descFournie)
                                                         || o.anglePointe.Contains(descFournie)
                                                         || o.nombreFlute.ToString().Contains(descFournie)
                                                         || o.image.Contains(descFournie));
            //}
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            string descFournie = champDescription.Text.ToLower();
            List<Outils> listOutil = Outils.chargerLstOutils();

            if (descFournie == "")
            {
                resGrid2.ItemsSource = listOutil;
            }
            else
            {
                resGrid2.ItemsSource = listOutil.Where(x => x.nom.Equals(descFournie));
            }
        }
    }
}