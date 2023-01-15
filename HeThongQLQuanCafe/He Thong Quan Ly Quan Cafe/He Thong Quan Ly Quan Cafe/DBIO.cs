using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace He_Thong_Quan_Ly_Quan_Cafe
{
    class DBIO

    {

        public static SqlConnection conn()
        {
            return new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=QuanLyQuanCafe;Integrated Security=True");
        }

        public static int tongHoaDon(String MaBan)
        {
            int TTThanhToan = 0;
            SqlConnection con = conn();
            con.Open();
            string sql = "SELECT SUM(TongTien) as TTThanhToan FROM [dbo].[HoaDon] where MaBan = '"+ MaBan +"' AND TrangThai = 0  Group by MaBan";
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable();
            dt.Clear();
            da.Fill(dt);
            try
            {
                TTThanhToan = Convert.ToInt32(dt.Rows[0]["TTThanhToan"]);
            } catch (Exception)
            {
                TTThanhToan = 0;
            }
            return TTThanhToan;
        }
        public static int giaMon(string MaMon)
        {
            int gia = 0;
            SqlConnection con = conn();
            con.Open();
            string sql = "select Gia from Menu where MaMon = '" + MaMon + "'";
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable();
            dt.Clear();
            da.Fill(dt);
            gia = Convert.ToInt32(dt.Rows[0]["Gia"]);
            return gia;
        }
        public static void updateBillTT(String MaBan)
        {
            SqlConnection con = conn();
            con.Open();
            String sql = "UPDATE [dbo].[HoaDon] SET [TrangThai] = " + 1 + " WHERE [MaBan] ='" + MaBan + "'";
            SqlCommand cmd = new SqlCommand();
            cmd = con.CreateCommand();
            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();
        }
        public static void updateBanTrong(String MaBan, int trangthai )
        {
            SqlConnection con = conn();
            con.Open();
            String sql = "UPDATE [dbo].[Ban] SET [TrangThai] = " + trangthai + " WHERE [MaBan] ='" + MaBan + "'";
            SqlCommand cmd = new SqlCommand();
            cmd = con.CreateCommand();
            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();
        }
        public static Bill getBill(String MaHD)
        {
            Bill hd = new Bill();
            SqlConnection con = conn();
            con.Open();
            string sql = "select * from HoaDon where MaHD = '" + MaHD + "'";
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable();
            dt.Clear();
            da.Fill(dt);

            hd.MaHD = dt.Rows[0]["MaHD"].ToString();
            hd.MaBan = dt.Rows[0]["MaBan"].ToString();
            hd.MaMon = dt.Rows[0]["MaMon"].ToString();
            hd.SoLuong = Convert.ToInt32(dt.Rows[0]["SoLuong"]);
            hd.TrangThai = Convert.ToInt32(dt.Rows[0]["TrangThai"]);
            hd.TongTien = Convert.ToInt32(dt.Rows[0]["TongTien"]);

            return hd;
        }
        public static void updateBill(Bill hd)
        {
            SqlConnection con = conn();
            con.Open();
            String sql = "UPDATE [dbo].[HoaDon] SET [MaBan] = '" + hd.MaBan + "'WHERE [MaHD] ='" + hd.MaHD + "'";
            SqlCommand cmd = new SqlCommand();
            cmd = con.CreateCommand();
            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();
        }
        public static Tables getTables(string MaBan)
        {
            Tables tb = new Tables();
            SqlConnection con = conn();
            con.Open();
            string sql = "select * from Ban where MaBan = '" + MaBan + "'";
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable();
            dt.Clear();
            da.Fill(dt);

            tb.MaBan = dt.Rows[0]["MaBan"].ToString();
            tb.TenBan = dt.Rows[0]["TenBan"].ToString();
            tb.TrangThai = Convert.ToInt32(dt.Rows[0]["TrangThai"]);

            return tb;
        }
        public static void updateBan(Tables tb)
        {
            SqlConnection con = conn();
            con.Open();
            String sql = "UPDATE [dbo].[Ban] SET [TenBan] = '" + tb.TenBan + "', [TrangThai] = '" + tb.TrangThai + "' WHERE [MaBan] ='" + tb.MaBan + "'";
            SqlCommand cmd = new SqlCommand();
            cmd = con.CreateCommand();
            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();
        }
        public static Account getAccount(string Username)
        {
            Account tk = new Account();
            SqlConnection con = conn();
            con.Open();
            string sql = "select * from ThongTinDangNhap where username ='" + Username + "'";
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable();
            dt.Clear();
            da.Fill(dt);

            tk.username = dt.Rows[0]["username"].ToString();
            tk.password = dt.Rows[0]["password"].ToString();
            tk.MaNV = dt.Rows[0]["MaNV"].ToString();
            tk.role = Convert.ToInt32(dt.Rows[0]["role"]);

            return tk;
        }
        public static void updateTaiKhoan(Account tk)
        {
            SqlConnection con = conn();
            con.Open();
            String sql = "UPDATE [dbo].[ThongTinDangNhap] SET [password] = '" + tk.password + "', [MaNV] = '" + tk.MaNV + "', [role] = '" + tk.role + "'  WHERE [username] ='" + tk.username + "'";
            SqlCommand cmd = new SqlCommand();
            cmd = con.CreateCommand();
            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();
        }
        public static Staff getStaff(string MaNV)
        {
            Staff stf = new Staff();
            SqlConnection con = conn();
            con.Open();
            string sql = "select * from NhanVien where MaNV ='" + MaNV + "'";
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable();
            dt.Clear();
            da.Fill(dt);

            stf.MaNV = dt.Rows[0]["MaNV"].ToString();
            stf.TenNV = dt.Rows[0]["TenNV"].ToString();
            stf.MaCV = dt.Rows[0]["MaCV"].ToString();
            stf.NamSinh = Convert.ToDateTime(dt.Rows[0]["NamSinh"]);
            stf.GioiTinh = dt.Rows[0]["GioiTinh"].ToString();
            stf.DiaChi = dt.Rows[0]["DiaChi"].ToString();
            stf.SoDienThoai = dt.Rows[0]["SoDienThoai"].ToString();
            stf.Luong = Convert.ToInt32(dt.Rows[0]["Luong"]);

            return stf;
        }
        public static void updateNhanVien(Staff stf)
        {
            SqlConnection con = conn();
            con.Open();
            String sql = "UPDATE [dbo].[NhanVien] SET [TenNV] = N'" + stf.TenNV + "', [MaCV] = '" + stf.MaCV + "', [NamSinh] = '" + stf.NamSinh + "', [GioiTinh] = N'" + stf.GioiTinh + "', [DiaChi] = N'" + stf.DiaChi + "', [SoDienThoai] = '" + stf.SoDienThoai + "', [Luong] = '" + stf.Luong + "'  WHERE [MaNV] ='" + stf.MaNV + "'";
            SqlCommand cmd = new SqlCommand();
            cmd = con.CreateCommand();
            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();
        }

        public static Products getProduct(string MaMon)
        {
            Products prdct = new Products();
            SqlConnection con = conn();
            con.Open();
            string sql = "select * from Menu where MaMon ='"+MaMon+"'";
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable();
            dt.Clear();
            da.Fill(dt);
            
            prdct.MaMon = dt.Rows[0]["MaMon"].ToString();
            prdct.TenMon = dt.Rows[0]["TenMon"].ToString();
            prdct.Loai= dt.Rows[0]["MaDanhMuc"].ToString();
            prdct.Gia =  Convert.ToInt32(dt.Rows[0]["Gia"]);

            return prdct;
        }
        public static void updateMon(Products prdct)
        {
            SqlConnection con = conn();
            con.Open();
            String sql = "UPDATE [dbo].[Menu] SET [TenMon] = N'"+prdct.TenMon+"', [MaDanhMuc] = '"+prdct.Loai+"', [Gia] = '"+prdct.Gia+"'  WHERE [MaMon] ='"+prdct.MaMon+"'";
            SqlCommand cmd = new SqlCommand();
            cmd = con.CreateCommand();
            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();
        }
        public static int updatePass(String user, String newpass){
            try
            {
                SqlConnection con = conn();
                con.Open();
                String sql = "UPDATE [dbo].[ThongTinDangNhap] SET [Password] = '" + newpass + "' WHERE [Username] = '" + user + "';";
                SqlCommand cmd = new SqlCommand();
                cmd = con.CreateCommand();
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();
                return 1;
            }
            catch { return 0; }
        }
        public static void themMon(Products tb)
        {
            SqlConnection con = conn();
            con.Open();
            String sql = "INSERT INTO Menu VALUES ('"+tb.MaMon+"',N'"+tb.TenMon+"',N'"+tb.Loai+"','"+tb.Gia+"')";
            SqlCommand cmd = new SqlCommand();
            cmd = con.CreateCommand();
            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();
        }
        public static void xoaMon(string MaMon)
        {
            SqlConnection con = conn();
            con.Open();
            String sql = "DELETE FROM [dbo].[Menu] WHERE MaMon='"+MaMon+"'";
            SqlCommand cmd = new SqlCommand();
            cmd = con.CreateCommand();
            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();
        }
      
        public static void themNhanVien(Staff stf)
        {
            SqlConnection con = conn();
            con.Open();
            String sql = "INSERT INTO NhanVien VALUES ('" + stf.MaNV + "',N'" + stf.TenNV + "',N'" + stf.MaCV + "','" + stf.NamSinh + "',N'" + stf.GioiTinh + "',N'" + stf.DiaChi + "','" + stf.SoDienThoai + "','" + stf.Luong + "')";
            SqlCommand cmd = new SqlCommand();
            cmd = con.CreateCommand();
            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();
        }
        public static void xoaNhanVien(string MaNV)
        {
            SqlConnection con = conn();
            con.Open();
            String sql = "DELETE FROM [dbo].[NhanVien] WHERE MaNV='" + MaNV + "'";
            SqlCommand cmd = new SqlCommand();
            cmd = con.CreateCommand();
            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();
        }
        public static void themBan(Tables tb)
        {
            SqlConnection con = conn();
            con.Open();
            String sql = "INSERT INTO Ban VALUES ('" + tb.MaBan + "',N'" + tb.TenBan + "',N'" + tb.TrangThai + "')";
            SqlCommand cmd = new SqlCommand();
            cmd = con.CreateCommand();
            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();
        }
        public static void xoaBan(string MaBan)
        {
            SqlConnection con = conn();
            con.Open();
            String sql = "DELETE FROM [dbo].[Ban] WHERE MaBan='" + MaBan + "'";
            SqlCommand cmd = new SqlCommand();
            cmd = con.CreateCommand();
            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();
        }
        public static void themTaiKhoan(Account tk)
        {
            SqlConnection con = conn();
            con.Open();
            String sql = "INSERT INTO ThongTinDangNhap VALUES ('" + tk.username + "','" + tk.password + "','" + tk.MaNV + "','" + tk.role + "')";
            SqlCommand cmd = new SqlCommand();
            cmd = con.CreateCommand();
            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();
        }
        public static void xoaTaiKhoan(string user)
        {
            SqlConnection con = conn();
            con.Open();
            String sql = "DELETE FROM [dbo].[ThongTinDangNhap] WHERE username='" + user + "'";
            SqlCommand cmd = new SqlCommand();
            cmd = con.CreateCommand();
            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();
        }
        public static void themOrder(Bill bl)
        {
            SqlConnection con = conn();
            con.Open();
            String sql = "INSERT INTO HoaDon VALUES ('"+bl.MaHD+"','"+bl.MaBan+"','"+bl.MaMon+"',"+bl.SoLuong+","+bl.TrangThai+","+bl.TongTien+")";
            SqlCommand cmd = new SqlCommand();
            cmd = con.CreateCommand();
            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();
        }
    }
}
