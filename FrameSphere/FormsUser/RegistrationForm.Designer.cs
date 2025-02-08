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
            this.noNumbers2 = new System.Windows.Forms.Label();
            this.noNumbers1 = new System.Windows.Forms.Label();
            this.lengthWarning = new System.Windows.Forms.Label();
            this.checklname = new System.Windows.Forms.Label();
            this.checkfname = new System.Windows.Forms.Label();
            this.lblPassStrength = new System.Windows.Forms.Label();
            this.charWarning = new System.Windows.Forms.Label();
            this.usernameWarning = new System.Windows.Forms.Label();
            this.confirmLabel = new System.Windows.Forms.Label();
            this.CheckMail = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ConfirmPass = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.LastName = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // FirstNameLabel
            // 
            this.FirstNameLabel.AutoSize = true;
            this.FirstNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FirstNameLabel.Location = new System.Drawing.Point(135, 98);
            this.FirstNameLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.FirstNameLabel.Name = "FirstNameLabel";
            this.FirstNameLabel.Size = new System.Drawing.Size(135, 25);
            this.FirstNameLabel.TabIndex = 2;
            this.FirstNameLabel.Text = "First Name : ";
            // 
            // EmailLabel
            // 
            this.EmailLabel.AutoSize = true;
            this.EmailLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EmailLabel.Location = new System.Drawing.Point(135, 154);
            this.EmailLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.EmailLabel.Name = "EmailLabel";
            this.EmailLabel.Size = new System.Drawing.Size(84, 25);
            this.EmailLabel.TabIndex = 3;
            this.EmailLabel.Text = "Email : ";
            this.EmailLabel.Click += new System.EventHandler(this.EmailLabel_Click);
            // 
            // LastNameLabel
            // 
            this.LastNameLabel.AutoSize = true;
            this.LastNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LastNameLabel.Location = new System.Drawing.Point(719, 98);
            this.LastNameLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LastNameLabel.Name = "LastNameLabel";
            this.LastNameLabel.Size = new System.Drawing.Size(134, 25);
            this.LastNameLabel.TabIndex = 4;
            this.LastNameLabel.Text = "Last Name : ";
            // 
            // PasswordLabel
            // 
            this.PasswordLabel.AutoSize = true;
            this.PasswordLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PasswordLabel.Location = new System.Drawing.Point(135, 271);
            this.PasswordLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.PasswordLabel.Name = "PasswordLabel";
            this.PasswordLabel.Size = new System.Drawing.Size(125, 25);
            this.PasswordLabel.TabIndex = 5;
            this.PasswordLabel.Text = "Password : ";
            // 
            // UserName
            // 
            this.UserName.Location = new System.Drawing.Point(313, 210);
            this.UserName.Margin = new System.Windows.Forms.Padding(4);
            this.UserName.Name = "UserName";
            this.UserName.Size = new System.Drawing.Size(927, 22);
            this.UserName.TabIndex = 6;
            this.UserName.TextChanged += new System.EventHandler(this.UserName_TextChanged);
            // 
            // Password
            // 
            this.Password.Location = new System.Drawing.Point(313, 271);
            this.Password.Margin = new System.Windows.Forms.Padding(4);
            this.Password.Name = "Password";
            this.Password.PasswordChar = '*';
            this.Password.Size = new System.Drawing.Size(315, 22);
            this.Password.TabIndex = 7;
            this.Password.TextChanged += new System.EventHandler(this.Password_TextChanged);
            // 
            // Email
            // 
            this.Email.Location = new System.Drawing.Point(313, 154);
            this.Email.Margin = new System.Windows.Forms.Padding(4);
            this.Email.Name = "Email";
            this.Email.Size = new System.Drawing.Size(927, 22);
            this.Email.TabIndex = 8;
            this.Email.TextChanged += new System.EventHandler(this.Email_TextChanged);
            // 
            // FirstName
            // 
            this.FirstName.Location = new System.Drawing.Point(313, 101);
            this.FirstName.Margin = new System.Windows.Forms.Padding(4);
            this.FirstName.Name = "FirstName";
            this.FirstName.Size = new System.Drawing.Size(367, 22);
            this.FirstName.TabIndex = 9;
            this.FirstName.TextChanged += new System.EventHandler(this.FirstName_TextChanged);
            // 
            // SubmitButton
            // 
            this.SubmitButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SubmitButton.Location = new System.Drawing.Point(1117, 337);
            this.SubmitButton.Margin = new System.Windows.Forms.Padding(4);
            this.SubmitButton.Name = "SubmitButton";
            this.SubmitButton.Size = new System.Drawing.Size(124, 34);
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
            this.RegisterLabel.Location = new System.Drawing.Point(685, 42);
            this.RegisterLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.RegisterLabel.Name = "RegisterLabel";
            this.RegisterLabel.Size = new System.Drawing.Size(207, 36);
            this.RegisterLabel.TabIndex = 11;
            this.RegisterLabel.Text = "Register Now";
            this.RegisterLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // ClearButton
            // 
            this.ClearButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ClearButton.Location = new System.Drawing.Point(873, 470);
            this.ClearButton.Margin = new System.Windows.Forms.Padding(4);
            this.ClearButton.Name = "ClearButton";
            this.ClearButton.Size = new System.Drawing.Size(124, 34);
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
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1688, 106);
            this.panel1.TabIndex = 13;
            // 
            // panel2
            // 
            this.panel2.AutoScroll = true;
            this.panel2.BackColor = System.Drawing.Color.LightGreen;
            this.panel2.Controls.Add(this.noNumbers2);
            this.panel2.Controls.Add(this.noNumbers1);
            this.panel2.Controls.Add(this.lengthWarning);
            this.panel2.Controls.Add(this.checklname);
            this.panel2.Controls.Add(this.checkfname);
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
            this.panel2.Location = new System.Drawing.Point(100, 162);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1483, 617);
            this.panel2.TabIndex = 14;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // noNumbers2
            // 
            this.noNumbers2.AutoSize = true;
            this.noNumbers2.ForeColor = System.Drawing.Color.Red;
            this.noNumbers2.Location = new System.Drawing.Point(871, 127);
            this.noNumbers2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.noNumbers2.Name = "noNumbers2";
            this.noNumbers2.Size = new System.Drawing.Size(133, 16);
            this.noNumbers2.TabIndex = 27;
            this.noNumbers2.Text = "No numbers allowed.";
            this.noNumbers2.Visible = false;
            // 
            // noNumbers1
            // 
            this.noNumbers1.AutoSize = true;
            this.noNumbers1.ForeColor = System.Drawing.Color.Red;
            this.noNumbers1.Location = new System.Drawing.Point(310, 127);
            this.noNumbers1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.noNumbers1.Name = "noNumbers1";
            this.noNumbers1.Size = new System.Drawing.Size(133, 16);
            this.noNumbers1.TabIndex = 26;
            this.noNumbers1.Text = "No numbers allowed.";
            this.noNumbers1.Visible = false;
            // 
            // lengthWarning
            // 
            this.lengthWarning.AutoSize = true;
            this.lengthWarning.ForeColor = System.Drawing.Color.Red;
            this.lengthWarning.Location = new System.Drawing.Point(310, 239);
            this.lengthWarning.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lengthWarning.Name = "lengthWarning";
            this.lengthWarning.Size = new System.Drawing.Size(271, 16);
            this.lengthWarning.TabIndex = 25;
            this.lengthWarning.Text = "Username must be at least 5 characters long";
            this.lengthWarning.Visible = false;
            // 
            // checklname
            // 
            this.checklname.AutoSize = true;
            this.checklname.ForeColor = System.Drawing.Color.Red;
            this.checklname.Location = new System.Drawing.Point(871, 127);
            this.checklname.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.checklname.Name = "checklname";
            this.checklname.Size = new System.Drawing.Size(126, 16);
            this.checklname.TabIndex = 24;
            this.checklname.Text = "No spaces allowed.";
            this.checklname.Visible = false;
            // 
            // checkfname
            // 
            this.checkfname.AutoSize = true;
            this.checkfname.ForeColor = System.Drawing.Color.Red;
            this.checkfname.Location = new System.Drawing.Point(310, 127);
            this.checkfname.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.checkfname.Name = "checkfname";
            this.checkfname.Size = new System.Drawing.Size(126, 16);
            this.checkfname.TabIndex = 23;
            this.checkfname.Text = "No spaces allowed.";
            this.checkfname.Visible = false;
            // 
            // lblPassStrength
            // 
            this.lblPassStrength.AutoSize = true;
            this.lblPassStrength.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPassStrength.ForeColor = System.Drawing.Color.DarkOrchid;
            this.lblPassStrength.Location = new System.Drawing.Point(309, 306);
            this.lblPassStrength.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPassStrength.Name = "lblPassStrength";
            this.lblPassStrength.Size = new System.Drawing.Size(178, 17);
            this.lblPassStrength.TabIndex = 22;
            this.lblPassStrength.Text = "Passwords didn\'t match";
            this.lblPassStrength.Visible = false;
            // 
            // charWarning
            // 
            this.charWarning.AutoSize = true;
            this.charWarning.ForeColor = System.Drawing.Color.Red;
            this.charWarning.Location = new System.Drawing.Point(309, 239);
            this.charWarning.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.charWarning.Name = "charWarning";
            this.charWarning.Size = new System.Drawing.Size(710, 16);
            this.charWarning.TabIndex = 21;
            this.charWarning.Text = "Username must contain only alphabets (a-z, A-Z), numbers (0-9), or underscores (_" +
    "). Special characters are not allowed.";
            this.charWarning.Visible = false;
            // 
            // usernameWarning
            // 
            this.usernameWarning.AutoSize = true;
            this.usernameWarning.ForeColor = System.Drawing.Color.Red;
            this.usernameWarning.Location = new System.Drawing.Point(309, 239);
            this.usernameWarning.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.usernameWarning.Name = "usernameWarning";
            this.usernameWarning.Size = new System.Drawing.Size(92, 16);
            this.usernameWarning.TabIndex = 20;
            this.usernameWarning.Text = "Already in use";
            this.usernameWarning.Visible = false;
            // 
            // confirmLabel
            // 
            this.confirmLabel.AutoSize = true;
            this.confirmLabel.ForeColor = System.Drawing.Color.Red;
            this.confirmLabel.Location = new System.Drawing.Point(943, 306);
            this.confirmLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.confirmLabel.Name = "confirmLabel";
            this.confirmLabel.Size = new System.Drawing.Size(148, 16);
            this.confirmLabel.TabIndex = 19;
            this.confirmLabel.Text = "Passwords didn\'t match";
            this.confirmLabel.Visible = false;
            // 
            // CheckMail
            // 
            this.CheckMail.AutoSize = true;
            this.CheckMail.ForeColor = System.Drawing.Color.Red;
            this.CheckMail.Location = new System.Drawing.Point(309, 182);
            this.CheckMail.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.CheckMail.Name = "CheckMail";
            this.CheckMail.Size = new System.Drawing.Size(165, 16);
            this.CheckMail.TabIndex = 18;
            this.CheckMail.Text = "Please enter a valid email.";
            this.CheckMail.Visible = false;
            this.CheckMail.Click += new System.EventHandler(this.label4_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(525, 474);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(288, 25);
            this.label3.TabIndex = 17;
            this.label3.Text = "Already have an account?  : ";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // ConfirmPass
            // 
            this.ConfirmPass.Location = new System.Drawing.Point(943, 273);
            this.ConfirmPass.Margin = new System.Windows.Forms.Padding(4);
            this.ConfirmPass.Name = "ConfirmPass";
            this.ConfirmPass.PasswordChar = '*';
            this.ConfirmPass.Size = new System.Drawing.Size(297, 22);
            this.ConfirmPass.TabIndex = 16;
            this.ConfirmPass.TextChanged += new System.EventHandler(this.ConfirmPass_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(691, 273);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(206, 25);
            this.label2.TabIndex = 15;
            this.label2.Text = "Confirm Password : ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(135, 210);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(138, 25);
            this.label1.TabIndex = 14;
            this.label1.Text = "User Name : ";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // LastName
            // 
            this.LastName.Location = new System.Drawing.Point(873, 101);
            this.LastName.Margin = new System.Windows.Forms.Padding(4);
            this.LastName.Name = "LastName";
            this.LastName.Size = new System.Drawing.Size(367, 22);
            this.LastName.TabIndex = 13;
            this.LastName.TextChanged += new System.EventHandler(this.LastName_TextChanged);
            // 
            // RegistrationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1685, 838);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "RegistrationForm";
            this.Text = "Registration Form";
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
        private System.Windows.Forms.Label checklname;
        private System.Windows.Forms.Label checkfname;
        private System.Windows.Forms.Label lengthWarning;
        private System.Windows.Forms.Label noNumbers1;
        private System.Windows.Forms.Label noNumbers2;
    }
}