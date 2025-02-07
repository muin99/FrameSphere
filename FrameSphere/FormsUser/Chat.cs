using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using FrameSphere.EntityClasses;

namespace FrameSphere.FormsUser
{
    public partial class Chat : Form
    {
        public User you;
        public User me = FSystem.loggedInUser;

        public Chat(User you = null)
        {
            if (you == null)
            {
                using (SqlConnection conn = DB.Connect())
                {
                    conn.Open();
                    string query = "SELECT receiver_id FROM Messages " +
                                   "WHERE sender_id = @me " +
                                   "ORDER BY sent_at desc";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@me", me.UserName);
                        string userName = cmd.ExecuteScalar()?.ToString();  // Safe null-check

                        // If the userName is null, assign logged-in user, else assign fetched user
                        this.you = string.IsNullOrEmpty(userName) ? FSystem.loggedInUser : new User(userName);

                    }
                }
            }
            else this.you = you;
            InitializeComponent();
            cuname.Text = this.you.FullName();
            LoadRecentUsers();
            LoadMessages();
        }

        private void sendbutton_Click_1(object sender, EventArgs e)
        {
            string messageText = message.Text.Trim();
            if (string.IsNullOrEmpty(messageText)) return;

            SaveMessageToDatabase(me.UserName, you.UserName, messageText);

            // Fixed: Added DateTime.Now as the third argument
            AddMessageToPanel(messageText, true, DateTime.Now);
            message.Clear();
        }

        private void SaveMessageToDatabase(string senderId, string receiverId, string messageText)
        {
            using (SqlConnection conn = DB.Connect())
            {
                conn.Open();
                string query = "INSERT INTO Messages (sender_id, receiver_id, message, sent_at) VALUES (@sender, @receiver, @message, GETDATE())";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@sender", senderId);
                    cmd.Parameters.AddWithValue("@receiver", receiverId);
                    cmd.Parameters.AddWithValue("@message", messageText);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private void LoadMessages()
        {
            msgpanel.Controls.Clear();
            using (SqlConnection conn = DB.Connect())
            {
                conn.Open();
                string query = "SELECT sender_id, message, sent_at FROM Messages " +
                               "WHERE (sender_id = @me AND receiver_id = @you) OR (sender_id = @you AND receiver_id = @me) " +
                               "ORDER BY sent_at";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@me", me.UserName);
                    cmd.Parameters.AddWithValue("@you", you.UserName);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            bool isMe = reader["sender_id"].ToString() == me.UserName;
                            DateTime sentAt = Convert.ToDateTime(reader["sent_at"]);
                            AddMessageToPanel(reader["message"].ToString(), isMe, sentAt);
                        }
                    }
                }
            }
        }

        private void LoadRecentUsers()
        {
            recentUsersPanel.Controls.Clear();
            using (SqlConnection conn = DB.Connect())
            {
                conn.Open();
                string query = @"
                SELECT user_name, last_message_time FROM (
                    SELECT 
                        CASE 
                            WHEN sender_id = @me THEN receiver_id 
                            ELSE sender_id 
                        END AS user_name, 
                        MAX(sent_at) AS last_message_time
                    FROM Messages
                    WHERE sender_id = @me OR receiver_id = @me
                    GROUP BY 
                        CASE 
                            WHEN sender_id = @me THEN receiver_id 
                            ELSE sender_id 
                        END
                ) AS RecentUsers
                ORDER BY last_message_time";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@me", me.UserName);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string userName = reader["user_name"].ToString();
                            DateTime lastMessageTime = Convert.ToDateTime(reader["last_message_time"]);
                            string timeAgo = GetTimeAgo(lastMessageTime);

                            AddUserToRecentPanel(userName, timeAgo);
                        }
                    }
                }
            }
        }

        private void AddUserToRecentPanel(string userName, string timeAgo)
        {
            Button userButton = new Button {
                Text = $"{userName} \t\t ({timeAgo})",
                Dock = DockStyle.Top,
                Height = 40,
                BackColor = Color.LightGray,
                FlatStyle = FlatStyle.Flat
            };

            // Fixed: Implemented missing OpenChatWithUser method
          
            userButton.Click += (sender, e) => OpenChatWithUser(userName);
            recentUsersPanel.Controls.Add(userButton);
        }

        private void AddMessageToPanel(string messageText, bool isMe, DateTime sentAt)
        {
            // Time label setup
            Label timeLabel = new Label {
                Text = sentAt.ToString("MM-dd-yyyy hh:mm tt"),
                AutoSize = true,
                ForeColor = Color.Gray,
                Font = new Font("Arial", 8, FontStyle.Italic),
                Margin = new Padding(5)
            };

            // Message label setup
            Label messageLabel = new Label {
                Text = messageText,
                AutoSize = true,
                MaximumSize = new Size(400, 0),
                Padding = new Padding(10),
                BackColor = isMe ? Color.LightBlue : Color.LightGray,
                ForeColor = Color.Black,
                Font = new Font("Arial", 10),
                Margin = new Padding(5)
            };

            // Container setup
            FlowLayoutPanel container = new FlowLayoutPanel {
                AutoSize = true,
                FlowDirection = isMe ? FlowDirection.RightToLeft : FlowDirection.LeftToRight,
                Dock = DockStyle.Top,
                Padding = new Padding(5),
                Width = msgpanel.Width - 20 // Adjust width to fit within msgpanel
            };

            // Message container (holds time and message)
            FlowLayoutPanel messageContainer = new FlowLayoutPanel {
                AutoSize = true,
                FlowDirection = FlowDirection.TopDown
                
            };
 


            // Add time and message labels to the message container
            messageContainer.Controls.Add(timeLabel);
            messageContainer.Controls.Add(messageLabel);


            // Add message container to the main container
            container.Controls.Add(messageContainer);

            // Add padding to messages from 'me' for proper alignment
            if (isMe)
            {
                // Add space for messages from 'me' on the left side
                container.Controls.Add(new Label { Width = container.Width / 2 });
            }

            // Add the container to the message panel
            msgpanel.Controls.Add(container);
            msgpanel.ScrollControlIntoView(container);
        }


        private string GetTimeAgo(DateTime lastMessageTime)
        {
            TimeSpan timeSpan = DateTime.Now - lastMessageTime;

            if (timeSpan.TotalSeconds < 60)
                return $"{timeSpan.Seconds} secs ago";
            if (timeSpan.TotalMinutes < 60)
                return $"{timeSpan.Minutes} mins ago";
            if (timeSpan.TotalHours < 24)
                return $"{timeSpan.Hours} hrs ago";
            return $"{timeSpan.Days} days ago";
        }

        // Fixed: Implemented the missing OpenChatWithUser method
        private void OpenChatWithUser(string userName)
        {
            this.Hide();
            Chat newChat = new Chat(new User(userName)); // Assuming `User` class has a UserName property
            newChat.Show();
        }
    }
}
