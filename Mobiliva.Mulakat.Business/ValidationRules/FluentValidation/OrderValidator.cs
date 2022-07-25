using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class OrderValidator : AbstractValidator<Order>
	{
		public OrderValidator()
		{
			RuleFor(x => x.CustomerName).NotEmpty();
			RuleFor(x => x.CustomerName).MinimumLength(2);
			RuleFor(x => x.CustomerEmail).NotEmpty();
			//RuleFor(x => x.).GreaterThan(0);
		}
	}
}
