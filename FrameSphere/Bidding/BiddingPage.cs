using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Drawing;
using FrameSphere.EntityClasses;
using System.Runtime.InteropServices.ComTypes;

namespace FrameSphere.Bidding
{
    public partial class BiddingPage : Form
    {
        public Bid bid;
        public Art art;
        public Event Event;

        public BiddingPage(Art art, Event Event)
        {
            InitializeComponent();

            if (art.SellingOption == "Free")
            {
                this.Hide();
                NotForSale notForSale = new NotForSale(art, Event);
                notForSale.Show();
            }
            this.art = art;
            this.Event = Event;
            bid = new Bid(art, Event);

            title.Text = art.ArtTitle;
            description.Text = art.ArtDescription;
            starts.Text = Event.StartsAt.ToString();
            ends.Text = Event.EndsAt.ToString();
            minBid.Text = bid.GetMinimumBid().ToString();
            cover.Image = FSystem.GetImageFromPath(art.artPhotos.FirstOrDefault());
            highestbid.Text = bid.GetMinimumBid().ToString();
            higestbidder.Text = bid.GetCurrentMaxBidder();

            User user = FSystem.loggedInUser;
            name.Text = user.FullName();
            userName.Text = user.UserName;
            profilepic.Image = FSystem.GetImageFromPath(user.ProfilePic);

            LoadPreviousBids();
        }

        private void bidBtn_Click(object sender, EventArgs e)
        {
            if (double.TryParse(currentbidamount.Text, out double newBidAmount))
            {
                double minBidAmount = bid.GetMinimumBid();

                if (newBidAmount > minBidAmount)
                {
                    if (bid.PlaceBid(newBidAmount))
                    {
                        MessageBox.Show("Bid placed successfully!");
                        AddBidToLayout(FSystem.loggedInUser.UserName, newBidAmount);
                        highestbid.Text = bid.GetMinimumBid().ToString();
                        higestbidder.Text = new User(bid.GetCurrentMaxBidder()).FullName();

                    }
                    else
                    {
                        MessageBox.Show("Failed to place bid.");
                    }
                }
                else
                {
                    MessageBox.Show("Bid amount must be greater than the current highest bid.");
                }
            }
            else
            {
                MessageBox.Show("Please enter a valid bid amount.");
            }
        }

        private void LoadPreviousBids()
        {
            List<string[]> previousBids = bid.GetAllBids();
            foreach (string[] bidEntry in previousBids)
            {
                string username = bidEntry[0];
                double bidAmount = Convert.ToDouble(bidEntry[1]);
                AddBidToLayout(username, bidAmount);
            }
        }

        private void AddBidToLayout(string username, double newBidAmount)
        {
            User user = FSystem.loggedInUser;
            Panel bidPanel = new Panel {
                Size = new Size(bidtable.Width - 20, 50),
                BorderStyle = BorderStyle.FixedSingle,
                BackColor = user.UserName == username ? Color.LightGreen : Color.LightGray,
                Padding = new Padding(5)
            };

            Label bidAmountLabel = new Label {
                Text = $"{username}: ${newBidAmount}",
                AutoSize = true,
                Font = new Font("Arial", 10, FontStyle.Bold),
                ForeColor = Color.Black,
                Location = new Point(10, 10)
            };

            bidPanel.Controls.Add(bidAmountLabel);

            if (user.UserName == username)
            {
                bidtable.Controls.Add(bidPanel, 1, bidtable.RowCount);
            }
            else
            {
                bidtable.Controls.Add(bidPanel, 0, bidtable.RowCount);
            }

            bidtable.RowCount++;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            ArtDisplayForm a = new ArtDisplayForm(art.ArtID, Event);
            a.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            TimeSpan remainingTime = Event.StartsAt - now;

            if (remainingTime.TotalSeconds > 0) // Event not started yet
            {
                endtimer.Text = $"{remainingTime.Days}d {remainingTime.Hours:D2}h {remainingTime.Minutes:D2}m {remainingTime.Seconds:D2}s";
            }
            else if (now >= Event.StartsAt && now < Event.EndsAt) // Event started but not ended
            {
                TimeSpan remainingUntilEnd = Event.EndsAt - now;
                endtimer.Text = $"{remainingUntilEnd.Days}d {remainingUntilEnd.Hours:D2}h {remainingUntilEnd.Minutes:D2}m {remainingUntilEnd.Seconds:D2}s";
            }
            else // Event finished
            {
                endtimer.Text = "Event Finished!";
                timer1.Stop();
            }
        }
    }
}
