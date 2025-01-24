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
    public partial class ArtistDashboard : Form
    {
        public ArtistDashboard()
        {
            InitializeComponent();
        }

        private void CreateArt_Click(object sender, EventArgs e)
        {
            CreateArts createArts = new CreateArts();
            this.Hide();
            createArts.Show();
        }

        private void ArtistDashboard_Load(object sender, EventArgs e)
        {
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
