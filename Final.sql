create database FinalKLTN
use FinalKLTN

create table TAIKHOAN
(
Id int IDENTITY(1,1) not null,
 TK varchar(50) not null,
 Pass varchar(50) not null,
 ChucDanh nvarchar(50) not null,
 TrangThai nvarchar(50) not null,
 primary key (TK)
 )
 
 create table CAPSO
(
 STT varchar(50) not null,
 HoTen nvarchar(50) not null,
 Sdt int null,
 Email varchar(50) null,
 Khoa nvarchar(80) not null,
 ThoiGian date not null,
 TrangThai nvarchar(50) not null,
 primary key (STT)
 )
 create table DSKHOA
(
 MaKhoa varchar(20) not null,
 Khoa nvarchar(80) not null,
 primary key (MaKhoa)
 )
 create table KETQUA
(
 MaPhieu varchar(10) not null,
 MaHS varchar(10) not null,
 Khoa nvarchar(80) not null,
 KetQua ntext null,
 ChuanDoan ntext null,
 LoiKhuyen ntext null,
 NgayKham date not null,
 NgayTK date null,
 Ha1 varchar(50) null,
 Ha2 varchar(50) null,
 TrangThai nvarchar(50) not null,
 primary key (MaPhieu)
 )
 create table PHIEUHEN
(
 MaPhieu varchar(10) not null,
 MaHS varchar(10) not null,
 MaDK varchar(50) not null,
 TrangThai nvarchar(50) not null,
 primary key (MaPhieu)
 )
 create table BACSI
(
 MaBS varchar(10) not null,
 HoTen nvarchar(50) not null,
 NgaySinh date not null,
 Sdt int not null,
 CCCD int not null,
 Email varchar(50) null,
 DiaChi nvarchar(150) not null,
 GioiTinh nvarchar(5) not null,
 Ha varchar(50) null,
 TK varchar(50) not null,
 Khoa nvarchar(80) not null,
 NgayBD date not null,
 GiaKham int not null,
 Lương int not null,
 TrangThai nvarchar(50) not null,
 primary key (MaBS)
 )
 create table NHANVIEN
(
 MaNV varchar(10) not null,
 HoTen nvarchar(50) not null,
 NgaySinh date not null,
 Sdt int not null,
 CCCD int not null,
 Email varchar(50) null,
 DiaChi nvarchar(150) not null,
 GioiTinh nvarchar(5) not null,
 Ha varchar(50) null,
 TK varchar(50) not null,
 ViTri nvarchar(80) not null,
 NgayBD date not null,
 Lương int not null,
 TrangThai nvarchar(50) not null,
 primary key (MaNV)
 )
 create table THOIGIANBS
(
 MaDK varchar(50) not null,
 MaBS varchar(10) not null,
 Ngay date not null,
 Gio Time not null,
 TrangThai nvarchar(50) not null,
 primary key (MaDK)
 )
 create table PHANHOI
(
 Id int IDENTITY(1,1) not null,
 HoTen nvarchar(50) not null,
 Sdt int not null,
 Email varchar(50) not null,
 NoiDung ntext not null,
 TraLoi ntext  null,
 TrangThai nvarchar(50) not null,
 primary key (Id)
 )
 create table HOSO
(
 TK varchar(50) not null,
 MaHS varchar(10) not null,
 HoTen nvarchar(50) not null,
 NgaySinh date not null,
 Sdt int not null,
 CCCD int not null,
 Email varchar(50) null,
 DiaChi nvarchar(150) not null,
 GioiTinh nvarchar(5) not null,
 NgheNghiep nvarchar(50) null,
 DanToc nvarchar(20) not null,
 primary key (MaHS)
 )
ALTER TABLE KETQUA 
ADD FOREIGN KEY (MaHS) REFERENCES HOSO(MaHS);
ALTER TABLE HOSO 
ADD FOREIGN KEY (TK) REFERENCES TAIKHOAN(TK);
ALTER TABLE NHANVIEN 
ADD FOREIGN KEY (TK) REFERENCES TAIKHOAN(TK);
ALTER TABLE BACSI 
ADD FOREIGN KEY (TK) REFERENCES TAIKHOAN(TK);
ALTER TABLE THOIGIANBS 
ADD FOREIGN KEY (MaBS) REFERENCES BACSI(MaBS);
ALTER TABLE PHIEUHEN 
ADD FOREIGN KEY (MaDK) REFERENCES THOIGIANBS(MaDK);
ALTER TABLE PHIEUHEN 
ADD FOREIGN KEY (MaHS) REFERENCES HOSO(MaHS);

