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

        public Chat(User you)
        {
            this.you = you;
            InitializeComponent();
            LoadMessages();
        }

        private void sendbutton_Click_1(object sender, EventArgs e)
        {
            string messageText = message.Text.Trim();
            if (string.IsNullOrEmpty(messageText)) return;

            // Save to database
            SaveMessageToDatabase(me.UserName, you.UserName, messageText);

            // Update UI
            AddMessageToPanel(messageText, true);
            message.Clear();
        }

        private void SaveMessageToDatabase(string senderId, string receiverId, string messageText)
        {
            using (SqlConnection conn = DB.Connect())
            {
                conn.Open();
                string query = "INSERT INTO Messages (sender_id, receiver_id, message) VALUES (@sender, @receiver, @message)";
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
                string query = "SELECT sender_id, message FROM Messages WHERE (sender_id = @me AND receiver_id = @you) OR (sender_id = @you AND receiver_id = @me) ORDER BY sent_at";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@me", me.UserName);
                    cmd.Parameters.AddWithValue("@you", you.UserName);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            bool isMe = reader["sender_id"].ToString() == me.UserName;
                            AddMessageToPanel(reader["message"].ToString(), isMe);
                        }
                    }
                }
            }
        }

        private void AddMessageToPanel(string messageText, bool isMe)
        {
            Label messageLabel = new Label {
                Text = messageText,
                AutoSize = true,
                MaximumSize = new Size(400, 0),
                Padding = new Padding(10),
                BackColor = isMe ? Color.LightBlue : Color.LightGray,
                ForeColor = Color.Black,
                Font = new Font("Arial", 10),
                Margin = new Padding(5),
            };

            FlowLayoutPanel container = new FlowLayoutPanel {
                AutoSize = true,
                FlowDirection = FlowDirection.LeftToRight,
                Dock = DockStyle.Top,
                Padding = new Padding(5),
                Width = msgpanel.Width - 20
            };

            if (isMe)
            {
                container.Controls.Add(new Label { Width = container.Width / 2 }); // Push to the right
                container.Controls.Add(messageLabel);

            }
            else
            {
                container.Controls.Add(messageLabel);
            }

            msgpanel.Controls.Add(container);
            msgpanel.ScrollControlIntoView(container);
        }
        private void message_Enter(object sender, EventArgs e)
        {

        }

        private void message_Leave(object sender, EventArgs e)
        {

        }
    }
}
