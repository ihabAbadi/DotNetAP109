using DAOBanque.Classes;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace BanqueWPF
{
    /// <summary>
    /// Logique d'interaction pour OperationWindow.xaml
    /// </summary>
    public partial class OperationWindow : Window
    {
        private Compte _compte;
        private int _typeOperation;
        private ListView _listeOperations;
        public OperationWindow()
        {
            InitializeComponent();
        }

        public OperationWindow(Compte compte, int typeOperation, ListView listeOperations) : this()
        {
            if(typeOperation == 1)
            {
                Title = "Dépôt";
            }
            else if(typeOperation == 0)
            {
                Title = "Retrait";
            }
            else
            {
                Close();
            }
            _compte = compte;
            _typeOperation = typeOperation;
            _listeOperations = listeOperations;
            numeroCompteLabel.Content = _compte.Numero;
        }

        public void ConfirmOperation(object sender, RoutedEventArgs e)
        {
            decimal montant = Convert.ToDecimal(montantTextBox.Text);
            if(_typeOperation == 1)
            {
                Operation o = new Operation(montant);
                if (_compte.Depot(o))
                {
                    MessageBox.Show("Dépôt effectué");
                }
                else
                {
                    MessageBox.Show("erreur dépôt");
                }
            }
            else if(_typeOperation == 0)
            {
                Operation o = new Operation(montant*-1);
                if (_compte.Retrait(o))
                {
                    MessageBox.Show("Retrait effectué");
                }
                else
                {
                    MessageBox.Show("erreur retrait");
                }
            }
            _listeOperations.ItemsSource = new List<Operation>(_compte.Operations);
            Close();
        }
    }
}
