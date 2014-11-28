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

            switch (infoIndex[2])
            {
                case "Collets":
                    var collet = resGrid1.SelectedItem as Collets;
                    Collet detailCollet = new Collet(collet);
                    detailCollet.Show();
                break;

                case "Outils":
                    var outil = resGrid2.SelectedItem as Outils;
                    Outil detailOutil = new Outil(outil);
                    detailOutil.Show();
                break;

                case "Porte-outils":
                    var porteOutil = resGrid3.SelectedItem as PorteOutils;
                    PorteOutil detailPorteOutil = new PorteOutil(porteOutil);
                    detailPorteOutil.Show();
                break;

                case "Plaquettes":
                    var plaquette = resGrid4.SelectedItem as Plaquettes;
                    Plaquette detailPlaquette = new Plaquette(plaquette);
                    detailPlaquette.Show();
                break;

                case "Cônes":
                    var cone = resGrid5.SelectedItem as Cones;
                    Cone detailCone = new Cone(cone);
                    detailCone.Show();
                break;

                case "Emplacements":
                    var emplacements = resGrid6.SelectedItem as Emplacements;
                    Emplacement detailEmplacement = new Emplacement(emplacements);
                    detailEmplacement.Show();
                break;

                case "Extensions":
                    var extensions = resGrid7.SelectedItem as Extensions;
                    Extension detailExtension = new Extension(extensions);
                    detailExtension.Show();
                break;

                case "Machines":
                    var machines = resGrid8.SelectedItem as Machines;
                    Machine detailMachine = new Machine(machines);
                    detailMachine.Show();
                break;

                case "Plateaux":
                    var plateauMachines = resGrid9.SelectedItem as PlateauMachines;
                    PlateauMachine detailPlateauMachine = new PlateauMachine(plateauMachines);
                    detailPlateauMachine.Show();
                break;
            }

            switch (infoIndex[3])
            {
                case "d'attachements":
                    var typeAttachements = resGrid10.SelectedItem as TypeAttachements;
                    TypeAttachement detailTypeAttachement = new TypeAttachement(typeAttachements);
                    detailTypeAttachement.Show();
                    break;

                case "de":
                    var typePorteOutils = resGrid11.SelectedItem as TypePorteOutils;
                    TypePorteOutil detailTypePorteOutil = new TypePorteOutil(typePorteOutils);
                    detailTypePorteOutil.Show();
                    break;

                case "d'emplacements":
                    var typeEmplacements = resGrid12.SelectedItem as TypeEmplacements;
                    TypeEmplacement detailTypeEmplacement = new TypeEmplacement(typeEmplacements);
                    detailTypeEmplacement.Show();
                    break;

                case "d'outils":
                    var typeOutils = resGrid13.SelectedItem as TypeOutils;
                    TypeOutil detailTypeOutil = new TypeOutil(typeOutils);
                    detailTypeOutil.Show();
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
            btnDetail.IsEnabled = true;
            index = tabInventaire.SelectedValue.ToString();
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
