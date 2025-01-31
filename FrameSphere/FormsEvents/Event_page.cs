using System;
using System.Data.SqlClient;
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

        public bool artistOfTheEvent()
        {
            using (SqlConnection con = DB.Connect())
            {
                con.Open();
                string q = $"select count(*) from ArtistEvent where username ='{FSystem.loggedInUser.UserName}' and " +
                    $"eventid = {currentEvent.EventID}";
                SqlCommand cmd = new SqlCommand(q, con);
                int res = Int32.Parse(cmd.ExecuteScalar().ToString());
                if (res > 0)
                {
                    return true;
                }
                else { return false; }
            }
        }
        public bool validVisitor()
        {
            using (SqlConnection con = DB.Connect()) { 
                con.Open();
                string q = $"select count(*) from TicketPurchases where username = '{FSystem.loggedInUser.UserName}' and" +
                    $" eventid = '{currentEvent.EventID}'";
                SqlCommand cmd = new SqlCommand (q, con);
                int res = Int32.Parse(cmd.ExecuteScalar().ToString());
                if (res > 0) {
                    return true;
                }
                else { return false; }
            }
        }

        public void checkEntrance()
        {
            if (FSystem.loggedInUser.isAdmin)
            {
                return;
            }
            if (artistOfTheEvent())
            {
                return;
            }
            if (currentEvent.StartsAt > System.DateTime.Now)
            {
                this.Hide();
                WaitingPage rr = new WaitingPage(currentEvent);
                rr.Show();
            }
            else if (currentEvent.RegistrationType == "Free") {
                return;
            }
            else if(currentEvent.RegistrationType == "Paid")
            {
                this.Hide();
                BuyTicket rr = new BuyTicket(currentEvent);
                rr.Show();
            }

        }
        public Event_page(int eventId)

        {
            currentEvent = new Event(eventId);

            checkEntrance();


            InitializeComponent();
            
            // Load the event data
            
            title.Text = currentEvent.EventTitle;

            loadImages(currentEvent.EventID);
            
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
