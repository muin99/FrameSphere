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
                if (FSystem.loggedInUser == null || string.IsNullOrEmpty(FSystem.loggedInUser.UserName))
                {
                    MessageBox.Show("Error: User not logged in or username is missing.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                using (SqlConnection con = DB.Connect())
                {
                    con.Open();
                    string sql = "SELECT Rating, Review FROM Rating WHERE ArtId = @ArtId AND Username = @UserName";
                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue("@ArtId", artId);
                        cmd.Parameters.AddWithValue("@UserName", (object)FSystem.loggedInUser.UserName ?? DBNull.Value);

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
                    string sql = "INSERT INTO Rating (ArtId, Username, Rating, Review, RatingDate) " +
                                 "VALUES (@ArtId, @UserName, @Rating, @Review, @ReviewDate)";
                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue("@ArtId", artId);
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
