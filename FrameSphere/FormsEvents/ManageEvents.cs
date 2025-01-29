using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrameSphere
{
    public partial class ManageEvents : Form
    {
        int id;

        public ManageEvents(int id)
        {
            InitializeComponent();
            this.id = id;
            LoadEventData(id);
        }

        public void LoadEventData(int eventid)
        {
            using (SqlConnection connection = DB.Connect())
            {
                this.id = eventid;
                connection.Open();
                string query = "SELECT EventID, Title, Description, OrganizerDetails, StartDate, EndDate, TicketPrice, EventPoster, Status FROM Events WHERE EventID = @ID";
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@ID", eventid);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            eventTitle_field.Text = reader["Title"].ToString();
                            eventDesc_field.Text = reader["Description"].ToString();
                            DateTime startDate = Convert.ToDateTime(reader["StartDate"]);
                            DateTime endDate = Convert.ToDateTime(reader["EndDate"]);
                            startdate.Text = startDate.ToString();
                            enddate.Text = endDate.ToString();
                            ticketprice_field.Text = reader["TicketPrice"].ToString();
                            OrgDetails_field.Text = reader["OrganizerDetails"].ToString();

                            byte[] eventPosterBytes = reader["EventPoster"] != DBNull.Value ? (byte[])reader["EventPoster"] : null;
                            Image eventPosterImage = eventPosterBytes != null ? Image.FromStream(new MemoryStream(eventPosterBytes)) : Properties.Resources._10_3__thumb;

                            if (eventPosterImage != null)
                            {
                                posterImage.Image = eventPosterImage;
                            }

                        }
                    }
                }
            }
        }



        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            var confirmation = MessageBox.Show(
    "Are you sure you want to reject this Event?",
    "Confirm Rejection",
    MessageBoxButtons.YesNo,
    MessageBoxIcon.Warning);

            if (confirmation == DialogResult.Yes)
            {
                try
                {
                    using (SqlConnection connection = DB.Connect())
                    {
                        string query = "UPDATE Events SET Status = 'Rejected' WHERE EventID = @ID";
                        using (SqlCommand cmd = new SqlCommand(query, connection))
                        {
                            cmd.Parameters.AddWithValue("@ID", id);
                            connection.Open();
                            cmd.ExecuteNonQuery();

                            MessageBox.Show("Event rejected successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }





                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error rejecting Event: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            
        }

        private void approvebutton_Click(object sender, EventArgs e)
        {
            var confirmation = MessageBox.Show(
    "Are you sure you want to Approve this Event?",
    "Confirm Rejection",
    MessageBoxButtons.YesNo,
    MessageBoxIcon.Warning);

            if (confirmation == DialogResult.Yes)
            {
                try
                {
                    using (SqlConnection connection = DB.Connect())
                    {
                        string query = "UPDATE Events SET Status = 'Approved' WHERE EventID = @ID";
                        using (SqlCommand cmd = new SqlCommand(query, connection))
                        {
                            cmd.Parameters.AddWithValue("@ID", id);
                            connection.Open();
                            cmd.ExecuteNonQuery();

                            MessageBox.Show("Event Approved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }



                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error Approving Event: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void manageevent_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Admin_dashboard a = new Admin_dashboard();
            a.Show();
            this.Hide();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void body_panel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void CurrentPWField_TextChanged(object sender, EventArgs e)
        {

        }

        private void participants_button_Click(object sender, EventArgs e)
        {
            this.Hide();

        }
    }
}
