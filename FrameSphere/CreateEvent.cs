using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrameSphere
{
    public partial class CreateEvent : Form
    {
        private string imagePath;
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


        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog {
                Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp",
                Title = "Select Event Poster"
            };
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                imagePath = openFileDialog.FileName;
                poster.Text = imagePath;
                byte[] imageBytes = File.ReadAllBytes(imagePath);
                using (MemoryStream ms = new MemoryStream(imageBytes))
                {
                    pictureBox.Image = System.Drawing.Image.FromStream(ms);
                }
            }
        }



        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void CreateEvent_Load(object sender, EventArgs e)
        {

        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (free.Checked)
            {
                label8.Visible = false;
                ticketprice.Visible = false;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = DB.Connect())
                {
                    connection.Open();
                    string UserID = FSystem.loggedInUser.UserName;
                    string title = Title.Text;
                    string description = Description.Text;
                    string organizerDetails = OrgDetails.Text;
                    DateTime startDate = startdate.Value;
                    DateTime endDate = enddate.Value;
                    string registrationType = free.Checked ? "Free" : "Paid";
                    decimal? ticketPrice = paid.Checked && decimal.TryParse(ticketprice.Text, out decimal price) ? price : (decimal?)null;

                    if (string.IsNullOrEmpty(imagePath))
                    {
                        MessageBox.Show("Please select an event poster image.");
                        return;
                    }

                    byte[] imageBytes = File.ReadAllBytes(imagePath);

                    string query = @"INSERT INTO Events (Title, Description, OrganizerDetails, StartDate, EndDate, EventPoster, RegistrationType, TicketPrice, Creator)
                                     VALUES (@Title, @Description, @OrganizerDetails, @StartDate, @EndDate, @EventPoster, @RegistrationType, @TicketPrice, @Creator)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Title", title);
                        command.Parameters.AddWithValue("@Description", description);
                        command.Parameters.AddWithValue("@OrganizerDetails", organizerDetails);
                        command.Parameters.AddWithValue("@StartDate", startDate);
                        command.Parameters.AddWithValue("@EndDate", endDate);
                        command.Parameters.AddWithValue("@EventPoster", imageBytes);
                        command.Parameters.AddWithValue("@RegistrationType", registrationType);
                        command.Parameters.AddWithValue("@TicketPrice", (object)ticketPrice ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Creator", UserID);
                        command.ExecuteNonQuery();
                        MessageBox.Show("Event created successfully!");

                        Event_page eventPage = new Event_page(title);
                        eventPage.LoadEventData(title, description, organizerDetails, startDate, endDate, registrationType, ticketPrice, imageBytes);
                        this.Hide();
                        eventPage.StartPosition = FormStartPosition.CenterParent;
                        eventPage.ShowDialog();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }



        private void startdate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void paid_CheckedChanged(object sender, EventArgs e)
        {
            if (paid.Checked)
            {
                label8.Visible = true;
                ticketprice.Visible = true;
            }
        }

        private void free_CheckedChanged(object sender, EventArgs e)
        {
            if (free.Checked)
            {
                label8.Visible = false;
                ticketprice.Visible = false;
            }
        }
    }

}
