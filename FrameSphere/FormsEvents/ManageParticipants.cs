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
using FrameSphere.EntityClasses;

namespace FrameSphere.FormsEvents
{
    public partial class ManageParticipants : Form
    {
        private Event ep;
        public ManageParticipants(Event _selected)
        {
            InitializeComponent();
            this.ep = _selected;
            LoadAddedArtists();
            LoadArtists();
        }
        private void LoadArtists(string search = "")
        {
            allartists.Controls.Clear(); // Clear previous items to avoid duplicates.

            // Query to fetch artists. Add filtering if a search string is provided.
            string q = string.IsNullOrWhiteSpace(search)
                ? "SELECT UserName FROM Artists"
                : $"SELECT UserName FROM Artists WHERE UserName LIKE '%{search}%'";

            using (SqlConnection conn = DB.Connect())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(q, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string id = reader["UserName"].ToString();
                    artistPanel(id); // Create a panel for each artist.
                }
            }
        }

        private void artistPanel(string id)
        {
            User user = new User(id);

            Panel artistPanel = new Panel {
                Size = new Size(allartists.Width - 10, 40),
                BackColor = Color.LightGray,
                Padding = new Padding(5),
                Margin = new Padding(3)
            };

            Label nameLabel = new Label {
                Text = user.FirstName + " " + user.LastName,
                AutoSize = true,
                Font = new Font("Arial", 10, FontStyle.Bold),
                Location = new Point(5, 10)
            };

            Button addButton = new Button {
                Text = "Add",
                Size = new Size(75, 25),
                Location = new Point(allartists.Width - 85, 5),
                BackColor = Color.Green,
                ForeColor = Color.White,
                Tag = user.UserName // Store artist name in Tag
            };
            addButton.Click += (s, e) => AddArtist((Button)s, user);

            artistPanel.Controls.Add(nameLabel);
            artistPanel.Controls.Add(addButton);
            allartists.Controls.Add(artistPanel);
        }
        private void AddArtist(Button btn, User user)
        {
            if (!ep.Artists.Any(a => a.UserName == user.UserName))
            {
                ep.AddArtist(user); // Add artist to the event's artist list.
                AddedArtistPanel(user.UserName); // Add to the "Currently Participating" panel.
            }
            else
            {
                MessageBox.Show("This artist is already added!", "Duplicate Entry", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        private void LoadAddedArtists()
        {
            noArtists.Visible = false; // Hide "None" initially
            string q = $"Select username from ArtistEvent where eventId = {ep.EventID}";

            using (SqlConnection conn = DB.Connect())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(q, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                if (!reader.HasRows)
                {
                    noArtists.Visible = true; // Show "None" label if event has no participating artists yet
                    return;
                }
                while (reader.Read())
                {
                    string i = reader["UserName"].ToString();
                    AddedArtistPanel(i);
                }
            }

            
        }

        private void AddedArtistPanel(string id)
        {
            User user = new User(id);
            Panel participant = new Panel{
                Size = new Size(participants_panel.Width - 10, 40),
                BackColor = Color.LightGreen,
                Padding = new Padding(5),
                Margin = new Padding(3)
            };

            Label name_label = new Label {
                Text = user.FirstName+" "+user.LastName,
                AutoSize = true,
                Font = new Font("Arial", 10, FontStyle.Bold),
                Location = new Point(5, 10)
            };

            Button remove_button = new Button {
                Text = "Remove",
                Size = new Size(75, 25),
                Location = new Point(participants_panel.Width - 85, 5),
                BackColor = Color.Red,
                ForeColor = Color.White,
                Tag = user.UserName // Store artist name in Tag
            };
            remove_button.Click += (s, e) => RemoveArtist((Button)s, user);

            participant.Controls.Add(name_label);
            participant.Controls.Add(remove_button);
            participants_panel.Controls.Add(participant);
        }
        private void RemoveArtist(Button btn, User user)
        {
            ep.RemoveArtist(user);
            participants_panel.Controls.Remove(btn.Parent); // Remove panel
        }

        private void SearchArtist_Field_TextChanged(object sender, EventArgs e)
        {
            LoadArtists(SearchArtist_Field.Text);
        }

        private void goBack_button_Click(object sender, EventArgs e)
        {
            this.Hide();
            ManageEvents mn = new ManageEvents(ep.EventID);
            mn.Show();
        }

        private void Logout_Click(object sender, EventArgs e)
        {
            FSystem.loggedInUser.Logout(this);
        }
    }
}