------database------
---TAIKHOAN---
INSERT INTO TAIKHOAN (TK, Pass, ChucDanh, TrangThai)
VALUES ('admin', 'e10adc3949ba59abbe56e057f20f883e', 'Admin', 'Đang làm việc');
INSERT INTO TAIKHOAN (TK, Pass, ChucDanh, TrangThai)
VALUES ('poli', 'ea614bafc0dad01347bb34d814045616', 'Nhân Viên', 'Đang làm việc');---
INSERT INTO TAIKHOAN (TK, Pass, ChucDanh, TrangThai)
VALUES ('nguyenmanh', 'bb9a8018ad34926a0953f7cbfc9a5316', 'Bác sĩ', 'Đang làm việc');---
INSERT INTO TAIKHOAN (TK, Pass, ChucDanh, TrangThai)
VALUES ('longlee', '1abb3521ceb70ef277bec804912287ff', 'Nhân Viên', 'Đã nghỉ việc');---
INSERT INTO TAIKHOAN (TK, Pass, ChucDanh, TrangThai)
VALUES ('Hayetop', 'f6dad7256b9fa875970cfcca61291cc3', 'Bệnh nhân', 'Bệnh nhân');---
INSERT INTO TAIKHOAN (TK, Pass, ChucDanh, TrangThai)
VALUES ('henry', '975a2ff70b746d79b1409ab58abd7a25', 'Bệnh nhân', 'Bệnh nhân');---
INSERT INTO TAIKHOAN (TK, Pass, ChucDanh, TrangThai)
VALUES ('nuongtu', 'c33367701511b4f6020ec61ded352059', 'Bác sĩ', 'Đang làm việc');---
INSERT INTO TAIKHOAN (TK, Pass, ChucDanh, TrangThai)
VALUES ('huyhuy', '4afef0ab1a5f212059ad787029161acd', 'Nhân Viên', 'Đang làm việc');
INSERT INTO TAIKHOAN (TK, Pass, ChucDanh, TrangThai)
VALUES ('kaitop', 'b7d8bd07f84a44adb24dedb1a9c72e52', 'Bệnh nhân', 'Bệnh nhân');---
INSERT INTO TAIKHOAN (TK, Pass, ChucDanh, TrangThai)
VALUES ('kienhuu', 'fd278a8f5571d3db556bd83198beb09a', 'Nhân Viên', 'Đang làm việc');---
INSERT INTO TAIKHOAN (TK, Pass, ChucDanh, TrangThai)
VALUES ('leman', '4db72e0e86a5a18acce007b3002b18c7', 'Bác sĩ', 'Đang làm việc');---
INSERT INTO TAIKHOAN (TK, Pass, ChucDanh, TrangThai)
VALUES ('vari', '202cb962ac59075b964b07152d234b70', 'Bệnh nhân', 'Bệnh nhân');---
INSERT INTO TAIKHOAN (TK, Pass, ChucDanh, TrangThai)
VALUES ('leminhman', 'db5008d29a7dcddff104b2292d79aa7f', 'Bệnh nhân', 'Bệnh nhân');---
INSERT INTO TAIKHOAN (TK, Pass, ChucDanh, TrangThai)
VALUES ('lienxo', 'e10adc3949ba59abbe56e057f20f883e', 'Nhân Viên', 'Đã nghỉ việc');---
INSERT INTO TAIKHOAN (TK, Pass, ChucDanh, TrangThai)
VALUES ('linhloan', 'e10adc3949ba59abbe56e057f20f883e', 'Bác sĩ', 'Đã nghỉ việc');---
INSERT INTO TAIKHOAN (TK, Pass, ChucDanh, TrangThai)
VALUES ('lop', 'e10adc3949ba59abbe56e057f20f883e', 'Bác sĩ', 'Đang làm việc'); ---
INSERT INTO TAIKHOAN (TK, Pass, ChucDanh, TrangThai)
VALUES ('bichnu', 'c33367701511b4f6020ec61ded352059', 'Nhân viên', 'Đã nghỉ việc');---
INSERT INTO TAIKHOAN (TK, Pass, ChucDanh, TrangThai)
VALUES ('nguhoang', '6b38c45f3d42fab9b9f8e794e254e844', 'Bác sĩ', 'Đang làm việc');
INSERT INTO TAIKHOAN (TK, Pass, ChucDanh, TrangThai)
VALUES ('vinhxo', '3d280462749155dfa43625a49e7ea1ab', 'Nhân Viên', 'Đang làm việc');---
INSERT INTO TAIKHOAN (TK, Pass, ChucDanh, TrangThai)
VALUES ('minhmanh', 'e80b5017098950fc58aad83c8c14978e', 'Bác sĩ', 'Đang làm việc');---
INSERT INTO TAIKHOAN (TK, Pass, ChucDanh, TrangThai)
VALUES ('vivi', 'e80b5017098950fc58aad83c8c14978e', 'Bác sĩ', 'Đang làm việc');---
INSERT INTO TAIKHOAN (TK, Pass, ChucDanh, TrangThai)
VALUES ('manhdung', 'e80b5017098950fc58aad83c8c14978e', 'Bác sĩ', 'Đã nghỉ việc');---
INSERT INTO TAIKHOAN (TK, Pass, ChucDanh, TrangThai)
VALUES ('tochauninh', 'e80b5017098950fc58aad83c8c14978e', 'Bác sĩ', 'Đang làm việc');---
INSERT INTO TAIKHOAN (TK, Pass, ChucDanh, TrangThai)
VALUES ('quyenne', 'e80b5017098950fc58aad83c8c14978e', 'Bác sĩ', 'Đang làm việc');---
INSERT INTO TAIKHOAN (TK, Pass, ChucDanh, TrangThai)
VALUES ('chaukiet', 'e80b5017098950fc58aad83c8c14978e', 'Bác sĩ', 'Đang làm việc');---
---NHANVIEN---
INSERT INTO NHANVIEN(MaNV, HoTen, NgaySinh, Sdt, CCCD, Email, DiaChi, GioiTinh,Ha,TK,ViTri,NgayBD,Lương,TrangThai)
VALUES ('NV01', 'Ngô Linh', '1998-05-12', '1234567890', '123456541', 'linh@gmail.com','Gò vấp','Nam','','poli','Điều dưỡng','2023-01-01','3000000','Đang làm việc');
INSERT INTO NHANVIEN(MaNV, HoTen, NgaySinh, Sdt, CCCD, Email, DiaChi, GioiTinh,Ha,TK,ViTri,NgayBD,Lương,TrangThai)
VALUES ('NV02', 'Hữu Kiện', '2023-12-25', '98988', '64785588', 'kien@gmail.com','Bình Tân','Nam','','kienhuu','Dược sĩ','2023-01-01','3000000','Đang làm việc');
INSERT INTO NHANVIEN(MaNV, HoTen, NgaySinh, Sdt, CCCD, Email, DiaChi, GioiTinh,Ha,TK,ViTri,NgayBD,Lương,TrangThai)
VALUES ('NV03', 'Bùi Bích', '1995-08-25', '321787845', '68978976', 'biich@gmail.com','Tân Bình','Nữ','','bichnu','Tiếp tân','2023-01-01','3000000','Đang làm việc');
INSERT INTO NHANVIEN(MaNV, HoTen, NgaySinh, Sdt, CCCD, Email, DiaChi, GioiTinh,Ha,TK,ViTri,NgayBD,Lương,TrangThai)
VALUES ('NV04', 'Liên Xô Xa', '2001-06-03', '9898878', '6793699', 'xoxo@gmail.com','Quận 1','Nữ','','lienxo','Y tá','2023-01-01','3000000','Đã nghỉ việc');
INSERT INTO NHANVIEN(MaNV, HoTen, NgaySinh, Sdt, CCCD, Email, DiaChi, GioiTinh,Ha,TK,ViTri,NgayBD,Lương,TrangThai)
VALUES ('NV05', 'Long Lê', '1989-08-15', '32884465', '878965462', 'lee@gmail.com','Quận 1','Nam','','longlee','Điều dưỡng','2023-01-01','3000000','Đang làm việc');
INSERT INTO NHANVIEN(MaNV, HoTen, NgaySinh, Sdt, CCCD, Email, DiaChi, GioiTinh,Ha,TK,ViTri,NgayBD,Lương,TrangThai)
VALUES ('NV06', 'Lê Vinh', '2000-01-12', '866786786', '678966', 'dcl@gmail.com','Bình Tân','Nam','','vinhxo','Bảo vệ','2023-01-01','3000000','Đang làm việc');
---HOSO---
INSERT INTO HOSO (TK,MaHS, HoTen, NgaySinh, Sdt, CCCD, Email, DiaChi, GioiTinh,NgheNghiep, DanToc)
VALUES ('henry', 'henry-1', 'Henry', '1995-12-12', '874244622', '568646885','henry@gmail.com', 'Quận 1','Nam','Giáo viên','Kinh');
INSERT INTO HOSO (TK,MaHS, HoTen, NgaySinh, Sdt, CCCD, Email, DiaChi, GioiTinh,NgheNghiep, DanToc)
VALUES ('henry', 'henry-2', 'Anna', '1995-12-12', '874244622', '568646885','henry@gmail.com', 'Quận 1','Nữ','Thợ điện','Kinh');
INSERT INTO HOSO (TK,MaHS, HoTen, NgaySinh, Sdt, CCCD, Email, DiaChi, GioiTinh,NgheNghiep, DanToc)
VALUES ('henry', 'henry-3', 'Jame', '1990-05-25', '874244622', '568646885','henry@gmail.com', 'Quận 1','Nữ','Phi cơ','Mông');
INSERT INTO HOSO (TK,MaHS, HoTen, NgaySinh, Sdt, CCCD, Email, DiaChi, GioiTinh,NgheNghiep, DanToc)
VALUES ('kaitop', 'kai-1', 'Khải', '1990-05-25', '14785236', '36521498','kaikai@gmail.com', 'Quận 5','Nam','Thợ mộc','Kinh');
INSERT INTO HOSO (TK,MaHS, HoTen, NgaySinh, Sdt, CCCD, Email, DiaChi, GioiTinh,NgheNghiep, DanToc)
VALUES ('leminhman', 'man-1', 'Mẫn', '2001-01-01', '68756896', '568646885','man@gmail.com', 'Quận 6','Nam','Sinh viên','Kinh');
INSERT INTO HOSO (TK,MaHS, HoTen, NgaySinh, Sdt, CCCD, Email, DiaChi, GioiTinh,NgheNghiep, DanToc)
VALUES ('leminhman', 'man-2', 'Mạng', '2001-01-01', '68756896', '568646885','man@gmail.com', 'Quận 6','Nam','Sinh viên','Kinh');
INSERT INTO HOSO (TK,MaHS, HoTen, NgaySinh, Sdt, CCCD, Email, DiaChi, GioiTinh,NgheNghiep, DanToc)
VALUES ('Hayetop', 'top-1', 'Hùng', '1989-11-05', '564654', '568646885','toptop@gmail.com', 'Quận 5','Nam','Tài xế','Kinh');
INSERT INTO HOSO (TK,MaHS, HoTen, NgaySinh, Sdt, CCCD, Email, DiaChi, GioiTinh,NgheNghiep, DanToc)
VALUES ('Hayetop', 'top-2', 'Tĩnh', '2015-01-01', '564654', '36521498','toptop@gmail.com', 'Quận 5','Nam','Học sinh','Kinh');
INSERT INTO HOSO (TK,MaHS, HoTen, NgaySinh, Sdt, CCCD, Email, DiaChi, GioiTinh,NgheNghiep, DanToc)
VALUES ('vari', 'vari-1', 'Nguyễn Lệ Minh', '2001-01-01', '68756896', '568646885','minmin@gmail.com', 'Quận 8','Nam','Sinh viên','Kinh');
INSERT INTO HOSO (TK,MaHS, HoTen, NgaySinh, Sdt, CCCD, Email, DiaChi, GioiTinh,NgheNghiep, DanToc)
VALUES ('vari', 'vari-2', 'Hiếu Nguyễn', '2002-02-02', '555555555', '568646885','minmin@gmail.com', 'Quận 8','Nam','Tài xế','Kinh');
INSERT INTO HOSO (TK,MaHS, HoTen, NgaySinh, Sdt, CCCD, Email, DiaChi, GioiTinh,NgheNghiep, DanToc)
VALUES ('vari', 'vari-3', 'Mã linh', '2003-02-02', '564654', '36521498','minmin@gmail.com', 'Quận 8','Nam','Học sinh','Kinh');
---KETQUA---
INSERT INTO KETQUA (MaPhieu,MaHS, Khoa, KetQua, ChuanDoan, LoiKhuyen, NgayKham, NgayTK, Ha1, Ha2, TrangThai)
VALUES ('162023-P6', 'top-11', 'Khoa Nội tiết', 'Nội tiết tố thay đổi', 'Tuổi thay đổi', 'Uống nhiều nước','2023-06-01', '','','','Đã khám');
INSERT INTO KETQUA (MaPhieu,MaHS, Khoa, KetQua, ChuanDoan, LoiKhuyen, NgayKham, NgayTK, Ha1, Ha2, TrangThai)
VALUES ('362023-P1', 'vari-1', 'Khoa Chẩn đoán hình ảnh', 'Bình thường', 'Không có vấn đề gì', 'Uống nhiều nước','2023-06-03', '','','','Đã khám');
INSERT INTO KETQUA (MaPhieu,MaHS, Khoa, KetQua, ChuanDoan, LoiKhuyen, NgayKham, NgayTK, Ha1, Ha2, TrangThai)
VALUES ('362023-P3', 'man-2', 'Khoa Thần kinh', 'Lêch dây thần kinh', 'Liệt dây thần kinh', 'Nhập viện sớm','2023-06-03', '2023-06-04','','','Đã khám');
INSERT INTO KETQUA (MaPhieu,MaHS, Khoa, KetQua, ChuanDoan, LoiKhuyen, NgayKham, NgayTK, Ha1, Ha2, TrangThai)
VALUES ('462023-P2', 'vari-1', 'Khoa Chẩn đoán hình ảnh', 'Bình thường', 'Không có vấn đề gì', 'Uống nhiều nước','2023-06-04', '','','','Đã khám');
INSERT INTO KETQUA (MaPhieu,MaHS, Khoa, KetQua, ChuanDoan, LoiKhuyen, NgayKham, NgayTK, Ha1, Ha2, TrangThai)
VALUES ('462023-P4', 'man-2', 'Khoa Thần kinh', '', '', '','2023-06-04', '','','','Chưa khám');
---BACSI---
INSERT INTO BACSI (MaBS, HoTen, NgaySinh, Sdt, CCCD, Email, DiaChi, GioiTinh, Ha, TK, Khoa, NgayBD, GiaKham, Lương, TrangThai)
VALUES ('BS01', 'Lê Xuân Tiến', '1995-01-01', '1111111111', '222222222', 'tien@gmail.com','Quận 1', 'Nam','','lop','Khoa Nội tim mạch', '2022-01-13','300000','10000000','Đang làm việc');
INSERT INTO BACSI (MaBS, HoTen, NgaySinh, Sdt, CCCD, Email, DiaChi, GioiTinh, Ha, TK, Khoa, NgayBD, GiaKham, Lương, TrangThai)
VALUES ('BS02', 'Minh Mạnh', '1999-02-02', '12345696', '321654741', 'manh@gmail.com','Quận 8', 'Nam','','minhmanh','Khoa Dược', '2021-02-14','250000','9000000','Đang làm việc');
INSERT INTO BACSI (MaBS, HoTen, NgaySinh, Sdt, CCCD, Email, DiaChi, GioiTinh, Ha, TK, Khoa, NgayBD, GiaKham, Lương, TrangThai)
VALUES ('BS03', 'Linh Loan', '2000-04-30', '987564123', '365214789', 'loan@gmail.com','Bình Dương', 'Nữ','','linhloan','Khoa Chẩn đoán hình ảnh', '2023-03-02','100000','9500000','Đã nghỉ việc');
INSERT INTO BACSI (MaBS, HoTen, NgaySinh, Sdt, CCCD, Email, DiaChi, GioiTinh, Ha, TK, Khoa, NgayBD, GiaKham, Lương, TrangThai)
VALUES ('BS04', 'Nguyễn Mạnh', '1995-03-03', '258741369', '321987456', 'man@gmail.com','Quận 1', 'Nam','','nguyenmanh','Khoa Bỏng', '2021-02-14','250000','9000000','Đang làm việc');
INSERT INTO BACSI (MaBS, HoTen, NgaySinh, Sdt, CCCD, Email, DiaChi, GioiTinh, Ha, TK, Khoa, NgayBD, GiaKham, Lương, TrangThai)
VALUES ('BS06', 'Lê Mẫn', '1975-06-05', '654789321', '321548897', 'manman@gmail.com','Quận 1', 'Nữ','','leman','Khoa Nhi', '2022-01-13','300000','10000000','Đã nghỉ việc');
INSERT INTO BACSI (MaBS, HoTen, NgaySinh, Sdt, CCCD, Email, DiaChi, GioiTinh, Ha, TK, Khoa, NgayBD, GiaKham, Lương, TrangThai)
VALUES ('BS07', 'Hoàng Vi', '1990-09-06', '12345696', '321654741', 'vivi@gmail.com','Quận 8', 'Nữ','','vivi','Khoa Lọc máu (thận nhân tạo)', '2021-02-14','250000','9000000','Đang làm việc');
INSERT INTO BACSI (MaBS, HoTen, NgaySinh, Sdt, CCCD, Email, DiaChi, GioiTinh, Ha, TK, Khoa, NgayBD, GiaKham, Lương, TrangThai)
VALUES ('BS08', 'Mạnh Dũng', '1995-07-13', '987564123', '365214789', 'dungm@gmail.com','Bình Dương', 'Nam','','manhdung','Khoa mắt', '2023-03-02','100000','9500000','Đã nghỉ việc');
INSERT INTO BACSI (MaBS, HoTen, NgaySinh, Sdt, CCCD, Email, DiaChi, GioiTinh, Ha, TK, Khoa, NgayBD, GiaKham, Lương, TrangThai)
VALUES ('BS09', 'Tô Châu Ninh', '2001-04-03', '258741369', '321987456', 'ninhninh@gmail.com','Quận 1', 'Nam','','tochauninh','Khoa Thần kinh', '2021-02-14','250000','9000000','Đang làm việc');
INSERT INTO BACSI (MaBS, HoTen, NgaySinh, Sdt, CCCD, Email, DiaChi, GioiTinh, Ha, TK, Khoa, NgayBD, GiaKham, Lương, TrangThai)
VALUES ('BS10', 'Ngô Quyền', '1950-09-25', '12345696', '321654741', 'quyen@gmail.com','Quận 8', 'Nam','','quyenne','Khoa Tai – mũi – họng', '2021-02-14','250000','9000000','Đang làm việc');
INSERT INTO BACSI (MaBS, HoTen, NgaySinh, Sdt, CCCD, Email, DiaChi, GioiTinh, Ha, TK, Khoa, NgayBD, GiaKham, Lương, TrangThai)
VALUES ('BS11', 'Châu Kiệt', '1985-04-25', '987564123', '365214789', 'kiet@gmail.com','Bình Dương', 'Nam','','chaukiet','Khoa Nội tim mạch', '2023-03-02','100000','9500000','Đã nghỉ việc');
INSERT INTO BACSI (MaBS, HoTen, NgaySinh, Sdt, CCCD, Email, DiaChi, GioiTinh, Ha, TK, Khoa, NgayBD, GiaKham, Lương, TrangThai)
VALUES ('BS12', 'Nương Nương', '1975-11-25', '258741369', '321987456', 'nuong@gmail.com','Quận 1', 'Nam','','nuongtu','Khoa Phụ sản', '2021-02-14','250000','9000000','Đang làm việc');
---CAPSO---
INSERT INTO CAPSO (STT, HoTen, Sdt, Email, Khoa, ThoiGian, TrangThai)
VALUES ('11062023-6', 'Lê Vinh', '6413132', 'yuio@gmail.com', 'Khoa Huyến Học lâm sàng', '2023-06-11','Đã sử dụng');
INSERT INTO CAPSO (STT, HoTen, Sdt, Email, Khoa, ThoiGian, TrangThai)
VALUES ('11062023-7', 'Lựu', '6532', 'opo@gmail.com', 'Khoa Dinh dưỡng', '2023-06-11','Đã bỏ');
INSERT INTO CAPSO (STT, HoTen, Sdt, Email, Khoa, ThoiGian, TrangThai)
VALUES ('11062023-8', 'Danh', '1457575', 'huynhsi342001@gmail.com', 'Khoa Chống nhiễm khuẩn', '2023-06-11','Đang chờ');
INSERT INTO CAPSO (STT, HoTen, Sdt, Email, Khoa, ThoiGian, TrangThai)
VALUES ('11062023-9', 'Hữu Nghị', '121111', 'nghi@gmail.com', 'Khoa Huyến Học lâm sàng', '2023-06-11','Đang chờ');
INSERT INTO CAPSO (STT, HoTen, Sdt, Email, Khoa, ThoiGian, TrangThai)
VALUES ('19062023-1', 'Bùi Bích Chung', '369852147', 'cv@gmail.com', 'Khoa khám bệnh', '2023-06-19','Đang chờ');
---DSKHOA---
INSERT INTO DSKHOA (MaKhoa, Khoa)
VALUES ('k-01', 'Khoa Bỏng');
INSERT INTO DSKHOA (MaKhoa, Khoa)
VALUES ('k-02', 'Khoa Chẩn đoán hình ảnh');
INSERT INTO DSKHOA (MaKhoa, Khoa)
VALUES ('k-03', 'Khoa Chấn thương chỉnh hình');
INSERT INTO DSKHOA (MaKhoa, Khoa)
VALUES ('k-04', 'Khoa Chống nhiễm khuẩn');
INSERT INTO DSKHOA (MaKhoa, Khoa)
VALUES ('k-05', 'Khoa Da Liễu');
INSERT INTO DSKHOA (MaKhoa, Khoa)
VALUES ('k-06', 'Khoa Dị ứng');
INSERT INTO DSKHOA (MaKhoa, Khoa)
VALUES ('k-07', 'Khoa Dinh dưỡng');
INSERT INTO DSKHOA (MaKhoa, Khoa)
VALUES ('k-08', 'Khoa Dược');
INSERT INTO DSKHOA (MaKhoa, Khoa)
VALUES ('k-09', 'Khoa Giải phẫu bệnh');
INSERT INTO DSKHOA (MaKhoa, Khoa)
VALUES ('k-10', 'Khoa Hóa Sinh');
INSERT INTO DSKHOA (MaKhoa, Khoa)
VALUES ('k-11', 'Khoa Hồi sức cấp cứu');
INSERT INTO DSKHOA (MaKhoa, Khoa)
VALUES ('k-12', 'Khoa Huyến học');
INSERT INTO DSKHOA (MaKhoa, Khoa)
VALUES ('k-13', 'Khoa Huyến Học lâm sàng');
INSERT INTO DSKHOA (MaKhoa, Khoa)
VALUES ('k-14', 'Khoa khám bệnh');
INSERT INTO DSKHOA (MaKhoa, Khoa)
VALUES ('k-15', 'Khoa Lao');
INSERT INTO DSKHOA (MaKhoa, Khoa)
VALUES ('k-16', 'Khoa Lão học');
INSERT INTO DSKHOA (MaKhoa, Khoa)
VALUES ('k-17', 'Khoa Lọc máu (thận nhân tạo)');
INSERT INTO DSKHOA (MaKhoa, Khoa)
VALUES ('k-18', 'Khoa mắt');
INSERT INTO DSKHOA (MaKhoa, Khoa)
VALUES ('k-19', 'Khoa Ngoại lồng ngực');
INSERT INTO DSKHOA (MaKhoa, Khoa)
VALUES ('k-20', 'Khoa Ngoại thận – tiết niệu');
INSERT INTO DSKHOA (MaKhoa, Khoa)
VALUES ('k-21', 'Khoa Ngoại thần kinh');
INSERT INTO DSKHOA (MaKhoa, Khoa)
VALUES ('k-22', 'Khoa Ngoại tiêu hóa');
INSERT INTO DSKHOA (MaKhoa, Khoa)
VALUES ('k-23', 'Khoa Ngoại tổng hợp');
INSERT INTO DSKHOA (MaKhoa, Khoa)
VALUES ('k-24', 'Khoa Nhi');
INSERT INTO DSKHOA (MaKhoa, Khoa)
VALUES ('k-25', 'Khoa Nội cơ – xương – khớp');
INSERT INTO DSKHOA (MaKhoa, Khoa)
VALUES ('k-26', 'Khoa Nội soi');
INSERT INTO DSKHOA (MaKhoa, Khoa)
VALUES ('k-27', 'Khoa Nội thận – tiết niệu');
INSERT INTO DSKHOA (MaKhoa, Khoa)
VALUES ('k-28', 'Khoa Nội tiết');
INSERT INTO DSKHOA (MaKhoa, Khoa)
VALUES ('k-29', 'Khoa Nội tiêu hóa');
INSERT INTO DSKHOA (MaKhoa, Khoa)
VALUES ('k-30', 'Khoa Nội tim mạch');
INSERT INTO DSKHOA (MaKhoa, Khoa)
VALUES ('k-31', 'Khoa Nội tổng hợp');
INSERT INTO DSKHOA (MaKhoa, Khoa)
VALUES ('k-32', 'Khoa Phẩu thuật gây mê hồi sức');
INSERT INTO DSKHOA (MaKhoa, Khoa)
VALUES ('k-33', 'Khoa Phụ sản');
INSERT INTO DSKHOA (MaKhoa, Khoa)
VALUES ('k-34', 'Khoa Răng - hàm – mặt');
INSERT INTO DSKHOA (MaKhoa, Khoa)
VALUES ('k-35', 'Khoa Tai – mũi – họng');
INSERT INTO DSKHOA (MaKhoa, Khoa)
VALUES ('k-36', 'Khoa Tâm thần');
INSERT INTO DSKHOA (MaKhoa, Khoa)
VALUES ('k-37', 'Khoa Thăm dò chức năng');
INSERT INTO DSKHOA (MaKhoa, Khoa)
VALUES ('k-38', 'Khoa Thần kinh');
INSERT INTO DSKHOA (MaKhoa, Khoa)
VALUES ('k-39', 'Khoa Truyền máu');
INSERT INTO DSKHOA (MaKhoa, Khoa)
VALUES ('k-40', 'Khoa Truyền nhiễm');
INSERT INTO DSKHOA (MaKhoa, Khoa)
VALUES ('k-41', 'Khoa Vật lý trị liệu – phục hồi chức năng');
INSERT INTO DSKHOA (MaKhoa, Khoa)
VALUES ('k-42', 'Khoa Vi sinh');
INSERT INTO DSKHOA (MaKhoa, Khoa)
VALUES ('k-43', 'Khoa Y học cổ truyền');
INSERT INTO DSKHOA (MaKhoa, Khoa)
VALUES ('k-44', 'Khoa Y học hạt nhân');
---PHANHOI---
INSERT INTO PHANHOI(HoTen,Sdt,Email,NoiDung,TraLoi,TrangThai)
VALUES ('Lê Hoàng', '123456','Hoang@gmail.com','Lorem Ipsum is simply dummy text of the printing and typesetting industry  Lorem Ipsum has been the industrys standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged','Chưa trả lời');
INSERT INTO PHANHOI(HoTen,Sdt,Email,NoiDung,TraLoi,TrangThai)
VALUES ('Lê Hoàng', '123456','Hoang@gmail.com','Lorem Ipsum is simply dummy text of the printing and typesetting industry  Lorem Ipsum has been the industrys standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged','Chưa trả lời');
INSERT INTO PHANHOI(HoTen,Sdt,Email,NoiDung,TraLoi,TrangThai)
VALUES ('Lê Hoàng', '123456','Hoang@gmail.com','Lorem Ipsum is simply dummy text of the printing and typesetting industry  Lorem Ipsum has been the industrys standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged','Chưa trả lời');
INSERT INTO PHANHOI(HoTen,Sdt,Email,NoiDung,TraLoi,TrangThai)
VALUES ('Lê Hoàng', '123456','Hoang@gmail.com','Lorem Ipsum is simply dummy text of the printing and typesetting industry  Lorem Ipsum has been the industrys standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged','Chưa trả lời');
INSERT INTO PHANHOI(HoTen,Sdt,Email,NoiDung,TraLoi,TrangThai)
VALUES ('Lê Hoàng', '123456','Hoang@gmail.com','Lorem Ipsum is simply dummy text of the printing and typesetting industry  Lorem Ipsum has been the industrys standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged','Chưa trả lời');
INSERT INTO PHANHOI(HoTen,Sdt,Email,NoiDung,TraLoi,TrangThai)
VALUES ('Lê Hoàng', '123456','Hoang@gmail.com','Lorem Ipsum is simply dummy text of the printing and typesetting industry  Lorem Ipsum has been the industrys standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged','Chưa trả lời');
---PHIEUHEN---
INSERT INTO PHIEUHEN(MaPhieu,MaHS,MaDK,TrangThai)
VALUES ('PH-1', 'henry-1','SCH1','Chưa khám');
INSERT INTO PHIEUHEN(MaPhieu,MaHS,MaDK,TrangThai)
VALUES ('PH-2', 'henry-1','SCH2','Đã khám');
INSERT INTO PHIEUHEN(MaPhieu,MaHS,MaDK,TrangThai)
VALUES ('PH-3', 'kai-1','SCH3','Đã hủy lịch');
INSERT INTO PHIEUHEN(MaPhieu,MaHS,MaDK,TrangThai)
VALUES ('PH-4', 'kai-1','SCH7','Đã hủy lịch');
---THOIGIANBS---
INSERT INTO THOIGIANBS(MaDK,MaDK,Ngay,Gio,TrangThai)
VALUES ('SCH1', 'BS01','2023-06-09','14:12:00','Đã đặt');
INSERT INTO THOIGIANBS(MaDK,MaDK,Ngay,Gio,TrangThai)
VALUES ('SCH2', 'BS02','2023-06-20','10:10:00','Đã đặt');
INSERT INTO THOIGIANBS(MaDK,MaDK,Ngay,Gio,TrangThai)
VALUES ('SCH3', 'BS02','2023-06-15','19:17:00','Đã hủy');
INSERT INTO THOIGIANBS(MaDK,MaDK,Ngay,Gio,TrangThai)
VALUES ('SCH4', 'BS10','2023-06-08','02:37:00','Chưa đặt');
INSERT INTO THOIGIANBS(MaDK,MaDK,Ngay,Gio,TrangThai)
VALUES ('SCH5', 'BS12','2023-06-24','04:00:00','Chưa đặt');
INSERT INTO THOIGIANBS(MaDK,MaDK,Ngay,Gio,TrangThai)
VALUES ('SCH7', 'BS06','2023-06-25','14:12:00','Đã đặt');
