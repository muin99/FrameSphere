using System;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using FrameSphere;

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

        private void button4_Click(object sender, EventArgs e)
        {
            // Open file dialog to select the event poster
            OpenFileDialog openFileDialog = new OpenFileDialog {
                Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp",
                Title = "Select Event Poster"
            };

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

        private void CreateEventBTN(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = DB.Connect())
                {
                    connection.Open();
                    string userID = FSystem.loggedInUser.UserName;
                    string title = Title.Text;
                    string description = Description.Text;
                    string organizerDetails = OrgDetails.Text;
                    DateTime startDate = startdate.Value;
                    DateTime endDate = enddate.Value;
                    string registrationType = free.Checked ? "Free" : "Paid";
                    decimal? ticketPrice = paid.Checked && decimal.TryParse(ticketprice.Text, out decimal price) ? price : (decimal?)null;

                    if (string.IsNullOrEmpty(eventPosterRelativePath))
                    {
                        MessageBox.Show("Please select an event poster image.");
                        return;
                    }

                    // Insert event data into the database, including the relative path for the poster
                    string query = @"INSERT INTO Events (Title, Description, OrganizerDetails, StartDate, EndDate, EventPoster, RegistrationType, TicketPrice, Creator)
                                     VALUES (@Title, @Description, @OrganizerDetails, @StartDate, @EndDate, @EventPoster, @RegistrationType, @TicketPrice, @Creator)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Title", title);
                        command.Parameters.AddWithValue("@Description", description);
                        command.Parameters.AddWithValue("@OrganizerDetails", organizerDetails);
                        command.Parameters.AddWithValue("@StartDate", startDate);
                        command.Parameters.AddWithValue("@EndDate", endDate);
                        command.Parameters.AddWithValue("@EventPoster", eventPosterRelativePath); // Save relative path
                        command.Parameters.AddWithValue("@RegistrationType", registrationType);
                        command.Parameters.AddWithValue("@TicketPrice", (object)ticketPrice ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Creator", userID);

                        command.ExecuteNonQuery();
                        MessageBox.Show("Event created successfully!");

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
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
