﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Logique d'interaction pour ajoutPorteOutil.xaml
    /// </summary>
    public partial class PorteOutil : Window
    {
        int idItemPresent;

        private void viderChamps()
        {
            listeTypePorteOutil.SelectedIndex = 0;
            listeNoLocal.SelectedIndex = 0;
            //listeNoArmoire.SelectedIndex = 0;
            //listeNoTiroir.SelectedIndex = 0;
            //listeNoCasier.SelectedIndex = 0;
            quantite.Text = "";
            image.Text = "";
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        public PorteOutil()
        {
            InitializeComponent();
            conserveChamps.ToolTip = "Empêche la suppression des chapms lors de l'ajout";

            listeNoArmoire.Items.Add("0 - Aucun");
            listeNoTiroir.Items.Add("0 - Aucun");
            listeNoCasier.Items.Add("0 - Aucun");

            List<TypePorteOutils> lstTypePorteOutils = TypePorteOutils.chargerlstTypePorteOutils();

            foreach (TypePorteOutils tPo in lstTypePorteOutils)
                listeTypePorteOutil.Items.Add(tPo.idTypePorteOutil + " - " + tPo.nom);
            
            /*
            // Charger les emplacements
            List<Armoires> lstArmoires = Armoires.chargerlstArmoires();
            List<Tiroirs> lstTiroirs = Tiroirs.chargerlstTiroirs();
            List<Casiers> lstCasiers = Casiers.chargerlstCasiers();

            foreach (Armoires a in lstArmoires)
                listeNoArmoire.Items.Add(a.idArmoire + " - " + a.noArmoire);

            foreach (Tiroirs t in lstTiroirs)
                listeNoTiroir.Items.Add(t.idTiroir + " - " + t.noTiroir);

            foreach (Casiers c in lstCasiers)
                listeNoCasier.Items.Add(c.idCasier + " - " + c.noCasier);
            */

            // Charger la liste des types d'emplacements
            List<Emplacements> lstEmplacements = Emplacements.chargerlstEmplacements();

            foreach (Emplacements e in lstEmplacements)
                listeNoLocal.Items.Add(e.idTypeEmplacement + " - " + e.noLocal + " - " + e.idArmoire + " - " + e.idCasier + " - " + e.idTiroir);

            viderChamps();
        }

        public PorteOutil(PorteOutils monPorteOutil)
        {
            InitializeComponent();
            idItemPresent = monPorteOutil.idPorteOutil;

            List<TypePorteOutils> lstTypePorteOutils = TypePorteOutils.chargerlstTypePorteOutils();

            foreach (TypePorteOutils tPo in lstTypePorteOutils)
            {
                if (monPorteOutil.idTypePorteOutil == tPo.nom)
                    listeTypePorteOutil.SelectedIndex = tPo.idTypePorteOutil - 1;
                else
                    listeTypePorteOutil.SelectedIndex = 0;

                listeTypePorteOutil.Items.Add(tPo.idTypePorteOutil + " - " + tPo.nom);
            }

            List<Emplacements> lstEmplacements = Emplacements.chargerlstEmplacements();

            foreach (Emplacements e in lstEmplacements)
                listeNoLocal.Items.Add(e.idTypeEmplacement + " - " + e.noLocal + " - " + e.idArmoire + " - " + e.idCasier + " - " + e.idTiroir);

            listeNoLocal.SelectedIndex = 0;

            quantite.Text = monPorteOutil.quantite.ToString();
            image.Text = monPorteOutil.image;

            btnSupprimer.IsEnabled = true;
        }

        private void btnAjout_Click(object sender, RoutedEventArgs e)
        {
            bool insertValide = true;
            char[] splitchar = { ' ' };
            string str = null;
            string str2 = null;
            string[] idPorteOul = null;
            string[] idEmpl = null;
            PorteOutils porteOutils = new PorteOutils();

            // Prendre le id du type d'emplacement
            str = listeTypePorteOutil.Text;
            idPorteOul = str.Split(splitchar);

            // Prendre le id du type d'attachement
            str2 = listeNoLocal.Text;
            idEmpl = str2.Split(splitchar);

            // Vérifier si les champs sont vide ? 
            if (quantite.Text == "")
                insertValide = false;

            if (image.Text == "")
                insertValide = false;

            if (insertValide == true)
            {
                if (porteOutils.ajoutPorteOutil(Convert.ToInt32(idPorteOul[0]), 1, Convert.ToInt32(quantite.Text), image.Text) == true)
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
            PorteOutils porteOutil = new PorteOutils();

            if (MessageBox.Show("Êtes-vous sûr de vouloir supprimer cet élément ?", "Attention !", MessageBoxButton.YesNoCancel, MessageBoxImage.Question, MessageBoxResult.Cancel) == MessageBoxResult.Yes)
            {
                if (porteOutil.deletePorteOutil(idItemPresent) == true)
                {
                    MessageBox.Show("Suppression réussie");
                    this.Close();
                }
            }
        }
    }
}
