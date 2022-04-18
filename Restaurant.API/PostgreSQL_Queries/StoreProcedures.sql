create or replace procedure sp_ingredient_and_food_insert
(
	ingredient_name varchar(100),
	ingredient_description varchar(100),
	ingredient_unit varchar(100),
	ingredient_price dec(18,2),
	food_name varchar(100),
	food_description varchar(100),
	food_type int,
	food_price dec(18,2)
)
language plpgsql
as $$
begin

-- How to call
call sp_ingredient_and_food_insert('Domates','Salkım domates','kg',7.99,'Menemen','Acılı menement',1,17.942131239)