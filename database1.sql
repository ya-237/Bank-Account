-- MySQL dump 10.13  Distrib 8.0.38, for Win64 (x86_64)
--
-- Host: localhost    Database: bankingaccountmanagementsystem
-- ------------------------------------------------------
-- Server version	9.0.1

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `account`
--

DROP TABLE IF EXISTS `account`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `account` (
  `accountid` int NOT NULL AUTO_INCREMENT,
  `accountnumber` int NOT NULL,
  `customerid` int NOT NULL,
  `accounttype` varchar(100) NOT NULL,
  `balance` int NOT NULL,
  `dateopened` int DEFAULT NULL,
  PRIMARY KEY (`accountid`),
  UNIQUE KEY `accountnumber` (`accountnumber`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `account`
--

LOCK TABLES `account` WRITE;
/*!40000 ALTER TABLE `account` DISABLE KEYS */;
/*!40000 ALTER TABLE `account` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `customer`
--

DROP TABLE IF EXISTS `customer`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `customer` (
  `customerid` int NOT NULL AUTO_INCREMENT,
  `firstname` varchar(100) NOT NULL,
  `lastname` varchar(100) NOT NULL,
  `dateofbirth` int NOT NULL,
  `address` varchar(100) DEFAULT NULL,
  `phonenumber` int NOT NULL,
  `email` varchar(100) DEFAULT NULL,
  `dateofcreation` int DEFAULT NULL,
  PRIMARY KEY (`customerid`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `customer`
--

LOCK TABLES `customer` WRITE;
/*!40000 ALTER TABLE `customer` DISABLE KEYS */;
/*!40000 ALTER TABLE `customer` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `customerlanguage`
--

DROP TABLE IF EXISTS `customerlanguage`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `customerlanguage` (
  `customerid` int NOT NULL,
  `languageID` int NOT NULL,
  PRIMARY KEY (`customerid`,`languageID`),
  KEY `languageID` (`languageID`),
  CONSTRAINT `customerlanguage_ibfk_1` FOREIGN KEY (`customerid`) REFERENCES `customer` (`customerid`),
  CONSTRAINT `customerlanguage_ibfk_2` FOREIGN KEY (`languageID`) REFERENCES `languages` (`languageID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `customerlanguage`
--

LOCK TABLES `customerlanguage` WRITE;
/*!40000 ALTER TABLE `customerlanguage` DISABLE KEYS */;
/*!40000 ALTER TABLE `customerlanguage` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `employeelangauge`
--

DROP TABLE IF EXISTS `employeelangauge`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `employeelangauge` (
  `employeeID` int NOT NULL,
  `languageID` int NOT NULL,
  PRIMARY KEY (`employeeID`,`languageID`),
  KEY `languageID` (`languageID`),
  CONSTRAINT `employeelangauge_ibfk_1` FOREIGN KEY (`employeeID`) REFERENCES `managers` (`Managerid`),
  CONSTRAINT `employeelangauge_ibfk_2` FOREIGN KEY (`languageID`) REFERENCES `languages` (`languageID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `employeelangauge`
--

LOCK TABLES `employeelangauge` WRITE;
/*!40000 ALTER TABLE `employeelangauge` DISABLE KEYS */;
/*!40000 ALTER TABLE `employeelangauge` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `languages`
--

DROP TABLE IF EXISTS `languages`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `languages` (
  `languageID` int NOT NULL AUTO_INCREMENT,
  `languageName` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`languageID`),
  UNIQUE KEY `languageID` (`languageID`),
  UNIQUE KEY `languageName` (`languageName`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `languages`
--

LOCK TABLES `languages` WRITE;
/*!40000 ALTER TABLE `languages` DISABLE KEYS */;
INSERT INTO `languages` VALUES (2,'English'),(1,'French');
/*!40000 ALTER TABLE `languages` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `loans`
--

DROP TABLE IF EXISTS `loans`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `loans` (
  `LoanID` int NOT NULL AUTO_INCREMENT,
  `Customerid` int DEFAULT NULL,
  `loantype` varchar(50) NOT NULL,
  `PrincipalAmount` decimal(15,2) DEFAULT NULL,
  `InterestRate` decimal(5,2) DEFAULT NULL,
  `StartDate` date DEFAULT NULL,
  `EndDate` date DEFAULT NULL,
  `MonthlyPayment` decimal(15,2) DEFAULT NULL,
  `Balance` decimal(15,2) DEFAULT NULL,
  `Status` varchar(20) DEFAULT NULL,
  PRIMARY KEY (`LoanID`),
  KEY `Customerid` (`Customerid`),
  CONSTRAINT `loans_ibfk_1` FOREIGN KEY (`Customerid`) REFERENCES `customer` (`customerid`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `loans`
--

LOCK TABLES `loans` WRITE;
/*!40000 ALTER TABLE `loans` DISABLE KEYS */;
/*!40000 ALTER TABLE `loans` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `managers`
--

DROP TABLE IF EXISTS `managers`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `managers` (
  `Managerid` int NOT NULL AUTO_INCREMENT,
  `firstname` varchar(50) DEFAULT NULL,
  `lastname` varchar(50) DEFAULT NULL,
  `username` varchar(50) DEFAULT NULL,
  `passwordhash` varchar(255) DEFAULT NULL,
  `email` varchar(100) DEFAULT NULL,
  `phonenumber` int DEFAULT NULL,
  `role` varchar(20) DEFAULT NULL,
  `datehired` date DEFAULT NULL,
  PRIMARY KEY (`Managerid`),
  UNIQUE KEY `username` (`username`),
  UNIQUE KEY `passwordhash` (`passwordhash`),
  UNIQUE KEY `email` (`email`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `managers`
--

LOCK TABLES `managers` WRITE;
/*!40000 ALTER TABLE `managers` DISABLE KEYS */;
/*!40000 ALTER TABLE `managers` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `transactions`
--

DROP TABLE IF EXISTS `transactions`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `transactions` (
  `transactionid` int NOT NULL AUTO_INCREMENT,
  `accountid` int NOT NULL,
  `transactiontype` varchar(100) DEFAULT NULL,
  `amount` int NOT NULL,
  `transactiondate` int NOT NULL,
  `description` varchar(255) DEFAULT NULL,
  `LoanID` int DEFAULT NULL,
  PRIMARY KEY (`transactionid`),
  KEY `LoanID` (`LoanID`),
  CONSTRAINT `transactions_ibfk_1` FOREIGN KEY (`LoanID`) REFERENCES `loans` (`LoanID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `transactions`
--

LOCK TABLES `transactions` WRITE;
/*!40000 ALTER TABLE `transactions` DISABLE KEYS */;
/*!40000 ALTER TABLE `transactions` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2024-08-29  7:33:03
