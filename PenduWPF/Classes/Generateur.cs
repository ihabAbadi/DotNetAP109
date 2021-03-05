﻿using PenduWPF.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace PenduWPF.Classes
{
    class Generateur : IGenerateur
    {
        private SqlConnection connection;
        private SqlCommand command;
        private SqlDataReader reader;
        private string request;
        public string Generer()
        {
            //Rechercher aleatoirement un mot à partir d'une table mots
            string response = null;
            request = "SELECT TOP 1 mot from mots order by newid()";
            connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ihab\source\repos\CoursAP2019\basededonnees.mdf;Integrated Security=True;Connect Timeout=30");
            command = new SqlCommand(request, connection);
            connection.Open();
            reader = command.ExecuteReader();
            if(reader.Read())
            {
                response = reader.GetString(0);
            }
            reader.Close();
            command.Dispose();
            connection.Close();
            return response;
        }
    }
}
