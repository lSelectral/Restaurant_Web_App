CREATE TABLE ingredients (
	id serial PRIMARY KEY NOT NULL,
	name varchar(100) NOT NULL,
	description varchar(100) NOT NULL,
	unit varchar(100) NOT NULL,
	price dec(18,2) NOT NULL
)

insert into ingredients (name, description, unit, price)
values 
('Zeytinyağı', 'Hakiki ege zeytinyağı', 'kg', 699.99),
('Sucuk', 'Dana eti sucuk', 'kg', 289.99),
('Kaşar', 'Mandıra kaşar', 'kg', 189.99),
('Peynir', 'Ezine Peyniri', 'kg', 79.99)

----------------------------------------------------------------------------

CREATE TABLE foods (
	id serial PRIMARY KEY NOT NULL,
	name varchar(100) NOT NULL,
	description varchar(100) NOT NULL,
	foodtype int NOT NULL,
	price dec(18,2) NOT NULL
)

-- Insert new data to foods
insert into foods (name, description, foodtype, price)
values
('Pide','Taşfırın kuşbaşı pide', 5, 45.99),
('Pizza','İtalyan pizza', 2, 45.99),
('Güveç','Tandır güveci', 4, 45.99),
('Köfte','Dana eti kaşarlı köfte', 3, 45.99)

----------------------------------------------------------------------------

CREATE TABLE food_ingredients (
	food_id int NOT NULL,
	ingredient_id int NOT NULL,
	PRIMARY KEY (food_id, ingredient_id),
	FOREIGN KEY (food_id) REFERENCES foods(id) ON UPDATE CASCADE,
	FOREIGN KEY (ingredient_id) REFERENCES ingredients (id) ON UPDATE CASCADE
)

-- Insert data to food_ingredients table
insert into food_ingredients (food_id, ingredient_id) values(1,1),(1,2)

----------------------------------------------------------------------------