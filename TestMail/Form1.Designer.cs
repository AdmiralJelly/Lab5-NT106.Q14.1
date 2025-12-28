namespace TestMail
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.label4 = new System.Windows.Forms.Label();
            this.txtMyEmail = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtAppPass = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSenderName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtFoodName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtImageLink = new System.Windows.Forms.TextBox();
            this.btnSendTest = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // Gmail đăng nhập
            this.label4.Location = new System.Drawing.Point(30, 25);
            this.label4.Size = new System.Drawing.Size(100, 20);
            this.label4.Text = "Gmail :";

            this.txtMyEmail.Location = new System.Drawing.Point(150, 22);
            this.txtMyEmail.Size = new System.Drawing.Size(350, 25);

            // App Password
            this.label5.Location = new System.Drawing.Point(30, 65);
            this.label5.Size = new System.Drawing.Size(100, 20);
            this.label5.Text = "Password:";

            this.txtAppPass.Location = new System.Drawing.Point(150, 62);
            this.txtAppPass.PasswordChar = '*';
            this.txtAppPass.Size = new System.Drawing.Size(350, 25);

            // Tên người gửi
            this.label1.Location = new System.Drawing.Point(30, 120);
            this.label1.Size = new System.Drawing.Size(250, 20);
            this.label1.Text = "Tên hiển thị (để trống nếu ẩn danh):";

            this.txtSenderName.Location = new System.Drawing.Point(30, 145);
            this.txtSenderName.Size = new System.Drawing.Size(470, 25);

            // Tên món ăn
            this.label2.Location = new System.Drawing.Point(30, 200);
            this.label2.Size = new System.Drawing.Size(200, 20);
            this.label2.Text = "Tên món ăn đóng góp:";

            this.txtFoodName.Location = new System.Drawing.Point(30, 225);
            this.txtFoodName.Size = new System.Drawing.Size(470, 25);

            // Link hình ảnh
            this.label3.Location = new System.Drawing.Point(30, 280);
            this.label3.Size = new System.Drawing.Size(200, 20);
            this.label3.Text = "Link hình ảnh (URL):";

            this.txtImageLink.Location = new System.Drawing.Point(30, 305);
            this.txtImageLink.Size = new System.Drawing.Size(470, 25);

            // Nút Gửi (Đã sửa lỗi tên từ btnSync thành btnSendTest)
            this.btnSendTest.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnSendTest.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.btnSendTest.Location = new System.Drawing.Point(175, 370);
            this.btnSendTest.Size = new System.Drawing.Size(200, 50);
            this.btnSendTest.Text = "GỬI ĐÓNG GÓP";
            this.btnSendTest.UseVisualStyleBackColor = false;
            this.btnSendTest.Click += new System.EventHandler(this.btnSendTest_Click);

            // Cấu hình Form
            this.ClientSize = new System.Drawing.Size(550, 450);
            this.Controls.Add(this.txtAppPass);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtMyEmail);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnSendTest);
            this.Controls.Add(this.txtImageLink);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtFoodName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtSenderName);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Gửi Mail Đóng Góp - Test Mail";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSenderName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtFoodName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtImageLink;
        private System.Windows.Forms.Button btnSendTest;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtMyEmail;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtAppPass;
    }
}