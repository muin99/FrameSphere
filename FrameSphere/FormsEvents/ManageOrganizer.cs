using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using FrameSphere.EntityClasses;

namespace FrameSphere.FormsEvents
{
    public partial class ManageOrganizer : Form
    {
        private Event currentEvent;

        public ManageOrganizer(Event selectedEvent)
        {
            InitializeComponent();
            currentEvent = selectedEvent;
            LoadAddedOrganizers();
            LoadPotentialOrganizers();
            SetupUI();
        }

        private void SetupUI()
        {
            // Form setup
            this.Text = "Manage Event Organizers";
            //lblCurrentOrganizers.Text = "Current Organizers:";
            //lblPotentialOrganizers.Text = "Add Organizers:";
            goBack_button.Text = "Back to Event";
        }

        private void LoadPotentialOrganizers(string search = "")
        {
            allorganizers.Controls.Clear();

            string query = string.IsNullOrWhiteSpace(search)
                ? "SELECT UserName FROM AllUser"
                : $"SELECT UserName FROM AllUser WHERE UserName LIKE '%{search}%'"; // Fixed concatenation
            try
            {
                using (SqlConnection conn = DB.Connect())
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@EventID", currentEvent.EventID);
                        cmd.Parameters.AddWithValue("@Search", $"%{search}%"); // Wildcards added here

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string userName = reader["UserName"].ToString();
                                CreateOrganizerPanel(userName, false);
                            }
                        }
                    }
                }
            }
            catch (SqlException e)
            {
                MessageBox.Show("Something went wrong! Try again later.", "DB Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine("DB ERROR: " + e.Message);
                return;
            }
            catch (Exception e)
            {
                MessageBox.Show("Something went wrong! Try again later.", "Unexpected Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine("UNEXPECTED ERROR: " + e.Message);
                return;
            }  
        }

        private void LoadAddedOrganizers()
        {
            currentOrganizers_panel.Controls.Clear();
            noOrganizers.Visible = false;

            string query = "SELECT UserName FROM Organizers WHERE EventId = @EventID";
            try
            {
                using (SqlConnection conn = DB.Connect())
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@EventID", currentEvent.EventID);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (!reader.HasRows)
                            {
                                noOrganizers.Visible = true;
                                return;
                            }

                            while (reader.Read())
                            {
                                string userName = reader["UserName"].ToString();
                                CreateOrganizerPanel(userName, true);
                            }
                        }
                    }
                }
            }
            catch (SqlException e)
            {
                MessageBox.Show("Something went wrong! Try again later.", "DB Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine("DB ERROR: " + e.Message);
                return;
            }
            catch (Exception e)
            {
                MessageBox.Show("Something went wrong! Try again later.", "Unexpected Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine("Error loading organizer list: " + e.Message);
                return;
            }
            
        }

        private void CreateOrganizerPanel(string userName, bool isCurrentOrganizer)
        {
            User user = new User(userName);
            var targetPanel = isCurrentOrganizer ? currentOrganizers_panel : allorganizers;
            Color panelColor = isCurrentOrganizer ? Color.LightGreen : Color.LightGray;
            string buttonText = isCurrentOrganizer ? "Remove" : "Add";
            Color buttonColor = isCurrentOrganizer ? Color.Red : Color.Green;

            Panel panel = new Panel {
                Size = new Size(targetPanel.Width - 25, 40),
                BackColor = panelColor,
                Margin = new Padding(5),
                Tag = userName
            };

            Label lblName = new Label {
                Text = $"{user.FirstName} {user.LastName}",
                Location = new Point(10, 10),
                AutoSize = true
            };

            Button actionButton = new Button {
                Text = buttonText,
                Size = new Size(75, 25),
                Location = new Point(panel.Width - 85, 7),
                BackColor = buttonColor,
                ForeColor = Color.White,
                Tag = userName
            };

            if (isCurrentOrganizer)
            {
                actionButton.Click += (s, e) => RemoveOrganizer(user);
            }
            else
            {
                actionButton.Click += (s, e) => AddOrganizer(user);
            }

            panel.Controls.Add(lblName);
            panel.Controls.Add(actionButton);
            targetPanel.Controls.Add(panel);
        }

        private void AddOrganizer(User organizer)
        {
            try
            {
                currentEvent.AddOrganizer(organizer);
                LoadAddedOrganizers();
                LoadPotentialOrganizers(SearchOrganizer_Field.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding organizer: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RemoveOrganizer(User organizer)
        {
            try
            {
                currentEvent.RemoveOrganizer(organizer);
                LoadAddedOrganizers();
                LoadPotentialOrganizers(SearchOrganizer_Field.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error removing organizer: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void goBack_button_Click(object sender, EventArgs e)
        {
            this.Close();
            ManageEvents e1 = new ManageEvents(currentEvent.EventID);
            e1.Show();
        }

        private void SearchOrganizer_Field_TextChanged(object sender, EventArgs e)
        {
            LoadPotentialOrganizers(SearchOrganizer_Field.Text);
        }
    }
}