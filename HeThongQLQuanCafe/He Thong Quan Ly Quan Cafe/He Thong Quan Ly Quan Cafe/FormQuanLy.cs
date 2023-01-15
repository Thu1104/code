using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace He_Thong_Quan_Ly_Quan_Cafe
{
    public partial class FormQuanLy : Form
    {
        SqlDataAdapter da = null;
        DataTable dt = null;
        SqlCommand cmd = null;
        SqlDataReader dr = null;
        SqlConnection conn = DBIO.conn();
        public FormQuanLy()
        {
            InitializeComponent();
            conn.Open();
            hienThiHoaDonAll();
        }
        public void hienThiHoaDonAll()
        {
            string sql = "select * from HoaDon";
            da = new SqlDataAdapter(sql, conn);
            dt = new DataTable();
            dt.Clear();
            da.Fill(dt);
            dataHoaDon.AutoGenerateColumns = false;
            dataHoaDon.DataSource = dt;
        }
        private void loadToCBDSMon()
        {
            string sql = "SELECT * FROM Menu";
            cmd = new SqlCommand(sql, conn);
            dr = cmd.ExecuteReader();
            dt = new DataTable();
            dt.Load(dr);
            dr.Dispose();
            cbDSMon.DisplayMember = "TenMon";
            cbDSMon.ValueMember = "MaMon";
            cbDSMon.DataSource = dt;
        }
        private void loadToCBDSBan()
        {
            string sql = "SELECT * FROM Ban";
            cmd = new SqlCommand(sql, conn);
            dr = cmd.ExecuteReader();
            dt = new DataTable();
            dt.Load(dr);
            dr.Dispose();
            cbDSBan.DisplayMember = "TenBan";
            cbDSBan.ValueMember = "MaBan";
            cbDSBan.DataSource = dt;
        }
        private void toolDoiMatKhau_Click(object sender, EventArgs e)
        {
            FormDoiMatKhau form = new FormDoiMatKhau();
            form.Username = this.Username;
            form.Password = this.Password;
            form.ShowDialog();

        }

        private void toolDangXuat_Click(object sender, EventArgs e)
        {
            DialogResult traloi;
            traloi = MessageBox.Show("Bạn có chắc muốn thoát chương trình?", "Trả lời",
            MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (traloi == DialogResult.OK)
            {
                this.Hide();
                new FormQuanLy().ShowDialog();
                this.Close();
            }
                
        }

        private void toolAdmin_Click(object sender, EventArgs e)
        {
            FormAdmin admin = new FormAdmin();
            this.Hide();
            admin.ShowDialog();
            this.Show();
        }
        int UserRole = 0;
        String Username = null;
        String Password = null;
        private void FromQuanLy_Load(object sender, EventArgs e)
        {
            FormDangNhap frm = new FormDangNhap();
            frm.ShowDialog();
            this.UserRole = frm.UserRole;
            if (UserRole == 0)
            {
                toolAdmin.Enabled = false;
            }
            this.Username = frm.username;
            this.Password = frm.password;
            lbl_xinchao.Text = "Xin chào " + Username + "!";

            loadToCBDSMon();
            loadToCBDSBan();
        }
        private void reset_Order()
        {
            txtMaHD.Clear();
            hienThiHoaDonAll();
        }
        private void btnReset_Click(object sender, EventArgs e)
        {
            reset_HoaDon();
        }

        private void dataHoaDon_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowSelected = Convert.ToInt32(dataHoaDon.CurrentRow.Index);
            string MaHD = dataHoaDon.Rows[rowSelected].Cells[0].Value.ToString();
            Bill hd = null;

            try
            {
                hd = DBIO.getBill(MaHD);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi!");
            }
            if (hd != null)
            {
                txtMaHD.Text = hd.MaHD;
                cbDSBan.SelectedItem = hd.MaBan;
                cbDSMon.SelectedItem = hd.MaMon;
                nmSoLuong.Value = hd.SoLuong;
                txtTongTien.Text = hd.TongTien.ToString();
                

            }
        }

        private void dataHoaDon_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            btnThemMon.Enabled = false;
            int rowSelected = Convert.ToInt32(dataHoaDon.CurrentRow.Index);
            string MaHD = dataHoaDon.Rows[rowSelected].Cells[0].Value.ToString();
            Bill hd = null;
            int TTThanhToan = 0;
            string MaBan = dataHoaDon.Rows[rowSelected].Cells[1].Value.ToString();
            cbDSBan.Enabled = false;
            txtMaHD.Enabled = false;
            cbDSMon.Enabled = false;
            nmSoLuong.Enabled = false;
            nmSoLuong.Value = 0;
            cbDSBan.SelectedValue = MaBan;
            try
            {
                TTThanhToan = DBIO.tongHoaDon(MaBan);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi!");
            }            
            txtTongTien.Text = TTThanhToan.ToString();
        }
        private void reset_HoaDon()
        {
            btnThemMon.Enabled = true;
            txtMaHD.Enabled = true;
            cbDSBan.Enabled = true;
           
            cbDSMon.Enabled = true;
            nmSoLuong.Enabled = true;
            txtMaHD.Clear();
            txtTongTien.Clear();
            cbDSBan.SelectedIndex = 0;
            cbDSMon.SelectedIndex = 0;
            nmSoLuong.Value = 0;
            txtMaHD.Clear();
            
            hienThiHoaDonAll();
        }

        private void txtTongTien_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void btnThemMon_Click(object sender, EventArgs e)
        {
            Bill hd = new Bill();
            hd.MaHD = txtMaHD.Text;
            hd.MaBan = cbDSBan.SelectedValue.ToString();
            hd.MaMon = cbDSMon.SelectedValue.ToString();
            hd.SoLuong = Convert.ToInt32(nmSoLuong.Value);
            hd.TrangThai = 0;
            hd.TongTien = DBIO.giaMon(hd.MaMon) * hd.SoLuong;
            try
            {
                DBIO.themOrder(hd);
                MessageBox.Show("Thêm thông tin order thành công!");
            }
            catch (Exception ex)
            {
               MessageBox.Show("Trùng mã hóa đơn!");
            }
            DBIO.updateBanTrong(cbDSBan.SelectedValue.ToString(), 1);
            reset_HoaDon();
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            try
            {
                DBIO.updateBillTT(cbDSBan.SelectedValue.ToString());
                DBIO.updateBanTrong(cbDSBan.SelectedValue.ToString(), 0);
                MessageBox.Show("Thanh toán thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Thanh toán thất bại!");
            }
            hienThiHoaDonAll();
            reset_HoaDon();
        }
    }
}