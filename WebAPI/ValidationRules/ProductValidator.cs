using FluentValidation;
using WebAPI.Entities;

namespace WebAPI.ValidationRules
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(x => x.ProductName)
                .NotEmpty().WithMessage("Don't leave the product name blank.")
                .MinimumLength(2).WithMessage("Enter at least 2 characters.")
                .MaximumLength(50).WithMessage("Enter no more than 50 characters.");

            RuleFor(x => x.Price)
                .NotEmpty().WithMessage("Price cannot be empty.")
                .GreaterThan(0).WithMessage("Price must be greater than 0.")
                .LessThan(1000).WithMessage("Price cannot exceed 1000.");

            RuleFor(x => x.ProductDescription).NotEmpty().WithMessage("Don't leave the product description blank.");


        }
    }
}