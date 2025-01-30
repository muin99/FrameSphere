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
    public partial class ManageArtCollections : Form
    {
        private Art r;
        private User u;
        public ManageArtCollections(User e)
        {
            InitializeComponent();
            this.u = e;
           // LoadAddedArtists();
            LoadArtists();
        }
        private void LoadArtists(string search = "")
        {
            allartists.Controls.Clear(); // Clear previous items to avoid duplicates.
            try
            {
                // Query to fetch artists. Add filtering if a search string is provided.
                string q = string.IsNullOrWhiteSpace(search)
                    ? $"select a.artid, a.arttitle, aa.username from art a, artartist aa where a.artid = aa.artid and aa.username = '{u.UserName}'"
                    : $"SELECT UserName FROM Artists WHERE UserName LIKE '%{search}%'";

                using (SqlConnection conn = DB.Connect())
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(q, conn);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        string artID = reader["ArtId"].ToString();
                        string artTitle = reader["ArtTitle"].ToString();

                        artistPanel(artID, artTitle); // Create a panel for each artist.
                    }
                }
            }
            catch (Exception ex) { throw ex; }
            
        }

        private void artistPanel(string artID, string artTitle)
        {
            //Art a = new Art(artID);

            Panel artistPanel = new Panel {
                Size = new Size(allartists.Width - 10, 40),
                BackColor = Color.LightGray,
                Padding = new Padding(5),
                Margin = new Padding(3)
            };

            Label nameLabel = new Label {
                Text = artID + " " + artTitle,
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
                Tag = artID // Store artist name in Tag
            };
           // addButton.Click += (s, e) => AddArtist((Button)s, user);

            artistPanel.Controls.Add(nameLabel);
            artistPanel.Controls.Add(addButton);
            allartists.Controls.Add(artistPanel);
        }
        //private void AddArtist(Button btn, User user)
        //{
        //    if (!e.Artists.Any(a => a.UserName == user.UserName))
        //    {
        //        e.AddArtist(user); // Add artist to the event's artist list.
        //        AddedArtistPanel(user.UserName); // Add to the "Currently Participating" panel.
        //    }
        //    else
        //    {
        //        MessageBox.Show("This artist is already added!", "Duplicate Entry", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //    }
        //}

        //private void LoadAddedArtists()
        //{
        //    string q = $"Select username from ArtistEvent where eventId = {e.EventID}";

        //    using (SqlConnection conn = DB.Connect())
        //    {
        //        conn.Open();
        //        SqlCommand cmd = new SqlCommand(q, conn);
        //        SqlDataReader reader = cmd.ExecuteReader();
        //        while (reader.Read())
        //        {
        //            string i = reader["UserName"].ToString();
        //            AddedArtistPanel(i);
        //        }
        //    }


        //}

        //private void AddedArtistPanel(string id)
        //{
        //    User user = new User(id);
        //    Panel participant = new Panel {
        //        Size = new Size(participants_panel.Width - 10, 40),
        //        BackColor = Color.LightGreen,
        //        Padding = new Padding(5),
        //        Margin = new Padding(3)
        //    };

        //    Label name_label = new Label {
        //        Text = user.FirstName + " " + user.LastName,
        //        AutoSize = true,
        //        Font = new Font("Arial", 10, FontStyle.Bold),
        //        Location = new Point(5, 10)
        //    };

        //    Button remove_button = new Button {
        //        Text = "Remove",
        //        Size = new Size(75, 25),
        //        Location = new Point(participants_panel.Width - 85, 5),
        //        BackColor = Color.Red,
        //        ForeColor = Color.White,
        //        Tag = user.UserName // Store artist name in Tag
        //    };
        //    remove_button.Click += (s, e) => RemoveArtist((Button)s, user);

        //    participant.Controls.Add(name_label);
        //    participant.Controls.Add(remove_button);
        //    participants_panel.Controls.Add(participant);
        //}
        //private void RemoveArtist(Button btn, User user)
        //{
        //    e.RemoveArtist(user);
        //    participants_panel.Controls.Remove(btn.Parent); // Remove panel
        //}

        private void SearchArtist_Field_TextChanged(object sender, EventArgs e)
        {
            LoadArtists(SearchArtist_Field.Text);
        }
    }
}
