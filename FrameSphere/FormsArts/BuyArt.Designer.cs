namespace FrameSphere.FormsArts
{
    partial class BuyArt
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
            this.amountToPay_field = new System.Windows.Forms.TextBox();
            this.amountToBePaid_label = new System.Windows.Forms.Label();
            this.VisaOption_button = new System.Windows.Forms.RadioButton();
            this.payment_label = new System.Windows.Forms.Label();
            this.checkout_button = new System.Windows.Forms.Button();
            this.PaymentOption_panel = new System.Windows.Forms.Panel();
            this.bKashOption_button = new System.Windows.Forms.RadioButton();
            this.ArtTitle = new System.Windows.Forms.Label();
            this.ArtPhoto = new System.Windows.Forms.PictureBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.TicketPageBody_panel = new System.Windows.Forms.Panel();
            this.TicketPageHeader_label = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.PaymentOption_panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ArtPhoto)).BeginInit();
            this.panel4.SuspendLayout();
            this.TicketPageBody_panel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // amountToPay_field
            // 
            this.amountToPay_field.Location = new System.Drawing.Point(350, 66);
            this.amountToPay_field.Margin = new System.Windows.Forms.Padding(2);
            this.amountToPay_field.Name = "amountToPay_field";
            this.amountToPay_field.ReadOnly = true;
            this.amountToPay_field.Size = new System.Drawing.Size(111, 20);
            this.amountToPay_field.TabIndex = 23;
            // 
            // amountToBePaid_label
            // 
            this.amountToBePaid_label.Font = new System.Drawing.Font("Microsoft New Tai Lue", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.amountToBePaid_label.Location = new System.Drawing.Point(346, 42);
            this.amountToBePaid_label.Name = "amountToBePaid_label";
            this.amountToBePaid_label.Size = new System.Drawing.Size(170, 21);
            this.amountToBePaid_label.TabIndex = 22;
            this.amountToBePaid_label.Text = "Amount To Be Paid";
            this.amountToBePaid_label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // VisaOption_button
            // 
            this.VisaOption_button.AutoSize = true;
            this.VisaOption_button.Location = new System.Drawing.Point(63, 98);
            this.VisaOption_button.Margin = new System.Windows.Forms.Padding(2);
            this.VisaOption_button.Name = "VisaOption_button";
            this.VisaOption_button.Size = new System.Drawing.Size(45, 17);
            this.VisaOption_button.TabIndex = 21;
            this.VisaOption_button.TabStop = true;
            this.VisaOption_button.Text = "Visa";
            this.VisaOption_button.UseVisualStyleBackColor = true;
            // 
            // payment_label
            // 
            this.payment_label.Font = new System.Drawing.Font("Microsoft New Tai Lue", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.payment_label.Location = new System.Drawing.Point(30, 11);
            this.payment_label.Name = "payment_label";
            this.payment_label.Size = new System.Drawing.Size(170, 21);
            this.payment_label.TabIndex = 19;
            this.payment_label.Text = "Payment Option";
            this.payment_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // checkout_button
            // 
            this.checkout_button.BackColor = System.Drawing.Color.DarkGreen;
            this.checkout_button.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.checkout_button.Font = new System.Drawing.Font("Lucida Console", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkout_button.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.checkout_button.Location = new System.Drawing.Point(47, 485);
            this.checkout_button.Name = "checkout_button";
            this.checkout_button.Size = new System.Drawing.Size(477, 29);
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
            this.PaymentOption_panel.Location = new System.Drawing.Point(8, 275);
            this.PaymentOption_panel.Margin = new System.Windows.Forms.Padding(2);
            this.PaymentOption_panel.Name = "PaymentOption_panel";
            this.PaymentOption_panel.Size = new System.Drawing.Size(598, 163);
            this.PaymentOption_panel.TabIndex = 20;
            // 
            // bKashOption_button
            // 
            this.bKashOption_button.AutoSize = true;
            this.bKashOption_button.Location = new System.Drawing.Point(63, 57);
            this.bKashOption_button.Margin = new System.Windows.Forms.Padding(2);
            this.bKashOption_button.Name = "bKashOption_button";
            this.bKashOption_button.Size = new System.Drawing.Size(55, 17);
            this.bKashOption_button.TabIndex = 20;
            this.bKashOption_button.TabStop = true;
            this.bKashOption_button.Text = "bKash";
            this.bKashOption_button.UseVisualStyleBackColor = true;
            // 
            // ArtTitle
            // 
            this.ArtTitle.AutoSize = true;
            this.ArtTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ArtTitle.Location = new System.Drawing.Point(262, 24);
            this.ArtTitle.Name = "ArtTitle";
            this.ArtTitle.Size = new System.Drawing.Size(366, 24);
            this.ArtTitle.TabIndex = 1;
            this.ArtTitle.Text = "Party at the square photography exhibition.";
            // 
            // ArtPhoto
            // 
            this.ArtPhoto.Location = new System.Drawing.Point(5, 7);
            this.ArtPhoto.Name = "ArtPhoto";
            this.ArtPhoto.Size = new System.Drawing.Size(238, 248);
            this.ArtPhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ArtPhoto.TabIndex = 0;
            this.ArtPhoto.TabStop = false;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.LightGreen;
            this.panel4.Controls.Add(this.ArtTitle);
            this.panel4.Controls.Add(this.ArtPhoto);
            this.panel4.Location = new System.Drawing.Point(8, 11);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(781, 258);
            this.panel4.TabIndex = 26;
            // 
            // TicketPageBody_panel
            // 
            this.TicketPageBody_panel.BackColor = System.Drawing.Color.PaleGreen;
            this.TicketPageBody_panel.Controls.Add(this.panel4);
            this.TicketPageBody_panel.Controls.Add(this.checkout_button);
            this.TicketPageBody_panel.Controls.Add(this.PaymentOption_panel);
            this.TicketPageBody_panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TicketPageBody_panel.Location = new System.Drawing.Point(2, 99);
            this.TicketPageBody_panel.Margin = new System.Windows.Forms.Padding(2);
            this.TicketPageBody_panel.Name = "TicketPageBody_panel";
            this.TicketPageBody_panel.Size = new System.Drawing.Size(1160, 562);
            this.TicketPageBody_panel.TabIndex = 2;
            // 
            // TicketPageHeader_label
            // 
            this.TicketPageHeader_label.AutoSize = true;
            this.TicketPageHeader_label.Font = new System.Drawing.Font("Microsoft New Tai Lue", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TicketPageHeader_label.Location = new System.Drawing.Point(500, 24);
            this.TicketPageHeader_label.Name = "TicketPageHeader_label";
            this.TicketPageHeader_label.Size = new System.Drawing.Size(111, 35);
            this.TicketPageHeader_label.TabIndex = 21;
            this.TicketPageHeader_label.Text = "Buy Art";
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
            this.button1.Click += new System.EventHandler(this.returnToDashboard_button_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightGreen;
            this.panel1.Controls.Add(this.TicketPageHeader_label);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1158, 89);
            this.panel1.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.TicketPageBody_panel, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.74597F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 85.25403F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1164, 663);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // BuyArt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1164, 663);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "BuyArt";
            this.Text = "BuyArt";
            this.PaymentOption_panel.ResumeLayout(false);
            this.PaymentOption_panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ArtPhoto)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.TicketPageBody_panel.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox amountToPay_field;
        private System.Windows.Forms.Label amountToBePaid_label;
        private System.Windows.Forms.RadioButton VisaOption_button;
        private System.Windows.Forms.Label payment_label;
        private System.Windows.Forms.Button checkout_button;
        private System.Windows.Forms.Panel PaymentOption_panel;
        private System.Windows.Forms.RadioButton bKashOption_button;
        private System.Windows.Forms.Label ArtTitle;
        private System.Windows.Forms.PictureBox ArtPhoto;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel TicketPageBody_panel;
        private System.Windows.Forms.Label TicketPageHeader_label;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}