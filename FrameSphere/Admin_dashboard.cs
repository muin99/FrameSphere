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
        }
        private void LoadUsers(string searchQuery = null)
        {
            usersPanel.Controls.Clear();
            string query = string.IsNullOrEmpty(searchQuery)
                ? "SELECT UserName, FirstName, LastName, Email, Status FROM AllUser"
                : "SELECT UserName, FirstName, LastName, Email, Status FROM AllUser WHERE UserName LIKE @SearchQuery";

            using (SqlConnection connection = DB.Connect())
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    if (!string.IsNullOrEmpty(searchQuery))
                    {
                        command.Parameters.AddWithValue("@SearchQuery", $"%{searchQuery}%");
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

        private void LoadEvents(string searchQuery = null)
        {
            eventsPanel.Controls.Clear();
            string query = string.IsNullOrEmpty(searchQuery)
                ? "SELECT EventID, Title FROM Events"
                : "SELECT EventID, Title FROM Events WHERE Title LIKE @SearchQuery";

            using (SqlConnection connection = DB.Connect())
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    if (!string.IsNullOrEmpty(searchQuery))
                    {
                        command.Parameters.AddWithValue("@SearchQuery", $"%{searchQuery}%");
                    }

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string eventId = reader["EventID"].ToString();
                            string title = reader["Title"].ToString();

                            CreateEventBox(eventId, title);
                        }
                    }
                }
            }
        }

        private void CreateUserBox(string userName, string fullName, string email, string status)
        {
            Panel userPanel = new Panel { Width = 500, Height = 50, BackColor = Color.LightGray, Margin = new Padding(5) };

            Label nameLabel = new Label { Text = fullName, Width = 150 };
            Label emailLabel = new Label { Text = email, Width = 200 };

            Button manageButton = new Button {
                Text = "Manage",
                Tag = userName, // Store User ID for reference
                Width = 80,
                Height = 30,
                BackColor = Color.LightBlue
            };
            manageButton.Click += (s, e) => OpenEditProfile(userName);

            ComboBox statusDropdown = new ComboBox { Width = 100, Text = status };
            statusDropdown.Items.AddRange(new string[] { "Active", "Inactive" });
            statusDropdown.SelectedIndexChanged += (s, e) => UpdateUserStatus(userName, statusDropdown.Text);

            userPanel.Controls.Add(nameLabel);
            userPanel.Controls.Add(emailLabel);
            userPanel.Controls.Add(manageButton);
            userPanel.Controls.Add(statusDropdown);

            usersPanel.Controls.Add(userPanel);
        }

        private void CreateEventBox(string eventId, string title)
        {
            Panel eventPanel = new Panel { Width = 500, Height = 50, BackColor = Color.LightGreen, Margin = new Padding(5) };

            Label titleLabel = new Label { Text = title, Width = 300 };

            Button manageButton = new Button {
                Text = "Manage",
                Tag = eventId, // Store Event ID for reference
                Width = 80,
                Height = 30,
                BackColor = Color.LightCoral
            };
            manageButton.Click += (s, e) => OpenManageEvents(eventId);

            ComboBox statusDropdown = new ComboBox { Width = 100, Text = "Pending" };
            statusDropdown.Items.AddRange(new string[] { "Pending", "Approved", "Rejected" });
            statusDropdown.SelectedIndexChanged += (s, e) => UpdateEventStatus(eventId, statusDropdown.Text);

            eventPanel.Controls.Add(titleLabel);
            eventPanel.Controls.Add(manageButton);
            eventPanel.Controls.Add(statusDropdown);

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

        private void SearchUsers(string query)
        {
            LoadUsers(query);
        }

        private void SearchEvents(string query)
        {
            LoadEvents(query);
        }
        private void Admin_dashboard_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            SearchEvents(usersearch.Text.ToString());
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
            SearchUsers(eventsearch.Text.ToString());
        }
    }
}
