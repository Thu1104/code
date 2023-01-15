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
    public partial class FormAdmin : Form
    {
        SqlDataAdapter da = null;
        DataTable dt = null;
        SqlCommand cmd = null;
        SqlDataReader dr = null;
        SqlConnection conn = DBIO.conn();
        public FormAdmin()
        {
            InitializeComponent();
            conn.Open();
            hienThiMenuAll();
            hienThiNhanVienAll();
            hienThiTaiKhoanAll();
            hienThiBanAll();
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
        public void hienThiMenuAll()
        {
            string sql = "select * from Menu";
            da = new SqlDataAdapter(sql, conn);
            dt = new DataTable();
            dt.Clear();
            da.Fill(dt);
            dataMenu.AutoGenerateColumns = false;
            dataMenu.DataSource = dt;
        }
        
        public void hienThiTaiKhoanAll()
        {
            string sql = "select * from ThongTinDangNhap";
            da = new SqlDataAdapter(sql, conn);
            dt = new DataTable();
            dt.Clear();
            da.Fill(dt);
            dataTaiKhoan.AutoGenerateColumns = false;
            dataTaiKhoan.DataSource = dt;
        }
        public void hienThiBanAll()
        {
            string sql = "select * from Ban";
            da = new SqlDataAdapter(sql, conn);
            dt = new DataTable();
            dt.Clear();
            da.Fill(dt);
            dataBan.AutoGenerateColumns = false;
            dataBan.DataSource = dt;
        }
        public void hienThiNhanVienAll()
        {
            string sql = "select * from NhanVien";
            da = new SqlDataAdapter(sql, conn);
            dt = new DataTable();
            dt.Clear();
            da.Fill(dt);
            dataNhanVien.AutoGenerateColumns = false;
            dataNhanVien.DataSource = dt;
        }


        private void chkNam_CheckedChanged(object sender, EventArgs e)
        {
           
        }

       

        private void FormAdmin_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'quanLyQuanCafeDataSet.ThongTinDangNhap' table. You can move, or remove it, as needed.
            loadToCBDanhMuc();
            loadToCBDanhMuc_add();
            loadToCBChucVu();

            txtMaMon.Clear();
            txtTenMon.Clear();
            cbDanhMuc_add.SelectedIndex = 0;
            txtGia.Clear();

            txtMaMon.Enabled = true;
            btnThemMenu.Enabled = true;
            btnSuaMenu.Enabled = false;
            btnXoaMenu.Enabled = false;

            btnSua.Enabled = false;
            btnXoa.Enabled = false;

            txtMaNV.Clear();
            txtTenNV.Clear();
            cbChucVu.SelectedIndex = 0;
            radNam.Checked = true;
            txtDiaChi.Clear();
            txtSoDienThoai.Clear();
            txtLuong.Clear();
            btnThem.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;

            txtUsername.Clear();
            txtPassword.Clear();
            txtMaNhanVien.Clear();
            cbLoaiTK.SelectedIndex = 0;
            btnThemTaiKhoan.Enabled = true;
            btnSuaTaiKhoan.Enabled = false;
            btnXoaTaiKhoan.Enabled = false;
        }

        private void loadToCBDanhMuc()
        {
            string sql = "SELECT * FROM DanhMuc";
            cmd = new SqlCommand(sql, conn);
            dr = cmd.ExecuteReader();
            dt = new DataTable();
            dt.Load(dr);
            dr.Dispose();
            cbDanhMuc.DisplayMember = "TenDanhMuc";
            cbDanhMuc.ValueMember = "MaDanhMuc";
            cbDanhMuc.DataSource = dt;
        }
        private void loadToCBDanhMuc_add() {
            string sql = "SELECT * FROM DanhMuc";
            cmd = new SqlCommand(sql, conn);
            dr = cmd.ExecuteReader();
            dt = new DataTable();
            dt.Load(dr);
            dr.Dispose();
            cbDanhMuc_add.DisplayMember = "TenDanhMuc";
            cbDanhMuc_add.ValueMember = "MaDanhMuc";
            cbDanhMuc_add.DataSource = dt;

        }
        private void reset()
        {
            txtMaMon.Clear();
            txtTenMon.Clear();
            txtGia.Clear();
            hienThiMenuAll();

            btnThemMenu.Enabled = true;
        }
        private void btnThemMenu_Click(object sender, EventArgs e)
        {
            Products stf = new Products();
            stf.MaMon = txtMaMon.Text;
            stf.TenMon = txtTenMon.Text;
            stf.Loai = cbDanhMuc_add.SelectedValue.ToString();
            stf.Gia =  Convert.ToInt32(txtGia.Text);
            try { 
                DBIO.themMon(stf);
                MessageBox.Show("Thêm món thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Thất bại!");
            }
            reset();
        }

        private void btnXoaMenu_Click(object sender, EventArgs e)
        {
            int rowSelected = Convert.ToInt32(dataMenu.CurrentRow.Index);
            String MaMon = dataMenu.Rows[rowSelected].Cells[0].Value.ToString();
            try
            {
                DBIO.xoaMon(MaMon);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Thất bại!");
            }
            reset();
        }
        public void hienThiMenu(string MaDanhMuc)
        {
            string sql = "select * from Menu where MaDanhMuc='"+MaDanhMuc+"'";
            da = new SqlDataAdapter(sql, conn);
            dt = new DataTable();
            dt.Clear();
            da.Fill(dt);
            dataMenu.AutoGenerateColumns = false;
            dataMenu.DataSource = dt;
        }
        private void cbDanhMuc_SelectedIndexChanged(object sender, EventArgs e)
        {
            string MaDanhMuc = cbDanhMuc.SelectedValue.ToString();
            if (chkTimKiem.Checked)
            {
                hienThiMenu(MaDanhMuc);
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            hienThiMenuAll();
        }

        private void btnSuaMenu_Click(object sender, EventArgs e)
        {
            Products prdct = new Products();
            prdct.MaMon = txtMaMon.Text;
            prdct.TenMon = txtTenMon.Text;
            prdct.Loai = cbDanhMuc_add.SelectedValue.ToString();
            prdct.Gia = Convert.ToInt32(txtGia.Text);
            try
            {
                DBIO.updateMon(prdct);
                MessageBox.Show("Cập nhật thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi");
            }
            reset();
            txtMaMon.Enabled = true;
        }

        private void btnThoatMenu_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        private void reset_NhanVien()
        {
            txtMaNV.Clear();
            txtTenNV.Clear();
            txtDiaChi.Clear();
            txtSoDienThoai.Clear();
            txtLuong.Clear();
            hienThiNhanVienAll();

            btnThem.Enabled = true;
        }
        private void loadToCBChucVu()
        {
            string sql = "SELECT * FROM ChucVu";
            cmd = new SqlCommand(sql, conn);
            dr = cmd.ExecuteReader();
            dt = new DataTable();
            dt.Clear();
            dt.Load(dr);
            dr.Dispose();
            cbChucVu.DisplayMember = "ChucVu";
            cbChucVu.ValueMember = "MaCV";
            cbChucVu.DataSource = dt;
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            Staff stf = new Staff();
            stf.MaNV = txtMaNV.Text;
            stf.TenNV = txtTenNV.Text;
            stf.MaCV = cbChucVu.SelectedValue.ToString();
            stf.NamSinh = dtimeNamSinh.Value;
            if (this.radNam.Checked == true)
                stf.GioiTinh = radNam.Text;
            else stf.GioiTinh = radNu.Text;
            stf.DiaChi = txtDiaChi.Text;
            stf.SoDienThoai = txtSoDienThoai.Text;
            stf.Luong = Convert.ToInt32(txtLuong.Text); ;
            try
            {
                DBIO.themNhanVien(stf);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Thất bại!");
            }
            reset_NhanVien();
        }
        private void reset_Ban()
        {
            txtMaBan.Clear();
            txtTenBan.Clear();
            hienThiBanAll();

            btnThemBan.Enabled = true;
        }
        private void btnThemBan_Click(object sender, EventArgs e)
        {
            Tables tb = new Tables();
            tb.MaBan = txtMaBan.Text;
            tb.TenBan = txtTenBan.Text;
            tb.TrangThai = Convert.ToInt32(cbTrangThai.SelectedItem);
            try
            {
                DBIO.themBan(tb);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Thất bại!");
            }
            reset_Ban();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            int rowSelected = Convert.ToInt32(dataNhanVien.CurrentRow.Index);
            String MaNV = dataNhanVien.Rows[rowSelected].Cells[0].Value.ToString();
            try
            {
                DBIO.xoaNhanVien(MaNV);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Thất bại!");
            }
            reset_NhanVien();
        }

        private void btnThoatNV_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void reset_TaiKhoan()
        {
            txtUsername.Clear();
            txtPassword.Clear();
            txtMaNV.Clear();
            hienThiTaiKhoanAll();

            btnThemTaiKhoan.Enabled = true;
        }
        private void btnThemTaiKhoan_Click(object sender, EventArgs e)
        {
            Account tk = new Account();
            tk.username = txtUsername.Text;
            tk.password = txtPassword.Text;
            tk.MaNV = txtMaNhanVien.Text;
            tk.role = Convert.ToInt32(cbLoaiTK.SelectedItem);
           
            try
            {
                DBIO.themTaiKhoan(tk);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Thất bại!");
            }
            reset_TaiKhoan();
        }

        private void btnXoaBan_Click(object sender, EventArgs e)
        {
            int rowSelected = Convert.ToInt32(dataBan.CurrentRow.Index);
            String MaBan = dataBan.Rows[rowSelected].Cells[0].Value.ToString();
            try
            {
                DBIO.xoaBan(MaBan);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Thất bại!");
            }
            reset_Ban();
        }

        private void btnThoatBan_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnThoatTK_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnXoaTaiKhoan_Click(object sender, EventArgs e)
        {
            int rowSelected = Convert.ToInt32(dataTaiKhoan.CurrentRow.Index);
            String user = dataTaiKhoan.Rows[rowSelected].Cells[0].Value.ToString();
            try
            {
                DBIO.xoaTaiKhoan(user);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Thất bại!");
            }
            reset_TaiKhoan();
        }

        private void dataMenu_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowSelected = Convert.ToInt32(dataMenu.CurrentRow.Index);
            String MaMon = dataMenu.Rows[rowSelected].Cells[0].Value.ToString();
            Products prdct = null;
            
            try
            {
                prdct = DBIO.getProduct(MaMon);
            } 
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi!");
            }
            if (prdct != null)
            {
                txtMaMon.Text = prdct.MaMon;
                txtTenMon.Text = prdct.TenMon;
                cbDanhMuc_add.SelectedValue = prdct.Loai;
                txtGia.Text = prdct.Gia.ToString();
            }
        }

        private void dataMenu_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            btnThemMenu.Enabled = false;
            btnSuaMenu.Enabled = true;
            btnXoaMenu.Enabled = true;
            int rowSelected = Convert.ToInt32(dataMenu.CurrentRow.Index);
            String MaMon = dataMenu.Rows[rowSelected].Cells[0].Value.ToString();
            Products prdct = null;

            try
            {
                prdct = DBIO.getProduct(MaMon);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi!");
            }
            if (prdct != null)
            {
                txtMaMon.Text = prdct.MaMon;
                txtMaMon.Enabled = false;
                txtTenMon.Text = prdct.TenMon;
                cbDanhMuc_add.SelectedValue = prdct.Loai;
                txtGia.Text = prdct.Gia.ToString();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            Staff stf = new Staff();
            stf.MaNV = txtMaNV.Text;
            stf.TenNV = txtTenNV.Text;
            stf.MaCV = cbChucVu.SelectedValue.ToString();
            stf.NamSinh = dtimeNamSinh.Value;
            if (this.radNam.Checked == true)
                stf.GioiTinh = radNam.Text;
            else stf.GioiTinh = radNu.Text;
            stf.DiaChi = txtDiaChi.Text;
            stf.SoDienThoai = txtSoDienThoai.Text;
            stf.Luong = Convert.ToInt32(txtLuong.Text);
            try
            {
                DBIO.updateNhanVien(stf);
                MessageBox.Show("Cập nhật thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi");
            }
            reset_NhanVien();
            txtMaNV.Enabled = true;
        }

        private void dataNhanVien_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            btnThem.Enabled = false;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            int rowSelected = Convert.ToInt32(dataNhanVien.CurrentRow.Index);
            String MaNV = dataNhanVien.Rows[rowSelected].Cells[0].Value.ToString();
            Staff stf = null;

            try
            {
                stf = DBIO.getStaff(MaNV);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi!");
            }
            if (stf != null)
            {
                txtMaNV.Text = stf.MaNV;
                txtTenNV.Text = stf.TenNV;
                cbChucVu.SelectedValue = stf.MaCV;
                dtimeNamSinh.Value = stf.NamSinh;
                if (stf.GioiTinh == "Nam")
                    radNam.Checked = true;
                else radNu.Checked = true;
                txtDiaChi.Text = stf.DiaChi;
                txtSoDienThoai.Text = stf.SoDienThoai;
                txtLuong.Text =stf.Luong.ToString();
            }
        }

        private void dataNhanVien_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            btnThem.Enabled = false;
            int rowSelected = Convert.ToInt32(dataNhanVien.CurrentRow.Index);
            String MaNV = dataNhanVien.Rows[rowSelected].Cells[0].Value.ToString();
            Staff stf = null;

            try
            {
                stf = DBIO.getStaff(MaNV);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi!");
            }
            if (stf != null)
            {
                txtMaNV.Text = stf.MaNV;
                txtMaNV.Enabled = false;
                txtTenNV.Text = stf.TenNV;
                cbChucVu.SelectedValue = stf.MaCV;
                dtimeNamSinh.Value = stf.NamSinh;
                if (stf.GioiTinh == "Nam")
                    radNam.Checked = true;
                else radNu.Checked = true;
                txtDiaChi.Text = stf.DiaChi;
                txtSoDienThoai.Text = stf.SoDienThoai;
            }
        }

        private void btnSuaTaiKhoan_Click(object sender, EventArgs e)
        {
            Account tk = new Account();
            tk.username = txtUsername.Text;
            tk.password = txtPassword.Text;
            tk.MaNV = txtMaNhanVien.Text;
            tk.role = Convert.ToInt32(cbLoaiTK.SelectedItem);
            try
            {
                DBIO.updateTaiKhoan(tk);
                MessageBox.Show("Cập nhật thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi");
            }
            reset_TaiKhoan();
            txtUsername.Enabled = true;
        }

        private void dataTaiKhoan_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            btnThemTaiKhoan.Enabled = false;
            btnSuaTaiKhoan.Enabled = true;
            btnXoaTaiKhoan.Enabled = true;
            int rowSelected = Convert.ToInt32(dataTaiKhoan.CurrentRow.Index);
            String username = dataTaiKhoan.Rows[rowSelected].Cells[0].Value.ToString();
            Account tk = null;

            try
            {
                tk = DBIO.getAccount(username);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi!");
            }
            if (tk != null)
            {
                txtUsername.Text = tk.username;
                txtPassword.Text = tk.password;
                txtMaNhanVien.Text = tk.MaNV;
                cbLoaiTK.SelectedItem = tk.role;
              
            }
        }

        private void dataTaiKhoan_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            btnThemTaiKhoan.Enabled = false;
            btnSuaTaiKhoan.Enabled = true;
            btnXoaTaiKhoan.Enabled = true;
            btnThemTaiKhoan.Enabled = false;
            int rowSelected = Convert.ToInt32(dataTaiKhoan.CurrentRow.Index);
            String username = dataTaiKhoan.Rows[rowSelected].Cells[0].Value.ToString();
            Account tk = null;

            try
            {
                tk = DBIO.getAccount(username);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi!");
            }
            if (tk != null)
            {
                txtUsername.Text = tk.username;
                txtUsername.Enabled = false;
                txtPassword.Text = tk.password;
                txtMaNhanVien.Text = tk.MaNV;
                txtMaNV.Enabled = false;
                cbLoaiTK.SelectedIndex = tk.role;
            }
        }

        private void btnSuaBan_Click(object sender, EventArgs e)
        {
            Tables tb = new Tables();
            tb.MaBan = txtMaBan.Text;
            tb.TenBan = txtTenBan.Text;
            tb.TrangThai = Convert.ToInt32(cbTrangThai.SelectedItem);
            try
            {
                DBIO.updateBan(tb);
                MessageBox.Show("Cập nhật thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi");
            }
            reset_Ban();
            txtMaBan.Enabled = true;
        }

        private void dataBan_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowSelected = Convert.ToInt32(dataBan.CurrentRow.Index);
            String MaBan = dataBan.Rows[rowSelected].Cells[0].Value.ToString();
            Tables tb = null;

            try
            {
                tb = DBIO.getTables(MaBan);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi!");
            }
            if (tb != null)
            {
                txtMaBan.Text = tb.MaBan;
                txtTenBan.Text = tb.TenBan;
                cbTrangThai.SelectedItem = tb.TrangThai;

            }
        }

        private void dataBan_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            btnThemBan.Enabled = false;
            int rowSelected = Convert.ToInt32(dataBan.CurrentRow.Index);
            String MaBan = dataBan.Rows[rowSelected].Cells[0].Value.ToString();
            Tables tb = null;

            try
            {
                tb = DBIO.getTables(MaBan);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi!");
            }
            if (tb != null)
            {
                txtMaBan.Text = tb.MaBan;
                txtMaBan.Enabled = false;
                txtTenBan.Text = tb.TenBan;
                cbTrangThai.SelectedIndex = tb.TrangThai;
            }
        }

        private void btnThoatDT_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLamLai_Click(object sender, EventArgs e)
        {
            txtMaMon.Clear();
            txtTenMon.Clear();
            cbDanhMuc_add.SelectedIndex = 0;
            txtGia.Clear();
            
            txtMaMon.Enabled = true;
            btnThemMenu.Enabled = true;
            btnSuaMenu.Enabled = false;
            btnXoaMenu.Enabled = false;

        }

        private void btnLamLai_NV_Click(object sender, EventArgs e)
        {
            txtMaNV.Clear();
            txtTenNV.Clear();
            cbChucVu.SelectedIndex = 0;
            radNam.Checked = true;
            txtDiaChi.Clear();
            txtSoDienThoai.Clear();
            txtLuong.Clear();
            btnThem.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
        }

        private void btnLamLai_TK_Click(object sender, EventArgs e)
        {
            txtUsername.Clear();
            txtPassword.Clear();
            txtMaNhanVien.Clear();
            cbLoaiTK.SelectedIndex = 0;
            txtUsername.Enabled = true;
            btnThemTaiKhoan.Enabled = true;
            btnSuaTaiKhoan.Enabled = false;
            btnXoaTaiKhoan.Enabled = false;
        }
    }
}
