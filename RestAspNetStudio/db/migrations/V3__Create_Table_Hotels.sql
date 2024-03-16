CREATE TABLE IF NOT EXISTS `hotels` (
  `id` bigint NOT NULL AUTO_INCREMENT,
  `name` varchar(80) NOT NULL,
  `adress` varchar(100) NOT NULL,
  `phone` varchar(100) NOT NULL,
  `description` varchar(200) NOT NULL,
  `rating` INT NOT NULL,
  PRIMARY KEY (`id`)
) 