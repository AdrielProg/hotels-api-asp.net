CREATE TABLE IF NOT EXISTS `prices`(
`id` bigint NOT NULL AUTO_INCREMENT,
`room_id` bigint NOT NULL,
`start_date` DATE NOT NULL,
`end_date` DATE NOT NULL,
`amount` DECIMAL(10, 2) NOT NULL,
`currency` VARCHAR(3) NOT NULL,
PRIMARY KEY (`id`),
KEY `room_id`(`room_id`),
CONSTRAINT `price_room` FOREIGN KEY (`room_id`) REFERENCES `rooms`(`id`))