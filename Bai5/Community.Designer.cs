namespace Bai5
{
    partial class Community
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
            lb_psw = new Label();
            lb_email = new Label();
            tb_psw = new TextBox();
            tb_email = new TextBox();
            cb_showpsw = new CheckBox();
            lb_foodname = new Label();
            lb_image = new Label();
            tb_foodname = new TextBox();
            tb_image = new TextBox();
            btn_src = new Button();
            btn_add = new Button();
            ptb_donggop = new PictureBox();
            ptb_image = new PictureBox();
            rtb_info = new RichTextBox();
            btn_find = new Button();
            label1 = new Label();
            btn_reset = new Button();
            btn_reset2 = new Button();
            btn_dropdb = new Button();
            ((System.ComponentModel.ISupportInitialize)ptb_donggop).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ptb_image).BeginInit();
            SuspendLayout();
            // 
            // lb_psw
            // 
            lb_psw.AutoSize = true;
            lb_psw.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 163);
            lb_psw.Location = new Point(2, 71);
            lb_psw.Name = "lb_psw";
            lb_psw.Size = new Size(97, 28);
            lb_psw.TabIndex = 10;
            lb_psw.Text = "Password";
            // 
            // lb_email
            // 
            lb_email.AutoSize = true;
            lb_email.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 163);
            lb_email.Location = new Point(2, -2);
            lb_email.Name = "lb_email";
            lb_email.Size = new Size(60, 28);
            lb_email.TabIndex = 9;
            lb_email.Text = "Email";
            // 
            // tb_psw
            // 
            tb_psw.Location = new Point(2, 102);
            tb_psw.Name = "tb_psw";
            tb_psw.ReadOnly = true;
            tb_psw.Size = new Size(328, 27);
            tb_psw.TabIndex = 8;
            // 
            // tb_email
            // 
            tb_email.Location = new Point(2, 29);
            tb_email.Name = "tb_email";
            tb_email.ReadOnly = true;
            tb_email.Size = new Size(328, 27);
            tb_email.TabIndex = 7;
            tb_email.TextChanged += tb_email_TextChanged;
            // 
            // cb_showpsw
            // 
            cb_showpsw.AutoSize = true;
            cb_showpsw.Location = new Point(196, 77);
            cb_showpsw.Name = "cb_showpsw";
            cb_showpsw.Size = new Size(134, 24);
            cb_showpsw.TabIndex = 11;
            cb_showpsw.Text = "Show password";
            cb_showpsw.UseVisualStyleBackColor = true;
            // 
            // lb_foodname
            // 
            lb_foodname.AutoSize = true;
            lb_foodname.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 163);
            lb_foodname.Location = new Point(501, 23);
            lb_foodname.Name = "lb_foodname";
            lb_foodname.Size = new Size(134, 31);
            lb_foodname.TabIndex = 12;
            lb_foodname.Text = "Tên món ăn";
            // 
            // lb_image
            // 
            lb_image.AutoSize = true;
            lb_image.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 163);
            lb_image.Location = new Point(514, 68);
            lb_image.Name = "lb_image";
            lb_image.Size = new Size(107, 31);
            lb_image.TabIndex = 13;
            lb_image.Text = "Hình ảnh";
            // 
            // tb_foodname
            // 
            tb_foodname.Location = new Point(641, 27);
            tb_foodname.Name = "tb_foodname";
            tb_foodname.Size = new Size(328, 27);
            tb_foodname.TabIndex = 14;
            // 
            // tb_image
            // 
            tb_image.Location = new Point(641, 71);
            tb_image.Name = "tb_image";
            tb_image.ReadOnly = true;
            tb_image.Size = new Size(288, 27);
            tb_image.TabIndex = 15;
            // 
            // btn_src
            // 
            btn_src.Location = new Point(935, 71);
            btn_src.Name = "btn_src";
            btn_src.Size = new Size(34, 30);
            btn_src.TabIndex = 16;
            btn_src.Text = "...";
            btn_src.UseVisualStyleBackColor = true;
            // 
            // btn_add
            // 
            btn_add.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 163);
            btn_add.Location = new Point(641, 272);
            btn_add.Name = "btn_add";
            btn_add.Size = new Size(213, 41);
            btn_add.TabIndex = 17;
            btn_add.Text = "Đóng góp món ăn";
            btn_add.UseVisualStyleBackColor = true;
            // 
            // ptb_donggop
            // 
            ptb_donggop.Location = new Point(641, 104);
            ptb_donggop.Name = "ptb_donggop";
            ptb_donggop.Size = new Size(288, 162);
            ptb_donggop.TabIndex = 18;
            ptb_donggop.TabStop = false;
            // 
            // ptb_image
            // 
            ptb_image.Location = new Point(641, 341);
            ptb_image.Name = "ptb_image";
            ptb_image.Size = new Size(288, 162);
            ptb_image.TabIndex = 19;
            ptb_image.TabStop = false;
            // 
            // rtb_info
            // 
            rtb_info.Location = new Point(22, 341);
            rtb_info.Name = "rtb_info";
            rtb_info.Size = new Size(613, 162);
            rtb_info.TabIndex = 20;
            rtb_info.Text = "";
            // 
            // btn_find
            // 
            btn_find.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 163);
            btn_find.Location = new Point(196, 274);
            btn_find.Name = "btn_find";
            btn_find.Size = new Size(235, 39);
            btn_find.TabIndex = 21;
            btn_find.Text = "Tìm món ăn hôm nay";
            btn_find.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 163);
            label1.Location = new Point(215, 240);
            label1.Name = "label1";
            label1.Size = new Size(202, 31);
            label1.TabIndex = 22;
            label1.Text = "HÔM NAY ĂN GÌ?";
            // 
            // btn_reset
            // 
            btn_reset.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 163);
            btn_reset.Location = new Point(262, 509);
            btn_reset.Name = "btn_reset";
            btn_reset.Size = new Size(97, 39);
            btn_reset.TabIndex = 23;
            btn_reset.Text = "Reset";
            btn_reset.UseVisualStyleBackColor = true;
            // 
            // btn_reset2
            // 
            btn_reset2.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 163);
            btn_reset2.Location = new Point(860, 274);
            btn_reset2.Name = "btn_reset2";
            btn_reset2.Size = new Size(69, 39);
            btn_reset2.TabIndex = 24;
            btn_reset2.Text = "Xóa";
            btn_reset2.UseVisualStyleBackColor = true;
            // 
            // btn_dropdb
            // 
            btn_dropdb.Location = new Point(2, 135);
            btn_dropdb.Name = "btn_dropdb";
            btn_dropdb.Size = new Size(136, 34);
            btn_dropdb.TabIndex = 25;
            btn_dropdb.Text = "Xóa Database";
            btn_dropdb.UseVisualStyleBackColor = true;
            btn_dropdb.Click += btn_dropdb_Click;
            // 
            // Community
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(986, 564);
            Controls.Add(btn_dropdb);
            Controls.Add(btn_reset2);
            Controls.Add(btn_reset);
            Controls.Add(label1);
            Controls.Add(btn_find);
            Controls.Add(rtb_info);
            Controls.Add(ptb_image);
            Controls.Add(ptb_donggop);
            Controls.Add(btn_add);
            Controls.Add(btn_src);
            Controls.Add(tb_image);
            Controls.Add(tb_foodname);
            Controls.Add(lb_image);
            Controls.Add(lb_foodname);
            Controls.Add(cb_showpsw);
            Controls.Add(lb_psw);
            Controls.Add(lb_email);
            Controls.Add(tb_psw);
            Controls.Add(tb_email);
            Name = "Community";
            Text = "Community";
            ((System.ComponentModel.ISupportInitialize)ptb_donggop).EndInit();
            ((System.ComponentModel.ISupportInitialize)ptb_image).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lb_psw;
        private Label lb_email;
        private TextBox tb_psw;
        private TextBox tb_email;
        private CheckBox cb_showpsw;
        private Label lb_foodname;
        private Label lb_image;
        private TextBox tb_foodname;
        private TextBox tb_image;
        private Button btn_src;
        private Button btn_add;
        private PictureBox ptb_donggop;
        private PictureBox ptb_image;
        private RichTextBox rtb_info;
        private Button btn_find;
        private Label label1;
        private Button btn_reset;
        private Button btn_reset2;
        private Button btn_dropdb;
    }
}