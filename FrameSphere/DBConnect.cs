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
        private static readonly string muin = @"ONUKROM";
        private static readonly string raisa = @"DESKTOP-5903S8A";
        private static readonly string nabil = @"MAZHARUL75\SQLEXPRESS";

        private static readonly string ServerName = muin; //Add your servername in a string
        private static readonly string ConnectionString = $@"Data Source={ServerName}; Initial Catalog = FrameSphere; Integrated Security = true";
        
        
        
        
        public static SqlConnection Connection = new SqlConnection(ConnectionString);

        static DB()
        {
            Connection = new SqlConnection(ConnectionString);
        } 
        public static SqlConnection Connect()
        {
            return new SqlConnection(ConnectionString);//a
        }
        //cat
    }
}
