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

namespace FrameSphere
{
    public partial class ArtistApplications : Form
    {
        public ArtistApplications()
        {
            InitializeComponent();
            LoadArtists();
        }

        private void LoadArtists(string searchQuery = "")
        {
            artistpanel.Controls.Clear();
            artistpanel.Controls.Add(noevent);
            noevent.Visible = false;

            string query = string.IsNullOrEmpty(searchQuery)
                ? @"
            SELECT 
                a.Username, 
                au.FirstName, 
                au.LastName, 
                a.Status 
            FROM artists a
            INNER JOIN alluser au ON a.Username = au.Username"
                : @"
            SELECT 
                a.Username, 
                au.FirstName, 
                au.LastName, 
                a.Status 
            FROM artists a
            INNER JOIN alluser au ON a.Username = au.Username
            WHERE au.FirstName LIKE @SearchQuery OR au.LastName LIKE @SearchQuery OR a.Username LIKE @SearchQuery";

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
                        else
                        {
                            noevent.Visible = false;
                        }

                        while (reader.Read())
                        {
                            string username = reader["Username"].ToString();
                            string fullName = $"{reader["FirstName"]} {reader["LastName"]}";
                            string status = reader["Status"].ToString();
                            CreateArtistBox(fullName, status, username);
                        }
                    }
                }
            }
        }

        private void CreateArtistBox(string fullName, string status, string username)
        {
            int panelWidth = artistpanel.Width - 21;
            int panelHeight = 30;

            Panel artistPanel = new Panel {
                Size = new Size(panelWidth, panelHeight),
                Location = new Point(34, 7),
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle,
                Margin = new Padding(0, 0, 0, 5)
            };

            Label nameLabel = new Label {
                Text = fullName,
                Font = new Font("Arial", 8, FontStyle.Bold),
                Location = new Point(3, 5),
                AutoSize = false,
                Size = new Size(200, 14),
                ForeColor = Color.Black
            };

            ComboBox statusDropdown = new ComboBox {
                Location = new Point(210, 3),
                Size = new Size(120, 21),
                DropDownStyle = ComboBoxStyle.DropDownList,
                Font = new Font("Arial", 8),
                Tag = username // Store the username for updating the status
            };

            statusDropdown.Items.AddRange(new[] { "Pending", "Approved", "Rejected" });
            statusDropdown.SelectedItem = status;

            statusDropdown.SelectedIndexChanged += (sender, e) =>
            {
                string selectedStatus = statusDropdown.SelectedItem.ToString();
                UpdateArtistStatus(username, selectedStatus);
            };

            artistPanel.Controls.Add(nameLabel);
            artistPanel.Controls.Add(statusDropdown);
            artistpanel.Controls.Add(artistPanel);
        }

        private void UpdateArtistStatus(string username, string status)
        {
            string query = "UPDATE artists SET Status = @Status WHERE Username = @Username";

            using (SqlConnection connection = DB.Connect())
            {
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Status", status);
                        command.Parameters.AddWithValue("@Username", username);
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show($"Status updated successfully for {username}.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show($"Failed to update status for {username}.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            LoadArtists(textBox1.Text);
        }

        private void button1_Click_1(object sender, EventArgs e)//return button
        {
            this.Hide();
            Admin_dashboard ad = new Admin_dashboard();
            ad.Show();
        }

        private void eventsboard_Click(object sender, EventArgs e)
        {
            this.Hide();
            EventsAdminView eventsAdminView = new EventsAdminView();
            eventsAdminView.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("You are current viewing Artist Applications Page", "!", MessageBoxButtons.OK);
            return;
        }

        private void UserBoard_Click(object sender, EventArgs e)
        {
            this.Hide();
            Admin_dashboard ad = new Admin_dashboard();
            ad.Show();
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

        private void Logout_Click_1(object sender, EventArgs e)
        {
            FSystem.loggedInUser.Logout(this);
        }
    }
}
