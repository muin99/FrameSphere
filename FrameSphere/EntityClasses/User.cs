using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace FrameSphere.EntityClasses
{
    public class User
    {
        private string _firstName;
        private string _lastName;
        private string _email;
        private string _password;
        private string _userName;
        private string _address;
        private string _phone;
        private string _status;
        private string _profilePic;
        private string _facebook;
        private string _instagram;
        private string _pinterest;
        private string _website;

        private SqlConnection connection;

        public string ProfilePic {
            get {
                using (connection = DB.Connect())
                {
                    string query = "SELECT ProfilePic FROM UserContact WHERE UserName = @UserName";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@UserName", _userName);
                    connection.Open();
                    _profilePic = command.ExecuteScalar()?.ToString();
                }
                return _profilePic;
            }
            set {
                _profilePic = value;
                using (connection = DB.Connect())
                {
                    string query = "UPDATE UserContact SET ProfilePic = @ProfilePic WHERE UserName = @UserName";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@ProfilePic", _profilePic);
                    command.Parameters.AddWithValue("@UserName", _userName);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public string FullName()
        {
            return FirstName + " " + LastName;
        }

        public string FirstName {
            get {
                using (connection = DB.Connect())
                {
                    string query = "SELECT FirstName FROM AllUser WHERE UserName = @UserName";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@UserName", _userName);
                    connection.Open();
                    _firstName = command.ExecuteScalar()?.ToString();
                }
                return _firstName;
            }
            set {
                _firstName = value;
                using (connection = DB.Connect())
                {
                    string query = "UPDATE AllUser SET FirstName = @FirstName WHERE UserName = @UserName";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@FirstName", _firstName);
                    command.Parameters.AddWithValue("@UserName", _userName);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public string LastName {
            get {
                using (connection = DB.Connect())
                {
                    string query = "SELECT LastName FROM AllUser WHERE UserName = @UserName";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@UserName", _userName);
                    connection.Open();
                    _lastName = command.ExecuteScalar()?.ToString();
                }
                return _lastName;
            }
            set {
                _lastName = value;
                using (connection = DB.Connect())
                {
                    string query = "UPDATE AllUser SET LastName = @LastName WHERE UserName = @UserName";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@LastName", _lastName);
                    command.Parameters.AddWithValue("@UserName", _userName);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public string Email {
            get {
                using (connection = DB.Connect())
                {
                    string query = "SELECT Email FROM UserContact WHERE UserName = @UserName";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@UserName", _userName);
                    connection.Open();
                    _email = command.ExecuteScalar()?.ToString();
                }
                return _email;
            }
            set {
                _email = value;
                using (connection = DB.Connect())
                {
                    string query = "UPDATE UserContact SET Email = @Email WHERE UserName = @UserName";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Email", _email);
                    command.Parameters.AddWithValue("@UserName", _userName);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }


        public string Password {
            get {
                using (connection = DB.Connect())
                {
                    string query = "SELECT Password FROM AllUser WHERE UserName = @UserName";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@UserName", _userName);
                    connection.Open();
                    _password = command.ExecuteScalar()?.ToString();
                }
                return _password;
            }
            set {
                _password = value;
                using (connection = DB.Connect())
                {
                    string query = "UPDATE AllUser SET Password = @Password WHERE UserName = @UserName";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Password", _password);
                    command.Parameters.AddWithValue("@UserName", _userName);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public string UserName {
            get { return _userName; }
            set { _userName = value; }
        }

        public string Address {
            get {
                using (connection = DB.Connect())
                {
                    string query = "SELECT Address FROM UserContact WHERE UserName = @UserName";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@UserName", _userName);
                    connection.Open();
                    _address = command.ExecuteScalar()?.ToString();
                }
                return _address;
            }
            set {
                _address = value;
                using (connection = DB.Connect())
                {
                    string query = "UPDATE UserContact SET Address = @Address WHERE UserName = @UserName";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Address", _address);
                    command.Parameters.AddWithValue("@UserName", _userName);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public string Phone {
            get {
                using (connection = DB.Connect())
                {
                    string query = "SELECT Phone FROM UserContact WHERE UserName = @UserName";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@UserName", _userName);
                    connection.Open();
                    _phone = command.ExecuteScalar()?.ToString();
                }
                return _phone;
            }
            set {
                _phone = value;
                using (connection = DB.Connect())
                {
                    string query = "UPDATE UserContact SET Phone = @Phone WHERE UserName = @UserName";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Phone", _phone);
                    command.Parameters.AddWithValue("@UserName", _userName);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public string Status {
            get {
                using (connection = DB.Connect())
                {
                    string query = "SELECT Status FROM AllUser WHERE UserName = @UserName";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@UserName", _userName);
                    connection.Open();
                    _status = command.ExecuteScalar()?.ToString();
                }
                return _status;
            }
            set {
                _status = value;
                using (connection = DB.Connect())
                {
                    string query = "UPDATE AllUser SET Status = @Status WHERE UserName = @UserName";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Status", _status);
                    command.Parameters.AddWithValue("@UserName", _userName);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public string Facebook {
            get {
                using (connection = DB.Connect())
                {
                    string query = "SELECT Facebook FROM UserSocials WHERE UserName = @UserName";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@UserName", _userName);
                    connection.Open();
                    _facebook = command.ExecuteScalar()?.ToString();
                }
                return _facebook;
            }
            set {
                _facebook = value;
                using (connection = DB.Connect())
                {
                    string query = "UPDATE UserSocials SET Facebook = @Facebook WHERE UserName = @UserName";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Facebook", _facebook);
                    command.Parameters.AddWithValue("@UserName", _userName);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public string Instagram {
            get {
                using (connection = DB.Connect())
                {
                    string query = "SELECT Instagram FROM UserSocials WHERE UserName = @UserName";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@UserName", _userName);
                    connection.Open();
                    _instagram = command.ExecuteScalar()?.ToString();
                }
                return _instagram;
            }
            set {
                _instagram = value;
                using (connection = DB.Connect())
                {
                    string query = "UPDATE UserSocials SET Instagram = @Instagram WHERE UserName = @UserName";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Instagram", _instagram);
                    command.Parameters.AddWithValue("@UserName", _userName);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public string Pinterest {
            get {
                using (connection = DB.Connect())
                {
                    string query = "SELECT Pinterest FROM UserSocials WHERE UserName = @UserName";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@UserName", _userName);
                    connection.Open();
                    _pinterest = command.ExecuteScalar()?.ToString();
                }
                return _pinterest;
            }
            set {
                _pinterest = value;
                using (connection = DB.Connect())
                {
                    string query = "UPDATE UserSocials SET Pinterest = @Pinterest WHERE UserName = @UserName";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Pinterest", _pinterest);
                    command.Parameters.AddWithValue("@UserName", _userName);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public string Website {
            get {
                using (connection = DB.Connect())
                {
                    string query = "SELECT Website FROM UserSocials WHERE UserName = @UserName";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@UserName", _userName);
                    connection.Open();
                    _website = command.ExecuteScalar()?.ToString();
                }
                return _website;
            }
            set {
                _website = value;
                using (connection = DB.Connect())
                {
                    string query = "UPDATE UserSocials SET Website = @Website WHERE UserName = @UserName";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Website", _website);
                    command.Parameters.AddWithValue("@UserName", _userName);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }


        //public string FirstName {
        //    get{

        //        string query = $"SELECT FirstName FROM AllUser WHERE Username = '{this.UserName}'";
        //        using (SqlConnection connection = DB.Connect())
        //        {
        //            try
        //            {
        //                connection.Open();
        //                using (SqlCommand command = new SqlCommand(query, connection))
        //                {
        //                    _firstname = (string)command.ExecuteScalar();
        //                    return _firstname;
        //                }
        //            }
        //            catch (Exception ex)
        //            {
        //                throw new Exception($"An error occurred while loading user data: {ex.Message}");
        //            }
        //        }
        //     }
        //    set {
        //        string query = $"UPDATE AllUser SET FirstName = '{value}' WHERE Username = '{this.UserName}'";
        //        using (SqlConnection connection = DB.Connect())
        //        {
        //            try
        //            {
        //                connection.Open();
        //                using (SqlCommand command = new SqlCommand(query, connection))
        //                {
        //                    command.ExecuteNonQuery();
        //                }
        //            }
        //            catch (Exception ex)
        //            {
        //                throw new Exception($"An error occurred while loading user data: {ex.Message}");
        //            }
        //        }
        //    }

        //}
        //public string LastName {
        //    get {
        //        string query = $"SELECT LastName FROM AllUser WHERE Username = '{this.UserName}'";
        //        using (SqlConnection connection = DB.Connect())
        //        {
        //            try
        //            {
        //                connection.Open();
        //                using (SqlCommand command = new SqlCommand(query, connection))
        //                {
        //                    _lastname = (string)command.ExecuteScalar();
        //                    return _lastname;
        //                }
        //            }
        //            catch (Exception ex)
        //            {
        //                throw new Exception($"An error occurred while loading user data: {ex.Message}");
        //            }
        //        }
        //    }
        //    set {
        //        string query = $"UPDATE AllUser SET LastName = '{value}' WHERE Username = '{this.UserName}'";
        //        using (SqlConnection connection = DB.Connect())
        //        {
        //            try
        //            {
        //                connection.Open();
        //                using (SqlCommand command = new SqlCommand(query, connection))
        //                {
        //                    command.ExecuteNonQuery();
        //                }
        //            }
        //            catch (Exception ex)
        //            {
        //                throw new Exception($"An error occurred while loading user data: {ex.Message}");
        //            }
        //        }
        //    }
        //}
        //public string FullName()
        //{
        //    return FirstName + " " + LastName;
        //}

        //public string Email { get; set; }
        //public string Password { get; set; }
        //public string UserName { get; set; }
        //public string Address { get; set; }
        //public string Phone { get; set; }
        //public string Status { get; set; }
        //public string ProfilePic { get; set; }
        //public string Facebook { get; set; }
        //public string Instagram { get; set; }
        //public string Website { get; set; }
        //public string Pinterest { get; set; }

        public int TotalVisitedEvents { get; private set; } = 0;
        public List<Event> VisitingEvents = new List<Event>();
        private bool _isArtist;
        public bool isArtist {
            get {
                string query = "SELECT COUNT(*) FROM artists WHERE username = @UserName AND status = 'Approved'";

                using (SqlConnection connection = DB.Connect())
                {
                    try
                    {
                        connection.Open();
                        using (SqlCommand cmd = new SqlCommand(query, connection))
                        {
                            cmd.Parameters.AddWithValue("@UserName", this.UserName);
                            int count = (int)cmd.ExecuteScalar();
                            FSystem.loggedInUser = new Artist(this.UserName);
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
        public List<Art> myArts = new List<Art>();
        public void loadArtList()
        {
            if (isArtist)
            {
                string query = $"select artId from ArtArtist where username = '{this.UserName}'";
                using (SqlConnection connection = DB.Connect())
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand(query, connection);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        int aid = Int32.Parse(reader["ArtId"].ToString());
                        Art a = new Art(aid);
                        myArts.Add(a);
                    }
                }
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

            string queryCheck = "SELECT COUNT(*) FROM artists WHERE username = @UserName";
            string queryInsert = "INSERT INTO artists (username, status) VALUES (@UserName, 'Pending')";

            using (SqlConnection connection = DB.Connect())
            {
                try
                {
                    connection.Open();

                    using (SqlCommand cmdCheck = new SqlCommand(queryCheck, connection))
                    {
                        cmdCheck.Parameters.AddWithValue("@UserName", this.UserName);
                        if ((int)cmdCheck.ExecuteScalar() > 0)
                        {
                            MessageBox.Show("You have already applied. Please wait for approval.");
                            return;
                        }
                    }

                    using (SqlCommand cmdInsert = new SqlCommand(queryInsert, connection))
                    {
                        cmdInsert.Parameters.AddWithValue("@UserName", this.UserName);
                        if (cmdInsert.ExecuteNonQuery() > 0)
                        {
                            MessageBox.Show("Application successful!");
                        }
                        else
                        {
                            MessageBox.Show("Something went wrong. Please try again.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}");
                }
            }
        }
        
        //public void loadUser()
        //{
        //    string query = $@"
        //        SELECT 
                     
                  
        //            au.Email, 
        //            au.UserName, 
        //            au.Status,
        //            uc.Phone, 
        //            uc.Address, 
        //            uc.ProfilePic,
        //            us.Facebook, 
        //            us.Instagram, 
        //            us.Pinterest, 
        //            us.Website
        //        FROM 
        //            AllUser au
        //        INNER JOIN UserContact uc ON uc.UserName = au.UserName
        //        INNER JOIN UserSocials us ON uc.UserName = us.UserName
        //        WHERE 
        //            au.UserName = '{this.UserName}'
        //    ";
      

        //    using (SqlConnection connection = DB.Connect())
        //    {
        //        try
        //        {
        //            connection.Open();
        //            using (SqlCommand command = new SqlCommand(query, connection))
        //            {
                      

        //                using (SqlDataReader reader = command.ExecuteReader())
        //                {
        //                    if (reader.Read())
        //                    {
        //                        //FirstName = reader["FirstName"].ToString();
        //                        //LastName = reader["LastName"].ToString();
        //                        Email = reader["Email"].ToString();
        //                        UserName = reader["UserName"].ToString();
        //                        Status = reader["Status"].ToString();
        //                        Phone = reader["Phone"].ToString();
        //                        Address = reader["Address"].ToString();
        //                        ProfilePic = reader["ProfilePic"].ToString();
        //                        Facebook = reader["Facebook"].ToString();
        //                        Instagram = reader["Instagram"].ToString();
        //                        Pinterest = reader["Pinterest"].ToString();
        //                        Website = reader["Website"].ToString();
        //                    }
        //                    else
        //                    {
        //                        throw new Exception("User not found.");
        //                    }
        //                }
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            throw new Exception($"An error occurred while loading user data: {ex.Message}");
        //        }
        //    }
        //}

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
        public User(string UserName) {
            this.UserName = UserName;
            //this.loadUser();
            //loadArtList();
        }

        //public User(string userName, string password)
        //{
        //    this.UserName = userName;

        //    string query = @"
        //        SELECT 
                    
        //            au.LastName, 
        //            au.Email, 
        //            au.UserName, 
        //            au.Status,
        //            uc.Phone, 
        //            uc.Address, 
        //            uc.ProfilePic,
        //            us.Facebook, 
        //            us.Instagram, 
        //            us.Pinterest, 
        //            us.Website
        //        FROM 
        //            AllUser au
        //        INNER JOIN UserContact uc ON uc.UserName = au.UserName
        //        INNER JOIN UserSocials us ON uc.UserName = us.UserName
        //        WHERE 
        //            (au.UserName = @UserName OR au.Email = @UserName)
        //            AND au.Password = @Password
        //    ";

        //    using (SqlConnection connection = DB.Connect())
        //    {
        //        try
        //        {
        //            connection.Open();

        //            using (SqlCommand command = new SqlCommand(query, connection))
        //            {
        //                command.Parameters.AddWithValue("@UserName", userName);
        //                command.Parameters.AddWithValue("@Password", password);

        //                using (SqlDataReader reader = command.ExecuteReader())
        //                {
        //                    if (reader.Read())
        //                    {
        //                        //FirstName = reader["FirstName"].ToString();
        //                        LastName = reader["LastName"].ToString();
        //                        Email = reader["Email"].ToString();
        //                        UserName = reader["UserName"].ToString();
        //                        Status = reader["Status"].ToString();
        //                        Phone = reader["Phone"].ToString();
        //                        Address = reader["Address"].ToString();
        //                        ProfilePic = reader["ProfilePic"].ToString();
        //                        Facebook = reader["Facebook"].ToString();
        //                        Instagram = reader["Instagram"].ToString();
        //                        Pinterest = reader["Pinterest"].ToString();
        //                        Website = reader["Website"].ToString();
        //                    }
        //                    else
        //                    {
        //                        throw new Exception("Invalid credentials.");
        //                    }
        //                }
        //            }

        //            string adminQuery = "SELECT COUNT(*) FROM adminlist WHERE UserName = @UserName";
        //            using (SqlCommand adminCommand = new SqlCommand(adminQuery, connection))
        //            {
        //                adminCommand.Parameters.AddWithValue("@UserName", this.UserName);
        //                isAdmin = (int)adminCommand.ExecuteScalar() > 0;
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            throw new Exception($"An error occurred during authentication: {ex.Message}");
        //        }
        //    }
        //}

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
