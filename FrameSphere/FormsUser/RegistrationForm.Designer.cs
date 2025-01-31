namespace FrameSphere
{
    partial class RegistrationForm
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
            this.FirstNameLabel = new System.Windows.Forms.Label();
            this.EmailLabel = new System.Windows.Forms.Label();
            this.LastNameLabel = new System.Windows.Forms.Label();
            this.PasswordLabel = new System.Windows.Forms.Label();
            this.UserName = new System.Windows.Forms.TextBox();
            this.Password = new System.Windows.Forms.TextBox();
            this.Email = new System.Windows.Forms.TextBox();
            this.FirstName = new System.Windows.Forms.TextBox();
            this.SubmitButton = new System.Windows.Forms.Button();
            this.RegisterLabel = new System.Windows.Forms.Label();
            this.ClearButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.charWarning = new System.Windows.Forms.Label();
            this.usernameWarning = new System.Windows.Forms.Label();
            this.confirmLabel = new System.Windows.Forms.Label();
            this.CheckMail = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ConfirmPass = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.LastName = new System.Windows.Forms.TextBox();
            this.lblPassStrength = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // FirstNameLabel
            // 
            this.FirstNameLabel.AutoSize = true;
            this.FirstNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FirstNameLabel.Location = new System.Drawing.Point(101, 80);
            this.FirstNameLabel.Name = "FirstNameLabel";
            this.FirstNameLabel.Size = new System.Drawing.Size(111, 20);
            this.FirstNameLabel.TabIndex = 2;
            this.FirstNameLabel.Text = "First Name : ";
            // 
            // EmailLabel
            // 
            this.EmailLabel.AutoSize = true;
            this.EmailLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EmailLabel.Location = new System.Drawing.Point(101, 125);
            this.EmailLabel.Name = "EmailLabel";
            this.EmailLabel.Size = new System.Drawing.Size(68, 20);
            this.EmailLabel.TabIndex = 3;
            this.EmailLabel.Text = "Email : ";
            this.EmailLabel.Click += new System.EventHandler(this.EmailLabel_Click);
            // 
            // LastNameLabel
            // 
            this.LastNameLabel.AutoSize = true;
            this.LastNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LastNameLabel.Location = new System.Drawing.Point(539, 80);
            this.LastNameLabel.Name = "LastNameLabel";
            this.LastNameLabel.Size = new System.Drawing.Size(110, 20);
            this.LastNameLabel.TabIndex = 4;
            this.LastNameLabel.Text = "Last Name : ";
            // 
            // PasswordLabel
            // 
            this.PasswordLabel.AutoSize = true;
            this.PasswordLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PasswordLabel.Location = new System.Drawing.Point(101, 220);
            this.PasswordLabel.Name = "PasswordLabel";
            this.PasswordLabel.Size = new System.Drawing.Size(101, 20);
            this.PasswordLabel.TabIndex = 5;
            this.PasswordLabel.Text = "Password : ";
            // 
            // UserName
            // 
            this.UserName.Location = new System.Drawing.Point(235, 171);
            this.UserName.Name = "UserName";
            this.UserName.Size = new System.Drawing.Size(696, 20);
            this.UserName.TabIndex = 6;
            this.UserName.TextChanged += new System.EventHandler(this.UserName_TextChanged);
            // 
            // Password
            // 
            this.Password.Location = new System.Drawing.Point(235, 220);
            this.Password.Name = "Password";
            this.Password.PasswordChar = '*';
            this.Password.Size = new System.Drawing.Size(237, 20);
            this.Password.TabIndex = 7;
            this.Password.TextChanged += new System.EventHandler(this.Password_TextChanged);
            // 
            // Email
            // 
            this.Email.Location = new System.Drawing.Point(235, 125);
            this.Email.Name = "Email";
            this.Email.Size = new System.Drawing.Size(696, 20);
            this.Email.TabIndex = 8;
            this.Email.TextChanged += new System.EventHandler(this.Email_TextChanged);
            // 
            // FirstName
            // 
            this.FirstName.Location = new System.Drawing.Point(235, 82);
            this.FirstName.Name = "FirstName";
            this.FirstName.Size = new System.Drawing.Size(276, 20);
            this.FirstName.TabIndex = 9;
            // 
            // SubmitButton
            // 
            this.SubmitButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SubmitButton.Location = new System.Drawing.Point(838, 274);
            this.SubmitButton.Name = "SubmitButton";
            this.SubmitButton.Size = new System.Drawing.Size(93, 28);
            this.SubmitButton.TabIndex = 10;
            this.SubmitButton.Text = "Register";
            this.SubmitButton.UseVisualStyleBackColor = true;
            this.SubmitButton.Click += new System.EventHandler(this.SubmitButton_Click);
            // 
            // RegisterLabel
            // 
            this.RegisterLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.RegisterLabel.AutoSize = true;
            this.RegisterLabel.BackColor = System.Drawing.Color.Transparent;
            this.RegisterLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RegisterLabel.ForeColor = System.Drawing.Color.DarkBlue;
            this.RegisterLabel.Location = new System.Drawing.Point(514, 34);
            this.RegisterLabel.Name = "RegisterLabel";
            this.RegisterLabel.Size = new System.Drawing.Size(172, 29);
            this.RegisterLabel.TabIndex = 11;
            this.RegisterLabel.Text = "Register Now";
            this.RegisterLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // ClearButton
            // 
            this.ClearButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ClearButton.Location = new System.Drawing.Point(655, 382);
            this.ClearButton.Name = "ClearButton";
            this.ClearButton.Size = new System.Drawing.Size(93, 28);
            this.ClearButton.TabIndex = 12;
            this.ClearButton.Text = "Login";
            this.ClearButton.UseVisualStyleBackColor = true;
            this.ClearButton.Click += new System.EventHandler(this.ClearButton_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightGreen;
            this.panel1.Controls.Add(this.RegisterLabel);
            this.panel1.Location = new System.Drawing.Point(-1, -1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1266, 86);
            this.panel1.TabIndex = 13;
            // 
            // panel2
            // 
            this.panel2.AutoScroll = true;
            this.panel2.BackColor = System.Drawing.Color.LightGreen;
            this.panel2.Controls.Add(this.lblPassStrength);
            this.panel2.Controls.Add(this.charWarning);
            this.panel2.Controls.Add(this.usernameWarning);
            this.panel2.Controls.Add(this.confirmLabel);
            this.panel2.Controls.Add(this.CheckMail);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.ConfirmPass);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.LastName);
            this.panel2.Controls.Add(this.FirstName);
            this.panel2.Controls.Add(this.Email);
            this.panel2.Controls.Add(this.LastNameLabel);
            this.panel2.Controls.Add(this.PasswordLabel);
            this.panel2.Controls.Add(this.EmailLabel);
            this.panel2.Controls.Add(this.SubmitButton);
            this.panel2.Controls.Add(this.ClearButton);
            this.panel2.Controls.Add(this.UserName);
            this.panel2.Controls.Add(this.Password);
            this.panel2.Controls.Add(this.FirstNameLabel);
            this.panel2.Location = new System.Drawing.Point(75, 132);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1112, 501);
            this.panel2.TabIndex = 14;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // charWarning
            // 
            this.charWarning.AutoSize = true;
            this.charWarning.ForeColor = System.Drawing.Color.Red;
            this.charWarning.Location = new System.Drawing.Point(232, 194);
            this.charWarning.Name = "charWarning";
            this.charWarning.Size = new System.Drawing.Size(568, 13);
            this.charWarning.TabIndex = 21;
            this.charWarning.Text = "Username must contain only alphabets (a-z, A-Z), numbers (0-9), or underscores (_" +
    "). Special characters are not allowed.";
            this.charWarning.Visible = false;
            // 
            // usernameWarning
            // 
            this.usernameWarning.AutoSize = true;
            this.usernameWarning.ForeColor = System.Drawing.Color.Red;
            this.usernameWarning.Location = new System.Drawing.Point(232, 194);
            this.usernameWarning.Name = "usernameWarning";
            this.usernameWarning.Size = new System.Drawing.Size(73, 13);
            this.usernameWarning.TabIndex = 20;
            this.usernameWarning.Text = "Already in use";
            this.usernameWarning.Visible = false;
            // 
            // confirmLabel
            // 
            this.confirmLabel.AutoSize = true;
            this.confirmLabel.ForeColor = System.Drawing.Color.Red;
            this.confirmLabel.Location = new System.Drawing.Point(707, 249);
            this.confirmLabel.Name = "confirmLabel";
            this.confirmLabel.Size = new System.Drawing.Size(118, 13);
            this.confirmLabel.TabIndex = 19;
            this.confirmLabel.Text = "Passwords didn\'t match";
            this.confirmLabel.Visible = false;
            // 
            // CheckMail
            // 
            this.CheckMail.AutoSize = true;
            this.CheckMail.ForeColor = System.Drawing.Color.Red;
            this.CheckMail.Location = new System.Drawing.Point(232, 148);
            this.CheckMail.Name = "CheckMail";
            this.CheckMail.Size = new System.Drawing.Size(130, 13);
            this.CheckMail.TabIndex = 18;
            this.CheckMail.Text = "Please enter a valid email.";
            this.CheckMail.Visible = false;
            this.CheckMail.Click += new System.EventHandler(this.label4_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(394, 385);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(236, 20);
            this.label3.TabIndex = 17;
            this.label3.Text = "Already have an account?  : ";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // ConfirmPass
            // 
            this.ConfirmPass.Location = new System.Drawing.Point(707, 222);
            this.ConfirmPass.Name = "ConfirmPass";
            this.ConfirmPass.PasswordChar = '*';
            this.ConfirmPass.Size = new System.Drawing.Size(224, 20);
            this.ConfirmPass.TabIndex = 16;
            this.ConfirmPass.TextChanged += new System.EventHandler(this.ConfirmPass_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(518, 222);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(168, 20);
            this.label2.TabIndex = 15;
            this.label2.Text = "Confirm Password : ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(101, 171);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 20);
            this.label1.TabIndex = 14;
            this.label1.Text = "User Name : ";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // LastName
            // 
            this.LastName.Location = new System.Drawing.Point(655, 82);
            this.LastName.Name = "LastName";
            this.LastName.Size = new System.Drawing.Size(276, 20);
            this.LastName.TabIndex = 13;
            // 
            // lblPassStrength
            // 
            this.lblPassStrength.AutoSize = true;
            this.lblPassStrength.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPassStrength.ForeColor = System.Drawing.Color.DarkOrchid;
            this.lblPassStrength.Location = new System.Drawing.Point(232, 249);
            this.lblPassStrength.Name = "lblPassStrength";
            this.lblPassStrength.Size = new System.Drawing.Size(140, 13);
            this.lblPassStrength.TabIndex = 22;
            this.lblPassStrength.Text = "Passwords didn\'t match";
            this.lblPassStrength.Visible = false;
            // 
            // RegistrationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "RegistrationForm";
            this.Text = "RegistrationForm";
            this.Load += new System.EventHandler(this.RegistrationForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label FirstNameLabel;
        private System.Windows.Forms.Label EmailLabel;
        private System.Windows.Forms.Label LastNameLabel;
        private System.Windows.Forms.Label PasswordLabel;
        private System.Windows.Forms.TextBox UserName;
        private System.Windows.Forms.TextBox Password;
        private System.Windows.Forms.TextBox Email;
        private System.Windows.Forms.TextBox FirstName;
        private System.Windows.Forms.Button SubmitButton;
        private System.Windows.Forms.Label RegisterLabel;
        private System.Windows.Forms.Button ClearButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox LastName;
        private System.Windows.Forms.TextBox ConfirmPass;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label CheckMail;
        private System.Windows.Forms.Label confirmLabel;
        private System.Windows.Forms.Label usernameWarning;
        private System.Windows.Forms.Label charWarning;
        private System.Windows.Forms.Label lblPassStrength;
    }
}