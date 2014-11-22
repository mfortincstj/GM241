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

            viderChamps();
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
                    viderChamps();
                }
            }
            else
                MessageBox.Show("Champs incomplet", "Attention !", MessageBoxButton.OK, MessageBoxImage.Warning, MessageBoxResult.OK);
        }
    }
}
