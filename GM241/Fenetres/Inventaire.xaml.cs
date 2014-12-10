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

        private void refresh()
        {
            Inventaire windowsInventaire = new Inventaire(estAdmin, usagerConnecte);
            this.Close();
            windowsInventaire.Show();
        }

        public Inventaire(bool admin, string user)
        {
            InitializeComponent();
            btnDetail.IsEnabled = false;

            champNom.Focus();

            champNom.ToolTip = "Pour le nom des produits";
            champDescription.ToolTip = "Pour tout les champs sauf le nom des produits";
            radioEt.ToolTip = "À venir";
            radioOu.ToolTip = "À venir";
            CheckBoxDesc.ToolTip = "Force la correspondance exacte du critère";

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
            btnDetail.IsEnabled = false;

            if (MessageBox.Show("Voulez-vous quitter le programme?", "Attention!", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No) == MessageBoxResult.Yes)
                Application.Current.Shutdown();
        }

        public void btnDetail_Click(object sender, RoutedEventArgs e)
        {
            btnDetail.IsEnabled = false;

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
                    detailCollet.ShowDialog();
                break;

                case "Outils":
                    var outil = resGrid2.SelectedItem as Outils;
                    Outil detailOutil = new Outil(outil);
                    detailOutil.ShowDialog();
                break;

                case "Porte-outils":
                    var porteOutil = resGrid3.SelectedItem as PorteOutils;
                    PorteOutil detailPorteOutil = new PorteOutil(porteOutil);
                    detailPorteOutil.ShowDialog();
                break;

                case "Plaquettes":
                    var plaquette = resGrid4.SelectedItem as Plaquettes;
                    Plaquette detailPlaquette = new Plaquette(plaquette);
                    detailPlaquette.ShowDialog();
                break;

                case "Cônes":
                    var cone = resGrid5.SelectedItem as Cones;
                    Cone detailCone = new Cone(cone);
                    detailCone.ShowDialog();
                break;

                case "Emplacements":
                    var emplacements = resGrid6.SelectedItem as Emplacements;
                    Emplacement detailEmplacement = new Emplacement(emplacements);
                    detailEmplacement.ShowDialog();
                break;

                case "Extensions":
                    var extensions = resGrid7.SelectedItem as Extensions;
                    Extension detailExtension = new Extension(extensions);
                    detailExtension.ShowDialog();
                break;

                case "Machines":
                    var machines = resGrid8.SelectedItem as Machines;
                    Machine detailMachine = new Machine(machines);
                    detailMachine.ShowDialog();
                break;

                case "Plateaux":
                    var plateauMachines = resGrid9.SelectedItem as PlateauMachines;
                    PlateauMachine detailPlateauMachine = new PlateauMachine(plateauMachines);
                    detailPlateauMachine.ShowDialog();
                break;
            }

            switch (infoIndex[3])
            {
                case "d'attachements":
                    var typeAttachements = resGrid10.SelectedItem as TypeAttachements;
                    TypeAttachement detailTypeAttachement = new TypeAttachement(typeAttachements);
                    detailTypeAttachement.ShowDialog();
                    break;

                case "de":
                    var typePorteOutils = resGrid11.SelectedItem as TypePorteOutils;
                    TypePorteOutil detailTypePorteOutil = new TypePorteOutil(typePorteOutils);
                    detailTypePorteOutil.ShowDialog();
                    break;

                case "d'emplacements":
                    var typeEmplacements = resGrid12.SelectedItem as TypeEmplacements;
                    TypeEmplacement detailTypeEmplacement = new TypeEmplacement(typeEmplacements);
                    detailTypeEmplacement.ShowDialog();
                    break;

                case "d'outils":
                    var typeOutils = resGrid13.SelectedItem as TypeOutils;
                    TypeOutil detailTypeOutil = new TypeOutil(typeOutils);
                    detailTypeOutil.ShowDialog();
                    break;
            }
        }

        private void lstMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            btnDetail.IsEnabled = false;

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
            btnDetail.IsEnabled = false;

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
            btnDetail.IsEnabled = false;
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
                resGrid1.ItemsSource = listCol.Where(o => o.idTypeAttachement.Contains(nomFourni));
                resGrid2.ItemsSource = listOutil.Where(o => o.nom.Contains(nomFourni));
                resGrid3.ItemsSource = listPorteOutil.Where(o => o.idTypePorteOutil.Contains(nomFourni));
                resGrid4.ItemsSource = listPlaquette.Where(o => o.nom.Contains(nomFourni));
                resGrid5.ItemsSource = listCone.Where(o => o.nom.Contains(nomFourni));
                resGrid6.ItemsSource = listEmplacement.Where(o => o.idTypeEmplacement.Contains(nomFourni));
                //resGrid7.ItemsSource = listExtension.Where(o => o.nom.Contains(nomFourni));
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
            btnDetail.IsEnabled = false;
            string descFournie = champDescription.Text.ToLower();

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

            if (descFournie == "")
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
                if(CheckBoxDesc.IsChecked == true)
                {

                    resGrid1.ItemsSource = listCol.Where(c => c.idEmplacement.ToString().Equals(descFournie) || c.diametreInterieur.Equals(descFournie) 
                    || c.quantite.ToString().Equals(descFournie) || c.image.Equals(descFournie));

                    resGrid2.ItemsSource = listOutil.Where(o => o.idTypeOutil.ToString().Equals(descFournie) || o.idEmplacement.ToString().Equals(descFournie)
                    || o.idPlaquette.ToString().Equals(descFournie) || o.quantite.ToString().Equals(descFournie) || o.diametreUsinage.Equals(descFournie)
                    || o.diametreSerrage.Equals(descFournie) || o.longueurCoupe.Equals(descFournie) || o.longueurTotal.Equals(descFournie)
                    || o.longueurShank.Equals(descFournie) || o.rayonCoin.Equals(descFournie) || o.anglePointe.Equals(descFournie)
                    || o.nombreFlute.ToString().Equals(descFournie) || o.image.Equals(descFournie));

                    resGrid3.ItemsSource = listPorteOutil.Where(po => po.idEmplacement.ToString().Equals(descFournie) || po.quantite.ToString().Equals(descFournie) 
                    || po.image.Equals(descFournie));

                    resGrid4.ItemsSource = listPlaquette.Where(p => p.idEmplacement.ToString().Equals(descFournie) || p.typePlaquette.Equals(descFournie)
                    || p.direction.Equals(descFournie) || p.angle.Equals(descFournie) || p.degagement.Equals(descFournie) || p.grosseur.Equals(descFournie)
                    || p.compagnie.Equals(descFournie) || p.quantite.ToString().Equals(descFournie) || p.codeAlpha.Equals(descFournie) || p.tourFraseuse.Equals(descFournie)
                    || p.image.Equals(descFournie));

                    resGrid5.ItemsSource = listCone.Where(co => co.typeCone.Equals(descFournie) || co.typeMachine.Equals(descFournie));

                    resGrid6.ItemsSource = listEmplacement.Where(em => em.noLocal.Equals(descFournie) || em.idArmoire.Equals(descFournie) 
                    || em.idTiroir.Equals(descFournie) || em.idCasier.Equals(descFournie));

                    resGrid7.ItemsSource = listExtension.Where(ex => ex.idPorteOutil.ToString().Equals(descFournie) || ex.idEmplacement.ToString().Equals(descFournie)
                    || ex.idCollet.ToString().Equals(descFournie) || ex.longueurShank.Equals(descFournie) || ex.diametreShank.Equals(descFournie)
                    || ex.longueurShank.Equals(descFournie) || ex.longueurTotale.Equals(descFournie) || ex.quantite.ToString().Equals(descFournie) 
                    || ex.image.Equals(descFournie));

                    resGrid8.ItemsSource = listMachine.Where(m => m.idPlateauMachine.ToString().Equals(descFournie) || m.nombreOutilMagasin.ToString().Equals(descFournie)
                    || m.precisionMachine.Equals(descFournie) || m.formatCone.Equals(descFournie) || m.nombreOutilPrep.ToString().Equals(descFournie)
                    || m.numeroMachine.ToString().Equals(descFournie) || m.axeXMin.Equals(descFournie) || m.axeXMAX.Equals(descFournie) || m.axeYMin.Equals(descFournie)
                    || m.axeYMAX.Equals(descFournie) || m.axeZMin.Equals(descFournie) || m.axeZMAX.Equals(descFournie));

                    resGrid10.ItemsSource = listTypeAttachement.Where(ta => ta.diametreExterieur.Equals(descFournie));

                    resGrid11.ItemsSource = listTypePorteOutil.Where(tpo => tpo.idCone.ToString().Equals(descFournie) || tpo.idTypeAttachement.ToString().Equals(descFournie));
                }
                else
                {
                    resGrid1.ItemsSource = listCol.Where(c => c.idEmplacement.ToString().Contains(descFournie) || c.diametreInterieur.Contains(descFournie) 
                    || c.quantite.ToString().Contains(descFournie) || c.image.Contains(descFournie));

                    resGrid2.ItemsSource = listOutil.Where(o => o.idTypeOutil.ToString().Contains(descFournie) || o.idEmplacement.ToString().Contains(descFournie)
                    || o.idPlaquette.ToString().Contains(descFournie) || o.quantite.ToString().Contains(descFournie) || o.diametreUsinage.Contains(descFournie)
                    || o.diametreSerrage.Contains(descFournie) || o.longueurCoupe.Contains(descFournie) || o.longueurTotal.Contains(descFournie)
                    || o.longueurShank.Contains(descFournie) || o.rayonCoin.Contains(descFournie) || o.anglePointe.Contains(descFournie)
                    || o.nombreFlute.ToString().Contains(descFournie) || o.image.Contains(descFournie));

                    resGrid3.ItemsSource = listPorteOutil.Where(po => po.idEmplacement.ToString().Contains(descFournie) || po.quantite.ToString().Contains(descFournie) 
                    || po.image.Contains(descFournie));

                    resGrid4.ItemsSource = listPlaquette.Where(p => p.idEmplacement.ToString().Contains(descFournie) || p.typePlaquette.Contains(descFournie)
                    || p.direction.Contains(descFournie) || p.angle.Contains(descFournie) || p.degagement.Contains(descFournie) || p.grosseur.Contains(descFournie)
                    || p.compagnie.Contains(descFournie) || p.quantite.ToString().Contains(descFournie) || p.codeAlpha.Contains(descFournie) || p.tourFraseuse.Contains(descFournie)
                    || p.image.Contains(descFournie));

                    resGrid5.ItemsSource = listCone.Where(co => co.typeCone.Contains(descFournie) || co.typeMachine.Contains(descFournie));

                    resGrid6.ItemsSource = listEmplacement.Where(em => em.noLocal.Contains(descFournie) || em.idArmoire.Contains(descFournie) 
                    || em.idTiroir.Contains(descFournie) || em.idCasier.Contains(descFournie));

                    resGrid7.ItemsSource = listExtension.Where(ex => ex.idPorteOutil.ToString().Contains(descFournie) || ex.idEmplacement.ToString().Contains(descFournie)
                    || ex.idCollet.ToString().Contains(descFournie) || ex.longueurShank.Contains(descFournie) || ex.diametreShank.Contains(descFournie)
                    || ex.longueurShank.Contains(descFournie) || ex.longueurTotale.Contains(descFournie) || ex.quantite.ToString().Contains(descFournie)
                    || ex.image.Contains(descFournie));

                    resGrid8.ItemsSource = listMachine.Where(m => m.idPlateauMachine.ToString().Contains(descFournie) || m.nombreOutilMagasin.ToString().Contains(descFournie)
                    || m.precisionMachine.Contains(descFournie) || m.formatCone.Contains(descFournie) || m.nombreOutilPrep.ToString().Contains(descFournie)
                    || m.numeroMachine.ToString().Contains(descFournie) || m.axeXMin.Contains(descFournie) || m.axeXMAX.Contains(descFournie) || m.axeYMin.Contains(descFournie)
                    || m.axeYMAX.Contains(descFournie) || m.axeZMin.Contains(descFournie) || m.axeZMAX.Contains(descFournie));

                    resGrid10.ItemsSource = listTypeAttachement.Where(ta => ta.diametreExterieur.Contains(descFournie));

                    resGrid11.ItemsSource = listTypePorteOutil.Where(tpo => tpo.idCone.ToString().Contains(descFournie) || tpo.idTypeAttachement.ToString().Contains(descFournie));
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            btnDetail.IsEnabled = false;
            string appPath = System.IO.Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath);
            String fileName = appPath + "\\guideUtilisateur.pdf";
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            process.StartInfo.FileName = fileName;
            process.Start();
            process.WaitForExit();
        }
    }
}
