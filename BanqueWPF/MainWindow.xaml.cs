using DAOBanque.Classes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace BanqueWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Banque banque;

        private Compte rechercheCompte;
        public MainWindow()
        {
            InitializeComponent();
            banque = new Banque("cic");
        }


        public void CreationCompteClick(object sender, RoutedEventArgs e)
        {
            Client client = new Client()
            {
                Nom = nomTextBox.Text,
                Prenom = prenomTextBox.Text,
                Telephone = telephoneTextBox.Text
            };
            Compte compte = new Compte()
            {
                Solde = Convert.ToDecimal(soldeTextBox.Text),
                Client = client
            };
            banque.CreationCompte(compte);
            resultatCreationTextBlock.Text = $"Compte crée avec le numéro {compte.Numero}";
        } 

        public void RechercheCompteClick(object sender, RoutedEventArgs e)
        {
            rechercheCompte = banque.RechercherCompteEtOperation(Convert.ToInt32(numeroTextBox.Text));
            if(rechercheCompte != null)
            {
                resultatRechercheClientTexBlock.Text = rechercheCompte.Client.ToString();
                resultatRechercheSoldeTexBlock.Text = rechercheCompte.Solde + " euros";
                resultatOperations.ItemsSource = rechercheCompte.Operations;
            }
            else
            {
                MessageBox.Show("aucun compte avec ce numéro");
            }
        }

        private void DepotClick(object sender, RoutedEventArgs e)
        {
            OuvrirOperationWindow(1);
        }
        private void RetraitClick(object sender, RoutedEventArgs e)
        {
            OuvrirOperationWindow(0);
        }

        private void OuvrirOperationWindow(int type)
        {
            if (rechercheCompte != null)
            {
                OperationWindow w = new OperationWindow(rechercheCompte, type, resultatOperations);
                w.Show();
            }
            else
            {
                MessageBox.Show("Merci d'effectuer une recherche");
            }
        }
    }
}
