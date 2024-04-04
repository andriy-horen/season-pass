CREATE TABLE IF NOT EXISTS lift_location (
	lift_location_id SERIAL PRIMARY KEY,
	name TEXT NOT NULL,
	latitude DECIMAL NOT NULL,
	longitude DECIMAL NOT NULL,
	ski_resort_id INT REFERENCES ski_resort(ski_resort_id)
);