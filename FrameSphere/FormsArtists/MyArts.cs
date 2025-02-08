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

namespace FrameSphere.FormsArtists
{
    public partial class MyArts : Form
    {
        public MyArts()
        {
            InitializeComponent();
            LoadArtPanels();
        }

        private void LoadArtPanels(string searchQuery = "")
        {
            artsPanel.Controls.Clear();
            artsPanel.Controls.Add(noArtLabel);
            noArtLabel.Visible = false;

            string query = string.IsNullOrEmpty(searchQuery)
                ? $"SELECT art.ArtId, art.ArtTitle, art.SellingOption, art.Price FROM Art, ArtArtist where ArtArtist.username = '{FSystem.loggedInUser.UserName}' and art.artid=artartist.artid"
                : $"SELECT art.ArtId, art.ArtTitle, art.SellingOption, art.Price FROM Art, ArtArtist where ArtArtist.username = '{FSystem.loggedInUser.UserName}' and art.artid=artartist.artid and Art.ArtTitle LIKE @SearchQuery";

            using (SqlConnection connection = DB.Connect())
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    if (!string.IsNullOrEmpty(searchQuery))
                    {
                        command.Parameters.AddWithValue("@SearchQuery", "%" + searchQuery + "%");
                    }

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (!reader.HasRows)
                        {
                            noArtLabel.Visible = true;
                            return;
                        }

                        noArtLabel.Visible = false;
                        while (reader.Read())
                        {
                            string title = reader["ArtTitle"].ToString();
                            int artId = Convert.ToInt32(reader["ArtId"]);
                            string sellingOption = reader["SellingOption"].ToString();

                            // Handle potential NULL values for Price
                            decimal price = reader["Price"] is DBNull ? 0m : Convert.ToDecimal(reader["Price"]);

                            CreateArtPanel(title, sellingOption, price, artId);
                        }
                    }
                }
            }
        }

        private void CreateArtPanel(string title, string sellingOption, decimal price, int artId)
        {
            int panelWidth = artsPanel.Width - 21;
            int panelHeight = 23;

            Panel artPanel = new Panel {
                Size = new Size(panelWidth, panelHeight),
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
                ForeColor = Color.Red,
                Cursor = Cursors.Hand
            };

            manageLabel.Click += (sender, e) => {
                // Create and show manage art form
                ManageArt manageArtForm = new ManageArt(artId);
                this.Hide();
                manageArtForm.StartPosition = FormStartPosition.CenterParent;
                manageArtForm.ShowDialog();
            };

            Label titleLabel = new Label {
                Text = title,
                Font = new Font("Arial", 8, FontStyle.Bold),
                Location = new Point(3, 5),
                AutoSize = false,
                Size = new Size(250, 14),
                ForeColor = Color.Black
            };

            Label priceLabel = new Label {
                Text = price == 0m ? "N/A" : $"{price:C}",
                Font = new Font("Arial", 8, FontStyle.Bold),
                Location = new Point(300, 5),
                AutoSize = false,
                Size = new Size(80, 14),
                ForeColor = Color.DarkBlue
            };

            Label optionLabel = new Label {
                Text = sellingOption,
                Font = new Font("Arial", 8, FontStyle.Bold),
                Location = new Point(463, 5),
                AutoSize = false,
                Size = new Size(100, 14),
                ForeColor = sellingOption == "For Sale" ? Color.Green :
                          sellingOption == "Not for Sale" ? Color.Red : Color.Peru
            };

            artPanel.Controls.Add(manageLabel);
            artPanel.Controls.Add(titleLabel);
            artPanel.Controls.Add(priceLabel);
            artPanel.Controls.Add(optionLabel);

            artsPanel.Controls.Add(artPanel);
        }

        // Navigation button click handlers


        

        private void logoutButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm login = new LoginForm();
            login.Show();
        }

        private void searchTextBox_TextChanged_1(object sender, EventArgs e)
        {
            LoadArtPanels(searchTextBox.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            UserDashBoard ad = new UserDashBoard();
            ad.Show();
        }
    }
}