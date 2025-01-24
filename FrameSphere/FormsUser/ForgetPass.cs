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
    public partial class ForgetPass : Form
    {
        public ForgetPass()
        {
            InitializeComponent();
        }

        private void resetpassword_btn_Click(object sender, EventArgs e)
        {
            string username = user_textbox.Text.Trim();
            string email = email_textbox.Text.Trim();
            string password = password_textbox.Text.Trim();
            string confirmPassword = confirmpassword_textbox.Text.Trim();

            if (string.IsNullOrEmpty(username) ||
                string.IsNullOrEmpty(email) ||
                string.IsNullOrEmpty(password) ||
                string.IsNullOrEmpty(confirmPassword))
            {
                MessageBox.Show("Please fill in all the fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (password != confirmPassword)
            {
                MessageBox.Show("Password and Confirm Password do not match.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                using (SqlConnection connection = DB.Connect())
                {
                    connection.Open();

                    //Check if the username exists
                    string usernameQuery = "SELECT COUNT(*) FROM AllUser WHERE UserName = @UserName";
                    using (SqlCommand cmdCheckUsername = new SqlCommand(usernameQuery, connection))
                    {
                        cmdCheckUsername.Parameters.AddWithValue("@UserName", username);
                        int usernameCount = (int)cmdCheckUsername.ExecuteScalar();

                        if (usernameCount == 0)
                        {
                            MessageBox.Show("Username not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                    //Check if the email matches the username
                    string emailQuery = "SELECT COUNT(*) FROM AllUser WHERE UserName = @UserName AND Email = @Email";
                    using (SqlCommand cmdCheckEmail = new SqlCommand(emailQuery, connection))
                    {
                        cmdCheckEmail.Parameters.AddWithValue("@UserName", username);
                        cmdCheckEmail.Parameters.AddWithValue("@Email", email);

                        int emailCount = (int)cmdCheckEmail.ExecuteScalar();

                        if (emailCount == 0)
                        {
                            MessageBox.Show("Email is not correct.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                    //Update the password 
                    string updateQuery = "UPDATE AllUser SET Password = @Password WHERE UserName = @UserName AND Email = @Email";
                    using (SqlCommand cmdUpdate = new SqlCommand(updateQuery, connection))
                    {
                        cmdUpdate.Parameters.AddWithValue("@Password", password);
                        cmdUpdate.Parameters.AddWithValue("@UserName", username);
                        cmdUpdate.Parameters.AddWithValue("@Email", email);

                        cmdUpdate.ExecuteNonQuery();

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
            this.Hide();
            LoginForm loginForm = new LoginForm();
            loginForm.StartPosition = FormStartPosition.CenterParent;
            loginForm.ShowDialog();
        }
    }
}
