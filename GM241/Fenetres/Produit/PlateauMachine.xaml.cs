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

namespace GM241.Fenetres.Produit
{
    /// <summary>
    /// Logique d'interaction pour PlateauMachine.xaml
    /// </summary>
    public partial class PlateauMachine : Window
    {
        int idItemPresent;

        private void viderChamps()
        {
            nom.Text = "";
            axeSupAOui.IsChecked = false;
            axeSupANon.IsChecked = true;
            axeSupBOui.IsChecked = false;
            axeSupBNon.IsChecked = true;
        }

        public PlateauMachine()
        {
            InitializeComponent();
            conserveChamps.ToolTip = "Empêche la suppression des chapms lors de l'ajout";

            viderChamps();
        }

        public PlateauMachine(PlateauMachines monPlateauMachine)
        {
            InitializeComponent();
            idItemPresent = monPlateauMachine.idPlateauMachine;

            nom.Text = monPlateauMachine.nom;

            if (monPlateauMachine.axeSuppA == true)
            {
                axeSupAOui.IsChecked = true;
                axeSupANon.IsChecked = false;
            }
            else
            {
                axeSupAOui.IsChecked = false;
                axeSupANon.IsChecked = true;
            }

            if (monPlateauMachine.axeSuppB == true)
            {
                axeSupBOui.IsChecked = true;
                axeSupBNon.IsChecked = false;
            }
            else
            {
                axeSupBOui.IsChecked = false;
                axeSupBNon.IsChecked = true;
            }

            btnSupprimer.IsEnabled = true;

        }

        private void btnAjouter_Click(object sender, RoutedEventArgs e)
        {
            bool insertValide = true;
            bool axeSupA = false;
            bool axeSupB = false;
            PlateauMachines plateauMachines = new PlateauMachines();

            if (nom.Text == "")
                insertValide = false;

            if (axeSupAOui.IsChecked == true)
                axeSupA = true;

            if (axeSupBOui.IsChecked == true)
                axeSupB = true;

            if (insertValide == true)
            {
                if (plateauMachines.ajoutPlateauMachine(nom.Text, axeSupA, axeSupB) == true)
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
            PlateauMachines plateauMachine = new PlateauMachines();

            if (MessageBox.Show("Êtes-vous sûr de vouloir supprimer cet élément ?", "Attention !", MessageBoxButton.YesNoCancel, MessageBoxImage.Question, MessageBoxResult.Cancel) == MessageBoxResult.Yes)
            {
                if (plateauMachine.deletePlateauMachine(idItemPresent) == true)
                {
                    MessageBox.Show("Suppression réussie");
                    this.Close();
                }
            }
        }
    }
}
