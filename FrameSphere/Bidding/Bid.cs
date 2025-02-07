using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;
using FrameSphere.EntityClasses;

namespace FrameSphere.Bidding
{
    public class Bid
    {
        public Art Art { get; set; }
        public Event Event { get; set; }

        public Bid(Art art, Event ev)
        {
            Art = art;
            Event = ev;
        }

        public double GetMinimumBid()
        {
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
                        return result != DBNull.Value ? Convert.ToDouble(result) : Art.Price;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error fetching minimum bid: " + ex.Message);
                return Art.Price;
            }
        }

        public string GetCurrentMaxBidder()
        {
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
                        return result != null && !Convert.IsDBNull(result) ? result.ToString() : "No Bids Yet";
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error fetching max bidder: " + ex.Message);
                return "Error";
            }
        }

        public bool PlaceBid(double bidAmount)
        {
            if (bidAmount <= GetMinimumBid())
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

        public List<string[]> GetAllBids()
        {
            List<string[]> bids = new List<string[]>();

            try
            {
                // Ensure the connection is closed properly by using 'using' statement
                using (SqlConnection con = DB.Connect())
                {
                    con.Open();

                    // Define the query with parameterized SQL to prevent SQL injection
                    string query = "SELECT username, biddingamount FROM bids WHERE artid = @artid AND eventid = @eventid";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        // Add the parameters to the SQL command
                        cmd.Parameters.AddWithValue("@artid", Art.ArtID); // Assuming Art.ArtID is set somewhere else
                        cmd.Parameters.AddWithValue("@eventid", Event.EventID); // Assuming Event.EventID is set somewhere else

                        // Execute the command and get the result via SqlDataReader
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            // Read the data returned from the query
                            while (reader.Read())
                            {
                                // Get the username and bidding amount for each row
                                string username = reader.GetString(0); // Column 0 is 'username'
                                double amount = reader.GetDouble(1);   // Column 1 is 'biddingamount'

                                // Add to the bids list
                                bids.Add(new string[] { username, amount.ToString() });
                            }
                        }
                    }
                }
            }
            catch (SqlException sqlEx)
            {
                // Log the error for SQL-related issues
                Console.WriteLine("SQL Error fetching bids: " + sqlEx.Message);
            }
            catch (Exception ex)
            {
                // Log any other exceptions
                Console.WriteLine("Error fetching bids: " + ex.Message);
            }
            
            // Return the list of bids
            return bids;
        }

    }
}
