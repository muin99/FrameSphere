using System;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace FrameSphere
{
    public partial class MakeAdmin : Form
    {
        public static MakeAdmin Instance { get; private set; }
        public MakeAdmin()
        {
            InitializeComponent();
            Instance = this;

        }

        private void btnApprove_Click(object sender, EventArgs e)
        {
            string currentAdmin = FSystem.loggedInUser.UserName; // The logged-in admin

            using (SqlConnection connection = DB.Connect())
            {
                connection.Open();

                // Check if the request exists
                string checkRequestQuery = "SELECT Approvals, TotalAdmins FROM PendingAdminRequests WHERE UserName = @UserName";
                using (SqlCommand checkCommand = new SqlCommand(checkRequestQuery, connection))
                {
                    checkCommand.Parameters.AddWithValue("@UserName", UserName.Text);
                    using (SqlDataReader reader = checkCommand.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            int approvals = Convert.ToInt32(reader["Approvals"]);
                            int totalAdmins = Convert.ToInt32(reader["TotalAdmins"]);
                            reader.Close(); // Close before executing another query

                            // Update approval count
                            string updateApprovalQuery = "UPDATE PendingAdminRequests SET Approvals = Approvals + 1 WHERE UserName = @UserName";
                            using (SqlCommand updateCommand = new SqlCommand(updateApprovalQuery, connection))
                            {
                                updateCommand.Parameters.AddWithValue("@UserName", UserName.Text);
                                updateCommand.ExecuteNonQuery();
                            }

                            // Check if all admins approved
                            if (approvals + 1 >= totalAdmins)
                            {
                                // Move to AdminList
                                string insertAdminQuery = "INSERT INTO AdminList (UserName) VALUES (@UserName)";
                                using (SqlCommand insertCommand = new SqlCommand(insertAdminQuery, connection))
                                {
                                    insertCommand.Parameters.AddWithValue("@UserName", UserName.Text);
                                    insertCommand.ExecuteNonQuery();
                                }

                                // Remove from PendingAdminRequests
                                string deleteRequestQuery = "DELETE FROM PendingAdminRequests WHERE UserName = @UserName";
                                using (SqlCommand deleteCommand = new SqlCommand(deleteRequestQuery, connection))
                                {
                                    deleteCommand.Parameters.AddWithValue("@UserName", UserName.Text);
                                    deleteCommand.ExecuteNonQuery();
                                }

                                MessageBox.Show("User has been successfully promoted to Admin!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("Approval recorded. Waiting for all admins to approve.", "Pending", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }

                            this.Close(); // Close the form after approval
                            Admin_dashboard a1 = new Admin_dashboard();
                            a1.Show();
                            return;
                        }
                    }
                }
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
