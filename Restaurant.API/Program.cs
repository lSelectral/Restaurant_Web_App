using MediatR;
using Npgsql;
using System.Data;
using System.Reflection;
using Restaurant_Web_API.Filters;
using FluentValidation.AspNetCore;
using Restaurant_Web_API.Middlewares;
using Restaurant_Web_API.Services;
using Restaurant.API.Extensions;
using Restaurant_Web_API.Repositories.FoodRepository;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(option => option.Filters
    .Add(new ValidateFilter()))
    .AddFluentValidation(x => x.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly()));

builder.Services.AddJWTAuthenticationValidation(builder.Configuration);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add PostgreSQL Database connection
builder.Services.AddScoped<IDbConnection>(sp => new NpgsqlConnection(builder.Configuration.GetConnectionString("Postgresql")));

// ADD Transaction DB to DI Container
builder.Services.AddScoped<IDbTransaction>(sp =>
{
    var connection = sp.GetRequiredService<IDbConnection>();
    connection.Open();
    return connection.BeginTransaction();
});

builder.Services.AddScoped<IFoodRepository, FoodRepository>();

builder.Services.AddMediatR(Assembly.GetExecutingAssembly());

builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

builder.Services.AddFluentValidationServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseGlobalExceptionMiddleware();

app.UseHttpsRedirection();

app.UseAuthentication(); // Authentication should come before [UseAuthorization]

app.UseAuthorization();

app.UseCustomLoggingMiddleware();

app.MapControllers();

app.Run();
