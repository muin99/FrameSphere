using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace FrameSphere
{
    
    public partial class Admin_dashboard : Form
    {
        public Admin_dashboard()
        {
            InitializeComponent();
            Loaduserboxes();

        }

        private void Loaduserboxes(string searchQuery = "")
        {
            userpanel.Controls.Clear();

            string query = (searchQuery == "")
                ? "SELECT UserName, FirstName, LastName, Email, Status FROM AllUser"
                : "SELECT UserName, FirstName, LastName, Email, Status FROM AllUser WHERE FirstName + ' ' + LastName LIKE @searchQuery";

            using (SqlConnection connection = DB.Connect())
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    if (!string.IsNullOrEmpty(searchQuery))
                    {
                        command.Parameters.AddWithValue("@searchQuery", "%" + searchQuery + "%");
                    }

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string userName = reader["UserName"].ToString();
                            string fullName = $"{reader["FirstName"]} {reader["LastName"]}";
                            string email = reader["Email"].ToString();
                            string status = reader["Status"].ToString();

                            CreateUserBox(userName, fullName, email, status);
                        }
                    }
                }
            }
        }

        private void CreateUserBox(string userName, string fullName, string email, string status)
        {
            int panelWidth = userpanel.Width - 21;
            int panelHeight = 23;

            Panel everyuser = new Panel {
                Size = new Size(panelWidth, panelHeight),
                BackColor = Color.WhiteSmoke,
                BorderStyle = BorderStyle.FixedSingle,
                Margin = new Padding(0,0,0,5)
            };

            Label nameLabel = new Label {
                Text = fullName,
                AutoSize = false,
                Size = new Size(400, 14),
                Font = new Font("Arial", 8, FontStyle.Bold),
                ForeColor = Color.Black,
                Location = new Point(3, 5)
            };

            Label manageLabel = new Label {
                Text = "Manage",
                Font = new Font("Arial", 8, FontStyle.Bold),
                Location = new Point(408, 5),
                AutoSize = false,
                Size = new Size(50, 14),
                ForeColor = Color.Red
            };

            manageLabel.Click += (sender, e) => {
                Edit_Profile m1 = new Edit_Profile(userName);
                this.Hide();
                m1.StartPosition = FormStartPosition.CenterParent;
                m1.ShowDialog();

            };

            Label statusLabel = new Label {
                Text = status,
                Font = new Font("Arial", 8, FontStyle.Bold),
                Location = new Point(463, 5),
                AutoSize = false,
                Size = new Size(62, 14),
                ForeColor = status == "Approved" ? Color.Green :
                            status == "Rejected" ? Color.Red : Color.Peru
            };

            everyuser.Controls.Add(nameLabel);
            everyuser.Controls.Add(manageLabel);
            everyuser.Controls.Add(statusLabel);


            userpanel.Controls.Add(everyuser);
        }



        private void Admin_dashboard_Load(object sender, EventArgs e)
        {

        }
        private void managelabel_Click(object sender, EventArgs e)
        {
            
        }
        private void button3_Click(object sender, EventArgs e)
        {

        }


        private void label1_Click(object sender, EventArgs e)
        {
            
        }

       
        private void dashBoardButton_Click(object sender, EventArgs e)//return button
        {
            this.Hide();
            UserDashBoard userDashBoard = new UserDashBoard();
            userDashBoard.Show();

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            Loaduserboxes(textBox2.Text);
        }

        private void eventsboard_Click(object sender, EventArgs e)//list of events button
        {
            this.Hide();
            EventsAdminView eventsAdminView = new EventsAdminView();
            eventsAdminView.Show();
        }

        private void button2_Click(object sender, EventArgs e)//artist applications button
        {
            this.Hide();
            ArtistApplications artistApplications = new ArtistApplications();
            artistApplications.Show();
        }

        private void UserBoard_Click(object sender, EventArgs e)//list of users button
        {
            MessageBox.Show("You are current viewing List of Users Page", "!", MessageBoxButtons.OK);
            return;
        }

        private void Logout_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
        }

        private void artlist_Click(object sender, EventArgs e)
        {
            AllArt a1 = new AllArt();
            a1.Show();
            this.Hide();
        }
    }
}
