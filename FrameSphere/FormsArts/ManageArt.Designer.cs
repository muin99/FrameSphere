
namespace FrameSphere
{
    partial class ManageArt
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
            this.midpanel = new System.Windows.Forms.Panel();
            this.goBack = new System.Windows.Forms.Button();
            this.Submit = new System.Windows.Forms.Button();
            this.paid = new System.Windows.Forms.RadioButton();
            this.free = new System.Windows.Forms.RadioButton();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.artPrice = new System.Windows.Forms.TextBox();
            this.Description = new System.Windows.Forms.TextBox();
            this.arttitle = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.artContainer = new System.Windows.Forms.FlowLayoutPanel();
            this.artPanel = new System.Windows.Forms.Panel();
            this.add = new System.Windows.Forms.Button();
            this.deleteArt = new System.Windows.Forms.Button();
            this.midpanel.SuspendLayout();
            this.artContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // midpanel
            // 
            this.midpanel.AutoScroll = true;
            this.midpanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.midpanel.Controls.Add(this.deleteArt);
            this.midpanel.Controls.Add(this.goBack);
            this.midpanel.Controls.Add(this.Submit);
            this.midpanel.Controls.Add(this.paid);
            this.midpanel.Controls.Add(this.free);
            this.midpanel.Controls.Add(this.label10);
            this.midpanel.Controls.Add(this.label9);
            this.midpanel.Controls.Add(this.label6);
            this.midpanel.Controls.Add(this.label7);
            this.midpanel.Controls.Add(this.artPrice);
            this.midpanel.Controls.Add(this.Description);
            this.midpanel.Controls.Add(this.arttitle);
            this.midpanel.Controls.Add(this.label5);
            this.midpanel.Controls.Add(this.artContainer);
            this.midpanel.Location = new System.Drawing.Point(0, 0);
            this.midpanel.Name = "midpanel";
            this.midpanel.Size = new System.Drawing.Size(1061, 675);
            this.midpanel.TabIndex = 5;
            // 
            // goBack
            // 
            this.goBack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.goBack.FlatAppearance.BorderColor = System.Drawing.Color.GreenYellow;
            this.goBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.goBack.Font = new System.Drawing.Font("Lucida Console", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.goBack.ForeColor = System.Drawing.Color.White;
            this.goBack.Location = new System.Drawing.Point(28, 32);
            this.goBack.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.goBack.Name = "goBack";
            this.goBack.Size = new System.Drawing.Size(105, 33);
            this.goBack.TabIndex = 26;
            this.goBack.Text = "Go Back";
            this.goBack.UseVisualStyleBackColor = false;
            this.goBack.Click += new System.EventHandler(this.goBack_Click);
            // 
            // Submit
            // 
            this.Submit.Location = new System.Drawing.Point(585, 550);
            this.Submit.Name = "Submit";
            this.Submit.Size = new System.Drawing.Size(75, 23);
            this.Submit.TabIndex = 37;
            this.Submit.Text = "Submit";
            this.Submit.UseVisualStyleBackColor = true;
            this.Submit.Click += new System.EventHandler(this.Submit_Click_1);
            // 
            // paid
            // 
            this.paid.AutoSize = true;
            this.paid.BackColor = System.Drawing.Color.White;
            this.paid.Location = new System.Drawing.Point(513, 457);
            this.paid.Name = "paid";
            this.paid.Size = new System.Drawing.Size(148, 17);
            this.paid.TabIndex = 34;
            this.paid.TabStop = true;
            this.paid.Text = "              Paid                    ";
            this.paid.UseVisualStyleBackColor = false;
            this.paid.CheckedChanged += new System.EventHandler(this.paid_CheckedChanged);
            // 
            // free
            // 
            this.free.AutoSize = true;
            this.free.BackColor = System.Drawing.Color.White;
            this.free.Location = new System.Drawing.Point(299, 457);
            this.free.Name = "free";
            this.free.Size = new System.Drawing.Size(148, 17);
            this.free.TabIndex = 33;
            this.free.TabStop = true;
            this.free.Text = "              Free                    ";
            this.free.UseVisualStyleBackColor = false;
            this.free.CheckedChanged += new System.EventHandler(this.free_CheckedChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft New Tai Lue", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(194, 160);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(89, 21);
            this.label10.TabIndex = 31;
            this.label10.Text = "Description";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft New Tai Lue", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(194, 124);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(64, 21);
            this.label9.TabIndex = 30;
            this.label9.Text = "Art Title";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft New Tai Lue", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(239, 480);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 21);
            this.label6.TabIndex = 28;
            this.label6.Text = "Price";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft New Tai Lue", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(194, 251);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(38, 21);
            this.label7.TabIndex = 27;
            this.label7.Text = "Arts";
            // 
            // artPrice
            // 
            this.artPrice.Location = new System.Drawing.Point(299, 480);
            this.artPrice.Name = "artPrice";
            this.artPrice.Size = new System.Drawing.Size(362, 20);
            this.artPrice.TabIndex = 25;
            this.artPrice.Visible = false;
            // 
            // Description
            // 
            this.Description.Location = new System.Drawing.Point(299, 160);
            this.Description.Multiline = true;
            this.Description.Name = "Description";
            this.Description.Size = new System.Drawing.Size(362, 77);
            this.Description.TabIndex = 24;
            // 
            // arttitle
            // 
            this.arttitle.Location = new System.Drawing.Point(299, 125);
            this.arttitle.Name = "arttitle";
            this.arttitle.Size = new System.Drawing.Size(362, 20);
            this.arttitle.TabIndex = 23;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(468, 40);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(133, 25);
            this.label5.TabIndex = 0;
            this.label5.Text = "Manage Art";
            // 
            // artContainer
            // 
            this.artContainer.AutoScroll = true;
            this.artContainer.Controls.Add(this.artPanel);
            this.artContainer.Controls.Add(this.add);
            this.artContainer.Location = new System.Drawing.Point(287, 254);
            this.artContainer.Name = "artContainer";
            this.artContainer.Size = new System.Drawing.Size(402, 190);
            this.artContainer.TabIndex = 39;
            // 
            // artPanel
            // 
            this.artPanel.Location = new System.Drawing.Point(0, 0);
            this.artPanel.Margin = new System.Windows.Forms.Padding(0);
            this.artPanel.Name = "artPanel";
            this.artPanel.Size = new System.Drawing.Size(371, 35);
            this.artPanel.TabIndex = 38;
            // 
            // add
            // 
            this.add.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.add.Location = new System.Drawing.Point(3, 38);
            this.add.Name = "add";
            this.add.Size = new System.Drawing.Size(86, 23);
            this.add.TabIndex = 35;
            this.add.Text = "Add";
            this.add.UseVisualStyleBackColor = true;
            this.add.Click += new System.EventHandler(this.add_Click_1);
            // 
            // deleteArt
            // 
            this.deleteArt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deleteArt.Location = new System.Drawing.Point(789, 606);
            this.deleteArt.Name = "deleteArt";
            this.deleteArt.Size = new System.Drawing.Size(159, 23);
            this.deleteArt.TabIndex = 40;
            this.deleteArt.Text = "Delete This Art";
            this.deleteArt.UseVisualStyleBackColor = true;
            this.deleteArt.Click += new System.EventHandler(this.deleteArt_Click);
            // 
            // ManageArt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1059, 675);
            this.Controls.Add(this.midpanel);
            this.Name = "ManageArt";
            this.Text = "Manage Art";
            this.midpanel.ResumeLayout(false);
            this.midpanel.PerformLayout();
            this.artContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel midpanel;
        private System.Windows.Forms.Button Submit;
        private System.Windows.Forms.RadioButton paid;
        private System.Windows.Forms.RadioButton free;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox artPrice;
        private System.Windows.Forms.TextBox Description;
        private System.Windows.Forms.TextBox arttitle;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.FlowLayoutPanel artContainer;
        private System.Windows.Forms.Button add;
        private System.Windows.Forms.Panel artPanel;
        private System.Windows.Forms.Button goBack;
        private System.Windows.Forms.Button deleteArt;
    }
}