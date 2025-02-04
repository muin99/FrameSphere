using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Diagnostics.Tracing;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FrameSphere.EntityClasses;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace FrameSphere
{
    public partial class UserDashBoard : Form
    {
        string Title;
        bool previous = false;
        bool current = false;
        bool upcoming = false;


        public UserDashBoard()
        {

            InitializeComponent();

            //FSystem.loggedInUser.loadUser();
            name.Text = FSystem.loggedInUser.FullName();
            userName.Text = "@"+FSystem.loggedInUser.UserName;

            phone.Text = FSystem.loggedInUser.Phone;
            email.Text = FSystem.loggedInUser.Email;
            address.Text = FSystem.loggedInUser.Address;
            profilepic.Image = FSystem.GetImageFromPath(FSystem.loggedInUser.ProfilePic);

            if (FSystem.loggedInUser.isAdmin)
            {
                adminDashboard.Visible = true;
            }

            LoadEventBoxes();


        }
        private void LoadEventBoxes(string searchQuery = "" )
        {
            eventspanel.Controls.Clear(); // Clear existing controls
            eventspanel.Controls.Add(noitem); // Add the "no items" label to the panel
            noitem.Visible = false; // Hide "no items" initially

            // Define the query, with or without a search filter
            string query = string.IsNullOrEmpty(searchQuery) ? "SELECT EventId, TicketPrice, RegistrationType, EventTitle, Description, StartDate, EndDate, EventPoster FROM Events ORDER BY CASE WHEN EndDate < GETDATE() THEN 2 WHEN StartDate > GETDATE() THEN 0 ELSE 1 END, StartDate ASC" : "SELECT EventId,TicketPrice,RegistrationType, EventTitle, Description, StartDate, EndDate, EventPoster FROM Events WHERE EventTitle LIKE @SearchQuery ORDER BY CASE WHEN EndDate < GETDATE() THEN 2 WHEN StartDate > GETDATE() THEN 0 ELSE 1 END, StartDate ASC";

            using (SqlConnection connection = DB.Connect())
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    if (!string.IsNullOrEmpty(searchQuery))
                    {
                        // Format the search query to allow fuzzy matching
                        string formattedQuery = string.Join("%", searchQuery.ToCharArray()) + "%";
                        command.Parameters.AddWithValue("@SearchQuery", "%" + formattedQuery);
                    }

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
                            int eventId = Convert.ToInt32(reader["EventId"]);
                            string ticketPrice =reader["TicketPrice"].ToString();
                            string registrationType = reader["RegistrationType"].ToString();
                            string title = reader["EventTitle"].ToString();
                            string description = reader["Description"] != DBNull.Value ? reader["Description"].ToString() : "No description available";
                            DateTime endDate = reader["EndDate"] != DBNull.Value ? (DateTime)reader["EndDate"]:DateTime.Now;
                            DateTime StartDate = reader["StartDate"] != DBNull.Value ? (DateTime)reader["StartDate"]:DateTime.Now ;
                            string eventPosterPath = reader["EventPoster"] != DBNull.Value ? reader["EventPoster"].ToString() : null;

                            // Format date or provide default message
                            //string formattedEndDate = endDate.HasValue ? endDate.Value.ToString("dd-MM-yyyy HH:mm:ss") : "No end date provided";

                            // Load the event poster image
                            Image eventPosterImage = !string.IsNullOrEmpty(eventPosterPath)
                                ? FSystem.GetImageFromPath(eventPosterPath) // Load the image from path
                                : FrameSphere.Properties.Resources._10_3__thumb; // Default placeholder image

                            if (previous && endDate < DateTime.Now) {
                                CreateEventBox(title, description, endDate, StartDate, eventPosterImage, eventId, ticketPrice , registrationType);
                            }
                            if (current && StartDate < DateTime.Now && endDate > DateTime.Now)
                            {
                                CreateEventBox(title, description, endDate, StartDate, eventPosterImage, eventId, ticketPrice, registrationType);
                            }
                            if (upcoming &&  StartDate > DateTime.Now)
                            {
                                CreateEventBox(title, description, endDate, StartDate, eventPosterImage, eventId, ticketPrice, registrationType);
                            }
                            if(!previous && !current && !upcoming)
                            {
                                CreateEventBox(title, description, endDate, StartDate, eventPosterImage, eventId, ticketPrice, registrationType);
                            }
                            // Create an event box for the current event
                            
                        }
                    }
                }
            }
        }



        private void CreateEventBox(string title, string description, DateTime endDate, DateTime StartDate, Image eventImage, int eventId, string ticketPrice, string type)
        {
            int panelWidth = eventspanel.Width - 40;
            int panelHeight = 120;

            Panel boxPanel = new Panel {
                Size = new Size(panelWidth, panelHeight),
                BackColor = Color.LightGreen,
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
                //Text = endDate.ToString(),
                Font = new Font("Arial", 10, FontStyle.Bold),
                ForeColor = Color.Red,
                Location = new Point(120, 90),
                AutoSize = true
            };

            Button enterButton = new Button {
                Text = "Enter",
                BackColor = Color.Green,
                ForeColor = Color.White,
                Size = new Size(80, 30),
                Location = new Point(panelWidth - 90, 40),
                FlatStyle = FlatStyle.Flat,
                Tag = eventId // Store the event ID in the button's Tag property
            };

            Label priceLabel = new Label {
                //Text = endDate.ToString(),
                Font = new Font("Arial", 10, FontStyle.Bold),
                ForeColor = Color.Red,
                Location = new Point(panelWidth - 90, 90),
                AutoSize = true,
                Text = (type!="Free") ? ticketPrice.ToString() : "Free"
            };



            Timer eventTimer = new Timer();
            eventTimer.Interval = 1000; // 1 second interval
            eventTimer.Tick += (sender, e) =>
            {
                DateTime now = DateTime.Now;
                TimeSpan remainingTime = StartDate - now;

                if (remainingTime.TotalSeconds > 0) // Event not started yet
                {
                    timeLabel.Text = $"Starts in: {remainingTime.Days}d {remainingTime.Hours:D2}h {remainingTime.Minutes:D2}m {remainingTime.Seconds:D2}s";
                }
                else if (now >= StartDate && now < endDate) // Event started but not ended
                {
                    TimeSpan remainingUntilEnd = endDate - now;
                    timeLabel.Text = $"Ends in: {remainingUntilEnd.Days}d {remainingUntilEnd.Hours:D2}h {remainingUntilEnd.Minutes:D2}m {remainingUntilEnd.Seconds:D2}s";
                }
                else // Event finished
                {
                    timeLabel.Text = "Event Finished!";
                    eventTimer.Stop(); // Stop timer since the event is over
                }
            };

            eventTimer.Start(); // Start the timer

            enterButton.Click += EnterButton_Click; // Attach the click event handler

            boxPanel.Controls.Add(pictureBox);
            boxPanel.Controls.Add(titleLabel);
            boxPanel.Controls.Add(descriptionLabel);
            boxPanel.Controls.Add(timeLabel);
            boxPanel.Controls.Add(enterButton);
            boxPanel.Controls.Add(priceLabel);

            boxPanel.Dock = DockStyle.Top;

            eventspanel.Controls.Add(boxPanel);
        }


        private void EnterButton_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            if (button != null && button.Tag != null)
            {
                if (int.TryParse(button.Tag.ToString(), out int eventId)) { 

                    this.Hide();
                    Event_page eventPage = new Event_page(eventId); // Pass the event ID to the EventPage
                    
                    //eventPage.Show(); // Show the EventPage dorkar nai
                }
                else
                {
                    MessageBox.Show("Invalid Event ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }





        private void button10_Click(object sender, EventArgs e)
        {
            this.Hide();
            CreateEvent createEvent = new CreateEvent();
            createEvent.ShowDialog(this);

        }


        private void button11_Click(object sender, EventArgs e)
        {
            //this.Hide();
            //ManageEvents me = new ManageEvents();
            //me.Show();
        }

        private void button14_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Edit_Profile edit_Profile = new Edit_Profile(FSystem.loggedInUser.UserName);
            edit_Profile.Show();
        }

        private void Logout_Click(object sender, EventArgs e)
        {
            FSystem.loggedInUser.Logout(this);
        }



        private void textBox1_TextChanged_2(object sender, EventArgs e)
        {
            LoadEventBoxes(textBox1.Text);
        }

        private void adminDashboard_Click(object sender, EventArgs e)
        {
            this.Hide();
            Admin_dashboard admin_Dashboard = new Admin_dashboard();
            admin_Dashboard.Show();
        }

        private void artistboard_Click(object sender, EventArgs e)
        {
            if (FSystem.loggedInUser.isArtist)
            {
                this.Hide();
                ArtistDashboard artistDashboard = new ArtistDashboard();
                artistDashboard.Show();
            }
            else
            {
                this.Hide();
                ApplyForArtist applyForArtist = new ApplyForArtist();
                applyForArtist.Show();
            }
        }

        private void facebook_pic_Click(object sender, EventArgs e)
        {
            try
            {
                string fb_URL = FSystem.loggedInUser.Facebook;
                if (fb_URL != null)
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
            catch (Exception ex)
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

        private void previousbtn_Click(object sender, EventArgs e)
        {
            if (previous)
            {
                previous = false;
                previousbtn.BackColor = Color.White;
                previousbtn.ForeColor = Color.ForestGreen;
            }
            else
            {
                previous = true;
                previousbtn.BackColor = Color.ForestGreen;
                previousbtn.ForeColor = Color.White;
            }
            LoadEventBoxes();
        }

        private void currentbtn_Click(object sender, EventArgs e)
        {
            if (current)
            {
                current = false;
                currentbtn.BackColor = Color.White;
                currentbtn.ForeColor = Color.ForestGreen;
            }
            else
            {
                current = true;
                currentbtn.BackColor = Color.ForestGreen;
                currentbtn.ForeColor = Color.White;
            }
            LoadEventBoxes();
        }

        private void upcomingbtn_Click(object sender, EventArgs e)
        {
            if (upcoming)
            {
                upcoming = false;
                upcomingbtn.BackColor = Color.White;
                upcomingbtn.ForeColor = Color.ForestGreen;
            }
            else
            {
                upcoming = true;
                upcomingbtn.BackColor = Color.ForestGreen;
                upcomingbtn.ForeColor = Color.White;
            }
            LoadEventBoxes();
        }
    }
}
