namespace PMHI
{
    partial class DisplayForm
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
            this.SuspendLayout();
            // 
            // DisplayForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Blue;
            this.ClientSize = new System.Drawing.Size(942, 730);
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "DisplayForm";
            this.Text = "DisplayForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DisplayForm_FormClosing);
            this.Load += new System.EventHandler(this.DisplayForm_Load);
            this.Click += new System.EventHandler(this.DisplayForm_Click);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DisplayForm_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion
    }
}