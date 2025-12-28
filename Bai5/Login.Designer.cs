namespace Bai5
{
    partial class Login
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
            components = new System.ComponentModel.Container();
            tb_email = new TextBox();
            tb_psw = new TextBox();
            lb_title = new Label();
            lb_login = new Label();
            lb_email = new Label();
            lb_psw = new Label();
            btn_login = new Button();
            contextMenuStrip1 = new ContextMenuStrip(components);
            cb_showpsw = new CheckBox();
            SuspendLayout();
            // 
            // tb_email
            // 
            tb_email.Location = new Point(259, 128);
            tb_email.Name = "tb_email";
            tb_email.Size = new Size(328, 27);
            tb_email.TabIndex = 0;
            // 
            // tb_psw
            // 
            tb_psw.Location = new Point(259, 202);
            tb_psw.Name = "tb_psw";
            tb_psw.Size = new Size(328, 27);
            tb_psw.TabIndex = 1;
            // 
            // lb_title
            // 
            lb_title.AutoSize = true;
            lb_title.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 163);
            lb_title.Location = new Point(299, 9);
            lb_title.Name = "lb_title";
            lb_title.Size = new Size(250, 38);
            lb_title.TabIndex = 2;
            lb_title.Text = "HÔM NAY ĂN GÌ?";
            // 
            // lb_login
            // 
            lb_login.AutoSize = true;
            lb_login.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 163);
            lb_login.Location = new Point(358, 64);
            lb_login.Name = "lb_login";
            lb_login.Size = new Size(128, 31);
            lb_login.TabIndex = 3;
            lb_login.Text = "Đăng nhập";
            // 
            // lb_email
            // 
            lb_email.AutoSize = true;
            lb_email.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 163);
            lb_email.Location = new Point(193, 128);
            lb_email.Name = "lb_email";
            lb_email.Size = new Size(60, 28);
            lb_email.TabIndex = 4;
            lb_email.Text = "Email";
            // 
            // lb_psw
            // 
            lb_psw.AutoSize = true;
            lb_psw.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 163);
            lb_psw.Location = new Point(156, 198);
            lb_psw.Name = "lb_psw";
            lb_psw.Size = new Size(97, 28);
            lb_psw.TabIndex = 5;
            lb_psw.Text = "Password";
            // 
            // btn_login
            // 
            btn_login.Location = new Point(358, 246);
            btn_login.Name = "btn_login";
            btn_login.Size = new Size(116, 38);
            btn_login.TabIndex = 6;
            btn_login.Text = "Login";
            btn_login.UseVisualStyleBackColor = true;
            btn_login.Click += btn_login_Click;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.ImageScalingSize = new Size(20, 20);
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(61, 4);
            // 
            // cb_showpsw
            // 
            cb_showpsw.AutoSize = true;
            cb_showpsw.Location = new Point(453, 172);
            cb_showpsw.Name = "cb_showpsw";
            cb_showpsw.Size = new Size(134, 24);
            cb_showpsw.TabIndex = 12;
            cb_showpsw.Text = "Show password";
            cb_showpsw.UseVisualStyleBackColor = true;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(850, 319);
            Controls.Add(cb_showpsw);
            Controls.Add(btn_login);
            Controls.Add(lb_psw);
            Controls.Add(lb_email);
            Controls.Add(lb_login);
            Controls.Add(lb_title);
            Controls.Add(tb_psw);
            Controls.Add(tb_email);
            Name = "Login";
            Text = "Login";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox tb_email;
        private TextBox tb_psw;
        private Label lb_title;
        private Label lb_login;
        private Label lb_email;
        private Label lb_psw;
        private Button btn_login;
        private ContextMenuStrip contextMenuStrip1;
        private CheckBox cb_showpsw;
    }
}