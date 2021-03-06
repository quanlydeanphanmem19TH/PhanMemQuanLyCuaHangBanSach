USE [QLCHSach]
GO
/****** Object:  Table [dbo].[HoaDon]    Script Date: 5/22/2021 8:46:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[HoaDon](
	[MaHD] [nvarchar](25) NOT NULL,
	[MaSach] [nvarchar](25) NULL,
	[SoLuong] [int] NULL,
	[ThanhTien] [int] NULL,
	[NgayBan] [datetime] NULL,
	[MaKH] [nvarchar](25) NULL,
	[IdNguoiDung] [varchar](30) NULL,
 CONSTRAINT [PK_HoaDon] PRIMARY KEY CLUSTERED 
(
	[MaHD] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[KeSach]    Script Date: 5/22/2021 8:46:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KeSach](
	[MaKe] [nchar](10) NOT NULL,
	[TenKe] [nvarchar](30) NULL,
	[ViTri] [nvarchar](30) NULL,
 CONSTRAINT [PK_KeSach] PRIMARY KEY CLUSTERED 
(
	[MaKe] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[KhachHang]    Script Date: 5/22/2021 8:46:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KhachHang](
	[MaKH] [nvarchar](25) NOT NULL,
	[TenKH] [nvarchar](200) NULL,
	[DiaChi] [nvarchar](200) NULL,
	[SDT] [nvarchar](25) NULL,
 CONSTRAINT [PK_KhachHang] PRIMARY KEY CLUSTERED 
(
	[MaKH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[LoaiNguoiDung]    Script Date: 5/22/2021 8:46:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LoaiNguoiDung](
	[IdLoaiND] [tinyint] NOT NULL,
	[TenLoaiND] [nvarchar](30) NOT NULL,
 CONSTRAINT [PK_LoaiNguoiDung] PRIMARY KEY CLUSTERED 
(
	[IdLoaiND] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[NguoiDung]    Script Date: 5/22/2021 8:46:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[NguoiDung](
	[IdNguoiDung] [varchar](30) NOT NULL,
	[PassND] [varchar](50) NULL,
	[HoTen] [nvarchar](30) NULL,
	[NgaySinh] [datetime] NULL,
	[GioiTinh] [nvarchar](3) NULL,
	[DiaChi] [nvarchar](100) NULL,
	[SoDT] [varchar](15) NULL,
	[IdLoaiND] [tinyint] NULL,
 CONSTRAINT [PK_NguoiDung] PRIMARY KEY CLUSTERED 
(
	[IdNguoiDung] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[NhaCC]    Script Date: 5/22/2021 8:46:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NhaCC](
	[MaNCC] [nvarchar](25) NOT NULL,
	[TenNCC] [nvarchar](200) NULL,
	[DiaChiNCC] [nvarchar](200) NULL,
	[SdtNCC] [nvarchar](25) NULL,
 CONSTRAINT [PK_NhaCC] PRIMARY KEY CLUSTERED 
(
	[MaNCC] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PhieuNhap]    Script Date: 5/22/2021 8:46:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PhieuNhap](
	[MaPN] [nvarchar](25) NOT NULL,
	[MaSach] [nvarchar](25) NULL,
	[SoLuong] [int] NULL,
	[ThanhTien] [int] NULL,
	[NgayNhap] [datetime] NULL,
	[MaNCC] [nvarchar](25) NULL,
	[IdNguoiDung] [varchar](30) NULL,
 CONSTRAINT [PK_PhieuNhap] PRIMARY KEY CLUSTERED 
(
	[MaPN] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Sach]    Script Date: 5/22/2021 8:46:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sach](
	[MaSach] [nvarchar](25) NOT NULL,
	[TenSach] [nvarchar](200) NULL,
	[NamXB] [nvarchar](25) NULL,
	[TacGia] [nvarchar](200) NULL,
	[SoLuongTon] [int] NULL,
	[GiaNhap] [int] NULL,
	[GiaBan] [int] NULL,
	[MaTheLoai] [nvarchar](25) NULL,
	[MaNCC] [nvarchar](25) NULL,
	[MaKe] [nchar](10) NULL,
 CONSTRAINT [PK_Sach] PRIMARY KEY CLUSTERED 
(
	[MaSach] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TheLoai]    Script Date: 5/22/2021 8:46:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TheLoai](
	[MaTheLoai] [nvarchar](25) NOT NULL,
	[TenTheLoai] [nvarchar](200) NULL,
 CONSTRAINT [PK_TheLoai] PRIMARY KEY CLUSTERED 
(
	[MaTheLoai] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
INSERT [dbo].[HoaDon] ([MaHD], [MaSach], [SoLuong], [ThanhTien], [NgayBan], [MaKH], [IdNguoiDung]) VALUES (N'HD01', N'SA01', 5, 1035000, CAST(N'2021-05-22 00:00:00.000' AS DateTime), N'KH01', N'AD01')
INSERT [dbo].[HoaDon] ([MaHD], [MaSach], [SoLuong], [ThanhTien], [NgayBan], [MaKH], [IdNguoiDung]) VALUES (N'HD02', N'SA02', 5, 1035000, CAST(N'2021-05-22 00:00:00.000' AS DateTime), N'KH01', N'AD01')
INSERT [dbo].[HoaDon] ([MaHD], [MaSach], [SoLuong], [ThanhTien], [NgayBan], [MaKH], [IdNguoiDung]) VALUES (N'HD03', N'SA02', 5, 1035000, CAST(N'2021-05-22 00:00:00.000' AS DateTime), N'KH01', N'AD01')
INSERT [dbo].[HoaDon] ([MaHD], [MaSach], [SoLuong], [ThanhTien], [NgayBan], [MaKH], [IdNguoiDung]) VALUES (N'HD04', N'SA02', 5, 1035000, CAST(N'2021-05-22 00:00:00.000' AS DateTime), N'KH01', N'AD01')
INSERT [dbo].[HoaDon] ([MaHD], [MaSach], [SoLuong], [ThanhTien], [NgayBan], [MaKH], [IdNguoiDung]) VALUES (N'HD05', N'SA02', 5, 1035000, CAST(N'2021-05-22 00:00:00.000' AS DateTime), N'KH01', N'AD01')
INSERT [dbo].[HoaDon] ([MaHD], [MaSach], [SoLuong], [ThanhTien], [NgayBan], [MaKH], [IdNguoiDung]) VALUES (N'HD06', N'SA02', 5, 1035000, CAST(N'2021-05-22 00:00:00.000' AS DateTime), N'KH01', N'AD01')
INSERT [dbo].[KeSach] ([MaKe], [TenKe], [ViTri]) VALUES (N'KE01      ', N'Chính trị', N'Khu A1')
INSERT [dbo].[KeSach] ([MaKe], [TenKe], [ViTri]) VALUES (N'KE02      ', N'Lịch sử', N'Khu A1')
INSERT [dbo].[KhachHang] ([MaKH], [TenKH], [DiaChi], [SDT]) VALUES (N'KH01', N'Lionel Messi', N'Argentina', N'999999999')
INSERT [dbo].[KhachHang] ([MaKH], [TenKH], [DiaChi], [SDT]) VALUES (N'KH02', N'Lionel Messi', N'Argentina', N'999999999')
INSERT [dbo].[KhachHang] ([MaKH], [TenKH], [DiaChi], [SDT]) VALUES (N'KH03', N'Cristiano Ronaldo', N'Portugal', N'888888888')
INSERT [dbo].[LoaiNguoiDung] ([IdLoaiND], [TenLoaiND]) VALUES (1, N'Admin')
INSERT [dbo].[LoaiNguoiDung] ([IdLoaiND], [TenLoaiND]) VALUES (2, N'Nhân viên')
INSERT [dbo].[NguoiDung] ([IdNguoiDung], [PassND], [HoTen], [NgaySinh], [GioiTinh], [DiaChi], [SoDT], [IdLoaiND]) VALUES (N'AD01', N'e10adc3949ba59abbe56e057f20f883e', N'Quan Dinh', CAST(N'2000-11-25 00:00:00.000' AS DateTime), N'Nam', N'Long Xuyên', N'0987939081', 1)
INSERT [dbo].[NguoiDung] ([IdNguoiDung], [PassND], [HoTen], [NgaySinh], [GioiTinh], [DiaChi], [SoDT], [IdLoaiND]) VALUES (N'NV01', N'e10adc3949ba59abbe56e057f20f883e', N'Yến Nhi', CAST(N'2000-02-27 00:00:00.000' AS DateTime), N'Nữ', N'Mỹ Hòa, Long Xuyên', N'0522944955', 2)
INSERT [dbo].[NhaCC] ([MaNCC], [TenNCC], [DiaChiNCC], [SdtNCC]) VALUES (N'NCC01', N'Nhà sách Phương Nam', N'Mỹ Long, Long Xuyên', N'0999999999')
INSERT [dbo].[NhaCC] ([MaNCC], [TenNCC], [DiaChiNCC], [SdtNCC]) VALUES (N'NCC02', N'Nhà sách Phương Bắc', N'Mỹ Hòa, Long Xuyên', N'0888888888')
INSERT [dbo].[PhieuNhap] ([MaPN], [MaSach], [SoLuong], [ThanhTien], [NgayNhap], [MaNCC], [IdNguoiDung]) VALUES (N'PN01', N'SA01', 20, 3800000, CAST(N'2021-05-11 00:00:00.000' AS DateTime), N'NCC01', N'NV01')
INSERT [dbo].[Sach] ([MaSach], [TenSach], [NamXB], [TacGia], [SoLuongTon], [GiaNhap], [GiaBan], [MaTheLoai], [MaNCC], [MaKe]) VALUES (N'SA01', N'Suối nguồn', N'2021', N'Ayn Rand', 50, 190000, 207000, N'TL03', N'NCC01', N'KE01      ')
INSERT [dbo].[Sach] ([MaSach], [TenSach], [NamXB], [TacGia], [SoLuongTon], [GiaNhap], [GiaBan], [MaTheLoai], [MaNCC], [MaKe]) VALUES (N'SA02', N'Tiếng Anh', N'2021', N'Nhuy', 45, 190000, 207000, N'TL01', N'NCC01', N'KE01      ')
INSERT [dbo].[TheLoai] ([MaTheLoai], [TenTheLoai]) VALUES (N'TL01', N'Ngoại ngữ')
INSERT [dbo].[TheLoai] ([MaTheLoai], [TenTheLoai]) VALUES (N'TL02', N'Khoa học')
INSERT [dbo].[TheLoai] ([MaTheLoai], [TenTheLoai]) VALUES (N'TL03', N'Tiểu thuyết')
ALTER TABLE [dbo].[HoaDon]  WITH CHECK ADD  CONSTRAINT [FK_HoaDon_KhachHang] FOREIGN KEY([MaKH])
REFERENCES [dbo].[KhachHang] ([MaKH])
GO
ALTER TABLE [dbo].[HoaDon] CHECK CONSTRAINT [FK_HoaDon_KhachHang]
GO
ALTER TABLE [dbo].[HoaDon]  WITH CHECK ADD  CONSTRAINT [FK_HoaDon_NguoiDung] FOREIGN KEY([IdNguoiDung])
REFERENCES [dbo].[NguoiDung] ([IdNguoiDung])
GO
ALTER TABLE [dbo].[HoaDon] CHECK CONSTRAINT [FK_HoaDon_NguoiDung]
GO
ALTER TABLE [dbo].[HoaDon]  WITH CHECK ADD  CONSTRAINT [FK_HoaDon_Sach] FOREIGN KEY([MaSach])
REFERENCES [dbo].[Sach] ([MaSach])
GO
ALTER TABLE [dbo].[HoaDon] CHECK CONSTRAINT [FK_HoaDon_Sach]
GO
ALTER TABLE [dbo].[NguoiDung]  WITH CHECK ADD  CONSTRAINT [FK_NguoiDung_LoaiNguoiDung] FOREIGN KEY([IdLoaiND])
REFERENCES [dbo].[LoaiNguoiDung] ([IdLoaiND])
GO
ALTER TABLE [dbo].[NguoiDung] CHECK CONSTRAINT [FK_NguoiDung_LoaiNguoiDung]
GO
ALTER TABLE [dbo].[PhieuNhap]  WITH CHECK ADD  CONSTRAINT [FK_PhieuNhap_NguoiDung] FOREIGN KEY([IdNguoiDung])
REFERENCES [dbo].[NguoiDung] ([IdNguoiDung])
GO
ALTER TABLE [dbo].[PhieuNhap] CHECK CONSTRAINT [FK_PhieuNhap_NguoiDung]
GO
ALTER TABLE [dbo].[PhieuNhap]  WITH CHECK ADD  CONSTRAINT [FK_PhieuNhap_NhaCC] FOREIGN KEY([MaNCC])
REFERENCES [dbo].[NhaCC] ([MaNCC])
GO
ALTER TABLE [dbo].[PhieuNhap] CHECK CONSTRAINT [FK_PhieuNhap_NhaCC]
GO
ALTER TABLE [dbo].[PhieuNhap]  WITH CHECK ADD  CONSTRAINT [FK_PhieuNhap_Sach] FOREIGN KEY([MaSach])
REFERENCES [dbo].[Sach] ([MaSach])
GO
ALTER TABLE [dbo].[PhieuNhap] CHECK CONSTRAINT [FK_PhieuNhap_Sach]
GO
ALTER TABLE [dbo].[Sach]  WITH CHECK ADD  CONSTRAINT [FK_Sach_KeSach] FOREIGN KEY([MaKe])
REFERENCES [dbo].[KeSach] ([MaKe])
GO
ALTER TABLE [dbo].[Sach] CHECK CONSTRAINT [FK_Sach_KeSach]
GO
ALTER TABLE [dbo].[Sach]  WITH CHECK ADD  CONSTRAINT [FK_Sach_NhaCC] FOREIGN KEY([MaNCC])
REFERENCES [dbo].[NhaCC] ([MaNCC])
GO
ALTER TABLE [dbo].[Sach] CHECK CONSTRAINT [FK_Sach_NhaCC]
GO
ALTER TABLE [dbo].[Sach]  WITH CHECK ADD  CONSTRAINT [FK_Sach_TheLoai] FOREIGN KEY([MaTheLoai])
REFERENCES [dbo].[TheLoai] ([MaTheLoai])
GO
ALTER TABLE [dbo].[Sach] CHECK CONSTRAINT [FK_Sach_TheLoai]
GO
