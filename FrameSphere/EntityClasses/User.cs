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
            return FirstName+" "+LastName;
        }

        public string Email { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Status { get; set; }
        public string ProfilePic { get; set; }
        public string Facebook { get; set; }
        public string Instagram { get; set; }
        public string Website { get; set; }
        public string Pinterest { get; set; }

        public int TotalVisitedEvents { get; private set; } = 0;

        public List<Event> VisitingEvents = new List<Event>();

        public bool isArtist { get; set; }
        public bool isAdmin { get; set; }
        public bool isLoggedIn { get; set; } = false;
        public bool checkPassword(string password)
        {
            string query = $"SELECT COUNT(*) FROM AllUser WHERE UserName = '{this.UserName}' AND Password = '{password}'";

            using (SqlConnection connection = DB.Connect())
            {
                try
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
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

            // Query to fetch data from the three tables
            string query = $@"SELECT 
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
                    AllUser au, 
                    UserContact uc, 
                    UserSocials us
                    WHERE 
                    uc.UserName = au.UserName 
                    AND uc.UserName = us.UserName
                    AND (au.UserName = '{userName}' or au.email = '{userName}')
                    AND au.password = '{password}'";

            using (SqlConnection connection = DB.Connect())
            {
                try
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                FirstName = reader["FirstName"].ToString();
                                LastName = reader["LastName"].ToString();
                                Email = reader["Email"].ToString();
                                this.UserName = reader["Username"].ToString();
                                Status = reader["Status"].ToString();
                                Phone = reader["Phone"].ToString();
                                Address = reader["Address"].ToString();
                                ProfilePic = reader["ProfilePic"].ToString();
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


        public User(string firstName, string lastName, string email, string password, string userName, string address, string phone, string status, string profilePic, string facebook, string instagram, string website, string pinterest, int totalVisitedEvents, List<Event> visitingEvents, bool isArtist, bool isAdmin, bool isLoggedIn)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = password;
            UserName = userName;
            Address = address;
            Phone = phone;
            Status = status;
            ProfilePic = profilePic;
            Facebook = facebook;
            Instagram = instagram;
            Website = website;
            Pinterest = pinterest;
            TotalVisitedEvents = totalVisitedEvents;
            VisitingEvents = visitingEvents;
            this.isArtist = isArtist;
            this.isAdmin = isAdmin;
            this.isLoggedIn = isLoggedIn;
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
