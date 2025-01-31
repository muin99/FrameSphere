using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FrameSphere.EntityClasses;

namespace FrameSphere.FormsArts
{
    public partial class test : Form
    {
        public test()
        {
            Art art = new Art(13);
            InitializeComponent();
            label1.Text = art.ArtID.ToString();
            label2.Text = art.ArtTitle.ToString();
            label3.Text = art.ArtDescription;
            label4.Text = art.SellingOption.ToString();
            label5.Text = art.Price.ToString();
            label6.Text = art.PhotoCount.ToString();
            pictureBox1.Image = FSystem.GetImageFromPath(art.artPhotos.FirstOrDefault());
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
