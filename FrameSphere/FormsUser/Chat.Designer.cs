namespace FrameSphere.FormsUser
{
    partial class Chat
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label nameuser;
        private System.Windows.Forms.FlowLayoutPanel msgpanel;
        private System.Windows.Forms.Button sendbutton;
        private System.Windows.Forms.RichTextBox message;
        private System.Windows.Forms.Panel recentUsersPanel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.panel2 = new System.Windows.Forms.Panel();
            this.nameuser = new System.Windows.Forms.Label();
            this.msgpanel = new System.Windows.Forms.FlowLayoutPanel();
            this.sendbutton = new System.Windows.Forms.Button();
            this.message = new System.Windows.Forms.RichTextBox();
            this.recentUsersPanel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.ForestGreen;
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.nameuser);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(800, 50);
            this.panel2.TabIndex = 4;
            // 
            // nameuser
            // 
            this.nameuser.AutoSize = true;
            this.nameuser.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold);
            this.nameuser.Location = new System.Drawing.Point(350, 13);
            this.nameuser.Name = "nameuser";
            this.nameuser.Size = new System.Drawing.Size(0, 24);
            this.nameuser.TabIndex = 0;
            // 
            // msgpanel
            // 
            this.msgpanel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.msgpanel.AutoScroll = true;
            this.msgpanel.BackColor = System.Drawing.Color.LightGreen;
            this.msgpanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.msgpanel.Location = new System.Drawing.Point(200, 50);
            this.msgpanel.Name = "msgpanel";
            this.msgpanel.Padding = new System.Windows.Forms.Padding(50, 50, 50, 60);
            this.msgpanel.Size = new System.Drawing.Size(600, 514);
            this.msgpanel.TabIndex = 2;
            this.msgpanel.WrapContents = false;
            // 
            // sendbutton
            // 
            this.sendbutton.BackColor = System.Drawing.Color.LightGreen;
            this.sendbutton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.sendbutton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.sendbutton.Location = new System.Drawing.Point(720, 570);
            this.sendbutton.Name = "sendbutton";
            this.sendbutton.Size = new System.Drawing.Size(75, 30);
            this.sendbutton.TabIndex = 0;
            this.sendbutton.Text = "Send";
            this.sendbutton.UseVisualStyleBackColor = false;
            this.sendbutton.Click += new System.EventHandler(this.sendbutton_Click_1);
            // 
            // message
            // 
            this.message.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.message.Location = new System.Drawing.Point(200, 570);
            this.message.Name = "message";
            this.message.Size = new System.Drawing.Size(500, 30);
            this.message.TabIndex = 1;
            this.message.Text = "";
            // 
            // recentUsersPanel
            // 
            this.recentUsersPanel.AutoScroll = true;
            this.recentUsersPanel.BackColor = System.Drawing.Color.LightGray;
            this.recentUsersPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.recentUsersPanel.Location = new System.Drawing.Point(0, 50);
            this.recentUsersPanel.Name = "recentUsersPanel";
            this.recentUsersPanel.Size = new System.Drawing.Size(200, 550);
            this.recentUsersPanel.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(365, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Chat Box";
            // 
            // Chat
            // 
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.sendbutton);
            this.Controls.Add(this.message);
            this.Controls.Add(this.msgpanel);
            this.Controls.Add(this.recentUsersPanel);
            this.Controls.Add(this.panel2);
            this.Name = "Chat";
            this.Text = "Chat";
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Label label1;
    }
}
