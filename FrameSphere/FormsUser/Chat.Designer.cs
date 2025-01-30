
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
            this.msgpanel = new System.Windows.Forms.Panel();
            this.nameuser = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.yourmsg = new System.Windows.Forms.Label();
            this.othermsg = new System.Windows.Forms.Label();
            this.sendbutton = new System.Windows.Forms.Button();
            this.panel2.SuspendLayout();
            this.msgpanel.SuspendLayout();
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
            // msgpanel
            // 
            this.msgpanel.BackColor = System.Drawing.Color.LightGreen;
            this.msgpanel.Controls.Add(this.sendbutton);
            this.msgpanel.Controls.Add(this.othermsg);
            this.msgpanel.Controls.Add(this.yourmsg);
            this.msgpanel.Controls.Add(this.richTextBox1);
            this.msgpanel.Location = new System.Drawing.Point(0, 46);
            this.msgpanel.Name = "msgpanel";
            this.msgpanel.Size = new System.Drawing.Size(600, 616);
            this.msgpanel.TabIndex = 1;
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
            // richTextBox1
            // 
            this.richTextBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox1.Location = new System.Drawing.Point(0, 546);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(600, 69);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "Type your message here ";
            // 
            // yourmsg
            // 
            this.yourmsg.AutoSize = true;
            this.yourmsg.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.yourmsg.Location = new System.Drawing.Point(477, 48);
            this.yourmsg.Name = "yourmsg";
            this.yourmsg.Size = new System.Drawing.Size(96, 24);
            this.yourmsg.TabIndex = 1;
            this.yourmsg.Text = "your msg";
            // 
            // othermsg
            // 
            this.othermsg.AutoSize = true;
            this.othermsg.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.othermsg.Location = new System.Drawing.Point(21, 95);
            this.othermsg.Name = "othermsg";
            this.othermsg.Size = new System.Drawing.Size(103, 24);
            this.othermsg.TabIndex = 2;
            this.othermsg.Text = "other msg";
            // 
            // sendbutton
            // 
            this.sendbutton.BackColor = System.Drawing.Color.LightGreen;
            this.sendbutton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.sendbutton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sendbutton.Location = new System.Drawing.Point(498, 571);
            this.sendbutton.Name = "sendbutton";
            this.sendbutton.Size = new System.Drawing.Size(75, 23);
            this.sendbutton.TabIndex = 3;
            this.sendbutton.Text = "Send";
            this.sendbutton.UseVisualStyleBackColor = false;
            // 
            // Chat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(601, 663);
            this.Controls.Add(this.msgpanel);
            this.Controls.Add(this.panel2);
            this.Name = "Chat";
            this.Text = "Chat";
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.msgpanel.ResumeLayout(false);
            this.msgpanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label nameuser;
        private System.Windows.Forms.Panel msgpanel;
        private System.Windows.Forms.Label othermsg;
        private System.Windows.Forms.Label yourmsg;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button sendbutton;
    }
}