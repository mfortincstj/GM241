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
        private void viderChamps()
        {
            listePorteOutil.SelectedIndex = 0;
            listeEmplacement.SelectedIndex = 0;
            listeCollet.SelectedIndex = 0;
            longShank.Text = "";
            diamShank.Text = "";
            longTotal.Text = "";
            quantite.Text = "0";
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

            // Charger la liste des types de porte outil
            List<TypePorteOutils> lstTypePorteOutils = TypePorteOutils.chargerlstTypePorteOutils();

            foreach (TypePorteOutils tPo in lstTypePorteOutils)
                listePorteOutil.Items.Add(tPo.idTypePorteOutil + " - " + tPo.nom);

            /*
            // Charger la liste des types d'emplacements
            List<TypeEmplacements> lstTypeEmpl = TypeEmplacements.chargerlstTypeEmplacements();

            foreach (TypeEmplacements tP in lstTypeEmpl)
                listeEmplacement.Items.Add(tP.idTypeEmplacement + " - " + tP.nom);
            */

            // Charger la liste des type d'attachements
            List<TypeAttachements> lstAttachements = TypeAttachements.chargerlstTypeAttachements();

            foreach (TypeAttachements tA in lstAttachements)
                listeCollet.Items.Add(tA.idTypeAttachements + " - " + tA.nom);

            viderChamps();
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

            str2 = listeEmplacement.Text;
            idEmp = str.Split(splitchar);

            str3 = listeCollet.Text;
            idCollet = str.Split(splitchar);

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
                    viderChamps();
                }
            }
            else
                MessageBox.Show("Champs incomplet", "Attention !", MessageBoxButton.OK, MessageBoxImage.Warning, MessageBoxResult.OK);
        }
    }
}
