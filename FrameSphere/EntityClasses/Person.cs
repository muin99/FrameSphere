using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrameSphere.EntityClasses
{
    public abstract class Person
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
        

        public bool isLoggedIn { get; set; } = false;

        
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
        public void Logout(Form a)
        {
            FSystem.loggedInUser = null;
            a.Hide();
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
        }
        public Person(string username) {
            this.UserName = username;
        }
    }
}
