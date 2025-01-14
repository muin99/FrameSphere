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
            rr.ShowDialog();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        private void AccountLabel_Click(object sender, EventArgs e)
        {

        }



        private void LoginButton_Click(object sender, EventArgs e)
        {
            if (UserId.Text != "" && Password.Text != "") { 
                if(FSystem.Login(UserId.Text, Password.Text))
                {
                    this.Hide();
                    UserDashBoard userDashboard = new UserDashBoard();
                    userDashboard.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Please enter a valid userid or password");
                }
            }

            if (UserId.Text == ""){ useridwar.Visible = true; }
            else { useridwar.Visible = false; }

            if(Password.Text == "")
            {
                passwordWarning.Visible = true;
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
