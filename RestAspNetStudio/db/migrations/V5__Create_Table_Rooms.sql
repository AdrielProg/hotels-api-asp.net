CREATE TABLE IF NOT EXISTS `rooms` (
  `id` bigint NOT NULL AUTO_INCREMENT,
  `hotel_id` bigint NOT NULL,
  `room_number` varchar(100) NOT NULL,
  `capacity` int NOT NULL,
  `description` text NOT NULL,
  `photos` varchar(255) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `hotel_id` (`hotel_id`),
  CONSTRAINT `room_hotel` FOREIGN KEY(`hotel_id`) REFERENCES`hotels`(`id`)
  )