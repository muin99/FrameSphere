using System;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace FrameSphere
{
    public partial class Edit_Profile : Form
    {
        private string imagePath = null; // Path to the selected image
        private string profilePicRelativePath = null; // Relative path for storing in the database

        public Edit_Profile(string username)
        {
            InitializeComponent();

            // Populate fields with logged-in user data
            FirstNameField.Text = FSystem.loggedInUser.FirstName;
            LastNameField.Text = FSystem.loggedInUser.LastName;
            PhoneField.Text = FSystem.loggedInUser.Phone;
            EmailField.Text = FSystem.loggedInUser.Email;
            AddressField.Text = FSystem.loggedInUser.Address;
            FaceBookField.Text = FSystem.loggedInUser.Facebook;
            InstagramField.Text = FSystem.loggedInUser.Instagram;
            PinterestField.Text = FSystem.loggedInUser.Pinterest;
            WebsiteField.Text = FSystem.loggedInUser.Website;

            // Load profile picture
            if (!string.IsNullOrWhiteSpace(FSystem.loggedInUser.ProfilePic))
            {
                string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
                string fullPath = Path.Combine(baseDirectory, FSystem.loggedInUser.ProfilePic);

                if (File.Exists(fullPath))
                {
                    profilepic.Image = Image.FromFile(fullPath);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Navigate back to the User Dashboard
            this.Hide();
            UserDashBoard userDashBoard = new UserDashBoard();
            userDashBoard.Show();
        }

        private void posterbtn_Click(object sender, EventArgs e)
        {
            // Open a file dialog to select the profile picture
            OpenFileDialog openFileDialog = new OpenFileDialog {
                Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp",
                Title = "Select Profile Picture"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                imagePath = openFileDialog.FileName;

                // Define the target directory for profile pictures
                string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
                string profileDir = Path.Combine(baseDirectory, "ProfileImages");
                Directory.CreateDirectory(profileDir); // Ensure the directory exists

                // Save the image in the profile directory
                string fileName = Path.GetFileName(imagePath);
                string destinationPath = Path.Combine(profileDir, fileName);
                File.Copy(imagePath, destinationPath, true); // Copy the image

                // Store the relative path to save in the database
                profilePicRelativePath = Path.Combine("ProfileImages", fileName);

                // Display the selected image in the PictureBox
                profilepic.Image = Image.FromFile(destinationPath);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Check if there are any fields to update
            if (string.IsNullOrWhiteSpace(FirstNameField.Text) &&
                string.IsNullOrWhiteSpace(LastNameField.Text) &&
                string.IsNullOrWhiteSpace(EmailField.Text) &&
                string.IsNullOrWhiteSpace(AddressField.Text) &&
                string.IsNullOrWhiteSpace(FaceBookField.Text) &&
                string.IsNullOrWhiteSpace(InstagramField.Text) &&
                string.IsNullOrWhiteSpace(WebsiteField.Text) &&
                string.IsNullOrWhiteSpace(PhoneField.Text) &&
                string.IsNullOrWhiteSpace(profilePicRelativePath))
            {
                MessageBox.Show("There is nothing to update. Please enter new information where needed.", "Empty Fields", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Ensure the current password is entered
            if (string.IsNullOrWhiteSpace(CurrentPWField.Text))
            {
                PWVerifyLabel.Visible = true;
                CurrentPWField.Focus();
                return;
            }

            string currentPW = CurrentPWField.Text;
            if (!FSystem.loggedInUser.CheckPassword(currentPW))
            {
                WrongPWLabel.Visible = true;
                CurrentPWField.Clear();
                CurrentPWField.Focus();
                return;
            }

            // Update user information in the database
            using (SqlConnection conn = DB.Connect())
            {
                conn.Open();

                string updateQuery = @"
                UPDATE AllUser
                SET 
                   
                    LastName = @LastName,
                    Email = @Email
                WHERE UserName = @UserName AND Password = @CurrentPW;

                UPDATE UserContact
                SET 
                    Email = @Email,
                    Address = @Address,
                    Phone = @Phone,
                    ProfilePic = @ProfilePic
                WHERE UserName = @UserName;

                UPDATE UserSocials
                SET 
                    Facebook = @Facebook,
                    Instagram = @Instagram,
                    Pinterest = @Pinterest,
                    Website = @Website
                WHERE UserName = @UserName;
                ";

                using (SqlCommand cmd = new SqlCommand(updateQuery, conn))
                {
                    // Add parameters to prevent SQL injection
                    //cmd.Parameters.AddWithValue("@FirstName", FirstNameField.Text);
                    cmd.Parameters.AddWithValue("@LastName", LastNameField.Text);
                    cmd.Parameters.AddWithValue("@Email", EmailField.Text);
                    cmd.Parameters.AddWithValue("@UserName", FSystem.loggedInUser.UserName); // Logged-in user's username
                    cmd.Parameters.AddWithValue("@CurrentPW", CurrentPWField.Text);

                    cmd.Parameters.AddWithValue("@Address", AddressField.Text);
                    cmd.Parameters.AddWithValue("@Phone", PhoneField.Text);

                    cmd.Parameters.AddWithValue("@Facebook", FaceBookField.Text);
                    cmd.Parameters.AddWithValue("@Instagram", InstagramField.Text);
                    cmd.Parameters.AddWithValue("@Pinterest", PinterestField.Text);
                    cmd.Parameters.AddWithValue("@Website", WebsiteField.Text);

                    // Add profile picture relative path or set it to NULL
                    if (!string.IsNullOrWhiteSpace(profilePicRelativePath))
                    {
                        cmd.Parameters.AddWithValue("@ProfilePic", profilePicRelativePath);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@ProfilePic", DBNull.Value);
                    }

                    try
                    {
                        // Execute the query
                        int rowsChanged = cmd.ExecuteNonQuery();
                        if (rowsChanged > 0)
                        {
                            MessageBox.Show("Information updated successfully.");
                        }
                        else
                        {
                            MessageBox.Show("Password may be incorrect.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error: {ex.Message}");
                        MessageBox.Show("An error occurred while updating the information.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            FSystem.loggedInUser.FirstName = FirstNameField.Text;

            // Reload the logged-in user's information
            FSystem.loggedInUser.loadUser();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            // Navigate to the Admin Dashboard
            Admin_dashboard adminDashboard = new Admin_dashboard();
            this.Hide();
            adminDashboard.Show();
        }
    }
}
