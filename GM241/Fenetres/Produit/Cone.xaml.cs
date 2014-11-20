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
    /// Logique d'interaction pour Cone.xaml
    /// </summary>
    public partial class Cone : Window
    {
        private void viderChamps()
        {
            nom.Text = "";
            typeCone.Text = "";
            typeMachine.Text = "";
        }

        public Cone()
        {
            InitializeComponent();

            viderChamps();
        }

        private void btnAjouter_Click(object sender, RoutedEventArgs e)
        {
            bool insertValide = true;
            Cones cones = new Cones();

            // Vérifier si les champs sont vide ? 
            if (nom.Text == "")
                insertValide = false;

            if (typeCone.Text == "")
                insertValide = false;

            if (typeMachine.Text == "")
                insertValide = false;

            if (insertValide == true)
            {
                if (cones.ajoutCone(nom.Text, typeCone.Text, typeMachine.Text) == true)
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
