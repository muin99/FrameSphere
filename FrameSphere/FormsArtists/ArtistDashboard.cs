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
using System.Diagnostics;
using System.Windows.Forms.VisualStyles;

namespace FrameSphere
{
    public partial class ArtistDashboard : Form
    {
        public ArtistDashboard()
        {
            InitializeComponent();
        }

        private void CreateArt_Click(object sender, EventArgs e)
        {
            CreateArts createArts = new CreateArts();
            this.Hide();
            createArts.Show();
        }

        private void ArtistDashboard_Load(object sender, EventArgs e)
        {
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void artistboard_Click(object sender, EventArgs e)
        {

        }

        private void button14_Click(object sender, EventArgs e)
        {

        }

        private void returnDashBoard_button_Click(object sender, EventArgs e)
        {
            this.Hide();
            UserDashBoard user = new UserDashBoard();
            user.Show();   
        }

        private void ArtistDash_button_Click(object sender, EventArgs e)
        {
            MessageBox.Show("You are currently viewing Artist Dashboard");
        }

        private void adminDash_button_Click(object sender, EventArgs e)
        {
            if (FSystem.loggedInUser.isAdmin)
            {
                this.Hide();
                Admin_dashboard ad = new Admin_dashboard();
                ad.Show();
            }
        }

        private void editProfile_button_Click(object sender, EventArgs e)
        {
            this.Hide();
            Edit_Profile ep = new Edit_Profile();
            ep.Show();
        }

        private void facebook_pic_Click(object sender, EventArgs e)
        {
            try
            {
                string fb_URL = FSystem.loggedInUser.Facebook;
                if(fb_URL!=null)
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
            catch(Exception ex)
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

        private void TotalArts_label_Click(object sender, EventArgs e)
        {

        }
    }
}
