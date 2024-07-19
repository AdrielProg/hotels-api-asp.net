CREATE TABLE IF NOT EXISTS rooms (
  id SERIAL PRIMARY KEY,
  hotel_id BIGINT NOT NULL,
  room_number VARCHAR(100) NOT NULL,
  capacity INT NOT NULL,
  description TEXT NOT NULL,
  photos VARCHAR(255) NOT NULL,
  CONSTRAINT room_hotel FOREIGN KEY (hotel_id) REFERENCES hotels (id)
);
