using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrameSphere
{
    public partial class Event_page : Form
    {
        public Event_page()
        {
            InitializeComponent();
        }

        public void LoadEventData(string title, string description, string organizerDetails, DateTime startDate, DateTime endDate, string registrationType, decimal? ticketPrice, byte[] eventPoster)
        {
            label1.Text = title;
            textBox1.Text = description;
            textBox2.Text = organizerDetails;
            label6.Text = startDate.ToString("MM/dd/yyyy hh:mm tt");
            label7.Text = endDate.ToString("MM/dd/yyyy hh:mm tt");
            //lblRegistrationType.Text = registrationType;
            label8.Text = ticketPrice.HasValue ? ticketPrice.Value.ToString("C") : "Free";

            // Set the event poster
            if (eventPoster != null && eventPoster.Length > 0)
            {
                using (MemoryStream ms = new MemoryStream(eventPoster))
                {
                    pictureBox1.Image = Image.FromStream(ms);
                }
            }
        }

        

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void Event_page_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint_1(object sender, PaintEventArgs e)
        {

        }
    }
}
