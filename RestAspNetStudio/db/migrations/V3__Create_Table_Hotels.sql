CREATE TABLE IF NOT EXISTS hotels (
  id SERIAL PRIMARY KEY,
  name VARCHAR(80) NOT NULL,
  adress VARCHAR(100) NOT NULL,
  phone VARCHAR(100) NOT NULL,
  description VARCHAR(200) NOT NULL,
  rating INT NOT NULL
);
