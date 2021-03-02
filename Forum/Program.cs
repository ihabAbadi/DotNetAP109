using Forum.Classes;
using System;

namespace Forum
{
    class Program
    {
        static void Main(string[] args)
        {
            Classes.Forum f = new Classes.Forum();
            Moderateur m = new Moderateur(f); 
        }
    }
}
