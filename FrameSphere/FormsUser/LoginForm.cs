using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FrameSphere.EntityClasses;

namespace FrameSphere
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void RegisterButton_Click(object sender, EventArgs e)
        {
            this.Hide(); 
            RegistrationForm rr = new RegistrationForm();
            rr.Show();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        private void AccountLabel_Click(object sender, EventArgs e)
        {

        }

        private string GetUserStatus(string userName)
        {
  
            string status = "";
            string query = "SELECT Status FROM AllUser WHERE UserName = @userName";

            using (SqlConnection connection = DB.Connect())
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    try
                    {
                        command.Parameters.AddWithValue("@userName", userName);
                        object result = command.ExecuteScalar();
                        if (result != null)
                        {
                            status = result.ToString();
                        }
                    }
                    catch (SqlException q)
                    {
                        MessageBox.Show("Something went wrong!", " DB Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Console.WriteLine("GetUserStatus DB Error: " + q.Message);
                        return null;
                    }

                }
            }
            return status;
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            // Clear previous warnings
            useridwar.Visible = false;
            passwordWarning.Visible = false;
            try
            {
                if (UserId.Text == "")
                {
                    useridwar.Visible = true;
                }
                if (Password.Text == "")
                {
                    passwordWarning.Visible = true;
                }

                if (string.IsNullOrEmpty(UserId.Text) || string.IsNullOrEmpty(Password.Text)) { return; }

                if (FSystem.Login(UserId.Text, Password.Text))
                {
                    string status = GetUserStatus(UserId.Text);

                    switch (status.ToLower()) // Case-insensitive comparison
                    {
                        case "approved":
                            this.Hide();
                            new UserDashBoard().Show();
                            break;
                        case "rejected":
                            MessageBox.Show("Your account creation has been rejected by Admin");
                            break;
                        case "pending":
                            MessageBox.Show("You may not login right now. Please wait for Admin approval.");
                            break;
                        default:
                            MessageBox.Show("Unknown account status.");
                            break;
                    }
                }
                else
                {
                    MessageBox.Show("Invalid credentials.");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Something went wrong!", " DB Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine("DB ERROR: " + ex.Message);
                return;
            }
            
        }


        private void label1_Click_2(object sender, EventArgs e)
        {

        }

        

        private void linkLabel1_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            ForgetPass fp = new ForgetPass();
            fp.Show();
        }
    }
}
