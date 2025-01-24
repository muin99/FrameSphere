using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;

namespace FrameSphere.EntityClasses
{
    public class Event
    {
        // Properties
        public string EventID { get; set; }
        public string EventTitle { get; set; }
        public string EventDescription { get; set; }
        public string Organization { get; set; }
        public double TicketPrice { get; set; }
        public Image PosterImage { get; set; } // Use Image type for the event poster
        public DateTime StartsAt { get; set; }
        public DateTime EndsAt { get; set; }

        public List<User> Visitors { get; set; } = new List<User>();
        public List<Artist> Artists { get; set; } = new List<Artist>();
        public List<User> Organizers { get; set; } = new List<User>();

        // Constructor to fetch event data by title
        public Event(string title)
        {
            // Query to fetch event data from the database
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
                        // Use parameterized queries to prevent SQL injection
                        command.Parameters.AddWithValue("@Title", title);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Assign values to properties
                                EventID = reader["EventID"].ToString();
                                EventTitle = reader["Title"].ToString();
                                EventDescription = reader["Description"].ToString();
                                Organization = reader["OrganizerDetails"].ToString();
                                StartsAt = Convert.ToDateTime(reader["StartDate"]);
                                EndsAt = Convert.ToDateTime(reader["EndDate"]);
                                TicketPrice = reader["TicketPrice"] != DBNull.Value
                                    ? Convert.ToDouble(reader["TicketPrice"])
                                    : 0.0;

                                // Load the event poster
                                string eventPosterPath = reader["EventPoster"] != DBNull.Value
                                    ? reader["EventPoster"].ToString()
                                    : null;

                                PosterImage = !string.IsNullOrEmpty(eventPosterPath)
                                    ? FSystem.GetImageFromPath(eventPosterPath) // Use reusable method
                                    : FrameSphere.Properties.Resources.defaultProfilePic; // Default image
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

        // Fetch all visitors for the event from the database
        public void LoadVisitors()
        {
            string query = "SELECT UserName FROM EventVisitors WHERE EventID = @EventID";

            using (SqlConnection connection = DB.Connect())
            {
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@EventID", EventID);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            Visitors.Clear();
                            while (reader.Read())
                            {
                                string userName = reader["UserName"].ToString();
                                Visitors.Add(new User(userName)); // Assume User class can load data by username
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception($"An error occurred while loading visitors: {ex.Message}");
                }
            }
        }

        // Fetch all artists for the event from the database
        public void LoadArtists()
        {
            string query = "SELECT ArtistName FROM EventArtists WHERE EventID = @EventID";

            using (SqlConnection connection = DB.Connect())
            {
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@EventID", EventID);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            Artists.Clear();
                            while (reader.Read())
                            {
                                string artistName = reader["ArtistName"].ToString();
                                Artists.Add(new Artist(artistName)); // Assume Artist class can load data by name
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception($"An error occurred while loading artists: {ex.Message}");
                }
            }
        }

        // Fetch all organizers for the event from the database
        public void LoadOrganizers()
        {
            string query = "SELECT UserName FROM EventOrganizers WHERE EventID = @EventID";

            using (SqlConnection connection = DB.Connect())
            {
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@EventID", EventID);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            Organizers.Clear();
                            while (reader.Read())
                            {
                                string userName = reader["UserName"].ToString();
                                Organizers.Add(new User(userName)); // Assume User class can load data by username
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception($"An error occurred while loading organizers: {ex.Message}");
                }
            }
        }
    }
}
