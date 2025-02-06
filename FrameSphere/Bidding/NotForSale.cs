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

namespace FrameSphere.Bidding
{
    public partial class NotForSale : Form
    {
        public Art art;
        public Event Event;
        public NotForSale(Art art, Event ev)
        {
            InitializeComponent();
            this.art = art;
            this.Event = ev;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            ArtDisplayForm af = new ArtDisplayForm(art.ArtID, Event);
            af.Show();
        }
    }
}
