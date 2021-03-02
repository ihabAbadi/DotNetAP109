using Forum.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Forum.Classes
{
    class Moderateur : Abonne
    {
        public Moderateur(IForum forum) : base(forum)
        {
           
        }

        public Abonne BannirAbonne(Abonne abonne)
        {
            return null;
        }

        public Nouvelle SupprimerNouvelle(Nouvelle nouvelle)
        {
            return null;
        }

        public List<Abonne> RecupererAbonnes()
        {
            return null;
        }
    }
}
