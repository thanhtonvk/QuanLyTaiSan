use master
go
create database QuanLyVatTu
go
use QuanLyVatTu
go
create table TaiKhoan
(
    tentk        varchar(30) primary key,
    matkhau      varchar(30)   not null,
    hoten        nvarchar(100) not null,
    email        nvarchar(100) not null,
    diachi       nvarchar(200),
    sdt          nvarchar(20),
    loaitaikhoan nvarchar(100),
)
    insert into TaiKhoan (tentk, matkhau, hoten, email, diachi, sdt, loaitaikhoan)
values ('admin', 'admin', 'admin', 'admin@admin.com', '', '', 'admin');
go
create table Khoa
(
    makhoa  int identity (1000,1) primary key,
    tenkhoa nvarchar(200) not null,
    diachi  nvarchar(200),
    sdt     nvarchar(20),
    ghichu  nvarchar(max)
)
    go
create table Nganh
(
    manganh  int identity (1000,1) primary key,
    tennganh nvarchar(200) not null,
    sdt      nvarchar(20),
    ghichu   nvarchar(max),
    makhoa   int           not null,
    constraint fk_makhoa foreign key (makhoa) references khoa (makhoa),
)
    go
create table LoaiTaiSan
(
    maloai  int identity (1000,1) primary key,
    tenloai nvarchar(100) not null,
    ghichu  nvarchar(max)
)
    go
create table TaiSan
(
    mataisan  int identity (1000,1) primary key,
    tentaisan nvarchar(100) not null,
    manganh   int           not null,
    constraint fk_manganh foreign key (manganh) references Nganh (manganh),
    hinhanh   nvarchar(max),
    soluong   int default 0,
    ghichu    nvarchar(max),
    maloai    int           not null,
    constraint fk_loaitaisan foreign key (maloai) references LoaiTaiSan (maloai)
)
    go
create table PhieuNhap
(
    maphieunhap int identity (1000,1) primary key,
    ngaynhap    datetime default getdate(),
    nguoinhap   nvarchar(100),
    ghichu      nvarchar(max)
)
    go
create table ChiTietPhieuNhap
(
    mactpn      int identity (1000,1) primary key,
    maphieunhap int not null,
    constraint fk_maphieunhap foreign key (maphieunhap) references PhieuNhap (maphieunhap),
    mataisan    int not null,
    constraint fk_mataisan foreign key (mataisan) references TaiSan (mataisan),
    dongia      int not null,
    soluong     int not null,
)
    go
create table PhieuXuat
(
    maphieuxuat int identity (1000,1) primary key,
    ngayxuat    datetime default getdate(),
    nguoinhap   nvarchar(100),
    ghichu      nvarchar(max)
)
    go
create table ChiTietPhieuXuat
(
    mactpx      int identity (1000,1) primary key,
    maphieuxuat int not null,
    constraint fk_maphieuxuat foreign key (maphieuxuat) references PhieuXuat (maphieuxuat),
    mataisan    int not null,
    constraint fk_mataisan_px foreign key (mataisan) references TaiSan (mataisan),
    dongia      int,
    soluong     int not null,
)