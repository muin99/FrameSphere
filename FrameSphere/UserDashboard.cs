using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
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
    public partial class UserDashBoard : Form
    {

        public UserDashBoard()
        {
            InitializeComponent();
            name.Text = FSystem.loggedInUser.FullName();
            userName.Text = "@"+FSystem.loggedInUser.UserName;

            phone.Text = FSystem.loggedInUser.Phone;
            email.Text = FSystem.loggedInUser.Email;
            address.Text = FSystem.loggedInUser.Address;

            if (FSystem.loggedInUser.isAdmin)
            {
                adminDashboard.Visible = true;
            }

            CreateEventBox("Party at the square photography competition.", "Lorem ipsum is simply dummy text...", "Ends in 22h:12m:15s", null);


            LoadEventBoxes();


        }
        private void LoadEventBoxes(string searchQuery = "")
        {
            eventspanel.Controls.Clear();
            eventspanel.Controls.Add(noitem);
            noitem.Visible = false;


            string query = string.IsNullOrEmpty(searchQuery)
                ? "SELECT Title, Description, EndDate, EventPoster FROM Events"
                : "SELECT Title, Description, EndDate, EventPoster FROM Events WHERE Title LIKE @SearchQuery";

            using (SqlConnection connection = DB.Connect())
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    if (!string.IsNullOrEmpty(searchQuery))
                    {
                        string formattedQuery = string.Join("%", searchQuery.ToCharArray()) + "%";
                        command.Parameters.AddWithValue("@SearchQuery", "%" + formattedQuery);

                    }

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (!reader.HasRows)
                        {
                            noitem.Visible = true;
                            return;
                        }
                        else { noitem.Visible = false; }
                        while (reader.Read())
                        {
                            string title = reader["Title"].ToString();
                            string description = reader["Description"].ToString();
                            DateTime endDate = Convert.ToDateTime(reader["EndDate"]);
                            byte[] eventPosterBytes = reader["EventPoster"] != DBNull.Value? (byte[])reader["EventPoster"] : null;

                            Image eventPosterImage = null;
                            if (eventPosterBytes != null)
                            {
                                eventPosterImage = Image.FromStream(new MemoryStream(eventPosterBytes));
                            }
                            else
                            {
                                eventPosterImage = FrameSphere.Properties.Resources._10_3__thumb;
                            }

                            CreateEventBox(title, description, endDate.ToString("dd-MM-yyyy HH:mm:ss"), eventPosterImage);
                        }
                    }
                }
            }
        }

        private void CreateEventBox(string title, string description, string time, Image eventImage)
        {
            int panelWidth = eventspanel.Width -20; 
            int panelHeight = 120;

            Panel boxPanel = new Panel {
                Size = new Size(panelWidth, panelHeight),
                BackColor = Color.LightGreen,
                BorderStyle = BorderStyle.FixedSingle,
                Margin = new Padding(10)
            };

            PictureBox pictureBox = new PictureBox {
                Size = new Size(100, 100),
                Location = new Point(10, 10),
                Image = eventImage,
                SizeMode = PictureBoxSizeMode.StretchImage
            };

            Label titleLabel = new Label {
                Text = title,
                Font = new Font("Arial", 12, FontStyle.Bold),
                Location = new Point(120, 10),
                AutoSize = false,
                Size = new Size(panelWidth - 230, 20),
                ForeColor = Color.Black
            };

            Label descriptionLabel = new Label {
                Text = description,
                Font = new Font("Arial", 10),
                Location = new Point(120, 40),
                AutoSize = false,
                Size = new Size(panelWidth - 230, 40), 
                ForeColor = Color.Gray
            };

            Label timeLabel = new Label {
                Text = time,
                Font = new Font("Arial", 10, FontStyle.Bold),
                ForeColor = Color.Red,
                Location = new Point(120, 90),
                AutoSize = true
            };

            Button enterButton = new Button {
                Text = "Enter",
                BackColor = Color.Green,
                ForeColor = Color.White,
                Size = new Size(80, 30),
                Location = new Point(panelWidth - 90, 40), 
                FlatStyle = FlatStyle.Flat
            };

            boxPanel.Controls.Add(pictureBox);
            boxPanel.Controls.Add(titleLabel);
            boxPanel.Controls.Add(descriptionLabel);
            boxPanel.Controls.Add(timeLabel);
            boxPanel.Controls.Add(enterButton);

            boxPanel.Dock = DockStyle.Top;

            eventspanel.Controls.Add(boxPanel);
        }


        private void button10_Click(object sender, EventArgs e)
        {
            this.Hide();
            CreateEvent createEvent = new CreateEvent();
            createEvent.ShowDialog(this);

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {

        }

        private void button12_Click(object sender, EventArgs e)
        {

        }

        private void button13_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button14_Click(object sender, EventArgs e)
        {

        }

        private void name_Click(object sender, EventArgs e)
        {

        }
        private void button14_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Edit_Profile edit_Profile = new Edit_Profile();
            edit_Profile.Show();
        }


        private void profilepic_Click(object sender, EventArgs e)
        {

        }

        private void Logout_Click(object sender, EventArgs e)
        {
            FSystem.loggedInUser.Logout(this);
        }

        private void eventspanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void eventspanel_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void eventspanel_Paint_2(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_TextChanged_2(object sender, EventArgs e)
        {
            LoadEventBoxes(textBox1.Text);
        }

        private void adminDashboard_Click(object sender, EventArgs e)
        {
            this.Hide();
            Admin_dashboard admin_Dashboard = new Admin_dashboard();
            admin_Dashboard.Show();
        }
    }
}
