-- MySQL dump 10.13  Distrib 8.0.31, for Win64 (x86_64)
--
-- Host: localhost    Database: game
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
-- Table structure for table `inventory`
--

DROP TABLE IF EXISTS `inventory`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `inventory` (
  `inv_id` int NOT NULL AUTO_INCREMENT,
  `inv_count` int NOT NULL,
  `item` int NOT NULL,
  `user` int NOT NULL,
  PRIMARY KEY (`inv_id`),
  KEY `item` (`item`),
  KEY `user` (`user`),
  CONSTRAINT `inventory_ibfk_1` FOREIGN KEY (`item`) REFERENCES `item` (`item_id`),
  CONSTRAINT `inventory_ibfk_2` FOREIGN KEY (`user`) REFERENCES `user` (`user_id`)
) ENGINE=InnoDB AUTO_INCREMENT=22 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `inventory`
--

LOCK TABLES `inventory` WRITE;
/*!40000 ALTER TABLE `inventory` DISABLE KEYS */;
INSERT INTO `inventory` VALUES (1,3,2,1),(2,90,1,1),(4,27,3,2),(17,2,4,1),(19,1,10,1),(20,3,5,1),(21,7,3,1);
/*!40000 ALTER TABLE `inventory` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `item`
--

DROP TABLE IF EXISTS `item`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `item` (
  `item_id` int NOT NULL AUTO_INCREMENT,
  `item_name` varchar(30) NOT NULL,
  `item_desc` varchar(256) NOT NULL,
  `item_image` varchar(128) DEFAULT NULL,
  `item_type` int NOT NULL,
  PRIMARY KEY (`item_id`),
  KEY `item_type` (`item_type`),
  CONSTRAINT `item_ibfk_1` FOREIGN KEY (`item_type`) REFERENCES `item_type` (`item_type_id`)
) ENGINE=InnoDB AUTO_INCREMENT=13 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `item`
--

LOCK TABLES `item` WRITE;
/*!40000 ALTER TABLE `item` DISABLE KEYS */;
INSERT INTO `item` VALUES (1,'Руда звездного серебра','Редкая и очень ценная руда, образовавшаяся благодаря географическим условиям Драконьего хребта','https://static.wikia.nocookie.net/gensin-impact/images/1/19/Item_Starsilver.png',4),(2,'Цветок-сахарок','Цветок со сладким ароматом','https://static.wikia.nocookie.net/gensin-impact/images/3/3a/Item_Sweet_Flower.png',4),(3,'Скарабей','Жук, который находит покой в огромном океане песков','https://static.wikia.nocookie.net/gensin-impact/images/a/a7/Item_Scarab.png',4),(4,'Дубина переговоров','Удобная дубина, сделанная из качественной стали. Фундамент \"Рационального убеждения\"','https://static.wikia.nocookie.net/gensin-impact/images/7/74/Weapon_Debate_Club.png',1),(5,'Медовое мясо с морковкой','Мясное блюдо с медовым соусом. Нежное угощение согреет вас холодным зимним вечером','https://static.wikia.nocookie.net/gensin-impact/images/8/85/Item_Sticky_Honey_Roast.png',2),(6,'Рыбацкий бутерброд','Ломтик хлеба, посыпанный луком','https://static.wikia.nocookie.net/gensin-impact/images/4/4c/Item_Fisherman%27s_Toast.png',2),(7,'Молоко с данго','Креативный напиток, приготовленный путем добавления данго в молоко. Сладкий и густой','https://static.wikia.nocookie.net/gensin-impact/images/8/83/Item_Dango_Milk.png/revision/latest?cb=20210904020630',2),(8,'Посох Хомы','Алый посох, использовавшийся в давно утраченном ритуале','https://static.wikia.nocookie.net/gensin-impact/images/1/17/Weapon_Staff_of_Homa.png',1),(9,'Кагоцурубэ Иссин','Клинок, который родился в государстве, далеко на севере. На пути домой его запятнала скверна бесчисленных злодеяний лишь ради одного слова - \"Иссин\"','https://static.wikia.nocookie.net/gensin-impact/images/9/96/Weapon_Kagotsurube_Isshin.png',1),(10,'Паймон','Самый лучший компаньон!','https://static.wikia.nocookie.net/gensin-impact/images/c/ce/Icon_Emoji_Paimon%27s_Paintings_17_Paimon_1.png',3),(11,'Венок','Венок, сплетённый Арамой. Венки аранар - олицетворённое благословение Ванараны','https://static.wikia.nocookie.net/gensin-impact/images/7/78/Item_Garland.png',3),(12,'Засохшая кусава','Засохшая кусава, утратившая всю свою силу. Но семена, что хранят драгоценную память, ещё живы','https://static.wikia.nocookie.net/gensin-impact/images/3/39/Item_Withered_Kusava.png',3);
/*!40000 ALTER TABLE `item` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `item_type`
--

DROP TABLE IF EXISTS `item_type`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `item_type` (
  `item_type_id` int NOT NULL AUTO_INCREMENT,
  `item_type_name` varchar(20) NOT NULL,
  PRIMARY KEY (`item_type_id`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `item_type`
--

LOCK TABLES `item_type` WRITE;
/*!40000 ALTER TABLE `item_type` DISABLE KEYS */;
INSERT INTO `item_type` VALUES (1,'Оружие'),(2,'Еда'),(3,'Задания'),(4,'Ресурсы');
/*!40000 ALTER TABLE `item_type` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `user`
--

DROP TABLE IF EXISTS `user`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `user` (
  `user_id` int NOT NULL AUTO_INCREMENT,
  `user_name` varchar(30) NOT NULL,
  `user_pass` varchar(40) NOT NULL,
  PRIMARY KEY (`user_id`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `user`
--

LOCK TABLES `user` WRITE;
/*!40000 ALTER TABLE `user` DISABLE KEYS */;
INSERT INTO `user` VALUES (1,'Traveler','piemon'),(2,'Paimon','mora'),(4,'Scaramouche','bighat');
/*!40000 ALTER TABLE `user` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `util`
--

DROP TABLE IF EXISTS `util`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `util` (
  `id` int NOT NULL AUTO_INCREMENT,
  `uid` int NOT NULL,
  `isAuthorized` tinyint(1) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `util`
--

LOCK TABLES `util` WRITE;
/*!40000 ALTER TABLE `util` DISABLE KEYS */;
INSERT INTO `util` VALUES (1,0,0);
/*!40000 ALTER TABLE `util` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2022-12-19 23:20:24
