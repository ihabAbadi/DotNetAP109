using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace CoursAdoNet.Tools
{
    public class Connection
    {
        //private static SqlConnection instance = null;
        private static string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ihab\source\repos\CoursAP2019\basededonnees.mdf;Integrated Security=True;Connect Timeout=30";
        //public static SqlConnection Instance
        //{
        //    get
        //    {
        //        if (instance == null)
        //            instance = new SqlConnection(connectionString);
        //        return instance;
        //    }
        //}

        //private Connection()
        //{
            
        //}

        public static SqlConnection GetSqlConnection()
        {
            return new SqlConnection(connectionString);
        }
     }
}
