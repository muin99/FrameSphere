
namespace FrameSphere
{
    partial class ManageEvents
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.header_panel = new System.Windows.Forms.Panel();
            this.Logout = new System.Windows.Forms.Button();
            this.ManageEvent_Title = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.body_panel = new System.Windows.Forms.Panel();
            this.manageButtons_panel = new System.Windows.Forms.Panel();
            this.visitors_button = new System.Windows.Forms.Button();
            this.artCollections_button = new System.Windows.Forms.Button();
            this.participants_button = new System.Windows.Forms.Button();
            this.currentPW_label = new System.Windows.Forms.Label();
            this.CurrentPWField = new System.Windows.Forms.TextBox();
            this.posterImage = new System.Windows.Forms.PictureBox();
            this.ticketPrice_label = new System.Windows.Forms.Label();
            this.end_label = new System.Windows.Forms.Label();
            this.organizer_label = new System.Windows.Forms.Label();
            this.registerType_label = new System.Windows.Forms.Label();
            this.eventPoster_label = new System.Windows.Forms.Label();
            this.start_label = new System.Windows.Forms.Label();
            this.eventDesc_label = new System.Windows.Forms.Label();
            this.eventTitle_label = new System.Windows.Forms.Label();
            this.update_button = new System.Windows.Forms.Button();
            this.paid = new System.Windows.Forms.RadioButton();
            this.free = new System.Windows.Forms.RadioButton();
            this.posterbtn = new System.Windows.Forms.Button();
            this.enddate = new System.Windows.Forms.DateTimePicker();
            this.startdate = new System.Windows.Forms.DateTimePicker();
            this.poster_field = new System.Windows.Forms.TextBox();
            this.ticketprice_field = new System.Windows.Forms.TextBox();
            this.OrgDetails_field = new System.Windows.Forms.TextBox();
            this.eventDesc_field = new System.Windows.Forms.TextBox();
            this.eventTitle_field = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.header_panel.SuspendLayout();
            this.body_panel.SuspendLayout();
            this.manageButtons_panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.posterImage)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.header_panel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.body_panel, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13.96181F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 86.03819F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1264, 681);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // header_panel
            // 
            this.header_panel.BackColor = System.Drawing.Color.LightGreen;
            this.header_panel.Controls.Add(this.Logout);
            this.header_panel.Controls.Add(this.ManageEvent_Title);
            this.header_panel.Controls.Add(this.button1);
            this.header_panel.Location = new System.Drawing.Point(3, 3);
            this.header_panel.Name = "header_panel";
            this.header_panel.Size = new System.Drawing.Size(1258, 89);
            this.header_panel.TabIndex = 1;
            // 
            // Logout
            // 
            this.Logout.BackColor = System.Drawing.Color.Snow;
            this.Logout.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.Logout.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.Logout.ForeColor = System.Drawing.Color.Red;
            this.Logout.Location = new System.Drawing.Point(1148, 30);
            this.Logout.Name = "Logout";
            this.Logout.Size = new System.Drawing.Size(75, 23);
            this.Logout.TabIndex = 23;
            this.Logout.Text = "Log out";
            this.Logout.UseVisualStyleBackColor = false;
            // 
            // ManageEvent_Title
            // 
            this.ManageEvent_Title.AutoSize = true;
            this.ManageEvent_Title.Font = new System.Drawing.Font("Microsoft New Tai Lue", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ManageEvent_Title.Location = new System.Drawing.Point(500, 24);
            this.ManageEvent_Title.Name = "ManageEvent_Title";
            this.ManageEvent_Title.Size = new System.Drawing.Size(197, 35);
            this.ManageEvent_Title.TabIndex = 21;
            this.ManageEvent_Title.Text = "Manage Event";
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
            // body_panel
            // 
            this.body_panel.BackColor = System.Drawing.Color.LightGreen;
            this.body_panel.Controls.Add(this.manageButtons_panel);
            this.body_panel.Controls.Add(this.currentPW_label);
            this.body_panel.Controls.Add(this.CurrentPWField);
            this.body_panel.Controls.Add(this.posterImage);
            this.body_panel.Controls.Add(this.ticketPrice_label);
            this.body_panel.Controls.Add(this.end_label);
            this.body_panel.Controls.Add(this.organizer_label);
            this.body_panel.Controls.Add(this.registerType_label);
            this.body_panel.Controls.Add(this.eventPoster_label);
            this.body_panel.Controls.Add(this.start_label);
            this.body_panel.Controls.Add(this.eventDesc_label);
            this.body_panel.Controls.Add(this.eventTitle_label);
            this.body_panel.Controls.Add(this.update_button);
            this.body_panel.Controls.Add(this.paid);
            this.body_panel.Controls.Add(this.free);
            this.body_panel.Controls.Add(this.posterbtn);
            this.body_panel.Controls.Add(this.enddate);
            this.body_panel.Controls.Add(this.startdate);
            this.body_panel.Controls.Add(this.poster_field);
            this.body_panel.Controls.Add(this.ticketprice_field);
            this.body_panel.Controls.Add(this.OrgDetails_field);
            this.body_panel.Controls.Add(this.eventDesc_field);
            this.body_panel.Controls.Add(this.eventTitle_field);
            this.body_panel.Location = new System.Drawing.Point(3, 98);
            this.body_panel.Name = "body_panel";
            this.body_panel.Size = new System.Drawing.Size(1240, 574);
            this.body_panel.TabIndex = 2;
            // 
            // manageButtons_panel
            // 
            this.manageButtons_panel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.manageButtons_panel.Controls.Add(this.visitors_button);
            this.manageButtons_panel.Controls.Add(this.artCollections_button);
            this.manageButtons_panel.Controls.Add(this.participants_button);
            this.manageButtons_panel.Location = new System.Drawing.Point(700, 40);
            this.manageButtons_panel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.manageButtons_panel.Name = "manageButtons_panel";
            this.manageButtons_panel.Size = new System.Drawing.Size(506, 248);
            this.manageButtons_panel.TabIndex = 27;
            // 
            // visitors_button
            // 
            this.visitors_button.BackColor = System.Drawing.Color.DarkGreen;
            this.visitors_button.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.visitors_button.Font = new System.Drawing.Font("Lucida Console", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.visitors_button.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.visitors_button.Location = new System.Drawing.Point(66, 143);
            this.visitors_button.Name = "visitors_button";
            this.visitors_button.Size = new System.Drawing.Size(373, 29);
            this.visitors_button.TabIndex = 6;
            this.visitors_button.Text = "Manage Visitors";
            this.visitors_button.UseVisualStyleBackColor = false;
            // 
            // artCollections_button
            // 
            this.artCollections_button.BackColor = System.Drawing.Color.DarkGreen;
            this.artCollections_button.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.artCollections_button.Font = new System.Drawing.Font("Lucida Console", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.artCollections_button.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.artCollections_button.Location = new System.Drawing.Point(66, 89);
            this.artCollections_button.Name = "artCollections_button";
            this.artCollections_button.Size = new System.Drawing.Size(373, 29);
            this.artCollections_button.TabIndex = 5;
            this.artCollections_button.Text = "Manage Art Collections";
            this.artCollections_button.UseVisualStyleBackColor = false;
            // 
            // participants_button
            // 
            this.participants_button.BackColor = System.Drawing.Color.DarkGreen;
            this.participants_button.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.participants_button.Font = new System.Drawing.Font("Lucida Console", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.participants_button.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.participants_button.Location = new System.Drawing.Point(66, 29);
            this.participants_button.Name = "participants_button";
            this.participants_button.Size = new System.Drawing.Size(373, 29);
            this.participants_button.TabIndex = 4;
            this.participants_button.Text = "Manage Participants";
            this.participants_button.UseVisualStyleBackColor = false;
            // 
            // currentPW_label
            // 
            this.currentPW_label.AutoSize = true;
            this.currentPW_label.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.currentPW_label.Location = new System.Drawing.Point(909, 320);
            this.currentPW_label.Name = "currentPW_label";
            this.currentPW_label.Size = new System.Drawing.Size(126, 19);
            this.currentPW_label.TabIndex = 26;
            this.currentPW_label.Text = "Current Password :";
            // 
            // CurrentPWField
            // 
            this.CurrentPWField.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CurrentPWField.Location = new System.Drawing.Point(1037, 320);
            this.CurrentPWField.Name = "CurrentPWField";
            this.CurrentPWField.Size = new System.Drawing.Size(168, 20);
            this.CurrentPWField.TabIndex = 25;
            // 
            // posterImage
            // 
            this.posterImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.posterImage.Location = new System.Drawing.Point(505, 421);
            this.posterImage.Name = "posterImage";
            this.posterImage.Size = new System.Drawing.Size(110, 98);
            this.posterImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.posterImage.TabIndex = 21;
            this.posterImage.TabStop = false;
            // 
            // ticketPrice_label
            // 
            this.ticketPrice_label.AutoSize = true;
            this.ticketPrice_label.Font = new System.Drawing.Font("Microsoft New Tai Lue", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ticketPrice_label.Location = new System.Drawing.Point(56, 353);
            this.ticketPrice_label.Name = "ticketPrice_label";
            this.ticketPrice_label.Size = new System.Drawing.Size(91, 21);
            this.ticketPrice_label.TabIndex = 20;
            this.ticketPrice_label.Text = "Ticket Price:";
            this.ticketPrice_label.Visible = false;
            // 
            // end_label
            // 
            this.end_label.AutoSize = true;
            this.end_label.Font = new System.Drawing.Font("Microsoft New Tai Lue", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.end_label.Location = new System.Drawing.Point(56, 202);
            this.end_label.Name = "end_label";
            this.end_label.Size = new System.Drawing.Size(63, 21);
            this.end_label.TabIndex = 19;
            this.end_label.Text = "Ends at:";
            // 
            // organizer_label
            // 
            this.organizer_label.AutoSize = true;
            this.organizer_label.Font = new System.Drawing.Font("Microsoft New Tai Lue", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.organizer_label.Location = new System.Drawing.Point(56, 247);
            this.organizer_label.Name = "organizer_label";
            this.organizer_label.Size = new System.Drawing.Size(140, 21);
            this.organizer_label.TabIndex = 18;
            this.organizer_label.Text = "Organizers Details:";
            // 
            // registerType_label
            // 
            this.registerType_label.AutoSize = true;
            this.registerType_label.Font = new System.Drawing.Font("Microsoft New Tai Lue", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.registerType_label.Location = new System.Drawing.Point(56, 322);
            this.registerType_label.Name = "registerType_label";
            this.registerType_label.Size = new System.Drawing.Size(97, 21);
            this.registerType_label.TabIndex = 17;
            this.registerType_label.Text = "Registration:";
            // 
            // eventPoster_label
            // 
            this.eventPoster_label.AutoSize = true;
            this.eventPoster_label.Font = new System.Drawing.Font("Microsoft New Tai Lue", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.eventPoster_label.Location = new System.Drawing.Point(56, 391);
            this.eventPoster_label.Name = "eventPoster_label";
            this.eventPoster_label.Size = new System.Drawing.Size(99, 21);
            this.eventPoster_label.TabIndex = 16;
            this.eventPoster_label.Text = "Event Poster:";
            // 
            // start_label
            // 
            this.start_label.AutoSize = true;
            this.start_label.Font = new System.Drawing.Font("Microsoft New Tai Lue", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.start_label.Location = new System.Drawing.Point(56, 171);
            this.start_label.Name = "start_label";
            this.start_label.Size = new System.Drawing.Size(70, 21);
            this.start_label.TabIndex = 15;
            this.start_label.Text = "Starts at:";
            // 
            // eventDesc_label
            // 
            this.eventDesc_label.AutoSize = true;
            this.eventDesc_label.Font = new System.Drawing.Font("Microsoft New Tai Lue", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.eventDesc_label.Location = new System.Drawing.Point(56, 69);
            this.eventDesc_label.Name = "eventDesc_label";
            this.eventDesc_label.Size = new System.Drawing.Size(134, 21);
            this.eventDesc_label.TabIndex = 14;
            this.eventDesc_label.Text = "Event Description:";
            // 
            // eventTitle_label
            // 
            this.eventTitle_label.AutoSize = true;
            this.eventTitle_label.Font = new System.Drawing.Font("Microsoft New Tai Lue", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.eventTitle_label.Location = new System.Drawing.Point(54, 33);
            this.eventTitle_label.Name = "eventTitle_label";
            this.eventTitle_label.Size = new System.Drawing.Size(84, 21);
            this.eventTitle_label.TabIndex = 13;
            this.eventTitle_label.Text = "Event Title:";
            // 
            // update_button
            // 
            this.update_button.BackColor = System.Drawing.Color.DarkGreen;
            this.update_button.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.update_button.Font = new System.Drawing.Font("Lucida Console", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.update_button.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.update_button.Location = new System.Drawing.Point(1037, 353);
            this.update_button.Name = "update_button";
            this.update_button.Size = new System.Drawing.Size(168, 29);
            this.update_button.TabIndex = 1;
            this.update_button.Text = "Update Event";
            this.update_button.UseVisualStyleBackColor = false;
            this.update_button.Click += new System.EventHandler(this.update_button_Click);
            // 
            // paid
            // 
            this.paid.AutoSize = true;
            this.paid.BackColor = System.Drawing.Color.White;
            this.paid.Location = new System.Drawing.Point(467, 323);
            this.paid.Name = "paid";
            this.paid.Size = new System.Drawing.Size(148, 17);
            this.paid.TabIndex = 12;
            this.paid.TabStop = true;
            this.paid.Text = "              Paid                    ";
            this.paid.UseVisualStyleBackColor = false;
            // 
            // free
            // 
            this.free.AutoSize = true;
            this.free.BackColor = System.Drawing.Color.White;
            this.free.Location = new System.Drawing.Point(255, 322);
            this.free.Name = "free";
            this.free.Size = new System.Drawing.Size(148, 17);
            this.free.TabIndex = 11;
            this.free.TabStop = true;
            this.free.Text = "              Free                    ";
            this.free.UseVisualStyleBackColor = false;
            // 
            // posterbtn
            // 
            this.posterbtn.BackColor = System.Drawing.Color.DarkGreen;
            this.posterbtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.posterbtn.Font = new System.Drawing.Font("Lucida Console", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.posterbtn.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.posterbtn.Location = new System.Drawing.Point(548, 394);
            this.posterbtn.Name = "posterbtn";
            this.posterbtn.Size = new System.Drawing.Size(67, 20);
            this.posterbtn.TabIndex = 1;
            this.posterbtn.Text = "Browse";
            this.posterbtn.UseVisualStyleBackColor = false;
            this.posterbtn.Click += new System.EventHandler(this.posterbtn_Click);
            // 
            // enddate
            // 
            this.enddate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.enddate.Location = new System.Drawing.Point(255, 202);
            this.enddate.Name = "enddate";
            this.enddate.Size = new System.Drawing.Size(362, 20);
            this.enddate.TabIndex = 9;
            // 
            // startdate
            // 
            this.startdate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.startdate.Location = new System.Drawing.Point(254, 174);
            this.startdate.Name = "startdate";
            this.startdate.Size = new System.Drawing.Size(362, 20);
            this.startdate.TabIndex = 6;
            // 
            // poster_field
            // 
            this.poster_field.Location = new System.Drawing.Point(255, 394);
            this.poster_field.Name = "poster_field";
            this.poster_field.ReadOnly = true;
            this.poster_field.Size = new System.Drawing.Size(362, 20);
            this.poster_field.TabIndex = 5;
            // 
            // ticketprice_field
            // 
            this.ticketprice_field.Location = new System.Drawing.Point(255, 353);
            this.ticketprice_field.Name = "ticketprice_field";
            this.ticketprice_field.Size = new System.Drawing.Size(362, 20);
            this.ticketprice_field.TabIndex = 4;
            this.ticketprice_field.Visible = false;
            // 
            // OrgDetails_field
            // 
            this.OrgDetails_field.Location = new System.Drawing.Point(255, 227);
            this.OrgDetails_field.Multiline = true;
            this.OrgDetails_field.Name = "OrgDetails_field";
            this.OrgDetails_field.Size = new System.Drawing.Size(362, 77);
            this.OrgDetails_field.TabIndex = 3;
            // 
            // eventDesc_field
            // 
            this.eventDesc_field.Location = new System.Drawing.Point(189, 69);
            this.eventDesc_field.Multiline = true;
            this.eventDesc_field.Name = "eventDesc_field";
            this.eventDesc_field.Size = new System.Drawing.Size(427, 79);
            this.eventDesc_field.TabIndex = 2;
            // 
            // eventTitle_field
            // 
            this.eventTitle_field.Location = new System.Drawing.Point(140, 33);
            this.eventTitle_field.Name = "eventTitle_field";
            this.eventTitle_field.Size = new System.Drawing.Size(477, 20);
            this.eventTitle_field.TabIndex = 1;
            // 
            // ManageEvents
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "ManageEvents";
            this.Text = "Manage Event";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.header_panel.ResumeLayout(false);
            this.header_panel.PerformLayout();
            this.body_panel.ResumeLayout(false);
            this.body_panel.PerformLayout();
            this.manageButtons_panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.posterImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel header_panel;
        private System.Windows.Forms.Label ManageEvent_Title;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel body_panel;
        private System.Windows.Forms.PictureBox posterImage;
        private System.Windows.Forms.Label ticketPrice_label;
        private System.Windows.Forms.Label end_label;
        private System.Windows.Forms.Label organizer_label;
        private System.Windows.Forms.Label registerType_label;
        private System.Windows.Forms.Label eventPoster_label;
        private System.Windows.Forms.Label start_label;
        private System.Windows.Forms.Label eventDesc_label;
        private System.Windows.Forms.Label eventTitle_label;
        private System.Windows.Forms.Button update_button;
        private System.Windows.Forms.RadioButton paid;
        private System.Windows.Forms.RadioButton free;
        private System.Windows.Forms.Button posterbtn;
        private System.Windows.Forms.DateTimePicker enddate;
        private System.Windows.Forms.DateTimePicker startdate;
        private System.Windows.Forms.TextBox poster_field;
        private System.Windows.Forms.TextBox ticketprice_field;
        private System.Windows.Forms.TextBox OrgDetails_field;
        private System.Windows.Forms.TextBox eventDesc_field;
        private System.Windows.Forms.TextBox eventTitle_field;
        private System.Windows.Forms.Button Logout;
        private System.Windows.Forms.Label currentPW_label;
        private System.Windows.Forms.TextBox CurrentPWField;
        private System.Windows.Forms.Panel manageButtons_panel;
        private System.Windows.Forms.Button visitors_button;
        private System.Windows.Forms.Button artCollections_button;
        private System.Windows.Forms.Button participants_button;
    }
}