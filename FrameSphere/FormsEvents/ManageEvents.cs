using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FrameSphere.EntityClasses;
using System.Reflection;
using FrameSphere.FormsEvents;

namespace FrameSphere
{
    public partial class ManageEvents : Form
    {
        public Event ev;
        public ManageEvents(int id)
        {
            InitializeComponent();
            //this.id = id;
            //LoadEventData(id);

            ev = new Event(id);
            eventTitle_field.Text = ev.EventTitle;
            eventDesc_field.Text = ev.EventDescription;
            startdate.Value = ev.StartsAt;
            enddate.Value = ev.EndsAt;
            OrgDetails_field.Text = ev.Organization;
            if (ev.RegistrationType == "Free")
            {
                free.Checked = true;
                paid.Checked = false;
            }

            if (ev.RegistrationType == "Paid")
            {
                ticketprice_field.Visible = true;
                paid.Checked = true;
                free.Checked = false;
            }
            ticketprice_field.Text = ev.TicketPrice.ToString();
            poster_field.Text = ev.PosterImage;
            posterImage.Image = FSystem.GetImageFromPath(ev.PosterImage);


        }
        private void update_button_Click(object sender, EventArgs e)
        {
            //FSystem.loggedInUser.CheckPassword(CurrentPWField.Text)
            if (FSystem.loggedInUser.CheckPassword(CurrentPWField.Text))
            {
                ev.EventTitle = eventTitle_field.Text;
                ev.EventDescription = eventDesc_field.Text;
                ev.StartsAt = startdate.Value;
                ev.EndsAt = enddate.Value;
                ev.Organization = OrgDetails_field.Text;
                if (free.Checked)
                {
                    ev.RegistrationType = "Free";
                    ev.TicketPrice = 0;
                }
                else if (paid.Checked) {
                    ev.RegistrationType = "Paid";
                    ev.TicketPrice = Int32.Parse(ticketprice_field.Text);
                }
                

                // Save the image to the "EventPosters" folder
                string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
                string eventPostersFolder = Path.Combine(baseDirectory, "EventPosters");
                Directory.CreateDirectory(eventPostersFolder); // Ensure the folder exists

                // Copy the selected image to the EventPosters folder
                string fileName = Path.GetFileName(poster_field.Text);
                string destinationPath = Path.Combine(eventPostersFolder, fileName);
                File.Copy(poster_field.Text, destinationPath, true);

                // Store the relative path for the database
                string eventPosterRelativePath = Path.Combine("EventPosters", fileName);
                ev.PosterImage = eventPosterRelativePath;
            }
            else
            {
                MessageBox.Show("Please enter your valid password");
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Admin_dashboard a = new Admin_dashboard();
            a.Show();
            this.Hide();
        }

        private void posterbtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog {
                Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp",
                Title = "Select Event Poster"
            };
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string imagePath = openFileDialog.FileName;
                poster_field.Text = imagePath;


                // Display the image in the PictureBox using FSystem.GetImageFromPath
                posterImage.Image = Image.FromFile(imagePath);
            }
        }

        private void participants_button_Click(object sender, EventArgs e)
        {
            this.Hide();
            ManageParticipants mn = new ManageParticipants(ev);
            mn.Show();


        }

        private void artCollections_button_Click(object sender, EventArgs e)
        {
            this.Hide();
            ManageArtCollections mn = new ManageArtCollections(FSystem.loggedInUser);
        }
    }
}
