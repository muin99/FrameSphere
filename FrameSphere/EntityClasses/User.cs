using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace FrameSphere.EntityClasses
{
    public class User : Person
    {
        private SqlConnection connection;
        private string _status;
        public Artist Artist { get; set; }
        public string Status {
            get {
                using (connection = DB.Connect())
                {
                    string query = "SELECT Status FROM AllUser WHERE UserName = @UserName";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@UserName", base.UserName);
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
                    command.Parameters.AddWithValue("@UserName", base.UserName);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

       
        public int TotalVisitedEvents { get; private set; } = 0;
        public List<Event> VisitingEvents = new List<Event>();

        

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


        public Artist ElevateToArtist()
        {
            if (isArtist)
            {
                return new Artist(UserName);
            }
            throw new InvalidOperationException("User is not an approved artist.");
        }

  // To check if we've already queried the DB
        private bool _isArtist = false;

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
                                object result = cmd.ExecuteScalar();
                                _isArtist = (result != null && result != DBNull.Value) ? Convert.ToInt32(result) > 0 : false;
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"An error occurred while checking if the user is an artist: {ex.Message}");
                            _isArtist = false;
                        }
                    }

                   

                return _isArtist;
            }
        }


        public Artist GetArtist()
        {
            return new Artist(this.UserName);
        }

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

        public bool IsArtist()
        {
            // Perform the check here without invoking the property directly
            return _isArtist; // Return the cached value or perform the DB query
        }

        //public User() { }
        public User(string UserName) : base(UserName) {
            if (IsArtist()) // Use a method here to avoid recursion
            {
                Artist = GetArtist();
            }
            //this.loadUser();
            //loadArtList();
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
