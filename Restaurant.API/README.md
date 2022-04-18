### RESTAURANT WEB API

>Available Endpoints are:


|HTTP|METHOD|RETURNS
|---|---|---|
|GET| GetAll | `List<Food>` 
|GET| GetFoodCount | `int` 
|GET| GetIngredientCountFromFoodId | `int`  
|GET| GetAggregateFoodPriceFromIngredientId | `FoodAggregatePrice` 
|GET| GetFoodIngredientTableFromIngredientId | `List<FoodIngredientTable>` 
|POST| SaveFood - SaveFoodWithIngredients | `Inserted element ID`
|PUT| UpdateFood | `[NULL]`
|DELETE| DeleteFoodWithIngredients - DeleteFood | `[NULL]`

---
> HOW TO RUN

- Fork this repo to your local instance. 

- Edit the `ConnectionStrings` variable in `appsettings.json` file for your local DB

```
"ConnectionStrings": {
    "Postgresql": "Server=127.0.0.1;Port=5432;Database=[DatabaseName];User Id=postgres;Password=[password]"
}
```

- Just create empty database, SQL codes for creating table and inserting data to these tables are located inside the `PostgreSQL_Queries` folder `CreateTables.sql` file.

- For creating **Functions** run the `Functions.sql` file inside same folder inside the Postgres Shell.

- For creating **Store Procedures** run the `StoreProcedures.sql` file.

-  Then run the `dotnet run` in the command line inside the project folder.

- Then run the whichever endpoint you want to run.

---

>Folder Structure

- **`Commands`**
> Commands for executing the , `CREATE`, `UPDATE` and `DELETE` operations.
- **`Controllers`**
> Controller for defining all endpoints with custom base controller class (Use MediatR)
- **`DTOs`**
> Contains **Data Transfer Objects** between layers
- **`EventHandlers`**
> Contains **SMS** and **E-Mail** sending handler classes (Run after receiving update) 
- **`Events`**
> Event types to received by Handler classes.
- **`Filters`**
> Filters for injecting validation code 
- **`Mappers`**
> AutoMapper class for mapping objects to each other
- **`Middlewares`**
> Global **Logging** and **Error Handling** middleware classes
- **`Models`**
> Contains model for data handling and defining
- **`PostgreSQL_Queries`**
> Contains the PostgreSQL query codes for **CREATING TABLE**, **INSERTING DATA**, **CREATING FUNCTIONS** and **CREATING STORE PROCEDURE**. 
- **`Queries`**
> Contains Query and its handlers for receiving data from Database
- **`Repositories`**
> Contains all service functions for querying and executing dapper sql queries
- **`Services`**
> FluentValidation service register class
- **`Validators`**
> Contains all FluentValidation validator classes for command classes
