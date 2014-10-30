using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using MySql.Data.MySqlClient;
using System.Configuration;

namespace GM241.Classes
{
    class BDService
    {
        private MySqlConnection connexion;

        public BDService()
        {
            try
            {
                string connexionString;

                connexionString = ConfigurationManager.ConnectionStrings["MySqlConnexion"].ConnectionString;
                connexion = new MySqlConnection(connexionString);
            }
            catch (Exception e)
            {
                MessageBox.Show("Erreur de la string de connexion");
            }
        }

        private bool Ouvrir()
        {
            try
            {
                connexion.Open();
                return true;
            }
            catch 
            {
                MessageBox.Show("Erreur d'ouverture de connexion");
                return false;
            }
        }

        private bool Fermer()
        {
            try
            {
                connexion.Close();
                return true;
            }
            catch
            {
                MessageBox.Show("Erreur de fermeture de connexion");
                return false;
            }
        }

        public void Insertion(string ins)
        {
            try
            {
                if(Ouvrir())
                {
                    MySqlCommand cmd = new MySqlCommand(ins,connexion);
                    cmd.ExecuteNonQuery();
                    Fermer();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Erreur lors de l'insertion");
            }
        }

        public List<string>[] selection(string sel, int nbChamp, ref int nbRange)
        {
            List<string> infoBrute = new List<string>();

            nbRange = 0;

            try
            {
                if(Ouvrir())
                {
                    MySqlCommand cmd = new MySqlCommand(sel,connexion);
                    MySqlDataReader dataReader = cmd.ExecuteReader();

                    while(dataReader.Read())
                    {
                        for (int i = 0; i < nbChamp; i++)
                        {
                            infoBrute.Add(dataReader[i].ToString());
                        }

                        nbRange++;
                    }

                    dataReader.Close();
                    Fermer();
                }

            }
            catch (Exception e)
            {
                MessageBox.Show("Erreur dans le select");
            }

            List<string>[] listeRetour;

            if(nbRange == 0)
            {
                listeRetour = new List<string>[1];
                listeRetour[0] = new List<string>();
                listeRetour[0].Add("");
            }
            else
            {
                listeRetour = new List<string>[nbRange];

                for (int i = 0; i < nbRange; i++)
                {
                    listeRetour[i] = new List<string>();

                    for (int x = 0; x < nbChamp; x++)
                    {
                        int indice = x + (i * nbChamp);
                        listeRetour[i].Add(infoBrute[indice]);
                    }
                }
            }
            return listeRetour;
        }
    }
}
