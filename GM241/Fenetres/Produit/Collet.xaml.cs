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
    /// Logique d'interaction pour ajoutCollet.xaml
    /// </summary>
    public partial class Collet : Window
    {
        public Collet()
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
        }

        private void btnAjout_Click(object sender, RoutedEventArgs e)
        {
            // Appel à une méthode (voir dans une classe collet ou dans une classe requêteBD ?) qui va permettre d'ajouter un collet dans la BD

        }

        private void bynAnnule_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Être vous sur de vouloir annuler cette ajout ?", "Attention !", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No) == MessageBoxResult.Yes)
                this.Close();
        }
    }
}
