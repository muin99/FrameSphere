﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using FrameSphere.FormsArts;

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
            LoadArtDetails();
            InitializeRatings();
            LoadReviewData();

        }
        private void LoadArtDetails()
        {
            try
            {
                using (SqlConnection con = DB.Connect())
                {
                    con.Open();

                    // First get art title and description
                    string artSql = "SELECT ArtTitle, ArtDescription FROM Art WHERE ArtId = @ArtId";
                    using (SqlCommand artCmd = new SqlCommand(artSql, con))
                    {
                        artCmd.Parameters.AddWithValue("@ArtId", artId);
                        using (SqlDataReader artReader = artCmd.ExecuteReader())
                        {
                            if (artReader.Read())
                            {
                                artTitle.Text = artReader["ArtTitle"].ToString();
                                artdes.Text = artReader["ArtDescription"].ToString();
                            }
                            else
                            {
                                MessageBox.Show("Artwork not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                this.Close();
                                return;
                            }
                        }
                    }

                    // Now get associated photo from ArtPhotos
                    string photoSql = "SELECT TOP 1 Photo FROM ArtPhotos WHERE ArtId = @ArtId";
                    using (SqlCommand photoCmd = new SqlCommand(photoSql, con))
                    {
                        photoCmd.Parameters.AddWithValue("@ArtId", artId);
                        using (SqlDataReader photoReader = photoCmd.ExecuteReader())
                        {
                            if (photoReader.Read())
                            {
                                string relativePath = photoReader["Photo"].ToString();
                                string fullPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, relativePath);

                                if (File.Exists(fullPath))
                                {
                                    artphoto.SizeMode = PictureBoxSizeMode.Zoom;
                                    artphoto.Image = Image.FromFile(fullPath);
                                }
                                else
                                {
                                    artphoto.SizeMode = PictureBoxSizeMode.Zoom;
                                    artphoto.Image = Properties.Resources.SmallerNetworkConnectionBackgroundtest_ezgif_com_video_to_gif_converter;
                                    MessageBox.Show("Image file not found", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }
                            }
                            else
                            {
                                artphoto.Image = Properties.Resources.SmallerNetworkConnectionBackgroundtest_ezgif_com_video_to_gif_converter;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading artwork: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
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

        private void submitbtn_Click(object sender, EventArgs e)
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
                    string sql = @"
                IF EXISTS (SELECT 1 FROM Rating WHERE ArtId = @ArtId AND Username = @UserName)
                BEGIN
                    UPDATE Rating 
                    SET Rating = @Rating, Review = @Review, RatingDate = @ReviewDate
                    WHERE ArtId = @ArtId AND Username = @UserName;
                END
                ELSE
                BEGIN
                    INSERT INTO Rating (ArtId, Username, Rating, Review, RatingDate) 
                    VALUES (@ArtId, @UserName, @Rating, @Review, @ReviewDate);
                END";

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
                //reviewTextBox.Clear();
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

        private void rating1_Click(object sender, EventArgs e)
        {
            rating1.Image = Properties.Resources.rating_filled;
            rating2.Image = Properties.Resources.rating_hollow;
            rating3.Image = Properties.Resources.rating_hollow;
            rating4.Image = Properties.Resources.rating_hollow;
            rating5.Image = Properties.Resources.rating_hollow;
            selectedRating = 1;
        }

        private void rating2_Click(object sender, EventArgs e)
        {
            rating1.Image = Properties.Resources.rating_filled;
            rating2.Image = Properties.Resources.rating_filled;
            rating3.Image = Properties.Resources.rating_hollow;
            rating4.Image = Properties.Resources.rating_hollow;
            rating5.Image = Properties.Resources.rating_hollow;
            selectedRating = 2;
        }

        private void rating3_Click(object sender, EventArgs e)
        {
            rating1.Image = Properties.Resources.rating_filled;
            rating2.Image = Properties.Resources.rating_filled;
            rating3.Image = Properties.Resources.rating_filled;
            rating4.Image = Properties.Resources.rating_hollow;
            rating5.Image = Properties.Resources.rating_hollow;
            selectedRating = 3;
        }

        private void rating4_Click(object sender, EventArgs e)
        {
            rating1.Image = Properties.Resources.rating_filled;
            rating2.Image = Properties.Resources.rating_filled;
            rating3.Image = Properties.Resources.rating_filled;
            rating4.Image = Properties.Resources.rating_filled;
            rating5.Image = Properties.Resources.rating_hollow;
            selectedRating = 4;
        }

        private void rating5_Click(object sender, EventArgs e)
        {
            rating1.Image = Properties.Resources.rating_filled;
            rating2.Image = Properties.Resources.rating_filled;
            rating3.Image = Properties.Resources.rating_filled;
            rating4.Image = Properties.Resources.rating_filled;
            rating5.Image = Properties.Resources.rating_filled;
            selectedRating = 5;
        }

        private void seeall_Click(object sender, EventArgs e)
        {
            this.Hide();
            allReviews a = new allReviews(artId);
            a.Show();
        }
    }
}
