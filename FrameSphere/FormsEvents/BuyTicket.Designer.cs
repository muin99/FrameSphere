namespace FrameSphere.FormsEvents
{
    partial class BuyTicket
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.TicketPageHeader_label = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.TicketPageBody_panel = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
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
            this.checkout_button = new System.Windows.Forms.Button();
            this.PaymentOption_panel = new System.Windows.Forms.Panel();
            this.amountToPay_field = new System.Windows.Forms.TextBox();
            this.amountToBePaid_label = new System.Windows.Forms.Label();
            this.VisaOption_button = new System.Windows.Forms.RadioButton();
            this.bKashOption_button = new System.Windows.Forms.RadioButton();
            this.payment_label = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.TicketPageBody_panel.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cover)).BeginInit();
            this.PaymentOption_panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.TicketPageBody_panel, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.74597F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 85.25403F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1561, 807);
            this.tableLayoutPanel1.TabIndex = 0;
            this.tableLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightGreen;
            this.panel1.Controls.Add(this.TicketPageHeader_label);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Location = new System.Drawing.Point(4, 4);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1553, 110);
            this.panel1.TabIndex = 1;
            // 
            // TicketPageHeader_label
            // 
            this.TicketPageHeader_label.AutoSize = true;
            this.TicketPageHeader_label.Font = new System.Drawing.Font("Microsoft New Tai Lue", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TicketPageHeader_label.Location = new System.Drawing.Point(667, 30);
            this.TicketPageHeader_label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.TicketPageHeader_label.Name = "TicketPageHeader_label";
            this.TicketPageHeader_label.Size = new System.Drawing.Size(201, 45);
            this.TicketPageHeader_label.TabIndex = 21;
            this.TicketPageHeader_label.Text = "Buy Tickets";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.DarkGreen;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Font = new System.Drawing.Font("Lucida Console", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button1.Location = new System.Drawing.Point(16, 37);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(260, 36);
            this.button1.TabIndex = 0;
            this.button1.Text = "Return to Dashboard";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // TicketPageBody_panel
            // 
            this.TicketPageBody_panel.BackColor = System.Drawing.Color.PaleGreen;
            this.TicketPageBody_panel.Controls.Add(this.panel4);
            this.TicketPageBody_panel.Controls.Add(this.checkout_button);
            this.TicketPageBody_panel.Controls.Add(this.PaymentOption_panel);
            this.TicketPageBody_panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TicketPageBody_panel.Location = new System.Drawing.Point(3, 121);
            this.TicketPageBody_panel.Name = "TicketPageBody_panel";
            this.TicketPageBody_panel.Size = new System.Drawing.Size(1555, 683);
            this.TicketPageBody_panel.TabIndex = 2;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.LightGreen;
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
            this.panel4.Location = new System.Drawing.Point(10, 14);
            this.panel4.Margin = new System.Windows.Forms.Padding(4);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(797, 318);
            this.panel4.TabIndex = 26;
            // 
            // organizer
            // 
            this.organizer.BackColor = System.Drawing.Color.LightGreen;
            this.organizer.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.organizer.Location = new System.Drawing.Point(16, 218);
            this.organizer.Margin = new System.Windows.Forms.Padding(4);
            this.organizer.Multiline = true;
            this.organizer.Name = "organizer";
            this.organizer.ReadOnly = true;
            this.organizer.Size = new System.Drawing.Size(515, 86);
            this.organizer.TabIndex = 10;
            this.organizer.Text = "vfvc cvvcc  fgdf dgfrdg fdgdfgbf gh fvb vbxvcv vvcfbgfhfgbcv vb bgv bn gfh bfgnbg" +
    "f bgfbv bbvcbgh fghbgvfbgvbh cvb fghfgbhngv bhg bngfhbbvb b";
            // 
            // price
            // 
            this.price.AutoSize = true;
            this.price.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.price.ForeColor = System.Drawing.Color.Red;
            this.price.Location = new System.Drawing.Point(395, 159);
            this.price.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.price.Name = "price";
            this.price.Size = new System.Drawing.Size(52, 25);
            this.price.TabIndex = 9;
            this.price.Text = "Free";
            // 
            // ends
            // 
            this.ends.AutoSize = true;
            this.ends.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ends.Location = new System.Drawing.Point(392, 124);
            this.ends.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ends.Name = "ends";
            this.ends.Size = new System.Drawing.Size(115, 25);
            this.ends.TabIndex = 8;
            this.ends.Text = "9 Jan, 2025";
            // 
            // starts
            // 
            this.starts.AutoSize = true;
            this.starts.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.starts.Location = new System.Drawing.Point(416, 91);
            this.starts.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.starts.Name = "starts";
            this.starts.Size = new System.Drawing.Size(115, 25);
            this.starts.TabIndex = 7;
            this.starts.Text = "2 Jan, 2025";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(237, 159);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(120, 25);
            this.label5.TabIndex = 6;
            this.label5.Text = "Ticket Price:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(237, 124);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(128, 25);
            this.label4.TabIndex = 5;
            this.label4.Text = "Ending Time:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(237, 91);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(134, 25);
            this.label3.TabIndex = 4;
            this.label3.Text = "Starting Time:";
            // 
            // description
            // 
            this.description.BackColor = System.Drawing.Color.LightGreen;
            this.description.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.description.Location = new System.Drawing.Point(241, 42);
            this.description.Margin = new System.Windows.Forms.Padding(4);
            this.description.Multiline = true;
            this.description.Name = "description";
            this.description.ReadOnly = true;
            this.description.Size = new System.Drawing.Size(533, 37);
            this.description.TabIndex = 3;
            this.description.Text = "vfvc cvvcc  fgdf dgfrdg fdgdfgbf gh fvb vbxvcv vvcfbgfhfgbcv vb bgv bn gfh bfgnbg" +
    "f bgfbv bbvcbgh fghbgvfbgvbh cvb fghfgbhngv bhg bngfhbbvb b";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(11, 185);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 29);
            this.label2.TabIndex = 2;
            this.label2.Text = "Organizer";
            // 
            // title
            // 
            this.title.AutoSize = true;
            this.title.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.title.Location = new System.Drawing.Point(236, 9);
            this.title.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(466, 29);
            this.title.TabIndex = 1;
            this.title.Text = "Party at the square photography exhibition.";
            // 
            // cover
            // 
            this.cover.Location = new System.Drawing.Point(13, 12);
            this.cover.Margin = new System.Windows.Forms.Padding(4);
            this.cover.Name = "cover";
            this.cover.Size = new System.Drawing.Size(200, 164);
            this.cover.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.cover.TabIndex = 0;
            this.cover.TabStop = false;
            // 
            // checkout_button
            // 
            this.checkout_button.BackColor = System.Drawing.Color.DarkGreen;
            this.checkout_button.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.checkout_button.Font = new System.Drawing.Font("Lucida Console", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkout_button.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.checkout_button.Location = new System.Drawing.Point(63, 597);
            this.checkout_button.Margin = new System.Windows.Forms.Padding(4);
            this.checkout_button.Name = "checkout_button";
            this.checkout_button.Size = new System.Drawing.Size(636, 36);
            this.checkout_button.TabIndex = 21;
            this.checkout_button.Text = "Proceed to Checkout";
            this.checkout_button.UseVisualStyleBackColor = false;
            this.checkout_button.Click += new System.EventHandler(this.checkout_button_Click);
            // 
            // PaymentOption_panel
            // 
            this.PaymentOption_panel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.PaymentOption_panel.Controls.Add(this.amountToPay_field);
            this.PaymentOption_panel.Controls.Add(this.amountToBePaid_label);
            this.PaymentOption_panel.Controls.Add(this.VisaOption_button);
            this.PaymentOption_panel.Controls.Add(this.bKashOption_button);
            this.PaymentOption_panel.Controls.Add(this.payment_label);
            this.PaymentOption_panel.Location = new System.Drawing.Point(10, 339);
            this.PaymentOption_panel.Name = "PaymentOption_panel";
            this.PaymentOption_panel.Size = new System.Drawing.Size(797, 201);
            this.PaymentOption_panel.TabIndex = 20;
            // 
            // amountToPay_field
            // 
            this.amountToPay_field.Location = new System.Drawing.Point(467, 81);
            this.amountToPay_field.Name = "amountToPay_field";
            this.amountToPay_field.ReadOnly = true;
            this.amountToPay_field.Size = new System.Drawing.Size(147, 22);
            this.amountToPay_field.TabIndex = 23;
            // 
            // amountToBePaid_label
            // 
            this.amountToBePaid_label.Font = new System.Drawing.Font("Microsoft New Tai Lue", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.amountToBePaid_label.Location = new System.Drawing.Point(462, 52);
            this.amountToBePaid_label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.amountToBePaid_label.Name = "amountToBePaid_label";
            this.amountToBePaid_label.Size = new System.Drawing.Size(227, 26);
            this.amountToBePaid_label.TabIndex = 22;
            this.amountToBePaid_label.Text = "Amount To Be Paid";
            this.amountToBePaid_label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // VisaOption_button
            // 
            this.VisaOption_button.AutoSize = true;
            this.VisaOption_button.Location = new System.Drawing.Point(84, 120);
            this.VisaOption_button.Name = "VisaOption_button";
            this.VisaOption_button.Size = new System.Drawing.Size(55, 20);
            this.VisaOption_button.TabIndex = 21;
            this.VisaOption_button.TabStop = true;
            this.VisaOption_button.Text = "Visa";
            this.VisaOption_button.UseVisualStyleBackColor = true;
            // 
            // bKashOption_button
            // 
            this.bKashOption_button.AutoSize = true;
            this.bKashOption_button.Location = new System.Drawing.Point(84, 70);
            this.bKashOption_button.Name = "bKashOption_button";
            this.bKashOption_button.Size = new System.Drawing.Size(66, 20);
            this.bKashOption_button.TabIndex = 20;
            this.bKashOption_button.TabStop = true;
            this.bKashOption_button.Text = "bKash";
            this.bKashOption_button.UseVisualStyleBackColor = true;
            // 
            // payment_label
            // 
            this.payment_label.Font = new System.Drawing.Font("Microsoft New Tai Lue", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.payment_label.Location = new System.Drawing.Point(40, 13);
            this.payment_label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.payment_label.Name = "payment_label";
            this.payment_label.Size = new System.Drawing.Size(227, 26);
            this.payment_label.TabIndex = 19;
            this.payment_label.Text = "Payment Option";
            this.payment_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BuyTicket
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1561, 807);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "BuyTicket";
            this.Text = "Buy Ticket For Event";
            this.Load += new System.EventHandler(this.BuyTicket_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.TicketPageBody_panel.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cover)).EndInit();
            this.PaymentOption_panel.ResumeLayout(false);
            this.PaymentOption_panel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label TicketPageHeader_label;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel TicketPageBody_panel;
        private System.Windows.Forms.Panel PaymentOption_panel;
        private System.Windows.Forms.Label payment_label;
        private System.Windows.Forms.RadioButton bKashOption_button;
        private System.Windows.Forms.RadioButton VisaOption_button;
        private System.Windows.Forms.Button checkout_button;
        private System.Windows.Forms.Panel panel4;
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
        private System.Windows.Forms.TextBox amountToPay_field;
        private System.Windows.Forms.Label amountToBePaid_label;
    }
}