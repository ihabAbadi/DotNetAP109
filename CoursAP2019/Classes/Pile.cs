using System;
using System.Collections.Generic;
using System.Text;

namespace CoursAP2019.Classes
{
    public class Pile<T>
    {
        private T[] tab;
        private int compteur;
        public event Action<int> PilePleine;
        public Pile(int taille)
        {
            tab = new T[taille];
            compteur = 0;
        }

        public void Empiler(T element)
        {
            if(compteur < tab.Length)
            {
                tab[compteur] = element;
                compteur++;
            }
            else
            {
                if(PilePleine != null)
                {
                    PilePleine(tab.Length);
                }
            }
        }

        public void Depiler()
        {
            if(compteur > 0)
            {
                compteur--;
                tab[compteur] = default(T);
            }
        }

        public T Search(Func<T, bool> MethodeSearch)
        {
            T element = default(T);
            for(int i=0; i < tab.Length; i++)
            {
                if(MethodeSearch(tab[i]))
                {
                    element = tab[i];
                    break;
                }
            }

            return element;
        }
    }
}
