
namespace He_Thong_Quan_Ly_Quan_Cafe
{
    partial class FormDoiMatKhau
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
            this.panel3 = new System.Windows.Forms.Panel();
            this.chkHienThi1 = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtMatKhauCu = new System.Windows.Forms.TextBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.chkHienThi2 = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtMatKhauMoi = new System.Windows.Forms.TextBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.chkHienThi3 = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtNhapLaiMatKhau = new System.Windows.Forms.TextBox();
            this.btnDoiMatKhau = new System.Windows.Forms.Button();
            this.btnDong = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnLamLai = new System.Windows.Forms.Button();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.chkHienThi1);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.txtMatKhauCu);
            this.panel3.Location = new System.Drawing.Point(14, 64);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(580, 50);
            this.panel3.TabIndex = 7;
            // 
            // chkHienThi1
            // 
            this.chkHienThi1.AutoSize = true;
            this.chkHienThi1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkHienThi1.Location = new System.Drawing.Point(401, 22);
            this.chkHienThi1.Name = "chkHienThi1";
            this.chkHienThi1.Size = new System.Drawing.Size(74, 23);
            this.chkHienThi1.TabIndex = 3;
            this.chkHienThi1.Text = "Hiển thị";
            this.chkHienThi1.UseVisualStyleBackColor = true;
            this.chkHienThi1.CheckedChanged += new System.EventHandler(this.chkHienThi1_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(57, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 19);
            this.label3.TabIndex = 0;
            this.label3.Text = "Mật khẩu cũ:";
            // 
            // txtMatKhauCu
            // 
            this.txtMatKhauCu.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMatKhauCu.Location = new System.Drawing.Point(180, 15);
            this.txtMatKhauCu.Name = "txtMatKhauCu";
            this.txtMatKhauCu.Size = new System.Drawing.Size(206, 26);
            this.txtMatKhauCu.TabIndex = 2;
            this.txtMatKhauCu.UseSystemPasswordChar = true;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.chkHienThi2);
            this.panel4.Controls.Add(this.label4);
            this.panel4.Controls.Add(this.txtMatKhauMoi);
            this.panel4.Location = new System.Drawing.Point(14, 134);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(580, 50);
            this.panel4.TabIndex = 9;
            // 
            // chkHienThi2
            // 
            this.chkHienThi2.AutoSize = true;
            this.chkHienThi2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkHienThi2.Location = new System.Drawing.Point(401, 17);
            this.chkHienThi2.Name = "chkHienThi2";
            this.chkHienThi2.Size = new System.Drawing.Size(74, 23);
            this.chkHienThi2.TabIndex = 4;
            this.chkHienThi2.Text = "Hiển thị";
            this.chkHienThi2.UseVisualStyleBackColor = true;
            this.chkHienThi2.CheckedChanged += new System.EventHandler(this.chkHienThi2_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(44, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(109, 19);
            this.label4.TabIndex = 0;
            this.label4.Text = "Mật khẩu mới:";
            // 
            // txtMatKhauMoi
            // 
            this.txtMatKhauMoi.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMatKhauMoi.Location = new System.Drawing.Point(180, 15);
            this.txtMatKhauMoi.Name = "txtMatKhauMoi";
            this.txtMatKhauMoi.Size = new System.Drawing.Size(206, 26);
            this.txtMatKhauMoi.TabIndex = 2;
            this.txtMatKhauMoi.UseSystemPasswordChar = true;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.chkHienThi3);
            this.panel5.Controls.Add(this.label5);
            this.panel5.Controls.Add(this.txtNhapLaiMatKhau);
            this.panel5.Location = new System.Drawing.Point(14, 206);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(580, 50);
            this.panel5.TabIndex = 10;
            // 
            // chkHienThi3
            // 
            this.chkHienThi3.AutoSize = true;
            this.chkHienThi3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkHienThi3.Location = new System.Drawing.Point(401, 17);
            this.chkHienThi3.Name = "chkHienThi3";
            this.chkHienThi3.Size = new System.Drawing.Size(74, 23);
            this.chkHienThi3.TabIndex = 4;
            this.chkHienThi3.Text = "Hiển thị";
            this.chkHienThi3.UseVisualStyleBackColor = true;
            this.chkHienThi3.CheckedChanged += new System.EventHandler(this.chkHienThi3_CheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(20, 18);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(136, 19);
            this.label5.TabIndex = 0;
            this.label5.Text = "Nhập lại mật khẩu:";
            // 
            // txtNhapLaiMatKhau
            // 
            this.txtNhapLaiMatKhau.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNhapLaiMatKhau.Location = new System.Drawing.Point(180, 15);
            this.txtNhapLaiMatKhau.Name = "txtNhapLaiMatKhau";
            this.txtNhapLaiMatKhau.Size = new System.Drawing.Size(206, 26);
            this.txtNhapLaiMatKhau.TabIndex = 2;
            this.txtNhapLaiMatKhau.UseSystemPasswordChar = true;
            // 
            // btnDoiMatKhau
            // 
            this.btnDoiMatKhau.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDoiMatKhau.Location = new System.Drawing.Point(246, 298);
            this.btnDoiMatKhau.Name = "btnDoiMatKhau";
            this.btnDoiMatKhau.Size = new System.Drawing.Size(107, 30);
            this.btnDoiMatKhau.TabIndex = 11;
            this.btnDoiMatKhau.Text = "Đổi mật khẩu";
            this.btnDoiMatKhau.UseVisualStyleBackColor = true;
            this.btnDoiMatKhau.Click += new System.EventHandler(this.btnDoiMatKhau_Click);
            // 
            // btnDong
            // 
            this.btnDong.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDong.Location = new System.Drawing.Point(374, 298);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(75, 30);
            this.btnDong.TabIndex = 12;
            this.btnDong.Text = "Đóng";
            this.btnDong.UseVisualStyleBackColor = true;
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(232, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 22);
            this.label1.TabIndex = 13;
            this.label1.Text = "Đổi mật khẩu";
            // 
            // btnLamLai
            // 
            this.btnLamLai.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLamLai.Location = new System.Drawing.Point(119, 298);
            this.btnLamLai.Name = "btnLamLai";
            this.btnLamLai.Size = new System.Drawing.Size(107, 30);
            this.btnLamLai.TabIndex = 14;
            this.btnLamLai.Text = "Làm lại";
            this.btnLamLai.UseVisualStyleBackColor = true;
            this.btnLamLai.Click += new System.EventHandler(this.btnLamLai_Click);
            // 
            // FormDoiMatKhau
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.ClientSize = new System.Drawing.Size(606, 348);
            this.Controls.Add(this.btnLamLai);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnDong);
            this.Controls.Add(this.btnDoiMatKhau);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Name = "FormDoiMatKhau";
            this.Text = "FormDoiMatKhau";
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtMatKhauCu;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtMatKhauMoi;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtNhapLaiMatKhau;
        private System.Windows.Forms.Button btnDoiMatKhau;
        private System.Windows.Forms.Button btnDong;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnLamLai;
        private System.Windows.Forms.CheckBox chkHienThi1;
        private System.Windows.Forms.CheckBox chkHienThi2;
        private System.Windows.Forms.CheckBox chkHienThi3;
    }
}