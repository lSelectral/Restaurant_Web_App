using FluentValidation;
using Restaurant_Web_API.Commands.Food.FoodDelete;

namespace Restaurant_Web_API.Validators
{
    public class FoodDeleteValidator : AbstractValidator<FoodDeleteCommand>
    {
        public FoodDeleteValidator()
        {
            RuleFor(x => x.Id).NotNull().NotEmpty().GreaterThan(0);
        }
    }
}
