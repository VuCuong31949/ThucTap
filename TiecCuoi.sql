CREATE TABLE [dbo].[ThietBi] (
    [MaTB]        INT IDENTITY(1,1) PRIMARY KEY,
    [TenTB]       NVARCHAR(100) NOT NULL,
    [LoaiTB]      NVARCHAR(100) NOT NULL,
    [SoLuongNhap] INT NOT NULL,
    [SoLuongHu]   INT NOT NULL,
    [SoLuongTon]  INT NOT NULL,
    [ViTriSD]     NVARCHAR(100),
    [HinhAnh]     VARCHAR(100),
    [GhiChu]      NVARCHAR(300),
    [Gia]         DECIMAL(18,2) NOT NULL
);

CREATE TABLE [dbo].[DungCu] (
    [MaDC]        INT IDENTITY(1,1) PRIMARY KEY,
    [TenDC]       NVARCHAR(100) NOT NULL,
    [LoaiDC]      NVARCHAR(100) NOT NULL,
    [SoLuongNhap] INT NOT NULL,
    [SoLuongHu]   INT NOT NULL,
    [SoLuongTon]  INT NOT NULL,
    [HinhAnh]     VARCHAR(100),
    [GhiChu]      NVARCHAR(300),
    [Gia]         DECIMAL(18,2) NOT NULL
);

CREATE TABLE [dbo].[ThiepCuoi] (
    [MaTC]        INT IDENTITY(1,1) PRIMARY KEY,
    [HinhAnh]     VARCHAR(200),
    [KichThuoc]   NVARCHAR(100),
    [ChatLieu]    NVARCHAR(100),
    [MauSac]      NVARCHAR(100),
    [NhaCungCap]  NVARCHAR(200),
    [Gia]         DECIMAL(18,2) NOT NULL,
    [KhuyenMai]   DECIMAL(18,2),
    [TrangThai]   NVARCHAR(100),
    [HoaTiec]     NVARCHAR(200)
);

CREATE TABLE [dbo].[DoCuoi] (
    [MaDC]        INT IDENTITY(1,1) PRIMARY KEY,
    [DanhMuc]     NVARCHAR(100),
    [MoTa]        NVARCHAR(200),
    [HinhAnh]     VARCHAR(200),
    [KichThuoc]   NVARCHAR(100),
    [ChatLieu]    NVARCHAR(100),
    [MauSac]      NVARCHAR(100),
    [NhaCungCap]  NVARCHAR(200),
    [Gia]         DECIMAL(18,2) NOT NULL,
    [KhuyenMai]   DECIMAL(18,2),
    [HinhThuc]    NVARCHAR(100),
    [LoaiSanh]    NVARCHAR(100),
    [LuotMua]     INT
);

CREATE TABLE [dbo].[MonAn] (
    [MaMA]        INT IDENTITY(1,1) PRIMARY KEY,
    [TenMA]       NVARCHAR(100) NOT NULL,
    [DanhMuc]     NVARCHAR(100),
    [NguyenLieu]  NVARCHAR(200),
    [Gia]         DECIMAL(18,2) NOT NULL,
    [HinhAnh]     VARCHAR(100),
    [MoTa]        NVARCHAR(200),
    [TrangThai]   NVARCHAR(100)
);

CREATE TABLE [dbo].[NguyenLieu] (
    [MaNL]        INT IDENTITY(1,1) PRIMARY KEY,
    [TenNL]       NVARCHAR(100) NOT NULL,
    [DanhMuc]     NVARCHAR(100),
    [NhaCungCap]  NVARCHAR(100),
    [SoLuong]     INT NOT NULL,
    [DonVi]       NVARCHAR(100),
    [NgayNhap]    DATE NOT NULL,
    [GiaNhap]     DECIMAL(18,2) NOT NULL,
    [GiaBan]      DECIMAL(18,2) NOT NULL,
    [TongGia]     DECIMAL(18,2),
    [HanSuDung]   INT,
    [TrangThai]   NVARCHAR(100),
    [GhiChu]      NVARCHAR(300)
);

CREATE TABLE [dbo].[SanhCuoi] (
    [MaSC]        INT IDENTITY(1,1) PRIMARY KEY,
    [TenSC]       NVARCHAR(100) NOT NULL,
    [SoLuongBan]  INT NOT NULL,
    [DienTich]    NVARCHAR(100),
    [LoaiSanh]    NVARCHAR(100),
    [LoaiDen]     NVARCHAR(100),
    [SoLuongDen]  INT,
    [LoaiMayLanh] NVARCHAR(100),
    [SLMayLanh]   INT,
    [LoaiMayChieu] NVARCHAR(100),
    [LoaiBackdrop] NVARCHAR(100),
    [LoaiManHinh] NVARCHAR(100),
    [TongChiPhi]  DECIMAL(18,2) NOT NULL
);

CREATE TABLE [dbo].[KhachMoi] (
    [MaKM]        INT IDENTITY(1,1) PRIMARY KEY,
    [TenKM]       NVARCHAR(100) NOT NULL,
    [SDT]         VARCHAR(15),
    [DiaChi]      NVARCHAR(200),
    [NhomKhachMoi] NVARCHAR(200),
    [SoLuong]     INT NOT NULL,
    [GhiChu]      NVARCHAR(300),
    [LoaiThiep]   NVARCHAR(100),
    [TenSanh]     NVARCHAR(100),
    [DiaChiSanh]  NVARCHAR(200
);
);

CREATE TABLE [dbo].[TiecCuoi] (
    [MaTC]             INT IDENTITY(1,1) PRIMARY KEY,
    [TenKH]           NVARCHAR(100) NOT NULL,
    [NgayDat]         DATE NOT NULL,
    [ThoiGianBatDau]  TIME NOT NULL,
    [ThoiGianKetThuc] TIME NOT NULL,
    [TenCoDau]        NVARCHAR(100),
    [TenChuRe]        NVARCHAR(100),
    [TenSanh]         NVARCHAR(100),
    [SlBan]           INT NOT NULL,
    [GoiAnTiec]       NVARCHAR(100),
    [GoiDichVu]       NVARCHAR(100),
    [LoaiThiepCuoi]   NVARCHAR(100),
    [GoiThucDon]      NVARCHAR(100),
    [GoiNuoc]         NVARCHAR(100),
    [GoiThietBi]      NVARCHAR(100),
    [GoiGiaTri]       NVARCHAR(100),
    [DonGiaTiec]      DECIMAL(18,2) NOT NULL
);

CREATE TABLE [dbo].[TaiKhoan] (
    [MaTK]      INT IDENTITY(1,1) PRIMARY KEY,
    [TenTK]     NVARCHAR(100) NOT NULL,
    [MatKhau]   VARCHAR(100) NOT NULL
);

CREATE TABLE [dbo].[DichVu] (
    [MaDV]      INT IDENTITY(1,1) PRIMARY KEY,
    [TenDV]     NVARCHAR(100) NOT NULL,
    [LoaiDV]    NVARCHAR(100),
    [GhiChu]    NVARCHAR(300),
    [MoTa]      NVARCHAR(200),
    [Gia]       DECIMAL(18,2) NOT NULL
);
