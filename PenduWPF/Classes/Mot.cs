using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace PenduWPF.Classes
{
    public class Mot
    {
        private int id;
        private string chaine;
        private SqlConnection connection;
        private SqlCommand command;
        private string request;

        public int Id { get => id; set => id = value; }
        public string Chaine { get => chaine; set => chaine = value; }

        public bool Save()
        {
            request = "INSERT INTO mots (mot) output inserted.id values(@mot)";
            connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ihab\source\repos\CoursAP2019\basededonnees.mdf;Integrated Security=True;Connect Timeout=30");
            command = new SqlCommand(request, connection);
            command.Parameters.Add(new SqlParameter("@mot", Chaine));
            connection.Open();
            Id = (int)command.ExecuteScalar();
            command.Dispose();
            connection.Close();
            return Id > 0;
        }
    }
}
