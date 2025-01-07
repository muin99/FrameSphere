namespace FrameSphere
{
    partial class LoginForm
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
            this.components = new System.ComponentModel.Container();
            this.WelcomeLabel = new System.Windows.Forms.Label();
            this.UserIdLabel = new System.Windows.Forms.Label();
            this.UserId = new System.Windows.Forms.TextBox();
            this.PasswordLabel = new System.Windows.Forms.Label();
            this.Password = new System.Windows.Forms.TextBox();
            this.LoginButton = new System.Windows.Forms.Button();
            this.RegisterButton = new System.Windows.Forms.Button();
            this.AccountLabel = new System.Windows.Forms.Label();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.useridwar = new System.Windows.Forms.Label();
            this.passwordWarning = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // WelcomeLabel
            // 
            this.WelcomeLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.WelcomeLabel.AutoSize = true;
            this.WelcomeLabel.BackColor = System.Drawing.Color.Transparent;
            this.WelcomeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WelcomeLabel.ForeColor = System.Drawing.Color.DarkBlue;
            this.WelcomeLabel.Location = new System.Drawing.Point(352, 53);
            this.WelcomeLabel.Name = "WelcomeLabel";
            this.WelcomeLabel.Size = new System.Drawing.Size(328, 29);
            this.WelcomeLabel.TabIndex = 0;
            this.WelcomeLabel.Text = "Welcome To FrameSphere";
            this.WelcomeLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.WelcomeLabel.Click += new System.EventHandler(this.label1_Click);
            // 
            // UserIdLabel
            // 
            this.UserIdLabel.AutoSize = true;
            this.UserIdLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UserIdLabel.Location = new System.Drawing.Point(199, 158);
            this.UserIdLabel.Name = "UserIdLabel";
            this.UserIdLabel.Size = new System.Drawing.Size(161, 20);
            this.UserIdLabel.TabIndex = 1;
            this.UserIdLabel.Text = "User ID or Email:   ";
            this.UserIdLabel.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // UserId
            // 
            this.UserId.Location = new System.Drawing.Point(357, 158);
            this.UserId.Name = "UserId";
            this.UserId.Size = new System.Drawing.Size(278, 20);
            this.UserId.TabIndex = 2;
            this.UserId.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // PasswordLabel
            // 
            this.PasswordLabel.AutoSize = true;
            this.PasswordLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PasswordLabel.Location = new System.Drawing.Point(248, 211);
            this.PasswordLabel.Name = "PasswordLabel";
            this.PasswordLabel.Size = new System.Drawing.Size(101, 20);
            this.PasswordLabel.TabIndex = 3;
            this.PasswordLabel.Text = "Password : ";
            // 
            // Password
            // 
            this.Password.Location = new System.Drawing.Point(357, 211);
            this.Password.Name = "Password";
            this.Password.PasswordChar = '*';
            this.Password.Size = new System.Drawing.Size(278, 20);
            this.Password.TabIndex = 4;
            // 
            // LoginButton
            // 
            this.LoginButton.Location = new System.Drawing.Point(549, 249);
            this.LoginButton.Name = "LoginButton";
            this.LoginButton.Size = new System.Drawing.Size(86, 22);
            this.LoginButton.TabIndex = 5;
            this.LoginButton.Text = "Log in";
            this.LoginButton.UseVisualStyleBackColor = true;
            this.LoginButton.Click += new System.EventHandler(this.LoginButton_Click);
            // 
            // RegisterButton
            // 
            this.RegisterButton.Location = new System.Drawing.Point(410, 248);
            this.RegisterButton.Name = "RegisterButton";
            this.RegisterButton.Size = new System.Drawing.Size(115, 23);
            this.RegisterButton.TabIndex = 6;
            this.RegisterButton.Text = "Register Now";
            this.RegisterButton.UseVisualStyleBackColor = true;
            this.RegisterButton.Click += new System.EventHandler(this.RegisterButton_Click);
            // 
            // AccountLabel
            // 
            this.AccountLabel.AutoSize = true;
            this.AccountLabel.Location = new System.Drawing.Point(413, 274);
            this.AccountLabel.Name = "AccountLabel";
            this.AccountLabel.Size = new System.Drawing.Size(124, 13);
            this.AccountLabel.TabIndex = 7;
            this.AccountLabel.Text = "Don\'t Have an account?";
            this.AccountLabel.Click += new System.EventHandler(this.AccountLabel_Click);
            // 
            // useridwar
            // 
            this.useridwar.AutoSize = true;
            this.useridwar.ForeColor = System.Drawing.Color.Red;
            this.useridwar.Location = new System.Drawing.Point(354, 181);
            this.useridwar.Name = "useridwar";
            this.useridwar.Size = new System.Drawing.Size(163, 13);
            this.useridwar.TabIndex = 8;
            this.useridwar.Text = "Please enter a username or email";
            this.useridwar.Visible = false;
            this.useridwar.Click += new System.EventHandler(this.label1_Click_2);
            // 
            // passwordWarning
            // 
            this.passwordWarning.AutoSize = true;
            this.passwordWarning.ForeColor = System.Drawing.Color.Red;
            this.passwordWarning.Location = new System.Drawing.Point(354, 232);
            this.passwordWarning.Name = "passwordWarning";
            this.passwordWarning.Size = new System.Drawing.Size(123, 13);
            this.passwordWarning.TabIndex = 9;
            this.passwordWarning.Text = "Please enter a password";
            this.passwordWarning.Visible = false;
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(959, 492);
            this.Controls.Add(this.passwordWarning);
            this.Controls.Add(this.useridwar);
            this.Controls.Add(this.AccountLabel);
            this.Controls.Add(this.RegisterButton);
            this.Controls.Add(this.LoginButton);
            this.Controls.Add(this.Password);
            this.Controls.Add(this.PasswordLabel);
            this.Controls.Add(this.UserId);
            this.Controls.Add(this.UserIdLabel);
            this.Controls.Add(this.WelcomeLabel);
            this.Name = "LoginForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.LoginForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label WelcomeLabel;
        private System.Windows.Forms.Label UserIdLabel;
        private System.Windows.Forms.TextBox UserId;
        private System.Windows.Forms.Label PasswordLabel;
        private System.Windows.Forms.TextBox Password;
        private System.Windows.Forms.Button LoginButton;
        private System.Windows.Forms.Button RegisterButton;
        private System.Windows.Forms.Label AccountLabel;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.Label useridwar;
        private System.Windows.Forms.Label passwordWarning;
    }
}

