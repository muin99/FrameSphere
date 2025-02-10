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

namespace FrameSphere.FormsArts
{
    public partial class allReviews : Form
    {
        public int artid;
        public allReviews(int artid)
        {
                this.artid = artid;
                InitializeComponent();
                LoadReviews();
                label1.Text = new Art(artid).ArtTitle;
            }


            private void LoadReviews()
            {
                 // Update with your DB connection string
                string query = "SELECT Username, Rating, Review, RatingDate FROM Rating WHERE ArtId = @ArtId ORDER BY RatingDate DESC";

                using (SqlConnection conn = DB.Connect())
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@ArtId", artid);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string username = reader["Username"].ToString();
                                int rating = Convert.ToInt32(reader["Rating"]);
                                string reviewText = reader["Review"].ToString();
                                DateTime ratingDate = Convert.ToDateTime(reader["RatingDate"]);

                                AddReviewToPanel(username, rating, reviewText, ratingDate);
                            }
                        }
                    }
                }
            }

            private void AddReviewToPanel(string username, int rating, string reviewText, DateTime ratingDate)
            {
                Panel reviewPanel = new Panel {
                    Size = new Size(evs.Width - 20, 100),
                    BorderStyle = BorderStyle.FixedSingle,
                    BackColor = Color.White
                };

                Label lblUsername = new Label {
                    Text = username,
                    Font = new Font("Arial", 10, FontStyle.Bold),
                    Location = new Point(10, 10),
                    AutoSize = true
                };

                Label lblDate = new Label {
                    Text = ratingDate.ToString("yyyy-MM-dd HH:mm"),
                    Font = new Font("Arial", 8),
                    Location = new Point(10, 30),
                    AutoSize = true,
                    ForeColor = Color.Gray
                };

                Label lblReview = new Label {
                    Text = reviewText,
                    Font = new Font("Arial", 10),
                    Location = new Point(10, 50),
                    Size = new Size(reviewPanel.Width - 120, 40),
                    AutoEllipsis = true
                };

                FlowLayoutPanel starsPanel = new FlowLayoutPanel {
                    Location = new Point(reviewPanel.Width - 110, 10),
                    AutoSize = true
                };

                for (int i = 1; i <= 5; i++)
                {
                    PictureBox star = new PictureBox {
                        Size = new Size(20, 20),
                        Image = i <= rating ? Properties.Resources.rating_filled : Properties.Resources.rating_hollow,
                        SizeMode = PictureBoxSizeMode.Zoom
                    };
                    starsPanel.Controls.Add(star);
                }

                reviewPanel.Controls.Add(lblUsername);
                reviewPanel.Controls.Add(lblDate);
                reviewPanel.Controls.Add(lblReview);
                reviewPanel.Controls.Add(starsPanel);

                evs.Controls.Add(reviewPanel);
            }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
    }
