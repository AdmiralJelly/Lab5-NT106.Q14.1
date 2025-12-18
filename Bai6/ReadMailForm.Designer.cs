namespace Bai6
{
    partial class ReadMailForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblFrom = new Label();
            lblTo = new Label();
            lblSubject = new Label();
            webBrowser1 = new WebBrowser();
            SuspendLayout();
            // 
            // lblFrom
            // 
            lblFrom.AutoSize = true;
            lblFrom.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblFrom.Location = new Point(12, 13);
            lblFrom.Name = "lblFrom";
            lblFrom.Size = new Size(49, 20);
            lblFrom.TabIndex = 0;
            lblFrom.Text = "From:";
            // 
            // lblTo
            // 
            lblTo.AutoSize = true;
            lblTo.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblTo.Location = new Point(12, 43);
            lblTo.Name = "lblTo";
            lblTo.Size = new Size(30, 20);
            lblTo.TabIndex = 0;
            lblTo.Text = "To:";
            // 
            // lblSubject
            // 
            lblSubject.AutoSize = true;
            lblSubject.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblSubject.Location = new Point(12, 73);
            lblSubject.Name = "lblSubject";
            lblSubject.Size = new Size(80, 25);
            lblSubject.TabIndex = 0;
            lblSubject.Text = "Subject";
            // 
            // webBrowser1
            // 
            webBrowser1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            webBrowser1.Location = new Point(12, 110);
            webBrowser1.MinimumSize = new Size(20, 20);
            webBrowser1.Name = "webBrowser1";
            webBrowser1.Size = new Size(776, 328);
            webBrowser1.TabIndex = 1;
            // 
            // ReadMailForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(webBrowser1);
            Controls.Add(lblSubject);
            Controls.Add(lblTo);
            Controls.Add(lblFrom);
            Name = "ReadMailForm";
            Text = "Read Mail";
            Load += ReadMailForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        private Label lblFrom;
        private Label lblTo;
        private Label lblSubject;
        private WebBrowser webBrowser1;
    }
}
