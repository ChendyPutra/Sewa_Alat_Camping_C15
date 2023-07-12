create database Final_Project_C15

create table pemilik(
id_pemilik char (10) primary key,
nama_toko varchar (10),
alamat varchar (50),
no_telepon char (12),
email varchar (50),
)

create table costumer(
nik char (15) primary key,
nama varchar (20),
alamat varchar (50),
no_telepon char (12),
username char (10),
pass varchar (20),
)

create table pegawai(
NIK char (15) primary key,
nama varchar (20),
no_telepon char (12),
alamat varchar (50),

)

create table alat_camping(
no_alat char(5) primary key,
nama_alat varchar (20),
harga money,
stock varchar (10),
kondisi varchar (10),
)

create table kurir(
id_driver char (5) primary key,
nama_driver varchar(20),
jenis_kendaraan varchar (20),
plat_nomor char (10),
)