using System;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;
using FrameSphere.EntityClasses;
using FrameSphere.FormsEvents;
using static System.Net.Mime.MediaTypeNames;

namespace FrameSphere
{
    public partial class Event_page : Form
    {
        public Event currentEvent;

        public Event_page(int eventId)
        {
            currentEvent = new Event(eventId);
            InitializeComponent();

            if (!checkEntrance())
            {
                this.Hide();
                // Return early to prevent loading the rest of the form
                return;
            }
            title.Text = currentEvent.EventTitle;
            organizer.Text = currentEvent.EventDescription;
            starts.Text = currentEvent.StartsAt.ToString();
            ends.Text = currentEvent.EndsAt.ToString();
            price.Text = (currentEvent.RegistrationType == "Free") ? "Free" : currentEvent.TicketPrice.ToString();
            cover.Image = FSystem.GetImageFromPath(currentEvent.PosterImage);


            // Load the event data AFTER entrance check
            title.Text = currentEvent.EventTitle;
            loadImages(currentEvent.EventID);
        }

        private bool artistOfTheEvent()
        {
            using (SqlConnection con = DB.Connect())
            {
                con.Open();
                string query = "SELECT COUNT(*) FROM ArtistEvent WHERE username = @username AND eventid = @eventid";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@username", FSystem.loggedInUser.UserName);
                cmd.Parameters.AddWithValue("@eventid", currentEvent.EventID);

                int res = Convert.ToInt32(cmd.ExecuteScalar());
                return res > 0;
            }
        }

        private bool validVisitor()
        {
            using (SqlConnection con = DB.Connect())
            {
                con.Open();
                string query = "SELECT COUNT(*) FROM TicketPurchases WHERE username = @username AND eventid = @eventid";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@username", FSystem.loggedInUser.UserName);
                cmd.Parameters.AddWithValue("@eventid", currentEvent.EventID);

                int res = Convert.ToInt32(cmd.ExecuteScalar());
                return res > 0;
            }
        }

        private bool checkEntrance()
        {
            if (FSystem.loggedInUser.isAdmin || artistOfTheEvent())
            {
                //return true; // Admins and event artists have access
            }

            if (currentEvent.StartsAt > DateTime.Now)
            {
                this.Hide();
                WaitingPage waitingPage = new WaitingPage(currentEvent);
                waitingPage.FormClosed += (s, e) => this.Show(); // Show Event Page after Waiting Page is closed
                waitingPage.Show();
                return false;
            }

            if (currentEvent.RegistrationType == "Free")
            {
                return true;
            }

            if (currentEvent.RegistrationType == "Paid" && !validVisitor())
            {
                this.Hide();
                BuyTicket buyTicketPage = new BuyTicket(currentEvent);
                buyTicketPage.FormClosed += (s, e) => this.Show(); // Show Event Page after Buy Ticket Page is closed
                buyTicketPage.Show();
                return false;
            }

            return true;
        }

        public void loadImages(int eventid)
        {
            using (SqlConnection conn = DB.Connect())
            {
                conn.Open();

                string query = @"
            SELECT A.ArtID, A.ArtTitle, AP.Photo 
            FROM ArtEvent AE
            JOIN Art A ON AE.ArtID = A.ArtID
            LEFT JOIN ArtPhotos AP ON A.ArtID = AP.ArtID
            WHERE AE.EventID = @eventid";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@eventid", eventid);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    int artID = reader.GetInt32(0); // ArtID
                    string title = reader.IsDBNull(1) ? "Untitled" : reader.GetString(1); // ArtTitle
                    string photoPath = reader.IsDBNull(2) ? "default.jpg" : reader.GetString(2); // Photo

                    AddDynamicPanel(artID, title, photoPath);
                }
            }
        }

        public void AddDynamicPanel(int artid, string title, string path)
        {
            Panel panel = new Panel();
            panel.Size = new Size(150, 200);  // Set panel size
            panel.BorderStyle = BorderStyle.FixedSingle;

            // Create PictureBox
            PictureBox pictureBox = new PictureBox();
            pictureBox.Size = new Size(140, 140); // Adjust size
            pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox.Image = FSystem.GetImageFromPath(path);
            pictureBox.Location = new Point(5, 5); // Position inside panel

            // Create Label
            Label label = new Label();
            label.Text = title;
            label.Size = new Size(140, 30);
            label.TextAlign = ContentAlignment.MiddleCenter;
            label.Location = new Point(5, 150);

            // Add controls to panel
            panel.Controls.Add(pictureBox);
            panel.Controls.Add(label);

            panel.Click += (s, e) => Panel_Click(s, e, artid);
            pictureBox.Click += (s, e) => Panel_Click(s, e, artid);
            label.Click += (s, e) => Panel_Click(s, e, artid);

            // Add panel to FlowLayoutPanel
            imagescontainer.Controls.Add(panel);

        }

        private void Panel_Click(object sender, EventArgs e, int artid)
        {
            ArtDisplayForm a = new ArtDisplayForm(artid);
            a.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Navigate back to the User Dashboard
            this.Hide();
            UserDashBoard userDashBoard = new UserDashBoard();
            userDashBoard.Show();
        }

        private void manage_Click(object sender, EventArgs e)
        {
            this.Hide();
            ManageEvents mn = new ManageEvents(currentEvent.EventID);
            //Application.Run(new ManageEvents("28"));
            mn.Show();
        }
    }
}
