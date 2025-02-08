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
                try
                {
                    using (connection = DB.Connect())
                    {
                        string query = "SELECT ProfilePic FROM UserContact WHERE UserName = @UserName";
                        SqlCommand command = new SqlCommand(query, connection);
                        command.Parameters.AddWithValue("@UserName", UserName);
                        connection.Open();
                        _profilePic = command.ExecuteScalar()?.ToString();
                    }
                    return _profilePic;

                }
                catch (SqlException e)
                {
                    MessageBox.Show("Something went wrong! Try again later.", "DB Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Console.WriteLine("DB ERROR IN GETTING PROFILE IMAGE: " + e.Message);
                    return null;
                }
                catch (Exception e)
                {
                    MessageBox.Show("Something went wrong! Try again later.", "Unexpected Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Console.WriteLine("UNEXPECTED ERROR IN GETTING PROFILE IMAGE: " + e.Message);
                    return null;
                }
                
            }
            set {
                _profilePic = value;
                try
                {
                    using (connection = DB.Connect())
                    {
                        string query = "UPDATE UserContact SET ProfilePic = @ProfilePic WHERE UserName = @UserName";
                        SqlCommand command = new SqlCommand(query, connection);
                        command.Parameters.AddWithValue("@ProfilePic", _profilePic);
                        command.Parameters.AddWithValue("@UserName", UserName);
                        connection.Open();
                        command.ExecuteNonQuery();
                    }

                }
                catch (SqlException e)
                {
                    MessageBox.Show("Something went wrong! Try again later.", "DB Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Console.WriteLine("DB ERROR IN SETTING PROFILE IMAGE: " + e.Message);
                    return;
                }
                catch (Exception e)
                {
                    MessageBox.Show("Something went wrong! Try again later.", "Unexpected Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Console.WriteLine("UNEXPECTED ERROR IN SETTING PROFILE IMAGE: " + e.Message);
                    return;
                }
                
            }
        }
        public string FullName()
        {
            return FirstName + " " + LastName;
        }

        public string FirstName {
            get {
                try
                {
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
                catch (SqlException e)
                {
                    MessageBox.Show("Something went wrong! Try again later.", "DB Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Console.WriteLine("DB ERROR IN GETTING FIRSTNAME: " + e.Message);
                    return null;
                }
                catch (Exception e)
                {
                    MessageBox.Show("Something went wrong! Try again later.", "Unexpected Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Console.WriteLine("UNEXPECTED ERROR IN GETTING FIRSTNAME: " + e.Message);
                    return null;
                }
                
            }
            set {
                _firstName = value;
                try
                {
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
                catch (SqlException e)
                {
                    MessageBox.Show("Something went wrong! Try again later.", "DB Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Console.WriteLine("DB ERROR IN SETTING FIRSTNAME: " + e.Message);
                    return;
                }
                catch (Exception e)
                {
                    MessageBox.Show("Something went wrong! Try again later.", "Unexpected Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Console.WriteLine("UNEXPECTED ERROR IN SETTING FIRSTNAME: " + e.Message);
                    return;
                }
                
            }
        }
        public string LastName {
            get {
                try
                {
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
                catch (SqlException e)
                {
                    MessageBox.Show("Something went wrong! Try again later.", "DB Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Console.WriteLine("DB ERROR IN GETTING LASTNAME: " + e.Message);
                    return null;
                }
                catch (Exception e)
                {
                    MessageBox.Show("Something went wrong! Try again later.", "Unexpected Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Console.WriteLine("UNEXPECTED ERROR IN GETTING LASTNAME: " + e.Message);
                    return null;
                }
                
            }
            set {
                _lastName = value;
                try
                {
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
                catch (SqlException e)
                {
                    MessageBox.Show("Something went wrong! Try again later.", "DB Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Console.WriteLine("DB ERROR IN SETTING LASTNAME: " + e.Message);
                    return;
                }
                catch (Exception e)
                {
                    MessageBox.Show("Something went wrong! Try again later.", "Unexpected Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Console.WriteLine("UNEXPECTED ERROR IN SETTING LASTNAME: " + e.Message);
                    return;
                }
                
            }
        }

        public string Email {
            get {
                try
                {
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
                catch (SqlException e)
                {
                    MessageBox.Show("Something went wrong! Try again later.", "DB Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Console.WriteLine("DB ERROR IN GETTING EMAIL: " + e.Message);
                    return null;
                }
                catch (Exception e)
                {
                    MessageBox.Show("Something went wrong! Try again later.", "Unexpected Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Console.WriteLine("UNEXPECTED ERROR IN GETTING EMAIL: " + e.Message);
                    return null;
                }
                
            }
            set {
                _email = value;
                try
                {
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
                catch (SqlException e)
                {
                    MessageBox.Show("Something went wrong! Try again later.", "DB Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Console.WriteLine("DB ERROR IN SETTING EMAIL: " + e.Message);
                    return;
                }
                catch (Exception e)
                {
                    MessageBox.Show("Something went wrong! Try again later.", "Unexpected Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Console.WriteLine("UNEXPECTED ERROR IN SETTING EMAIL: " + e.Message);
                    return;
                }
                
            }
        }
        public string Password {
            get {
                try
                {
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
                catch (SqlException e)
                {
                    MessageBox.Show("Something went wrong! Try again later.", "DB Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Console.WriteLine("DB ERROR IN GETTING PASSWORD: " + e.Message);
                    return null;
                }
                catch (Exception e)
                {
                    MessageBox.Show("Something went wrong! Try again later.", "Unexpected Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Console.WriteLine("UNEXPECTED ERROR IN GETTING PASSWORD: " + e.Message);
                    return null;
                }
               
            }
            set {
                _password = value;
                try
                {
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
                catch (SqlException e)
                {
                    MessageBox.Show("Something went wrong! Try again later.", "DB Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Console.WriteLine("DB ERROR IN SETTING PASSWORD: " + e.Message);
                    return;
                }
                catch (Exception e)
                {
                    MessageBox.Show("Something went wrong! Try again later.", "Unexpected Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Console.WriteLine("UNEXPECTED ERROR IN SETTING PASSWORD: " + e.Message);
                    return;
                }
               
            }
        }

        public string UserName {
            get { return _userName; }
            set { _userName = value; }
        }

        public string Address {
            get {
                try
                {
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
                catch (SqlException e)
                {
                    MessageBox.Show("Something went wrong! Try again later.", "DB Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Console.WriteLine("DB ERROR IN GETTING ADDRESS: " + e.Message);
                    return null;
                }
                catch (Exception e)
                {
                    MessageBox.Show("Something went wrong! Try again later.", "Unexpected Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Console.WriteLine("UNEXPECTED ERROR IN GETTING ADDRESS: " + e.Message);
                    return null;
                }
                
            }
            set {
                _address = value;
                try
                {
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
                catch (SqlException e)
                {
                    MessageBox.Show("Something went wrong! Try again later.", "DB Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Console.WriteLine("DB ERROR IN SETTING ADDRESS: " + e.Message);
                    return;
                }
                catch (Exception e)
                {
                    MessageBox.Show("Something went wrong! Try again later.", "Unexpected Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Console.WriteLine("UNEXPECTED ERROR IN SETTING ADDRESS: " + e.Message);
                    return;
                }
                
            }
        }

        public string Phone {
            get {
                try
                {
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
                catch (SqlException e)
                {
                    MessageBox.Show("Something went wrong! Try again later.", "DB Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Console.WriteLine("DB ERROR IN GETTING PHONE: " + e.Message);
                    return null;
                }
                catch (Exception e)
                {
                    MessageBox.Show("Something went wrong! Try again later.", "Unexpected Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Console.WriteLine("UNEXPECTED ERROR IN GETTING PHONE: " + e.Message);
                    return null;
                }
            }
            set {
                _phone = value;
                try
                {
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
                catch (SqlException e)
                {
                    MessageBox.Show("Something went wrong! Try again later.", "DB Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Console.WriteLine("DB ERROR IN SETTING PHONE: " + e.Message);
                    return;
                }
                catch (Exception e)
                {
                    MessageBox.Show("Something went wrong! Try again later.", "Unexpected Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Console.WriteLine("UNEXPECTED ERROR IN SETTING PHONE: " + e.Message);
                    return;
                }
                
            }
        }
        public string Facebook {
            get {
                try
                {
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
                catch (SqlException e)
                {
                    MessageBox.Show("Something went wrong! Try again later.", "DB Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Console.WriteLine("DB ERROR IN GETTING FACEBOOK: " + e.Message);
                    return null;
                }
                catch (Exception e)
                {
                    MessageBox.Show("Something went wrong! Try again later.", "Unexpected Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Console.WriteLine("UNEXPECTED ERROR IN GETTING FACEBOOK: " + e.Message);
                    return null;
                }
               
            }
            set {
                _facebook = value;
                try
                {
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
                catch (SqlException e)
                {
                    MessageBox.Show("Something went wrong! Try again later.", "DB Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Console.WriteLine("DB ERROR IN SETTING FACEBOOK: " + e.Message);
                    return;
                }
                catch (Exception e)
                {
                    MessageBox.Show("Something went wrong! Try again later.", "Unexpected Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Console.WriteLine("UNEXPECTED ERROR IN SETTING FACEBOOK: " + e.Message);
                    return;
                }
                
            }
        }

        public string Instagram {
            get {
                try
                {
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
                catch (SqlException e)
                {
                    MessageBox.Show("Something went wrong! Try again later.", "DB Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Console.WriteLine("DB ERROR IN GETTING INSTAGRAM: " + e.Message);
                    return null;
                }
                catch (Exception e)
                {
                    MessageBox.Show("Something went wrong! Try again later.", "Unexpected Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Console.WriteLine("UNEXPECTED ERROR IN GETTING INSTAGRAM: " + e.Message);
                    return null;
                }
                
            }
            set {
                _instagram = value;
                try
                {
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
                catch (SqlException e)
                {
                    MessageBox.Show("Something went wrong! Try again later.", "DB Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Console.WriteLine("DB ERROR IN SETTING INSTAGRAM: " + e.Message);
                    return;
                }
                catch (Exception e)
                {
                    MessageBox.Show("Something went wrong! Try again later.", "Unexpected Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Console.WriteLine("UNEXPECTED ERROR IN SETTING INSTAGRAM: " + e.Message);
                    return;
                }
                
            }
        }

        public string Pinterest {
            get {
                try
                {
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
                catch (SqlException e)
                {
                    MessageBox.Show("Something went wrong! Try again later.", "DB Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Console.WriteLine("DB ERROR IN GETTING PINTEREST: " + e.Message);
                    return null;
                }
                catch (Exception e)
                {
                    MessageBox.Show("Something went wrong! Try again later.", "Unexpected Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Console.WriteLine("UNEXPECTED ERROR IN GETTING PINTEREST: " + e.Message);
                    return null;
                }
                
            }
            set {
                _pinterest = value;
                try
                {
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
                catch (SqlException e)
                {
                    MessageBox.Show("Something went wrong! Try again later.", "DB Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Console.WriteLine("DB ERROR IN SETTING PINTEREST: " + e.Message);
                    return;
                }
                catch (Exception e)
                {
                    MessageBox.Show("Something went wrong! Try again later.", "Unexpected Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Console.WriteLine("UNEXPECTED ERROR IN SETTING PINTEREST: " + e.Message);
                    return;
                }
                
            }
        }

        public string Website {
            get {
                try
                {
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
                catch (SqlException e)
                {
                    MessageBox.Show("Something went wrong! Try again later.", "DB Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Console.WriteLine("DB ERROR IN GETTING WEBSITE: " + e.Message);
                    return null;
                }
                catch (Exception e)
                {
                    MessageBox.Show("Something went wrong! Try again later.", "Unexpected Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Console.WriteLine("UNEXPECTED ERROR IN GETTING WEBSITE: " + e.Message);
                    return null;
                }
                
            }
            set {
                _website = value;
                try
                {
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
                catch (SqlException e)
                {
                    MessageBox.Show("Something went wrong! Try again later.", "DB Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Console.WriteLine("DB ERROR IN SETTING WEBSITE: " + e.Message);
                    return;
                }
                catch (Exception e)
                {
                    MessageBox.Show("Something went wrong! Try again later.", "Unexpected Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Console.WriteLine("UNEXPECTED ERROR IN SETTING WEBSITE: " + e.Message);
                    return;
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
        public abstract void Logout(Form a);
        public Person(string username) {
            this.UserName = username;
        }
    }
}
