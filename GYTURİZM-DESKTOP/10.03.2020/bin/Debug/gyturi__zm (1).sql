-- phpMyAdmin SQL Dump
-- version 4.9.2
-- https://www.phpmyadmin.net/
--
-- Anamakine: 127.0.0.1:3308
-- Üretim Zamanı: 08 Haz 2020, 09:07:03
-- Sunucu sürümü: 5.7.28
-- PHP Sürümü: 7.3.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Veritabanı: `gyturi̇zm`
--

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `biletler`
--

DROP TABLE IF EXISTS `biletler`;
CREATE TABLE IF NOT EXISTS `biletler` (
  `ID` int(3) NOT NULL,
  `u` int(3) NOT NULL,
  `cins` varchar(20) COLLATE utf8_turkish_ci NOT NULL,
  `nereden` varchar(15) COLLATE utf8_turkish_ci NOT NULL,
  `nereye` varchar(15) COLLATE utf8_turkish_ci NOT NULL,
  `kalkış` varchar(15) COLLATE utf8_turkish_ci NOT NULL,
  `t` varchar(20) COLLATE utf8_turkish_ci NOT NULL,
  `fiyat` varchar(3) COLLATE utf8_turkish_ci NOT NULL,
  `ad` varchar(20) COLLATE utf8_turkish_ci NOT NULL,
  `soyad` varchar(15) COLLATE utf8_turkish_ci NOT NULL,
  `tc` varchar(11) COLLATE utf8_turkish_ci NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_turkish_ci;

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `koltuk`
--

DROP TABLE IF EXISTS `koltuk`;
CREATE TABLE IF NOT EXISTS `koltuk` (
  `ID1` int(3) NOT NULL AUTO_INCREMENT,
  `sıra1` int(3) NOT NULL,
  `cins1` varchar(15) COLLATE utf8_turkish_ci NOT NULL,
  `nereden1` varchar(15) COLLATE utf8_turkish_ci NOT NULL,
  `nereye1` varchar(15) COLLATE utf8_turkish_ci NOT NULL,
  `t1` varchar(20) COLLATE utf8_turkish_ci NOT NULL,
  PRIMARY KEY (`ID1`,`sıra1`)
) ENGINE=MyISAM AUTO_INCREMENT=57 DEFAULT CHARSET=utf8 COLLATE=utf8_turkish_ci;

--
-- Tablo döküm verisi `koltuk`
--

INSERT INTO `koltuk` (`ID1`, `sıra1`, `cins1`, `nereden1`, `nereye1`, `t1`) VALUES
(1, 1, '', '', '', ''),
(2, 2, '', '', '', ''),
(3, 3, '', '', '', ''),
(4, 4, '', '', '', ''),
(5, 5, '', '', '', ''),
(6, 6, '', '', '', ''),
(7, 7, '', '', '', ''),
(8, 8, '', '', '', ''),
(9, 9, '', '', '', ''),
(10, 10, '', '', '', ''),
(11, 11, '', '', '', ''),
(12, 12, '', '', '', ''),
(13, 13, '', '', '', ''),
(14, 14, '', '', '', ''),
(15, 15, '', '', '', ''),
(16, 16, '', '', '', ''),
(17, 17, '', '', '', ''),
(18, 18, '', '', '', ''),
(19, 19, '', '', '', ''),
(20, 20, '', '', '', ''),
(21, 21, '', '', '', ''),
(22, 22, '', '', '', ''),
(23, 23, '', '', '', ''),
(24, 24, '', '', '', ''),
(25, 25, '', '', '', ''),
(26, 26, '', '', '', ''),
(27, 27, '', '', '', ''),
(28, 28, '', '', '', ''),
(29, 29, '', '', '', ''),
(30, 30, '', '', '', ''),
(31, 31, '', '', '', ''),
(32, 32, '', '', '', ''),
(33, 33, '', '', '', ''),
(34, 34, '', '', '', ''),
(35, 35, '', '', '', ''),
(36, 36, '', '', '', ''),
(37, 37, '', '', '', ''),
(38, 38, '', '', '', ''),
(39, 39, '', '', '', ''),
(40, 40, '', '', '', ''),
(41, 41, '', '', '', ''),
(42, 42, '', '', '', ''),
(43, 43, '', '', '', ''),
(44, 44, '', '', '', ''),
(45, 45, '', '', '', ''),
(46, 46, '', '', '', ''),
(47, 47, '', '', '', ''),
(48, 48, '', '', '', ''),
(49, 49, '', '', '', ''),
(50, 50, '', '', '', ''),
(51, 51, '', '', '', ''),
(52, 52, '', '', '', ''),
(53, 53, '', '', '', ''),
(54, 54, '', '', '', ''),
(55, 55, '', '', '', ''),
(56, 56, '', '', '', '');

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `nereden`
--

DROP TABLE IF EXISTS `nereden`;
CREATE TABLE IF NOT EXISTS `nereden` (
  `ID` int(3) NOT NULL AUTO_INCREMENT,
  `IL` varchar(15) COLLATE utf8_turkish_ci NOT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=MyISAM AUTO_INCREMENT=9 DEFAULT CHARSET=utf8 COLLATE=utf8_turkish_ci;

--
-- Tablo döküm verisi `nereden`
--

INSERT INTO `nereden` (`ID`, `IL`) VALUES
(1, 'SİNOP'),
(2, 'KASTAMONU'),
(3, 'KARABÜK'),
(4, 'BOLU'),
(5, 'SAKARYA'),
(6, 'İSTANBUL'),
(7, 'SAMSUN(ÖÖ)'),
(8, 'SAMSUN(ÖS)');

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `nereye1`
--

DROP TABLE IF EXISTS `nereye1`;
CREATE TABLE IF NOT EXISTS `nereye1` (
  `ID` int(3) NOT NULL AUTO_INCREMENT,
  `IL` varchar(15) COLLATE utf8_turkish_ci NOT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=MyISAM AUTO_INCREMENT=8 DEFAULT CHARSET=utf8 COLLATE=utf8_turkish_ci;

--
-- Tablo döküm verisi `nereye1`
--

INSERT INTO `nereye1` (`ID`, `IL`) VALUES
(1, 'İSTANBUL'),
(2, 'SAKARYA'),
(3, 'BOLU'),
(4, 'KASTAMONU'),
(5, 'KARABÜK'),
(6, 'SAMSUN(ÖÖ)'),
(7, 'SAMSUN(ÖS)');

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `nereye2`
--

DROP TABLE IF EXISTS `nereye2`;
CREATE TABLE IF NOT EXISTS `nereye2` (
  `ID` int(3) NOT NULL AUTO_INCREMENT,
  `IL` varchar(15) COLLATE utf8_turkish_ci NOT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=MyISAM AUTO_INCREMENT=2 DEFAULT CHARSET=utf8 COLLATE=utf8_turkish_ci;

--
-- Tablo döküm verisi `nereye2`
--

INSERT INTO `nereye2` (`ID`, `IL`) VALUES
(1, 'SİNOP');

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `nereye3`
--

DROP TABLE IF EXISTS `nereye3`;
CREATE TABLE IF NOT EXISTS `nereye3` (
  `ID` int(3) NOT NULL AUTO_INCREMENT,
  `IL` varchar(15) COLLATE utf8_turkish_ci NOT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=MyISAM AUTO_INCREMENT=6 DEFAULT CHARSET=utf8 COLLATE=utf8_turkish_ci;

--
-- Tablo döküm verisi `nereye3`
--

INSERT INTO `nereye3` (`ID`, `IL`) VALUES
(1, 'KARABÜK'),
(2, 'BOLU'),
(3, 'SAKARYA'),
(4, 'İSTANBUL'),
(5, 'SİNOP');

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `nereye4`
--

DROP TABLE IF EXISTS `nereye4`;
CREATE TABLE IF NOT EXISTS `nereye4` (
  `ID` int(3) NOT NULL AUTO_INCREMENT,
  `IL` varchar(15) COLLATE utf8_turkish_ci NOT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=MyISAM AUTO_INCREMENT=6 DEFAULT CHARSET=utf8 COLLATE=utf8_turkish_ci;

--
-- Tablo döküm verisi `nereye4`
--

INSERT INTO `nereye4` (`ID`, `IL`) VALUES
(1, 'İSTANBUL'),
(2, 'SİNOP'),
(3, 'BOLU'),
(4, 'SAKARYA'),
(5, 'KASTAMONU');

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `nereye5`
--

DROP TABLE IF EXISTS `nereye5`;
CREATE TABLE IF NOT EXISTS `nereye5` (
  `ID` int(3) NOT NULL AUTO_INCREMENT,
  `IL` varchar(15) COLLATE utf8_turkish_ci NOT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=MyISAM AUTO_INCREMENT=6 DEFAULT CHARSET=utf8 COLLATE=utf8_turkish_ci;

--
-- Tablo döküm verisi `nereye5`
--

INSERT INTO `nereye5` (`ID`, `IL`) VALUES
(1, 'KARABÜK'),
(2, 'SİNOP'),
(3, 'SAKARYA'),
(4, 'KASTAMONU'),
(5, 'İSTANBUL');

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `nereye6`
--

DROP TABLE IF EXISTS `nereye6`;
CREATE TABLE IF NOT EXISTS `nereye6` (
  `ID` int(3) NOT NULL AUTO_INCREMENT,
  `IL` varchar(15) COLLATE utf8_turkish_ci NOT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=MyISAM AUTO_INCREMENT=6 DEFAULT CHARSET=utf8 COLLATE=utf8_turkish_ci;

--
-- Tablo döküm verisi `nereye6`
--

INSERT INTO `nereye6` (`ID`, `IL`) VALUES
(1, 'İSTANBUL'),
(2, 'KARABÜK'),
(3, 'BOLU'),
(4, 'KASTAMONU'),
(5, 'SİNOP');

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `nereye7`
--

DROP TABLE IF EXISTS `nereye7`;
CREATE TABLE IF NOT EXISTS `nereye7` (
  `ID` int(3) NOT NULL AUTO_INCREMENT,
  `IL` varchar(15) COLLATE utf8_turkish_ci NOT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=MyISAM AUTO_INCREMENT=6 DEFAULT CHARSET=utf8 COLLATE=utf8_turkish_ci;

--
-- Tablo döküm verisi `nereye7`
--

INSERT INTO `nereye7` (`ID`, `IL`) VALUES
(1, 'KARABÜK'),
(2, 'SİNOP'),
(3, 'BOLU'),
(4, 'KASTAMONU'),
(5, 'SAKARYA');

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `otobüsöz`
--

DROP TABLE IF EXISTS `otobüsöz`;
CREATE TABLE IF NOT EXISTS `otobüsöz` (
  `ID` int(3) NOT NULL AUTO_INCREMENT,
  `NEREDEN` varchar(15) COLLATE utf8_turkish_ci NOT NULL,
  `NEREYE` varchar(15) COLLATE utf8_turkish_ci NOT NULL,
  `KALKIŞ_SAAT` varchar(15) COLLATE utf8_turkish_ci NOT NULL,
  `KOLTUKADED` varchar(5) COLLATE utf8_turkish_ci NOT NULL,
  `FİYAT` int(15) NOT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=MyISAM AUTO_INCREMENT=36 DEFAULT CHARSET=utf8 COLLATE=utf8_turkish_ci;

--
-- Tablo döküm verisi `otobüsöz`
--

INSERT INTO `otobüsöz` (`ID`, `NEREDEN`, `NEREYE`, `KALKIŞ_SAAT`, `KOLTUKADED`, `FİYAT`) VALUES
(1, 'SİNOP', 'SAMSUN(ÖÖ)', '09:00:00', '2+2', 40),
(2, 'SİNOP', 'İSTANBUL', '10:00:00', '2+2', 105),
(3, 'İSTANBUL', 'SİNOP', '11:00:00', '2+2', 105),
(4, 'SAMSUN(ÖÖ)', 'SİNOP', '08:00:00', '2+2', 40),
(5, 'SAMSUN(ÖS)', 'SİNOP', '14:00:00', '2+2', 40),
(6, 'SİNOP', 'SAMSUN(ÖS)', '15:00:00', '2+2', 40),
(7, 'SİNOP', 'SAKARYA', '10:00:00', '2+2', 90),
(8, 'SAKARYA', 'SİNOP', '12:15:00', '2+2', 90),
(9, 'SİNOP', 'BOLU', '10:00:00', '2+2', 75),
(10, 'BOLU', 'SİNOP', '13:45:00', '2+2', 75),
(11, 'SİNOP', 'KARABÜK', '10:00:00', '2+2', 60),
(12, 'KARABÜK', 'SİNOP', '15:20:00', '2+2', 60),
(13, 'SİNOP', 'KASTAMONU', '10:00:00', '2+2', 35),
(14, 'KASTAMONU', 'SİNOP', '16:45:00', '2+2', 35),
(15, 'SAKARYA', 'KASTAMONU', '12:15:00', '2+2', 55),
(16, 'KASTAMONU', 'SAKARYA', '12:25:00', '2+2', 55),
(17, 'SAKARYA', 'KARABÜK', '12:15:00', '2+2', 30),
(18, 'SAKARYA', 'BOLU', '12:15:00', '2+2', 15),
(19, 'SAKARYA', 'İSTANBUL', '16:55:00', '2+2', 15),
(20, 'KASTAMONU', 'İSTANBUL', '12:25:00', '2+2', 70),
(21, 'KASTAMONU', 'BOLU', '12:25:00', '2+2', 40),
(22, 'KASTAMONU', 'KARABÜK', '12:25:00', '2+2', 25),
(23, 'KARABÜK', 'İSTANBUL', '13:50:00', '2+2', 45),
(24, 'KARABÜK', 'SAKARYA', '13:50:00', '2+2', 30),
(25, 'KARABÜK', 'BOLU', '13:50:00', '2+2', 15),
(26, 'KARABÜK', 'KASTAMONU', '15:20:00', '2+2', 25),
(27, 'İSTANBUL', 'KASTAMONU', '11:00:00', '2+2', 70),
(28, 'İSTANBUL', 'KARABÜK', '11:00:00', '2+2', 45),
(29, 'İSTANBUL', 'BOLU', '11:00:00', '2+2', 30),
(30, 'İSTANBUL', 'SAKARYA', '11:00:00', '2+2', 15),
(31, 'BOLU', 'KASTAMONU', '13:45:00', '2+2', 40),
(32, 'BOLU', 'KARABÜK', '13:45:00', '2+2', 15),
(33, 'BOLU', 'İSTANBUL', '15:25:00', '2+2', 30),
(34, 'BOLU', 'SAKARYA', '15:25:00', '2+2', 15),
(35, '', '', '', '', 0);

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `sefer_bilgileri`
--

DROP TABLE IF EXISTS `sefer_bilgileri`;
CREATE TABLE IF NOT EXISTS `sefer_bilgileri` (
  `ID` int(3) NOT NULL AUTO_INCREMENT,
  `NEREDEN` varchar(15) COLLATE utf8_turkish_ci NOT NULL,
  `NEREYE` varchar(15) COLLATE utf8_turkish_ci NOT NULL,
  `KM` int(5) NOT NULL,
  `SAAT` varchar(15) COLLATE utf8_turkish_ci NOT NULL,
  `MOLA_SAYISI` int(1) NOT NULL,
  PRIMARY KEY (`ID`,`NEREDEN`,`NEREYE`)
) ENGINE=MyISAM AUTO_INCREMENT=35 DEFAULT CHARSET=utf8 COLLATE=utf8_turkish_ci;

--
-- Tablo döküm verisi `sefer_bilgileri`
--

INSERT INTO `sefer_bilgileri` (`ID`, `NEREDEN`, `NEREYE`, `KM`, `SAAT`, `MOLA_SAYISI`) VALUES
(1, 'SAMSUN(ÖÖ)', 'SİNOP', 163, '01:50:00', 0),
(2, 'SİNOP', 'SAMSUN(ÖÖ)', 163, '01:50:00', 0),
(3, 'SİNOP', 'KASTAMONU', 183, '02:25:00', 0),
(4, 'SİNOP', 'KARABÜK', 295, '03:40:00', 1),
(5, 'SİNOP', 'BOLU', 425, '05:10:00', 2),
(6, 'SİNOP', 'SAKARYA', 535, '06:20:00', 2),
(7, 'SİNOP', 'İSTANBUL', 700, '08:00:00', 4),
(8, 'KASTAMONU', 'SİNOP', 183, '02:25:00', 0),
(9, 'KASTAMONU', 'KARABÜK', 110, '01:22:00', 0),
(10, 'KASTAMONU', 'BOLU', 250, '02:55:00', 1),
(11, 'KASTAMONU', 'SAKARYA', 380, '04:00:00', 1),
(12, 'KASTAMONU', 'İSTANBUL', 515, '05:35:00', 3),
(13, 'KARABÜK', 'KASTAMONU', 110, '01:22:00', 0),
(14, 'KARABÜK', 'SİNOP', 295, '03:40:00', 1),
(15, 'KARABÜK', 'BOLU', 140, '01:35:00', 0),
(16, 'KARABÜK', 'SAKARYA', 265, '02:51:00', 1),
(17, 'KARABÜK', 'İSTANBUL', 400, '04:17:00', 2),
(18, 'BOLU', 'KARABÜK', 140, '01:35:00', 0),
(19, 'BOLU', 'KASTAMONU', 250, '02:55:00', 1),
(20, 'BOLU', 'SİNOP', 425, '05:10:00', 2),
(21, 'BOLU', 'SAKARYA', 128, '01:30:00', 0),
(22, 'BOLU', 'İSTANBUL', 263, '03:06:00', 1),
(23, 'SAKARYA', 'BOLU', 128, '01:30:00', 0),
(24, 'SAKARYA', 'KARABÜK', 265, '02:51:00', 1),
(25, 'SAKARYA', 'KASTAMONU', 380, '04:00:00', 1),
(26, 'SAKARYA', 'SİNOP', 535, '06:20:00', 2),
(27, 'SAKARYA', 'İSTANBUL', 148, '01:15:00', 0),
(28, 'İSTANBUL', 'SAKARYA', 148, '01:15:00', 0),
(29, 'İSTANBUL', 'BOLU', 263, '03:06:00', 1),
(30, 'İSTANBUL', 'KARABÜK', 400, '04:17:00', 2),
(31, 'İSTANBUL', 'KASTAMONU', 515, '05:35:00', 3),
(32, 'İSTANBUL', 'SİNOP', 700, '08:00:00', 4),
(33, 'SAMSUN(ÖS)', 'SİNOP', 163, '01:50:00', 0),
(34, 'SİNOP', 'SAMSUN(ÖS)', 163, '01:50:00', 0);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
