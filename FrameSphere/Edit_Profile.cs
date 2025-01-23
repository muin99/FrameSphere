using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrameSphere
{
    public partial class Edit_Profile : Form
    {
        byte[] imageBytes = null;
        public Edit_Profile()
        {
            InitializeComponent();

            FirstNameField.Text = FSystem.loggedInUser.FirstName;
            LastNameField.Text= FSystem.loggedInUser.LastName;
            PhoneField.Text = FSystem.loggedInUser.Phone;
            EmailField.Text = FSystem.loggedInUser.Email;
            AddressField.Text = FSystem.loggedInUser.Address;
            FaceBookField.Text = FSystem.loggedInUser.Facebook;
            InstagramField.Text = FSystem.loggedInUser.Instagram;
            PinterestField.Text = FSystem.loggedInUser.Pinterest;
            WebsiteField.Text = FSystem.loggedInUser.Website;
            imageBytes = FSystem.loggedInUser.ProfilePic;

            if (imageBytes != null)
            {
                using (MemoryStream ms = new MemoryStream(FSystem.loggedInUser.ProfilePic))
                {
                    profilepic.Image = Image.FromStream(ms);
                }
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            UserDashBoard userDashBoard = new UserDashBoard();
            userDashBoard.Show();
        }

        public Edit_Profile(string username)
        {
            InitializeComponent();
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
                imageBytes == null)  // Check if imageBytes is null to avoid unnecessary update
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

            // Open the connection and update the information
            using (SqlConnection conn = DB.Connect())
            {
                conn.Open();

                // Define the SQL query with INNER JOINs to update the related tables
                string updateQuery = @"
            UPDATE AllUser
            SET 
                FirstName = @FirstName,
                LastName = @LastName,
                Email = @Email
            WHERE UserName = @UserName AND Password = @CurrentPW;

            UPDATE UserContact
            SET 
                Email = @Email,
                Address = @Address,
                Phone = @Phone,
                ProfilePic = @pp
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
                    cmd.Parameters.AddWithValue("@FirstName", FirstNameField.Text);
                    cmd.Parameters.AddWithValue("@LastName", LastNameField.Text);
                    cmd.Parameters.AddWithValue("@Email", EmailField.Text);
                    cmd.Parameters.AddWithValue("@UserName", FSystem.loggedInUser.UserName); // Logged-in user's username
                    cmd.Parameters.AddWithValue("@CurrentPW", CurrentPWField.Text);

                    cmd.Parameters.AddWithValue("@Address", AddressField.Text);
                    cmd.Parameters.AddWithValue("@Phone", PhoneField.Text);  // Assuming you have a Phone field for user contact

                    cmd.Parameters.AddWithValue("@Facebook", FaceBookField.Text);
                    cmd.Parameters.AddWithValue("@Instagram", InstagramField.Text);
                    cmd.Parameters.AddWithValue("@Pinterest", PinterestField.Text);
                    cmd.Parameters.AddWithValue("@Website", WebsiteField.Text);

                    // Only update ProfilePic if imageBytes is not null
                    if (imageBytes != null)
                    {
                        cmd.Parameters.AddWithValue("@pp", imageBytes);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@pp", DBNull.Value); // Use DBNull if no image selected
                    }

                    try
                    {
                        // Execute the query
                        int rowsChanged = cmd.ExecuteNonQuery();
                        if (rowsChanged > 0)
                        {
                            MessageBox.Show("Information updated successfully");
                        }
                        else
                        {
                            MessageBox.Show("Password may be incorrect", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error: {ex.Message}");
                        MessageBox.Show("An error occurred while updating the information.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
            }
            FSystem.loggedInUser.loadUser();
        }



        private void button1_Click_1(object sender, EventArgs e)
        {
            Admin_dashboard u1 = new Admin_dashboard();
            this.Hide();
            u1.Show();
        }
        string imagePath = null;

        private void posterbtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog {
                Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp",
                Title = "Select Event Poster"
            };
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                imagePath = openFileDialog.FileName;
                poster.Text = imagePath;
                imageBytes = File.ReadAllBytes(imagePath);
                using (MemoryStream ms = new MemoryStream(imageBytes))
                {
                    profilepic.Image = System.Drawing.Image.FromStream(ms);
                }
            }
        }

        private void profilepic_Click(object sender, EventArgs e)
        {

        }
    }
}
//UPDATE UserContact\r\nSET Address = 'thiscity',\r\n    Email = 'ra@',\r\n\tPhone = '73823',\r\n\t\r\n"