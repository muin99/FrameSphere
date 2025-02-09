
namespace FrameSphere
{
    partial class Event_page
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.addart = new System.Windows.Forms.Button();
            this.manage = new System.Windows.Forms.Button();
            this.organizer = new System.Windows.Forms.TextBox();
            this.price = new System.Windows.Forms.Label();
            this.ends = new System.Windows.Forms.Label();
            this.starts = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.description = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.title = new System.Windows.Forms.Label();
            this.cover = new System.Windows.Forms.PictureBox();
            this.imagescontainer = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cover)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Location = new System.Drawing.Point(8, 8);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1264, 681);
            this.panel1.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.LightGreen;
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.button1);
            this.panel2.Location = new System.Drawing.Point(-2, 1);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1266, 89);
            this.panel2.TabIndex = 24;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft New Tai Lue", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(516, 24);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(157, 35);
            this.label9.TabIndex = 21;
            this.label9.Text = "Event Page";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.DarkGreen;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Font = new System.Drawing.Font("Lucida Console", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button1.Location = new System.Drawing.Point(12, 30);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(195, 29);
            this.button1.TabIndex = 0;
            this.button1.Text = "Return to Dashboard";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.LightGreen;
            this.panel4.Controls.Add(this.addart);
            this.panel4.Controls.Add(this.manage);
            this.panel4.Controls.Add(this.organizer);
            this.panel4.Controls.Add(this.price);
            this.panel4.Controls.Add(this.ends);
            this.panel4.Controls.Add(this.starts);
            this.panel4.Controls.Add(this.label5);
            this.panel4.Controls.Add(this.label4);
            this.panel4.Controls.Add(this.label3);
            this.panel4.Controls.Add(this.description);
            this.panel4.Controls.Add(this.label2);
            this.panel4.Controls.Add(this.title);
            this.panel4.Controls.Add(this.cover);
            this.panel4.Location = new System.Drawing.Point(-2, 96);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1266, 153);
            this.panel4.TabIndex = 25;
            // 
            // addart
            // 
            this.addart.BackColor = System.Drawing.Color.DarkGreen;
            this.addart.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addart.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.addart.Location = new System.Drawing.Point(1072, 101);
            this.addart.Name = "addart";
            this.addart.Size = new System.Drawing.Size(148, 29);
            this.addart.TabIndex = 24;
            this.addart.Text = "Add Art";
            this.addart.UseVisualStyleBackColor = false;
            this.addart.Visible = false;
            this.addart.Click += new System.EventHandler(this.button3_Click);
            // 
            // manage
            // 
            this.manage.BackColor = System.Drawing.Color.Red;
            this.manage.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.manage.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.manage.Location = new System.Drawing.Point(1072, 10);
            this.manage.Name = "manage";
            this.manage.Size = new System.Drawing.Size(148, 29);
            this.manage.TabIndex = 23;
            this.manage.Text = "Manage ";
            this.manage.UseVisualStyleBackColor = false;
            this.manage.Click += new System.EventHandler(this.manage_Click);
            // 
            // organizer
            // 
            this.organizer.BackColor = System.Drawing.Color.LightGreen;
            this.organizer.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.organizer.Location = new System.Drawing.Point(732, 34);
            this.organizer.Multiline = true;
            this.organizer.Name = "organizer";
            this.organizer.ReadOnly = true;
            this.organizer.Size = new System.Drawing.Size(305, 87);
            this.organizer.TabIndex = 10;
            this.organizer.Text = "vfvc cvvcc  fgdf dgfrdg fdgdfgbf gh fvb vbxvcv vvcfbgfhfgbcv vb bgv bn gfh bfgnbg" +
    "f bgfbv bbvcbgh fghbgvfbgvbh cvb fghfgbhngv bhg bngfhbbvb b";
            // 
            // price
            // 
            this.price.AutoSize = true;
            this.price.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.price.ForeColor = System.Drawing.Color.Red;
            this.price.Location = new System.Drawing.Point(296, 129);
            this.price.Name = "price";
            this.price.Size = new System.Drawing.Size(42, 20);
            this.price.TabIndex = 9;
            this.price.Text = "Free";
            // 
            // ends
            // 
            this.ends.AutoSize = true;
            this.ends.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ends.Location = new System.Drawing.Point(294, 101);
            this.ends.Name = "ends";
            this.ends.Size = new System.Drawing.Size(92, 20);
            this.ends.TabIndex = 8;
            this.ends.Text = "9 Jan, 2025";
            // 
            // starts
            // 
            this.starts.AutoSize = true;
            this.starts.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.starts.Location = new System.Drawing.Point(312, 74);
            this.starts.Name = "starts";
            this.starts.Size = new System.Drawing.Size(92, 20);
            this.starts.TabIndex = 7;
            this.starts.Text = "2 Jan, 2025";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(178, 129);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(94, 20);
            this.label5.TabIndex = 6;
            this.label5.Text = "Ticket Price:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(178, 101);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 20);
            this.label4.TabIndex = 5;
            this.label4.Text = "Ending Time:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(178, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Starting Time:";
            // 
            // description
            // 
            this.description.BackColor = System.Drawing.Color.LightGreen;
            this.description.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.description.Location = new System.Drawing.Point(181, 34);
            this.description.Multiline = true;
            this.description.Name = "description";
            this.description.ReadOnly = true;
            this.description.Size = new System.Drawing.Size(420, 30);
            this.description.TabIndex = 3;
            this.description.Text = "vfvc cvvcc  fgdf dgfrdg fdgdfgbf gh fvb vbxvcv vvcfbgfhfgbcv vb bgv bn gfh bfgnbg" +
    "f bgfbv bbvcbgh fghbgvfbgvbh cvb fghfgbhngv bhg bngfhbbvb b";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(728, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 24);
            this.label2.TabIndex = 2;
            this.label2.Text = "Organizer";
            // 
            // title
            // 
            this.title.AutoSize = true;
            this.title.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.title.Location = new System.Drawing.Point(177, 7);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(366, 24);
            this.title.TabIndex = 1;
            this.title.Text = "Party at the square photography exhibition.";
            // 
            // cover
            // 
            this.cover.Location = new System.Drawing.Point(10, 10);
            this.cover.Name = "cover";
            this.cover.Size = new System.Drawing.Size(150, 133);
            this.cover.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.cover.TabIndex = 0;
            this.cover.TabStop = false;
            // 
            // imagescontainer
            // 
            this.imagescontainer.AutoScroll = true;
            this.imagescontainer.Location = new System.Drawing.Point(-1, 263);
            this.imagescontainer.Name = "imagescontainer";
            this.imagescontainer.Size = new System.Drawing.Size(1268, 426);
            this.imagescontainer.TabIndex = 26;
            // 
            // Event_page
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.imagescontainer);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Event_page";
            this.Text = "Event Page";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cover)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button manage;
        private System.Windows.Forms.TextBox organizer;
        private System.Windows.Forms.Label price;
        private System.Windows.Forms.Label ends;
        private System.Windows.Forms.Label starts;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox description;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label title;
        private System.Windows.Forms.PictureBox cover;
        private System.Windows.Forms.FlowLayoutPanel imagescontainer;
        private System.Windows.Forms.Button addart;
    }
}