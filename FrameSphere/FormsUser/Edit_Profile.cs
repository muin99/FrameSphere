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
        private string managedUserName;
        public Edit_Profile(string username)
        {
            

            InitializeComponent();
            managedUserName = username;
            // Determine if the profile is being managed by an admin or edited by the logged-in user.
            bool isManageMode = !username.Equals(FSystem.loggedInUser.UserName, StringComparison.OrdinalIgnoreCase);

            if (isManageMode)
            {
                // Admin is managing another user's profile.
                // Show the Approve and Reject buttons.
                approve.Visible = true;
                reject.Visible = true;

                // Change label11 to "Manage Profile".
                label11.Text = "Manage Profile";

                // Load the selected user's data from the database.
                using (SqlConnection connection = DB.Connect())
                {
                    // Query only the available columns.
                    string query = "SELECT FirstName, LastName, Email, Status FROM AllUser WHERE UserName = @username";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@username", username);
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                FirstNameField.Text = reader["FirstName"].ToString();
                                LastNameField.Text = reader["LastName"].ToString();
                                EmailField.Text = reader["Email"].ToString();

                                // For fields not available in the table, set them to empty or a default value.
                                PhoneField.Text = "";
                                AddressField.Text = "";
                                FaceBookField.Text = "";
                                InstagramField.Text = "";
                                PinterestField.Text = "";
                                WebsiteField.Text = "";

                                // If you store a profile picture path elsewhere, update accordingly.
                                // For now, we'll clear it.
                                poster.Text = "";
                            }
                            else
                            {
                                MessageBox.Show("User not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
            }
            else
            {
                // Logged-in user is editing their own profile.
                // Hide the Approve and Reject buttons.
                approve.Visible = false;
                reject.Visible = false;

                // Load data from FSystem.loggedInUser.
                FirstNameField.Text = FSystem.loggedInUser.FirstName;
                LastNameField.Text = FSystem.loggedInUser.LastName;
                EmailField.Text = FSystem.loggedInUser.Email;

                // If these fields exist in your FSystem.loggedInUser, otherwise clear them.
                PhoneField.Text = FSystem.loggedInUser.Phone;
                AddressField.Text = FSystem.loggedInUser.Address;
                FaceBookField.Text = FSystem.loggedInUser.Facebook;
                InstagramField.Text = FSystem.loggedInUser.Instagram;
                PinterestField.Text = FSystem.loggedInUser.Pinterest;
                WebsiteField.Text = FSystem.loggedInUser.Website;
                poster.Text = FSystem.loggedInUser.ProfilePic;
            }

            // Common code to load the profile picture from file (if a profile picture path exists).
            string profilePicPath = poster.Text;
            if (!string.IsNullOrWhiteSpace(profilePicPath))
            {
                string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
                string fullPath = Path.Combine(baseDirectory, profilePicPath);
                if (File.Exists(fullPath))
                {
                    profilepic.Image = Image.FromFile(fullPath);
                }
            }


        }

        private void approve_Click(object sender, EventArgs e)
        {
            // Only allow status update in Manage mode (i.e. when the managed user is not the logged-in user)
            if (managedUserName.Equals(FSystem.loggedInUser.UserName, StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("You cannot approve your own profile.", "Operation Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection conn = DB.Connect())
            {
                string query = "UPDATE AllUser SET Status = 'Approved' WHERE UserName = @username";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@username", managedUserName);
                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("User status updated to Approved.", "Status Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Failed to update status.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void reject_Click(object sender, EventArgs e)
        {
            // Only allow status update in Manage mode.
            if (managedUserName.Equals(FSystem.loggedInUser.UserName, StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("You cannot reject your own profile.", "Operation Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection conn = DB.Connect())
            {
                string query = "UPDATE AllUser SET Status = 'Rejected' WHERE UserName = @username";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@username", managedUserName);
                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("User status updated to Rejected.", "Status Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Failed to update status.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
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
            //FSystem.loggedInUser.loadUser();
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
