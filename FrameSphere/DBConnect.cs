using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameSphere
{
    public static class DBConnect
    {
        //Write the server name here
        private static string ServerName = "DESKTOP-5903S8A";

        private static readonly string cString = $"Data Source={ServerName}\\SQLEXPRESS; Initial Catalog = FrameSphere; Integrated Security = true";

        public static SqlConnection Connect()
        {
            return new SqlConnection(cString);
        }
    }
}