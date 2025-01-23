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
    public partial class manageUser : Form
    {
        string uName;
        public manageUser(string uName)
        {
            InitializeComponent();
            this.uName = uName;
            LoadUserData(uName);
        }

        public void LoadUserData(string username)
        {
            using (SqlConnection connection = DB.Connect())
            {
                this.uName = username;
                connection.Open();
                string query = "SELECT UserName, Password, FirstName, LastName, Email, Status FROM AllUser WHERE UserName = @UserName";
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@username", username);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            firstname.Text = reader["FirstName"].ToString();
                            lastname.Text = reader["LastName"].ToString();
                            UserName.Text = reader["UserName"].ToString();
                            email.Text = reader["Email"].ToString();

                        }
                    }
                }
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void approvebutton_Click(object sender, EventArgs e)
        {
            var confirmation = MessageBox.Show(
    "Are you sure you want to approve this User?",
    "Confirm Approval",
    MessageBoxButtons.YesNo,
    MessageBoxIcon.Warning);

            if (confirmation == DialogResult.Yes)
            {
                try
                {
                    using (SqlConnection connection = DB.Connect())
                    {
                        string query = "UPDATE AllUser SET Status = 'Approved' WHERE UserName = @username";
                        using (SqlCommand cmd = new SqlCommand(query, connection))
                        {
                            cmd.Parameters.AddWithValue("@username", uName);
                            connection.Open();
                            cmd.ExecuteNonQuery();

                            MessageBox.Show("User Approved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }





                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error Approving User: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void rejectButton_Click(object sender, EventArgs e)
        {
            var confirmation = MessageBox.Show(
    "Are you sure you want to reject this User?",
    "Confirm Rejection",
    MessageBoxButtons.YesNo,
    MessageBoxIcon.Warning);

            if (confirmation == DialogResult.Yes)
            {
                try
                {
                    using (SqlConnection connection = DB.Connect())
                    {
                        string query = "UPDATE AllUser SET Status = 'Rejected' WHERE UserName = @username";
                        using (SqlCommand cmd = new SqlCommand(query, connection))
                        {
                            cmd.Parameters.AddWithValue("@username", uName);
                            connection.Open();
                            cmd.ExecuteNonQuery();

                            MessageBox.Show("User rejected successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }





                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error rejecting User: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Admin_dashboard a = new Admin_dashboard();
            a.Show();
            this.Hide();
        }
    }
}
