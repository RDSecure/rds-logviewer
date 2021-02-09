-- MySQL dump 10.13  Distrib 8.0.20, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: rdsecurelogs
-- ------------------------------------------------------
-- Server version	8.0.19

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `origin`
--

DROP TABLE IF EXISTS `origin`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `origin` (
  `code` varchar(10) NOT NULL,
  `Name` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`code`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `origin`
--

LOCK TABLES `origin` WRITE;
/*!40000 ALTER TABLE `origin` DISABLE KEYS */;
INSERT INTO `origin` VALUES ('AdminA','Administration Access'),('Statics','Statics'),('UserP','User Portal');
/*!40000 ALTER TABLE `origin` ENABLE KEYS */;
UNLOCK TABLES;

DROP TABLE IF EXISTS `rdslogs`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `rdslogs` (
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
) ENGINE=InnoDB AUTO_INCREMENT=352 DEFAULT CHARSET=utf8;

DROP TABLE IF EXISTS `severely`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `severely` (
  `key` varchar(5) NOT NULL,
  `NumValue` int DEFAULT NULL,
  `Severity` varchar(20) DEFAULT NULL,
  `Keyword` varchar(10) DEFAULT NULL,
  `Description` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`key`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `severely`
--

LOCK TABLES `severely` WRITE;
/*!40000 ALTER TABLE `severely` DISABLE KEYS */;
INSERT INTO `severely` VALUES ('A',1,'Alert','alert','Action must be taken immediately'),('C',2,'Critical','crit','Critical conditions'),('D',7,'Debug','debug','Debug-level messages'),('E',0,'Emergency','emerg','	System is unusable'),('ER',3,'Error','err','Error conditions'),('I',6,'Informational','info','Informational messages'),('N',5,'Notice','notice','Normal but significant conditions'),('T',8,'unknow','unknow','unknow'),('W',4,'Warning','warning','Warning conditions');
/*!40000 ALTER TABLE `severely` ENABLE KEYS */;
UNLOCK TABLES;

/*!40101 SET character_set_client = @saved_cs_client */;


/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2021-02-09 15:14:45

