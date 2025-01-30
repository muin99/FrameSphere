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
    public partial class Form1 : Form
    {
        private Event ex;
        public Form1(Event a)
        {
            InitializeComponent();
            this.ex = a;
            LoadArt();
            //ArtPanel("1", "cat");
            //LoadAddedArt();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void goBack_button_Click(object sender, EventArgs e)
        {
            this.Hide();
            ManageEvents mn = new ManageEvents(ex.EventID);
        }

        private void LoadArt(string search = "")
        {
            allArts_panel.Controls.Clear(); // Clear previous items to avoid duplicates.
            try
            {
                // Query to fetch art. Add filtering if a search string is provided.
                string q = string.IsNullOrWhiteSpace(search)
                    ? $"select a.artid, a.arttitle, aa.username from art a, artartist aa where a.artid = aa.artid and aa.username = '{FSystem.loggedInUser.UserName}'"
                    : $"select a.artid, a.arttitle, aa.username from art a, artartist aa where a.artid = aa.artid and aa.username = '{FSystem.loggedInUser.UserName}' and a.artTitle LIKE '%{search}%'";

                using (SqlConnection conn = DB.Connect())
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(q, conn);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        int artID = Int32.Parse(reader["ArtId"].ToString());
                        string artTitle = reader["ArtTitle"].ToString();

                        ArtPanel(artID, artTitle); // Create a panel for each art for allArts_panel.
                    }
                }
            }
            catch (Exception exx) { MessageBox.Show("An error occurred: " + exx.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }

        }
        private void ArtPanel(int artID, string artTitle)
        {
            Panel art = new Panel {
                Size = new Size(allArts_panel.Width - 10, 40),
                BackColor = Color.LightGray,
                Padding = new Padding(5),
                Margin = new Padding(3)
            };

            Label artLabel = new Label {
                Text = artID + " " + artTitle,
                AutoSize = true,
                Font = new Font("Arial", 10, FontStyle.Bold),
                Location = new Point(5, 10)
            };

            Button addButton = new Button {
                Text = "Add",
                Size = new Size(75, 25),
                Location = new Point(allArts_panel.Width - 85, 5),
                BackColor = Color.Green,
                ForeColor = Color.White,
                Tag = artID // Store artist name in Tag
            };
            addButton.Click += (s, e) => AddArt((Button)s, artID);

            art.Controls.Add(artLabel);
            art.Controls.Add(addButton);
            allArts_panel.Controls.Add(art);
        }

        private void AddArt(Button btn, int artId)
        {
            ex.AddArt(artId);
        }
        private void LoadAddedArt()
        {   
            try
            {
                string q = $"select ar.ArtId, ar.ArtTitle from Art ar, ArtEvent e where ar.artId= e.artId and eventId={ex.EventID};";
                using (SqlConnection conn = DB.Connect())
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(q, conn);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        string artID = reader["ArtId"].ToString();
                        string artTitle = reader["ArtTitle"].ToString();
                        AddedArtPanel(artID, artTitle);
                    }
                }
            }catch(Exception exxx) { MessageBox.Show("An error occurred: " + exxx.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            
        }

        private void AddedArtPanel(string artID, string artTitle)
        {
            Panel art = new Panel {
                Size = new Size(allArts_panel.Width - 10, 40),
                BackColor = Color.LightGray,
                Padding = new Padding(5),
                Margin = new Padding(3)
            };

            Label artLabel = new Label {
                Text = artID + " " + artTitle,
                AutoSize = true,
                Font = new Font("Arial", 10, FontStyle.Bold),
                Location = new Point(5, 10)
            };

            Button remove_button = new Button {
                Text = "Remove",
                Size = new Size(75, 25),
                Location = new Point(submittedArts_panel.Width - 85, 5),
                BackColor = Color.Red,
                ForeColor = Color.White,
                Tag = artID // Store artid in Tag
            };
            //remove_button.Click += (s, e) => RemoveArt((Button)s, artID);

            art.Controls.Add(artLabel);
            art.Controls.Add(remove_button);
            submittedArts_panel.Controls.Add(art);
        }
        //private void RemoveArt(Button btn, string art)
        //{
        //    ex.RemoveArt(art);
        //    submittedArts_panel.Controls.Remove(btn.Parent); // Remove panel
        //}

        private void SearchArt_Field_TextChanged(object sender, EventArgs e)
        {
            LoadArt(SearchArt_Field.Text);
        }
    }
}
