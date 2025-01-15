using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrameSphere
{
    public partial class Edit_Profile : Form
    {
        public Edit_Profile()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            UserDashBoard userDashBoard = new UserDashBoard();
            userDashBoard.Show();
        }

        private void UpdateBtn_Click(object sender, EventArgs e)
        {
            SqlConnection conn = DB.Connect();
            string q = "UPDATE AllUser\r\nSET FirstName = 'r',\r\n    LastName = 'a',\r\n\tEmail = 'ra@'\r\nWHERE Password = 'a' and Username = 'a';\r\n\r\nUPDATE UserContact\r\nSET Address = 'thiscity',\r\n    Email = 'ra@',\r\n\tPhone = '73823',\r\n\t\r\n"
            
        }
    }
}
