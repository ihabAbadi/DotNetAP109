using PenduWPF.Classes;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PenduWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        JeuPendu jeu;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ClickJouer(object sender, RoutedEventArgs e)
        {
            Generateur g = new Generateur();
            jeu = new JeuPendu(g);
            jeu.GenererMasque();
            if(jeu.Masque != null)
            {
                masqueTextBlock.Text = jeu.Masque;
                nbEssaiTextBlock.Text = "Nombre Essai : " + jeu.NbreEssai;
                GenererBoutons();
            }
        } 
        private void ClickAjouterMot(object sender, RoutedEventArgs e)
        {
            if(motTextBox.Text != "")
            {
                Mot mot = new Mot()
                {
                    Chaine = motTextBox.Text
                };
                if(mot.Save())
                {
                    MessageBox.Show("mot ajouté");
                    motTextBox.Text = "";
                }
                else
                {
                    MessageBox.Show("Erreur insertion");
                }
            }
        }


        private void GenererBoutons()
        {
            boutonsLettres.Children.Clear();
            for(char c='a'; c <= 'z'; c++)
            {
                Button b = new Button()
                {
                    Content = c,
                    Width = 100,
                    Height = 100,
                    HorizontalContentAlignment = HorizontalAlignment.Center,
                    VerticalContentAlignment = VerticalAlignment.Center
                };
                b.Click += ClickLettreBouton;
                boutonsLettres.Children.Add(b);
            }
        }

        private void ClickLettreBouton(object sender, RoutedEventArgs e)
        {
            if(sender is Button b)
            {
                char c = Convert.ToChar(b.Content);
                if (jeu.TestChar(c))
                {
                    masqueTextBlock.Text = jeu.Masque;
                    if(jeu.TestWin())
                    {
                        MessageBox.Show("Bravo !!!!!");
                    }                    
                }
                else
                {
                    nbEssaiTextBlock.Text = "Nombre Essai : " + jeu.NbreEssai;
                    if (jeu.NbreEssai == 0)
                    {
                        MessageBox.Show("Perdu !!!!");
                    }
                }
                
                b.IsEnabled = false;
            }
        }
    }
}
