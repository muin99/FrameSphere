namespace FrameSphere.FormsArts
{
    partial class test
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
            this.artPanel = new System.Windows.Forms.Panel();
            this.remove = new System.Windows.Forms.Button();
            this.photobox = new System.Windows.Forms.TextBox();
            this.artPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // artPanel
            // 
            this.artPanel.Controls.Add(this.remove);
            this.artPanel.Controls.Add(this.photobox);
            this.artPanel.Location = new System.Drawing.Point(215, 208);
            this.artPanel.Name = "artPanel";
            this.artPanel.Size = new System.Drawing.Size(371, 35);
            this.artPanel.TabIndex = 40;
            // 
            // remove
            // 
            this.remove.Location = new System.Drawing.Point(304, 8);
            this.remove.Name = "remove";
            this.remove.Size = new System.Drawing.Size(66, 21);
            this.remove.TabIndex = 36;
            this.remove.Text = "Remove";
            this.remove.UseVisualStyleBackColor = true;
            // 
            // photobox
            // 
            this.photobox.Location = new System.Drawing.Point(9, 8);
            this.photobox.Name = "photobox";
            this.photobox.ReadOnly = true;
            this.photobox.Size = new System.Drawing.Size(289, 20);
            this.photobox.TabIndex = 26;
            // 
            // test
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.artPanel);
            this.Name = "test";
            this.Text = "test";
            this.artPanel.ResumeLayout(false);
            this.artPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel artPanel;
        private System.Windows.Forms.Button remove;
        private System.Windows.Forms.TextBox photobox;
    }
}