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
        //public Event(string EventID) { this._EventID = EventID; }

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
        public Image PosterImage { get; set; }
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
        public Event(string title)
        {
            string query = @"
                SELECT 
                    EventID,
                    Title,
                    Description,
                    OrganizerDetails,
                    StartDate,
                    EndDate,
                    EventPoster,
                    TicketPrice
                FROM 
                    Events
                WHERE 
                    Title = @Title";

            using (SqlConnection connection = DB.Connect())
            {
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Title", title);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                EventID = reader["EventID"].ToString();
                                EventTitle = reader["Title"].ToString();
                                EventDescription = reader["Description"].ToString();
                                Organization = reader["OrganizerDetails"].ToString();
                                StartsAt = Convert.ToDateTime(reader["StartDate"]);
                                EndsAt = Convert.ToDateTime(reader["EndDate"]);
                                TicketPrice = reader["TicketPrice"] != DBNull.Value
                                    ? Convert.ToDouble(reader["TicketPrice"])
                                    : 0.0;

                                string eventPosterPath = reader["EventPoster"] != DBNull.Value
                                    ? reader["EventPoster"].ToString()
                                    : null;

                                PosterImage = !string.IsNullOrEmpty(eventPosterPath)
                                    ? FSystem.GetImageFromPath(eventPosterPath)
                                    : FrameSphere.Properties.Resources.defaultProfilePic;
                            }
                            else
                            {
                                throw new Exception("Event not found.");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception($"An error occurred while fetching event data: {ex.Message}");
                }
            }
        }

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
