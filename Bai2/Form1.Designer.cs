namespace Bai_2_IMAP
{
    partial class IMAP
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
            this.lbEmail = new System.Windows.Forms.Label();
            this.lbPassword = new System.Windows.Forms.Label();
            this.txt_email = new System.Windows.Forms.TextBox();
            this.txt_password = new System.Windows.Forms.TextBox();
            this.btn_login = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.cb_show_pass = new System.Windows.Forms.CheckBox();
            this.lbTotal = new System.Windows.Forms.Label();
            this.lbTotalValue = new System.Windows.Forms.Label();
            this.lbRecent = new System.Windows.Forms.Label();
            this.lbRecentValue = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // lbEmail
            // 
            this.lbEmail.AutoSize = true;
            this.lbEmail.Location = new System.Drawing.Point(30, 30);
            this.lbEmail.Name = "lbEmail";
            this.lbEmail.Size = new System.Drawing.Size(46, 20);
            this.lbEmail.TabIndex = 0;
            this.lbEmail.Text = "Email";
            // 
            // lbPassword
            // 
            this.lbPassword.AutoSize = true;
            this.lbPassword.Location = new System.Drawing.Point(30, 70);
            this.lbPassword.Name = "lbPassword";
            this.lbPassword.Size = new System.Drawing.Size(70, 20);
            this.lbPassword.TabIndex = 1;
            this.lbPassword.Text = "Password";
            // 
            // txt_email
            // 
            this.txt_email.Location = new System.Drawing.Point(120, 27);
            this.txt_email.Name = "txt_email";
            this.txt_email.Size = new System.Drawing.Size(400, 27);
            this.txt_email.TabIndex = 2;
            this.txt_email.Text = ""; 
            // 
            // txt_password
            // 
            this.txt_password.Location = new System.Drawing.Point(120, 67);
            this.txt_password.Name = "txt_password";
            this.txt_password.Size = new System.Drawing.Size(400, 27);
            this.txt_password.TabIndex = 3;
            this.txt_password.UseSystemPasswordChar = true;
            // 
            // btn_login
            // 
            this.btn_login.Location = new System.Drawing.Point(600, 27);
            this.btn_login.Name = "btn_login";
            this.btn_login.Size = new System.Drawing.Size(120, 70);
            this.btn_login.TabIndex = 4;
            this.btn_login.Text = "LOGIN";
            this.btn_login.UseVisualStyleBackColor = true;
            this.btn_login.Click += new System.EventHandler(this.btn_login_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(30, 160);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 29;
            this.dataGridView1.Size = new System.Drawing.Size(740, 270);
            this.dataGridView1.TabIndex = 5;
            // 
            // cb_show_pass
            // 
            this.cb_show_pass.AutoSize = true;
            this.cb_show_pass.Location = new System.Drawing.Point(530, 70);
            this.cb_show_pass.Name = "cb_show_pass";
            this.cb_show_pass.Size = new System.Drawing.Size(18, 17);
            this.cb_show_pass.TabIndex = 6;
            this.cb_show_pass.UseVisualStyleBackColor = true;
            this.cb_show_pass.CheckedChanged += new System.EventHandler(this.cb_show_pass_CheckedChanged);
            // 
            // lbTotal
            // 
            this.lbTotal.AutoSize = true;
            this.lbTotal.Location = new System.Drawing.Point(30, 120);
            this.lbTotal.Name = "lbTotal";
            this.lbTotal.Size = new System.Drawing.Size(46, 20);
            this.lbTotal.TabIndex = 7;
            this.lbTotal.Text = "Total:";
            // 
            // lbTotalValue
            // 
            this.lbTotalValue.AutoSize = true;
            this.lbTotalValue.Location = new System.Drawing.Point(80, 120);
            this.lbTotalValue.Name = "lbTotalValue";
            this.lbTotalValue.Size = new System.Drawing.Size(46, 20);
            this.lbTotalValue.TabIndex = 8;
            this.lbTotalValue.Text = "";
            // 
            // lbRecent
            // 
            this.lbRecent.AutoSize = true;
            this.lbRecent.Location = new System.Drawing.Point(200, 120);
            this.lbRecent.Name = "lbRecent";
            this.lbRecent.Size = new System.Drawing.Size(56, 20);
            this.lbRecent.TabIndex = 9;
            this.lbRecent.Text = "Recent:";
            // 
            // lbRecentValue
            // 
            this.lbRecentValue.AutoSize = true;
            this.lbRecentValue.Location = new System.Drawing.Point(260, 120);
            this.lbRecentValue.Name = "lbRecentValue";
            this.lbRecentValue.Size = new System.Drawing.Size(56, 20);
            this.lbRecentValue.TabIndex = 10;
            this.lbRecentValue.Text = "";
            // 
            // IMAP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lbRecentValue);
            this.Controls.Add(this.lbRecent);
            this.Controls.Add(this.lbTotalValue);
            this.Controls.Add(this.lbTotal);
            this.Controls.Add(this.cb_show_pass);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btn_login);
            this.Controls.Add(this.txt_password);
            this.Controls.Add(this.txt_email);
            this.Controls.Add(this.lbPassword);
            this.Controls.Add(this.lbEmail);
            this.Name = "IMAP";
            this.Text = "Form3"; // Updated title to match image
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbEmail;
        private System.Windows.Forms.Label lbPassword;
        private System.Windows.Forms.TextBox txt_email;
        private System.Windows.Forms.TextBox txt_password;
        private System.Windows.Forms.Button btn_login;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.CheckBox cb_show_pass;
        private System.Windows.Forms.Label lbTotal;
        private System.Windows.Forms.Label lbTotalValue;
        private System.Windows.Forms.Label lbRecent;
        private System.Windows.Forms.Label lbRecentValue;
    }
}
