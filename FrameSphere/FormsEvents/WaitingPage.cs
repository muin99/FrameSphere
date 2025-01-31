using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FrameSphere.EntityClasses;

namespace FrameSphere.FormsEvents
{
    public partial class WaitingPage : Form
    {
        Event currentEvent;
        public WaitingPage(Event ee)
        {
            this.currentEvent = ee;
            InitializeComponent();
            title.Text = currentEvent.EventTitle;
            organizer.Text = currentEvent.EventDescription;
            starts.Text = currentEvent.StartsAt.ToString();
            ends.Text = currentEvent.EndsAt.ToString();
            price.Text = (currentEvent.RegistrationType == "Free") ? "Free" : currentEvent.TicketPrice.ToString();
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime eventStartTime = currentEvent.StartsAt;

            TimeSpan remainingTime = eventStartTime - DateTime.Now;

            if (remainingTime.TotalSeconds > 0)
            {
                timer.Text = $"{remainingTime.Days}d {remainingTime.Hours:D2}h {remainingTime.Minutes:D2}m {remainingTime.Seconds:D2}s";
            }
            else
            {
                timer.Text = "Event Started!";
                this.Hide();
                Event_page ev = new Event_page(currentEvent.EventID);
                ev.Show();
                timer1.Stop();
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            UserDashBoard u = new UserDashBoard();
            u.Show();
        }
    }
}
