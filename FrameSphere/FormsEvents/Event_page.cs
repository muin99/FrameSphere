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
using FrameSphere.EntityClasses;

namespace FrameSphere
{
    public partial class Event_page : Form
    {

        public Event_page(string Title)
        {
            InitializeComponent();

            Event e = new Event(Title);

            // Format the title and description
            title.Text = e.EventTitle;
            description.Text = e.EventDescription;
            organizer.Text = e.Organization;

            // Format starts and ends time
            if (DateTime.TryParse(e.StartsAt.ToString(), out DateTime startsAt))
            {
                starts.Text = startsAt.ToString("dd MMM yyyy, hh:mm tt"); // Example: "17 Jan 2025, 08:00 PM"
            }
            else
            {
                starts.Text = "Invalid Start Date";
            }

            if (DateTime.TryParse(e.EndsAt.ToString(), out DateTime endsAt))
            {
                ends.Text = endsAt.ToString("dd MMM yyyy, hh:mm tt"); // Example: "18 Jan 2025, 10:00 PM"
            }
            else
            {
                ends.Text = "Invalid End Date";
            }

            // Handle cover image from byte array
            if (e.Poster != null && e.Poster.Length > 0)
            {
                using (MemoryStream ms = new MemoryStream(e.Poster))
                {
                    cover.Image = Image.FromStream(ms);
                }
            }
            else
            {
                // Set a default image if Poster is null or empty
                cover.Image = FrameSphere.Properties.Resources.SmallerNetworkConnectionBackgroundtest_ezgif_com_video_to_gif_converter;
            }
        }


        public void LoadEventData(string title, string description, string organizerDetails, DateTime startDate, DateTime endDate, string registrationType, decimal? ticketPrice, byte[] eventPoster)
        {
            this.title.Text = title;
            this.description.Text = description;
            organizer.Text = organizerDetails;
            starts.Text = startDate.ToString("MM/dd/yyyy hh:mm tt");
            ends.Text = endDate.ToString("MM/dd/yyyy hh:mm tt");
            label8.Text = ticketPrice.HasValue ? ticketPrice.Value.ToString("C") : "Free";

            if (eventPoster != null && eventPoster.Length > 0)
            {
                using (MemoryStream ms = new MemoryStream(eventPoster))
                {
                    cover.Image = Image.FromStream(ms);
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

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            UserDashBoard userDashBoard = new UserDashBoard();
            userDashBoard.Show();
        }
    }
}
