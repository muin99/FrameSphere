using System;
using System.Linq;
using System.Windows.Forms;
using FrameSphere.EntityClasses;

namespace FrameSphere.Bidding
{
    public partial class BiddingPage : Form
    {
        public Bid bid;
        public BiddingPage(Art art, Event Event)
        {
            InitializeComponent();

            if (art.SellingOption == "Free")
            {
                this.Hide();
                NotForSale notForSale = new NotForSale(art, Event);
                notForSale.Show();
            }

            bid = new Bid(art, Event);

            title.Text = art.ArtTitle;
            description.Text = art.ArtDescription;
            starts.Text = Event.StartsAt.ToString();
            ends.Text = Event.EndsAt.ToString();
            minBid.Text = art.Price.ToString();
            cover.Image = FSystem.GetImageFromPath(art.artPhotos.FirstOrDefault());

            User user = FSystem.loggedInUser;
            name.Text = user.FullName();
            userName.Text = user.UserName;
            profilepic.Image = FSystem.GetImageFromPath(user.ProfilePic);
        }

        private void bidBtn_Click(object sender, EventArgs e)
        {
            // Get the current bid amount entered by the user
            if (double.TryParse(currentbidamount.Text, out double newBidAmount))
            {
                // Get the minimum bid for validation
                double minBidAmount = double.Parse(minBid.Text);

                // Check if the new bid is higher than the minimum bid
                if (newBidAmount >= minBidAmount)
                {
                    // Save the bid (could involve updating the database, for example)
                    // You would likely need to update your Bid object and possibly save it to the database
                    bid.PlaceBid(newBidAmount);

                    // Add the bid to the layout
                    AddBidToLayout(newBidAmount);
                }
                else
                {
                    MessageBox.Show("Bid amount must be greater than the minimum bid.");
                }
            }
            else
            {
                MessageBox.Show("Please enter a valid bid amount.");
            }
        }

        private void AddBidToLayout(double newBidAmount)
        {
            // Check if this bid belongs to the logged-in user or another user
            User user = FSystem.loggedInUser;

            // Create a new panel to hold the bid
            Panel bidPanel = new Panel();
            bidPanel.Size = new System.Drawing.Size(bidtable.Width - 20, 40); // Adjust size as needed
            bidPanel.BorderStyle = BorderStyle.FixedSingle;

            // Add the bid amount and user details to the panel
            Label bidAmountLabel = new Label {
                Text = $"{user.UserName}: ${newBidAmount}",
                AutoSize = true,
                Font = new System.Drawing.Font("Arial", 10),
                Location = new System.Drawing.Point(10, 10)
            };

            // Add the label to the panel
            bidPanel.Controls.Add(bidAmountLabel);

            // If it's the logged-in user's bid, add it to the right column
            if (user.UserName == FSystem.loggedInUser.UserName)
            {
                bidtable.Controls.Add(bidPanel, 1, bidtable.RowCount);
            }
            else
            {
                // Otherwise, add it to the left column for other bids
                bidtable.Controls.Add(bidPanel, 0, bidtable.RowCount);
            }

            // Optionally, increase the row count to create space for more bids
            bidtable.RowCount++;
        }
    }
}
