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
    /// Logique d'interaction pour ajoutOutil.xaml
    /// </summary>
    public partial class Outil : Window
    {
        private void viderChamps()
        {
            listeTypeOutil.SelectedIndex = 0;
            listePlaquette.SelectedIndex = 0;
            listeNoLocal.SelectedIndex = 0;
            //listeNoArmoire.SelectedIndex = 0;
            //listeNoTiroir.SelectedIndex = 0;
            //listeNoCasier.SelectedIndex = 0;
            nom.Text = "";
            quantite.Text = "";
            diametreUsinage.Text = "";
            longueurCoupe.Text = "";
            longuerTotal.Text = "";
            longueurShank.Text = "";
            rayonCoin.Text = "";
            diametreSerrage.Text = "";
            anglePointe.Text = "";
            nbrFlute.Text = "";
            img.Text = "";
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        public Outil(Outils monOutil)
        {
            InitializeComponent();

            // Pour le type d'outil
            List<TypeOutils> lstTypeOutils = TypeOutils.chargerlstTypeOutils();

            foreach (TypeOutils tO in lstTypeOutils)
                listeTypeOutil.Items.Add(tO.idTypeOutil + " - " + tO.nom);

            listeTypeOutil.SelectedIndex = monOutil.idTypeOutil - 1;

            // Pour les plaquettes
            List<Plaquettes> lstPlaquettes = Plaquettes.chargerlstPlaquettes();

            if (monOutil.idPlaquette == null)
            {
                listePlaquette.Items.Add("0 - Aucun");
                listePlaquette.SelectedIndex = 0;
            }

            foreach (Plaquettes p in lstPlaquettes)
                listePlaquette.Items.Add(p.idPlaquette + " - " + p.nom);

            if (monOutil.idPlaquette != null)
                listePlaquette.SelectedIndex = monOutil.idPlaquette.Value - 1;

            nom.Text = monOutil.nom;
            quantite.Text = monOutil.quantite.ToString();
            diametreUsinage.Text = monOutil.diametreUsinage;
            longueurCoupe.Text = monOutil.longueurCoupe;
            longuerTotal.Text = monOutil.longueurTotal;
            longueurShank.Text = monOutil.longueurShank;
            rayonCoin.Text = monOutil.rayonCoin;
            diametreSerrage.Text = monOutil.diametreSerrage;
            anglePointe.Text = monOutil.anglePointe;
            nbrFlute.Text = monOutil.nombreFlute.ToString();

            if (monOutil.disponible == true)
            {
                dispoOui.IsChecked = true;
                dispoNon.IsChecked = false;
            }

            if (monOutil.unitePouce == true)
            {
                uniteOui.IsChecked = true;
                uniteNon.IsChecked = false;
            }

            img.Text = monOutil.image;

            btnAjouter.IsEnabled = false;
            btnModif.IsEnabled = true;
            btnSupprimer.IsEnabled = true;
        }

        public Outil()
        {
            InitializeComponent();

            listeNoArmoire.Items.Add("0 - Aucun");
            listeNoTiroir.Items.Add("0 - Aucun");
            listeNoCasier.Items.Add("0 - Aucun");

            // Charger la liste des types d'outil
            List<TypeOutils> lstTypeOutils = TypeOutils.chargerlstTypeOutils();

            foreach (TypeOutils tO in lstTypeOutils)
                listeTypeOutil.Items.Add(tO.idTypeOutil + " - " + tO.nom);

            /*
            // Charger la liste des types d'emplacements
            List<Emplacements> lstEmplacements = Emplacements.chargerlstEmplacements();

            foreach (Emplacements e in lstEmplacements)
            {
                listeNoLocal.Items.Add(e.idTypeEmplacement + " - " + e.noLocal);
                listeNoArmoire.Items.Add(e.noArmoire);
                listeNoTiroir.Items.Add(e.noTiroir);
                listeNoCasier.Items.Add(e.noCasier);
            }
            */

            // Chargement temporaire des emplacement *** À changer
            List<Emplacements> lstEmplacements = Emplacements.chargerlstEmplacements();
            foreach (Emplacements e in lstEmplacements)
                listeNoLocal.Items.Add(e.idTypeEmplacement + " - " + e.noLocal + " - " + e.idArmoire + " - " + e.idCasier + " - " + e.idTiroir);

            // Charger la liste des plaquettes
            List<Plaquettes> lstPlaquettes = Plaquettes.chargerlstPlaquettes();

            foreach (Plaquettes p in lstPlaquettes)
                listePlaquette.Items.Add(p.idPlaquette + " - " + p.nom);

            viderChamps();
        }

        private void btnAjout_Click(object sender, RoutedEventArgs e)
        {
            bool insertValide = true;
            bool outilDisponible = false;
            bool uniteEnPouce = false;
            char[] splitchar = {' '};
            string str = null;
            string str2 = null;
            string str3 = null;
            string[] idTypeOutil = null;
            string[] idTypeEmplacement = null;
            string[] idPlaquette = null;
            Outils outils = new Outils();

            str = listeTypeOutil.Text;
            idTypeOutil = str.Split(splitchar);

            str2 = listeNoLocal.Text;
            idTypeEmplacement = str2.Split(splitchar);

            str3 = listePlaquette.Text;
            idPlaquette = str3.Split(splitchar);

            if (nom.Text == "")
                insertValide = false;

            if (quantite.Text == "")
                insertValide = false;

            if (diametreUsinage.Text == "")
                insertValide = false;

            if (longueurCoupe.Text == "")
                insertValide = false;

            if (longuerTotal.Text == "")
                insertValide = false;

            if (longueurShank.Text == "")
                insertValide = false;

            if (rayonCoin.Text == "")
                insertValide = false;

            if (diametreSerrage.Text == "")
                insertValide = false;

            if (img.Text == "")
                insertValide = false;

            if(dispoOui.IsChecked == true)
            {
                outilDisponible = true;
            }

            if (uniteOui.IsChecked == true)
            {
                uniteEnPouce = true;
            }

            if (insertValide == true)
            {
                if (outils.ajoutOutil(Convert.ToInt32(idTypeOutil[0]), Convert.ToInt32(idTypeEmplacement[0]), Convert.ToInt32(idPlaquette[0]), nom.Text, Convert.ToInt32(quantite.Text), diametreUsinage.Text, diametreSerrage.Text, longueurCoupe.Text, longuerTotal.Text, longueurShank.Text, rayonCoin.Text, anglePointe.Text, Convert.ToInt32(nbrFlute.Text), outilDisponible, uniteEnPouce, img.Text) == true)
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
