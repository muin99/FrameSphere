namespace FrameSphere.FormsEvents
{
    partial class ManageArtCollection
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
            this.MP_Body = new System.Windows.Forms.Panel();
            this.allArts_panel = new System.Windows.Forms.FlowLayoutPanel();
            this.submittedArts_panel = new System.Windows.Forms.FlowLayoutPanel();
            this.noArts = new System.Windows.Forms.Label();
            this.CurrentArts_Label = new System.Windows.Forms.Label();
            this.SearchArt_Field = new System.Windows.Forms.TextBox();
            this.FindArtist_Label = new System.Windows.Forms.Label();
            this.MP_Header = new System.Windows.Forms.Panel();
            this.goBack_button = new System.Windows.Forms.Button();
            this.Logout = new System.Windows.Forms.Button();
            this.ManageArtCollection_Title = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.MP_Body.SuspendLayout();
            this.submittedArts_panel.SuspendLayout();
            this.MP_Header.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.MP_Body, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.MP_Header, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.79049F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 83.20951F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1264, 681);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // MP_Body
            // 
            this.MP_Body.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.MP_Body.Controls.Add(this.allArts_panel);
            this.MP_Body.Controls.Add(this.submittedArts_panel);
            this.MP_Body.Controls.Add(this.CurrentArts_Label);
            this.MP_Body.Controls.Add(this.SearchArt_Field);
            this.MP_Body.Controls.Add(this.FindArtist_Label);
            this.MP_Body.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MP_Body.Location = new System.Drawing.Point(2, 116);
            this.MP_Body.Margin = new System.Windows.Forms.Padding(2);
            this.MP_Body.Name = "MP_Body";
            this.MP_Body.Size = new System.Drawing.Size(1260, 563);
            this.MP_Body.TabIndex = 2;
            // 
            // allArts_panel
            // 
            this.allArts_panel.AutoScroll = true;
            this.allArts_panel.Location = new System.Drawing.Point(23, 80);
            this.allArts_panel.Margin = new System.Windows.Forms.Padding(2);
            this.allArts_panel.Name = "allArts_panel";
            this.allArts_panel.Size = new System.Drawing.Size(591, 479);
            this.allArts_panel.TabIndex = 6;
            // 
            // submittedArts_panel
            // 
            this.submittedArts_panel.AutoScroll = true;
            this.submittedArts_panel.Controls.Add(this.noArts);
            this.submittedArts_panel.Location = new System.Drawing.Point(649, 80);
            this.submittedArts_panel.Margin = new System.Windows.Forms.Padding(2);
            this.submittedArts_panel.Name = "submittedArts_panel";
            this.submittedArts_panel.Size = new System.Drawing.Size(602, 479);
            this.submittedArts_panel.TabIndex = 5;
            // 
            // noArts
            // 
            this.noArts.AutoSize = true;
            this.noArts.Location = new System.Drawing.Point(2, 0);
            this.noArts.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.noArts.Name = "noArts";
            this.noArts.Size = new System.Drawing.Size(33, 13);
            this.noArts.TabIndex = 0;
            this.noArts.Text = "None";
            // 
            // CurrentArts_Label
            // 
            this.CurrentArts_Label.AutoSize = true;
            this.CurrentArts_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CurrentArts_Label.Location = new System.Drawing.Point(656, 52);
            this.CurrentArts_Label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.CurrentArts_Label.Name = "CurrentArts_Label";
            this.CurrentArts_Label.Size = new System.Drawing.Size(177, 17);
            this.CurrentArts_Label.TabIndex = 4;
            this.CurrentArts_Label.Text = "Current Art Collections:";
            // 
            // SearchArt_Field
            // 
            this.SearchArt_Field.Location = new System.Drawing.Point(86, 49);
            this.SearchArt_Field.Margin = new System.Windows.Forms.Padding(2);
            this.SearchArt_Field.Name = "SearchArt_Field";
            this.SearchArt_Field.Size = new System.Drawing.Size(351, 20);
            this.SearchArt_Field.TabIndex = 2;
            this.SearchArt_Field.TextChanged += new System.EventHandler(this.SearchArt_Field_TextChanged);
            // 
            // FindArtist_Label
            // 
            this.FindArtist_Label.AutoSize = true;
            this.FindArtist_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FindArtist_Label.Location = new System.Drawing.Point(20, 51);
            this.FindArtist_Label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.FindArtist_Label.Name = "FindArtist_Label";
            this.FindArtist_Label.Size = new System.Drawing.Size(69, 17);
            this.FindArtist_Label.TabIndex = 1;
            this.FindArtist_Label.Text = "Search: ";
            // 
            // MP_Header
            // 
            this.MP_Header.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.MP_Header.Controls.Add(this.goBack_button);
            this.MP_Header.Controls.Add(this.Logout);
            this.MP_Header.Controls.Add(this.ManageArtCollection_Title);
            this.MP_Header.Location = new System.Drawing.Point(2, 2);
            this.MP_Header.Margin = new System.Windows.Forms.Padding(2);
            this.MP_Header.Name = "MP_Header";
            this.MP_Header.Size = new System.Drawing.Size(1260, 110);
            this.MP_Header.TabIndex = 1;
            // 
            // goBack_button
            // 
            this.goBack_button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.goBack_button.FlatAppearance.BorderColor = System.Drawing.Color.GreenYellow;
            this.goBack_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.goBack_button.Font = new System.Drawing.Font("Lucida Console", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.goBack_button.ForeColor = System.Drawing.Color.White;
            this.goBack_button.Location = new System.Drawing.Point(23, 25);
            this.goBack_button.Margin = new System.Windows.Forms.Padding(2);
            this.goBack_button.Name = "goBack_button";
            this.goBack_button.Size = new System.Drawing.Size(105, 33);
            this.goBack_button.TabIndex = 25;
            this.goBack_button.Text = "Go Back";
            this.goBack_button.UseVisualStyleBackColor = false;
            this.goBack_button.Click += new System.EventHandler(this.goBack_button_Click);
            // 
            // Logout
            // 
            this.Logout.BackColor = System.Drawing.Color.Snow;
            this.Logout.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.Logout.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.Logout.ForeColor = System.Drawing.Color.Red;
            this.Logout.Location = new System.Drawing.Point(1160, 36);
            this.Logout.Name = "Logout";
            this.Logout.Size = new System.Drawing.Size(75, 23);
            this.Logout.TabIndex = 24;
            this.Logout.Text = "Log out";
            this.Logout.UseVisualStyleBackColor = false;
            // 
            // ManageArtCollection_Title
            // 
            this.ManageArtCollection_Title.AutoSize = true;
            this.ManageArtCollection_Title.Font = new System.Drawing.Font("Microsoft New Tai Lue", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ManageArtCollection_Title.Location = new System.Drawing.Point(475, 36);
            this.ManageArtCollection_Title.Name = "ManageArtCollection_Title";
            this.ManageArtCollection_Title.Size = new System.Drawing.Size(316, 35);
            this.ManageArtCollection_Title.TabIndex = 22;
            this.ManageArtCollection_Title.Text = "Manage Art Collections";
            // 
            // ManageArtCollection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ManageArtCollection";
            this.Text = "Manage Art Collection";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.MP_Body.ResumeLayout(false);
            this.MP_Body.PerformLayout();
            this.submittedArts_panel.ResumeLayout(false);
            this.submittedArts_panel.PerformLayout();
            this.MP_Header.ResumeLayout(false);
            this.MP_Header.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel MP_Header;
        private System.Windows.Forms.Button goBack_button;
        private System.Windows.Forms.Button Logout;
        private System.Windows.Forms.Label ManageArtCollection_Title;
        private System.Windows.Forms.Panel MP_Body;
        private System.Windows.Forms.FlowLayoutPanel allArts_panel;
        private System.Windows.Forms.FlowLayoutPanel submittedArts_panel;
        private System.Windows.Forms.Label noArts;
        private System.Windows.Forms.Label CurrentArts_Label;
        private System.Windows.Forms.TextBox SearchArt_Field;
        private System.Windows.Forms.Label FindArtist_Label;
    }
}