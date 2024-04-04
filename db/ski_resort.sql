CREATE TABLE IF NOT EXISTS ski_resort (
	ski_resort_id SERIAL PRIMARY KEY,
	name TEXT NOT NULL,
	rating REAL NULL,
		
	base_elevation INT NULL,
	top_elevation INT NULL,
	
	blue_slopes_length REAL NULL,
	red_slopes_length REAL NULL,
	black_slopes_length REAL NULL,
	skiroutes_length REAL NULL,
	
	aerial_cablecar_count INT NULL,
	funicular_count INT NULL,
	gondola_lift_count INT NULL,
	chairlift_count INT NULL,
	combination_lift_count INT NULL,
	tbar_lift_count INT NULL,
	ropetow_lift_count INT NULL,
	carpet_lift_count INT NULL,
	
	heli_skiing BOOL NULL,
	cat_skiing BOOL NULL,
	
	open_hour TIME NULL,
	close_hour TIME NULL,
	season_info TEXT NULL,
	
	ticket_adult_price TEXT NULL,
	ticket_youth_price TEXT NULL,
	ticket_child_price TEXT NULL,
	
	website TEXT NULL,
	logo_url TEXT NULL,
	skiresort_info_url TEXT NULL
);