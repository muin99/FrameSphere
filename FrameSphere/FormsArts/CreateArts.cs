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
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FrameSphere.EntityClasses;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace FrameSphere
{
    public partial class CreateArts : Form
    {
        private string imagePath;
        public CreateArts()
        {
            InitializeComponent();

            FSystem.loggedInUser.loadUser();

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


        }

        private void EnterButton_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            if (button != null && button.Tag != null)
            {
                string eventId = button.Tag.ToString();
                Event_page eventPage = new Event_page(eventId); // Pass the event ID to the EventPage
                this.Hide();
                eventPage.Show(); // Show the EventPage
            }
        }



        private void button10_Click(object sender, EventArgs e)
        {
            this.Hide();
            CreateEvent createEvent = new CreateEvent();
            createEvent.ShowDialog(this);

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
        private List<byte[]> selectedPhotos = new List<byte[]>();

        [Obsolete]
        private void Submit_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = DB.Connect())
                {
                    connection.Open();
                    string UserID = FSystem.loggedInUser.UserName;
                    string artTitle = arttitle.Text;
                    string description = Description.Text;
                    string SellingOption = free.Checked ? "Free" : "Paid";
                    decimal? artprice = paid.Checked && decimal.TryParse(artPrice.Text, out decimal price) ? price : (decimal?)null;

                    if (string.IsNullOrEmpty(imagePath))
                    {
                        MessageBox.Show("Please select an Art Photo.");
                        return;
                    }

                    byte[] imageBytes = File.ReadAllBytes(imagePath);

                    // Insert into Art table
                    string artQuery = @"INSERT INTO Art (ArtTitle, ArtDescription, SellingOption, Price)
                                VALUES (@ArtTitle, @ArtDescription, @SellingOption, @Price);
                                SELECT SCOPE_IDENTITY();"; // Get the inserted ArtId

                    int artId;
                    using (SqlCommand command = new SqlCommand(artQuery, connection))
                    {
                        command.Parameters.AddWithValue("@ArtTitle", artTitle);
                        command.Parameters.AddWithValue("@ArtDescription", description);
                        command.Parameters.AddWithValue("@SellingOption", SellingOption);
                        command.Parameters.AddWithValue("@Price", (object)artprice ?? DBNull.Value);

                        artId = Convert.ToInt32(command.ExecuteScalar()); // Get the newly inserted ArtId
                    }

                    // Insert into ArtArtist table
                    string artArtistQuery = @"INSERT INTO ArtArtist (ArtId, UserName)
                                      VALUES (@ArtId, @UserName)";
                    using (SqlCommand command = new SqlCommand(artArtistQuery, connection))
                    {
                        command.Parameters.AddWithValue("@ArtId", artId);
                        command.Parameters.AddWithValue("@UserName", UserID);
                        command.ExecuteNonQuery();
                    }

                    // Insert into ArtPhotos table (assuming multiple photos)
                    string artPhotosQuery = @"INSERT INTO ArtPhotos (ArtId, Photo)
                          VALUES (@ArtId, @Photo)";
                    foreach (var photo in selectedPhotos) // Loop through selected photos
                    {
                        using (SqlCommand command = new SqlCommand(artPhotosQuery, connection))
                        {
                            command.Parameters.AddWithValue("@ArtId", artId); // Add ArtId parameter
                            command.Parameters.Add("@Photo", SqlDbType.VarBinary).Value = photo; // Add Photo parameter with explicit type
                            command.ExecuteNonQuery();
                        }
                    }

                    MessageBox.Show("Art created successfully!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void photobtn_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Multiselect = true; // Enable multi-selection
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    selectedPhotos.Clear(); // Clear any previously selected photos
                    imagePath = openFileDialog.FileName;
                    photobox.Text = string.Join(";", openFileDialog.FileNames); // Display all selected paths

                    foreach (string filePath in openFileDialog.FileNames)
                    {
                        byte[] imageBytes = File.ReadAllBytes(filePath); // Read file as byte array
                        selectedPhotos.Add(imageBytes); // Add to the list

                        using (MemoryStream ms = new MemoryStream(imageBytes))
                        {
                            // Optionally display each image in the PictureBox (replace as needed)
                            //pictureBox.Image = System.Drawing.Image.FromStream(ms);
                        }
                    }

                    MessageBox.Show($"{selectedPhotos.Count} photos selected successfully!");
                }
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

        private void add_Click(object sender, EventArgs e)
        {

        }
    }
}
