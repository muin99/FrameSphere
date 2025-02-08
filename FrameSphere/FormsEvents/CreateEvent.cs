using System;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using FrameSphere;
using FrameSphere.EntityClasses;

namespace FrameSphere
{
    public partial class CreateEvent : Form
    {
        private string imagePath; // Full path to the selected image
        private string eventPosterRelativePath; // Relative path for the database

        public CreateEvent()
        {
            InitializeComponent();

            startdate.Format = DateTimePickerFormat.Custom;
            startdate.CustomFormat = "MM/dd/yyyy hh:mm tt";
            enddate.Format = DateTimePickerFormat.Custom;
            enddate.CustomFormat = "MM/dd/yyyy hh:mm tt";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Dispose();
            UserDashBoard userDashBoard = new UserDashBoard();
            userDashBoard.Show();
        }

        private void button4_Click(object sender, EventArgs e)//browse
        {
            // Open file dialog to select the event poster
            OpenFileDialog openFileDialog = new OpenFileDialog {
                Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp",
                Title = "Select Event Poster"
            };
            try
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    imagePath = openFileDialog.FileName;
                    poster.Text = imagePath;

                    // Save the image to the "EventPosters" folder
                    string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
                    string eventPostersFolder = Path.Combine(baseDirectory, "EventPosters");
                    Directory.CreateDirectory(eventPostersFolder); // Ensure the folder exists

                    // Copy the selected image to the EventPosters folder
                    string fileName = Path.GetFileName(imagePath);
                    string destinationPath = Path.Combine(eventPostersFolder, fileName);
                    File.Copy(imagePath, destinationPath, true);

                    // Store the relative path for the database
                    eventPosterRelativePath = Path.Combine("EventPosters", fileName);

                    // Display the image in the PictureBox using FSystem.GetImageFromPath
                    pictureBox.Image = FSystem.GetImageFromPath(eventPosterRelativePath);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Something went wrong! Try again later.", "Image Loading Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine("Potential Image Loading error: " + ex.Message);
            }
        }

        private void CreateEventBTN(object sender, EventArgs e)
        {

            double price = (paid.Checked && double.TryParse(ticketprice.Text, out double parsedPrice)) ? parsedPrice : 0;
            Event a = new Event(
                                Title.Text,                // Event Title
                                Description.Text,          // Event Description
                                OrgDetails.Text,         // Organization
                                price,
                                startdate.Value,  // Start Date
                                enddate.Value,  // End Date
                                free.Checked ? "Free" : "Paid",                      // Registration Type
                                eventPosterRelativePath            // Poster Image Path
                                );
            MessageBox.Show("Event created successfully. Please Wait for Admin Approval.");
            this.Hide();
            new UserDashBoard().Show();
        }

        private void paid_CheckedChanged(object sender, EventArgs e)
        {
            if (paid.Checked)
            {
                label8.Visible = true;
                ticketprice.Visible = true;
            }
        }

        private void free_CheckedChanged_1(object sender, EventArgs e)
        {
            if (free.Checked)
            {
                label8.Visible = false;
                ticketprice.Visible = false;
            }
        }
    }
}
