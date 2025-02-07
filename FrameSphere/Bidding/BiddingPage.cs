using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Drawing;
using FrameSphere.EntityClasses;
using System.Runtime.InteropServices.ComTypes;
using FrameSphere.FormsUser;

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

            User user = new User(art.Creator);
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

            // Create the bid panel for each user
            Panel bidPanel = new Panel {
                Size = new Size(300, 100), // Adjusted size for bid panel
                BorderStyle = BorderStyle.FixedSingle,
                BackColor = user.UserName == username ? Color.LightGray : Color.LightGreen,
                Padding = new Padding(5),
                //Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right,
                Margin = (username == user.UserName)? new Padding(100,5,5,5): new Padding(-100, 5, 5, 5) // Adding margin for spacing between each bid
            
            };


            // Bid Amount Label
            Label bidAmountLabel = new Label {
                Text = $"@{username}: ${newBidAmount}",
                AutoSize = true,
                Font = new Font("Arial", 10, FontStyle.Bold),
                ForeColor = Color.Black,
                Location = new Point(10, 10)
            };
            bidPanel.Controls.Add(bidAmountLabel);

            // Username Label with Profile Link
            Label usernameLabel = new Label {
                Text = new User(username).FullName(),
                AutoSize = true,
                ForeColor = Color.Blue,
                Location = new Point(10, 30),
                Cursor = Cursors.Hand // Indicate that it's clickable
            };
            usernameLabel.Click += (sender, e) =>
            {
                // Navigate to user profile (implement profile navigation logic here)
                NavigateToUserProfile(username);
            };
            bidPanel.Controls.Add(usernameLabel);

            // Send Text Button
            Button sendTextButton = new Button {
                Text = "Send a Text",
                Size = new Size(100, 30),
                Location = new Point(10, 60)
            };
            sendTextButton.Click += (sender, e) =>
            {
                // Implement send text logic here
                SendText(username);
            };
            bidPanel.Controls.Add(sendTextButton);

            // Send Purchase Request Button (only visible if the user is the creator)
            Button sendPurchaseRequestButton = new Button {
                Text = "Send Purchase Request",
                Size = new Size(150, 30),
                Location = new Point(120, 60),
                Visible = user.UserName == art.Creator // Only visible if the user is the creator
            };
            sendPurchaseRequestButton.Click += (sender, e) =>
            {
                // Implement send purchase request logic here
                SendPurchaseRequest(username);
            };
            bidPanel.Controls.Add(sendPurchaseRequestButton);

            // Add panel to the appropriate FlowLayoutPanel (left or right)
            
                flowLayoutPanel1.Controls.Add(bidPanel);  // Add to the left panel (for other bids)
   

            // Ensure FlowLayoutPanel automatically arranges items top-to-bottom
            flowLayoutPanel1.AutoScroll = true;
        }

        // Example stub methods for actions (replace with actual logic)
        private void NavigateToUserProfile(string username)
        {
            // Implement navigation logic to the user's profile
            MessageBox.Show($"Navigating to {username}'s profile...");
        }

        private void SendText(string username)
        {
            Chat chat = new Chat(new User(username));
            chat.Show();
        }

        private void SendPurchaseRequest(string username)
        {
            // Implement send purchase request logic here
            //MessageBox.Show($"Sending purchase request to {username}...");
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

        private void chat_Click(object sender, EventArgs e)
        {
            this.Hide();
            Chat ch = new Chat(new User(art.Creator));
            ch.Show();
        }
    }
}
