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
        public string index = "";

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

        public void btnDetail_Click(object sender, RoutedEventArgs e)
        {
            char[] splitchar = { ' ' };
            string str = null;
            string[] infoIndex = null;
            PorteOutils porteOutils = new PorteOutils();

            // Prendre le id du type d'emplacement
            str = index;
            infoIndex = str.Split(splitchar);
            /*
            var outil = resGrid.SelectedItem as Outils;

            Outil detailOutil = new Outil(outil);
            detailOutil.Show();
            */
            switch (infoIndex[2])
            {
                case "Collets":
                    MessageBox.Show("case 0 !");
                break;

                case "Outils" : 
                    var outil = resGrid2.SelectedItem as Outils;
                    Outil detailOutil = new Outil(outil);
                    detailOutil.Show();
                break;
            }
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

        private void tabInventaire_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (tabInventaire.SelectedIndex)
            {
                case 0:  // Test
                    btnDetail.IsEnabled = true;
                    index = tabInventaire.SelectedIndex.ToString();
                    MessageBox.Show(index);
                    break;

                case 1:  // Collets
                    btnDetail.IsEnabled = true;
                    index = tabInventaire.SelectedValue.ToString();
                    break;

                case 2:  // Outils
                    btnDetail.IsEnabled = true;
                    index = tabInventaire.SelectedValue.ToString();
                    break;

                case 3:  // PorteOutils
                    btnDetail.IsEnabled = true;
                    break;

                case 4:  // Plaquettes
                    btnDetail.IsEnabled = true;
                    break;

                case 5:  // Cones
                    btnDetail.IsEnabled = true;
                    break;

                case 6:  // EMplacements
                    btnDetail.IsEnabled = true;
                    break;

                case 7:  // Extensions
                    btnDetail.IsEnabled = true;
                    break;

                case 8:  // Machines
                    btnDetail.IsEnabled = true;
                    break;

                case 9:  // PlateauxMachines
                    btnDetail.IsEnabled = true;
                    break;

                case 10:  // TypeAttachements
                    btnDetail.IsEnabled = true;
                    break;

                case 11:  // TypePorteOutils
                    btnDetail.IsEnabled = true;
                    break;

                case 12:  // TypeEmplacements
                    btnDetail.IsEnabled = true;
                    break;
                case 13:  // TypeOutils
                    btnDetail.IsEnabled = true;
                    break;
            }
        }

        private void champNom_TextChanged(object sender, TextChangedEventArgs e)
        {
            string nomFourni = champNom.Text.ToLower();
            

            List<Collets> listCol = Collets.chargerlstCollets();
            List<Outils> listOutil = Outils.chargerLstOutils();
            List<PorteOutils> listPorteOutil = PorteOutils.chargerlstPorteOutils();
            List<Plaquettes> listPlaquette = Plaquettes.chargerlstPlaquettes();
            List<Cones> listCone = Cones.chargerlstCones();
            List<Emplacements> listEmplacement = Emplacements.chargerlstEmplacements();
            List<Extensions> listExtension = Extensions.chargerlstExtensions();
            List<Machines> listMachine = Machines.chargerMachines();
            List<PlateauMachines> listPlateauMachine = PlateauMachines.chargerlstPlateauMachines();
            List<TypeAttachements> listTypeAttachement = TypeAttachements.chargerlstTypeAttachements();
            List<TypePorteOutils> listTypePorteOutil = TypePorteOutils.chargerlstTypePorteOutils();
            List<TypeEmplacements> listTypeEmplacement = TypeEmplacements.chargerlstTypeEmplacements();
            List<TypeOutils> listTypeOutil = TypeOutils.chargerlstTypeOutils();
            
            if(nomFourni == "")
            {
                resGrid1.ItemsSource = listCol;
                resGrid2.ItemsSource = listOutil;
                resGrid3.ItemsSource = listPorteOutil;
                resGrid4.ItemsSource = listPlaquette;
                resGrid5.ItemsSource = listCone;
                resGrid6.ItemsSource = listEmplacement;
                resGrid7.ItemsSource = listExtension;
                resGrid8.ItemsSource = listMachine;
                resGrid9.ItemsSource = listPlateauMachine;
                resGrid10.ItemsSource = listTypeAttachement;
                resGrid11.ItemsSource = listTypePorteOutil;
                resGrid12.ItemsSource = listTypeEmplacement;
                resGrid13.ItemsSource = listTypeOutil;  
            }
            else
            {
                resGrid2.ItemsSource = listOutil.Where(o => o.nom.Contains(nomFourni));
                resGrid4.ItemsSource = listPlaquette.Where(o => o.nom.Contains(nomFourni));
                resGrid5.ItemsSource = listCone.Where(o => o.nom.Contains(nomFourni));
                resGrid8.ItemsSource = listMachine.Where(o => o.nom.Contains(nomFourni));
                resGrid9.ItemsSource = listPlateauMachine.Where(o => o.nom.Contains(nomFourni));
                resGrid10.ItemsSource = listTypeAttachement.Where(o => o.nom.Contains(nomFourni));
                resGrid11.ItemsSource = listTypePorteOutil.Where(o => o.nom.Contains(nomFourni));
                resGrid12.ItemsSource = listTypeEmplacement.Where(o => o.nom.Contains(nomFourni));
                resGrid13.ItemsSource = listTypeOutil.Where(o => o.nom.Contains(nomFourni));
            }
        }

        private void champDescription_TextChanged(object sender, TextChangedEventArgs e)
        {
            string descFournie = champDescription.Text.ToLower();
            List<Outils> listOutil = Outils.chargerLstOutils();

            if (descFournie == "")
            {
                resGrid2.ItemsSource = listOutil;
            }
            else
            {
                if(CheckBoxDesc.IsChecked == true)
                {
                    resGrid2.ItemsSource = listOutil.Where(o => o.idTypeOutil.ToString().Equals(descFournie)
                                                             || o.idEmplacement.ToString().Equals(descFournie)
                                                             || o.idPlaquette.ToString().Equals(descFournie)
                                                             || o.quantite.ToString().Equals(descFournie)
                                                             || o.diametreUsinage.Equals(descFournie)
                                                             || o.diametreSerrage.Equals(descFournie)
                                                             || o.longueurCoupe.Equals(descFournie)
                                                             || o.longueurTotal.Equals(descFournie)
                                                             || o.longueurShank.Equals(descFournie)
                                                             || o.rayonCoin.Equals(descFournie)
                                                             || o.anglePointe.Equals(descFournie)
                                                             || o.nombreFlute.ToString().Equals(descFournie)
                                                             || o.image.Equals(descFournie));
                }
                else
                {
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
                }
            }
        }
    }
}
