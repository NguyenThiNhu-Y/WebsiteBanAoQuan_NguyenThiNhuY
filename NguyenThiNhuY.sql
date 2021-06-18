create database HoTenDB
go
use HoTenDB
go
set dateformat dmy

create table tblUserAccount (
id int primary key identity,
UserName varchar(50), 
password varchar(50), 
status varchar(20) default 'activated'
)

insert into tblUserAccount values
('admin','123',default),
('nhuy','12345',default),
('abc','333', 'blocked')

create table tblCategory(
 id varchar(10) primary key , 
 name nvarchar(50), 
 description nvarchar(200)
 )

 insert into tblCategory values
 ('LO001',N'Áo',N'có nhiều mẫu mã'),
 ('LO002',N'Quần',N'có nhiều kích cỡ')

 create table tblProduct
 (ID varchar(10) primary key,
 Name nvarchar(50), 
 UnitCost money, 
 Quantity int, 
 image varchar(max), 
 Description nvarchar(200), 
 Status varchar(20) default 'c',
 idCategoryNo varchar(10) foreign key references tblCategory(id)
 )

 insert into tblProduct values
 ('SP001',N'Áo thun', 90000,100,null,N'vải thun mát mẻ', default,'LO001'),
 ('SP002',N'Áo khoác', 200000,110,null,N'chống nắng tốt', default,'LO001'),
 ('SP003',N'Áo croptop', 100000,120,null,N'dễ thương, phù hợp cho các bạn trẻ', default,'LO001'),
 ('SP004',N'quần tây', 190000,90,null,N'aaaaaaaa', default,'LO002'),
 ('SP005',N'quần jean', 290000,100,null,N'bbbbbbbbbbbb', default,'LO002')