using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace FrameSphere
{
    public partial class ManageArt : Form
    {
        private int artID;
        private int ct = 0;

        public ManageArt(int artID)
        {
            InitializeComponent();
            this.artID = artID;
            //LoadUserProfile();
            LoadArtData();
        }

        //private void loaduserprofile()
        //{
        //    name.text = fsystem.loggedinuser.fullname();
        //    username.text = "@" + fsystem.loggedinuser.username;
        //    phone.text = fsystem.loggedinuser.phone;
        //    email.text = fsystem.loggedinuser.email;
        //    address.text = fsystem.loggedinuser.address;
        //    profilepic.image = fsystem.getimagefrompath(fsystem.loggedinuser.profilepic);

        //    if (fsystem.loggedinuser.isadmin)
        //    {
        //        admindashboard.visible = true;
        //    }
        //}

        private void LoadArtData()
        {
            using (SqlConnection connection = DB.Connect())
            {
                connection.Open();

                // Load Art details
                string artQuery = @"SELECT ArtTitle, ArtDescription, SellingOption, Price 
                                  FROM Art WHERE ArtID = @ArtID";
                SqlCommand artCmd = new SqlCommand(artQuery, connection);
                artCmd.Parameters.AddWithValue("@ArtID", artID);

                using (SqlDataReader reader = artCmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        arttitle.Text = reader["ArtTitle"].ToString();
                        Description.Text = reader["ArtDescription"].ToString();
                        string sellingOption = reader["SellingOption"].ToString();

                        if (sellingOption == "Free")
                        {
                            free.Checked = true;
                            artPrice.Hide();
                        }
                        else
                        {
                            paid.Checked = true;
                            artPrice.Text = reader["Price"].ToString();
                            artPrice.Show();
                        }
                    }
                }

                // Load ArtPhotos
                string photosQuery = "SELECT Photo FROM ArtPhotos WHERE ArtID = @ArtID";
                SqlCommand photosCmd = new SqlCommand(photosQuery, connection);
                photosCmd.Parameters.AddWithValue("@ArtID", artID);

                using (SqlDataReader photosReader = photosCmd.ExecuteReader())
                {
                    while (photosReader.Read())
                    {
                        string relativePath = photosReader["Photo"].ToString();
                        string fullPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, relativePath);
                        AddPhotoPanel(fullPath);
                    }
                }
                RepositionAddButton();
            }
        }

        private void AddPhotoPanel(string imagePath)
        {
            Panel newArtPanel = new Panel {
                Width = artPanel.Width,
                Height = artPanel.Height
            };

            TextBox newTextBox = new TextBox {
                Width = 289,
                Left = 9,
                ReadOnly = true,
                Text = imagePath
            };

            Button removeButton = new Button {
                Text = "Remove",
                Left = 302,
                Size = new Size(66, 21),
                FlatStyle = FlatStyle.Standard,
                BackColor = Color.White
            };

            newTextBox.Click += (ss, ee) => {
                OpenFileDialog openFileDialog = new OpenFileDialog {
                    Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp",
                    Title = "Select Art Image"
                };

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    newTextBox.Text = openFileDialog.FileName;
                }
            };

            removeButton.Click += (s, ee) => {
                artContainer.Controls.Remove(newArtPanel);
                newArtPanel.Dispose();
                RepositionAddButton();
                ct--;
            };

            newArtPanel.Controls.Add(newTextBox);
            newArtPanel.Controls.Add(removeButton);
            artContainer.Controls.Add(newArtPanel);
            ct++;
        }

        private void RepositionAddButton()
        {
            if (artContainer.Controls.Count > 0)
            {
                Control lastPanel = artContainer.Controls[artContainer.Controls.Count - 1];
                add.Location = new Point(lastPanel.Location.X, lastPanel.Bottom + 10);
            }
            else
            {
                add.Location = new Point(10, 10);
            }

            if (!artContainer.Controls.Contains(add))
            {
                artContainer.Controls.Add(add);
            }
        }



       
        private void UpdatePhotos(SqlConnection connection)
        {
            // Delete existing photos
            string deletePhotosQuery = "DELETE FROM ArtPhotos WHERE ArtID = @ArtID";
            new SqlCommand(deletePhotosQuery, connection) { Parameters = { new SqlParameter("@ArtID", artID) } }.ExecuteNonQuery();

            // Insert new photos
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

                        string uniqueFileName = $"{Guid.NewGuid()}{Path.GetExtension(fileName)}";
                        string destinationPath = Path.Combine(storagePath, uniqueFileName);

                        if (!File.Exists(destinationPath))
                            File.Copy(filePath, destinationPath);

                        string relativePath = "ArtImages/" + uniqueFileName;

                        string insertPhotoQuery = "INSERT INTO ArtPhotos (ArtID, Photo) VALUES (@ArtID, @Photo)";
                        new SqlCommand(insertPhotoQuery, connection) {
                            Parameters = {
                                new SqlParameter("@ArtID", artID),
                                new SqlParameter("@Photo", relativePath)
                            }
                        }.ExecuteNonQuery();
                    }
                }
            }
        }

        private bool ValidateForm()
        {
            if (string.IsNullOrWhiteSpace(arttitle.Text))
            {
                MessageBox.Show("Please enter a title for the art");
                return false;
            }

            if (paid.Checked && !decimal.TryParse(artPrice.Text, out decimal price))
            {
                MessageBox.Show("Please enter a valid price for paid art");
                return false;
            }

            //foreach (Control control in artContainer.Controls)
            //{
            //    if (control is Panel panel)
            //    {
            //        TextBox photoBox = panel.Controls.OfType<TextBox>().FirstOrDefault();
            //        if (photoBox == null || string.IsNullOrWhiteSpace(photoBox.Text))
            //        {
            //            MessageBox.Show("Please select images for all art items");
            //            return false;
            //        }
            //    }
            //}
            return true;
        }
        

        private void Submit_Click_1(object sender, EventArgs e)
        {
            if (!ValidateForm()) return;

            SqlTransaction transaction = null;
            try
            {
                using (SqlConnection connection = DB.Connect())
                {
                    connection.Open();
                    transaction = connection.BeginTransaction();

                    // Update Art table
                    string updateArtQuery = @"UPDATE Art SET 
                                    ArtTitle = @Title, 
                                    ArtDescription = @Desc, 
                                    SellingOption = @SellOption, 
                                    Price = @Price, 
                                    photocnt = @PhotoCnt 
                                    WHERE ArtID = @ArtID";

                    using (SqlCommand artCmd = new SqlCommand(updateArtQuery, connection, transaction))
                    {
                        artCmd.Parameters.AddWithValue("@Title", arttitle.Text);
                        artCmd.Parameters.AddWithValue("@Desc", Description.Text);
                        artCmd.Parameters.AddWithValue("@SellOption", free.Checked ? "Free" : "Paid");
                        artCmd.Parameters.AddWithValue("@Price", paid.Checked ? Convert.ToDecimal(artPrice.Text) : (object)DBNull.Value);
                        artCmd.Parameters.AddWithValue("@PhotoCnt", ct);
                        artCmd.Parameters.AddWithValue("@ArtID", artID);
                        artCmd.ExecuteNonQuery();
                    }

                    // Delete existing photos
                    string deletePhotosQuery = "DELETE FROM ArtPhotos WHERE ArtID = @ArtID";
                    using (SqlCommand deleteCmd = new SqlCommand(deletePhotosQuery, connection, transaction))
                    {
                        deleteCmd.Parameters.AddWithValue("@ArtID", artID);
                        deleteCmd.ExecuteNonQuery();
                    }

                    // Insert new photos
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

                                string uniqueFileName = $"{Guid.NewGuid()}{Path.GetExtension(fileName)}";
                                string destinationPath = Path.Combine(storagePath, uniqueFileName);

                                if (!File.Exists(destinationPath))
                                    File.Copy(filePath, destinationPath);

                                string relativePath = "ArtImages/" + uniqueFileName;

                                string insertPhotoQuery = "INSERT INTO ArtPhotos (ArtID, Photo) VALUES (@ArtID, @Photo)";
                                using (SqlCommand photoCmd = new SqlCommand(insertPhotoQuery, connection, transaction))
                                {
                                    photoCmd.Parameters.AddWithValue("@ArtID", artID);
                                    photoCmd.Parameters.AddWithValue("@Photo", relativePath);
                                    photoCmd.ExecuteNonQuery();
                                }
                            }
                        }
                    }

                    transaction.Commit();
                    MessageBox.Show("Art updated successfully!");
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                transaction?.Rollback();
                MessageBox.Show($"Error updating art: {ex.Message}\n\nDetails: {ex.StackTrace}");
            }
        }

        private void free_CheckedChanged(object sender, EventArgs e)
        {
            artPrice.Hide();
        }

        private void paid_CheckedChanged(object sender, EventArgs e)
        {
            artPrice.Show();
        }

        private void add_Click_1(object sender, EventArgs e)
        {
            AddPhotoPanel("");
            RepositionAddButton();
        }
    }
}