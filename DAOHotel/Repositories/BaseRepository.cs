using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DAOHotel.Repositories
{
    public class BaseRepository
    {
        protected SqlCommand command;
        protected SqlDataReader reader;
        protected string request;
        protected SqlConnection connection;
    }
}
