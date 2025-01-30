
namespace FrameSphere
{
    partial class Admin_dashboard
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.RegisterLabel = new System.Windows.Forms.Label();
            this.eventsboard = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.userList_label = new System.Windows.Forms.Label();
            this.search_label = new System.Windows.Forms.Label();
            this.userpanel = new System.Windows.Forms.FlowLayoutPanel();
            this.label9 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.buttons_panel = new System.Windows.Forms.Panel();
            this.UserBoard = new System.Windows.Forms.Button();
            this.Logout = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.userpanel.SuspendLayout();
            this.buttons_panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.LightGreen;
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.RegisterLabel);
            this.panel1.Location = new System.Drawing.Point(16, 9);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1688, 106);
            this.panel1.TabIndex = 14;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Black;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.button1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button1.Location = new System.Drawing.Point(40, 31);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(211, 31);
            this.button1.TabIndex = 12;
            this.button1.Text = "Return to Dashboard";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.dashBoardButton_Click);
            // 
            // RegisterLabel
            // 
            this.RegisterLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
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
            // eventsboard
            // 
            this.eventsboard.BackColor = System.Drawing.Color.DarkGreen;
            this.eventsboard.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.eventsboard.Font = new System.Drawing.Font("Lucida Console", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.eventsboard.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.eventsboard.Location = new System.Drawing.Point(71, 65);
            this.eventsboard.Margin = new System.Windows.Forms.Padding(4);
            this.eventsboard.Name = "eventsboard";
            this.eventsboard.Size = new System.Drawing.Size(260, 36);
            this.eventsboard.TabIndex = 13;
            this.eventsboard.Text = "List of Events";
            this.eventsboard.UseVisualStyleBackColor = false;
            this.eventsboard.Click += new System.EventHandler(this.eventsboard_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.LightGreen;
            this.panel3.Controls.Add(this.userList_label);
            this.panel3.Controls.Add(this.search_label);
            this.panel3.Controls.Add(this.userpanel);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.textBox2);
            this.panel3.Location = new System.Drawing.Point(427, 123);
            this.panel3.Margin = new System.Windows.Forms.Padding(4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1311, 703);
            this.panel3.TabIndex = 16;
            // 
            // userList_label
            // 
            this.userList_label.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.userList_label.Font = new System.Drawing.Font("Lucida Console", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userList_label.ForeColor = System.Drawing.Color.Black;
            this.userList_label.Location = new System.Drawing.Point(56, 21);
            this.userList_label.Name = "userList_label";
            this.userList_label.Size = new System.Drawing.Size(1101, 27);
            this.userList_label.TabIndex = 28;
            this.userList_label.Text = "List of Users";
            this.userList_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // search_label
            // 
            this.search_label.Font = new System.Drawing.Font("Lucida Console", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.search_label.Location = new System.Drawing.Point(56, 75);
            this.search_label.Name = "search_label";
            this.search_label.Size = new System.Drawing.Size(104, 27);
            this.search_label.TabIndex = 27;
            this.search_label.Text = "Search: ";
            this.search_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // userpanel
            // 
            this.userpanel.AutoScroll = true;
            this.userpanel.Controls.Add(this.label9);
            this.userpanel.Location = new System.Drawing.Point(56, 121);
            this.userpanel.Margin = new System.Windows.Forms.Padding(4);
            this.userpanel.Name = "userpanel";
            this.userpanel.Size = new System.Drawing.Size(1101, 559);
            this.userpanel.TabIndex = 26;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(4, 0);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(92, 16);
            this.label9.TabIndex = 30;
            this.label9.Text = "NO User Here";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.LightGreen;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label5.Location = new System.Drawing.Point(688, 103);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 17);
            this.label5.TabIndex = 25;
            this.label5.Text = "Status";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(167, 73);
            this.textBox2.Margin = new System.Windows.Forms.Padding(4);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(990, 29);
            this.textBox2.TabIndex = 22;
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.DarkGreen;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button2.Font = new System.Drawing.Font("Lucida Console", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button2.Location = new System.Drawing.Point(71, 130);
            this.button2.Margin = new System.Windows.Forms.Padding(4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(260, 36);
            this.button2.TabIndex = 14;
            this.button2.Text = "Artist Applications";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
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
            this.buttons_panel.TabIndex = 17;
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
            this.Logout.Click += new System.EventHandler(this.Logout_Click);
            // 
            // Admin_dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1685, 838);
            this.Controls.Add(this.Logout);
            this.Controls.Add(this.buttons_panel);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Admin_dashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Admin_dashboard";
            this.Load += new System.EventHandler(this.Admin_dashboard_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.userpanel.ResumeLayout(false);
            this.userpanel.PerformLayout();
            this.buttons_panel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label RegisterLabel;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.FlowLayoutPanel userpanel;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button eventsboard;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Panel buttons_panel;
        private System.Windows.Forms.Button UserBoard;
        private System.Windows.Forms.Label userList_label;
        private System.Windows.Forms.Label search_label;
        private System.Windows.Forms.Button Logout;
    }
}