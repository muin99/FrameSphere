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
            LoadEventBoxes();
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
                manageUser m1 = new manageUser(userName);
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

        private void LoadEventBoxes(string searchQuery = "")
        {
            eventpanel.Controls.Clear();
            eventpanel.Controls.Add(noevent);
            noevent.Visible = false;


            string query = string.IsNullOrEmpty(searchQuery)
                ? "SELECT EventID, Title, Status FROM Events"
                : "SELECT EventID, Title, Status FROM Events WHERE Title LIKE @SearchQuery";

            using (SqlConnection connection = DB.Connect())
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    if (!string.IsNullOrEmpty(searchQuery))
                    {
                        string formattedQuery = string.Join("%", searchQuery.ToCharArray()) + "%";
                        command.Parameters.AddWithValue("@SearchQuery", "%" + formattedQuery);

                    }

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        
                        if (!reader.HasRows)
                        {
                            noevent.Visible = true;
                            return;
                        }
                        else { noevent.Visible = false; }
                        while (reader.Read())
                        {
                            string title = reader["Title"].ToString();
                            int eventid = Convert.ToInt32(reader["EventID"]);
                            string status = reader["Status"].ToString();
                            CreateEventsBox(title, status, eventid);


                        }
                    }
                }
            }
        }


        private void CreateEventsBox(string title, string status, int eventid)
        {
            int panelWidth = eventpanel.Width - 21;
            int panelHeight = 23;

            

            Panel everyevent = new Panel {
                Size = new Size(panelWidth, panelHeight),
                Location = new Point(34, 7),
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle,
                Margin = new Padding(0,0,0,5)
            };

            Label manageLabel = new Label {
                Text = "Manage",
                Font = new Font("Arial", 8, FontStyle.Bold),
                Location = new Point(408,5),
                AutoSize = false,
                Size = new Size(50, 14),
                ForeColor = Color.Red
            };

            manageLabel.Click += (sender, e) =>
            {
                manageevent manageEventForm = new manageevent(eventid);
                this.Hide();
                manageEventForm.StartPosition = FormStartPosition.CenterParent;
                manageEventForm.ShowDialog();
                
            };

            Label titleLabel = new Label {
                Text = title,
                Font = new Font("Arial", 8, FontStyle.Bold),
                Location = new Point(3, 5),
                AutoSize = false,
                Size = new Size(400,14),
                ForeColor = Color.Black
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
            
            everyevent.Controls.Add(manageLabel);
            everyevent.Controls.Add(titleLabel);
            everyevent.Controls.Add(statusLabel);
            

        

            eventpanel.Controls.Add(everyevent);
            
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            LoadEventBoxes(textBox1.Text);
        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
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
    }
}
