using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Tracing;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FrameSphere.EntityClasses;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace FrameSphere
{
    public partial class CreateArts : Form
    {

        public CreateArts()
        {
            InitializeComponent();

            FSystem.loggedInUser.loadUser();

            name.Text = FSystem.loggedInUser.FullName();
            userName.Text = "@"+FSystem.loggedInUser.UserName;

            phone.Text = FSystem.loggedInUser.Phone;
            email.Text = FSystem.loggedInUser.Email;
            address.Text = FSystem.loggedInUser.Address;
            if (FSystem.loggedInUser.ProfilePic != null)
            {
                using (MemoryStream ms = new MemoryStream(FSystem.loggedInUser.ProfilePic))
                {
                    profilepic.Image = Image.FromStream(ms);
                }
            }

            if (FSystem.loggedInUser.isAdmin)
            {
                adminDashboard.Visible = true;
            }


        }

        private void EnterButton_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            if (button != null && button.Tag != null)
            {
                string eventId = button.Tag.ToString();
                Event_page eventPage = new Event_page(eventId); // Pass the event ID to the EventPage
                this.Hide();
                eventPage.Show(); // Show the EventPage
            }
        }



        private void button10_Click(object sender, EventArgs e)
        {
            this.Hide();
            CreateEvent createEvent = new CreateEvent();
            createEvent.ShowDialog(this);

        }

        private void button14_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Edit_Profile edit_Profile = new Edit_Profile();
            edit_Profile.Show();
        }

        private void Logout_Click(object sender, EventArgs e)
        {
            FSystem.loggedInUser.Logout(this);
        }

        private void adminDashboard_Click(object sender, EventArgs e)
        {
            this.Hide();
            Admin_dashboard admin_Dashboard = new Admin_dashboard();
            admin_Dashboard.Show();
        }

        private void artistboard_Click(object sender, EventArgs e)
        {
            if (FSystem.loggedInUser.isArtist)
            {
                this.Hide();
                ArtistDashboard artistDashboard = new ArtistDashboard();
                artistDashboard.Show();
            }
            else
            {
                this.Hide();
                ApplyForArtist applyForArtist = new ApplyForArtist();
                applyForArtist.Show();
            }
        }

    }
}
