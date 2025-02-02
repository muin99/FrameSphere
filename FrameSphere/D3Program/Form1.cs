using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace FrameSphere.D3Program
{
    public partial class Form1 : Form
    {
        private FlowLayoutPanel flowLayoutPanel;

        public Form1()
        {
            InitializeComponent();
            SetupLayout();
            LoadArtData();
        }

        private void SetupLayout()
        {
            flowLayoutPanel = new FlowLayoutPanel {
                Dock = DockStyle.Fill,
                AutoScroll = true
            };

            this.Controls.Add(flowLayoutPanel);
        }

        private void LoadArtData()
        {
            string jsonFilePath = "..\\..\\D3Program\\artsCollections.json"; // Make sure this file exists in your project directory

            if (!File.Exists(jsonFilePath))
            {
                MessageBox.Show("JSON file not found!");
                return;
            }

            string jsonData = File.ReadAllText(jsonFilePath);
            List<ArtCollection> artList = JsonConvert.DeserializeObject<List<ArtCollection>>(jsonData);

            foreach (ArtCollection art in artList)
            {
                if (art.PhotoPath != null)
                {
                    foreach (string photo in art.PhotoPath)
                    {
                        if (!string.IsNullOrEmpty(photo) && File.Exists(photo))
                        {
                            PictureBox pb = new PictureBox {
                                Image = Image.FromFile(photo),
                                SizeMode = PictureBoxSizeMode.Zoom,
                                Width = 200,
                                Height = 200,
                                BorderStyle = BorderStyle.FixedSingle,
                                Margin = new Padding(10)
                            };

                            ToolTip tooltip = new ToolTip();
                            tooltip.SetToolTip(pb, art.Title);
                            flowLayoutPanel.Controls.Add(pb);
                        }
                        else
                        {
                            Label lbl = new Label {
                                Text = "Image not found",
                                AutoSize = true,
                                ForeColor = Color.Red,
                                Margin = new Padding(10)
                            };

                            flowLayoutPanel.Controls.Add(lbl);
                        }
                    }
                }
            }
        }
    }

    public class ArtCollection
    {
        public int ArtID { get; set; }
        public string Title { get; set; }
        public List<string> PhotoPath { get; set; }
        public string Description { get; set; }
        public string nameofCreator { get; set; }
        public string Creator { get; set; }
    }
}
