
namespace FrameSphere.FormsEvents
{
    partial class ManageOrganizer
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
            this.mParticipant_tableLayout = new System.Windows.Forms.TableLayoutPanel();
            this.MP_Header = new System.Windows.Forms.Panel();
            this.goBack_button = new System.Windows.Forms.Button();
            this.Logout = new System.Windows.Forms.Button();
            this.ManageParticipants_Title = new System.Windows.Forms.Label();
            this.MP_Body = new System.Windows.Forms.Panel();
            this.allorganizers = new System.Windows.Forms.FlowLayoutPanel();
            this.currentOrganizers_panel = new System.Windows.Forms.FlowLayoutPanel();
            this.noOrganizers = new System.Windows.Forms.Label();
            this.CurrentArtists_Label = new System.Windows.Forms.Label();
            this.SearchOrganizer_Field = new System.Windows.Forms.TextBox();
            this.FindArtist_Label = new System.Windows.Forms.Label();
            this.mParticipant_tableLayout.SuspendLayout();
            this.MP_Header.SuspendLayout();
            this.MP_Body.SuspendLayout();
            this.currentOrganizers_panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mParticipant_tableLayout
            // 
            this.mParticipant_tableLayout.ColumnCount = 1;
            this.mParticipant_tableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.mParticipant_tableLayout.Controls.Add(this.MP_Header, 0, 0);
            this.mParticipant_tableLayout.Controls.Add(this.MP_Body, 0, 1);
            this.mParticipant_tableLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mParticipant_tableLayout.Location = new System.Drawing.Point(0, 0);
            this.mParticipant_tableLayout.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.mParticipant_tableLayout.Name = "mParticipant_tableLayout";
            this.mParticipant_tableLayout.RowCount = 2;
            this.mParticipant_tableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13.48449F));
            this.mParticipant_tableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 86.51551F));
            this.mParticipant_tableLayout.Size = new System.Drawing.Size(1685, 838);
            this.mParticipant_tableLayout.TabIndex = 1;
            // 
            // MP_Header
            // 
            this.MP_Header.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.MP_Header.Controls.Add(this.goBack_button);
            this.MP_Header.Controls.Add(this.Logout);
            this.MP_Header.Controls.Add(this.ManageParticipants_Title);
            this.MP_Header.Location = new System.Drawing.Point(3, 2);
            this.MP_Header.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MP_Header.Name = "MP_Header";
            this.MP_Header.Size = new System.Drawing.Size(1677, 106);
            this.MP_Header.TabIndex = 0;
            // 
            // goBack_button
            // 
            this.goBack_button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.goBack_button.FlatAppearance.BorderColor = System.Drawing.Color.GreenYellow;
            this.goBack_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.goBack_button.Font = new System.Drawing.Font("Lucida Console", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.goBack_button.ForeColor = System.Drawing.Color.White;
            this.goBack_button.Location = new System.Drawing.Point(31, 31);
            this.goBack_button.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.goBack_button.Name = "goBack_button";
            this.goBack_button.Size = new System.Drawing.Size(140, 41);
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
            this.Logout.Location = new System.Drawing.Point(1547, 44);
            this.Logout.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Logout.Name = "Logout";
            this.Logout.Size = new System.Drawing.Size(100, 28);
            this.Logout.TabIndex = 24;
            this.Logout.Text = "Log out";
            this.Logout.UseVisualStyleBackColor = false;
            this.Logout.Click += new System.EventHandler(this.Logout_Click);
            // 
            // ManageParticipants_Title
            // 
            this.ManageParticipants_Title.AutoSize = true;
            this.ManageParticipants_Title.Font = new System.Drawing.Font("Microsoft New Tai Lue", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ManageParticipants_Title.Location = new System.Drawing.Point(715, 31);
            this.ManageParticipants_Title.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ManageParticipants_Title.Name = "ManageParticipants_Title";
            this.ManageParticipants_Title.Size = new System.Drawing.Size(331, 45);
            this.ManageParticipants_Title.TabIndex = 22;
            this.ManageParticipants_Title.Text = "Manage Organizers";
            // 
            // MP_Body
            // 
            this.MP_Body.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.MP_Body.Controls.Add(this.allorganizers);
            this.MP_Body.Controls.Add(this.currentOrganizers_panel);
            this.MP_Body.Controls.Add(this.CurrentArtists_Label);
            this.MP_Body.Controls.Add(this.SearchOrganizer_Field);
            this.MP_Body.Controls.Add(this.FindArtist_Label);
            this.MP_Body.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MP_Body.Location = new System.Drawing.Point(3, 115);
            this.MP_Body.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MP_Body.Name = "MP_Body";
            this.MP_Body.Size = new System.Drawing.Size(1679, 721);
            this.MP_Body.TabIndex = 1;
            // 
            // allorganizers
            // 
            this.allorganizers.AutoScroll = true;
            this.allorganizers.Location = new System.Drawing.Point(31, 98);
            this.allorganizers.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.allorganizers.Name = "allorganizers";
            this.allorganizers.Size = new System.Drawing.Size(672, 590);
            this.allorganizers.TabIndex = 6;
            // 
            // currentOrganizers_panel
            // 
            this.currentOrganizers_panel.Controls.Add(this.noOrganizers);
            this.currentOrganizers_panel.Location = new System.Drawing.Point(723, 98);
            this.currentOrganizers_panel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.currentOrganizers_panel.Name = "currentOrganizers_panel";
            this.currentOrganizers_panel.Size = new System.Drawing.Size(747, 590);
            this.currentOrganizers_panel.TabIndex = 5;
            // 
            // noOrganizers
            // 
            this.noOrganizers.AutoSize = true;
            this.noOrganizers.Location = new System.Drawing.Point(3, 0);
            this.noOrganizers.Name = "noOrganizers";
            this.noOrganizers.Size = new System.Drawing.Size(40, 16);
            this.noOrganizers.TabIndex = 0;
            this.noOrganizers.Text = "None";
            // 
            // CurrentArtists_Label
            // 
            this.CurrentArtists_Label.AutoSize = true;
            this.CurrentArtists_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CurrentArtists_Label.Location = new System.Drawing.Point(719, 60);
            this.CurrentArtists_Label.Name = "CurrentArtists_Label";
            this.CurrentArtists_Label.Size = new System.Drawing.Size(183, 20);
            this.CurrentArtists_Label.TabIndex = 4;
            this.CurrentArtists_Label.Text = "Currently Organizing";
            // 
            // SearchOrganizer_Field
            // 
            this.SearchOrganizer_Field.Location = new System.Drawing.Point(115, 60);
            this.SearchOrganizer_Field.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.SearchOrganizer_Field.Name = "SearchOrganizer_Field";
            this.SearchOrganizer_Field.Size = new System.Drawing.Size(467, 22);
            this.SearchOrganizer_Field.TabIndex = 2;
            this.SearchOrganizer_Field.TextChanged += new System.EventHandler(this.SearchOrganizer_Field_TextChanged);
            // 
            // FindArtist_Label
            // 
            this.FindArtist_Label.AutoSize = true;
            this.FindArtist_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FindArtist_Label.Location = new System.Drawing.Point(27, 63);
            this.FindArtist_Label.Name = "FindArtist_Label";
            this.FindArtist_Label.Size = new System.Drawing.Size(80, 20);
            this.FindArtist_Label.TabIndex = 1;
            this.FindArtist_Label.Text = "Search: ";
            // 
            // ManageOrganizer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1685, 838);
            this.Controls.Add(this.mParticipant_tableLayout);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "ManageOrganizer";
            this.Text = "Manage Organizers";
            this.mParticipant_tableLayout.ResumeLayout(false);
            this.MP_Header.ResumeLayout(false);
            this.MP_Header.PerformLayout();
            this.MP_Body.ResumeLayout(false);
            this.MP_Body.PerformLayout();
            this.currentOrganizers_panel.ResumeLayout(false);
            this.currentOrganizers_panel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel mParticipant_tableLayout;
        private System.Windows.Forms.Panel MP_Header;
        private System.Windows.Forms.Button goBack_button;
        private System.Windows.Forms.Button Logout;
        private System.Windows.Forms.Label ManageParticipants_Title;
        private System.Windows.Forms.Panel MP_Body;
        private System.Windows.Forms.FlowLayoutPanel allorganizers;
        private System.Windows.Forms.FlowLayoutPanel currentOrganizers_panel;
        private System.Windows.Forms.Label noOrganizers;
        private System.Windows.Forms.Label CurrentArtists_Label;
        private System.Windows.Forms.TextBox SearchOrganizer_Field;
        private System.Windows.Forms.Label FindArtist_Label;
    }
}