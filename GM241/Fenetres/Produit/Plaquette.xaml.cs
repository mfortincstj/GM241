using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace GM241.Fenetres.Produit
{
    /// <summary>
    /// Logique d'interaction pour ajoutPlaquette.xaml
    /// </summary>
    public partial class Plaquette : Window
    {
        int idItemPresent;

        private void viderChamps()
        {
            listeNoLocal.SelectedIndex = 0;
            listeNoArmoire.SelectedIndex = 0;
            listeNoTiroir.SelectedIndex = 0;
            listeNoCasier.SelectedIndex = 0;
            nom.Text = "";
            typePlaquette.Text = "";
            direction.Text = "";
            angle.Text = "";
            degagement.Text = "";
            grosseur.Text = "";
            compagnie.Text = "";
            quantite.Text = "";
            codeAlpha.Text = "";
            image.Text = "";
            tourFraiseuse.Text = "";
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        public Plaquette()
        {
            InitializeComponent();
            conserveChamps.ToolTip = "Empêche la suppression des chapms lors de l'ajout";
            quantite.ToolTip = "Ce champ n'accepte que les chiffres";

            listeNoArmoire.Items.Add("0 - Aucun");
            listeNoTiroir.Items.Add("0 - Aucun");
            listeNoCasier.Items.Add("0 - Aucun");

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
                listeNoLocal.Items.Add(e.idTypeEmplacement + " - " + e.noLocal + " - " + e.idArmoire + " - " + e.idCasier + " - " + e.idTiroir);

            viderChamps();
        }

        public Plaquette(Plaquettes maPlaquette)
        {
            InitializeComponent();
            idItemPresent = maPlaquette.idPlaquette;

            List<Emplacements> lstEmplacements = Emplacements.chargerlstEmplacements();
            foreach (Emplacements e in lstEmplacements)
                listeNoLocal.Items.Add(e.idTypeEmplacement + " - " + e.noLocal + " - " + e.idArmoire + " - " + e.idCasier + " - " + e.idTiroir);

            listeNoLocal.SelectedIndex = 0;

            nom.Text = maPlaquette.nom;
            typePlaquette.Text = maPlaquette.typePlaquette;
            direction.Text = maPlaquette.direction;
            angle.Text = maPlaquette.angle;
            degagement.Text = maPlaquette.degagement;
            grosseur.Text = maPlaquette.grosseur;
            compagnie.Text = maPlaquette.compagnie;
            quantite.Text = maPlaquette.quantite.ToString();
            codeAlpha.Text = maPlaquette.codeAlpha;
            image.Text = maPlaquette.image;
            tourFraiseuse.Text = maPlaquette.tourFraseuse;

            btnSupprimer.IsEnabled = true;
        }

        private void btnAjout_Click(object sender, RoutedEventArgs e)
        {
            bool insertValide = true;
            bool outilDisponible = false;
            bool uniteEnPouce = false;
            char[] splitchar = { ' ' };
            string str = null;
            string[] idTypeEmplacement = null;
            Plaquettes plaquettes = new Plaquettes();

            str = listeNoLocal.Text;
            idTypeEmplacement = str.Split(splitchar);

            if (nom.Text == "")
                insertValide = false;

            if (typePlaquette.Text == "")
                insertValide = false;

            if (direction.Text == "")
                insertValide = false;

            if (angle.Text == "")
                insertValide = false;

            if (degagement.Text == "")
                insertValide = false;

            if (grosseur.Text == "")
                insertValide = false;

            if (compagnie.Text == "")
                insertValide = false;

            if (quantite.Text == "")
                insertValide = false;

            if (codeAlpha.Text == "")
                insertValide = false;

            if (tourFraiseuse.Text == "")
                insertValide = false;

            if (image.Text == "")
                insertValide = false;

            if (dispoOui.IsChecked == true)
            {
                outilDisponible = true;
            }

            if (uniteOui.IsChecked == true)
            {
                uniteEnPouce = true;
            }

            if (insertValide == true)
            {
                if (plaquettes.ajoutPlaquette(1, nom.Text, typePlaquette.Text, direction.Text, angle.Text, degagement.Text, grosseur.Text, compagnie.Text, Convert.ToInt32(quantite.Text), outilDisponible, codeAlpha.Text, tourFraiseuse.Text, uniteEnPouce, image.Text) == true)
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
            Plaquettes plaquette = new Plaquettes();

            if (MessageBox.Show("Êtes-vous sûr de vouloir supprimer cet élément ?", "Attention !", MessageBoxButton.YesNoCancel, MessageBoxImage.Question, MessageBoxResult.Cancel) == MessageBoxResult.Yes)
            {
                if (plaquette.deletePlaquette(idItemPresent) == true)
                {
                    MessageBox.Show("Suppression réussie");
                    this.Close();
                }
            }
        }
    }
}
