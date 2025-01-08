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
        private static readonly string cstr = "Data Source=ONUKROM\\SQLEXPRESS; Initial Catalog = FrameSphere; Integrated Security = true";

        public static SqlConnection Connect()
        {
            return new SqlConnection(cstr);
        }
    }
}
