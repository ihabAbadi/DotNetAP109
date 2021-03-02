using Forum.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Forum.Classes
{
    class Abonne
    {
        private string email;
        private string nom;
        private string prenom;
        private string age;

        protected IForum _forum;

        public string Email { get => email; set => email = value; }
        public string Nom { get => nom; set => nom = value; }
        public string Prenom { get => prenom; set => prenom = value; }
        public string Age { get => age; set => age = value; }

        public Abonne(IForum forum)
        {
            _forum = forum;
        }
        public Nouvelle CreerNouvelle(Nouvelle nouvelle)
        {
            return null;
        }

        public Nouvelle PublierNouvelle(Nouvelle nouvelle)
        {
            return null;
        }

        public Nouvelle RepondreNouvelle(Nouvelle nouvelle)
        {
            return null;
        }

        public List<Nouvelle> RecupererNouvelles()
        {
            return null;
        }
    }
}
