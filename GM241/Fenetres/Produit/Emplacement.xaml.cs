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
    /// Logique d'interaction pour Emplacements.xaml
    /// </summary>
    public partial class Emplacement : Window
    {
        private void viderChamps()
        {
            listeTypeEmplacement.SelectedIndex = 0;
            noLocal.Text = "";
            noArmoire.Text = "";
            noTitoir.Text = "";
            noCasier.Text = "";
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        public Emplacement()
        {
            InitializeComponent();

            // Charger la liste des types d'emplacements
            List<TypeEmplacements> lstTypeEmpl = TypeEmplacements.chargerlstTypeEmplacements();

            foreach (TypeEmplacements tP in lstTypeEmpl)
                listeTypeEmplacement.Items.Add(tP.idTypeEmplacement + " - " + tP.nom);

            viderChamps();
        }

        private void btnAjouter_Click(object sender, RoutedEventArgs e)
        {
            bool insertValide = true;
            char[] splitchar = {' '};
            string str = null;
            string[] idEmp = null;
            Emplacements empl = new Emplacements();

            // Prendre le id du type d'emplacement
            str = listeTypeEmplacement.Text;
            idEmp = str.Split(splitchar);

            // Vérifier si les champs sont vide ? 
            if(noLocal.Text == "")
                insertValide = false;

            if (insertValide == true)
            {
                if (empl.ajoutEmplacement(Convert.ToInt32(idEmp[0]), noLocal.Text, noArmoire.Text, noTitoir.Text, noCasier.Text) == true)
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
