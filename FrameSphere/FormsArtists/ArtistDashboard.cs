using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Windows.Forms.VisualStyles;
using FrameSphere.EntityClasses;

namespace FrameSphere
{
    public partial class ArtistDashboard : Form
    {
        //featured art panel 
        private const int ImageWidth = 117;
        private const int ImageHeight = 117;
        private const int ImageSpacing = 27;
        private const int ImageShift = ImageWidth+ImageSpacing;
        private string[] ImagePaths;
        public ArtistDashboard()
        {
            InitializeComponent();
            name.Text = FSystem.loggedInUser.FullName();
            userName.Text = "@"+FSystem.loggedInUser.UserName;

            phone.Text = FSystem.loggedInUser.Phone;
            email.Text = FSystem.loggedInUser.Email;
            address.Text = FSystem.loggedInUser.Address;
            profilepic.Image = FSystem.GetImageFromPath(FSystem.loggedInUser.ProfilePic);
            
            profilepic.Image = FSystem.GetImageFromPath(FSystem.loggedInUser.ProfilePic);
            LoadArtistEvents(FSystem.loggedInUser.UserName);
            LoadStatistics();
            //LoadFeaturedPanel();
        }
        public void LoadImagePaths()
        {
            int i = 0;
            foreach (Art a in FSystem.loggedInUser.Artist.myArts)//for each artid of logged user
            {
                ImagePaths[i] = a.artPhotos[0];//store the path for the first image per artid
            }
        }
        public void AddImageBoxes()
        {
            int currentPos = 0;
            foreach(string path in  ImagePaths)
            {
                PictureBox artPic = new PictureBox() {
                    Size = new Size(ImageWidth, ImageHeight),
                    Location = new Point(currentPos, 46),
                    SizeMode = PictureBoxSizeMode.Zoom,
                    Image = Image.FromFile(path)
                };
                featuredArt_panel.Controls.Add(artPic);
                currentPos += ImageShift;
            }
        }
        //public void LoadFeaturedPanel()
        //{
        //    LoadImagePaths();
        //    AddImageBoxes();
        //}
        public void LoadStatistics()
        {
            getNumberOfArts();
            //getNumberOfArtsSold();
            getNumberOfEventsParticipated();
        }
        public void getNumberOfEventsParticipated()
        {
            try
            {
                string query = $"select count(*) eventid from artistEvent where username = '{FSystem.loggedInUser.UserName}';";
                using (SqlConnection conn = DB.Connect())
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        TotalParticipations_label.Text = cmd.ExecuteScalar().ToString();
                    }
                }
            }
            catch (Exception ex) { throw ex; }
        }
        public void getNumberOfArts()
        {
            try
            {
                string query = $"select count(*) artid from artArtist where username = '{FSystem.loggedInUser.UserName}';";
                using (SqlConnection conn = DB.Connect())
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        TotalArts_label.Text = cmd.ExecuteScalar().ToString();
                    }
                }
            }
            catch (Exception ex) { throw ex; }
        }
        private void CreateArt_Click(object sender, EventArgs e)
        {
            CreateArts createArts = new CreateArts();
            this.Hide();
            createArts.Show();
        }
        private void LoadArtistEvents(string artistUsername)
        {
            associatedEvents_panel.Controls.Clear(); // Clear existing controls
            associatedEvents_panel.Controls.Add(noitem); // Add the "no items" label to the panel
            noitem.Visible = false; // Hide "no items" initially

            // Define the query to fetch only the events where the artist is added
            string query = "SELECT E.EventID, E.EventTitle, E.Description, E.EndDate, E.EventPoster FROM Events E INNER JOIN ArtistEvent AE ON E.EventID = AE.EventId WHERE AE.UserName = @ArtistUsername";

            using (SqlConnection connection = DB.Connect())
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ArtistUsername", artistUsername);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (!reader.HasRows)
                        {
                            noitem.Visible = true; // Show "no items" label if no events are found
                            return;
                        }

                        while (reader.Read())
                        {
                            // Extract event data with null-check handling
                            int eventId = Convert.ToInt32(reader["EventID"]);
                            string title = reader["EventTitle"].ToString();
                            string description = reader["Description"] != DBNull.Value ? reader["Description"].ToString() : "No description available";
                            DateTime? endDate = reader["EndDate"] != DBNull.Value ? (DateTime?)reader["EndDate"] : null;
                            string eventPosterPath = reader["EventPoster"] != DBNull.Value ? reader["EventPoster"].ToString() : null;

                            // Format date or provide default message
                            string formattedEndDate = endDate.HasValue ? endDate.Value.ToString("dd-MM-yyyy HH:mm:ss") : "No end date provided";

                            // Load the event poster image
                            Image eventPosterImage = !string.IsNullOrEmpty(eventPosterPath)
                                ? FSystem.GetImageFromPath(eventPosterPath) // Load the image from path
                                : FrameSphere.Properties.Resources._10_3__thumb; // Default placeholder image

                            // Create an event box for the current event
                            CreateEventBox(title, description, formattedEndDate, eventPosterImage, eventId);
                        }
                    }
                }
            }
        }

        private void CreateEventBox(string title, string description, string time, Image eventImage, int eventId)
        {
            int panelWidth = associatedEvents_panel.Width - 40;
            int panelHeight = 120;

            Panel boxPanel = new Panel {
                Size = new Size(panelWidth, panelHeight),
                BackColor = Color.LightBlue,
                BorderStyle = BorderStyle.FixedSingle,
                Margin = new Padding(10)
            };

            PictureBox pictureBox = new PictureBox {
                Size = new Size(100, 100),
                Location = new Point(10, 10),
                Image = eventImage,
                SizeMode = PictureBoxSizeMode.StretchImage
            };

            Label titleLabel = new Label {
                Text = title,
                Font = new Font("Arial", 12, FontStyle.Bold),
                Location = new Point(120, 10),
                AutoSize = false,
                Size = new Size(panelWidth - 230, 20),
                ForeColor = Color.Black
            };

            Label descriptionLabel = new Label {
                Text = description,
                Font = new Font("Arial", 10),
                Location = new Point(120, 40),
                AutoSize = false,
                Size = new Size(panelWidth - 230, 40),
                ForeColor = Color.Gray
            };

            Label timeLabel = new Label {
                Text = time,
                Font = new Font("Arial", 10, FontStyle.Bold),
                ForeColor = Color.Red,
                Location = new Point(120, 90),
                AutoSize = true
            };

            Button enterButton = new Button {
                Text = "Enter",
                BackColor = Color.Blue,
                ForeColor = Color.White,
                Size = new Size(80, 30),
                Location = new Point(panelWidth - 90, 40),
                FlatStyle = FlatStyle.Flat,
                Tag = eventId // Store the event ID in the button's Tag property
            };
            enterButton.Click += EnterButton_Click; // Attach the click event handler

            boxPanel.Controls.Add(pictureBox);
            boxPanel.Controls.Add(titleLabel);
            boxPanel.Controls.Add(descriptionLabel);
            boxPanel.Controls.Add(timeLabel);
            boxPanel.Controls.Add(enterButton);

            boxPanel.Dock = DockStyle.Top;

            associatedEvents_panel.Controls.Add(boxPanel);
        }

        private void EnterButton_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            if (button != null && button.Tag != null)
            {
                if (int.TryParse(button.Tag.ToString(), out int eventId))
                {
                    Event_page eventPage = new Event_page(eventId); // Pass the event ID to the EventPage
                    this.Hide();
                    eventPage.Show(); // Show the EventPage
                }
                else
                {
                    MessageBox.Show("Invalid Event ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void ArtistDashboard_Load(object sender, EventArgs e)
        {
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void artistboard_Click(object sender, EventArgs e)
        {

        }

        private void button14_Click(object sender, EventArgs e)
        {

        }

        private void returnDashBoard_button_Click(object sender, EventArgs e)
        {
            this.Hide();
            UserDashBoard user = new UserDashBoard();
            user.Show();   
        }

        private void ArtistDash_button_Click(object sender, EventArgs e)
        {
            MessageBox.Show("You are currently viewing Artist Dashboard");
        }

        private void adminDash_button_Click(object sender, EventArgs e)
        {
            if (FSystem.loggedInUser.isAdmin)
            {
                this.Hide();
                Admin_dashboard ad = new Admin_dashboard();
                ad.Show();
            }
        }

        private void editProfile_button_Click(object sender, EventArgs e)
        {
            this.Hide();
            Edit_Profile ep = new Edit_Profile(FSystem.loggedInUser.UserName);
            ep.Show();
        }

        private void facebook_pic_Click(object sender, EventArgs e)
        {
            try
            {
                string fb_URL = FSystem.loggedInUser.Facebook;
                if(fb_URL!=null)
                {
                    Process.Start(new ProcessStartInfo {
                        FileName = fb_URL,
                        UseShellExecute = true
                    });
                }
                else
                {
                    Process.Start(new ProcessStartInfo {
                        FileName = "#",
                        UseShellExecute = true
                    });
                }
                
            }
            catch(Exception ex)
            {
                MessageBox.Show($"An error occurred:{ex.Message}");
            }  
        }

        private void instagram_link_Click(object sender, EventArgs e)
        {
            try
            {
                string insta_URL = FSystem.loggedInUser.Instagram;
                if (insta_URL != null)
                {
                    Process.Start(new ProcessStartInfo {
                        FileName = insta_URL,
                        UseShellExecute = true
                    });
                }
                else
                {
                    Process.Start(new ProcessStartInfo {
                        FileName = "#",
                        UseShellExecute = true
                    });
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred:{ex.Message}");
            }
        }

        private void pinterest_link_Click(object sender, EventArgs e)
        {

            try
            {
                string pint_URL = FSystem.loggedInUser.Pinterest;
                if (pint_URL != null)
                {
                    Process.Start(new ProcessStartInfo {
                        FileName = pint_URL,
                        UseShellExecute = true
                    });
                }
                else
                {
                    Process.Start(new ProcessStartInfo {
                        FileName = "#",
                        UseShellExecute = true
                    });
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred:{ex.Message}");
            }

        }

        private void website_link_Click(object sender, EventArgs e)
        {

            try
            {
                string web_URL = FSystem.loggedInUser.Website;
                if (web_URL != null)
                {
                    Process.Start(new ProcessStartInfo {
                        FileName = web_URL,
                        UseShellExecute = true
                    });
                }
                else
                {
                    Process.Start(new ProcessStartInfo {
                        FileName = "#",
                        UseShellExecute = true
                    });
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred:{ex.Message}");
            }
        }

        private void TotalArts_label_Click(object sender, EventArgs e)
        {

        }

        private void Logout_Click(object sender, EventArgs e)
        {
            FSystem.loggedInUser.Logout(this);
        }
    }
}
