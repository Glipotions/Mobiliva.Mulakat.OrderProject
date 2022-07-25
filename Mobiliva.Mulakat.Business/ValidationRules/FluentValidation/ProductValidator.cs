using FluentValidation;

namespace Mobiliva.Mulakat.Business.ValidationRules.FluentValidation
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(x => x.Description).NotEmpty();
            RuleFor(x => x.Description).MinimumLength(2);
        }

    }
}
