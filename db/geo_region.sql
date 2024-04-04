CREATE TYPE geo_region_type AS ENUM ('continent', 'country');

CREATE TABLE IF NOT EXISTS geo_region (
	geo_region_id SERIAL PRIMARY KEY,
	parent_region_id INT REFERENCES geo_region(geo_region_id),
	name TEXT NOT NULL,
	type geo_region_type NULL
);