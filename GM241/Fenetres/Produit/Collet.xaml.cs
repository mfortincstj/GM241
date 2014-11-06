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
    /// Logique d'interaction pour ajoutCollet.xaml
    /// </summary>
    public partial class Collet : Window
    {
        public Collet()
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;

            // Charger la liste des emplacements
            List<Emplacements> listEmplacements = Emplacements.chargerlstEmplacements();
            //foreach (Emplacements emp in listEmplacements)
                //listeEmplacement.Items.Add(emp.idTypeEmplacement);
        }

        private void btnAjout_Click(object sender, RoutedEventArgs e)
        {
            //Collets collets = new Collets();

            //collets.ajoutCollet(Convert.ToInt32(listeEmplacement.Text), Convert.ToInt32(listeTypeAttachement.Text), 
              //                  boxDiametre.Text, Convert.ToInt32(boxQuantite.Text), boxQuantite.Text);
        }

        private void btnAnnule_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Êtes-vous sûr de vouloir annuler cet ajout?", "Attention!", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No) == MessageBoxResult.Yes)
                this.Close();
        }
    }
}
