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
    public partial class ApplyForArtist : Form
    {
        public ApplyForArtist()
        {
            InitializeComponent();
        }

        private void Apply_Click(object sender, EventArgs e)
        {
            FSystem.loggedInUser.applyforBecomingArtist();

            this.Hide();
            UserDashBoard u = new UserDashBoard();
            u.Show();

        }
    }
}
