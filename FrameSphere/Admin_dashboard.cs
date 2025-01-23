using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace FrameSphere
{
    public partial class Admin_dashboard : Form
    {
        public Admin_dashboard()
        {
            InitializeComponent();
            LoadUsers();
            LoadEvents();
        }
        private void LoadUsers(string searchQuery = "")
        {
            usersPanel.Controls.Clear();

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
                        // Add wildcards for the LIKE clause
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
            Panel userPanel = new Panel {
                Width = 543,
                Height = 50,
                BackColor = Color.WhiteSmoke,
                BorderStyle = BorderStyle.FixedSingle,
                Padding = new Padding(10),
                Margin = new Padding(0, 10, 0, 10)
            };

            Label nameLabel = new Label {
                Text = fullName,
                Width = 200,
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                ForeColor = Color.Black,
                Location = new Point(10, 15)
            };

            ComboBox statusDropdown = new ComboBox {
                Width = 150,
                Location = new Point(220, 10),
                Font = new Font("Segoe UI", 9F),
                DropDownStyle = ComboBoxStyle.DropDownList,
                BackColor = Color.White
            };
            statusDropdown.Items.AddRange(new string[] { "Pending", "Approved", "Rejected" });
            statusDropdown.SelectedItem = status; // Ensure current status is displayed
            statusDropdown.SelectedIndexChanged += (s, e) =>
            {
                UpdateUserStatus(userName, statusDropdown.Text);
                LoadUsers(); // Reload to reflect changes
            };

            Button manageButton = new Button {
                Text = "Manage",
                Location = new Point(400, 10),
                Width = 80,
                Height = 30,
                BackColor = Color.LightBlue,
                FlatStyle = FlatStyle.Flat
            };
            manageButton.Click += (s, e) => OpenEditProfile(userName);

            userPanel.Controls.Add(nameLabel);
            userPanel.Controls.Add(statusDropdown);
            userPanel.Controls.Add(manageButton);

            usersPanel.Controls.Add(userPanel);
        }

        private void LoadEvents(string searchQuery = "")
        {
            eventsPanel.Controls.Clear();

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
                        // Proper parameterized query with wildcards for LIKE clause
                        string formattedQuery = string.Join("%", searchQuery.ToCharArray()) + "%";
                        command.Parameters.AddWithValue("@SearchQuery", "%" + formattedQuery);
                    }

                    using (SqlDataReader reader = command.ExecuteReader())
                    {

                        while (reader.Read())
                        {
                            string eventId = reader["EventID"].ToString();
                            string title = reader["Title"].ToString();
                            string status = reader["Status"].ToString();

                            CreateEventBox(eventId, title, status);
                        }
                    }
                }
            }
        }



        private void CreateEventBox(string eventId, string title, string status)
        {
            Panel eventPanel = new Panel {
                Width = 543,
                Height = 50,
                BackColor = Color.WhiteSmoke,
                BorderStyle = BorderStyle.FixedSingle,
                Padding = new Padding(10),
                Margin = new Padding(0, 10, 0, 10)
            };

            Label titleLabel = new Label {
                Text = title,
                Width = 200,
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                ForeColor = Color.Black,
                Location = new Point(10, 15)
            };

            ComboBox statusDropdown = new ComboBox {
                Width = 150,
                Location = new Point(220, 10),
                Font = new Font("Segoe UI", 9F),
                DropDownStyle = ComboBoxStyle.DropDownList,
                BackColor = Color.White
            };
            statusDropdown.Items.AddRange(new string[] { "Pending", "Approved", "Rejected" });
            statusDropdown.SelectedItem = status; // Ensure current status is displayed
            statusDropdown.SelectedIndexChanged += (s, e) =>
            {
                UpdateEventStatus(eventId, statusDropdown.Text);
                LoadEvents(""); // Reload to reflect changes
            };

            Button manageButton = new Button {
                Text = "Manage",
                Location = new Point(400, 10),
                Width = 80,
                Height = 30,
                BackColor = Color.LightBlue,
                FlatStyle = FlatStyle.Flat
            };
            manageButton.Click += (s, e) => OpenManageEvents(eventId);

            eventPanel.Controls.Add(titleLabel);
            eventPanel.Controls.Add(statusDropdown);
            eventPanel.Controls.Add(manageButton);

            eventsPanel.Controls.Add(eventPanel);
        }






        private void OpenEditProfile(string userName)
        {
            // Open the Edit Profile Form and pass the userName
            Edit_Profile editForm = new Edit_Profile(userName);
            editForm.Show();
        }

        private void OpenManageEvents(string eventId)
        {
            // Open the Manage Events Form and pass the eventId
            ManageEvents manageForm = new ManageEvents(eventId);
            manageForm.Show();
        }

        private void UpdateUserStatus(string userName, string newStatus)
        {
            using (SqlConnection connection = DB.Connect())
            {
                connection.Open();
                string query = "UPDATE AllUser SET Status = @Status WHERE UserName = @UserName";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Status", newStatus);
                    command.Parameters.AddWithValue("@UserName", userName);
                    command.ExecuteNonQuery();
                }
            }
        }

        private void UpdateEventStatus(string eventId, string newStatus)
        {
            using (SqlConnection connection = DB.Connect())
            {
                connection.Open();
                string query = "UPDATE Events SET Status = @Status WHERE EventID = @EventID";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Status", newStatus);
                    command.Parameters.AddWithValue("@EventID", eventId);
                    command.ExecuteNonQuery();
                }
            }
        }

        private void Admin_dashboard_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
            LoadEvents(eventsearch.Text.ToString());
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

        private void eventsearch_TextChanged(object sender, EventArgs e)
        {
            LoadUsers(usersearch.Text.ToString());
        }
    }
}
