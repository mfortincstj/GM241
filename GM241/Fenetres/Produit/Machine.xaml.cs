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

namespace GM241.Fenetres.Produit
{
    /// <summary>
    /// Logique d'interaction pour Machine.xaml
    /// </summary>
    public partial class Machine : Window
    {
        public Machine()
        {
            InitializeComponent();
        }

        private void axeZOui_Checked(object sender, RoutedEventArgs e)
        {
            boxAxeZMin.IsEnabled = true;
            boxAxeZMax.IsEnabled = true;
        }

        private void axeZNon_Checked(object sender, RoutedEventArgs e)
        {
            boxAxeZMin.IsEnabled = false;
            boxAxeZMax.IsEnabled = false;
            boxAxeZMin.Text = "";
            boxAxeZMax.Text = "";
        }
    }
}
