using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using FrameSphere.EntityClasses;

namespace FrameSphere.FormsArts
{
    public partial class BuyArt : Form
    {
        private Art currentArt;
        private double bidAmount;


        public BuyArt(Art art, double amount)
        {
            this.currentArt = art;
            this.bidAmount = amount;
            InitializeComponent();
            LoadArtDetails();
        }


        private void LoadArtDetails()
        {
            ArtTitle.Text = currentArt.ArtTitle;
            amountToPay_field.Text = bidAmount.ToString();
            LoadArtPhoto(currentArt.ArtID);
        }

 
        private void LoadArtPhoto(int artId)
        {
            try
            {
                using (SqlConnection connection = DB.Connect())
                {
                    connection.Open();
                    string query = "SELECT Photo FROM ArtPhotos WHERE ArtID = @artId";

                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@artId", artId);
                        object result = cmd.ExecuteScalar();

                        if (result != null && result != DBNull.Value)
                        {
                            string imagePath = result.ToString();
                            ArtPhoto.Image = FSystem.GetImageFromPath(imagePath);
                        }
                        else
                        {
                            ArtPhoto.Image = Properties.Resources.defaultProfilePic; // Default image
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading image: " + ex.Message, "Image Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void checkout_button_Click(object sender, EventArgs e)
        {
            // Ensure a payment option is selected
            if (bKashOption_button.Checked || VisaOption_button.Checked)
            {
                try
                {
                    using (SqlConnection connection = DB.Connect())
                    {
                        connection.Open();

                        // Insert the purchase record into ArtSold
                        string queryInsert = "INSERT INTO ArtSold (UserName, ArtId, Amount) VALUES (@userName, @artId, @amount)";
                        using (SqlCommand cmdInsert = new SqlCommand(queryInsert, connection))
                        {
                            cmdInsert.Parameters.AddWithValue("@userName", FSystem.loggedInUser.UserName);
                            cmdInsert.Parameters.AddWithValue("@artId", currentArt.ArtID);
                            cmdInsert.Parameters.AddWithValue("@amount", bidAmount);
                            cmdInsert.ExecuteNonQuery();
                        }

                        // Delete the purchase request entry
                        string queryDelete = "DELETE FROM PurchaseRequests WHERE ArtID = @artId";
                        using (SqlCommand cmdDelete = new SqlCommand(queryDelete, connection))
                        {
                            cmdDelete.Parameters.AddWithValue("@artId", currentArt.ArtID);
                            cmdDelete.ExecuteNonQuery();
                        }
                    }

                    MessageBox.Show("Payment successful! Art purchased.", "Success", MessageBoxButtons.OK);
                    this.Close();
                }
                catch (Exception err)
                {
                    MessageBox.Show("Error during checkout: " + err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please choose a payment option", "Payment Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        private void returnToDashboard_button_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Dispose();
            UserDashBoard userDashBoard = new UserDashBoard();
            userDashBoard.Show();
        }
    }
}
