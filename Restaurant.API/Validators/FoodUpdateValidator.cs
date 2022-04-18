using FluentValidation;
using Restaurant_Web_API.Commands.Food.FoodUpdate;

namespace Restaurant_Web_API.Validators
{
    public class FoodUpdateValidator : AbstractValidator<FoodUpdateCommand>
    {
        public FoodUpdateValidator()
        {
            RuleFor(x => x.Id).NotNull().NotEmpty().GreaterThan(0);
            RuleFor(x => x.Name).NotNull().NotEmpty().WithMessage("Food name can't be empty or null");
            RuleFor(x => x.Name).MinimumLength(4);
            RuleFor(x => x.Description).NotEmpty().NotNull().MinimumLength(8);
            RuleFor(x => x.Price).GreaterThan(0);
            RuleFor(x => x.FoodType).GreaterThan(0);
        }
    }
}
