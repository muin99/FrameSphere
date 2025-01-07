namespace FrameSphere
{
    partial class UserDashboard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserDashboard));
            this.panel1 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.RegisteredEventsButton = new System.Windows.Forms.Button();
            this.WelcomeNameField = new System.Windows.Forms.TextBox();
            this.ArtCollectionsButton = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.LogoutButton = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.OngoingEventsLabel = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.UpcomingEventsLabel = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.RegisteredEventsButton);
            this.panel1.Controls.Add(this.WelcomeNameField);
            this.panel1.Controls.Add(this.ArtCollectionsButton);
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Location = new System.Drawing.Point(1, 1);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(227, 535);
            this.panel1.TabIndex = 0;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(16, 360);
            this.button2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(177, 47);
            this.button2.TabIndex = 7;
            this.button2.Text = "Profile Settings";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // RegisteredEventsButton
            // 
            this.RegisteredEventsButton.Location = new System.Drawing.Point(16, 290);
            this.RegisteredEventsButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.RegisteredEventsButton.Name = "RegisteredEventsButton";
            this.RegisteredEventsButton.Size = new System.Drawing.Size(177, 47);
            this.RegisteredEventsButton.TabIndex = 6;
            this.RegisteredEventsButton.Text = "Registered Events";
            this.RegisteredEventsButton.UseVisualStyleBackColor = true;
            // 
            // WelcomeNameField
            // 
            this.WelcomeNameField.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.WelcomeNameField.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WelcomeNameField.Location = new System.Drawing.Point(16, 153);
            this.WelcomeNameField.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.WelcomeNameField.Name = "WelcomeNameField";
            this.WelcomeNameField.Size = new System.Drawing.Size(186, 17);
            this.WelcomeNameField.TabIndex = 5;
            this.WelcomeNameField.Text = "<FirstName> <Surname>";
            // 
            // ArtCollectionsButton
            // 
            this.ArtCollectionsButton.Location = new System.Drawing.Point(16, 220);
            this.ArtCollectionsButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ArtCollectionsButton.Name = "ArtCollectionsButton";
            this.ArtCollectionsButton.Size = new System.Drawing.Size(177, 47);
            this.ArtCollectionsButton.TabIndex = 2;
            this.ArtCollectionsButton.Text = "Art Collections";
            this.ArtCollectionsButton.UseVisualStyleBackColor = true;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(48, 26);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(110, 122);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.LogoutButton);
            this.panel2.Location = new System.Drawing.Point(233, 1);
            this.panel2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(742, 51);
            this.panel2.TabIndex = 1;
            // 
            // LogoutButton
            // 
            this.LogoutButton.Location = new System.Drawing.Point(633, 9);
            this.LogoutButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.LogoutButton.Name = "LogoutButton";
            this.LogoutButton.Size = new System.Drawing.Size(88, 30);
            this.LogoutButton.TabIndex = 3;
            this.LogoutButton.Text = "Logout";
            this.LogoutButton.UseVisualStyleBackColor = true;
            this.LogoutButton.Click += new System.EventHandler(this.LogoutButton_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.OngoingEventsLabel);
            this.panel3.Location = new System.Drawing.Point(233, 58);
            this.panel3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(360, 478);
            this.panel3.TabIndex = 2;
            // 
            // OngoingEventsLabel
            // 
            this.OngoingEventsLabel.AutoSize = true;
            this.OngoingEventsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OngoingEventsLabel.Location = new System.Drawing.Point(76, 22);
            this.OngoingEventsLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.OngoingEventsLabel.Name = "OngoingEventsLabel";
            this.OngoingEventsLabel.Size = new System.Drawing.Size(181, 26);
            this.OngoingEventsLabel.TabIndex = 0;
            this.OngoingEventsLabel.Text = "Ongoing Events";
            this.OngoingEventsLabel.Click += new System.EventHandler(this.OngoingEventsLabel_Click);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.UpcomingEventsLabel);
            this.panel4.Location = new System.Drawing.Point(611, 58);
            this.panel4.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(364, 485);
            this.panel4.TabIndex = 3;
            // 
            // UpcomingEventsLabel
            // 
            this.UpcomingEventsLabel.AutoSize = true;
            this.UpcomingEventsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UpcomingEventsLabel.Location = new System.Drawing.Point(81, 22);
            this.UpcomingEventsLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.UpcomingEventsLabel.Name = "UpcomingEventsLabel";
            this.UpcomingEventsLabel.Size = new System.Drawing.Size(199, 26);
            this.UpcomingEventsLabel.TabIndex = 1;
            this.UpcomingEventsLabel.Text = "Upcoming Events";
            // 
            // UserDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 535);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "UserDashboard";
            this.Text = "UserDashboard";
            this.Load += new System.EventHandler(this.UserDashboard_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button ArtCollectionsButton;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button LogoutButton;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TextBox WelcomeNameField;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button RegisteredEventsButton;
        private System.Windows.Forms.Label OngoingEventsLabel;
        private System.Windows.Forms.Label UpcomingEventsLabel;
    }
}