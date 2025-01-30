namespace FrameSphere
{
    partial class ArtistApplications
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.artistpanel = new System.Windows.Forms.FlowLayoutPanel();
            this.noevent = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.RegisterLabel = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.artistList_label = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.buttons_panel = new System.Windows.Forms.Panel();
            this.UserBoard = new System.Windows.Forms.Button();
            this.eventsboard = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.search_label = new System.Windows.Forms.Label();
            this.Logout = new System.Windows.Forms.Button();
            this.artistpanel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.buttons_panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // artistpanel
            // 
            this.artistpanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.artistpanel.AutoScroll = true;
            this.artistpanel.Controls.Add(this.noevent);
            this.artistpanel.Location = new System.Drawing.Point(51, 116);
            this.artistpanel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.artistpanel.Name = "artistpanel";
            this.artistpanel.Size = new System.Drawing.Size(1225, 559);
            this.artistpanel.TabIndex = 27;
            // 
            // noevent
            // 
            this.noevent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.noevent.AutoSize = true;
            this.noevent.Location = new System.Drawing.Point(4, 0);
            this.noevent.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.noevent.Name = "noevent";
            this.noevent.Size = new System.Drawing.Size(137, 16);
            this.noevent.TabIndex = 28;
            this.noevent.Text = "NO Applications Here";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.LightGreen;
            this.panel1.Controls.Add(this.Logout);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.RegisterLabel);
            this.panel1.Location = new System.Drawing.Point(16, 10);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1688, 106);
            this.panel1.TabIndex = 19;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Black;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.button1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button1.Location = new System.Drawing.Point(40, 31);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(211, 31);
            this.button1.TabIndex = 12;
            this.button1.Text = "Return to Dashboard";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // RegisterLabel
            // 
            this.RegisterLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.RegisterLabel.AutoSize = true;
            this.RegisterLabel.BackColor = System.Drawing.Color.Transparent;
            this.RegisterLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RegisterLabel.ForeColor = System.Drawing.Color.DarkBlue;
            this.RegisterLabel.Location = new System.Drawing.Point(703, 37);
            this.RegisterLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.RegisterLabel.Name = "RegisterLabel";
            this.RegisterLabel.Size = new System.Drawing.Size(269, 36);
            this.RegisterLabel.TabIndex = 11;
            this.RegisterLabel.Text = "Admin Dashboard";
            this.RegisterLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.LightGreen;
            this.panel2.Controls.Add(this.search_label);
            this.panel2.Controls.Add(this.artistpanel);
            this.panel2.Controls.Add(this.artistList_label);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.textBox1);
            this.panel2.Location = new System.Drawing.Point(427, 123);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1311, 703);
            this.panel2.TabIndex = 20;
            // 
            // artistList_label
            // 
            this.artistList_label.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.artistList_label.Font = new System.Drawing.Font("Lucida Console", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.artistList_label.ForeColor = System.Drawing.Color.Black;
            this.artistList_label.Location = new System.Drawing.Point(56, 21);
            this.artistList_label.Name = "artistList_label";
            this.artistList_label.Size = new System.Drawing.Size(1101, 27);
            this.artistList_label.TabIndex = 29;
            this.artistList_label.Text = "List of Artist Applications";
            this.artistList_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.LightGreen;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Location = new System.Drawing.Point(688, 96);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 17);
            this.label2.TabIndex = 20;
            this.label2.Text = "Status";
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(166, 66);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(1081, 29);
            this.textBox1.TabIndex = 17;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // buttons_panel
            // 
            this.buttons_panel.BackColor = System.Drawing.Color.LightGreen;
            this.buttons_panel.Controls.Add(this.UserBoard);
            this.buttons_panel.Controls.Add(this.eventsboard);
            this.buttons_panel.Controls.Add(this.button2);
            this.buttons_panel.Location = new System.Drawing.Point(16, 123);
            this.buttons_panel.Name = "buttons_panel";
            this.buttons_panel.Size = new System.Drawing.Size(404, 703);
            this.buttons_panel.TabIndex = 21;
            // 
            // UserBoard
            // 
            this.UserBoard.BackColor = System.Drawing.Color.DarkGreen;
            this.UserBoard.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.UserBoard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.UserBoard.Font = new System.Drawing.Font("Lucida Console", 11.25F);
            this.UserBoard.ForeColor = System.Drawing.Color.White;
            this.UserBoard.Location = new System.Drawing.Point(71, 198);
            this.UserBoard.Name = "UserBoard";
            this.UserBoard.Size = new System.Drawing.Size(260, 36);
            this.UserBoard.TabIndex = 15;
            this.UserBoard.Text = "List of Users";
            this.UserBoard.UseVisualStyleBackColor = false;
            this.UserBoard.Click += new System.EventHandler(this.UserBoard_Click);
            // 
            // eventsboard
            // 
            this.eventsboard.BackColor = System.Drawing.Color.DarkGreen;
            this.eventsboard.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.eventsboard.Font = new System.Drawing.Font("Lucida Console", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.eventsboard.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.eventsboard.Location = new System.Drawing.Point(71, 65);
            this.eventsboard.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.eventsboard.Name = "eventsboard";
            this.eventsboard.Size = new System.Drawing.Size(260, 36);
            this.eventsboard.TabIndex = 13;
            this.eventsboard.Text = "List of Events";
            this.eventsboard.UseVisualStyleBackColor = false;
            this.eventsboard.Click += new System.EventHandler(this.eventsboard_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.DarkGreen;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button2.Font = new System.Drawing.Font("Lucida Console", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button2.Location = new System.Drawing.Point(71, 130);
            this.button2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(260, 36);
            this.button2.TabIndex = 14;
            this.button2.Text = "Artist Applications";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // search_label
            // 
            this.search_label.Font = new System.Drawing.Font("Lucida Console", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.search_label.Location = new System.Drawing.Point(55, 73);
            this.search_label.Name = "search_label";
            this.search_label.Size = new System.Drawing.Size(104, 27);
            this.search_label.TabIndex = 30;
            this.search_label.Text = "Search: ";
            this.search_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Logout
            // 
            this.Logout.BackColor = System.Drawing.Color.Black;
            this.Logout.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.Logout.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.Logout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Logout.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.Logout.ForeColor = System.Drawing.Color.White;
            this.Logout.Location = new System.Drawing.Point(1561, 37);
            this.Logout.Margin = new System.Windows.Forms.Padding(4);
            this.Logout.Name = "Logout";
            this.Logout.Size = new System.Drawing.Size(112, 31);
            this.Logout.TabIndex = 20;
            this.Logout.Text = "Log out";
            this.Logout.UseVisualStyleBackColor = false;
            // 
            // ArtistApplications
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1685, 838);
            this.Controls.Add(this.buttons_panel);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "ArtistApplications";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ArtistApplications";
            this.artistpanel.ResumeLayout(false);
            this.artistpanel.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.buttons_panel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel artistpanel;
        private System.Windows.Forms.Label noevent;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label RegisterLabel;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label artistList_label;
        private System.Windows.Forms.Panel buttons_panel;
        private System.Windows.Forms.Button UserBoard;
        private System.Windows.Forms.Button eventsboard;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label search_label;
        private System.Windows.Forms.Button Logout;
    }
}