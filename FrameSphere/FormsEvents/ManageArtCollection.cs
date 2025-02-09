using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using FrameSphere.EntityClasses;

namespace FrameSphere.FormsEvents
{
    public partial class ManageArtCollection : Form
    {
        private Event ex; // Current event for the user
        public ManageArtCollection(Event a)
        {
            InitializeComponent();
            this.ex = a;
            LoadArt(); // Load all available arts
            LoadAddedArt(); // Load arts added for the current user and event
        }

        private void goBack_button_Click(object sender, EventArgs e)
        {
            this.Hide();
            ManageEvents mn = new ManageEvents(ex.EventID);
            mn.Show();
        }

        // Load all arts (left panel) based on search term
        private void LoadArt(string search = "")
        {
            allArts_panel.Controls.Clear(); // Clear previous items to avoid duplicates
            try
            {
                string query;
                // Parameterized query for security
                if (FSystem.loggedInUser.isAdmin)
                {
                    query = string.IsNullOrWhiteSpace(search)
                        ? "SELECT a.artid, a.arttitle FROM art a"
                        : "SELECT a.artid, a.arttitle FROM art a WHERE a.artTitle LIKE @search";
                }
                else
                {
                    query = string.IsNullOrWhiteSpace(search)
                        ? "SELECT a.artid, a.arttitle, aa.username FROM art a, artartist aa WHERE a.artid = aa.artid AND aa.username = @username"
                        : "SELECT a.artid, a.arttitle, aa.username FROM art a, artartist aa WHERE a.artid = aa.artid AND aa.username = @username AND a.artTitle LIKE @search";
                }

                using (SqlConnection conn = DB.Connect())
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        // Add parameters for security
                        cmd.Parameters.AddWithValue("@username", FSystem.loggedInUser.UserName);
                        if (!string.IsNullOrWhiteSpace(search))
                        {
                            cmd.Parameters.AddWithValue("@search", "%" + search + "%");
                        }

                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            int artID = Convert.ToInt32(reader["ArtId"]);
                            string artTitle = reader["ArtTitle"].ToString();
                            ArtPanel(artID, artTitle); // Create a panel for each art in allArts_panel
                        }
                    }
                }
            }
            catch (SqlException e)
            {
                MessageBox.Show("Something went wrong! Try again later.", "DB Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine("DB ERROR: " + e.Message);
            }
            catch (Exception e)
            {
                MessageBox.Show("Something went wrong! Try again later.", "Unexpected Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine("UNEXPECTED ERROR: " + e.Message);
            }
        }

        // Display art on the left panel
        private void ArtPanel(int artID, string artTitle)
        {
            Panel art = new Panel {
                Size = new Size(allArts_panel.Width - 10, 40),
                BackColor = Color.LightGray,
                Padding = new Padding(5),
                Margin = new Padding(3)
            };

            Label artLabel = new Label {
                Text = $"{artID} {artTitle}",
                AutoSize = true,
                Font = new Font("Arial", 10, FontStyle.Bold),
                Location = new Point(5, 10)
            };

            Button addButton = new Button {
                Text = "Add",
                Size = new Size(75, 25),
                Location = new Point(art.Width - 85, 5),
                BackColor = Color.Green,
                ForeColor = Color.White,
                Tag = artID // Store artId in Tag
            };
            addButton.Click += (s, e) => AddArt(artID);

            art.Controls.Add(artLabel);
            art.Controls.Add(addButton);
            allArts_panel.Controls.Add(art);
        }

        private void AddArt(int artId)
        {
            ex.AddArt(artId);
        }

        // Load added arts for the current user and event (right panel)
        private void LoadAddedArt()
        {
            noArts.Visible = false; // Hide "None" initially
            try
            {
                string query = @"
                    SELECT artId, artTitle 
                    FROM art 
                    WHERE artId IN (
                        SELECT artId FROM artArtist 
                        WHERE username IN (
                            SELECT username FROM artistEvent WHERE eventId = @eventId
                        )
                    )
                    AND artId IN (
                        SELECT artId FROM artEvent WHERE eventId = @eventId
                    );";

                using (SqlConnection conn = DB.Connect())
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        // Add parameters for eventId to avoid SQL injection
                        cmd.Parameters.AddWithValue("@eventId", ex.EventID);

                        SqlDataReader reader = cmd.ExecuteReader();

                        if (!reader.HasRows)
                        {
                            noArts.Visible = true; // Show "None" label if event has no art collections 
                            return;
                        }

                        while (reader.Read())
                        {
                            string artID = reader["ArtId"].ToString();
                            string artTitle = reader["ArtTitle"].ToString();
                            AddedArtPanel(artID, artTitle); // Display the art in the right panel
                        }
                    }
                }
            }
            catch (SqlException e)
            {
                MessageBox.Show("Something went wrong! Try again later.", "DB Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine("DB ERROR: " + e.Message);
            }
            catch (Exception e)
            {
                MessageBox.Show("Something went wrong! Try again later.", "Unexpected Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine("UNEXPECTED ERROR: " + e.Message);
            }
        }

        // Display added art on the right panel (submittedArts_panel)
        private void AddedArtPanel(string artID, string artTitle)
        {
            Panel art = new Panel {
                Size = new Size(submittedArts_panel.Width - 10, 40),
                BackColor = Color.LightGray,
                Padding = new Padding(5),
                Margin = new Padding(3)
            };

            Label artLabel = new Label {
                Text = $"{artID} {artTitle}",
                AutoSize = true,
                Font = new Font("Arial", 10, FontStyle.Bold),
                Location = new Point(5, 10)
            };

            Button remove_button = new Button {
                Text = "Remove",
                Size = new Size(75, 25),
                Location = new Point(art.Width - 85, 5),
                BackColor = Color.Red,
                ForeColor = Color.White,
                Tag = artID // Store artId in Tag
            };
            remove_button.Click += (s, e) => RemoveArt(artID);

            art.Controls.Add(artLabel);
            art.Controls.Add(remove_button);
            submittedArts_panel.Controls.Add(art);
        }

        // Remove art from the right panel
        private void RemoveArt(string artID)
        {
            int artId = Int32.Parse(artID);
            ex.RemoveArt(artId); // Remove from DB
            foreach (Control control in submittedArts_panel.Controls)
            {
                if (control is Panel && ((Panel)control).Controls.ContainsKey(artID))
                {
                    submittedArts_panel.Controls.Remove(control); // Remove from UI
                    break;
                }
            }
        }

        // Search arts when the text changes in the search field
        private void SearchArt_Field_TextChanged(object sender, EventArgs e)
        {
            LoadArt(SearchArt_Field.Text);
        }

        private void Logout_Click(object sender, EventArgs e)
        {
            FSystem.loggedInUser.Logout(this);
        }
    }
}
