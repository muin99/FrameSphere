using System;
using System.Drawing;
using System.Windows.Forms;
using FrameSphere.EntityClasses;

namespace FrameSphere
{
    public partial class Event_page : Form
    {
        public Event currentEvent;

        public Event_page(int eventId)
        {
            InitializeComponent();
            
            // Load the event data
            currentEvent = new Event(eventId);
            title.Text = currentEvent.EventTitle;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            // Navigate back to the User Dashboard
            this.Hide();
            UserDashBoard userDashBoard = new UserDashBoard();
            userDashBoard.Show();
        }

        private void manage_Click(object sender, EventArgs e)
        {
            this.Hide();
            ManageEvents mn = new ManageEvents(currentEvent.EventID);
            //Application.Run(new ManageEvents("28"));
            mn.Show();
        }
    }
}
