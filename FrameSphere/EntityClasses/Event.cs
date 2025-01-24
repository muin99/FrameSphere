using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace FrameSphere.EntityClasses
{
    public class Event
    {
        public string EventID { get; set; }
        public string EventTitle { get; set; }
        public string EventDescription { get; set; }
        public string Organization { get; set; }
        public double TicketPrice { get; set; }
        public byte[] Poster { get; set; }
        public DateTime StartsAt { get; set; }
        public DateTime EndsAt { get; set; }

        public List<User> Visitors { get; set; } = new List<User>();
        public List<Artist> Artists { get; set; } = new List<Artist>();
        public List<User> Organizers { get; set; } = new List<User>();

        public Event(string title)
        {
            this.EventTitle = title;

            // Query to fetch event data from the Events table
            string query = $@"SELECT 
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
            Title = '{title}'";

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
                                EventID = reader["EventID"].ToString();
                                EventTitle = reader["Title"].ToString();
                                EventDescription = reader["Description"].ToString();
                                Organization = reader["OrganizerDetails"].ToString();
                                StartsAt = Convert.ToDateTime(reader["StartDate"]);
                                EndsAt = Convert.ToDateTime(reader["EndDate"]);

                                // Read the EventPoster as byte[] from the database
                                if (reader["EventPoster"] != DBNull.Value)
                                {
                                    Poster = (byte[])reader["EventPoster"]; // Store it as a byte array
                                }
                                else
                                {
                                    Poster = null; // Or set to some default byte array if needed
                                }

                                TicketPrice = reader["TicketPrice"] != DBNull.Value ? Convert.ToDouble(reader["TicketPrice"]) : 0.0;
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


        public void AddVisitor(User visitor)
        {
            Visitors.Add(visitor);
        }

        public void AddArtist(Artist artist)
        {
            Artists.Add(artist);
        }

        public void AddOrganizer(User organizer)
        {
            Organizers.Add(organizer);
        }
    }
}
