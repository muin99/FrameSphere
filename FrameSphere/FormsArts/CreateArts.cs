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
//using static System.Windows.Forms.VisualStyles.VisualStyleElement;
//using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace FrameSphere
{
    public partial class CreateArts : Form
    {
        private string imagePath;
        public CreateArts()
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

        }


        private List<string> photoPaths = new List<string>();


        private void PhotoBox_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog {
                Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp",
                Title = "Select Art Image"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string selectedPath = openFileDialog.FileName;
                ((TextBox)((Control)sender).Tag).Text = selectedPath;
            }
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            Panel newArtPanel = new Panel {
                Width = artPanel.Width,
                Height = artPanel.Height,
                BorderStyle = BorderStyle.FixedSingle // Optional: Adds visibility
            };

            TextBox newTextBox = new TextBox { Width = 200 };
            Button removeButton = new Button { Text = "Remove", Left = 210 };

            PictureBox newPhotoBox = new PictureBox {
                Width = 50,
                Height = 50,
                BackColor = System.Drawing.Color.Gray,
                Left = 270,
                Tag = newTextBox
            };
            newPhotoBox.Click += PhotoBox_Click;

            // Make sure remove button correctly removes its parent panel
            removeButton.Click += (s, ev) =>
            {
                artContainer.Controls.Remove(newArtPanel);
                newArtPanel.Dispose();
            };

            newArtPanel.Controls.Add(newTextBox);
            newArtPanel.Controls.Add(removeButton);
            newArtPanel.Controls.Add(newPhotoBox);

            artContainer.Controls.Add(newArtPanel);
        }



        private void Submit_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = DB.Connect())
                {
                    connection.Open();
                    string userID = FSystem.loggedInUser.UserName;
                    string artTitle = arttitle.Text;
                    string description = Description.Text;
                    string sellingOption = free.Checked ? "Free" : "Paid";
                    decimal? artPriceValue = paid.Checked && decimal.TryParse(artPrice.Text, out decimal price) ? price : (decimal?)null;

                    // Insert into Art table
                    string artInsertQuery = "INSERT INTO Art (ArtTitle, ArtDescription, SellingOption, Price, photocnt) OUTPUT INSERTED.ArtID VALUES (@Title, @Desc, @SellOption, @Price, @PhotoCnt)";
                    SqlCommand artCommand = new SqlCommand(artInsertQuery, connection);
                    artCommand.Parameters.AddWithValue("@Title", artTitle);
                    artCommand.Parameters.AddWithValue("@Desc", description);
                    artCommand.Parameters.AddWithValue("@SellOption", sellingOption);
                    artCommand.Parameters.AddWithValue("@Price", (object)artPrice ?? DBNull.Value);
                    artCommand.Parameters.AddWithValue("@PhotoCnt", artContainer.Controls.Count);

                    int artID = (int)artCommand.ExecuteScalar();

                    // Insert into ArtPhotos table
                    foreach (Control control in artContainer.Controls)
                    {
                        if (control is Panel panel)
                        {
                            TextBox photoPathBox = panel.Controls[0] as TextBox;
                            if (!string.IsNullOrWhiteSpace(photoPathBox.Text))
                            {
                                string filePath = photoPathBox.Text;
                                string fileName = Path.GetFileName(filePath);
                                string storagePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ArtImages");
                                Directory.CreateDirectory(storagePath);
                                string destinationPath = Path.Combine(storagePath, fileName);
                                File.Copy(filePath, destinationPath, true);

                                string relativePath = Path.Combine("ArtImages", fileName);
                                string photoInsertQuery = "INSERT INTO ArtPhotos (ArtID, Photo) VALUES (@ArtID, @Photo)";
                                SqlCommand photoCommand = new SqlCommand(photoInsertQuery, connection);
                                photoCommand.Parameters.AddWithValue("@ArtID", artID);
                                photoCommand.Parameters.AddWithValue("@Photo", relativePath);
                                photoCommand.ExecuteNonQuery();
                            }
                        }
                    }

                    MessageBox.Show("Art successfully added!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
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
        private void EnterButton_Click(object sender, EventArgs e)
        {
            //Button button = sender as Button;
            //if (button != null && button.Tag != null)
            //{
            //    int eventId = button.Tag.ToString();
            //    Event_page eventPage = new Event_page(eventId); // Pass the event ID to the EventPage
            //    this.Hide();
            //    eventPage.Show(); // Show the EventPage
            //}
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

    }
}
