﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.DirectoryServices.ActiveDirectory;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace FrameSphere
{
    public partial class RegistrationForm : Form
    {
        private bool allowRegister = false;
        public RegistrationForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void RegistrationForm_Load(object sender, EventArgs e)
        {

        }
        public static void Register(string firstName, string lastName, string userName, string email, string password)
        {
            using (SqlConnection c = DB.Connect())
            {
                try
                {
                    c.Open();

                    string q = $@"
                            BEGIN TRANSACTION;
                            INSERT INTO AllUser (FirstName, LastName, UserName, Email, Password, Status)
                            VALUES ('{firstName}', '{lastName}', '{userName}', '{email}', '{password}', 'pending');

                            INSERT INTO UserSocials (UserName)
                            VALUES ('{userName}');

                            INSERT INTO UserContact (UserName)
                            VALUES ('{userName}');

                            COMMIT TRANSACTION;";

                    using (SqlCommand cmd = new SqlCommand(q, c))
                    {
                        cmd.ExecuteNonQuery();
                        Console.WriteLine("Registration successful.");
                    }
                }
                catch (SqlException q)
                {
                    MessageBox.Show("Something went wrong! Try again later.", "DB Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Console.WriteLine("Register DB error: " + q.Message);
                    return;
                }
                catch (Exception e)
                {
                    MessageBox.Show("Something went wrong! Try again later.", "Unexpected Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Console.WriteLine("Register unexpected error: " + e.Message);
                    return;
                }

            }
        }
        

        private bool checkValidations()
        {  if (!CheckMail.Visible && !usernameWarning.Visible && !confirmLabel.Visible && !charWarning.Visible && !checkfname.Visible && !checklname.Visible && UserName.Text != "" && Password.Text != "")
            {
                return true;
            }
            else { return false; }
            
        }

        private bool isEmpty()
        {
            if (string.IsNullOrEmpty(FirstName.Text) || string.IsNullOrEmpty(LastName.Text) || string.IsNullOrEmpty(Email.Text) || string.IsNullOrEmpty(UserName.Text) || string.IsNullOrEmpty(Password.Text) || string.IsNullOrEmpty(ConfirmPass.Text))
            {
                return true;
            }
            else { return false; }
        }
        private void SubmitButton_Click(object sender, EventArgs e)
        {
            //validation
            try
            {
                if (!isEmpty())
                {
                    if (checkValidations())//if both ok, update DB
                    {
                        allowRegister = true;
                        string fname = capitalizeFirst(FirstName.Text);
                        string lname = capitalizeFirst(LastName.Text);

                        Register(fname, lname, UserName.Text.ToString(), Email.Text.ToString(), Password.Text.ToString());
                        MessageBox.Show("Registration successful! Please wait for account approval before login.", "Registration Done", MessageBoxButtons.OK);
                        allowRegister = true;
                    }
                    else//input wrong
                    {
                        MessageBox.Show("Ensure valid data entries!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
                else//empty fields
                {
                    MessageBox.Show("Please fill all fields!", "Empty Fields", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Something went wrong!", " Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine("ERROR: " + ex.Message);
                return;
            }
            if (allowRegister)
            {
                this.Hide();
                LoginForm loginForm = new LoginForm();
                loginForm.StartPosition = FormStartPosition.CenterParent;
                loginForm.ShowDialog();
            }
            else {MessageBox.Show("Something went wrong!", "Registration Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            this.Hide();

            LoginForm loginForm = new LoginForm();
            loginForm.StartPosition = FormStartPosition.CenterParent;
            loginForm.ShowDialog();
        }

        private void panel2_Paint(object sender, PaintEventArgs e) //rounded corners for data entry panel
        {
            Panel panel = (Panel)sender; 
            int borderRadius = 25;

            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            Rectangle rect = new Rectangle(0, 0, panel.Width, panel.Height);


            using (System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath())
            {
                path.AddArc(rect.X, rect.Y, borderRadius, borderRadius, 180, 90);
                path.AddArc(rect.X + rect.Width - borderRadius, rect.Y, borderRadius, borderRadius, 270, 90);
                path.AddArc(rect.X + rect.Width - borderRadius, rect.Y + rect.Height - borderRadius, borderRadius, borderRadius, 0, 90);
                path.AddArc(rect.X, rect.Y + rect.Height - borderRadius, borderRadius, borderRadius, 90, 90);
                path.CloseAllFigures();


                panel.Region = new Region(path);      
            }
        }
        private void EmailLabel_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        
        private void Email_TextChanged(object sender, EventArgs e)
        {
            if (FSystem.validEmail(Email.Text)) {CheckMail.Visible = true;}
            else{CheckMail.Visible = false;}
        }


        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void ConfirmPass_TextChanged(object sender, EventArgs e)
        {
            if (ConfirmPass.Text != Password.Text) {
                confirmLabel.Visible = true;
            }
            else
            {
                confirmLabel.Visible = false;
            }
        }
        private void validUsername(string username)
        {
            //proper length?
            if (username.Length < 5)
            {
                lengthWarning.Visible = true;
            }
            else { lengthWarning.Visible = false; }
            //proper characters?
            for (int i = 0; i < username.Length; i++)
            {
                if (
                    !((username[i] >= 'A' && username[i] <= 'Z') ||
                    (username[i] >= 'a' && username[i] <= 'z') ||
                    (username[i] >= '0' && username[i] <= '9') ||
                    (username[i] == '_')
                    ))
                {
                    charWarning.Visible = true;
                    return;
                }

            }
            charWarning.Visible = false;
        }
        private void UserName_TextChanged(object sender, EventArgs e)
        {
            //check if username already is in use
            try
            {
                if (DB.Connection.State != System.Data.ConnectionState.Open)
                {
                    DB.Connection.Open();
                }

                string q = $"select count(*) from AllUser where username = '{UserName.Text.ToString()}'";
                using (SqlCommand cmd = new SqlCommand(q, DB.Connection))
                {
                    int n = (int)cmd.ExecuteScalar();
                    if (n > 0)
                    {
                        usernameWarning.Visible = true;
                    }
                    else
                    {
                        usernameWarning.Visible = false;
                    }
                }
                DB.Connection.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Something went wrong!", "DB ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine("ERROR: " + ex.Message);
            }
            //check if username is appropriate
            validUsername(UserName.Text); 
        }

        private void Password_TextChanged(object sender, EventArgs e)
        {
            string password = Password.Text;
            string pattern = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\w\d\s]).{8,}$";
            bool isValid = Regex.IsMatch(password, pattern);

            string strengthMessage = "Weak";
            if (isValid)
            {
                strengthMessage = "Strong";
            }
            else if (password.Length >= 8)
            {
                strengthMessage = "Medium";
            }

            lblPassStrength.Text = $"Password Strength: {strengthMessage}";
            lblPassStrength.ForeColor = strengthMessage == "Strong" ? Color.DarkBlue :
                                        strengthMessage == "Medium" ? Color.DarkOrchid : Color.Red;

            lblPassStrength.Visible = password.Length > 0;

        }
        private bool noSpaces(string text)
        {
            if (text.StartsWith(" ") || text.EndsWith(" ")) { return false; }
            else { return true; }
        }
        private bool noNumbers(string text)
        {
            if (text.Any(char.IsDigit)){ return false; }
            else { return true; }
        }
        private string capitalizeFirst(string text)
        {
            return char.ToUpper(text[0]) + text.Substring(1);
        }
        private void FirstName_TextChanged(object sender, EventArgs e)
        {
            if (!noSpaces(FirstName.Text)) { checkfname.Visible = true; }
            else { checkfname.Visible = false; }

            if (!noNumbers(FirstName.Text)) { noNumbers1.Visible = true; }
            else { noNumbers1.Visible = false; }

        }

        private void LastName_TextChanged(object sender, EventArgs e)
        {
            if (!noSpaces(LastName.Text)) { checklname.Visible = true; }
            else { checklname.Visible = false; }

            if (!noNumbers(LastName.Text)) { noNumbers2.Visible = true; }
            else { noNumbers2.Visible = false; }
        }
    }
}
