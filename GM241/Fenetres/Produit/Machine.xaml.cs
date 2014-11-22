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
    /// Logique d'interaction pour Machine.xaml
    /// </summary>
    public partial class Machine : Window
    {
        private void viderChamps()
        {
            listePlateauMachine.SelectedIndex = 0;
            nom.Text = "";
            nbrOutil.Text = "0";
            precision.Text = "";
            formatCone.Text = "";
            nbrOutilPrep.Text = "0";
            noMachine.Text = "0";
            axeXMin.Text = "";
            axeXMax.Text = "";
            axeYMin.Text = "";
            axeYMax.Text = "";
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        public Machine()
        {
            InitializeComponent();

            // Charger la liste des plateaux machine
            List<PlateauMachines> lstPlateauMachines = PlateauMachines.chargerlstPlateauMachines();

            foreach (PlateauMachines tPm in lstPlateauMachines)
                listePlateauMachine.Items.Add(tPm.idPlateauMachine + " - " + tPm.nom);

            viderChamps();
        }



        private void axeZOui_Checked(object sender, RoutedEventArgs e)
        {
            axeZMin.IsEnabled = true;
            axeZMax.IsEnabled = true;
        }

        private void axeZNon_Checked(object sender, RoutedEventArgs e)
        {
            axeZMin.IsEnabled = false;
            axeZMax.IsEnabled = false;
            axeZMin.Text = "";
            axeZMax.Text = "";
        }

        private void btnAjouter_Click(object sender, RoutedEventArgs e)
        {
            bool insertValide = true;
            bool axeZ = false;
            char[] splitchar = { ' ' };
            string str = null;
            string[] idPlateauMachine = null;
            Machines machines = new Machines();

            // Prendre le id du type d'emplacement
            str = listePlateauMachine.Text;
            idPlateauMachine = str.Split(splitchar);

            // Vérifier si les champs sont vide ? 
            if (nom.Text == "")
                insertValide = false;

            if (nbrOutil.Text == "")
                insertValide = false;

            if (precision.Text == "")
                insertValide = false;

            if (formatCone.Text == "")
                insertValide = false;

            if (nbrOutilPrep.Text == "")
                insertValide = false;

            if (noMachine.Text == "")
                insertValide = false;

            if (axeXMin.Text == "")
                insertValide = false;

            if (axeXMax.Text == "")
                insertValide = false;

            if (axeYMin.Text == "")
                insertValide = false;

            if (axeYMax.Text == "")
                insertValide = false;

            if(axeZOui.IsChecked == true)
            {
                axeZ = true;

                if (axeZMin.Text == "")
                {
                    insertValide = false;
                }

                if (axeZMax.Text == "")
                {
                    insertValide = false;
                }
            }

            if (insertValide == true)
            {
                if (machines.ajoutMachine(Convert.ToInt32(idPlateauMachine[0]), nom.Text, Convert.ToInt32(nbrOutil.Text), precision.Text, formatCone.Text, Convert.ToInt32(nbrOutilPrep.Text), Convert.ToInt32(noMachine.Text), axeXMin.Text, axeXMax.Text, axeYMin.Text, axeYMax.Text, Convert.ToBoolean(axeZ), axeZMin.Text, axeZMax.Text) == true)
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
