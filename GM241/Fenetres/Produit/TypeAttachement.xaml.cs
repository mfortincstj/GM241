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
    /// Logique d'interaction pour TypeAttachement.xaml
    /// </summary>
    public partial class TypeAttachement : Window
    {
        int idItemPresent;

        private void viderChamps()
        {
            nom.Text = "";
            diametreExt.Text = "";
        }

        public TypeAttachement()
        {
            InitializeComponent();

            viderChamps();
        }

        public TypeAttachement(TypeAttachements monTypeAttachement)
        {
            InitializeComponent();
            idItemPresent = monTypeAttachement.idTypeAttachement;

            nom.Text = monTypeAttachement.nom;
            diametreExt.Text = monTypeAttachement.diametreExterieur;

            btnAjouter.IsEnabled = false;
            btnSupprimer.IsEnabled = true;
        }

        private void btnAjouter_Click(object sender, RoutedEventArgs e)
        {
            bool insertValide = true;

            TypeAttachements typeAttachements = new TypeAttachements();

            // Vérifier si les champs sont vide ? 
            if (nom.Text == "")
                insertValide = false;

            if (diametreExt.Text == "")
                insertValide = false;

            if (insertValide == true)
            {
                if (typeAttachements.ajoutTypeAttachement(nom.Text, diametreExt.Text) == true)
                {
                    MessageBox.Show("Insertion réussie");
                    viderChamps();
                }
            }
            else
                MessageBox.Show("Champ(s) incomplet(s)", "Attention !", MessageBoxButton.OK, MessageBoxImage.Warning, MessageBoxResult.OK);
        }

        private void btnSupprimer_Click_1(object sender, RoutedEventArgs e)
        {
            TypeAttachements typeAttachement = new TypeAttachements();

            if (MessageBox.Show("Êtes-vous sûr de vouloir supprimer cet élément ?", "Attention !", MessageBoxButton.YesNoCancel, MessageBoxImage.Question, MessageBoxResult.Cancel) == MessageBoxResult.Yes)
            {
                typeAttachement.deleteTypeAttachement(idItemPresent);
                MessageBox.Show("Suppression réussie");
                this.Close();
            }
        }
    }
}
