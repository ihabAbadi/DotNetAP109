using System;
using System.Collections.Generic;
using System.Text;

namespace CompteBancaire.Classes
{
    public class IHM
    {
        private Banque banque;
        public void Start()
        {
            CreationBanque();
            string choix;
            do
            {
                MenuPrincipal();
                choix = Console.ReadLine();
                Console.Clear();
                switch(choix)
                {
                    case "1":
                        ActionCreationCompte();
                        break;
                    case "2":
                        ActionDepot();
                        break;
                    case "3":
                        ActionRetrait();
                        break;
                    case "4":
                        ActionAffichageCompte();
                        break;
                    case "5":
                        ActionCalculeInteret();
                        break;
                }
            } while (choix != "0");
        }

        private void CreationBanque()
        {
            Console.Write("Le nom de la banque : ");
            string nom = Console.ReadLine();
            banque = new Banque(nom);
            Console.Clear();
        }

        private void MenuPrincipal()
        {
            Console.WriteLine("1---Créer un compte");
            Console.WriteLine("2---Effectuer un dépôt");
            Console.WriteLine("3---Effectuer un retrait");
            Console.WriteLine("4---Afficher Solde ");
            Console.WriteLine("5---Calcule Interet");
            Console.WriteLine("0---Quitter");
        }

        private void MenuCreationCompte()
        {
            Console.WriteLine("1--Compte courant");
            Console.WriteLine("2--Compte Epargne");
            Console.WriteLine("3--Compte Payant");
        }

        private void ActionCreationCompte()
        {
            Compte compte = null;
            Client client = ActionCreationClient();
            MenuCreationCompte();
            string choix = Console.ReadLine();
            switch(choix)
            {
                case "1":
                    compte = new Compte();
                    break;
                case "2":
                    Console.Write("Merci de saisir le taux : ");
                    decimal t = Convert.ToDecimal(Console.ReadLine());
                    compte = new CompteEpargne(t);
                    break;
                case "3":
                    Console.Write("Merci de saisir le cout d'une opération : ");
                    decimal c = Convert.ToDecimal(Console.ReadLine());
                    compte = new ComptePayant(c);
                    break;
            }
            if(compte != null)
            {
                compte.Client = client;
                banque.CreationCompte(compte);
                ActionAfficherMessage($"compte crée avec le numéro {compte.Numero}", ConsoleColor.Green);
            }
            else
            {
                ActionAfficherMessage("Erreur création compte", ConsoleColor.Red);
            }
        }

        private Client ActionCreationClient()
        {
            Client client = new Client();
            Console.Write("Merci de saisir le nom du client : ");
            client.Nom = Console.ReadLine();
            Console.Write("Merci de saisir le prénom du client : ");
            client.Prenom = Console.ReadLine();
            Console.Write("Merci de saisir le téléphone du client : ");
            client.Telephone = Console.ReadLine();
            return client;
        }

        private void ActionDepot()
        {
            Compte compte = ActionChercherCompte();
            if(compte != null)
            {
                Console.WriteLine("Le montant du dépôt : ");
                decimal montant = Convert.ToDecimal(Console.ReadLine());
                if(compte.Depot(new Operation(montant)))
                {
                    ActionAfficherMessage($"Dépôt effectué, nouveau solde : {compte.Solde}", ConsoleColor.Green);
                }
                else
                {
                    ActionAfficherMessage("Erreur dépôt ", ConsoleColor.Red);
                }
            }
            else
            {
                ActionAfficherMessage("Aucun compte avec ce numéro", ConsoleColor.Red);
            }
        }

        private void ActionRetrait()
        {
            Compte compte = ActionChercherCompte();
            if (compte != null)
            {
                Console.WriteLine("Le montant du retrait : ");
                decimal montant = Convert.ToDecimal(Console.ReadLine());
                if (compte.Retrait(new Operation(montant * -1)))
                {
                    ActionAfficherMessage($"Retrait effectué, nouveau solde : {compte.Solde}", ConsoleColor.Green);
                }
                else
                {
                    ActionAfficherMessage("Erreur Retrait ", ConsoleColor.Red);
                }
            }
            else
            {
                ActionAfficherMessage("Aucun compte avec ce numéro", ConsoleColor.Red);
            }
        }

        private Compte ActionChercherCompte()
        {
            Console.Write("Merci de saisir le numéro de compte : ");
            int numero = Convert.ToInt32(Console.ReadLine());
            Compte compte = banque.RechercherCompte(numero);
            return compte;
        }

        private void ActionAffichageCompte()
        {
            Compte compte = ActionChercherCompte();
            if (compte != null)
            {
                    ActionAfficherMessage($"{compte.ToString()}", ConsoleColor.Magenta);

            }
            else
            {
                ActionAfficherMessage("Aucun compte avec ce numéro", ConsoleColor.Red);
            }
        }
        private void ActionCalculeInteret()
        {
            Compte compte = ActionChercherCompte();
            if (compte != null && compte is CompteEpargne compteEpargne)
            {
                if(compteEpargne.CalculeInteret())
                {
                    ActionAfficherMessage($"calcule interet effectué, nouveau solde : {compte.Solde}", ConsoleColor.Green);
                }
            }
            else
            {
                ActionAfficherMessage("Aucun compte epargne avec ce numéro", ConsoleColor.Red);
            }
        }

        private void ActionAfficherMessage(string message, ConsoleColor color)
        {
            Console.Clear();
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Une touche pour continuer...");
            Console.ReadLine();
            Console.Clear();
        } 
    }
}
