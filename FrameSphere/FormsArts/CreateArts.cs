using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Diagnostics.Tracing;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
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
        private int ct = 0;
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
            ct++;
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
                TextBox associatedTextBox = ((Control)sender).Tag as TextBox;
                if (associatedTextBox != null)
                {
                    associatedTextBox.Text = selectedPath;
                }

                // Load the selected image into the PictureBox
                photobox.Text = selectedPath;
                PictureBox pictureBox = sender as PictureBox;
                if (pictureBox != null)
                {
                    try
                    {
                        pictureBox.Image?.Dispose(); // Dispose previous image if any
                        pictureBox.Image = Image.FromFile(selectedPath);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error loading image: {ex.Message}");
                    }
                }
            }
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            
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

        private void RepositionAddButton()
        {
            if (artContainer.Controls.Count > 0)
            {
                // Find the last added panel
                Control lastPanel = artContainer.Controls[artContainer.Controls.Count - 1];
                add.Location = new Point(lastPanel.Location.X, lastPanel.Bottom + 10); // Adjust spacing
            }
            else
            {
                // Default position if no panels exist
                add.Location = new Point(10, 10);
            }

            // Ensure the Add button remains visible
            if (!artContainer.Controls.Contains(add))
            {
                artContainer.Controls.Add(add);
            }
        }
        private bool checkphotobox(string s)
        {
            if (string.IsNullOrWhiteSpace(s))
            {
                MessageBox.Show("Please select a photo for all art items.");
                return false;
            }
            else
            {
                return true;
            }
        }

        private void add_Click(object sender, EventArgs e)
        {
           

            // Create a new panel dynamically
            Panel newArtPanel = new Panel {
                Width = artPanel.Width,
                Height = artPanel.Height,
                
            };

            // Create a readonly textbox to hold the selected photo path
            TextBox newTextBox = new TextBox {
                Width = 289,
                Left = 9,
                ReadOnly = true,
                //Tag = "Check"
                //Text = photobox.Text // Assign the selected image path
            };
            newTextBox.ReadOnly = true;
            newTextBox.Click += (ss, o) => {
                OpenFileDialog openFileDialog = new OpenFileDialog {
                    Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp",
                    Title = "Select Art Image"
                };

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string selectedPath = openFileDialog.FileName;
                    TextBox associatedTextBox = ((Control)sender).Tag as TextBox;
                    if (associatedTextBox != null)
                    {
                        associatedTextBox.Text = selectedPath;
                        
                    }

                    // Load the selected image into the PictureBox
                    newTextBox.Text = selectedPath;
                    
                }
            };
            // Create a remove button
            Button removeButton = new Button {
                Text = "Remove",
                Left = 302,
                Size = new Size(66, 21),
                FlatStyle= FlatStyle.Standard,
                BackColor= Color.White
            };

            // Remove the "Add" button before inserting a new panel
            artContainer.Controls.Remove(add);

            // Handle the remove button click event
            removeButton.Click += (s, ev) =>
            {
                artContainer.Controls.Remove(newArtPanel);
                newArtPanel.Dispose();
                RepositionAddButton();

                ct--;
            };

            // Add controls to the panel
            newArtPanel.Controls.Add(newTextBox);
            newArtPanel.Controls.Add(removeButton);

            // Add the panel to the container
            artContainer.Controls.Add(newArtPanel);

            // Reposition the "Add" button below the last panel
            RepositionAddButton();
            ct++;
        }

        private void EnterButton_Click(object sender, EventArgs e)
        {
           
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

        private void artContainer_Paint(object sender, PaintEventArgs e)
        {

        }

        private void photobox_TextChanged(object sender, EventArgs e)
        {

        }
        private void Submit_Click_1(object sender, EventArgs e)
        {
            // Check if all the photo paths in the TextBoxes are valid
            foreach (Control control in artContainer.Controls)
            {
                if (control is Panel panel)
                {
                    TextBox photoPathBox = panel.Controls.OfType<TextBox>().FirstOrDefault();
                    if (photoPathBox != null && !checkphotobox(photoPathBox.Text))
                    {
                        return; // Exit the method if any photo path is invalid (empty or whitespace)
                    }
                }
            }
 

            try
            {
                using (SqlConnection connection = DB.Connect())
                {
                    connection.Open();

                    string userID = FSystem.loggedInUser.UserName; // Get the artist username
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
                    artCommand.Parameters.AddWithValue("@Price", (object)artPriceValue ?? DBNull.Value);
                    artCommand.Parameters.AddWithValue("@PhotoCnt", ct);

                    object result = artCommand.ExecuteScalar();
                    int artID = (result != null) ? Convert.ToInt32(result) : 0;
                    if (artID == 0)
                    {
                        MessageBox.Show("Failed to insert into Art table.");
                        return;
                    }

                    // Insert into ArtArtist table
                    string artistInsertQuery = "INSERT INTO ArtArtist (ArtId, UserName) VALUES (@ArtID, @UserName)";
                    SqlCommand artistCommand = new SqlCommand(artistInsertQuery, connection);
                    artistCommand.Parameters.AddWithValue("@ArtID", artID);
                    artistCommand.Parameters.AddWithValue("@UserName", userID);
                    artistCommand.ExecuteNonQuery();

                    // Insert into ArtPhotos table
                    foreach (Control control in artContainer.Controls)
                    {
                        if (control is Panel panel)
                        {
                            TextBox photoPathBox = panel.Controls.OfType<TextBox>().FirstOrDefault();
                            if (photoPathBox != null && !string.IsNullOrWhiteSpace(photoPathBox.Text))
                            {
                                string filePath = photoPathBox.Text;
                                string fileName = Path.GetFileName(filePath);
                                string storagePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ArtImages");
                                Directory.CreateDirectory(storagePath);

                                // Generate unique filename to prevent overwrites
                                string uniqueFileName = $"{Guid.NewGuid()}{Path.GetExtension(fileName)}";
                                string destinationPath = Path.Combine(storagePath, uniqueFileName);
                                if (!File.Exists(destinationPath))
                                {
                                    File.Copy(filePath, destinationPath);
                                }

                                string relativePath = "ArtImages/" + uniqueFileName;

                                // Insert into ArtPhotos table
                                string photoInsertQuery = "INSERT INTO ArtPhotos (ArtID, Photo) VALUES (@ArtID, @Photo)";
                                SqlCommand photoCommand = new SqlCommand(photoInsertQuery, connection);
                                photoCommand.Parameters.AddWithValue("@ArtID", artID);
                                photoCommand.Parameters.AddWithValue("@Photo", relativePath);
                                photoCommand.ExecuteNonQuery();
                            }
                            else
                            {
                                MessageBox.Show("Please select an image for all art.");
                                return;
                            }
                        }
                    }

                    MessageBox.Show("Art successfully added!");
                }
            }
            catch (SqlException a)
            {
                MessageBox.Show("Something went wrong! Try again later.", "DB Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine("DB ERROR iN SUBMITTING: " + a.Message);
                return;
            }
            catch (Exception a)
            {
                MessageBox.Show("Something went wrong! Try again later.", "Unexpected Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine("UNEXPECTED ERROR IN SUBMITTING: " + a.Message);
                return;
            }
        }
        //private void Submit_Click_1(object sender, EventArgs e)
        //{
        //    // Check if all the photo paths in the TextBoxes are valid
        //    foreach (Control control in artContainer.Controls)
        //    {
        //        if (control is Panel panel)
        //        {
        //            TextBox photoPathBox = panel.Controls.OfType<TextBox>().FirstOrDefault();
        //            if (photoPathBox != null && !checkphotobox(photoPathBox.Text))
        //            {
        //                return; // Exit the method if any photo path is invalid (empty or whitespace)
        //            }
        //        }
        //    }

        //    try
        //    {
        //        using (SqlConnection connection = DB.Connect())
        //        {
        //            connection.Open();

        //            string userID = FSystem.loggedInUser.UserName;
        //            string artTitle = arttitle.Text;
        //            string description = Description.Text;
        //            string sellingOption = free.Checked ? "Free" : "Paid";
        //            decimal? artPriceValue = paid.Checked && decimal.TryParse(artPrice.Text, out decimal price) ? price : (decimal?)null;

        //            // Insert into Art table
        //            string artInsertQuery = "INSERT INTO Art (ArtTitle, ArtDescription, SellingOption, Price, photocnt) OUTPUT INSERTED.ArtID VALUES (@Title, @Desc, @SellOption, @Price, @PhotoCnt)";
        //            SqlCommand artCommand = new SqlCommand(artInsertQuery, connection);
        //            artCommand.Parameters.AddWithValue("@Title", artTitle);
        //            artCommand.Parameters.AddWithValue("@Desc", description);
        //            artCommand.Parameters.AddWithValue("@SellOption", sellingOption);
        //            artCommand.Parameters.AddWithValue("@Price", (object)artPriceValue ?? DBNull.Value);
        //            artCommand.Parameters.AddWithValue("@PhotoCnt", ct);

        //            object result = artCommand.ExecuteScalar();
        //            int artID = (result != null) ? Convert.ToInt32(result) : 0; //eida koittheke paisos?
        //            if (artID == 0)
        //            {
        //                MessageBox.Show("Failed to insert into Art table.");
        //                return;
        //            }

        //            // Insert into ArtPhotos table
        //            foreach (Control control in artContainer.Controls)
        //            {
        //                if (control is Panel panel)
        //                {
        //                    TextBox photoPathBox = panel.Controls.OfType<TextBox>().FirstOrDefault();
        //                    if (photoPathBox != null && !string.IsNullOrWhiteSpace(photoPathBox.Text))
        //                    {
        //                        string filePath = photoPathBox.Text;
        //                        string fileName = Path.GetFileName(filePath);
        //                        string storagePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ArtImages");
        //                        Directory.CreateDirectory(storagePath);

        //                        // Generate unique filename to prevent overwrites
        //                        string uniqueFileName = $"{Guid.NewGuid()}{Path.GetExtension(fileName)}";
        //                        string destinationPath = Path.Combine(storagePath, uniqueFileName);
        //                        if (!File.Exists(destinationPath))
        //                        {
        //                            File.Copy(filePath, destinationPath);
        //                        }

        //                        string relativePath = "ArtImages/" + uniqueFileName;

        //                        // Insert into ArtPhotos table
        //                        string photoInsertQuery = "INSERT INTO ArtPhotos (ArtID, Photo) VALUES (@ArtID, @Photo)";
        //                        SqlCommand photoCommand = new SqlCommand(photoInsertQuery, connection);
        //                        photoCommand.Parameters.AddWithValue("@ArtID", artID);
        //                        photoCommand.Parameters.AddWithValue("@Photo", relativePath);
        //                        photoCommand.ExecuteNonQuery();
        //                    }
        //                    else
        //                    {
        //                        MessageBox.Show("Please select an image for all art.");
        //                        return;
        //                    }
        //                }
                       


        //            }

        //            MessageBox.Show("Art successfully added!");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Error: " + ex.Message);
        //    }
        //}



        private void paid_CheckedChanged(object sender, EventArgs e)
        {
            artPrice.Show();
        }

        private void free_CheckedChanged(object sender, EventArgs e)
        {
            artPrice.Hide();
        }
    }
}
