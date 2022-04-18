using FluentValidation;
using Restaurant_Web_API.Commands.Food.FoodInsert;

namespace Restaurant_Web_API.Validators
{
    public class FoodInsertValidator : AbstractValidator<FoodInsertCommand>
    {
        public FoodInsertValidator()
        {
            RuleFor(x => x.Name).NotNull().NotEmpty().WithMessage("Food name can't be empty or null");
            RuleFor(x => x.Name).MinimumLength(4);
            RuleFor(x => x.Description).NotEmpty().NotNull().MinimumLength(8);
            RuleFor(x => x.Price).NotEmpty().GreaterThan(0);
            RuleFor(x => x.FoodType).NotEmpty().GreaterThan(0);
            RuleFor(x => x.Ingredients.Count).NotEmpty().GreaterThan(0);
            RuleFor(x => x.Ingredients.Min()).GreaterThan(0).WithMessage("Ingredient id should be bigger than 0");
        }
    }
}
