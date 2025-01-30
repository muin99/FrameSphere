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

namespace FrameSphere.FormsEvents
{
    public partial class Form1 : Form
    {
        private Event e = new Event(28);
        public Form1(Event a)
        {
            InitializeComponent();
            this.e = a;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void goBack_button_Click(object sender, EventArgs e)
        {
            this.Hide();
            ManageEvents mn = new ManageEvents();
        }
    }
}
