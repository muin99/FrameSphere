using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace FrameSphere
{
    public partial class UserEvents : Form
    {
        public UserEvents()
        {
            InitializeComponent();
            LoadEventBoxes();
        }

        private void LoadEventBoxes(string searchQuery = "")
        {
            eventpanel.Controls.Clear();
            eventpanel.Controls.Add(noevent);
            noevent.Visible = false;

            string loggedInUsername = FSystem.loggedInUser.UserName;

            string query = @"SELECT e.EventID, e.EventTitle, e.Status FROM Events e INNER JOIN Organizers o ON e.EventID = o.EventID WHERE o.UserName = @UserName";

            if (!string.IsNullOrEmpty(searchQuery))
            {
                query += " AND e.EventTitle LIKE @SearchQuery";
            }

            using (SqlConnection connection = DB.Connect())
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserName", loggedInUsername);

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

                        int x = 0;
                        while (reader.Read())
                        {
                            string title = reader["EventTitle"].ToString();
                            int eventid = Convert.ToInt32(reader["EventID"]);
                            string status = reader["Status"].ToString();
                            CreateEventsBox(++x, title, status, eventid);
                        }
                    }
                }
            }
        }


        private void CreateEventsBox(int x, string title, string status, int eventid)
        {
            int panelWidth = eventpanel.Width - 21;
            int panelHeight = 23;



            Panel everyevent = new Panel {
                Size = new Size(panelWidth, panelHeight),
                Location = new Point(34, 7),
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle,
                Margin = new Padding(0, 0, 0, 5)
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
                ManageEvents manageEventForm = new ManageEvents(eventid);
                this.Hide();
                manageEventForm.StartPosition = FormStartPosition.CenterParent;
                manageEventForm.ShowDialog();

            };

            Label numberlabel = new Label {
                Text = x.ToString() + ". ",
                Font = new Font("Arial", 8, FontStyle.Bold),
                Location = new Point(3, 5),
                AutoSize = false,
                Size = new Size(25, 14),
                ForeColor = Color.Black
            };

            Label titleLabel = new Label {
                Text = title,
                Font = new Font("Arial", 8, FontStyle.Bold),
                Location = new Point(40, 5),
                AutoSize = false,
                Size = new Size(400, 14),
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
            everyevent.Controls.Add(numberlabel);



            eventpanel.Controls.Add(everyevent);

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            LoadEventBoxes(textBox1.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UserDashBoard a = new UserDashBoard();
            a.Show();
            this.Hide();
        }
    }
}
