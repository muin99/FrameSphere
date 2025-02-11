﻿using System;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace FrameSphere
{
    public partial class Edit_Profile : Form
    {
        public MakeAdmin m1;

        private string imagePath = null; // Path to the selected image
        private string profilePicRelativePath = null; // Relative path for storing in the database
        private string managedUserName;
        public string username;
        public Edit_Profile(string username)
        {
            InitializeComponent();
            this.username = username;

            if (FSystem.loggedInUser.isAdmin)
            {
                delete.Visible = true;
            }
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
                    try
                    {
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

                                    string status = reader["Status"].ToString();
                                    if (status.ToLower() == "approved")
                                    {
                                        makeAdmin.Visible = true;
                                    }
                                    else
                                    {
                                        makeAdmin.Visible = false;
                                    }


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
                    catch(SqlException e)
                    {
                        MessageBox.Show("Something went wrong! Try again later.", "DB Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Console.WriteLine("DB ERROR: "+e.Message);
                    }
                    catch(Exception e)
                    {
                        MessageBox.Show("Something went wrong! Try again later.", "Unexpected Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Console.WriteLine("UNEXPECTED ERROR: " + e.Message);
                    }
                    
                }
            }
            else
            {
                // Logged-in user is editing their own profile.
                // Hide the Approve and Reject buttons.
                approve.Visible = false;
                reject.Visible = false;
                makeAdmin.Visible = false;

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
            try
            {
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
            catch(Exception ex)
            {
                MessageBox.Show("Something went wrong!", "Image Loading Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine("IMAGE LOADING ERROR: " + ex.Message);
            }
           


        }

        private void makeAdmin_Click(object sender, EventArgs e)
        {
            string selectedUser = managedUserName; // The user to be made admin
            string currentAdmin = FSystem.loggedInUser.UserName; // Current logged-in admin
            string firstName = "", lastName = "", email = "";

            using (SqlConnection connection = DB.Connect())
            {
                connection.Open();

                // Check if the user is already an admin
                string checkAdminQuery = "SELECT UserName FROM AdminList WHERE UserName = @UserName";
                try
                {
                    using (SqlCommand checkAdminCommand = new SqlCommand(checkAdminQuery, connection))
                    {
                        checkAdminCommand.Parameters.AddWithValue("@UserName", selectedUser);
                        using (SqlDataReader reader = checkAdminCommand.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                MessageBox.Show("This user is already an admin.", "Already Admin", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }
                        }
                    }
                }
                catch(SqlException ex)
                {
                    MessageBox.Show("Something went wrong! Try again later.", "DB Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Console.WriteLine("CheckAdminQuery DB error: " + ex.Message);
                    return;
                }
                catch (Exception q)
                {
                    MessageBox.Show("Something went wrong! Try again later.", "Unexpected Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Console.WriteLine("CheckAdminQuery unexpected error: " + q.Message);
                    return;
                }

                // Fetch user details from AllUser table
                string getUserDetailsQuery = "SELECT FirstName, LastName, Email FROM AllUser WHERE UserName = @UserName";
                try
                {
                    using (SqlCommand userDetailsCommand = new SqlCommand(getUserDetailsQuery, connection))
                    {
                        userDetailsCommand.Parameters.AddWithValue("@UserName", selectedUser);
                        using (SqlDataReader reader = userDetailsCommand.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                firstName = reader["FirstName"].ToString();
                                lastName = reader["LastName"].ToString();
                                email = reader["Email"].ToString();
                            }
                        }
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Something went wrong! Try again later.", "DB Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Console.WriteLine("getUserDetailsQuery DB error: " + ex.Message);
                    return;
                }
                catch (Exception q)
                {
                    MessageBox.Show("Something went wrong! Try again later.", "Unexpected Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Console.WriteLine("getUserDetailsQuery unexpected error: " + q.Message);
                    return;
                }

                // Get the total number of admins //--------------------------------------EXCEPTION HANDLING PENDING FROM HERE DOWN-------------------------
                string totalAdminsQuery = "SELECT COUNT(*) FROM AdminList";
                int totalAdmins;
                using (SqlCommand totalAdminsCommand = new SqlCommand(totalAdminsQuery, connection))
                {
                    totalAdmins = (int)totalAdminsCommand.ExecuteScalar();
                }
                // If there's only one admin, promote the user immediately
                if (totalAdmins == 1)
                {
                    string insertAdminQuery = "INSERT INTO AdminList (UserName) VALUES (@UserName)";
                    using (SqlCommand insertCommand = new SqlCommand(insertAdminQuery, connection))
                    {
                        insertCommand.Parameters.AddWithValue("@UserName", selectedUser);
                        insertCommand.ExecuteNonQuery();
                    }

                    // Remove any pending request (optional safeguard)
                    string deleteRequestQuery = "DELETE FROM PendingAdminRequests WHERE UserName = @UserName";
                    using (SqlCommand deleteCommand = new SqlCommand(deleteRequestQuery, connection))
                    {
                        deleteCommand.Parameters.AddWithValue("@UserName", selectedUser);
                        deleteCommand.ExecuteNonQuery();
                    }

                    MessageBox.Show("User has been successfully promoted to Admin!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Check if the user is already in the PendingAdminRequests table
                string checkRequestQuery = "SELECT Approvals, TotalAdmins FROM PendingAdminRequests WHERE UserName = @UserName";
                using (SqlCommand checkCommand = new SqlCommand(checkRequestQuery, connection))
                {
                    checkCommand.Parameters.AddWithValue("@UserName", selectedUser);
                    using (SqlDataReader reader = checkCommand.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            int approvals = Convert.ToInt32(reader["Approvals"]);
                            int totalAdminsRequired = Convert.ToInt32(reader["TotalAdmins"]);
                            reader.Close();

                            // Update approval count
                            string updateApprovalQuery = "UPDATE PendingAdminRequests SET Approvals = Approvals + 1 WHERE UserName = @UserName";
                            using (SqlCommand updateCommand = new SqlCommand(updateApprovalQuery, connection))
                            {
                                updateCommand.Parameters.AddWithValue("@UserName", selectedUser);
                                updateCommand.ExecuteNonQuery();
                            }

                            // If approvals meet or exceed total admins, promote the user
                            if (approvals + 1 >= totalAdminsRequired)
                            {
                                string insertAdminQuery = "INSERT INTO AdminList (UserName) VALUES (@UserName)";
                                using (SqlCommand insertCommand = new SqlCommand(insertAdminQuery, connection))
                                {
                                    insertCommand.Parameters.AddWithValue("@UserName", selectedUser);
                                    insertCommand.ExecuteNonQuery();
                                }

                                // Remove from PendingAdminRequests
                                string deleteRequestQuery = "DELETE FROM PendingAdminRequests WHERE UserName = @UserName";
                                using (SqlCommand deleteCommand = new SqlCommand(deleteRequestQuery, connection))
                                {
                                    deleteCommand.Parameters.AddWithValue("@UserName", selectedUser);
                                    deleteCommand.ExecuteNonQuery();
                                }

                                MessageBox.Show("User has been successfully promoted to Admin!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("Approval recorded. Waiting for all admins to approve.", "Pending", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            return;
                        }
                    }
                }

                // If no request exists, create a new one
                string insertRequestQuery = "INSERT INTO PendingAdminRequests (UserName, RequestedBy, Approvals, TotalAdmins, Status) VALUES (@UserName, @RequestedBy, 1, @TotalAdmins, 'Pending')";
                using (SqlCommand insertCommand = new SqlCommand(insertRequestQuery, connection))
                {
                    insertCommand.Parameters.AddWithValue("@UserName", selectedUser);
                    insertCommand.Parameters.AddWithValue("@RequestedBy", currentAdmin);
                    insertCommand.Parameters.AddWithValue("@TotalAdmins", totalAdmins);
                    insertCommand.ExecuteNonQuery();
                }

                // Get the RequestID of the newly created request
                string getRequestIDQuery = "SELECT RequestID FROM PendingAdminRequests WHERE UserName = @UserName";
                int requestID = 0;
                using (SqlCommand getRequestIDCommand = new SqlCommand(getRequestIDQuery, connection))
                {
                    getRequestIDCommand.Parameters.AddWithValue("@UserName", selectedUser);
                    requestID = (int)getRequestIDCommand.ExecuteScalar();
                }

                // Insert into AdminApprovals table with the correct RequestID
                string insertApprovalLogQuery = "INSERT INTO AdminApprovals (RequestID, AdminName) VALUES (@RequestID, @AdminName)";
                using (SqlCommand approvalLogCommand = new SqlCommand(insertApprovalLogQuery, connection))
                {
                    approvalLogCommand.Parameters.AddWithValue("@RequestID", requestID);
                    approvalLogCommand.Parameters.AddWithValue("@AdminName", currentAdmin);
                    approvalLogCommand.ExecuteNonQuery();
                }

                MessageBox.Show("Admin promotion request submitted. Waiting for other admins to approve.", "Request Sent", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                poster.Text = profilePicRelativePath;
            }
        }
        private bool checkLink(string url, string platform)
        {
            string facebook_pattern = @"^(https?:\/\/)?(www\.|web\.)?(facebook\.com)\/[a-zA-Z0-9.]+(\/)?$";
            string instagram_pattern = @"^(https?:\/\/)?(www\.)?(instagram\.com)\/[a-zA-Z0-9._]+(\/)?$";
            string pinterest_pattern = @"^(https?:\/\/)?(www\.)?(pinterest\.com)\/[a-zA-Z0-9._]+(\/)?$";
            string website_pattern = @"^(https?:\/\/)?([a-zA-Z0-9.-]+\.[a-zA-Z]{2,})(\/\S*)?$";
            switch (platform.ToLower())
            {
                case "facebook":
                    return Regex.IsMatch(url, facebook_pattern);
                case "instagram":
                    return Regex.IsMatch(url, instagram_pattern);
                case "pinterest":
                    return Regex.IsMatch(url, pinterest_pattern);
                case "website":
                    return Regex.IsMatch(url, website_pattern);
                default:
                    return false;
            }
        }
        private bool checkValidations()
        {
            if (!CheckMail_e.Visible && !checkfname1.Visible && !checklname2.Visible && !checkPhone.Visible && !invalidPhone.Visible && CurrentPWField.Text != "")
            {
                return true;
            }
            else { return false; }

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
            //Ensure social links are valid in button2_Click
            if (!string.IsNullOrWhiteSpace(FaceBookField.Text) && !checkLink(FaceBookField.Text, "facebook"))
            {
                MessageBox.Show("Facebook link is invalid!", "Invalid Link", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!string.IsNullOrWhiteSpace(InstagramField.Text) && !checkLink(InstagramField.Text, "instagram"))
            {
                MessageBox.Show("Instagram link is invalid!", "Invalid Link", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!string.IsNullOrWhiteSpace(PinterestField.Text) && !checkLink(PinterestField.Text, "pinterest"))
            {
                MessageBox.Show("Pinterest link is invalid!", "Invalid Link", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!string.IsNullOrWhiteSpace(WebsiteField.Text) && !checkLink(WebsiteField.Text, "website"))
            {
                MessageBox.Show("Website link is invalid!", "Invalid Link", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            //Ensure all are validated
            if (!checkValidations())
            {
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

        private void button4_Click(object sender, EventArgs e)
        {
            ChangePass f1 = new ChangePass();
            this.Hide();
            f1.Show();
        }

        private void profilechange_Click(object sender, EventArgs e)
        {
            if (FSystem.loggedInUser.CheckPassword(CurrentPWField.Text) && 
                FSystem.loggedInUser.ProfilePic != poster.Text)
            {
                FSystem.loggedInUser.ProfilePic = poster.Text;
                MessageBox.Show("Profile Changed");
            }
            else {
                MessageBox.Show("Not a valid password");
            }
        }

        private void EmailField_TextChanged(object sender, EventArgs e)
        {
            if (FSystem.validEmail(EmailField.Text)) { CheckMail_e.Visible = true; }
            else { CheckMail_e.Visible = false; }
        }

        private bool noSpaces(string text)
        {
            if (text.StartsWith(" ") || text.EndsWith(" ")) { return false; }
            else { return true; }
        }
        private bool noNumbers(string text)
        {
            if (text.Any(char.IsDigit)) { return false; }
            else { return true; }
        }
        private bool noLetters(string text)
        {
            if (!text.Any(char.IsDigit)) { return false; }
            else { return true; }
        }
        private string capitalizeFirst(string text)
        {
            return char.ToUpper(text[0]) + text.Substring(1);
        }

        private void FirstNameField_TextChanged(object sender, EventArgs e)
        {
            if (!noSpaces(FirstNameField.Text)) { checkfname1.Visible = true; }
            else { checkfname1.Visible = false; }

            if (!noNumbers(FirstNameField.Text)) { noNumbers11.Visible = true; }
            else { noNumbers11.Visible = false; }
        }

        private void LastNameField_TextChanged(object sender, EventArgs e)
        {
            if (!noSpaces(LastNameField.Text)) { checklname2.Visible = true; }
            else { checklname2.Visible = false; }

            if (!noNumbers(LastNameField.Text)) { noNumbers22.Visible = true; }
            else { noNumbers22.Visible = false; }
        }

        private void PhoneField_TextChanged(object sender, EventArgs e)
        {
            if (!noSpaces(PhoneField.Text)) { checkPhone.Visible = true; }
            else { checkPhone.Visible = false; }
            if (!noLetters(PhoneField.Text)) { invalidPhone.Visible = true; }
            else { invalidPhone.Visible = false; }

        }

        private void delete_Click(object sender, EventArgs e)
        {
            FSystem.DeleteUser(username);
        }

    }
}

