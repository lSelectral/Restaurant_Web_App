---------------------------------------------------------------
-- Function without parameter
/*
create or replace function func_get_food_count()
returns int
language plpgsql
as
$$
declare food_count int;
begin

select count(*) into food_count from foods;
return food_count;
end;
$$;
*/
select func_get_food_count();
---------------------------------------------------------------

---------------------------------------------------------------
-- Function with one parameter
/*
create or replace function func_get_ingredient_count_from_food_id(foodid int)
returns int
language plpgsql
as
$$
declare ingredient_count int;
begin
select count(ingredient_id) into ingredient_count from food_ingredients where food_id = foodid;
return ingredient_count;
end;
$$;
*/
select func_get_ingredient_count_from_food_id(14) "Food Ingredients Count";
---------------------------------------------------------------

---------------------------------------------------------------
-- Function with parameter and multiple output
/*
create or replace function func_food_sum_and_average_from_ingredient_id(
	in ingredientid int,
	out sum_price numeric(18,2),
	out avg_price numeric(18,2)
)
language plpgsql
as
$$
begin

SELECT sum(price), avg(price)
into sum_price, avg_price
FROM food_ingredients
INNER JOIN foods
ON food_ingredients.food_id = foods.id
where ingredient_id = ingredientid;

end;
$$;
*/
select sum_price sumprice,avg_price avgprice from func_food_sum_and_average_from_ingredient_id(2)
---------------------------------------------------------------

---------------------------------------------------------------
-- Function with parameter that returns table
/*
create or replace function func_get_food_table(ingredientid int)
returns table(
	food_id int, 
	ingredient_id int, 
	food_name varchar(200), 
	ingredient_name varchar(200), 
	food_price dec(18,2))
language plpgsql
as
$$
begin

return query 
SELECT food_ingredients.food_id, food_ingredients.ingredient_id, foods.name, ingredients.name, foods.price
FROM food_ingredients
INNER JOIN foods
ON food_ingredients.food_id = foods.id
INNER JOIN ingredients
ON food_ingredients.ingredient_id = ingredients.id
where food_ingredients.ingredient_id = ingredientid;

end;
$$;
*/
select 
food_id FoodId, 
ingredient_id IngredientId,
food_name FoodName,
ingredient_name IngredientName,
food_price FoodPrice
from func_get_food_table(2)
---------------------------------------------------------------
