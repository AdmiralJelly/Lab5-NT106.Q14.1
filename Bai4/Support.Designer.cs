namespace Bai4
{
    partial class Support
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
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.WV_URL = new Microsoft.Web.WebView2.WinForms.WebView2();
            ((System.ComponentModel.ISupportInitialize)(this.WV_URL)).BeginInit();
            this.SuspendLayout();
            // 
            // WV_URL
            // 
            this.WV_URL.AllowExternalDrop = true;
            this.WV_URL.CreationProperties = null;
            this.WV_URL.DefaultBackgroundColor = System.Drawing.Color.White;
            this.WV_URL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.WV_URL.Location = new System.Drawing.Point(0, 0);
            this.WV_URL.Name = "WV_URL";
            this.WV_URL.Size = new System.Drawing.Size(1225, 780);
            this.WV_URL.TabIndex = 0;
            this.WV_URL.ZoomFactor = 1D;
            // 
            // Support
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MidnightBlue;
            this.ClientSize = new System.Drawing.Size(1225, 780);
            this.Controls.Add(this.WV_URL);
            this.Name = "Support";
            this.Text = "Support";
            ((System.ComponentModel.ISupportInitialize)(this.WV_URL)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private Microsoft.Web.WebView2.WinForms.WebView2 WV_URL;
    }
}