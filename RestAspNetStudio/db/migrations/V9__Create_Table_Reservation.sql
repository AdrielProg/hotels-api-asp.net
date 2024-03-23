CREATE TABLE IF NOT EXISTS `reservations`(
`id` bigint NOT NULL AUTO_INCREMENT,
`user_id` bigint NOT NULL,
`room_id` bigint NOT NULL,
`checkin_date_time` TIMESTAMP NOT NULL,
`checkout_date_time` TIMESTAMP NOT NULL,
PRIMARY KEY (`id`),
KEY `user_id`(`user_id`),
KEY `room_id`(`room_id`),
CONSTRAINT `reservation_user` FOREIGN KEY (`user_id`) REFERENCES `users`(`id`),
CONSTRAINT `reservation_room` FOREIGN KEY (`room_id`) REFERENCES `rooms`(`id`))