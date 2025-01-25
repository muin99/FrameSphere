using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;

namespace FrameSphere.EntityClasses
{
    public class Event
    {
        private string _EventID;
        private string _EventTitle;
        private string _EventDescription;
        private string _Organization;
        private double _TicketPrice;
        private DateTime _StartsAt;
        private DateTime _EndsAt;

        public Event(string eventId)
        {
            // Fetch event details from the database using the eventId
            string connectionString = "your_connection_string_here"; // Replace with your actual connection string
            string query = "SELECT EventTitle, EventDescription, Organization, StartsAt, EndsAt, TicketPrice, PosterImage FROM Events WHERE EventId = @EventId";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@EventId", eventId);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Populate the event object properties
                            EventTitle = reader["EventTitle"].ToString();
                            EventDescription = reader["EventDescription"].ToString();
                            Organization = reader["Organization"].ToString();
                            StartsAt = Convert.ToDateTime(reader["StartsAt"]);
                            EndsAt = Convert.ToDateTime(reader["EndsAt"]);
                            TicketPrice = (int)reader["TicketPrice"];
                            PosterImage = reader["PosterImage"]?.ToString(); // Assuming it's a file path stored as a string
                        }
                        else
                        {
                            throw new Exception("Event not found with the given ID.");
                        }
                    }
                }
            }
        }



        //public Event(string EventID) { this._EventID = EventID; }
        public Event(string eventID, string eventTitle, string eventDescription, string organization, double ticketPrice, DateTime startsAt, DateTime endsAt, string posterImage)
        {
            // Assign values to class properties
            this.EventID = eventID;
            this.EventTitle = eventTitle;
            this.EventDescription = eventDescription;
            this.Organization = organization;
            this.TicketPrice = ticketPrice;
            this.StartsAt = startsAt;
            this.EndsAt = endsAt;
            this.PosterImage = posterImage;

            // Add the event to the database
            string query = @"
        INSERT INTO Events (EventID, Title, Description, OrganizerDetails, TicketPrice, StartDate, EndDate, EventPoster) 
        VALUES (@EventID, @Title, @Description, @OrganizerDetails, @TicketPrice, @StartDate, @EndDate, @EventPoster)
    ";

            using (SqlConnection connection = DB.Connect())
            {
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@EventID", eventID);
                        command.Parameters.AddWithValue("@Title", eventTitle);
                        command.Parameters.AddWithValue("@Description", eventDescription);
                        command.Parameters.AddWithValue("@OrganizerDetails", organization);
                        command.Parameters.AddWithValue("@TicketPrice", ticketPrice);
                        command.Parameters.AddWithValue("@StartDate", startsAt);
                        command.Parameters.AddWithValue("@EndDate", endsAt);
                        command.Parameters.AddWithValue("@EventPoster", posterImage);
                        

                        command.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception($"An error occurred while adding the event to the database: {ex.Message}");
                }
            }
        }


        // Properties
        public string EventID {
            get { return _EventID; }
            set { _EventID = value; }
        }
        public string EventTitle {
            get {
                string query = $"SELECT Title FROM Events WHERE EventId = '{EventID}'";
                using (SqlConnection connection = DB.Connect())
                {
                    try
                    {
                        connection.Open();
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            _EventTitle = (string)command.ExecuteScalar();
                            return _EventTitle;
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception($"An error occurred while loading event title: {ex.Message}");
                    }
                }
            }
            set {
                string query = $"UPDATE Events SET Title = '{value}' WHERE EventId = '{EventID}'";
                using (SqlConnection connection = DB.Connect())
                {
                    try
                    {
                        connection.Open();
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.ExecuteNonQuery();
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception($"An error occurred while updating event title: {ex.Message}");
                    }
                }
            }
        }
        public string EventDescription {
            get {
                string query = $"SELECT Description FROM Events WHERE EventId = '{EventID}'";
                using (SqlConnection connection = DB.Connect())
                {
                    try
                    {
                        connection.Open();
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            _EventDescription = (string)command.ExecuteScalar();
                            return _EventDescription;
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception($"An error occurred while loading event description: {ex.Message}");
                    }
                }
            }
            set {
                string query = $"UPDATE Events SET Description = '{value}' WHERE EventId = '{EventID}'";
                using (SqlConnection connection = DB.Connect())
                {
                    try
                    {
                        connection.Open();
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.ExecuteNonQuery();
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception($"An error occurred while updating event description: {ex.Message}");
                    }
                }
            }
        }
        public string Organization {
            get {
                string query = $"SELECT OrganizerDetails FROM Events WHERE EventId = '{EventID}'";
                using (SqlConnection connection = DB.Connect())
                {
                    try
                    {
                        connection.Open();
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            _Organization = (string)command.ExecuteScalar();
                            return _Organization;
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception($"An error occurred while loading event organizer details: {ex.Message}");
                    }
                }
            }
            set {
                string query = $"UPDATE Events SET OrganizerDetails = '{value}' WHERE EventId = '{EventID}'";
                using (SqlConnection connection = DB.Connect())
                {
                    try
                    {
                        connection.Open();
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.ExecuteNonQuery();
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception($"An error occurred while updating event organizer details: {ex.Message}");
                    }
                }
            }
        }
        public double TicketPrice {
            get {
                string query = $"SELECT TicketPrice FROM Events WHERE EventId = '{EventID}'";
                using (SqlConnection connection = DB.Connect())
                {
                    try
                    {
                        connection.Open();
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            _TicketPrice = (double)command.ExecuteScalar();
                            return _TicketPrice;
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception($"An error occurred while loading ticket price: {ex.Message}");
                    }
                }
            }
            set {
                string query = $"UPDATE Events SET TicketPrice = '{value}' WHERE EventId = '{EventID}'";
                using (SqlConnection connection = DB.Connect())
                {
                    try
                    {
                        connection.Open();
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.ExecuteNonQuery();
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception($"An error occurred while updating ticket price: {ex.Message}");
                    }
                }
            }
        }
        private string _posterimage;
        public string PosterImage {
            get {
                string query = $"SELECT EventPoster FROM Events WHERE EventId = '{EventID}'";
                using (SqlConnection connection = DB.Connect())
                {
                    try
                    {
                        connection.Open();
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            _posterimage = (string)command.ExecuteScalar();
                            return _posterimage;
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception($"An error occurred while loading event organizer details: {ex.Message}");
                    }
                }
            }
            set {
                string query = $"UPDATE Events SET EventPoster = '{value}' WHERE EventId = '{EventID}'";
                using (SqlConnection connection = DB.Connect())
                {
                    try
                    {
                        connection.Open();
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.ExecuteNonQuery();
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception($"An error occurred while updating event organizer details: {ex.Message}");
                    }
                }
            }
        }
        public DateTime StartsAt {
            get {
                string query = $"SELECT StartDate FROM Events WHERE EventId = '{EventID}'";
                using (SqlConnection connection = DB.Connect())
                {
                    try
                    {
                        connection.Open();
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            _StartsAt = (DateTime)command.ExecuteScalar();
                            return _StartsAt;
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception($"An error occurred while loading event start date: {ex.Message}");
                    }
                }
            }
            set {
                string query = $"UPDATE Events SET StartDate = '{value}' WHERE EventId = '{EventID}'";
                using (SqlConnection connection = DB.Connect())
                {
                    try
                    {
                        connection.Open();
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.ExecuteNonQuery();
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception($"An error occurred while updating event start date: {ex.Message}");
                    }
                }
            }
        }
        public DateTime EndsAt {
            get {
                string query = $"SELECT EndDate FROM Events WHERE EventId = '{EventID}'";
                using (SqlConnection connection = DB.Connect())
                {
                    try
                    {
                        connection.Open();
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            _EndsAt = (DateTime)command.ExecuteScalar();
                            return _EndsAt;
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception($"An error occurred while loading event end date: {ex.Message}");
                    }
                }
            }
            set {
                string query = $"UPDATE Events SET EndDate = '{value}' WHERE EventId = '{EventID}'";
                using (SqlConnection connection = DB.Connect())
                {
                    try
                    {
                        connection.Open();
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.ExecuteNonQuery();
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception($"An error occurred while updating event end date: {ex.Message}");
                    }
                }
            }
        }

        public List<User> Visitors { get; set; } = new List<User>();
        public List<Artist> Artists { get; set; } = new List<Artist>();
        public List<User> Organizers { get; set; } = new List<User>();

        // Constructor to fetch event data by title

        // Add a visitor to the event
        public void AddVisitor(User visitor)
        {
            if (visitor == null) throw new ArgumentNullException(nameof(visitor));
            Visitors.Add(visitor);
        }

        // Add an artist to the event
        public void AddArtist(Artist artist)
        {
            if (artist == null) throw new ArgumentNullException(nameof(artist));
            Artists.Add(artist);
        }

        // Add an organizer to the event
        public void AddOrganizer(User organizer)
        {
            if (organizer == null) throw new ArgumentNullException(nameof(organizer));
            Organizers.Add(organizer);
        }
    }
}
