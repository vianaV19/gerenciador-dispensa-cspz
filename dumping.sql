-- MySQL dump 10.13  Distrib 8.0.32, for Win64 (x86_64)
--
-- Host: localhost    Database: cspz
-- ------------------------------------------------------
-- Server version	8.0.31

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
-- Table structure for table `tb_acompanhamento`
--

DROP TABLE IF EXISTS `tb_acompanhamento`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tb_acompanhamento` (
  `id` int NOT NULL AUTO_INCREMENT,
  `data` datetime DEFAULT CURRENT_TIMESTAMP,
  `acompanhamento` varchar(150) NOT NULL,
  `qntd` mediumint NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tb_acompanhamento`
--

LOCK TABLES `tb_acompanhamento` WRITE;
/*!40000 ALTER TABLE `tb_acompanhamento` DISABLE KEYS */;
INSERT INTO `tb_acompanhamento` VALUES (1,'2023-06-04 18:53:09','arroz',3);
/*!40000 ALTER TABLE `tb_acompanhamento` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tb_dispensa`
--

DROP TABLE IF EXISTS `tb_dispensa`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tb_dispensa` (
  `id` int NOT NULL AUTO_INCREMENT,
  `data` datetime DEFAULT CURRENT_TIMESTAMP,
  `assist` mediumint NOT NULL,
  `colab` mediumint NOT NULL,
  `projet` mediumint NOT NULL,
  `total` mediumint NOT NULL,
  `proteina` varchar(150) NOT NULL,
  `qntd_proteina` mediumint NOT NULL,
  `sobremesa` varchar(150) NOT NULL,
  `qntd_sobremesa` mediumint NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tb_dispensa`
--

LOCK TABLES `tb_dispensa` WRITE;
/*!40000 ALTER TABLE `tb_dispensa` DISABLE KEYS */;
INSERT INTO `tb_dispensa` VALUES (1,'2023-06-04 18:53:09',3,10,0,15,'carne',3,'bolo',5),(2,'2023-06-04 18:53:09',4,11,0,16,'carne',3,'bolo',5),(3,'2023-06-04 18:53:09',5,12,0,17,'carne',3,'bolo',5);
/*!40000 ALTER TABLE `tb_dispensa` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tb_guarnicao`
--

DROP TABLE IF EXISTS `tb_guarnicao`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tb_guarnicao` (
  `id` int NOT NULL AUTO_INCREMENT,
  `data` datetime DEFAULT CURRENT_TIMESTAMP,
  `guarnicao` varchar(150) NOT NULL,
  `qntd` mediumint NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tb_guarnicao`
--

LOCK TABLES `tb_guarnicao` WRITE;
/*!40000 ALTER TABLE `tb_guarnicao` DISABLE KEYS */;
INSERT INTO `tb_guarnicao` VALUES (1,'2023-06-04 18:53:09','guarnicao',32);
/*!40000 ALTER TABLE `tb_guarnicao` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tb_lanche`
--

DROP TABLE IF EXISTS `tb_lanche`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tb_lanche` (
  `id` int NOT NULL AUTO_INCREMENT,
  `data` datetime DEFAULT CURRENT_TIMESTAMP,
  `lanche` varchar(150) NOT NULL,
  `turno` varchar(50) NOT NULL,
  `qntd` mediumint NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tb_lanche`
--

LOCK TABLES `tb_lanche` WRITE;
/*!40000 ALTER TABLE `tb_lanche` DISABLE KEYS */;
INSERT INTO `tb_lanche` VALUES (1,'2023-06-04 18:53:09','sanduiche','manha',32),(2,'2023-06-04 18:53:09','pao de sal','tade',20);
/*!40000 ALTER TABLE `tb_lanche` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping routines for database 'cspz'
--
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2023-06-04 18:55:50
