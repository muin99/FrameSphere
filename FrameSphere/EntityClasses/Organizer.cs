using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace FrameSphere.EntityClasses
{
    public class Organizer : User
    {
        public int EventID { get; set; }
        public Organizer(string UserName) : base(UserName){ }
        public int NumberOfManagedEvents { get; set; }

        public Event[] ManagedEvents = new Event[1000];

        public void AddEvent(Event eventToAdd)
        {
            if (NumberOfManagedEvents < ManagedEvents.Length)
            {
                ManagedEvents[NumberOfManagedEvents++] = eventToAdd;
                Console.WriteLine($"Event '{eventToAdd.EventTitle}' added to Organizer {UserName}'s managed events.");
            }
            else
            {
                Console.WriteLine("Cannot add more events. Maximum capacity reached.");
            }
        }

        public void RemoveOrganizer(User organizer)
        {
            string query = $"DELETE FROM Organizers WHERE UserName = @UserName AND EventID = @EventID";

            using (SqlConnection conn = DB.Connect())
            {
                try
                {
                    conn.Open();

                    // Check if the artist exists in the event.
                    string checkQuery = $"SELECT COUNT(*) FROM Organizers WHERE UserName = @UserName AND EventID = @EventID";
                    SqlCommand checkCmd = new SqlCommand(checkQuery, conn);
                    checkCmd.Parameters.AddWithValue("@UserName", organizer.UserName);
                    checkCmd.Parameters.AddWithValue("@EventID", this.EventID);

                    int count = (int)checkCmd.ExecuteScalar();

                    if (count == 0)
                    {
                        MessageBox.Show("This organizer is not part of the event.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Remove the artist from the database.
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@UserName", organizer.UserName);
                    cmd.Parameters.AddWithValue("@EventID", this.EventID);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Organizer successfully removed from the event.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred while removing the Organizer: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }

        public void RemoveEvent(Event eventToRemove)
        {
            for (int i = 0; i < NumberOfManagedEvents; i++)
            {
                if (ManagedEvents[i] == eventToRemove)
                {
                    for (int j = i; j < NumberOfManagedEvents - 1; j++)
                    {
                        ManagedEvents[j] = ManagedEvents[j + 1];
                    }

                    ManagedEvents[--NumberOfManagedEvents] = null;
                    Console.WriteLine($"Event '{eventToRemove.EventTitle}' removed from Organizer {UserName}'s managed events.");
                    return;
                }
            }
            Console.WriteLine("Event not found in the managed list.");
        }

        
    }
}
