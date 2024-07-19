CREATE TABLE IF NOT EXISTS reservations (
  id SERIAL PRIMARY KEY,
  user_id BIGINT NOT NULL,
  room_id BIGINT NOT NULL,
  checkin_date_time TIMESTAMP NOT NULL,
  checkout_date_time TIMESTAMP NOT NULL,
  CONSTRAINT reservation_user FOREIGN KEY (user_id) REFERENCES users (id),
  CONSTRAINT reservation_room FOREIGN KEY (room_id) REFERENCES rooms (id)
);
