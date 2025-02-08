using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using FrameSphere.EntityClasses;

namespace FrameSphere.FormsArts
{
    public partial class SoldForm : Form
    {
        private Art _art;
        int aid;

        public SoldForm(Art art)
        {
            InitializeComponent();
            _art = art;
            aid = art.ArtID;
            CheckArtStatus();
        }

        private void CheckArtStatus()
        {
            try
            {
                using (SqlConnection connection = DB.Connect())
                {
                    connection.Open();
                    string query = "SELECT UserName, Amount FROM ArtSold WHERE Artid = @artId";

                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@artId", _art.ArtID);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string userName = reader["UserName"].ToString();
                                decimal amount = Convert.ToDecimal(reader["Amount"]);
                                soldLabel.Text = $"This art is sold";
                                label1.Text = $"to {userName}";
                                label2.Text = $"at ${amount}";
                            }
                            else
                            {
                                soldLabel.Text = "This art is not sold yet.";
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error checking art status: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private int GetEventIdByArtId(int artId)
        {
            int eventId = -1; // Default value if no event is found

            try
            {
                using (SqlConnection connection = DB.Connect())
                {
                    connection.Open();
                    string query = "SELECT TOP 1 EventId FROM ArtEvent WHERE ArtId = @artId";

                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@artId", artId);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                eventId = Convert.ToInt32(reader["EventId"]);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error retrieving event ID: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return eventId;
        }


        private void returnBtn_Click(object sender, EventArgs e)
        {
            int eventId = GetEventIdByArtId(aid);

            if (eventId != -1) // Ensure a valid EventId was found
            {
                Event_page e1 = new Event_page(eventId);
                this.Hide();
                e1.Show();
            }
            else
            {
                MessageBox.Show("No associated event found for this art.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        
    }
}
