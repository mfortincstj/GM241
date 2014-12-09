﻿using System;
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
        int idColletPresent;

        private void viderChamps()
        {
            listeTypeEmplacement.SelectedIndex = 0;
            listeTypeAttachement.SelectedIndex = 0;
            diametreInt.Text = "";
            quant.Text = "";
            img.Text = "";
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        public Collet()
        {
            InitializeComponent();
            conserveChamps.ToolTip = "Empêche la suppression des chapms lors de l'ajout";
            quant.ToolTip = "Ce champ n'accepte que les chiffres";

            // Charger la liste des types d'emplacements
            List<TypeEmplacements> lstTypeEmpl = TypeEmplacements.chargerlstTypeEmplacements();

            foreach (TypeEmplacements tP in lstTypeEmpl)
                listeTypeEmplacement.Items.Add(tP.idTypeEmplacement + " - " + tP.nom);

            // Charger la liste des attachements
            List<TypeAttachements> lstAttachements = TypeAttachements.chargerlstTypeAttachements();

            foreach (TypeAttachements tA in lstAttachements)
                listeTypeAttachement.Items.Add(tA.idTypeAttachement + " - " + tA.nom);

            viderChamps();
        }

        public Collet(Collets monCollet)
        {
            InitializeComponent();
            
            idColletPresent = monCollet.idCollet;

            /*
            // Charger la liste des types d'emplacements
            List<TypeEmplacements> lstTypeEmpl = TypeEmplacements.chargerlstTypeEmplacements();

            foreach (TypeEmplacements tP in lstTypeEmpl)
                listeTypeEmplacement.Items.Add(tP.idTypeEmplacement + " - " + tP.nom);

            listeTypeEmplacement.SelectedIndex = monCollet.idEmplacement - 1;
            */

            if (monCollet.idTypeAttachement == null)
            {
                listeTypeAttachement.Items.Add("0 - Aucun");

                listeTypeAttachement.SelectedIndex = 0;
            }

            // Charger la liste des attachements
            List<TypeAttachements> lstAttachements = TypeAttachements.chargerlstTypeAttachements();

            foreach (TypeAttachements tA in lstAttachements)
            {
                if (monCollet.idTypeAttachement == tA.nom)
                    listeTypeAttachement.SelectedIndex = tA.idTypeAttachement - 1;

                listeTypeAttachement.Items.Add(tA.idTypeAttachement + " - " + tA.nom);
            }

            diametreInt.Text = monCollet.diametreInterieur;
            quant.Text = monCollet.quantite.ToString();
            img.Text = monCollet.image;

            btnSupprimer.IsEnabled = true;
        }

        private void btnAjout_Click(object sender, RoutedEventArgs e)
        {
            bool insertValide = true;
            char[] splitchar = {' '};
            char[] splitchar2 = { ' ' };
            string str = null;
            string str2 = null;
            string[] idEmp = null;
            string[] idTypeAtt = null;
            Collets collets = new Collets();

            // Prendre le id du type d'emplacement
            str = listeTypeEmplacement.Text;
            idEmp = str.Split(splitchar);

            // Prendre le id du type d'attachement
            str2 = listeTypeAttachement.Text;
            idTypeAtt = str2.Split(splitchar2);

            // Vérifier si les champs sont vide ? 
            if(diametreInt.Text == "")
                insertValide = false;

            if (img.Text == "")
                insertValide = false;

            if (quant.Text == "")
                insertValide = false;

            if (insertValide == true)
            {
                if (collets.ajoutCollet(Convert.ToInt32(idEmp[0]), Convert.ToInt32(idTypeAtt[0]), diametreInt.Text, Convert.ToInt32(quant.Text), img.Text) == true)
                {
                    MessageBox.Show("Insertion réussie");

                    if (conserveChamps.IsChecked == false)
                        viderChamps();
                }
            }
            else
                MessageBox.Show("Champ(s) incomplet(s)", "Attention !", MessageBoxButton.OK, MessageBoxImage.Warning, MessageBoxResult.OK);
        }

        private void btnSupprimer_Click(object sender, RoutedEventArgs e)
        {
            Collets collet = new Collets();

            if (MessageBox.Show("Êtes-vous sûr de vouloir supprimer cet élément ?", "Attention !", MessageBoxButton.YesNoCancel, MessageBoxImage.Question, MessageBoxResult.Cancel) == MessageBoxResult.Yes)
            {
                if (collet.deleteCollet(idColletPresent) == true)
                {
                    MessageBox.Show("Suppression réussie");
                    this.Close();
                }
            }
        }
    }
}
