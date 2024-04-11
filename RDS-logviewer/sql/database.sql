-- --------------------------------------------------------
-- Host:                         127.0.0.1
-- Versión del servidor:         8.0.19 - MySQL Community Server - GPL
-- SO del servidor:              Win64
-- HeidiSQL Versión:             11.0.0.5919
-- --------------------------------------------------------

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;


-- Volcando estructura de base de datos para rdsecurelogs
DROP DATABASE IF EXISTS `rdsecurelogs`;
CREATE DATABASE IF NOT EXISTS `rdsecurelogs` /*!40100 DEFAULT CHARACTER SET utf8 */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `rdsecurelogs`;

-- Volcando estructura para tabla rdsecurelogs.origin
DROP TABLE IF EXISTS `origin`;
CREATE TABLE IF NOT EXISTS `origin` (
  `code` varchar(10) NOT NULL,
  `Name` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`code`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- Volcando datos para la tabla rdsecurelogs.origin: ~3 rows (aproximadamente)
/*!40000 ALTER TABLE `origin` DISABLE KEYS */;
INSERT INTO `origin` (`code`, `Name`) VALUES
	('AdminA', 'Administration Access');
INSERT INTO `origin` (`code`, `Name`) VALUES
	('Statics', 'Statics');
INSERT INTO `origin` (`code`, `Name`) VALUES
	('UserP', 'User Portal');
/*!40000 ALTER TABLE `origin` ENABLE KEYS */;

-- Volcando estructura para tabla rdsecurelogs.rdslogs
DROP TABLE IF EXISTS `rdslogs`;
CREATE TABLE IF NOT EXISTS `rdslogs` (
  `id` bigint NOT NULL AUTO_INCREMENT,
  `TimeCreated` varchar(30) DEFAULT NULL,
  `TimeCreatedf` datetime DEFAULT NULL,
  `EventID` int DEFAULT NULL,
  `Level` int DEFAULT NULL,
  `EventRecordID` int DEFAULT NULL,
  `Computer` varchar(45) DEFAULT NULL,
  `Origin_code` varchar(10) NOT NULL,
  `severely_key` varchar(45) NOT NULL,
  `code` varchar(20) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `SNO` varchar(45) DEFAULT NULL,
  `INETA` varchar(45) DEFAULT NULL,
  `messaje` text,
  `rdsContent` text,
  PRIMARY KEY (`id`),
  KEY `fk_RDSLogs_Origin_idx` (`Origin_code`),
  KEY `fk_RDSLogs_severely1_idx` (`severely_key`),
  CONSTRAINT `fk_RDSLogs_Origin` FOREIGN KEY (`Origin_code`) REFERENCES `origin` (`code`),
  CONSTRAINT `fk_RDSLogs_severely1` FOREIGN KEY (`severely_key`) REFERENCES `severely` (`key`)
) ENGINE=InnoDB AUTO_INCREMENT=1649 DEFAULT CHARSET=utf8;


-- Volcando estructura para tabla rdsecurelogs.severely
DROP TABLE IF EXISTS `severely`;
CREATE TABLE IF NOT EXISTS `severely` (
  `key` varchar(5) NOT NULL,
  `NumValue` int DEFAULT NULL,
  `Severity` varchar(20) DEFAULT NULL,
  `Keyword` varchar(10) DEFAULT NULL,
  `Description` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`key`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- Volcando datos para la tabla rdsecurelogs.severely: ~9 rows (aproximadamente)
/*!40000 ALTER TABLE `severely` DISABLE KEYS */;
INSERT INTO `severely` (`key`, `NumValue`, `Severity`, `Keyword`, `Description`) VALUES
	('A', 1, 'Alert', 'alert', 'Action must be taken immediately');
INSERT INTO `severely` (`key`, `NumValue`, `Severity`, `Keyword`, `Description`) VALUES
	('C', 2, 'Critical', 'crit', 'Critical conditions');
INSERT INTO `severely` (`key`, `NumValue`, `Severity`, `Keyword`, `Description`) VALUES
	('D', 7, 'Debug', 'debug', 'Debug-level messages');
INSERT INTO `severely` (`key`, `NumValue`, `Severity`, `Keyword`, `Description`) VALUES
	('E', 0, 'Emergency', 'emerg', '	System is unusable');
INSERT INTO `severely` (`key`, `NumValue`, `Severity`, `Keyword`, `Description`) VALUES
	('ER', 3, 'Error', 'err', 'Error conditions');
INSERT INTO `severely` (`key`, `NumValue`, `Severity`, `Keyword`, `Description`) VALUES
	('I', 6, 'Informational', 'info', 'Informational messages');
INSERT INTO `severely` (`key`, `NumValue`, `Severity`, `Keyword`, `Description`) VALUES
	('N', 5, 'Notice', 'notice', 'Normal but significant conditions');
INSERT INTO `severely` (`key`, `NumValue`, `Severity`, `Keyword`, `Description`) VALUES
	('T', 8, 'unknow', 'unknow', 'unknow');
INSERT INTO `severely` (`key`, `NumValue`, `Severity`, `Keyword`, `Description`) VALUES
	('W', 4, 'Warning', 'warning', 'Warning conditions');
/*!40000 ALTER TABLE `severely` ENABLE KEYS */;

/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IF(@OLD_FOREIGN_KEY_CHECKS IS NULL, 1, @OLD_FOREIGN_KEY_CHECKS) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
