using FluentValidation.AspNetCore;
using Restaurant_Web_API.Validators;

namespace Restaurant_Web_API.Services
{
    public static class FluentService
    {
        public static void AddFluentValidationServices(this IServiceCollection services)
        {
            services.AddControllers().AddFluentValidation(
                a => a.RegisterValidatorsFromAssemblyContaining<FoodDeleteValidator>()).AddFluentValidation(
                a => a.RegisterValidatorsFromAssemblyContaining<FoodInsertValidator>()).AddFluentValidation(
                a => a.RegisterValidatorsFromAssemblyContaining<FoodUpdateValidator>()).AddFluentValidation();
        }
    }
}
