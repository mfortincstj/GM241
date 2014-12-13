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
using GM241.Fenetres.Produit;

namespace GM241.Fenetres.Menu
{
    /// <summary>
    /// Logique d'interaction pour menuAdmin.xaml
    /// </summary>
    public partial class MenuAdmin : Window
    {
        private string usagerConnecte = "";
        private bool estAdmin = false;

        public MenuAdmin(bool admin, string user)
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;

            // Initialiser la liste des produits
            lstProduits.Items.Add("Sélection"); lstProduits.Items.Add("Machines"); lstProduits.Items.Add("Plateaux pour machines");
            lstProduits.Items.Add("Outils"); lstProduits.Items.Add("Types d'outils"); lstProduits.Items.Add("Extensions");
            lstProduits.Items.Add("Porte-outils"); lstProduits.Items.Add("Collets"); lstProduits.Items.Add("Types de Porte-outils");
            lstProduits.Items.Add("Cônes"); lstProduits.Items.Add("Plaquettes"); lstProduits.Items.Add("Emplacements");
            lstProduits.Items.Add("Types d'emplacements"); lstProduits.Items.Add("Types d'attachements");
            lstProduits.SelectedIndex = 0;

            estAdmin = admin;
            usagerConnecte = user;
        }

        private void btnFermer_Click(object sender, RoutedEventArgs e)
        {
            Inventaire.Inventaire inventaire = new Inventaire.Inventaire(estAdmin, usagerConnecte);
            inventaire.Show();
            this.Close();   // Fermeture du login
        }

        private void lstProduits_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (lstProduits.SelectedIndex)
            {
                // Rien de sélectionné
                case 0:
                    vue.Children.Clear();
                break;

                // Machines
                case 1:
                    vue.Children.Clear();
                    Machine fenetreMachine = new Machine();
                    object childContentMachine = fenetreMachine.Content;
                    fenetreMachine.Content = null;
                    vue.Children.Add(childContentMachine as UIElement);
                break;

                // Plateau pour machines
                case 2:
                    vue.Children.Clear();
                    PlateauMachine fenetrePlateauMachine = new PlateauMachine();
                    object childContentPlateauMachine = fenetrePlateauMachine.Content;
                    fenetrePlateauMachine.Content = null;
                    vue.Children.Add(childContentPlateauMachine as UIElement);
                break;

                // Outils
                case 3:
                    vue.Children.Clear();
                    Outil fenetreOutil = new Outil();
                    object childContentOutil = fenetreOutil.Content;
                    fenetreOutil.Content = null;
                    vue.Children.Add(childContentOutil as UIElement);
                break;

                // Type d'outils
                case 4:
                    vue.Children.Clear();
                    TypeOutil fenetreTypeOutil = new TypeOutil();
                    object childContentTypeOutil = fenetreTypeOutil.Content;
                    fenetreTypeOutil.Content = null;
                    vue.Children.Add(childContentTypeOutil as UIElement);
                break;

                // Extensions
                case 5:
                    vue.Children.Clear();
                    Extension fenetreExtension = new Extension();
                    object childContentExtension = fenetreExtension.Content;
                    fenetreExtension.Content = null;
                    vue.Children.Add(childContentExtension as UIElement);
                break;

                // Porte outils
                case 6:
                    vue.Children.Clear();
                    PorteOutil fenetrePorteOutil = new PorteOutil();
                    object childContentPorteOutil = fenetrePorteOutil.Content;
                    fenetrePorteOutil.Content = null;
                    vue.Children.Add(childContentPorteOutil as UIElement);
                break;

                // Collets
                case 7:
                    vue.Children.Clear();
                    Collet fenetreCollet = new Collet();
                    object childContentCollet = fenetreCollet.Content;
                    fenetreCollet.Content = null;
                    vue.Children.Add(childContentCollet as UIElement);
                break;

                // Type de pourte outils
                case 8:
                    vue.Children.Clear();
                    TypePorteOutil fenetreTypePorteOutil = new TypePorteOutil();
                    object childContentTypePorteOutil = fenetreTypePorteOutil.Content;
                    fenetreTypePorteOutil.Content = null;
                    vue.Children.Add(childContentTypePorteOutil as UIElement);
                break;

                // Cones
                case 9:
                    vue.Children.Clear();
                    Cone fenetreCone = new Cone();
                    object childContentCone = fenetreCone.Content;
                    fenetreCone.Content = null;
                    vue.Children.Add(childContentCone as UIElement);
                break;

                // Plaquettes
                case 10:
                    vue.Children.Clear();
                    Plaquette fenetrePlaquette = new Plaquette();
                    object childContentPlaquette = fenetrePlaquette.Content;
                    fenetrePlaquette.Content = null;
                    vue.Children.Add(childContentPlaquette as UIElement);
                break;

                // Emplacements
                case 11:
                    vue.Children.Clear();
                    Emplacement fenetreEmplacement = new Emplacement();
                    object childContentEmplacement = fenetreEmplacement.Content;
                    fenetreEmplacement.Content = null;
                    vue.Children.Add(childContentEmplacement as UIElement);
                break;

                // Type d'emplacements
                case 12:
                    vue.Children.Clear();
                    TypeEmplacement fenetreTypeEmplacement = new TypeEmplacement();
                    object childContentTypeEmplacement = fenetreTypeEmplacement.Content;
                    fenetreTypeEmplacement.Content = null;
                    vue.Children.Add(childContentTypeEmplacement as UIElement);
                break;

                // Type d'attachements
                case 13:
                    vue.Children.Clear();
                    TypeAttachement fenetreTypeAttachement = new TypeAttachement();
                    object childContentTypeAttachement = fenetreTypeAttachement.Content;
                    fenetreTypeAttachement.Content = null;
                    vue.Children.Add(childContentTypeAttachement as UIElement);
                break;
            }
        }

        private void btnAideAdmin_Click(object sender, RoutedEventArgs e)
        {
            string appPath = System.IO.Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath);
            String fileName = appPath + "\\Guide_utilisateur\\menuAdmin.pdf";
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            process.StartInfo.FileName = fileName;
            process.Start();
        }
    }
}
