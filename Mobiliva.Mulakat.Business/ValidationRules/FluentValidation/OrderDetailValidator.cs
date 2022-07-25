using FluentValidation;

namespace Mobiliva.Mulakat.Business.ValidationRules.FluentValidation
{
    public class OrderDetailValidator : AbstractValidator<OrderDetail>
    {
        public OrderDetailValidator()
        {
            //RuleFor(x => x.OrderId).NotEmpty();
        }
    }
}