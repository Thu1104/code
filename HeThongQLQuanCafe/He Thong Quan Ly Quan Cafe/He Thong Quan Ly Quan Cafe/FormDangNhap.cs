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
    public partial class FormDangNhap : Form
    {
        public bool UserClosing { set; get; }
        public int UserRole = 0;
        public  String username = "";
        public  String password = "";
        public FormDangNhap()
        {
            InitializeComponent();
            UserClosing = true;
        }

        private void FormDangNhap_Load(object sender, EventArgs e)
        {

        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            SqlConnection conn = DBIO.conn();
            try
            {
                //Mo ket noi
                conn.Open();
                String Username = txtUser.Text;
                String Password = txtPass.Text;
                //Tao chuoi truy van
                String sql = "select role from ThongTinDangNhap where username='" + Username + "' and password='" + Password + "'";
                //Truy van csdl
                SqlCommand cmd = new SqlCommand(sql, conn);
                //Luu du lieu tra ve
                SqlDataReader dta = cmd.ExecuteReader();

                if (dta.Read() == true)
                {
                    MessageBox.Show("Đăng nhập thành công!", "Thông báo");
                    UserRole = (int) dta.GetValue(0);

                    this.username = Username;
                    this.password = Password;

                    UserClosing = false;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Đăng nhập thất bại!");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Kết nối cơ sở dử liệu thất bại!");
            }
            /*FromQuanLy f = new FromQuanLy();
            this.Hide();
            f.ShowDialog();
            this.Show();*/
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            UserClosing = true;
            this.Close();
           
        }

        private void FormDangNhap_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (UserClosing)
            {
                Application.Exit();
            }
        }
    }
}
