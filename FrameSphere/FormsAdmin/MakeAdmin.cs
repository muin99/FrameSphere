using System;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace FrameSphere
{
    public partial class MakeAdmin : Form
    {
        //public static MakeAdmin Instance { get; private set; }
        public MakeAdmin()
        {
            InitializeComponent();
            //Instance = this;

            string aquery = "SELECT TOP 1 RequestID, UserName, RequestedBy, Approvals, TotalAdmins, Status FROM PendingAdminRequests ORDER BY RequestID DESC";

            using (SqlConnection connection = DB.Connect())
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(aquery, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read()) // If there is data
                        {
                            string selectedUser = reader["UserName"].ToString();
                            string requestedBy = reader["RequestedBy"].ToString();
                            string approvals = reader["Approvals"].ToString();
                            string totalAdmins = reader["TotalAdmins"].ToString();
                            string status = reader["Status"].ToString();
                            reader.Close();
                            // Assuming you fetch user details separately based on UserName
                            string userQuery = "SELECT FirstName, LastName, Email FROM AllUser WHERE UserName = @UserName";
                            using (SqlCommand userCommand = new SqlCommand(userQuery, connection))
                            {
                                userCommand.Parameters.AddWithValue("@UserName", selectedUser);
                                using (SqlDataReader userReader = userCommand.ExecuteReader())
                                {
                                    if (userReader.Read())
                                    {
                                        string firstName = userReader["FirstName"].ToString();
                                        string lastName = userReader["LastName"].ToString();
                                        string email = userReader["Email"].ToString();
                                        string currentAdmin = requestedBy; // Assuming current admin is the one who requested

                                        // Populate form labels
                                        FirstName.Text = firstName;
                                        LastName.Text = lastName;
                                        Email.Text = email;
                                        UserName.Text = selectedUser;
                                        txt.Text = currentAdmin + " wants to make this user an Admin.";
                                        txt2.Text = "Do You Want To Give Approval..??";
                                    }
                                }
                            }
                        }
                    }
                }
            }
            

        }

        private void btnApprove_Click(object sender, EventArgs e)
        {
            string currentAdmin = FSystem.loggedInUser.UserName; // The logged-in admin

            using (SqlConnection connection = DB.Connect())
            {
                connection.Open();

                // Check if the request exists
                string checkRequestQuery = "SELECT RequestID, Approvals, TotalAdmins FROM PendingAdminRequests WHERE UserName = @UserName";
                using (SqlCommand checkCommand = new SqlCommand(checkRequestQuery, connection))
                {
                    checkCommand.Parameters.AddWithValue("@UserName", UserName.Text);
                    using (SqlDataReader reader = checkCommand.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            int requestID = Convert.ToInt32(reader["RequestID"]); // Get RequestID
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

                            // Check if the admin already approved this request
                            string checkApprovalQuery = "SELECT COUNT(*) FROM AdminApprovals WHERE RequestID = @RequestID AND AdminName = @AdminName";
                            using (SqlCommand checkApprovalCommand = new SqlCommand(checkApprovalQuery, connection))
                            {
                                checkApprovalCommand.Parameters.AddWithValue("@RequestID", requestID);
                                checkApprovalCommand.Parameters.AddWithValue("@AdminName", currentAdmin);

                                int approvalCount = (int)checkApprovalCommand.ExecuteScalar();
                                if (approvalCount > 0)
                                {
                                    MessageBox.Show("You have already approved this request.", "Duplicate Approval", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return;
                                }
                            }

                            // Log admin approval in AdminApprovals table
                            string insertApprovalLogQuery = "INSERT INTO AdminApprovals (RequestID, AdminName) VALUES (@RequestID, @AdminName)";
                            using (SqlCommand logCommand = new SqlCommand(insertApprovalLogQuery, connection))
                            {
                                logCommand.Parameters.AddWithValue("@RequestID", requestID);
                                logCommand.Parameters.AddWithValue("@AdminName", currentAdmin);
                                logCommand.ExecuteNonQuery();
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

                                // Delete related records from AdminApprovals first
                                string deleteAdminApprovalsQuery = "DELETE FROM AdminApprovals WHERE RequestID = @RequestID";
                                using (SqlCommand deleteAdminApprovalsCommand = new SqlCommand(deleteAdminApprovalsQuery, connection))
                                {
                                    deleteAdminApprovalsCommand.Parameters.AddWithValue("@RequestID", requestID);
                                    deleteAdminApprovalsCommand.ExecuteNonQuery();
                                }

                                // Now delete from PendingAdminRequests
                                string deleteRequestQuery = "DELETE FROM PendingAdminRequests WHERE RequestID = @RequestID";
                                using (SqlCommand deleteCommand = new SqlCommand(deleteRequestQuery, connection))
                                {
                                    deleteCommand.Parameters.AddWithValue("@RequestID", requestID);
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
                            a1.adminRequest.Visible = false;
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
