
namespace FrameSphere.FormsUser
{
    partial class Chat
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.nameuser = new System.Windows.Forms.Label();
            this.msgpanel = new System.Windows.Forms.FlowLayoutPanel();
            this.sendbutton = new System.Windows.Forms.Button();
            this.message = new System.Windows.Forms.RichTextBox();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.ForestGreen;
            this.panel2.Controls.Add(this.nameuser);
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(600, 46);
            this.panel2.TabIndex = 1;
            // 
            // nameuser
            // 
            this.nameuser.AutoSize = true;
            this.nameuser.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameuser.Location = new System.Drawing.Point(270, 11);
            this.nameuser.Name = "nameuser";
            this.nameuser.Size = new System.Drawing.Size(66, 24);
            this.nameuser.TabIndex = 0;
            this.nameuser.Text = "label1";
            // 
            // msgpanel
            // 
            this.msgpanel.BackColor = System.Drawing.Color.LightGreen;
            this.msgpanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.msgpanel.Location = new System.Drawing.Point(0, 46);
            this.msgpanel.Name = "msgpanel";
            this.msgpanel.Size = new System.Drawing.Size(600, 543);
            this.msgpanel.TabIndex = 1;
            // 
            // sendbutton
            // 
            this.sendbutton.BackColor = System.Drawing.Color.LightGreen;
            this.sendbutton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.sendbutton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sendbutton.Location = new System.Drawing.Point(514, 618);
            this.sendbutton.Name = "sendbutton";
            this.sendbutton.Size = new System.Drawing.Size(75, 23);
            this.sendbutton.TabIndex = 5;
            this.sendbutton.Text = "Send";
            this.sendbutton.UseVisualStyleBackColor = false;
            this.sendbutton.Click += new System.EventHandler(this.sendbutton_Click_1);
            // 
            // message
            // 
            this.message.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.message.Location = new System.Drawing.Point(0, 595);
            this.message.Name = "message";
            this.message.Size = new System.Drawing.Size(600, 69);
            this.message.TabIndex = 4;
            this.message.Text = "Type your message here ";
            // 
            // Chat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(601, 663);
            this.Controls.Add(this.sendbutton);
            this.Controls.Add(this.message);
            this.Controls.Add(this.msgpanel);
            this.Controls.Add(this.panel2);
            this.Name = "Chat";
            this.Text = "Chat";
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label nameuser;
        private System.Windows.Forms.FlowLayoutPanel msgpanel;
        private System.Windows.Forms.Button sendbutton;
        private System.Windows.Forms.RichTextBox message;
    }
}