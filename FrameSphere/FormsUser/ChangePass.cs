using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace FrameSphere
{
    public partial class ChangePass : Form
    {
        public ChangePass()
        {
            InitializeComponent();
        }

        
        private void resetpassword_btn_Click_1(object sender, EventArgs e)
        {
            string currentPassword = currentpassword.Text.Trim();
            string newPassword = password_textbox.Text.Trim();
            string confirmPassword = confirmpassword_textbox.Text.Trim();
            string username = FSystem.loggedInUser.UserName; // Get logged-in username

            if (string.IsNullOrEmpty(currentPassword) ||
                string.IsNullOrEmpty(newPassword) ||
                string.IsNullOrEmpty(confirmPassword))
            {
                MessageBox.Show("Please fill in all the fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (newPassword != confirmPassword)
            {
                MessageBox.Show("New Password and Confirm New Password do not match.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                using (SqlConnection connection = DB.Connect())
                {
                    connection.Open();

                    // Verify current password using the logged-in username
                    string verifyPasswordQuery = "SELECT COUNT(*) FROM AllUser WHERE UserName = @UserName AND Password = @Password";
                    using (SqlCommand cmdVerifyPassword = new SqlCommand(verifyPasswordQuery, connection))
                    {
                        cmdVerifyPassword.Parameters.AddWithValue("@UserName", username);
                        cmdVerifyPassword.Parameters.AddWithValue("@Password", currentPassword);

                        int passwordCount = (int)cmdVerifyPassword.ExecuteScalar();

                        if (passwordCount == 0)
                        {
                            MessageBox.Show("Incorrect current password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                    // Update the password using the logged-in username
                    string updateQuery = "UPDATE AllUser SET Password = @NewPassword WHERE UserName = @UserName";
                    using (SqlCommand cmdUpdatePassword = new SqlCommand(updateQuery, connection))
                    {
                        cmdUpdatePassword.Parameters.AddWithValue("@NewPassword", newPassword);
                        cmdUpdatePassword.Parameters.AddWithValue("@UserName", username);

                        cmdUpdatePassword.ExecuteNonQuery();

                        MessageBox.Show("Password changed successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        this.Hide();

                        LoginForm loginForm = new LoginForm();
                        loginForm.ShowDialog();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void backtosignin_btn_Click(object sender, EventArgs e)
        {
            LoginForm a1 = new LoginForm();
            this.Hide();
            a1.Show();
        }
    }
}
