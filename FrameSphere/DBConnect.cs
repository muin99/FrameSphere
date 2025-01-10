using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameSphere
{
    public static class DB
    {
        private static readonly string ServerName = "ONUKROM\\SQLEXPRESS";
        private static readonly string ConnectionString = $"Data Source={ServerName}; Initial Catalog = FrameSphere; Integrated Security = true";

        public static SqlConnection Connect()
        {
            return new SqlConnection(ConnectionString);
        }
    }
}
