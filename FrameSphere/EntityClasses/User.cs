using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrameSphere.EntityClasses
{
    public class User
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName()
        {
            return FirstName + " " + LastName;
        }

        public string Email { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Status { get; set; }
        public byte[] ProfilePic { get; set; }
        public string Facebook { get; set; }
        public string Instagram { get; set; }
        public string Website { get; set; }
        public string Pinterest { get; set; }

        public int TotalVisitedEvents { get; private set; } = 0;
        public List<Event> VisitingEvents = new List<Event>();
        private bool _isArtist;
        public bool isArtist {
            get {
                string query = "SELECT COUNT(*) FROM artists WHERE username = @UserName and status ='Approved'";

                using (SqlConnection connection = DB.Connect())
                {
                    try
                    {
                        connection.Open();
                        using (SqlCommand cmd = new SqlCommand(query, connection))
                        {
                            cmd.Parameters.AddWithValue("@UserName", this.UserName);
                            int count = (int)cmd.ExecuteScalar();
                            return count > 0;
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"An error occurred while checking if the user is an artist: {ex.Message}");
                        return false;
                    }
                }
            }
            set {
                _isArtist = value;
            }
        }

        private bool _isAdmin;
        public bool isAdmin {
            get {
                string query = "SELECT COUNT(*) FROM adminlist WHERE username = @UserName";

                using (SqlConnection connection = DB.Connect())
                {
                    try
                    {
                        connection.Open();
                        using (SqlCommand cmd = new SqlCommand(query, connection))
                        {
                            cmd.Parameters.AddWithValue("@UserName", this.UserName);
                            int count = (int)cmd.ExecuteScalar();
                            return count > 0;
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"An error occurred while checking if the user is an admin: {ex.Message}");
                        return false;
                    }
                }
            }
            set {
                _isAdmin = value;
            }
        }

        public bool isLoggedIn { get; set; } = false;

        public void applyforBecomingArtist()
        {
            if (isArtist)
            {
                MessageBox.Show("You are already an artist");
                return;
            }
            DB.Connection.Open();
            string qr = $"select count(*) from artists where username = '{this.UserName}'";
            SqlCommand c = new SqlCommand(qr, DB.Connection);
            if ((int)c.ExecuteScalar() > 0)
            {
                MessageBox.Show("You have already applied wait");
                return;
            }
            
            string q = $"insert into artists (username, status) values('{this.UserName}', 'Pending')";

            if (DB.Connection.State != System.Data.ConnectionState.Open)
            {
                DB.Connection.Open();
            }

            SqlCommand cmd = new SqlCommand(q, DB.Connection);

            if ((int)cmd.ExecuteNonQuery() > 0)
            {
                MessageBox.Show("Application successfull!");
                DB.Connection.Close();
            }
            else
            {
                MessageBox.Show("Either you have already applied or something went wrong.!");
                DB.Connection.Close();
            }



        }

        public void loadUser()
        {
            string userName = this.UserName;

            string query = @"
                SELECT 
                    au.UserName,
                    au.FirstName, 
                    au.LastName, 
                    au.Email, 
                    au.Username, 
                    au.Status,
                    uc.Phone, 
                    uc.Address, 
                    uc.ProfilePic,
                    us.Facebook, 
                    us.Instagram, 
                    us.Pinterest, 
                    us.Website
                FROM 
                    AllUser au
                INNER JOIN UserContact uc ON uc.UserName = au.UserName
                INNER JOIN UserSocials us ON uc.UserName = us.UserName
                WHERE 
                    au.UserName = @UserName
            ";

            using (SqlConnection connection = DB.Connect())
            {
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@UserName", userName);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                FirstName = reader["FirstName"].ToString();
                                LastName = reader["LastName"].ToString();
                                Email = reader["Email"].ToString();
                                this.UserName = reader["UserName"].ToString();
                                Status = reader["Status"].ToString();
                                Phone = reader["Phone"].ToString();
                                Address = reader["Address"].ToString();
                                // Corrected ProfilePic to read byte[] instead of string
                                ProfilePic = reader["ProfilePic"] as byte[];
                                Facebook = reader["Facebook"].ToString();
                                Instagram = reader["Instagram"].ToString();
                                Pinterest = reader["Pinterest"].ToString();
                                Website = reader["Website"].ToString();
                            }
                            else
                            {
                                throw new Exception("User not found.");
                            }
                        }
                    }

                    //string adminQuery = "SELECT COUNT(*) FROM adminlist WHERE UserName = @UserName";
                    //using (SqlCommand adminCommand = new SqlCommand(adminQuery, connection))
                    //{
                    //    adminCommand.Parameters.AddWithValue("@UserName", this.UserName);
                    //    int adminCount = (int)adminCommand.ExecuteScalar();

                    //    isAdmin = adminCount > 0;
                    //}
                }
                catch (Exception ex)
                {
                    throw new Exception($"An error occurred while fetching user data: {ex.Message}");
                }
            }
        }

        public bool CheckPassword(string password)
        {
            string query = "SELECT COUNT(*) FROM AllUser WHERE UserName = @UserName AND Password = @Password";

            using (SqlConnection connection = DB.Connect())
            {
                try
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@UserName", this.UserName);
                        command.Parameters.AddWithValue("@Password", password);

                        int count = (int)command.ExecuteScalar();
                        return count > 0;
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception($"An error occurred while checking the password: {ex.Message}");
                }
            }
        }

        public User() { }

        public User(string userName, string password)
        {
            this.UserName = userName;

            string query = @"
                SELECT 
                    au.UserName,
                    au.FirstName, 
                    au.LastName, 
                    au.Email, 
                    au.Username, 
                    au.Status,
                    uc.Phone, 
                    uc.Address, 
                    uc.ProfilePic,
                    us.Facebook, 
                    us.Instagram, 
                    us.Pinterest, 
                    us.Website
                FROM 
                    AllUser au
                INNER JOIN UserContact uc ON uc.UserName = au.UserName
                INNER JOIN UserSocials us ON uc.UserName = us.UserName
                WHERE 
                    (au.UserName = @UserName OR au.Email = @UserName)
                    AND au.Password = @Password
            ";

            using (SqlConnection connection = DB.Connect())
            {
                try
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@UserName", userName);
                        command.Parameters.AddWithValue("@Password", password);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                FirstName = reader["FirstName"].ToString();
                                LastName = reader["LastName"].ToString();
                                Email = reader["Email"].ToString();
                                this.UserName = reader["UserName"].ToString();
                                Status = reader["Status"].ToString();
                                Phone = reader["Phone"].ToString();
                                Address = reader["Address"].ToString();
                                // Corrected ProfilePic to read byte[] instead of string
                                ProfilePic = reader["ProfilePic"] as byte[];
                                Facebook = reader["Facebook"].ToString();
                                Instagram = reader["Instagram"].ToString();
                                Pinterest = reader["Pinterest"].ToString();
                                Website = reader["Website"].ToString();
                            }
                            else
                            {
                                throw new Exception("User not found.");
                            }
                        }
                    }

                    string adminQuery = "SELECT COUNT(*) FROM adminlist WHERE UserName = @UserName";
                    using (SqlCommand adminCommand = new SqlCommand(adminQuery, connection))
                    {
                        adminCommand.Parameters.AddWithValue("@UserName", this.UserName);
                        int adminCount = (int)adminCommand.ExecuteScalar();

                        isAdmin = adminCount > 0;
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception($"An error occurred while fetching user data: {ex.Message}");
                }
            }
        }

        public void Logout(Form a)
        {
            FSystem.loggedInUser = null;
            a.Hide();
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
        }

        public void VisitEvent(Event eventItem)
        {
            VisitingEvents.Add(eventItem);
            TotalVisitedEvents++;
        }

        public void DisplayProfile()
        {
            Console.WriteLine($"Name: {FirstName} {LastName}, Email: {Email}, Username: {UserName}, Total Events Attended: {TotalVisitedEvents}");
        }
    }
}
