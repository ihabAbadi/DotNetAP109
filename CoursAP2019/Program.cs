using CoursAP2019.Classes;
using CoursAP2019.Interfaces;
using System;
using System.Collections.Generic;

namespace CoursAP2019
{
    class Program
    {
        static void Main(string[] args)
        {
            #region cours c# héritage, polymorphisme, interface
            /*//List<Person> persons = new List<Person>();
            Person s = new Student("toto", "tata", 20, 1);
            //persons.Add(s);
            Person t = new Teacher("titi", "minet", 50, ".net");
            //persons.Add(t);
            //foreach(Person p in persons)
            //{
            //    Console.WriteLine(p.GetType());
            //    p.Display();
            //    //1ere manière de convertir des objets
            //    //Student st = p as Student;
            //    //if(st != null)
            //    //{
            //    //    st.DisplayStudent();
            //    //}
            //    //2eme manière de convertir des objets
            //    //if(p.GetType() == typeof(Student))
            //    //{
            //    //    Student st = (Student)p;
            //    //    st.DisplayStudent();
            //    //}
            //    //3eme manière de convertir des objets
            //    if(p is Student st)
            //    {
            //        st.DisplayStudent();
            //    }
            //    else if(p is Teacher tt)
            //    {
            //        tt.DisplayTeacher();
            //    }
            //}

            //List<IDisplayable> display = new List<IDisplayable>();
            //display.Add(s);
            //display.Add(t);
            //display.Add(new Car() { Model = "ford" });
            //foreach(IDisplayable i in display)
            //{
            //    if(i is Student st)
            //    {
            //        st.DisplayStudent();
            //    }
            //    i.Display();
            //}

            //Affichage dans une console 
            Console.WriteLine("Bonjour tout le monde");
            Console.Write("Votre nom : ");
            //Lire à partir d'une console
            string nom = Console.ReadLine();
            Console.Write("Votre age : ");
            int age = Convert.ToInt32(Console.ReadLine());*/
            #endregion

            #region cours passage paramètre, delgate, event
            //Passage de paramètres en ref ou out pour les variables de type valeur
            //int c = 10;
            //Addition(ref c, 20);
            //int c;
            //Addition(out c, 20);
            //Console.WriteLine(c);
            //Person p = new Person("toto","tata");
            //AfficherPersonne(p);
            //Console.WriteLine(p.FirstName);

            //Console.WriteLine("Merci saisir l'age : ");
            ////int age = Convert.ToInt32(Console.ReadLine());
            ////Convertion avec la méthode tryparse
            //int age;
            //if(!Int32.TryParse(Console.ReadLine(), out age))
            //{
            //    Console.WriteLine("merci de saisir une valeur numérique");
            //}
            //else
            //{
            //    Console.WriteLine("L'age est de " + age);
            //}

            //utilisation des delegates
            //Calculatrice cal = new Calculatrice();
            //cal.Calcule(30, 40, cal.Addition);
            //cal.Calcule(30, 40, cal.Soustraction);
            //cal.Calcule(30, 40, Multiplication);
            //cal.Calcule(40, 30, delegate (double a, double b) { return a / b; });
            //Expression lambda
            //cal.Calcule(40, 30, (a, b) =>  a / b);
            //Person p = new Person("toto", "tata");
            //p.Display(Console.WriteLine);
            //p.Display(Console.Write);
            //quelque expression lambda dans le framework .net
            //List<Person> liste = new List<Person>() { new Person("toto", "tata"), new Person("titi", "minet") };
            //foreach(Person p in liste)
            //{
            //    AfficherPersonne(p);
            //}
            ////<=>

            //liste.ForEach(AfficherPersonne);

            //Person p = null;
            //foreach(Person ps in liste)
            //{
            //    if(ps.FirstName == "toto")
            //    {
            //        p = ps;
            //        break;
            //    }
            //}
            //<=>
            //Person p = liste.Find(x => x.FirstName == "toto");
            /* Pile<Person> pilePersonnes = new Pile<Person>(2);
             pilePersonnes.PilePleine += NotificationPilePleine;
             pilePersonnes.Empiler(new Person("toto", "tata"));
             pilePersonnes.Empiler(new Person("titi", "minet"));
             pilePersonnes.Depiler();
             pilePersonnes.Empiler(new Person("titi", "minet"));
             pilePersonnes.Empiler(new Person("titi", "minet"));
             Person p = pilePersonnes.Search(x => x.FirstName == "toto");*/

            //Cours event
            //Car car = new Car() { Model = "Ford", Price = 20000 };
            //car.Promotion += NotificationSms;
            //car.Promotion += NotificationEmail;
            //string choix;
            //int compteur = 0;
            //do
            //{
            //    Console.Write("Promotion ? (o/n) ");
            //    choix = Console.ReadLine();
            //    if(choix == "o")
            //    {
            //        Console.Write("Le montant de la réduction : ");
            //        decimal reduction = Convert.ToDecimal(Console.ReadLine());
            //        car.Discount(reduction);
            //        compteur++;
            //    }
            //    if(compteur == 3)
            //    {
            //        car.Promotion -= NotificationSms;
            //    }
            //} while (choix != "0"); 
            //Injection de dépendance

            Car car = new Car(new Sauvegarde());
            Car car2 = new Car(new SauvegardeSGBD());
            #endregion
        }


        //static void Addition(ref int a, int b)
        //{
        //    a += 2;
        //    Console.WriteLine(a + b);
        //}
        static void Addition(out int a, int b)
        {
            a = 2;
            Console.WriteLine(a + b);
        }
        static void AfficherPersonne(Person p)
        {
            p.FirstName = "Mr ou Mme " + p.FirstName;
            Console.WriteLine(p.FirstName);
        }

        static bool NotreTryParse(string chaine, out int entier)
        {
            bool result = false;
            try
            {
                entier = Convert.ToInt32(chaine);
                result = true;
            }catch(Exception e)
            {
                entier = 0;
            }
            return result;
        }


        static double Multiplication(double a, double b)
        {
            return a * b;
        }


        static void NotificationSms(decimal price)
        {
            Console.WriteLine($"Sms avec le nouveau prix de la voiture : ${price}");
        }
        static void NotificationEmail(decimal price)
        {
            Console.WriteLine($"Mail avec le nouveau prix de la voiture : ${price}");
        }

        static void NotificationPilePleine(int taille)
        {
            Console.WriteLine($"La pile est pleine avec : {taille} elements");
        }
    }
}
