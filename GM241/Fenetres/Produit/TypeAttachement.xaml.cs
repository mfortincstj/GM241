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
                MessageBox.Show("Champs incomplet", "Attention !", MessageBoxButton.OK, MessageBoxImage.Warning, MessageBoxResult.OK);
        }
    }
}
