namespace MineSweeper
{
    partial class Form1
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
            this.masterLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // masterLabel
            // 
            this.masterLabel.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.masterLabel.ForeColor = System.Drawing.Color.Black;
            this.masterLabel.Location = new System.Drawing.Point(26, 23);
            this.masterLabel.Name = "masterLabel";
            this.masterLabel.Size = new System.Drawing.Size(20, 20);
            this.masterLabel.TabIndex = 0;
            this.masterLabel.Text = "O";
            this.masterLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.masterLabel.Visible = false;
            this.masterLabel.Click += new System.EventHandler(this.Label_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(399, 374);
            this.Controls.Add(this.masterLabel);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label masterLabel;
    }
}

