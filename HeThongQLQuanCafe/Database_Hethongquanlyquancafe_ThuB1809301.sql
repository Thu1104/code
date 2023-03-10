USE [master]
GO
/****** Object:  Database [QuanLyQuanCafe]    Script Date: 12/10/2021 11:50:48 PM ******/
CREATE DATABASE [QuanLyQuanCafe]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'QuanLyQuanCafe', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\QuanLyQuanCafe.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'QuanLyQuanCafe_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\QuanLyQuanCafe_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [QuanLyQuanCafe] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [QuanLyQuanCafe].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [QuanLyQuanCafe] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [QuanLyQuanCafe] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [QuanLyQuanCafe] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [QuanLyQuanCafe] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [QuanLyQuanCafe] SET ARITHABORT OFF 
GO
ALTER DATABASE [QuanLyQuanCafe] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [QuanLyQuanCafe] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [QuanLyQuanCafe] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [QuanLyQuanCafe] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [QuanLyQuanCafe] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [QuanLyQuanCafe] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [QuanLyQuanCafe] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [QuanLyQuanCafe] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [QuanLyQuanCafe] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [QuanLyQuanCafe] SET  DISABLE_BROKER 
GO
ALTER DATABASE [QuanLyQuanCafe] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [QuanLyQuanCafe] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [QuanLyQuanCafe] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [QuanLyQuanCafe] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [QuanLyQuanCafe] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [QuanLyQuanCafe] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [QuanLyQuanCafe] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [QuanLyQuanCafe] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [QuanLyQuanCafe] SET  MULTI_USER 
GO
ALTER DATABASE [QuanLyQuanCafe] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [QuanLyQuanCafe] SET DB_CHAINING OFF 
GO
ALTER DATABASE [QuanLyQuanCafe] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [QuanLyQuanCafe] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [QuanLyQuanCafe] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [QuanLyQuanCafe] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [QuanLyQuanCafe] SET QUERY_STORE = OFF
GO
USE [QuanLyQuanCafe]
GO
/****** Object:  Table [dbo].[Ban]    Script Date: 12/10/2021 11:50:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ban](
	[MaBan] [nvarchar](10) NOT NULL,
	[TenBan] [nvarchar](10) NOT NULL,
	[TrangThai] [int] NOT NULL,
 CONSTRAINT [PK_Ban] PRIMARY KEY CLUSTERED 
(
	[MaBan] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ChucVu]    Script Date: 12/10/2021 11:50:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChucVu](
	[MaCV] [nvarchar](10) NOT NULL,
	[ChucVu] [nvarchar](20) NOT NULL,
 CONSTRAINT [PK_ChucVu] PRIMARY KEY CLUSTERED 
(
	[MaCV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DanhMuc]    Script Date: 12/10/2021 11:50:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DanhMuc](
	[MaDanhMuc] [nvarchar](10) NOT NULL,
	[TenDanhMuc] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_DanhMuc] PRIMARY KEY CLUSTERED 
(
	[MaDanhMuc] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HoaDon]    Script Date: 12/10/2021 11:50:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HoaDon](
	[MaHD] [nvarchar](10) NOT NULL,
	[MaBan] [nvarchar](10) NOT NULL,
	[MaMon] [nvarchar](10) NOT NULL,
	[SoLuong] [int] NOT NULL,
	[TrangThai] [int] NOT NULL,
	[TongTien] [int] NOT NULL,
 CONSTRAINT [PK_HoaDon] PRIMARY KEY CLUSTERED 
(
	[MaHD] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Menu]    Script Date: 12/10/2021 11:50:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Menu](
	[MaMon] [nvarchar](10) NOT NULL,
	[TenMon] [nvarchar](50) NOT NULL,
	[MaDanhMuc] [nvarchar](10) NOT NULL,
	[Gia] [int] NOT NULL,
 CONSTRAINT [PK_Menu] PRIMARY KEY CLUSTERED 
(
	[MaMon] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NhanVien]    Script Date: 12/10/2021 11:50:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NhanVien](
	[MaNV] [nvarchar](10) NOT NULL,
	[TenNV] [nvarchar](50) NOT NULL,
	[MaCV] [nvarchar](10) NOT NULL,
	[NamSinh] [date] NOT NULL,
	[GioiTinh] [nvarchar](10) NOT NULL,
	[DiaChi] [nvarchar](100) NOT NULL,
	[SoDienThoai] [nvarchar](20) NOT NULL,
	[Luong] [int] NOT NULL,
 CONSTRAINT [PK_NhanVien] PRIMARY KEY CLUSTERED 
(
	[MaNV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ThongTinDangNhap]    Script Date: 12/10/2021 11:50:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ThongTinDangNhap](
	[username] [nvarchar](10) NOT NULL,
	[password] [nvarchar](10) NOT NULL,
	[MaNV] [nvarchar](10) NOT NULL,
	[role] [int] NOT NULL,
 CONSTRAINT [PK_Thongtindangnhap] PRIMARY KEY CLUSTERED 
(
	[username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Ban] ([MaBan], [TenBan], [TrangThai]) VALUES (N'B01', N'Bàn 1', 1)
INSERT [dbo].[Ban] ([MaBan], [TenBan], [TrangThai]) VALUES (N'B02', N'Bàn 2', 0)
INSERT [dbo].[Ban] ([MaBan], [TenBan], [TrangThai]) VALUES (N'B03', N'Bàn 3', 0)
INSERT [dbo].[Ban] ([MaBan], [TenBan], [TrangThai]) VALUES (N'B04', N'Bàn 4', 0)
INSERT [dbo].[Ban] ([MaBan], [TenBan], [TrangThai]) VALUES (N'B05', N'Bàn 5', 0)
INSERT [dbo].[Ban] ([MaBan], [TenBan], [TrangThai]) VALUES (N'B06', N'Bàn 6', 0)
INSERT [dbo].[Ban] ([MaBan], [TenBan], [TrangThai]) VALUES (N'B07', N'Bàn 7', 0)
INSERT [dbo].[Ban] ([MaBan], [TenBan], [TrangThai]) VALUES (N'B08', N'Bàn 8', 0)
INSERT [dbo].[Ban] ([MaBan], [TenBan], [TrangThai]) VALUES (N'B09', N'Bàn 9', 0)
INSERT [dbo].[Ban] ([MaBan], [TenBan], [TrangThai]) VALUES (N'B10', N'Bàn 10', 0)
INSERT [dbo].[Ban] ([MaBan], [TenBan], [TrangThai]) VALUES (N'B11', N'Bàn 11', 0)
INSERT [dbo].[Ban] ([MaBan], [TenBan], [TrangThai]) VALUES (N'B12', N'Bàn 12', 0)
INSERT [dbo].[Ban] ([MaBan], [TenBan], [TrangThai]) VALUES (N'B13', N'Bàn 13', 0)
INSERT [dbo].[Ban] ([MaBan], [TenBan], [TrangThai]) VALUES (N'B14', N'Bàn 14', 0)
INSERT [dbo].[Ban] ([MaBan], [TenBan], [TrangThai]) VALUES (N'B15', N'Bàn 15', 0)
INSERT [dbo].[Ban] ([MaBan], [TenBan], [TrangThai]) VALUES (N'B16', N'Bàn 22', 0)
INSERT [dbo].[Ban] ([MaBan], [TenBan], [TrangThai]) VALUES (N'B17', N'Bàn 17', 0)
INSERT [dbo].[Ban] ([MaBan], [TenBan], [TrangThai]) VALUES (N'B18', N'Bàn 18', 0)
INSERT [dbo].[Ban] ([MaBan], [TenBan], [TrangThai]) VALUES (N'B19', N'Bàn 19', 0)
INSERT [dbo].[Ban] ([MaBan], [TenBan], [TrangThai]) VALUES (N'B20', N'Bàn 20', 0)
GO
INSERT [dbo].[ChucVu] ([MaCV], [ChucVu]) VALUES (N'CV01', N'Quản lý')
INSERT [dbo].[ChucVu] ([MaCV], [ChucVu]) VALUES (N'CV02', N'Thu ngân')
INSERT [dbo].[ChucVu] ([MaCV], [ChucVu]) VALUES (N'CV03', N'Phục vụ')
GO
INSERT [dbo].[DanhMuc] ([MaDanhMuc], [TenDanhMuc]) VALUES (N'01', N'Cà phê')
INSERT [dbo].[DanhMuc] ([MaDanhMuc], [TenDanhMuc]) VALUES (N'02', N'Trà sữa')
INSERT [dbo].[DanhMuc] ([MaDanhMuc], [TenDanhMuc]) VALUES (N'03', N'Nước ép')
INSERT [dbo].[DanhMuc] ([MaDanhMuc], [TenDanhMuc]) VALUES (N'04', N'Sinh tố')
INSERT [dbo].[DanhMuc] ([MaDanhMuc], [TenDanhMuc]) VALUES (N'05', N'Hồng trà')
INSERT [dbo].[DanhMuc] ([MaDanhMuc], [TenDanhMuc]) VALUES (N'06', N'Yaourt')
INSERT [dbo].[DanhMuc] ([MaDanhMuc], [TenDanhMuc]) VALUES (N'07', N'Nước ngọt')
GO
INSERT [dbo].[HoaDon] ([MaHD], [MaBan], [MaMon], [SoLuong], [TrangThai], [TongTien]) VALUES (N'HD01', N'B03', N'M001', 2, 1, 30000)
INSERT [dbo].[HoaDon] ([MaHD], [MaBan], [MaMon], [SoLuong], [TrangThai], [TongTien]) VALUES (N'HD02', N'B03', N'M002', 2, 1, 24000)
INSERT [dbo].[HoaDon] ([MaHD], [MaBan], [MaMon], [SoLuong], [TrangThai], [TongTien]) VALUES (N'HD03', N'B06', N'M004', 1, 1, 25000)
INSERT [dbo].[HoaDon] ([MaHD], [MaBan], [MaMon], [SoLuong], [TrangThai], [TongTien]) VALUES (N'HD04', N'B06', N'M007', 1, 1, 25000)
INSERT [dbo].[HoaDon] ([MaHD], [MaBan], [MaMon], [SoLuong], [TrangThai], [TongTien]) VALUES (N'HD05', N'B09', N'M009', 2, 1, 24000)
INSERT [dbo].[HoaDon] ([MaHD], [MaBan], [MaMon], [SoLuong], [TrangThai], [TongTien]) VALUES (N'HD06', N'B09', N'M002', 1, 1, 12000)
INSERT [dbo].[HoaDon] ([MaHD], [MaBan], [MaMon], [SoLuong], [TrangThai], [TongTien]) VALUES (N'HD07', N'B01', N'M002', 1, 1, 12000)
INSERT [dbo].[HoaDon] ([MaHD], [MaBan], [MaMon], [SoLuong], [TrangThai], [TongTien]) VALUES (N'HD08', N'B01', N'M005', 3, 1, 60000)
INSERT [dbo].[HoaDon] ([MaHD], [MaBan], [MaMon], [SoLuong], [TrangThai], [TongTien]) VALUES (N'HD09', N'B03', N'M004', 2, 1, 50000)
INSERT [dbo].[HoaDon] ([MaHD], [MaBan], [MaMon], [SoLuong], [TrangThai], [TongTien]) VALUES (N'HD10', N'B04', N'M005', 2, 1, 40000)
INSERT [dbo].[HoaDon] ([MaHD], [MaBan], [MaMon], [SoLuong], [TrangThai], [TongTien]) VALUES (N'HD11', N'B04', N'M004', 2, 1, 50000)
INSERT [dbo].[HoaDon] ([MaHD], [MaBan], [MaMon], [SoLuong], [TrangThai], [TongTien]) VALUES (N'HD12', N'B01', N'M001', 1, 1, 15000)
INSERT [dbo].[HoaDon] ([MaHD], [MaBan], [MaMon], [SoLuong], [TrangThai], [TongTien]) VALUES (N'HD13', N'B01', N'M003', 2, 0, 40000)
GO
INSERT [dbo].[Menu] ([MaMon], [TenMon], [MaDanhMuc], [Gia]) VALUES (N'M001', N'Cà phê sữa', N'01', 15000)
INSERT [dbo].[Menu] ([MaMon], [TenMon], [MaDanhMuc], [Gia]) VALUES (N'M002', N'Cà phê', N'01', 12000)
INSERT [dbo].[Menu] ([MaMon], [TenMon], [MaDanhMuc], [Gia]) VALUES (N'M003', N'Sinh tố bơ', N'04', 20000)
INSERT [dbo].[Menu] ([MaMon], [TenMon], [MaDanhMuc], [Gia]) VALUES (N'M004', N'Sinh tố dâu', N'04', 25000)
INSERT [dbo].[Menu] ([MaMon], [TenMon], [MaDanhMuc], [Gia]) VALUES (N'M005', N'Trà sữa matcha', N'02', 22000)
INSERT [dbo].[Menu] ([MaMon], [TenMon], [MaDanhMuc], [Gia]) VALUES (N'M006', N'Trà sữa truyền thống', N'02', 18000)
INSERT [dbo].[Menu] ([MaMon], [TenMon], [MaDanhMuc], [Gia]) VALUES (N'M007', N'Sữa tươi trân châu đường đen', N'02', 25000)
INSERT [dbo].[Menu] ([MaMon], [TenMon], [MaDanhMuc], [Gia]) VALUES (N'M008', N'Sting', N'07', 12000)
INSERT [dbo].[Menu] ([MaMon], [TenMon], [MaDanhMuc], [Gia]) VALUES (N'M011', N'Cam ép', N'03', 15000)
INSERT [dbo].[Menu] ([MaMon], [TenMon], [MaDanhMuc], [Gia]) VALUES (N'M012', N'Bưởi ép', N'03', 15000)
INSERT [dbo].[Menu] ([MaMon], [TenMon], [MaDanhMuc], [Gia]) VALUES (N'M013', N'Trà tắt', N'05', 18000)
INSERT [dbo].[Menu] ([MaMon], [TenMon], [MaDanhMuc], [Gia]) VALUES (N'M014', N'Trà đào', N'05', 20000)
INSERT [dbo].[Menu] ([MaMon], [TenMon], [MaDanhMuc], [Gia]) VALUES (N'M015', N'Trà vải', N'05', 20000)
INSERT [dbo].[Menu] ([MaMon], [TenMon], [MaDanhMuc], [Gia]) VALUES (N'M016', N'Yaourt đá', N'06', 15000)
INSERT [dbo].[Menu] ([MaMon], [TenMon], [MaDanhMuc], [Gia]) VALUES (N'M017', N'Yaourt tắt', N'06', 18000)
INSERT [dbo].[Menu] ([MaMon], [TenMon], [MaDanhMuc], [Gia]) VALUES (N'M018', N'Chanh dây', N'03', 18000)
INSERT [dbo].[Menu] ([MaMon], [TenMon], [MaDanhMuc], [Gia]) VALUES (N'M019', N'Pepsi', N'07', 15000)
GO
INSERT [dbo].[NhanVien] ([MaNV], [TenNV], [MaCV], [NamSinh], [GioiTinh], [DiaChi], [SoDienThoai], [Luong]) VALUES (N'NV01', N'Nguyễn Thị Anh Thư', N'CV01', CAST(N'2000-04-11' AS Date), N'Nữ', N'Nguyễn Văn Linh, Cần Thơ', N'0911513973', 10000000)
INSERT [dbo].[NhanVien] ([MaNV], [TenNV], [MaCV], [NamSinh], [GioiTinh], [DiaChi], [SoDienThoai], [Luong]) VALUES (N'NV02', N'Trần Thúy Vy', N'CV02', CAST(N'2000-12-30' AS Date), N'Nữ', N'Nguyễn Văn Linh, Cần Thơ', N'0987654321', 6000000)
INSERT [dbo].[NhanVien] ([MaNV], [TenNV], [MaCV], [NamSinh], [GioiTinh], [DiaChi], [SoDienThoai], [Luong]) VALUES (N'NV03', N'Phạm Lê', N'CV03', CAST(N'2000-01-01' AS Date), N'Nam', N'Cần Thơ', N'0123456789', 6000000)
GO
INSERT [dbo].[ThongTinDangNhap] ([username], [password], [MaNV], [role]) VALUES (N'Admin', N'admin', N'NV01', 1)
INSERT [dbo].[ThongTinDangNhap] ([username], [password], [MaNV], [role]) VALUES (N'NV02', N'2', N'NV02', 0)
INSERT [dbo].[ThongTinDangNhap] ([username], [password], [MaNV], [role]) VALUES (N'NV04', N'NV04', N'NV04', 0)
INSERT [dbo].[ThongTinDangNhap] ([username], [password], [MaNV], [role]) VALUES (N'NV05', N'3', N'NV05', 0)
GO
USE [master]
GO
ALTER DATABASE [QuanLyQuanCafe] SET  READ_WRITE 
GO
