using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace FrameSphere.EntityClasses
{
    public class Event
    {
        // Private fields
        private int _eventID;
        private string _eventTitle;   
        private string _eventDescription;
        private string _organization;
        private double _ticketPrice;
        private DateTime _startsAt;
        private DateTime _endsAt;
        private string _registrationType;
        private string _posterImage;
        private string _status;
        private string _creator;
        private DateTime _createdAt;

            // Assuming DB.Connect() is a method that returns a SqlConnection
            private SqlConnection connection;

            // Getter and Setter for EventID aa
            public int EventID {
                get {
                return _eventID;
                    } 
            set {
                _eventID = value;
                    }
            }

            // Getter and Setter for EventTitle
            public string EventTitle {
                get {
                    using (connection = DB.Connect())
                    {
                        string query = "SELECT EventTitle FROM Events WHERE EventID = @EventID";
                        SqlCommand command = new SqlCommand(query, connection);
                        command.Parameters.AddWithValue("@EventID", _eventID);
                        connection.Open();
                        _eventTitle = (command.ExecuteScalar()?.ToString());
                    }
                    return _eventTitle;
                }
                set {
                    _eventTitle = value;
                    using (connection = DB.Connect())
                    {
                        string query = "UPDATE Events SET EventTitle = @EventTitle WHERE EventID = @EventID";
                        SqlCommand command = new SqlCommand(query, connection);
                        command.Parameters.AddWithValue("@EventTitle", _eventTitle);
                        command.Parameters.AddWithValue("@EventID", _eventID);
                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                }
            }

            // Getter and Setter for EventDescription
            public string EventDescription {
                get {
                    using (connection = DB.Connect())
                    {
                        string query = "SELECT Description FROM Events WHERE EventID = @EventID";
                        SqlCommand command = new SqlCommand(query, connection);
                        command.Parameters.AddWithValue("@EventID", _eventID);
                        connection.Open();
                        _eventDescription = command.ExecuteScalar()?.ToString();
                    }
                    return _eventDescription;
                }
                set {
                    _eventDescription = value;
                    using (connection = DB.Connect())
                    {
                        string query = "UPDATE Events SET Description = @Description WHERE EventID = @EventID";
                        SqlCommand command = new SqlCommand(query, connection);
                        command.Parameters.AddWithValue("@Description", _eventDescription);
                        command.Parameters.AddWithValue("@EventID", _eventID);
                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                }
            }

            // Getter and Setter for Organization
            public string Organization {
                get {
                    using (connection = DB.Connect())
                    {
                        string query = "SELECT OrganizerDetails FROM Events WHERE EventID = @EventID";
                        SqlCommand command = new SqlCommand(query, connection);
                        command.Parameters.AddWithValue("@EventID", _eventID);
                        connection.Open();
                        _organization = command.ExecuteScalar()?.ToString();
                    }
                    return _organization;
                }
                set {
                    _organization = value;
                    using (connection = DB.Connect())
                    {
                        string query = "UPDATE Events SET OrganizerDetails = @OrganizerDetails WHERE EventID = @EventID";
                        SqlCommand command = new SqlCommand(query, connection);
                        command.Parameters.AddWithValue("@OrganizerDetails", _organization);
                        command.Parameters.AddWithValue("@EventID", _eventID);
                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                }
            }

            // Getter and Setter for TicketPrice
            public double TicketPrice {
                get {
                    using (connection = DB.Connect())
                    {
                        string query = "SELECT TicketPrice FROM Events WHERE EventID = @EventID";
                        SqlCommand command = new SqlCommand(query, connection);
                        command.Parameters.AddWithValue("@EventID", _eventID);
                        connection.Open();
                        _ticketPrice = Convert.ToDouble(command.ExecuteScalar());
                    }
                    return _ticketPrice;
                }
                set {
                    _ticketPrice = value;
                    using (connection = DB.Connect())
                    {
                        string query = "UPDATE Events SET TicketPrice = @TicketPrice WHERE EventID = @EventID";
                        SqlCommand command = new SqlCommand(query, connection);
                        command.Parameters.AddWithValue("@TicketPrice", _ticketPrice);
                        command.Parameters.AddWithValue("@EventID", _eventID);
                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                }
            }

            // Getter and Setter for StartsAt
            public DateTime StartsAt {
                get {
                    using (connection = DB.Connect())
                    {
                        string query = "SELECT StartDate FROM Events WHERE EventID = @EventID";
                        SqlCommand command = new SqlCommand(query, connection);
                        command.Parameters.AddWithValue("@EventID", _eventID);
                        connection.Open();
                        _startsAt = Convert.ToDateTime(command.ExecuteScalar());
                    }
                    return _startsAt;
                }
                set {
                    _startsAt = value;
                    using (connection = DB.Connect())
                    {
                        string query = "UPDATE Events SET StartDate = @StartDate WHERE EventID = @EventID";
                        SqlCommand command = new SqlCommand(query, connection);
                        command.Parameters.AddWithValue("@StartDate", _startsAt);
                        command.Parameters.AddWithValue("@EventID", _eventID);
                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                }
            }

            // Getter and Setter for EndsAt
            public DateTime EndsAt {
                get {
                    using (connection = DB.Connect())
                    {
                        string query = "SELECT EndDate FROM Events WHERE EventID = @EventID";
                        SqlCommand command = new SqlCommand(query, connection);
                        command.Parameters.AddWithValue("@EventID", _eventID);
                        connection.Open();
                        _endsAt = Convert.ToDateTime(command.ExecuteScalar());
                    }
                    return _endsAt;
                }
                set {
                    _endsAt = value;
                    using (connection = DB.Connect())
                    {
                        string query = "UPDATE Events SET EndDate = @EndDate WHERE EventID = @EventID";
                        SqlCommand command = new SqlCommand(query, connection);
                        command.Parameters.AddWithValue("@EndDate", _endsAt);
                        command.Parameters.AddWithValue("@EventID", _eventID);
                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                }
            }

            // Getter and Setter for RegistrationType
            public string RegistrationType {
                get {
                    using (connection = DB.Connect())
                    {
                        string query = "SELECT RegistrationType FROM Events WHERE EventID = @EventID";
                        SqlCommand command = new SqlCommand(query, connection);
                        command.Parameters.AddWithValue("@EventID", _eventID);
                        connection.Open();
                        _registrationType = command.ExecuteScalar()?.ToString();
                    }
                    return _registrationType;
                }
                set {
                    _registrationType = value;
                    using (connection = DB.Connect())
                    {
                        string query = "UPDATE Events SET RegistrationType = @RegistrationType WHERE EventID = @EventID";
                        SqlCommand command = new SqlCommand(query, connection);
                        command.Parameters.AddWithValue("@RegistrationType", _registrationType);
                        command.Parameters.AddWithValue("@EventID", _eventID);
                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                }
            }

            // Getter and Setter for PosterImage
            public string PosterImage {
                get {
                    using (connection = DB.Connect())
                    {
                        string query = "SELECT EventPoster FROM Events WHERE EventID = @EventID";
                        SqlCommand command = new SqlCommand(query, connection);
                        command.Parameters.AddWithValue("@EventID", _eventID);
                        connection.Open();
                        _posterImage = command.ExecuteScalar()?.ToString();
                    }
                    return _posterImage;
                }
                set {
                    _posterImage = value;
                    using (connection = DB.Connect())
                    {
                        string query = "UPDATE Events SET EventPoster = @EventPoster WHERE EventID = @EventID";
                        SqlCommand command = new SqlCommand(query, connection);
                        command.Parameters.AddWithValue("@EventPoster", _posterImage);
                        command.Parameters.AddWithValue("@EventID", _eventID);
                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                }
            }

            // Getter and Setter for Status
            public string Status {
                get {
                    using (connection = DB.Connect())
                    {
                        string query = "SELECT Status FROM Events WHERE EventID = @EventID";
                        SqlCommand command = new SqlCommand(query, connection);
                        command.Parameters.AddWithValue("@EventID", _eventID);
                        connection.Open();
                        _status = command.ExecuteScalar()?.ToString();
                    }
                    return _status;
                }
                set {
                    _status = value;
                    using (connection = DB.Connect())
                    {
                        string query = "UPDATE Events SET Status = @Status WHERE EventID = @EventID";
                        SqlCommand command = new SqlCommand(query, connection);
                        command.Parameters.AddWithValue("@Status", _status);
                        command.Parameters.AddWithValue("@EventID", _eventID);
                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                }
            }

            // Getter and Setter for Creator
            public string Creator {
                get {
                    using (connection = DB.Connect())
                    {
                        string query = "SELECT Creator FROM Events WHERE EventID = @EventID";
                        SqlCommand command = new SqlCommand(query, connection);
                        command.Parameters.AddWithValue("@EventID", _eventID);
                        connection.Open();
                        _creator = command.ExecuteScalar()?.ToString();
                    }
                    return _creator;
                }
                set {
                    _creator = value;
                    using (connection = DB.Connect())
                    {
                        string query = "UPDATE Events SET Creator = @Creator WHERE EventID = @EventID";
                        SqlCommand command = new SqlCommand(query, connection);
                        command.Parameters.AddWithValue("@Creator", _creator);
                        command.Parameters.AddWithValue("@EventID", _eventID);
                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                }
            }

            // Getter and Setter for CreatedAt
            public DateTime CreatedAt {
                get {
                    using (connection = DB.Connect())
                    {
                        string query = "SELECT CreatedAt FROM Events WHERE EventID = @EventID";
                        SqlCommand command = new SqlCommand(query, connection);
                        command.Parameters.AddWithValue("@EventID", _eventID);
                        connection.Open();
                        _createdAt = Convert.ToDateTime(command.ExecuteScalar());
                    }
                    return _createdAt;
                }
                set {
                    _createdAt = value;
                    using (connection = DB.Connect())
                    {
                        string query = "UPDATE Events SET CreatedAt = @CreatedAt WHERE EventID = @EventID";
                        SqlCommand command = new SqlCommand(query, connection);
                        command.Parameters.AddWithValue("@CreatedAt", _createdAt);
                        command.Parameters.AddWithValue("@EventID", _eventID);
                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                }
            }
     



        // Constructors
        public Event(int eventID)
        {
            this.EventID = eventID;
            // Fetch event details from the database using the eventID
            //string query = "SELECT * FROM Events WHERE EventID = @EventID";

            //using (SqlConnection connection = DB.Connect())
            //{
            //    connection.Open();
            //    using (SqlCommand command = new SqlCommand(query, connection))
            //    {
            //        command.Parameters.AddWithValue("@EventID", eventID);

            //        using (SqlDataReader reader = command.ExecuteReader())
            //        {
            //            if (reader.Read())
            //            {
            //                // Populate properties
            //                EventID = reader["EventID"].ToString();
            //                EventTitle = reader["EventTitle"].ToString();
            //                EventDescription = reader["EventDescription"].ToString();
            //                Organization = reader["Organization"].ToString();
            //                StartsAt = Convert.ToDateTime(reader["StartsAt"]);
            //                EndsAt = Convert.ToDateTime(reader["EndsAt"]);
            //                TicketPrice = Convert.ToDouble(reader["TicketPrice"]);
            //                PosterImage = reader["PosterImage"]?.ToString();
            //                RegistrationType = reader["RegistrationType"].ToString();
            //                Status = reader["Status"].ToString();
            //                Creator = reader["Creator"].ToString();
            //                CreatedAt = Convert.ToDateTime(reader["CreatedAt"]);
            //            }
            //            else
            //            {
            //                throw new Exception("Event not found with the given ID.");
            //            }
            //        }
            //    }
            //}
        }

        public Event(string eventTitle, string eventDescription, string organization, double ticketPrice,
            DateTime startsAt,
                     DateTime endsAt, string registrationType, string posterImage)
        {
            string query = @"INSERT INTO Events (EventTitle, Description, OrganizerDetails, TicketPrice, StartDate, EndDate, 
                            RegistrationType, EventPoster, Status, Creator, CreatedAt)
                            VALUES (@EventTitle, @EventDescription, @Organization, @TicketPrice, @StartsAt, @EndsAt, 
                            @RegistrationType, @PosterImage, @Status, @Creator, @CreatedAt)";

            using (SqlConnection connection = DB.Connect())
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@EventTitle", eventTitle);
                    command.Parameters.AddWithValue("@EventDescription", eventDescription);
                    command.Parameters.AddWithValue("@Organization", organization);
                    command.Parameters.AddWithValue("@TicketPrice", ticketPrice);
                    command.Parameters.AddWithValue("@StartsAt", startsAt);
                    command.Parameters.AddWithValue("@EndsAt", endsAt);
                    command.Parameters.AddWithValue("@RegistrationType", registrationType);
                    command.Parameters.AddWithValue("@PosterImage", posterImage);
                    command.Parameters.AddWithValue("@Status", "Pending");
                    command.Parameters.AddWithValue("@Creator", FSystem.loggedInUser.UserName);
                    command.Parameters.AddWithValue("@CreatedAt", DateTime.Now);

                    command.ExecuteNonQuery();
                }
            }
        }




        // Insert the new event into the database
        private void InsertToDatabase()
        {
            
        }

        // Methods for managing associated data
        public List<User> Visitors { get; set; } = new List<User>();
        public List<Artist> Artists { get; set; } = new List<Artist>();
        public List<User> Organizers { get; set; } = new List<User>();

        public void AddVisitor(User visitor)
        {
            if (visitor == null) throw new ArgumentNullException(nameof(visitor));
            Visitors.Add(visitor);
        }
        public void RemoveArtist(User artist)
        {
            string query = $"DELETE FROM ArtistEvent WHERE UserName = @UserName AND EventID = @EventID";

            using (SqlConnection conn = DB.Connect())
            {
                try
                {
                    conn.Open();

                    // Check if the artist exists in the event.
                    string checkQuery = $"SELECT COUNT(*) FROM ArtistEvent WHERE UserName = @UserName AND EventID = @EventID";
                    SqlCommand checkCmd = new SqlCommand(checkQuery, conn);
                    checkCmd.Parameters.AddWithValue("@UserName", artist.UserName);
                    checkCmd.Parameters.AddWithValue("@EventID", this.EventID);

                    int count = (int)checkCmd.ExecuteScalar();

                    if (count == 0)
                    {
                        MessageBox.Show("This artist is not part of the event.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Remove the artist from the database.
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@UserName", artist.UserName);
                    cmd.Parameters.AddWithValue("@EventID", this.EventID);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Artist successfully removed from the event.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred while removing the artist: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public void RemoveArt(int ArtID)
        {
            Art art = new Art(ArtID);
            string query = $"DELETE FROM ArtEvent WHERE ArtId = {ArtID} AND EventID = {EventID}";

            using (SqlConnection conn = DB.Connect())
            {
                try
                {
                    conn.Open();

                    // Check if the art exists in the event.
                    string checkQuery = $"SELECT COUNT(*) FROM ArtEvent WHERE ArtId = @ArtID AND EventID = @EventID";
                    SqlCommand checkCmd = new SqlCommand(checkQuery, conn);
                    checkCmd.Parameters.AddWithValue("@ArtID", art.ArtID);
                    checkCmd.Parameters.AddWithValue("@EventID", this.EventID);

                    int count = (int)checkCmd.ExecuteScalar();

                    if (count == 0)
                    {
                        MessageBox.Show("This art is not in the collections for the event.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Remove the art from the database.
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@UserName", art.ArtID);
                    cmd.Parameters.AddWithValue("@EventID", this.EventID);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Art successfully removed from the collection.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred while removing the art: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public void AddArt(int ArtID)
        {
            Art art = new Art(ArtID);
            string query = $"insert into ArtEvent values ({ArtID},{EventID})";
            using (SqlConnection conn = DB.Connect())
            {
                try
                {
                    conn.Open();
                    // Check if the art is already added to avoid duplicates.
                    string checkQuery = $"SELECT COUNT(*) FROM ArtEvent WHERE ArtID = @ArtID AND EventID = @EventID";
                    SqlCommand checkCmd = new SqlCommand(checkQuery, conn);
                    checkCmd.Parameters.AddWithValue("@ArtID", art.ArtID);
                    checkCmd.Parameters.AddWithValue("@EventID", this.EventID);

                    int count = (int)checkCmd.ExecuteScalar();

                    if (count > 0)
                    {
                        MessageBox.Show("This art already exists in the collections for this event.", "Duplicate Entry", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Insert art into ArtEvent table.
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@ArtID", art.ArtID);
                    cmd.Parameters.AddWithValue("@EventID", this.EventID);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Art successfully added to the event.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred while adding the artist: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        public void AddArtist(User artist)
        {
            string q = $"INSERT INTO ArtistEvent (UserName, EventID) VALUES (@UserName, @EventID)";

            using (SqlConnection conn = DB.Connect())
            {
                try
                {
                    conn.Open();
                    // Check if the artist is already added to avoid duplicates.
                    string checkQuery = $"SELECT COUNT(*) FROM ArtistEvent WHERE UserName = @UserName AND EventID = @EventID";
                    SqlCommand checkCmd = new SqlCommand(checkQuery, conn);
                    checkCmd.Parameters.AddWithValue("@UserName", artist.UserName);
                    checkCmd.Parameters.AddWithValue("@EventID", this.EventID);

                    int count = (int)checkCmd.ExecuteScalar();

                    if (count > 0)
                    {
                        MessageBox.Show("This artist is already participating in this event.", "Duplicate Entry", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Insert artist into ArtistEvent table.
                    SqlCommand cmd = new SqlCommand(q, conn);
                    cmd.Parameters.AddWithValue("@UserName", artist.UserName);
                    cmd.Parameters.AddWithValue("@EventID", this.EventID);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Artist successfully added to the event.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred while adding the artist: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        public void AddOrganizer(User organizer)
        {
            if (organizer == null) throw new ArgumentNullException(nameof(organizer));
            Organizers.Add(organizer);
        }
        public void Save()
        {
            using (connection = DB.Connect())
            {
                connection.Open();
                string query = @"UPDATE Events SET 
                                EventTitle = @EventTitle,
                                Description = @Description,
                                OrganizerDetails = @OrganizerDetails,
                                StartDate = @StartDate,
                                EndDate = @EndDate,
                                RegistrationType = @RegistrationType,
                                TicketPrice = @TicketPrice,
                                EventPoster = @EventPoster,
                                Status = @Status
                                WHERE EventID = @EventID";

                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@EventTitle", EventTitle);
                cmd.Parameters.AddWithValue("@Description", EventDescription);
                cmd.Parameters.AddWithValue("@OrganizerDetails", Organization);
                cmd.Parameters.AddWithValue("@StartDate", StartsAt);
                cmd.Parameters.AddWithValue("@EndDate", EndsAt);
                cmd.Parameters.AddWithValue("@RegistrationType", RegistrationType);
                cmd.Parameters.AddWithValue("@TicketPrice", TicketPrice);
                cmd.Parameters.AddWithValue("@EventPoster", PosterImage);
                cmd.Parameters.AddWithValue("@Status", Status);
                cmd.Parameters.AddWithValue("@EventID", EventID);

                cmd.ExecuteNonQuery();
            }
        }

        public bool validVisitor()
        {
            using (SqlConnection con = DB.Connect())
            {
                con.Open();
                string query = "SELECT COUNT(*) FROM UserEvent WHERE username = @username AND eventid = @eventid";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@username", FSystem.loggedInUser.UserName);
                cmd.Parameters.AddWithValue("@eventid", this.EventID);

                int res = Convert.ToInt32(cmd.ExecuteScalar());
                return res > 0;
            }
        }
    }


}
