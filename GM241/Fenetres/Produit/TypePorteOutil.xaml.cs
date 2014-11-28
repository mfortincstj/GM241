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

namespace GM241.Fenetres.Produit
{
    /// <summary>
    /// Logique d'interaction pour TypePorteOutil.xaml
    /// </summary>
    public partial class TypePorteOutil : Window
    {
        private void viderChamps()
        {
            listeCone.SelectedIndex = 0;
            listeAttachement.SelectedIndex = 0;
            nom.Text = "";
        }

        public TypePorteOutil()
        {
            InitializeComponent();

            // Charger la liste des cones
            List<Cones> lstCones = Cones.chargerlstCones();

            foreach (Cones c in lstCones)
                listeCone.Items.Add(c.idCone + " - " + c.nom);

            // Charger la liste des attachements
            List<TypeAttachements> lstAttachements = TypeAttachements.chargerlstTypeAttachements();

            foreach (TypeAttachements tA in lstAttachements)
                listeAttachement.Items.Add(tA.idTypeAttachements + " - " + tA.nom);

            viderChamps();
        }

        public TypePorteOutil(TypePorteOutils monTypePorteOutil)
        {
            InitializeComponent();

            // Charger la liste des cones
            List<Cones> lstCones = Cones.chargerlstCones();

            foreach (Cones c in lstCones)
                listeCone.Items.Add(c.idCone + " - " + c.nom);

            listeCone.SelectedIndex = monTypePorteOutil.idCone - 1;

            // Charger la liste des attachements
            List<TypeAttachements> lstAttachements = TypeAttachements.chargerlstTypeAttachements();

            foreach (TypeAttachements tA in lstAttachements)
                listeAttachement.Items.Add(tA.idTypeAttachements + " - " + tA.nom);

            listeAttachement.SelectedIndex = monTypePorteOutil.idTypeAttachement - 1;

            nom.Text = monTypePorteOutil.nom;
        }

        private void btnAjouter_Click(object sender, RoutedEventArgs e)
        {
            bool insertValide = true;
            char[] splitchar = { ' ' };
            string str = null;
            string str2 = null;
            string[] idCone = null;
            string[] idAttchement = null;
            TypePorteOutils typePorteOutils = new TypePorteOutils();

            // Prendre le id du type d'emplacement
            str = listeCone.Text;
            idCone = str.Split(splitchar);

            // Prendre le id du type d'attachement
            str2 = listeAttachement.Text;
            idAttchement = str2.Split(splitchar);

            // Vérifier si les champs sont vide ? 
            if (nom.Text == "")
                insertValide = false;

            if (insertValide == true)
            {
                if (typePorteOutils.ajoutTypePorteOutil(Convert.ToInt32(idCone[0]), Convert.ToInt32(idAttchement[0]), nom.Text) == true)
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
