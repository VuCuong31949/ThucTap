create database ThucTap
use ThucTap

create table ThietBi
(
	MaTB int identity(1,1)  not null,
	TenTB nvarchar(100),
	LoaiTB nvarchar(100),
	SoLuongNhap int,
	SoLuongHu int,
	SoLuongTon int,
	ViTriSD nvarchar(100),
	HinhAnh varchar(100),
	GhiChu nvarchar(300),
	Gia Decimal,
	ConStraint PK_ThietBi primary key(MaTB)
)
create table DungCu
(
	MaDC int identity(1,1) not null,
	TenDC nvarchar(100),
	LoaiDC nvarchar(100),
	SoLuongNhap int,
	SoLuongHu int,
	SoLuongTon int,
	HinhAnh varchar(100),
	GhiChu nvarchar(300),
	Gia Decimal,
	ConStraint PK_DungCu primary key(MaDC)
)
create table ThiepCuoi
(
	MaTC int identity(1,1) not null,
	HinhAnh varchar(200),
	KichThuoc nvarchar(100),
	ChatLieu nvarchar(100),
	MauSac nvarchar(100),
	NhaCungCap nvarchar(200),
	Gia Decimal,
	KhuyenMai decimal,
	TrangThai nvarchar(100),
	HoaTiec nvarchar(200),
	ConStraint PK_ThiepCuoi Primary key (MaTC)
)

create table DoCuoi
(
	MaDC int identity(1,1) not null,
	DanhMuc nvarchar(100),
	MoTa nvarchar(200),
	HinhAnh varchar(200),
	KichThuoc nvarchar(100),
	ChatLieu nvarchar(100),
	MauSac nvarchar(100),
	NhaCungCap nvarchar(200),
	Gia Decimal,
	KhuyenMai decimal,
	HinhThuc nvarchar(100),
	LoaiSanh nvarchar(100),
	LuotMua int,
	ConStraint PK_DoCuoi Primary key (MaDC)
)
create table MonAn
(
	MaMA int identity(1,1) not null,
	TenMA nvarchar(100),
	DanhMuc nvarchar(100),
	NguyenLieu nvarchar(200),
	Gia Decimal,
	HinhAnh varchar(100),
	MoTa nvarchar(200),
	TrangThai nvarchar(100),
	ConStraint PK_MonAn primary key(MaMA)
)
create table Nguyenlieu
(
	MaNL int identity(1,1) not null,
	TenNL nvarchar(100),
	DanhMuc nvarchar(100),
	NhaCungCap nvarchar(100),
	SoLuong int,
	DonVi nvarchar(100),
	NgayNhap Date,
	GiaNhap Decimal,
	GiaBan Decimal,
	TongGia Decimal,
	HanSuDung int,
	TrangThai nvarchar(100),
	GhiChu nvarchar(300),
	ConStraint PK_NguyenLieu Primary key (MaNL)
)
create table SanhCuoi
(
	MaSC int identity(1,1) not null,
	TenSC nvarchar(100),
	SoLuongBan int,
	DienTich nvarchar(100),
	LoaiSanh nvarchar(100),
	LoaiDen nvarchar(100),
	SoLuongDen int,
	LoaiMayLanh nvarchar(100),
	SLMayLanh int,
	LoaiMayChieu nvarchar(100),
	LoaiBackdrop nvarchar(100),
	LoaiManHinh nvarchar(100),
	TongChiPhi Decimal,
	ConStraint PK_SanhCuoi primary key(MaSC)
)
create table KhachMoi
(
	MaKM int identity(1,1) not null,
	TenKM nvarchar(100),
	SDT varchar(15),
	DiaChi nvarchar(200),
	NhomKhachMoi nvarchar(200),
	SoLuong int,
	GhiChu nvarchar(300),
	LoaiThiep nvarchar(100),
	TenSanh nvarchar(100),
	DiaChiSanh nvarchar(200),
	Constraint PK_KhachMoi primary key(MaKM)
)

create table TiecCuoi
(
	MaTC int identity(1,1) not null,
	TenKH nvarchar(100),
	NgayDat Date,
	ThoiGianBatDau Time,
	ThoiGianKetThuc Time,
	TenCoDau nvarchar(100),
	TenChuRe nvarchar(100),
	TenSanh nvarchar(100),
	SlBan int,
	GoiAnTiec nvarchar(100),
	GoiDichVu nvarchar(100),
	LoaiThiepCuoi nvarchar(100),
	GoiThucDon nvarchar(100),
	GoiNuoc nvarchar(100),
	GoiThietBi nvarchar(100),
	GoiGiaTri nvarchar(100),
	DonGiaTiec Decimal,
	Constraint PK_TiecCuoi primary key(MaTC)
)

create table TaiKhoan
(
	MaTK int identity(1,1) not null,
	TenTK nvarchar(100),
	MatKhau varchar(100),
	Constraint PK_TaiKhoan primary key(MaTK)

)
create table DichVu
(
	MaDV int identity(1,1) not null,
	TenDV nvarchar(100),
	LoaiDV nvarchar(100),
	GhiChu nvarchar(300),
	MoTa nvarchar(200),
	Gia Decimal,
	Constraint PK_DichVu primary key(MaDV)
)