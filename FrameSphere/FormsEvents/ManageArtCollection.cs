using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using FrameSphere.EntityClasses;

namespace FrameSphere.FormsEvents
{
    public partial class ManageArtCollection : Form
    {
        private Event currentEvent;

        public ManageArtCollection(Event eventObj)
        {
            InitializeComponent();
            currentEvent = eventObj;
            LoadArt();
            LoadAddedArt();
        }

        private void LoadArt(string search = "")
        {
            allArts_panel.Controls.Clear();
            try
            {
                using (SqlConnection conn = DB.Connect())
                {
                    conn.Open();
                    SqlCommand cmd = CreateArtCommand(conn, search);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int artId = reader.GetInt32(0);
                            string artTitle = reader.GetString(1);
                            ArtPanel(artId, artTitle);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading art: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private SqlCommand CreateArtCommand(SqlConnection conn, string search)
        {
            string query = FSystem.loggedInUser.isAdmin
                ? "SELECT ArtId, ArtTitle FROM Art WHERE ArtTitle LIKE @search"
                : @"SELECT a.ArtId, a.ArtTitle 
                   FROM Art a
                   INNER JOIN ArtArtist aa ON a.ArtId = aa.ArtId
                   WHERE aa.UserName = @username AND a.ArtTitle LIKE @search";

            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@search", $"%{search}%");

            if (!FSystem.loggedInUser.isAdmin)
                cmd.Parameters.AddWithValue("@username", FSystem.loggedInUser.UserName);

            return cmd;
        }

        private void ArtPanel(int artId, string artTitle)
        {
            Panel panel = new Panel {
                Size = new Size(allArts_panel.Width - 25, 40),
                BackColor = Color.LightGray,
                Margin = new Padding(3)
            };

            Label lbl = new Label {
                Text = $"{artId} - {artTitle}",
                AutoSize = true,
                Location = new Point(10, 10)
            };

            Button btnAdd = new Button {
                Text = "Add",
                Size = new Size(75, 25),
                Location = new Point(panel.Width - 85, 7),
                BackColor = Color.Green,
                ForeColor = Color.White,
                Tag = artId
            };
            btnAdd.Click += (s, e) => AddArt(artId, artTitle);

            panel.Controls.Add(lbl);
            panel.Controls.Add(btnAdd);
            allArts_panel.Controls.Add(panel);
        }

        private void AddArt(int artId, string artTitle)
        {
            if (IsArtInEvent(artId))
            {
                MessageBox.Show("This art is already in the event", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                using (SqlConnection conn = DB.Connect())
                {
                    conn.Open();
                    new SqlCommand(
                        "INSERT INTO ArtEvent (ArtId, EventId) VALUES (@artId, @eventId)", conn) {
                        Parameters = {
                            new SqlParameter("@artId", artId),
                            new SqlParameter("@eventId", currentEvent.EventID)
                        }
                    }.ExecuteNonQuery();
                }
                AddedArtPanel(artId.ToString(), artTitle);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding art: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool IsArtInEvent(int artId)
        {
            using (SqlConnection conn = DB.Connect())
            {
                conn.Open();
                object result = new SqlCommand(
                    "SELECT COUNT(*) FROM ArtEvent WHERE ArtId = @artId AND EventId = @eventId", conn) {
                    Parameters = {
                        new SqlParameter("@artId", artId),
                        new SqlParameter("@eventId", currentEvent.EventID)
                    }
                }.ExecuteScalar();

                return Convert.ToInt32(result) > 0;
            }
        }

        private void LoadAddedArt()
        {
            submittedArts_panel.Controls.Clear();
            try
            {
                using (SqlConnection conn = DB.Connect())
                {
                    conn.Open();
                    using (SqlDataReader reader = new SqlCommand(
                        @"SELECT a.ArtId, a.ArtTitle 
                        FROM Art a
                        INNER JOIN ArtEvent ae ON a.ArtId = ae.ArtId
                        WHERE ae.EventId = @eventId", conn) {
                        Parameters = { new SqlParameter("@eventId", currentEvent.EventID) }
                    }.ExecuteReader())
                    {
                        if (!reader.HasRows)
                        {
                            noArts.Visible = true;
                            return;
                        }

                        while (reader.Read())
                        {
                            string artId = reader["ArtId"].ToString();
                            string artTitle = reader["ArtTitle"].ToString();
                            AddedArtPanel(artId, artTitle);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading added art: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AddedArtPanel(string artId, string artTitle)
        {
            Panel panel = new Panel {
                Size = new Size(submittedArts_panel.Width - 25, 40),
                BackColor = Color.LightGreen,
                Margin = new Padding(3)
            };

            Label lbl = new Label {
                Text = $"{artId} - {artTitle}",
                AutoSize = true,
                Location = new Point(10, 10)
            };

            Button btnRemove = new Button {
                Text = "Remove",
                Size = new Size(75, 25),
                Location = new Point(panel.Width - 85, 7),
                BackColor = Color.Red,
                ForeColor = Color.White,
                Tag = artId
            };
            btnRemove.Click += (s, e) => RemoveArt(int.Parse(artId));

            panel.Controls.Add(lbl);
            panel.Controls.Add(btnRemove);
            submittedArts_panel.Controls.Add(panel);
            noArts.Visible = false;
        }

        private void RemoveArt(int artId)
        {
            try
            {
                using (SqlConnection conn = DB.Connect())
                {
                    conn.Open();
                    new SqlCommand(
                        "DELETE FROM ArtEvent WHERE ArtId = @artId AND EventId = @eventId", conn) {
                        Parameters = {
                            new SqlParameter("@artId", artId),
                            new SqlParameter("@eventId", currentEvent.EventID)
                        }
                    }.ExecuteNonQuery();
                }

                foreach (Control panel in submittedArts_panel.Controls)
                {
                    if (panel is Panel p && p.Controls[0] is Label lbl && lbl.Text.StartsWith(artId.ToString()))
                    {
                        submittedArts_panel.Controls.Remove(p);
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error removing art: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SearchArt_Field_TextChanged(object sender, EventArgs e)
        {
            LoadArt(SearchArt_Field.Text);
        }

        private void goBack_button_Click(object sender, EventArgs e)
        {
            this.Hide();
            new ManageEvents(currentEvent.EventID).Show();
        }

        private void Logout_Click(object sender, EventArgs e)
        {
            FSystem.loggedInUser.Logout(this);
        }
    }
}