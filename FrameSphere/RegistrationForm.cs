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
                    try
                    {
                        cmd.ExecuteNonQuery();
                        Console.WriteLine("Registration successful.");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error: {ex.Message}");
                    }
                }
            }
        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            if (!CheckMail.Visible && !usernameWarning.Visible && !confirmLabel.Visible && !charWarning.Visible && UserName.Text != "" && Password.Text !="")
            {
                Register(FirstName.Text.ToString(), LastName.Text.ToString(), UserName.Text.ToString(), Email.Text.ToString(), Password.Text.ToString());
                this.Hide();

                LoginForm loginForm = new LoginForm();
                loginForm.ShowDialog();
            }
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            this.Hide();

            LoginForm loginForm = new LoginForm();
            loginForm.ShowDialog();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            Panel panel = (Panel)sender; // The panel triggering the event
            int borderRadius = 25; // Adjust the radius of the corners as needed

            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            Rectangle rect = new Rectangle(0, 0, panel.Width, panel.Height);

            // Create the rounded rectangle path
            using (System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath())
            {
                path.AddArc(rect.X, rect.Y, borderRadius, borderRadius, 180, 90);
                path.AddArc(rect.X + rect.Width - borderRadius, rect.Y, borderRadius, borderRadius, 270, 90);
                path.AddArc(rect.X + rect.Width - borderRadius, rect.Y + rect.Height - borderRadius, borderRadius, borderRadius, 0, 90);
                path.AddArc(rect.X, rect.Y + rect.Height - borderRadius, borderRadius, borderRadius, 90, 90);
                path.CloseAllFigures();

                // Set the panel's region to the rounded path
                panel.Region = new Region(path);

                // Optional: Draw the border
                
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
            if (Email.Text.Length == 0 || !Email.Text.Contains('@')) {
                CheckMail.Visible = true;
            }
            else
            {
                CheckMail.Visible = false;
            }
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

        private void UserName_TextChanged(object sender, EventArgs e)
        {
            //using (SqlConnection c = DB.Connect()) {
                DB.Connection.Open();
                string q = $"select count(*) from AllUser where username = '{UserName.Text.ToString()}'";
                using (SqlCommand cmd = new SqlCommand(q, DB.Connection))
                {
                    int n = (int) cmd.ExecuteScalar();
                    if (n > 0)
                    {
                        usernameWarning.Visible = true;
                    }
                    else { 
                        usernameWarning.Visible=false;
                    }
                }
                DB.Connection.Close();

            //}
            string username = UserName.Text;
            for (int i = 0; i < username.Length; i++) { 
                if(
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
    }
}
