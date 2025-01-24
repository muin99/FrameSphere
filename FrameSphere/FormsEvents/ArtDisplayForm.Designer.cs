namespace FrameSphere
{
    partial class ArtDisplayForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ArtDisplayForm));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.profilepanel = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button14 = new System.Windows.Forms.Button();
            this.address = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.email = new System.Windows.Forms.Label();
            this.phone = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.contact = new System.Windows.Forms.Label();
            this.userName = new System.Windows.Forms.Label();
            this.name = new System.Windows.Forms.Label();
            this.profilepic = new System.Windows.Forms.PictureBox();
            this.ArtImage = new System.Windows.Forms.PictureBox();
            this.website_link = new System.Windows.Forms.PictureBox();
            this.pinterest_link = new System.Windows.Forms.PictureBox();
            this.instagram_link = new System.Windows.Forms.PictureBox();
            this.facebook_pic = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.profilepanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.profilepic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ArtImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.website_link)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pinterest_link)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.instagram_link)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.facebook_pic)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.Controls.Add(this.panel4, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.ArtImage, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1133, 601);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.LightGreen;
            this.panel4.Controls.Add(this.profilepanel);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(683, 4);
            this.panel4.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(446, 593);
            this.panel4.TabIndex = 4;
            // 
            // profilepanel
            // 
            this.profilepanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.profilepanel.Controls.Add(this.website_link);
            this.profilepanel.Controls.Add(this.pinterest_link);
            this.profilepanel.Controls.Add(this.instagram_link);
            this.profilepanel.Controls.Add(this.facebook_pic);
            this.profilepanel.Controls.Add(this.label4);
            this.profilepanel.Controls.Add(this.pictureBox1);
            this.profilepanel.Controls.Add(this.button14);
            this.profilepanel.Controls.Add(this.address);
            this.profilepanel.Controls.Add(this.label8);
            this.profilepanel.Controls.Add(this.email);
            this.profilepanel.Controls.Add(this.phone);
            this.profilepanel.Controls.Add(this.label3);
            this.profilepanel.Controls.Add(this.label2);
            this.profilepanel.Controls.Add(this.contact);
            this.profilepanel.Controls.Add(this.userName);
            this.profilepanel.Controls.Add(this.name);
            this.profilepanel.Controls.Add(this.profilepic);
            this.profilepanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.profilepanel.Location = new System.Drawing.Point(0, 0);
            this.profilepanel.Margin = new System.Windows.Forms.Padding(13, 12, 13, 12);
            this.profilepanel.Name = "profilepanel";
            this.profilepanel.Size = new System.Drawing.Size(446, 593);
            this.profilepanel.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::FrameSphere.Properties.Resources.cross;
            this.pictureBox1.Location = new System.Drawing.Point(403, 7);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(36, 37);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 12;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // button14
            // 
            this.button14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button14.BackColor = System.Drawing.Color.Lime;
            this.button14.Location = new System.Drawing.Point(166, 58);
            this.button14.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button14.Name = "button14";
            this.button14.Size = new System.Drawing.Size(100, 28);
            this.button14.TabIndex = 11;
            this.button14.Text = "Edit Profile";
            this.button14.UseVisualStyleBackColor = false;
            // 
            // address
            // 
            this.address.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.address.Location = new System.Drawing.Point(29, 383);
            this.address.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.address.Name = "address";
            this.address.Size = new System.Drawing.Size(159, 59);
            this.address.TabIndex = 9;
            this.address.Text = "Bashundhara RA\r\nPO-1209, Dhaka\r\n";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(19, 362);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(68, 17);
            this.label8.TabIndex = 8;
            this.label8.Text = "Contact:";
            // 
            // email
            // 
            this.email.AutoSize = true;
            this.email.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.email.Location = new System.Drawing.Point(77, 330);
            this.email.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.email.Name = "email";
            this.email.Size = new System.Drawing.Size(131, 17);
            this.email.TabIndex = 7;
            this.email.Text = "56muin@gmail.com";
            // 
            // phone
            // 
            this.phone.AutoSize = true;
            this.phone.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.phone.Location = new System.Drawing.Point(88, 309);
            this.phone.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.phone.Name = "phone";
            this.phone.Size = new System.Drawing.Size(120, 17);
            this.phone.TabIndex = 6;
            this.phone.Text = "+8801400059919";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(29, 330);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "Email:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(29, 309);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Phone:";
            // 
            // contact
            // 
            this.contact.AutoSize = true;
            this.contact.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.contact.Location = new System.Drawing.Point(19, 288);
            this.contact.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.contact.Name = "contact";
            this.contact.Size = new System.Drawing.Size(68, 17);
            this.contact.TabIndex = 3;
            this.contact.Text = "Contact:";
            // 
            // userName
            // 
            this.userName.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.userName.Location = new System.Drawing.Point(152, 245);
            this.userName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.userName.Name = "userName";
            this.userName.Size = new System.Drawing.Size(133, 16);
            this.userName.TabIndex = 2;
            this.userName.Text = "@onukrom";
            this.userName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // name
            // 
            this.name.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.name.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.name.Location = new System.Drawing.Point(108, 226);
            this.name.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(221, 18);
            this.name.TabIndex = 1;
            this.name.Text = "Md. Muinul Islam";
            this.name.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // profilepic
            // 
            this.profilepic.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.profilepic.Image = global::FrameSphere.Properties.Resources.SmallerNetworkConnectionBackgroundtest_ezgif_com_video_to_gif_converter;
            this.profilepic.Location = new System.Drawing.Point(152, 92);
            this.profilepic.Margin = new System.Windows.Forms.Padding(27, 25, 27, 25);
            this.profilepic.Name = "profilepic";
            this.profilepic.Size = new System.Drawing.Size(133, 128);
            this.profilepic.TabIndex = 0;
            this.profilepic.TabStop = false;
            // 
            // ArtImage
            // 
            this.ArtImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ArtImage.Image = global::FrameSphere.Properties.Resources.SmallerNetworkConnectionBackgroundtest_ezgif_com_video_to_gif_converter;
            this.ArtImage.Location = new System.Drawing.Point(3, 2);
            this.ArtImage.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ArtImage.Name = "ArtImage";
            this.ArtImage.Size = new System.Drawing.Size(673, 597);
            this.ArtImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ArtImage.TabIndex = 0;
            this.ArtImage.TabStop = false;
            // 
            // website_link
            // 
            this.website_link.Image = ((System.Drawing.Image)(resources.GetObject("website_link.Image")));
            this.website_link.Location = new System.Drawing.Point(273, 488);
            this.website_link.Name = "website_link";
            this.website_link.Size = new System.Drawing.Size(40, 37);
            this.website_link.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.website_link.TabIndex = 20;
            this.website_link.TabStop = false;
            // 
            // pinterest_link
            // 
            this.pinterest_link.Image = ((System.Drawing.Image)(resources.GetObject("pinterest_link.Image")));
            this.pinterest_link.Location = new System.Drawing.Point(215, 488);
            this.pinterest_link.Name = "pinterest_link";
            this.pinterest_link.Size = new System.Drawing.Size(40, 37);
            this.pinterest_link.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pinterest_link.TabIndex = 19;
            this.pinterest_link.TabStop = false;
            // 
            // instagram_link
            // 
            this.instagram_link.Image = ((System.Drawing.Image)(resources.GetObject("instagram_link.Image")));
            this.instagram_link.Location = new System.Drawing.Point(160, 488);
            this.instagram_link.Name = "instagram_link";
            this.instagram_link.Size = new System.Drawing.Size(40, 37);
            this.instagram_link.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.instagram_link.TabIndex = 18;
            this.instagram_link.TabStop = false;
            // 
            // facebook_pic
            // 
            this.facebook_pic.Image = ((System.Drawing.Image)(resources.GetObject("facebook_pic.Image")));
            this.facebook_pic.Location = new System.Drawing.Point(102, 488);
            this.facebook_pic.Name = "facebook_pic";
            this.facebook_pic.Size = new System.Drawing.Size(40, 37);
            this.facebook_pic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.facebook_pic.TabIndex = 17;
            this.facebook_pic.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(31, 498);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 17);
            this.label4.TabIndex = 16;
            this.label4.Text = "Socials:";
            // 
            // ArtDisplayForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1133, 601);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "ArtDisplayForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.profilepanel.ResumeLayout(false);
            this.profilepanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.profilepic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ArtImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.website_link)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pinterest_link)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.instagram_link)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.facebook_pic)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.PictureBox ArtImage;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel profilepanel;
        private System.Windows.Forms.Button button14;
        private System.Windows.Forms.Label address;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label email;
        private System.Windows.Forms.Label phone;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label contact;
        private System.Windows.Forms.Label userName;
        private System.Windows.Forms.Label name;
        private System.Windows.Forms.PictureBox profilepic;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox website_link;
        private System.Windows.Forms.PictureBox pinterest_link;
        private System.Windows.Forms.PictureBox instagram_link;
        private System.Windows.Forms.PictureBox facebook_pic;
        private System.Windows.Forms.Label label4;
    }
}