using System;
using System.Data.SqlClient;
using FrameSphere.EntityClasses;

namespace FrameSphere.Bidding
{
    public class Bid
    {
        public Art Art { get; set; }
        public Event Event { get; set; }

        private double _minimumBid;
        private string _currentMaxBidder;

        public double MinimumBid {
            get {
                try
                {
                    using (SqlConnection con = DB.Connect())
                    {
                        con.Open();
                        string query = "SELECT MAX(biddingamount) FROM bids WHERE artid = @artid AND eventid = @eventid";
                        using (SqlCommand cmd = new SqlCommand(query, con))
                        {
                            cmd.Parameters.AddWithValue("@artid", Art.ArtID);
                            cmd.Parameters.AddWithValue("@eventid", Event.EventID);
                            object result = cmd.ExecuteScalar();
                            _minimumBid = result != DBNull.Value ? Convert.ToDouble(result) : 0.0;
                            return _minimumBid;
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error fetching minimum bid: " + ex.Message);
                    return 0.0;
                }
            }
        }

        public string CurrentMaxBidder {
            get {
                try
                {
                    using (SqlConnection con = DB.Connect())
                    {
                        con.Open();
                        string query = "SELECT TOP 1 username FROM bids WHERE artid = @artid AND eventid = @eventid ORDER BY biddingamount DESC";
                        using (SqlCommand cmd = new SqlCommand(query, con))
                        {
                            cmd.Parameters.AddWithValue("@artid", Art.ArtID);
                            cmd.Parameters.AddWithValue("@eventid", Event.EventID);
                            object result = cmd.ExecuteScalar();
                            _currentMaxBidder = result != null && !Convert.IsDBNull(result) ? result.ToString() : "No Bids Yet";
                            return _currentMaxBidder;
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error fetching max bidder: " + ex.Message);
                    return "Error";
                }
            }
        }

        public Bid(Art art, Event ev)
        {
            Art = art;
            Event = ev;
        }

        public bool PlaceBid( double bidAmount)
        {
            if (bidAmount <= MinimumBid)
            {
                Console.WriteLine("Bid amount must be higher than the current highest bid.");
                return false;
            }

            try
            {
                using (SqlConnection con = DB.Connect())
                {
                    con.Open();
                    string query = "INSERT INTO bids (artid, eventid, username, biddingamount, biddingtime) VALUES (@artid, @eventid, @username, @biddingamount, GETDATE())";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@artid", Art.ArtID);
                        cmd.Parameters.AddWithValue("@eventid", Event.EventID);
                        cmd.Parameters.AddWithValue("@username", FSystem.loggedInUser.UserName);
                        cmd.Parameters.AddWithValue("@biddingamount", bidAmount);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error placing bid: " + ex.Message);
                return false;
            }
        }
    }
}
