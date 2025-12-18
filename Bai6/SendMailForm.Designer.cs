namespace Bai6
{
    partial class SendMailForm
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            chkHtml = new CheckBox();
            txtFrom = new TextBox();
            txtTo = new TextBox();
            txtSubject = new TextBox();
            rtbBody = new RichTextBox();
            txtAttachment = new TextBox();
            btnBrowse = new Button();
            btnSend = new Button();
            label5 = new Label();
            txtName = new TextBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 15);
            label1.Name = "label1";
            label1.Size = new Size(46, 20);
            label1.TabIndex = 0;
            label1.Text = "From:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 48);
            label2.Name = "label2";
            label2.Size = new Size(52, 20);
            label2.TabIndex = 0;
            label2.Text = "Name:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 81);
            label3.Name = "label3";
            label3.Size = new Size(28, 20);
            label3.TabIndex = 0;
            label3.Text = "To:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 114);
            label4.Name = "label4";
            label4.Size = new Size(61, 20);
            label4.TabIndex = 0;
            label4.Text = "Subject:";
            // 
            // chkHtml
            // 
            chkHtml.AutoSize = true;
            chkHtml.Location = new Point(80, 147);
            chkHtml.Name = "chkHtml";
            chkHtml.Size = new Size(70, 24);
            chkHtml.TabIndex = 1;
            chkHtml.Text = "HTML";
            chkHtml.UseVisualStyleBackColor = true;
            // 
            // txtFrom
            // 
            txtFrom.Location = new Point(80, 12);
            txtFrom.Name = "txtFrom";
            txtFrom.ReadOnly = true;
            txtFrom.Size = new Size(350, 27);
            txtFrom.TabIndex = 2;
            // 
            // txtTo
            // 
            txtTo.Location = new Point(80, 78);
            txtTo.Name = "txtTo";
            txtTo.Size = new Size(350, 27);
            txtTo.TabIndex = 2;
            // 
            // txtSubject
            // 
            txtSubject.Location = new Point(80, 111);
            txtSubject.Name = "txtSubject";
            txtSubject.Size = new Size(350, 27);
            txtSubject.TabIndex = 2;
            // 
            // rtbBody
            // 
            rtbBody.Location = new Point(80, 177);
            rtbBody.Name = "rtbBody";
            rtbBody.Size = new Size(350, 200);
            rtbBody.TabIndex = 3;
            rtbBody.Text = "";
            // 
            // txtAttachment
            // 
            txtAttachment.Location = new Point(80, 394);
            txtAttachment.Name = "txtAttachment";
            txtAttachment.ReadOnly = true;
            txtAttachment.Size = new Size(244, 27);
            txtAttachment.TabIndex = 2;
            // 
            // btnBrowse
            // 
            btnBrowse.Location = new Point(330, 393);
            btnBrowse.Name = "btnBrowse";
            btnBrowse.Size = new Size(100, 29);
            btnBrowse.TabIndex = 4;
            btnBrowse.Text = "Browse...";
            btnBrowse.UseVisualStyleBackColor = true;
            btnBrowse.Click += btnBrowse_Click;
            // 
            // btnSend
            // 
            btnSend.Location = new Point(330, 428);
            btnSend.Name = "btnSend";
            btnSend.Size = new Size(100, 29);
            btnSend.TabIndex = 4;
            btnSend.Text = "Send";
            btnSend.UseVisualStyleBackColor = true;
            btnSend.Click += btnSend_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(12, 397);
            label5.Name = "label5";
            label5.Size = new Size(62, 20);
            label5.TabIndex = 0;
            label5.Text = "Attach:";
            // 
            // txtName
            // 
            txtName.Location = new Point(80, 45);
            txtName.Name = "txtName";
            txtName.Size = new Size(350, 27);
            txtName.TabIndex = 2;
            // 
            // SendMailForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(452, 469);
            Controls.Add(btnSend);
            Controls.Add(btnBrowse);
            Controls.Add(rtbBody);
            Controls.Add(txtSubject);
            Controls.Add(txtTo);
            Controls.Add(txtName);
            Controls.Add(txtAttachment);
            Controls.Add(txtFrom);
            Controls.Add(chkHtml);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "SendMailForm";
            Text = "Send Mail";
            ResumeLayout(false);
            PerformLayout();
        }

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private CheckBox chkHtml;
        private TextBox txtFrom;
        private TextBox txtTo;
        private TextBox txtSubject;
        private RichTextBox rtbBody;
        private TextBox txtAttachment;
        private Button btnBrowse;
        private Button btnSend;
        private Label label5;
        private TextBox txtName;
    }
}
