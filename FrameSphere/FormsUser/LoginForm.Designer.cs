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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            this.WelcomeLabel = new System.Windows.Forms.Label();
            this.UserIdLabel = new System.Windows.Forms.Label();
            this.UserId = new System.Windows.Forms.TextBox();
            this.PasswordLabel = new System.Windows.Forms.Label();
            this.Password = new System.Windows.Forms.TextBox();
            this.LoginButton = new System.Windows.Forms.Button();
            this.RegisterButton = new System.Windows.Forms.Button();
            this.AccountLabel = new System.Windows.Forms.Label();
            this.useridwar = new System.Windows.Forms.Label();
            this.passwordWarning = new System.Windows.Forms.Label();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // WelcomeLabel
            // 
            resources.ApplyResources(this.WelcomeLabel, "WelcomeLabel");
            this.WelcomeLabel.BackColor = System.Drawing.Color.Transparent;
            this.WelcomeLabel.ForeColor = System.Drawing.Color.DarkBlue;
            this.WelcomeLabel.Name = "WelcomeLabel";
            this.WelcomeLabel.Click += new System.EventHandler(this.label1_Click);
            // 
            // UserIdLabel
            // 
            resources.ApplyResources(this.UserIdLabel, "UserIdLabel");
            this.UserIdLabel.Name = "UserIdLabel";
            this.UserIdLabel.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // UserId
            // 
            resources.ApplyResources(this.UserId, "UserId");
            this.UserId.Name = "UserId";
            this.UserId.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // PasswordLabel
            // 
            resources.ApplyResources(this.PasswordLabel, "PasswordLabel");
            this.PasswordLabel.Name = "PasswordLabel";
            // 
            // Password
            // 
            resources.ApplyResources(this.Password, "Password");
            this.Password.Name = "Password";
            // 
            // LoginButton
            // 
            resources.ApplyResources(this.LoginButton, "LoginButton");
            this.LoginButton.Name = "LoginButton";
            this.LoginButton.UseVisualStyleBackColor = true;
            this.LoginButton.Click += new System.EventHandler(this.LoginButton_Click);
            // 
            // RegisterButton
            // 
            resources.ApplyResources(this.RegisterButton, "RegisterButton");
            this.RegisterButton.Name = "RegisterButton";
            this.RegisterButton.UseVisualStyleBackColor = true;
            this.RegisterButton.Click += new System.EventHandler(this.RegisterButton_Click);
            // 
            // AccountLabel
            // 
            resources.ApplyResources(this.AccountLabel, "AccountLabel");
            this.AccountLabel.Name = "AccountLabel";
            this.AccountLabel.Click += new System.EventHandler(this.AccountLabel_Click);
            // 
            // useridwar
            // 
            resources.ApplyResources(this.useridwar, "useridwar");
            this.useridwar.ForeColor = System.Drawing.Color.Red;
            this.useridwar.Name = "useridwar";
            this.useridwar.Click += new System.EventHandler(this.label1_Click_2);
            // 
            // passwordWarning
            // 
            resources.ApplyResources(this.passwordWarning, "passwordWarning");
            this.passwordWarning.ForeColor = System.Drawing.Color.Red;
            this.passwordWarning.Name = "passwordWarning";
            // 
            // linkLabel1
            // 
            resources.ApplyResources(this.linkLabel1, "linkLabel1");
            this.linkLabel1.LinkColor = System.Drawing.Color.Indigo;
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.TabStop = true;
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked_1);
            // 
            // LoginForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGreen;
            this.Controls.Add(this.linkLabel1);
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
        private System.Windows.Forms.LinkLabel linkLabel1;
    }
}

