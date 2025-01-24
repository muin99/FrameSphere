using System;
using System.Drawing;
using System.Windows.Forms;
using FrameSphere.EntityClasses;

namespace FrameSphere
{
    public partial class Event_page : Form
    {
        private Event currentEvent;

        public Event_page(string title)
        {
            InitializeComponent();

            // Load the event data
            currentEvent = new Event(title);
            LoadEventDetails();
        }

        private void LoadEventDetails()
        {
            if (currentEvent == null) return;

            // Set title, description, and organizer
            this.title.Text = currentEvent.EventTitle;
            this.description.Text = currentEvent.EventDescription;
            organizer.Text = currentEvent.Organization;

            // Format the start and end dates
            starts.Text = currentEvent.StartsAt.ToString("dd MMM yyyy, hh:mm tt"); // Example: "17 Jan 2025, 08:00 PM"
            ends.Text = currentEvent.EndsAt.ToString("dd MMM yyyy, hh:mm tt"); // Example: "18 Jan 2025, 10:00 PM"

            // Format ticket price or show "Free" if no price is set
            label8.Text = currentEvent.TicketPrice > 0
                ? currentEvent.TicketPrice.ToString("C") // Currency format
                : "Free";

            // Load the event poster
            if (currentEvent.PosterImage != null)
            {
                cover.Image = currentEvent.PosterImage; // Use the `PosterImage` property directly
            }
            else
            {
                // Set a default image if no poster is available
                cover.Image = FrameSphere.Properties.Resources.defaultProfilePic;
            }
        }

        public void LoadEventData(string title, string description, string organizerDetails, DateTime startDate, DateTime endDate, string registrationType, decimal? ticketPrice, string eventPosterPath)
        {
            // Populate the event page fields
            this.title.Text = title;
            this.description.Text = description;
            organizer.Text = organizerDetails;
            starts.Text = startDate.ToString("MM/dd/yyyy hh:mm tt");
            ends.Text = endDate.ToString("MM/dd/yyyy hh:mm tt");
            label8.Text = ticketPrice.HasValue && ticketPrice > 0 ? ticketPrice.Value.ToString("C") : "Free";

            // Load the event poster using the reusable FSystem method
            cover.Image = FSystem.GetImageFromPath(eventPosterPath);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Navigate back to the User Dashboard
            this.Hide();
            UserDashBoard userDashBoard = new UserDashBoard();
            userDashBoard.Show();
        }
    }
}
