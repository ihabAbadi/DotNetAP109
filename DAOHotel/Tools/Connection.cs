using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DAOHotel.Tools
{
    class Connection
    {
        private static string stringConnection = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ihab\source\repos\CoursAP2019\basededonnees.mdf;Integrated Security=True;Connect Timeout=30";
        public static SqlConnection New { get => new SqlConnection(stringConnection); }
    }
}
