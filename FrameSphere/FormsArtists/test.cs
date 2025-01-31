using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FrameSphere.EntityClasses;

namespace FrameSphere.FormsArtists
{
    public partial class test : Form
    {
        public test()
        {
            InitializeComponent();
            Art a = FSystem.loggedInUser.myArts[0];
            a.ArtTitle = "cat";
            label1.Text = a.ArtTitle;
            label2.Text = a.ArtDescription;
            pictureBox1.Image = FSystem.GetImageFromPath(a.ArtPhotos.FirstOrDefault());
        }

        private void test_Load(object sender, EventArgs e)
        {

        }
    }
}
