namespace Bai6
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            grpLogin = new GroupBox();
            btnLogin = new Button();
            txtPass = new TextBox();
            txtUser = new TextBox();
            label2 = new Label();
            label1 = new Label();
            grpSettings = new GroupBox();
            numSmtpPort = new NumericUpDown();
            numImapPort = new NumericUpDown();
            txtSmtp = new TextBox();
            txtImap = new TextBox();
            label4 = new Label();
            label6 = new Label();
            label5 = new Label();
            label3 = new Label();
            btnCompose = new Button();
            btnRefresh = new Button();
            btnLogout = new Button();
            dataGridView1 = new DataGridView();
            colNo = new DataGridViewTextBoxColumn();
            colFrom = new DataGridViewTextBoxColumn();
            colSubject = new DataGridViewTextBoxColumn();
            colDate = new DataGridViewTextBoxColumn();
            grpLogin.SuspendLayout();
            grpSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numSmtpPort).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numImapPort).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // grpLogin
            // 
            grpLogin.Controls.Add(btnLogin);
            grpLogin.Controls.Add(txtPass);
            grpLogin.Controls.Add(txtUser);
            grpLogin.Controls.Add(label2);
            grpLogin.Controls.Add(label1);
            grpLogin.Location = new Point(12, 12);
            grpLogin.Name = "grpLogin";
            grpLogin.Size = new Size(335, 126);
            grpLogin.TabIndex = 0;
            grpLogin.TabStop = false;
            grpLogin.Text = "Đăng nhập";
            // 
            // btnLogin
            // 
            btnLogin.Location = new Point(106, 90);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(139, 29);
            btnLogin.TabIndex = 4;
            btnLogin.Text = "Đăng nhập";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;
            // 
            // txtPass
            // 
            txtPass.Location = new Point(81, 57);
            txtPass.Name = "txtPass";
            txtPass.PasswordChar = '*';
            txtPass.Size = new Size(238, 27);
            txtPass.TabIndex = 3;
            // 
            // txtUser
            // 
            txtUser.Location = new Point(81, 24);
            txtUser.Name = "txtUser";
            txtUser.Size = new Size(238, 27);
            txtUser.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 60);
            label2.Name = "label2";
            label2.Size = new Size(70, 20);
            label2.TabIndex = 1;
            label2.Text = "Mật khẩu";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 27);
            label1.Name = "label1";
            label1.Size = new Size(71, 20);
            label1.TabIndex = 0;
            label1.Text = "Tài khoản";
            // 
            // grpSettings
            // 
            grpSettings.Controls.Add(numSmtpPort);
            grpSettings.Controls.Add(numImapPort);
            grpSettings.Controls.Add(txtSmtp);
            grpSettings.Controls.Add(txtImap);
            grpSettings.Controls.Add(label4);
            grpSettings.Controls.Add(label6);
            grpSettings.Controls.Add(label5);
            grpSettings.Controls.Add(label3);
            grpSettings.Location = new Point(362, 12);
            grpSettings.Name = "grpSettings";
            grpSettings.Size = new Size(410, 100);
            grpSettings.TabIndex = 0;
            grpSettings.TabStop = false;
            grpSettings.Text = "Cài đặt";
            // 
            // numSmtpPort
            // 
            numSmtpPort.Location = new Point(275, 58);
            numSmtpPort.Maximum = new decimal(new int[] { 65535, 0, 0, 0 });
            numSmtpPort.Name = "numSmtpPort";
            numSmtpPort.Size = new Size(116, 27);
            numSmtpPort.TabIndex = 2;
            numSmtpPort.Value = new decimal(new int[] { 465, 0, 0, 0 });
            // 
            // numImapPort
            // 
            numImapPort.Location = new Point(59, 58);
            numImapPort.Maximum = new decimal(new int[] { 65535, 0, 0, 0 });
            numImapPort.Name = "numImapPort";
            numImapPort.Size = new Size(116, 27);
            numImapPort.TabIndex = 2;
            numImapPort.Value = new decimal(new int[] { 993, 0, 0, 0 });
            // 
            // txtSmtp
            // 
            txtSmtp.Location = new Point(260, 24);
            txtSmtp.Name = "txtSmtp";
            txtSmtp.Size = new Size(131, 27);
            txtSmtp.TabIndex = 1;
            txtSmtp.Text = "smtp.gmail.com";
            // 
            // txtImap
            // 
            txtImap.Location = new Point(59, 24);
            txtImap.Name = "txtImap";
            txtImap.Size = new Size(131, 27);
            txtImap.TabIndex = 1;
            txtImap.Text = "imap.gmail.com";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(207, 27);
            label4.Name = "label4";
            label4.Size = new Size(46, 20);
            label4.TabIndex = 0;
            label4.Text = "SMTP";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(207, 60);
            label6.Name = "label6";
            label6.Size = new Size(35, 20);
            label6.TabIndex = 0;
            label6.Text = "Port";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(6, 60);
            label5.Name = "label5";
            label5.Size = new Size(35, 20);
            label5.TabIndex = 0;
            label5.Text = "Port";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(6, 27);
            label3.Name = "label3";
            label3.Size = new Size(45, 20);
            label3.TabIndex = 0;
            label3.Text = "IMAP";
            // 
            // btnCompose
            // 
            btnCompose.Location = new Point(12, 144);
            btnCompose.Name = "btnCompose";
            btnCompose.Size = new Size(94, 29);
            btnCompose.TabIndex = 1;
            btnCompose.Text = "Gửi mail";
            btnCompose.UseVisualStyleBackColor = true;
            btnCompose.Click += btnCompose_Click;
            btnCompose.Visible = false;
            // 
            // btnRefresh
            // 
            btnRefresh.Location = new Point(115, 144);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(94, 29);
            btnRefresh.TabIndex = 1;
            btnRefresh.Text = "Refresh";
            btnRefresh.UseVisualStyleBackColor = true;
            btnRefresh.Click += btnRefresh_Click;
             btnRefresh.Visible = false;
            // 
            // btnLogout
            // 
            btnLogout.Location = new Point(218, 144);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(94, 29);
            btnLogout.TabIndex = 1;
            btnLogout.Text = "Đăng xuất";
            btnLogout.UseVisualStyleBackColor = true;
            btnLogout.Click += btnLogout_Click;
             btnLogout.Visible = false;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { colNo, colFrom, colSubject, colDate });
            dataGridView1.Location = new Point(12, 179);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(776, 360);
            dataGridView1.TabIndex = 2;
            dataGridView1.CellClick += dataGridView1_CellClick;
            // 
            // colNo
            // 
            colNo.HeaderText = "#";
            colNo.MinimumWidth = 6;
            colNo.Name = "colNo";
            colNo.ReadOnly = true;
            colNo.Width = 50;
            // 
            // colFrom
            // 
            colFrom.HeaderText = "From";
            colFrom.MinimumWidth = 6;
            colFrom.Name = "colFrom";
            colFrom.ReadOnly = true;
            colFrom.Width = 200;
            // 
            // colSubject
            // 
            colSubject.HeaderText = "Subject";
            colSubject.MinimumWidth = 6;
            colSubject.Name = "colSubject";
            colSubject.ReadOnly = true;
            colSubject.Width = 350;
            // 
            // colDate
            // 
            colDate.HeaderText = "Datetime";
            colDate.MinimumWidth = 6;
            colDate.Name = "colDate";
            colDate.ReadOnly = true;
            colDate.Width = 150;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 550);
            Controls.Add(dataGridView1);
            Controls.Add(btnLogout);
            Controls.Add(btnRefresh);
            Controls.Add(btnCompose);
            Controls.Add(grpSettings);
            Controls.Add(grpLogin);
            Name = "Form1";
            Text = "Form1";
            grpLogin.ResumeLayout(false);
            grpLogin.PerformLayout();
            grpSettings.ResumeLayout(false);
            grpSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numSmtpPort).EndInit();
            ((System.ComponentModel.ISupportInitialize)numImapPort).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox grpLogin;
        private Label label2;
        private Label label1;
        private TextBox txtPass;
        private TextBox txtUser;
        private Button btnLogin;
        private GroupBox grpSettings;
        private NumericUpDown numSmtpPort;
        private NumericUpDown numImapPort;
        private TextBox txtSmtp;
        private TextBox txtImap;
        private Label label4;
        private Label label6;
        private Label label5;
        private Label label3;
        private Button btnCompose;
        private Button btnRefresh;
        private Button btnLogout;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn colNo;
        private DataGridViewTextBoxColumn colFrom;
        private DataGridViewTextBoxColumn colSubject;
        private DataGridViewTextBoxColumn colDate;
    }
}
