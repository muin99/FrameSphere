using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FrameSphere.EntityClasses;
using FrameSphere.FormsUser;

namespace FrameSphere
{
    public partial class ArtDisplayForm : Form
    {
        public Art art;
        public User user;
        public string[] photos;  // Array for storing photos
        int ct = 0;
        int t = 0;
        int Artid;
        public ArtDisplayForm(int artid)
        {
            art = new Art(artid);
            Artid = artid;
            string username;
            using(SqlConnection con = DB.Connect())
            {
                con.Open();
                string q = $"select username from ArtArtist where artid = '{artid}'";
                SqlCommand cmd = new SqlCommand(q, con);
                username = cmd.ExecuteScalar().ToString();
            }
            user = new User(username);
            InitializeComponent();
            name.Text = user.FullName();
            userName.Text = "@" + user.UserName;
            phone.Text = user.Phone;
            email.Text = user.Email;
            address.Text = user.Address;
            title.Text = art.ArtTitle;
            Description.Text = art.ArtDescription;

            using (SqlConnection con = DB.Connect())
            {
                con.Open();
                string q = $"SELECT photo FROM ArtPhotos WHERE artid = {art.ArtID}";
                SqlCommand cmd = new SqlCommand(q, con);
                SqlDataReader reader = cmd.ExecuteReader();

                List<string> tempPhotos = new List<string>();
                while (reader.Read())
                {
                    tempPhotos.Add(reader["photo"].ToString());
                }
                reader.Close();

                ct = tempPhotos.Count;
                photos = tempPhotos.ToArray();


            }
            ArtImage.Image = FSystem.GetImageFromPath(photos[t]);
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();

        }

        private void facebook_pic_Click(object sender, EventArgs e)
        {
            try
            {
                string fb_URL = FSystem.loggedInUser.Facebook;
                if (fb_URL != null)
                {
                    Process.Start(new ProcessStartInfo {
                        FileName = fb_URL,
                        UseShellExecute = true
                    });
                }
                else
                {
                    Process.Start(new ProcessStartInfo {
                        FileName = "#",
                        UseShellExecute = true
                    });
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred:{ex.Message}");
            }
        }

        private void instagram_link_Click(object sender, EventArgs e)
        {
            try
            {
                string insta_URL = FSystem.loggedInUser.Instagram;
                if (insta_URL != null)
                {
                    Process.Start(new ProcessStartInfo {
                        FileName = insta_URL,
                        UseShellExecute = true
                    });
                }
                else
                {
                    Process.Start(new ProcessStartInfo {
                        FileName = "#",
                        UseShellExecute = true
                    });
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred:{ex.Message}");
            }
        }

        private void pinterest_link_Click(object sender, EventArgs e)
        {

            try
            {
                string pint_URL = FSystem.loggedInUser.Pinterest;
                if (pint_URL != null)
                {
                    Process.Start(new ProcessStartInfo {
                        FileName = pint_URL,
                        UseShellExecute = true
                    });
                }
                else
                {
                    Process.Start(new ProcessStartInfo {
                        FileName = "#",
                        UseShellExecute = true
                    });
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred:{ex.Message}");
            }

        }

        private void website_link_Click(object sender, EventArgs e)
        {

            try
            {
                string web_URL = FSystem.loggedInUser.Website;
                if (web_URL != null)
                {
                    Process.Start(new ProcessStartInfo {
                        FileName = web_URL,
                        UseShellExecute = true
                    });
                }
                else
                {
                    Process.Start(new ProcessStartInfo {
                        FileName = "#",
                        UseShellExecute = true
                    });
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred:{ex.Message}");
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (t > 0)
            {
                ArtImage.Image = FSystem.GetImageFromPath(photos[--t]);
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (t < ct-1)
            {
                ArtImage.Image = FSystem.GetImageFromPath(photos[++t]);
            }
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void chat_Click(object sender, EventArgs e)
        {
            Chat chat = new Chat(user);
            chat.Show();
        }

        private void buy_Click(object sender, EventArgs e)
        {

        }

        private void review_Click(object sender, EventArgs e)
        {
            ArtReviewPage a1 = new ArtReviewPage(Artid);
            a1.ShowDialog();
        }
    }
}
