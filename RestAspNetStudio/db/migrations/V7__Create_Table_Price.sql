CREATE TABLE IF NOT EXISTS prices (
  id SERIAL PRIMARY KEY,
  room_id BIGINT NOT NULL,
  start_date DATE NOT NULL,
  end_date DATE NOT NULL,
  amount DECIMAL(10, 2) NOT NULL,
  currency VARCHAR(3) NOT NULL,
  CONSTRAINT price_room FOREIGN KEY (room_id) REFERENCES rooms (id)
);
