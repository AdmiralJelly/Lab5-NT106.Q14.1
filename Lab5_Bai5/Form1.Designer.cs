namespace Lab5_Bai5
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
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.btnSync = new System.Windows.Forms.Button();
            this.btnRandom = new System.Windows.Forms.Button();
            this.lblFoodName = new System.Windows.Forms.Label();
            this.lblContributor = new System.Windows.Forms.Label();
            this.pbFoodImage = new System.Windows.Forms.PictureBox();
            this.lvwContributions = new System.Windows.Forms.ListView();
            this.colContributor = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDish = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbFoodImage)).BeginInit();
            this.SuspendLayout();

            // Label Email/Username
            this.label1.Location = new System.Drawing.Point(20, 20);
            this.label1.Text = "Username:";
            this.label1.Size = new System.Drawing.Size(70, 20);

            // txtEmail
            this.txtEmail.Location = new System.Drawing.Point(100, 17);
            this.txtEmail.Size = new System.Drawing.Size(200, 20);

            // Label Password
            this.label2.Location = new System.Drawing.Point(20, 50);
            this.label2.Text = "Password:";
            this.label2.Size = new System.Drawing.Size(70, 20);

            // txtPassword
            this.txtPassword.Location = new System.Drawing.Point(100, 47);
            this.txtPassword.Size = new System.Drawing.Size(200, 20);
            this.txtPassword.PasswordChar = '*';

            // btnSync (Tải đóng góp)
            this.btnSync.Location = new System.Drawing.Point(320, 15);
            this.btnSync.Size = new System.Drawing.Size(120, 55);
            this.btnSync.Text = "Tải đóng góp";
            this.btnSync.Click += new System.EventHandler(this.btnSync_Click);

    
            this.lvwContributions.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { this.colContributor, this.colDish });
            this.lvwContributions.FullRowSelect = true;
            this.lvwContributions.GridLines = true;
            this.lvwContributions.Location = new System.Drawing.Point(20, 90);
            this.lvwContributions.Size = new System.Drawing.Size(350, 420);
            this.lvwContributions.TabIndex = 7;
            this.lvwContributions.UseCompatibleStateImageBehavior = false;
            this.lvwContributions.View = System.Windows.Forms.View.Details;
            this.lvwContributions.SelectedIndexChanged += new System.EventHandler(this.lvwContributions_SelectedIndexChanged);

            this.colContributor.Text = "Người đóng góp";
            this.colContributor.Width = 150;
            this.colDish.Text = "Món ăn";
            this.colDish.Width = 180;

            // Khu vực hiển thị chi tiết bên phải
            this.lblFoodName.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Bold);
            this.lblFoodName.Location = new System.Drawing.Point(400, 90);
            this.lblFoodName.Size = new System.Drawing.Size(360, 40);
            this.lblFoodName.Text = "Tên món ăn";
            this.lblFoodName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            this.lblContributor.Location = new System.Drawing.Point(400, 135);
            this.lblContributor.Size = new System.Drawing.Size(360, 20);
            this.lblContributor.Text = "Đóng góp bởi: ";
            this.lblContributor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            this.pbFoodImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbFoodImage.Location = new System.Drawing.Point(400, 170);
            this.pbFoodImage.Size = new System.Drawing.Size(360, 240);
            this.pbFoodImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;

            // btnRandom
            this.btnRandom.Location = new System.Drawing.Point(480, 450);
            this.btnRandom.Size = new System.Drawing.Size(200, 60);
            this.btnRandom.Text = "HÔM NAY ĂN GÌ?";
            this.btnRandom.Click += new System.EventHandler(this.btnRandom_Click);

            // Form1
            this.ClientSize = new System.Drawing.Size(800, 550);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lvwContributions);
            this.Controls.Add(this.pbFoodImage);
            this.Controls.Add(this.lblContributor);
            this.Controls.Add(this.lblFoodName);
            this.Controls.Add(this.btnRandom);
            this.Controls.Add(this.btnSync);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtEmail);
            this.Name = "Form1";
            this.Text = "Hôm nay ăn gì? (Phiên bản nâng cao) - Lab 5";
            ((System.ComponentModel.ISupportInitialize)(this.pbFoodImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Button btnSync;
        private System.Windows.Forms.Button btnRandom;
        private System.Windows.Forms.Label lblFoodName;
        private System.Windows.Forms.Label lblContributor;
        private System.Windows.Forms.PictureBox pbFoodImage;
        private System.Windows.Forms.ListView lvwContributions;
        private System.Windows.Forms.ColumnHeader colContributor;
        private System.Windows.Forms.ColumnHeader colDish;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}