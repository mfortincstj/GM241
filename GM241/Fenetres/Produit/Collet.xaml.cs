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
using System.Text.RegularExpressions;

namespace GM241.Fenetres.Produit
{
    /// <summary>
    /// Logique d'interaction pour ajoutCollet.xaml
    /// </summary>
    public partial class Collet : Window
    {
        private void viderChamps()
        {
            listeTypeEmplacement.SelectedIndex = 0;
            listeTypeAttachement.SelectedIndex = 0;
            diametreInt.Text = "";
            quant.Text = "0";
            img.Text = "";
        }

        public Collet()
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;

            int iCompteur = 0;
            
            // Charger la liste des emplacements
            List<string> lstNom = TypeEmplacements.chargerNom();
            List<Emplacements> lstEmpl = Emplacements.chargerlstEmplacements();

            foreach (Emplacements e in lstEmpl)
                listeTypeEmplacement.Items.Add(e.idTypeEmplacement + " - " + lstNom[iCompteur++]);

            // Charger la liste des attachements
            List<TypeAttachements> lstAttachements = TypeAttachements.chargerlstTypeAttachements();

            foreach (TypeAttachements tA in lstAttachements)
                listeTypeAttachement.Items.Add(tA.idTypeAttachements + " - " + tA.nom);

            viderChamps();
        }

        private void btnAjout_Click(object sender, RoutedEventArgs e)
        {
            bool insertValide = true;
            char[] splitchar = {' '};
            string str = null;
            string str2 = null;
            string[] idEmp = null;
            string[] idTypeAtt = null;
            Collets collets = new Collets();

            // Prendre le id de l'attachement
            str = listeTypeEmplacement.Text;
            idEmp = str.Split(splitchar);

            // Prendre le id du type d'attachement
            str2 = listeTypeEmplacement.Text;
            idTypeAtt = str.Split(splitchar);

            // Vérifier si les champs sont vide ? 
            if(diametreInt.Text == "")
                insertValide = false;

            if (img.Text == "")
                insertValide = false;

            quant.Text = Regex.Replace(quant.Text, "[^0-9.]", "");


            if (insertValide == true)
            {
                if (collets.ajoutCollet(Convert.ToInt32(idEmp[0]), Convert.ToInt32(idTypeAtt[0]), diametreInt.Text, Convert.ToInt32(quant.Text), img.Text) == true)
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
