using System;
using System.Data.SqlClient;

namespace CoursAdoNet
{
    class Program
    {
        static void Main(string[] args)
        {
            //Connexion à la base de données
            SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ihab\source\repos\CoursAP2019\basededonnees.mdf;Integrated Security=True;Connect Timeout=30");
            //requete création table
            //string request = "CREATE TABLE person (" +
            //    "id int PRIMARY KEY identity(1,1), " +
            //    "firstname varchar(200) not null, " +
            //    "lastname varchar(200) not null)";
            //Console.Write("Le nom : ");
            //string firstName = Console.ReadLine();
            //Console.Write("Le prénom : ");
            //string lastName = Console.ReadLine();
            //string request = "INSERT INTO person (firstname, lastname) " +
            //    "OUTPUT INSERTED.id values (@firstname,  @lastname)";
            ////Commande pour executer une requete
            //SqlCommand command = new SqlCommand(request, connection);
            //command.Parameters.Add(new SqlParameter("@firstname", firstName));
            //command.Parameters.Add(new SqlParameter("@lastname", lastName));

            string request = "SELECT id, firstname, lastname from person";
            SqlCommand command = new SqlCommand(request, connection);
            connection.Open();
            //L'execution d'une commande peut se faire de 3 manières
            //1ere sans resultat 
            //int nb = command.ExecuteNonQuery();
            //2eme avec une seule valeur comme resultat
            //int id = (int)command.ExecuteScalar();
            //3eme avec des données comme resultat
            SqlDataReader reader = command.ExecuteReader();
            while(reader.Read())
            {
                Console.WriteLine($"Id {reader.GetInt32(0)}, Nom {reader.GetString(1)}, Prénom {reader.GetString(2)} ");
            }
            reader.Close();
            //liberation des ressources
            command.Dispose();
            //Console.WriteLine($"l'id de la ligne est de {id}");
            connection.Close();
        }
    }
}
