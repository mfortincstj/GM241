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
        int idItemPresent;

        private void viderChamps()
        {
            nom.Text = "";
            typeCone.Text = "";
            typeMachine.Text = "";
        }

        public Cone()
        {
            InitializeComponent();
            conserveChamps.ToolTip = "Empêche la suppression des chapms lors de l'ajout";

            viderChamps();
        }

        public Cone(Cones monCone)
        {
            InitializeComponent();
            idItemPresent = monCone.idCone;

            nom.Text = monCone.nom;
            typeCone.Text = monCone.typeCone;
            typeMachine.Text = monCone.typeMachine;

            btnSupprimer.IsEnabled = true;
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

                    if (conserveChamps.IsChecked == false)
                        viderChamps();
                }
            }
            else
                MessageBox.Show("Champ(s) incomplet(s)", "Attention !", MessageBoxButton.OK, MessageBoxImage.Warning, MessageBoxResult.OK);
        }

        private void btnSupprimer_Click_1(object sender, RoutedEventArgs e)
        {
            Cones cone = new Cones();

            if (MessageBox.Show("Êtes-vous sûr de vouloir supprimer cet élément ?", "Attention !", MessageBoxButton.YesNoCancel, MessageBoxImage.Question, MessageBoxResult.Cancel) == MessageBoxResult.Yes)
            {
                if (cone.deleteCone(idItemPresent) == true)
                {
                    MessageBox.Show("Suppression réussie");
                    this.Close();
                }
            }
        }
    }
}
