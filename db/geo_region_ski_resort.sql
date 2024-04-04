CREATE TABLE IF NOT EXISTS geo_region_ski_resort (
	geo_region_ski_resort_id SERIAL PRIMARY KEY,
	geo_region_id INT REFERENCES geo_region(geo_region_id),
	ski_resort_id INT REFERENCES ski_resort(ski_resort_id)
);