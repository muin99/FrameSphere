namespace FrameSphere
{
    partial class ArtCollection
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ArtCollection));
            this.panel1 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.RegisteredEventsButton = new System.Windows.Forms.Button();
            this.WelcomeNameField = new System.Windows.Forms.TextBox();
            this.ArtCollectionsButton = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.LogoutButton = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.RegisteredEventsButton);
            this.panel1.Controls.Add(this.WelcomeNameField);
            this.panel1.Controls.Add(this.ArtCollectionsButton);
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Location = new System.Drawing.Point(1, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(227, 535);
            this.panel1.TabIndex = 1;
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
            this.panel2.Location = new System.Drawing.Point(232, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(742, 51);
            this.panel2.TabIndex = 2;
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
            // 
            // ArtCollection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 535);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "ArtCollection";
            this.Text = "Art Collection";
            this.Load += new System.EventHandler(this.ArtCollection_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button RegisteredEventsButton;
        private System.Windows.Forms.TextBox WelcomeNameField;
        private System.Windows.Forms.Button ArtCollectionsButton;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button LogoutButton;
    }
}