using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace He_Thong_Quan_Ly_Quan_Cafe
{
    public partial class FormDoiMatKhau : Form
    {
        public String Username = null;
        public String Password = null;
        SqlConnection conn = DBIO.conn();
        public FormDoiMatKhau()
        {
            InitializeComponent();
            conn.Open();
        }

        private  void btnDoiMatKhau_Click(object sender, EventArgs e)
        {
            String OldPass = txtMatKhauCu.Text;
            
            String NewPass = txtMatKhauMoi.Text;
            String ReNew = txtNhapLaiMatKhau.Text;
            if ((OldPass == Password) && (NewPass != "") && (NewPass == ReNew))
            {
                try
                {
                    int i = DBIO.updatePass(Username, NewPass);
                    if (i == 1) Password = NewPass;
                    MessageBox.Show("Đổi mật khẩu thành công!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi, không thực hiện được!");
                }
                
            }
            else
            {
                MessageBox.Show("Mật khẩu sai hoặc không trùng khớp!");
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLamLai_Click(object sender, EventArgs e)
        {
            txtMatKhauCu.Clear();
            txtMatKhauMoi.Clear();
            txtNhapLaiMatKhau.Clear();
        }

        private void chkHienThi3_CheckedChanged(object sender, EventArgs e)
        {
            if(chkHienThi3.Checked == true)
            {
                txtNhapLaiMatKhau.UseSystemPasswordChar = false;
            }
            else { txtNhapLaiMatKhau.UseSystemPasswordChar = true; }
        }

        private void chkHienThi2_CheckedChanged(object sender, EventArgs e)
        {
            if (chkHienThi2.Checked == true)
            {
                txtMatKhauMoi.UseSystemPasswordChar = false;
            }
            else { txtMatKhauMoi.UseSystemPasswordChar = true; }
        }

        private void chkHienThi1_CheckedChanged(object sender, EventArgs e)
        {
            if (chkHienThi1.Checked == true)
            {
                txtMatKhauCu.UseSystemPasswordChar = false;
            }
            else { txtMatKhauCu.UseSystemPasswordChar = true; }
        }
    }
}
