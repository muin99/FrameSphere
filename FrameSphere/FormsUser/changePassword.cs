using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrameSphere.FormsUser
{
    public partial class changePassword : Form
    {
        public changePassword()
        {
            InitializeComponent();
        }

        private void resetpassword_btn_Click(object sender, EventArgs e)
        {
            string username = FSystem.loggedInUser.UserName;
            string cPass = currentPass.Text;
            string password = password_textbox.Text;
            string confirmPassword = confirmpassword_textbox.Text;

            if (
                string.IsNullOrEmpty(cPass) ||
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


                    //Update the password 
                    string updateQuery = "UPDATE AllUser SET Password = @Password WHERE UserName = @UserName";
                    using (SqlCommand cmdUpdate = new SqlCommand(updateQuery, connection))
                    {
                        cmdUpdate.Parameters.AddWithValue("@Password", password);
                        cmdUpdate.Parameters.AddWithValue("@UserName", username);

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

        }
    }
}
