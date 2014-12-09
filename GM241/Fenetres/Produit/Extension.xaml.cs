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
using System.Text.RegularExpressions;

namespace GM241.Fenetres.Produit
{
    /// <summary>
    /// Logique d'interaction pour Extension.xaml
    /// </summary>
    public partial class Extension : Window
    {
        int idItemPresent;

        private void viderChamps()
        {
            listePorteOutil.SelectedIndex = 0;
            listeNoLocal.SelectedIndex = 0;
            listeCollet.SelectedIndex = 0;
            listeNoArmoire.SelectedIndex = 0;
            listeNoTiroir.SelectedIndex = 0;
            listeNoCasier.SelectedIndex = 0;
            longShank.Text = "";
            diamShank.Text = "";
            longTotal.Text = "";
            quantite.Text = "";
            img.Text = "";
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        public Extension()
        {
            InitializeComponent();
            conserveChamps.ToolTip = "Empêche la suppression des chapms lors de l'ajout";
            quantite.ToolTip = "Ce champ n'accepte que les chiffres";

            listeNoArmoire.Items.Add("0 - Aucun");
            listeNoTiroir.Items.Add("0 - Aucun");
            listeNoCasier.Items.Add("0 - Aucun");

            // Charger la liste des types de porte outil
            List<TypePorteOutils> lstTypePorteOutils = TypePorteOutils.chargerlstTypePorteOutils();

            foreach (TypePorteOutils tPo in lstTypePorteOutils)
                listePorteOutil.Items.Add(tPo.idTypePorteOutil + " - " + tPo.nom);

            /*
            // Charger la liste des types d'emplacements
            List<Emplacements> lstEmplacements = Emplacements.chargerlstEmplacements();

            foreach (Emplacements e in lstEmplacements)
            {
                listeNoLocal.Items.Add(e.idTypeEmplacement + " - " + e.noLocal);
                listeNoArmoire.Items.Add(e.noArmoire);
                listeNoTiroir.Items.Add(e.noTiroir);
                listeNoCasier.Items.Add(e.noCasier);
            }
            */

            // Chargement temporaire des emplacement *** À changer
            List<Emplacements> lstEmplacements = Emplacements.chargerlstEmplacements();
            foreach (Emplacements e in lstEmplacements)
            {
                listeNoLocal.Items.Add(e.idTypeEmplacement + " - " + e.noLocal + " - " + e.idArmoire + " - " + e.idCasier + " - " + e.idTiroir);
            }

            // Charger la liste des type d'attachements
            List<TypeAttachements> lstAttachements = TypeAttachements.chargerlstTypeAttachements();

            foreach (TypeAttachements tA in lstAttachements)
                listeCollet.Items.Add(tA.idTypeAttachement + " - " + tA.nom);

            viderChamps();
        }

        public Extension(Extensions monExtension)
        {
            InitializeComponent();
            idItemPresent = monExtension.idExtension;

            // Charger la liste des types de porte outil
            List<TypeAttachements> lstTypeAttachements = TypeAttachements.chargerlstTypeAttachements();

            foreach (TypeAttachements ta in lstTypeAttachements)
            {
                if (monExtension.idCollet == ta.nom)
                    listePorteOutil.SelectedIndex = ta.idTypeAttachement - 1;

                listeCollet.Items.Add(ta.idTypeAttachement + " - " + ta.nom);
            }

            // Charger la liste des type d'attachements
            List<TypePorteOutils> lstTypePorteOutils = TypePorteOutils.chargerlstTypePorteOutils();

            foreach (TypePorteOutils tpo in lstTypePorteOutils)
            {
                if (monExtension.idPorteOutil == tpo.nom)
                    listePorteOutil.SelectedIndex = tpo.idTypePorteOutil - 1;

                listePorteOutil.Items.Add(tpo.idTypePorteOutil + " - " + tpo.nom);
            }

            longShank.Text = monExtension.longueurShank;
            diamShank.Text = monExtension.diametreShank;
            longTotal.Text = monExtension.longueurTotale;
            quantite.Text = monExtension.quantite.ToString();
            img.Text = monExtension.image;

            btnSupprimer.IsEnabled = true;
        }

        private void btnAjouter_Click(object sender, RoutedEventArgs e)
        {
            bool insertValide = true;
            char[] splitchar = { ' ' };
            string str = null;
            string str2 = null;
            string str3 = null;
            string[] idPorteOutil = null;
            string[] idEmp = null;
            string[] idCollet = null;

            Extensions extensions = new Extensions();

            str = listePorteOutil.Text;
            idPorteOutil = str.Split(splitchar);

            str2 = listeNoLocal.Text;
            idEmp = str2.Split(splitchar);

            str3 = listeCollet.Text;
            idCollet = str3.Split(splitchar);

            if (longShank.Text == "")
                insertValide = false;

            if (diamShank.Text == "")
                insertValide = false;

            if (longTotal.Text == "")
                insertValide = false;

            if (img.Text == "")
                insertValide = false;

            if (insertValide == true)
            {
                if (extensions.ajoutExtension(Convert.ToInt32(idPorteOutil[0]), Convert.ToInt32(idEmp[0]), Convert.ToInt32(idCollet[0]), longShank.Text, diamShank.Text, longTotal.Text, Convert.ToInt32(quantite.Text), img.Text) == true)
                {
                    MessageBox.Show("Insertion réussie");

                    if (conserveChamps.IsChecked == false)
                        viderChamps();
                }
            }
            else
                MessageBox.Show("Champ(s) incomplet(s)", "Attention !", MessageBoxButton.OK, MessageBoxImage.Warning, MessageBoxResult.OK);
        }

        private void btnSupprimer_Click_1(object sender, RoutedEventArgs e)
        {
            Extensions extension = new Extensions();

            if (MessageBox.Show("Êtes-vous sûr de vouloir supprimer cet élément ?", "Attention !", MessageBoxButton.YesNoCancel, MessageBoxImage.Question, MessageBoxResult.Cancel) == MessageBoxResult.Yes)
            {
                
                if (extension.deleteExtension(idItemPresent) == true)
                {
                    MessageBox.Show("Suppression réussie");
                    this.Close();
                }
            }
        }
    }
}
