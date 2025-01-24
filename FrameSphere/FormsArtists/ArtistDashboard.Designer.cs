namespace FrameSphere
{
    partial class ArtistDashboard
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
            this.CreateArt = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // CreateArt
            // 
            this.CreateArt.Location = new System.Drawing.Point(137, 127);
            this.CreateArt.Name = "CreateArt";
            this.CreateArt.Size = new System.Drawing.Size(206, 23);
            this.CreateArt.TabIndex = 0;
            this.CreateArt.Text = "CreateArt";
            this.CreateArt.UseVisualStyleBackColor = true;
            // 
            // ArtistDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.CreateArt);
            this.Name = "ArtistDashboard";
            this.Text = "ArtistDashboard";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button CreateArt;
    }
}