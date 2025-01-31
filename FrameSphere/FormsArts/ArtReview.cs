using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using FrameSphere;

namespace FrameSphere
{
    public partial class ArtReviewPage : Form
    {
        private int artId;
        private int selectedRating = 0;

        public ArtReviewPage(int artId)
        {
            InitializeComponent();
            this.artId = artId;
            //name.Text = FSystem.loggedInUser.FullName();
            LoadReviewData();
            InitializeRatings();
        }

        private void LoadReviewData()
        {
            try
            {
                using (SqlConnection con = DB.Connect())
                {
                    con.Open();
                    string sql = "SELECT Rating, Review FROM ArtReviews WHERE ArtID = @ArtID AND UserID = @UserID";
                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue("@ArtID", artId);
                        cmd.Parameters.AddWithValue("@UserName", FSystem.loggedInUser.UserName);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                int existingRating = reader.GetInt32(0);
                                string existingReview = reader.GetString(1);
                                UpdateRating(existingRating);
                                reviewTextBox.Text = existingReview;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading review: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InitializeRatings()
        {
            rating1.Image = Properties.Resources.rating_hollow;
            rating2.Image = Properties.Resources.rating_hollow;
            rating3.Image = Properties.Resources.rating_hollow;
            rating4.Image = Properties.Resources.rating_hollow;
            rating5.Image = Properties.Resources.rating_hollow;
            selectedRating = 0;
        }

        private void UpdateRating(int rating)
        {
            selectedRating = rating;
            rating1.Image = rating >= 1 ? Properties.Resources.rating_filled : Properties.Resources.rating_hollow;
            rating2.Image = rating >= 2 ? Properties.Resources.rating_filled : Properties.Resources.rating_hollow;
            rating3.Image = rating >= 3 ? Properties.Resources.rating_filled : Properties.Resources.rating_hollow;
            rating4.Image = rating >= 4 ? Properties.Resources.rating_filled : Properties.Resources.rating_hollow;
            rating5.Image = rating >= 5 ? Properties.Resources.rating_filled : Properties.Resources.rating_hollow;
        }

        private void SubmitReview_Click(object sender, EventArgs e)
        {
            if (selectedRating == 0)
            {
                MessageBox.Show("Please select a rating.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string review = reviewTextBox.Text.Trim();
            if (string.IsNullOrEmpty(review))
            {
                MessageBox.Show("Please write a review.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection con = DB.Connect())
                {
                    string sql = "INSERT INTO ArtReviews (ArtID, UserID, Rating, Review, ReviewDate) " +
                                 "VALUES (@ArtID, @UserID, @Rating, @Review, @ReviewDate)";
                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue("@ArtID", artId);
                        cmd.Parameters.AddWithValue("@UserName", FSystem.loggedInUser.UserName);
                        cmd.Parameters.AddWithValue("@Rating", selectedRating);
                        cmd.Parameters.AddWithValue("@Review", review);
                        cmd.Parameters.AddWithValue("@ReviewDate", DateTime.Now);
                        con.Open();
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Review submitted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                InitializeRatings();
                reviewTextBox.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error submitting review: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
