using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using FrameSphere.EntityClasses;

namespace FrameSphere.FormsArts
{
    public partial class SoldForm : Form
    {
        private Art _art;

        public SoldForm(Art art)
        {
            InitializeComponent();
            _art = art;
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
                                soldLabel.Text = $"This art is sold to {userName} at ${amount}";
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
    }
}
