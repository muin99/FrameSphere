using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;
using FrameSphere.EntityClasses;
using static System.Net.Mime.MediaTypeNames;

namespace FrameSphere
{
    public partial class Event_page : Form
    {
        public Event currentEvent;

        public Event_page(int eventId)
        {
            InitializeComponent();
            
            // Load the event data
            currentEvent = new Event(eventId);
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
