
namespace FrameSphere
{
    partial class AllArt
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
            this.buttons_panel = new System.Windows.Forms.Panel();
            this.artlist = new System.Windows.Forms.Button();
            this.UserBoard = new System.Windows.Forms.Button();
            this.eventsboard = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Logout = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.RegisterLabel = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.EventsList_label = new System.Windows.Forms.Label();
            this.search_label = new System.Windows.Forms.Label();
            this.artsPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.noArtLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.searchTextBox = new System.Windows.Forms.TextBox();
            this.buttons_panel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.artsPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttons_panel
            // 
            this.buttons_panel.BackColor = System.Drawing.Color.LightGreen;
            this.buttons_panel.Controls.Add(this.artlist);
            this.buttons_panel.Controls.Add(this.UserBoard);
            this.buttons_panel.Controls.Add(this.eventsboard);
            this.buttons_panel.Controls.Add(this.button2);
            this.buttons_panel.Location = new System.Drawing.Point(-13, 102);
            this.buttons_panel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttons_panel.Name = "buttons_panel";
            this.buttons_panel.Size = new System.Drawing.Size(303, 571);
            this.buttons_panel.TabIndex = 22;
            // 
            // artlist
            // 
            this.artlist.BackColor = System.Drawing.Color.DarkGreen;
            this.artlist.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.artlist.Font = new System.Drawing.Font("Lucida Console", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.artlist.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.artlist.Location = new System.Drawing.Point(53, 213);
            this.artlist.Name = "artlist";
            this.artlist.Size = new System.Drawing.Size(195, 29);
            this.artlist.TabIndex = 20;
            this.artlist.Text = "List of Arts";
            this.artlist.UseVisualStyleBackColor = false;
            this.artlist.Click += new System.EventHandler(this.artsBoardButton_Click);
            // 
            // UserBoard
            // 
            this.UserBoard.BackColor = System.Drawing.Color.DarkGreen;
            this.UserBoard.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.UserBoard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.UserBoard.Font = new System.Drawing.Font("Lucida Console", 11.25F);
            this.UserBoard.ForeColor = System.Drawing.Color.White;
            this.UserBoard.Location = new System.Drawing.Point(53, 161);
            this.UserBoard.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.UserBoard.Name = "UserBoard";
            this.UserBoard.Size = new System.Drawing.Size(195, 29);
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
            this.eventsboard.Location = new System.Drawing.Point(53, 53);
            this.eventsboard.Name = "eventsboard";
            this.eventsboard.Size = new System.Drawing.Size(195, 29);
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
            this.button2.Location = new System.Drawing.Point(53, 106);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(195, 29);
            this.button2.TabIndex = 14;
            this.button2.Text = "Artist Applications";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.artistAppsButton_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.LightGreen;
            this.panel1.Controls.Add(this.Logout);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.RegisterLabel);
            this.panel1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.panel1.Location = new System.Drawing.Point(-13, 7);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1291, 86);
            this.panel1.TabIndex = 20;
            // 
            // Logout
            // 
            this.Logout.BackColor = System.Drawing.Color.Black;
            this.Logout.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.Logout.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.Logout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Logout.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.Logout.ForeColor = System.Drawing.Color.White;
            this.Logout.Location = new System.Drawing.Point(1171, 30);
            this.Logout.Name = "Logout";
            this.Logout.Size = new System.Drawing.Size(84, 25);
            this.Logout.TabIndex = 19;
            this.Logout.Text = "Log out";
            this.Logout.UseVisualStyleBackColor = false;
            this.Logout.Click += new System.EventHandler(this.logoutButton_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Black;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.button1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button1.Location = new System.Drawing.Point(30, 25);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(158, 25);
            this.button1.TabIndex = 12;
            this.button1.Text = "Return to Dashboard";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // RegisterLabel
            // 
            this.RegisterLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.RegisterLabel.AutoSize = true;
            this.RegisterLabel.BackColor = System.Drawing.Color.Transparent;
            this.RegisterLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RegisterLabel.ForeColor = System.Drawing.Color.DarkBlue;
            this.RegisterLabel.Location = new System.Drawing.Point(527, 30);
            this.RegisterLabel.Name = "RegisterLabel";
            this.RegisterLabel.Size = new System.Drawing.Size(220, 29);
            this.RegisterLabel.TabIndex = 11;
            this.RegisterLabel.Text = "Admin Dashboard";
            this.RegisterLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.LightGreen;
            this.panel2.Controls.Add(this.EventsList_label);
            this.panel2.Controls.Add(this.search_label);
            this.panel2.Controls.Add(this.artsPanel);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.searchTextBox);
            this.panel2.Location = new System.Drawing.Point(295, 102);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(983, 571);
            this.panel2.TabIndex = 21;
            // 
            // EventsList_label
            // 
            this.EventsList_label.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.EventsList_label.Font = new System.Drawing.Font("Lucida Console", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EventsList_label.ForeColor = System.Drawing.Color.Black;
            this.EventsList_label.Location = new System.Drawing.Point(120, 15);
            this.EventsList_label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.EventsList_label.Name = "EventsList_label";
            this.EventsList_label.Size = new System.Drawing.Size(826, 22);
            this.EventsList_label.TabIndex = 29;
            this.EventsList_label.Text = "List of Arts";
            this.EventsList_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // search_label
            // 
            this.search_label.Font = new System.Drawing.Font("Lucida Console", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.search_label.Location = new System.Drawing.Point(41, 59);
            this.search_label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.search_label.Name = "search_label";
            this.search_label.Size = new System.Drawing.Size(78, 22);
            this.search_label.TabIndex = 28;
            this.search_label.Text = "Search: ";
            this.search_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // artsPanel
            // 
            this.artsPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.artsPanel.AutoScroll = true;
            this.artsPanel.Controls.Add(this.noArtLabel);
            this.artsPanel.Location = new System.Drawing.Point(44, 94);
            this.artsPanel.Name = "artsPanel";
            this.artsPanel.Size = new System.Drawing.Size(919, 454);
            this.artsPanel.TabIndex = 27;
            // 
            // noArtLabel
            // 
            this.noArtLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.noArtLabel.AutoSize = true;
            this.noArtLabel.Location = new System.Drawing.Point(3, 0);
            this.noArtLabel.Name = "noArtLabel";
            this.noArtLabel.Size = new System.Drawing.Size(80, 13);
            this.noArtLabel.TabIndex = 28;
            this.noArtLabel.Text = "NO Event Here";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.LightGreen;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Location = new System.Drawing.Point(516, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 13);
            this.label2.TabIndex = 20;
            this.label2.Text = "Selling Option";
            // 
            // searchTextBox
            // 
            this.searchTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.searchTextBox.Location = new System.Drawing.Point(124, 54);
            this.searchTextBox.Multiline = true;
            this.searchTextBox.Name = "searchTextBox";
            this.searchTextBox.Size = new System.Drawing.Size(812, 24);
            this.searchTextBox.TabIndex = 17;
            this.searchTextBox.TextChanged += new System.EventHandler(this.searchTextBox_TextChanged_1);
            // 
            // AllArt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1280, 681);
            this.Controls.Add(this.buttons_panel);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Name = "AllArt";
            this.Text = "All Art";
            this.buttons_panel.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.artsPanel.ResumeLayout(false);
            this.artsPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel buttons_panel;
        private System.Windows.Forms.Button UserBoard;
        private System.Windows.Forms.Button eventsboard;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button Logout;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label RegisterLabel;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label EventsList_label;
        private System.Windows.Forms.Label search_label;
        private System.Windows.Forms.FlowLayoutPanel artsPanel;
        private System.Windows.Forms.Label noArtLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox searchTextBox;
        private System.Windows.Forms.Button artlist;
    }
}