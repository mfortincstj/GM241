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

namespace GM241.Fenetres.Menu
{
    /// <summary>
    /// Logique d'interaction pour MenuRapport.xaml
    /// </summary>
    public partial class MenuRapport : Window
    {
        public MenuRapport()
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
        }

        private void btnFermer_Click(object sender, RoutedEventArgs e)
        {
            bool estAdmin = true;

            MenuPrincipal menuPrincipal = new MenuPrincipal(estAdmin);
            menuPrincipal.Show();

            this.Close();
        }
    }
}
