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
    public partial class ManageParticipants : Form
    {
        private Event _event;
        public ManageParticipants(Event _selected)
        {
            InitializeComponent();
            this._event = _selected;
            LoadArtists();
        }
        private void LoadArtists()
        {
            AddArtistPanel("a","raisa");
        }

        private void AddArtistPanel(string username,string firstname)
        {
            Panel participant = new Panel{
                Size = new Size(participants_panel.Width - 10, 40),
                BackColor = Color.LightGreen,
                Padding = new Padding(5),
                Margin = new Padding(3)
            };

            Label username_label = new Label {
                Text = username,
                AutoSize = true,
                Font = new Font("Arial", 10, FontStyle.Bold),
                Location = new Point(5, 10)
            };

            Label firstname_label = new Label {
                Text = firstname,
                AutoSize = true,
                Font = new Font("Arial", 10, FontStyle.Bold),
                Location = new Point(35, 10)
            };

            Button remove_button = new Button {
                Text = "Remove",
                Size = new Size(75, 25),
                Location = new Point(participants_panel.Width - 85, 5),
                BackColor = Color.Red,
                ForeColor = Color.White,
                Tag = username // Store artist name in Tag
            };
            remove_button.Click += (s, e) => RemoveArtist((Button)s, username);

            participant.Controls.Add(username_label);
            participant.Controls.Add(firstname_label);
            participant.Controls.Add(remove_button);
            participants_panel.Controls.Add(participant);
        }
        private void RemoveArtist(Button btn, string name)
        {
            _event.Artists.RemoveAll(a => a.FirstName == name);
           
            participants_panel.Controls.Remove(btn.Parent); // Remove panel
        }

    }
}
