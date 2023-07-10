CREATE DATABASE mavi_db;
use mavi_db;
CREATE TABLE mavi_musteriler 
(
  musteri_id varchar(64) not null,
  musteri_ad varchar(64) not null,
  musteri_soyad varchar(64) not null,
  musteri_tel varchar(64) not null,
  musteri_mail varchar(64) not null,
  musteri_adres varchar(64) not null,
  primary key(musteri_id)
);
CREATE TABLE mavi_urunler
(
	urun_id varchar(64) not null,
    urun_ad varchar(64) not null,
    urun_kategori varchar(64) not null,
    urun_fiyat float not null,
    urun_stok float not null,
    urun_birim float not null,
    urun_detay varchar(64) not null,
	primary key(urun_id)
);
CREATE TABLE mavi_satislar
(
    satis_id varchar(64) not null,
    musteri_id varchar(64) not null,
    urun_id varchar(64) not null,
    satis_tarih datetime not null,
    satis_fiyat float not null,
    primary key(satis_id),
    foreign key(urun_id) references mavi_urunler(urun_id) on delete cascade on update cascade,
    foreign key(musteri_id) references mavi_musteriler(musteri_id) on delete cascade on update cascade
);
CREATE TABLE mavi_odemeler
(
	odeme_id varchar(64) not null,
    musteri_id varchar(64) not null,
    odeme_tarih datetime not null,
    odeme_tutar float not null,
    odeme_tur varchar(64) not null,
    odeme_aciklama varchar(64) not null,
    primary key(odeme_id),
    foreign key(musteri_id) references mavi_musteriler(musteri_id) on delete cascade on update cascade
);
ALTER TABLE mavi_urunler MODIFY COLUMN urun_birim varchar(64);
