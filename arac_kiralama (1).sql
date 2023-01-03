-- phpMyAdmin SQL Dump
-- version 5.1.3
-- https://www.phpmyadmin.net/
--
-- Anamakine: 127.0.0.1
-- Üretim Zamanı: 03 Oca 2023, 18:10:19
-- Sunucu sürümü: 8.0.28
-- PHP Sürümü: 8.1.2

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Veritabanı: `arac_kiralama`
--

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `admin`
--

CREATE TABLE `admin` (
  `id` int NOT NULL,
  `isim` varchar(100) COLLATE utf8mb4_unicode_ci NOT NULL,
  `sifre` varchar(100) COLLATE utf8mb4_unicode_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Tablo döküm verisi `admin`
--

INSERT INTO `admin` (`id`, `isim`, `sifre`) VALUES
(1, 'admin', '1');

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `araçlar`
--

CREATE TABLE `araçlar` (
  `id` int NOT NULL,
  `Plaka` varchar(100) COLLATE utf8mb4_unicode_ci NOT NULL,
  `Marka` varchar(100) COLLATE utf8mb4_unicode_ci NOT NULL,
  `Seri` varchar(100) COLLATE utf8mb4_unicode_ci NOT NULL,
  `Model` varchar(100) COLLATE utf8mb4_unicode_ci NOT NULL,
  `Renk` varchar(100) COLLATE utf8mb4_unicode_ci NOT NULL,
  `MotorGücü` varchar(100) COLLATE utf8mb4_unicode_ci NOT NULL,
  `MotorHacmi` varchar(100) COLLATE utf8mb4_unicode_ci NOT NULL,
  `BakımTarihi` varchar(100) COLLATE utf8mb4_unicode_ci NOT NULL,
  `Kilometre` varchar(100) COLLATE utf8mb4_unicode_ci NOT NULL,
  `YakıtTürü` varchar(100) COLLATE utf8mb4_unicode_ci NOT NULL,
  `GünlükFiyat` varchar(100) COLLATE utf8mb4_unicode_ci NOT NULL,
  `Açıklama` varchar(100) COLLATE utf8mb4_unicode_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Tablo döküm verisi `araçlar`
--

INSERT INTO `araçlar` (`id`, `Plaka`, `Marka`, `Seri`, `Model`, `Renk`, `MotorGücü`, `MotorHacmi`, `BakımTarihi`, `Kilometre`, `YakıtTürü`, `GünlükFiyat`, `Açıklama`) VALUES
(2, '2347823', 'Mercedes', '321', 'E246', 'Beyaz', '6.2', '4', '5 Ocak 2023 Perşembe', '200km', 'Benzinli', '1000tl', 'Aracimiz hizlidir');

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `boşaraçlar`
--

CREATE TABLE `boşaraçlar` (
  `id` int NOT NULL,
  `Plaka` varchar(100) COLLATE utf8mb4_unicode_ci NOT NULL,
  `Marka` varchar(100) COLLATE utf8mb4_unicode_ci NOT NULL,
  `Seri` varchar(100) COLLATE utf8mb4_unicode_ci NOT NULL,
  `Model` varchar(100) COLLATE utf8mb4_unicode_ci NOT NULL,
  `Renk` varchar(100) COLLATE utf8mb4_unicode_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `calisanlar`
--

CREATE TABLE `calisanlar` (
  `id` int NOT NULL,
  `kullAdi` varchar(100) COLLATE utf8mb4_unicode_ci NOT NULL,
  `sifre` varchar(100) COLLATE utf8mb4_unicode_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Tablo döküm verisi `calisanlar`
--

INSERT INTO `calisanlar` (`id`, `kullAdi`, `sifre`) VALUES
(6, 'esmail', '2');

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `doluaraçlar`
--

CREATE TABLE `doluaraçlar` (
  `id` int NOT NULL,
  `Plaka` varchar(1000) COLLATE utf8mb4_unicode_ci NOT NULL,
  `Marka` varchar(100) COLLATE utf8mb4_unicode_ci NOT NULL,
  `Seri` varchar(100) COLLATE utf8mb4_unicode_ci NOT NULL,
  `Model` varchar(200) COLLATE utf8mb4_unicode_ci NOT NULL,
  `Renk` varchar(80) COLLATE utf8mb4_unicode_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Tablo döküm verisi `doluaraçlar`
--

INSERT INTO `doluaraçlar` (`id`, `Plaka`, `Marka`, `Seri`, `Model`, `Renk`) VALUES
(2, '2347823', 'Mercedes', '321', 'E246', 'Beyaz');

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `giderislemleri`
--

CREATE TABLE `giderislemleri` (
  `id` int NOT NULL,
  `tarih` varchar(100) COLLATE utf8mb4_unicode_ci NOT NULL,
  `tutar` int NOT NULL,
  `aciklama` varchar(300) COLLATE utf8mb4_unicode_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Tablo döküm verisi `giderislemleri`
--

INSERT INTO `giderislemleri` (`id`, `tarih`, `tutar`, `aciklama`) VALUES
(1, '2 Ocak 2023 Pazartesi', 1200, 'Tamir');

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `kasa`
--

CREATE TABLE `kasa` (
  `id` int NOT NULL,
  `SözleşmeTarihi` varchar(200) COLLATE utf8mb4_unicode_ci NOT NULL,
  `MüşteriAdSoyad` varchar(200) COLLATE utf8mb4_unicode_ci NOT NULL,
  `SeçilenAraba` varchar(200) COLLATE utf8mb4_unicode_ci NOT NULL,
  `ToplamTutar` int NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Tablo döküm verisi `kasa`
--

INSERT INTO `kasa` (`id`, `SözleşmeTarihi`, `MüşteriAdSoyad`, `SeçilenAraba`, `ToplamTutar`) VALUES
(1, '2 Ocak 2023 Pazartesi', 'Esmail Sarwari', '2347823', 2600);

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `yenisözleşme`
--

CREATE TABLE `yenisözleşme` (
  `id` int NOT NULL,
  `SözleşmeTarihi` varchar(200) COLLATE utf8mb4_unicode_ci NOT NULL,
  `TcKimlik` varchar(200) COLLATE utf8mb4_unicode_ci NOT NULL,
  `AdSoyad` varchar(200) COLLATE utf8mb4_unicode_ci NOT NULL,
  `Cinsiyet` varchar(200) COLLATE utf8mb4_unicode_ci NOT NULL,
  `DoğumTarihi` varchar(200) COLLATE utf8mb4_unicode_ci NOT NULL,
  `DoğumYeri` varchar(200) COLLATE utf8mb4_unicode_ci NOT NULL,
  `CepTelefon` varchar(200) COLLATE utf8mb4_unicode_ci NOT NULL,
  `EMail` varchar(200) COLLATE utf8mb4_unicode_ci NOT NULL,
  `Adres` varchar(200) COLLATE utf8mb4_unicode_ci NOT NULL,
  `EhliyetNo` varchar(200) COLLATE utf8mb4_unicode_ci NOT NULL,
  `EhliyetTarihi` varchar(100) COLLATE utf8mb4_unicode_ci NOT NULL,
  `EhliyetVerilenYer` varchar(200) COLLATE utf8mb4_unicode_ci NOT NULL,
  `ÇıkışZamanı` varchar(200) COLLATE utf8mb4_unicode_ci NOT NULL,
  `DönüşZamanı` varchar(200) COLLATE utf8mb4_unicode_ci NOT NULL,
  `KullanımSüresi` varchar(200) COLLATE utf8mb4_unicode_ci NOT NULL,
  `VekilAdSoyad` varchar(200) COLLATE utf8mb4_unicode_ci NOT NULL,
  `VekilCepTelefon` varchar(200) COLLATE utf8mb4_unicode_ci NOT NULL,
  `Plaka` varchar(200) COLLATE utf8mb4_unicode_ci NOT NULL,
  `Marka` varchar(200) COLLATE utf8mb4_unicode_ci NOT NULL,
  `Seri` varchar(200) COLLATE utf8mb4_unicode_ci NOT NULL,
  `Model` varchar(200) COLLATE utf8mb4_unicode_ci NOT NULL,
  `Renk` varchar(100) COLLATE utf8mb4_unicode_ci NOT NULL,
  `Açıklama` varchar(200) COLLATE utf8mb4_unicode_ci NOT NULL,
  `ToplamTutar` varchar(200) COLLATE utf8mb4_unicode_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Tablo döküm verisi `yenisözleşme`
--

INSERT INTO `yenisözleşme` (`id`, `SözleşmeTarihi`, `TcKimlik`, `AdSoyad`, `Cinsiyet`, `DoğumTarihi`, `DoğumYeri`, `CepTelefon`, `EMail`, `Adres`, `EhliyetNo`, `EhliyetTarihi`, `EhliyetVerilenYer`, `ÇıkışZamanı`, `DönüşZamanı`, `KullanımSüresi`, `VekilAdSoyad`, `VekilCepTelefon`, `Plaka`, `Marka`, `Seri`, `Model`, `Renk`, `Açıklama`, `ToplamTutar`) VALUES
(2, '2 Ocak 2023 Pazartesi', '9963235532', 'Esmail Sarwari', 'Bay', '2 Ocak 2023 Pazartesi', 'Gazne', '342543465', 'esmail.sarwari10@gmail.com', 'Kutahya', '398hu', '2 Ocak 2023 Pazartesi', 'Kutahya Bel', '2 Ocak 2023 Pazartesi', '4 Ocak 2023 Çarşamba', '2', 'Nihat Aliyev', '05313173909', '2347823', 'Mercedes', '321', 'E246', 'Beyaz', 'Temiz Arac', '2600');

--
-- Dökümü yapılmış tablolar için indeksler
--

--
-- Tablo için indeksler `admin`
--
ALTER TABLE `admin`
  ADD PRIMARY KEY (`id`);

--
-- Tablo için indeksler `araçlar`
--
ALTER TABLE `araçlar`
  ADD PRIMARY KEY (`id`);

--
-- Tablo için indeksler `boşaraçlar`
--
ALTER TABLE `boşaraçlar`
  ADD PRIMARY KEY (`id`);

--
-- Tablo için indeksler `calisanlar`
--
ALTER TABLE `calisanlar`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `kullAdi` (`kullAdi`);

--
-- Tablo için indeksler `doluaraçlar`
--
ALTER TABLE `doluaraçlar`
  ADD PRIMARY KEY (`id`);

--
-- Tablo için indeksler `giderislemleri`
--
ALTER TABLE `giderislemleri`
  ADD PRIMARY KEY (`id`);

--
-- Tablo için indeksler `kasa`
--
ALTER TABLE `kasa`
  ADD PRIMARY KEY (`id`);

--
-- Tablo için indeksler `yenisözleşme`
--
ALTER TABLE `yenisözleşme`
  ADD PRIMARY KEY (`id`);

--
-- Dökümü yapılmış tablolar için AUTO_INCREMENT değeri
--

--
-- Tablo için AUTO_INCREMENT değeri `admin`
--
ALTER TABLE `admin`
  MODIFY `id` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- Tablo için AUTO_INCREMENT değeri `araçlar`
--
ALTER TABLE `araçlar`
  MODIFY `id` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- Tablo için AUTO_INCREMENT değeri `boşaraçlar`
--
ALTER TABLE `boşaraçlar`
  MODIFY `id` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- Tablo için AUTO_INCREMENT değeri `calisanlar`
--
ALTER TABLE `calisanlar`
  MODIFY `id` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=12;

--
-- Tablo için AUTO_INCREMENT değeri `doluaraçlar`
--
ALTER TABLE `doluaraçlar`
  MODIFY `id` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- Tablo için AUTO_INCREMENT değeri `giderislemleri`
--
ALTER TABLE `giderislemleri`
  MODIFY `id` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- Tablo için AUTO_INCREMENT değeri `kasa`
--
ALTER TABLE `kasa`
  MODIFY `id` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- Tablo için AUTO_INCREMENT değeri `yenisözleşme`
--
ALTER TABLE `yenisözleşme`
  MODIFY `id` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
