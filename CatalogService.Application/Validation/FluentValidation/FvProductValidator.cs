using CatalogService.Application.DTOs;
using FluentValidation;

namespace CatalogService.Application.Validation.FluentValidation
{
    public class FvProductValidator : AbstractValidator<ProductDtoForCreate>
    {
        public FvProductValidator()
        {
            // Name Rules
            RuleFor(x => x.Name).NotEmpty().WithMessage("Product name is required.");
            RuleFor(x => x.Name).Length(3, 100).WithMessage("Product name must be between 3-100 characters long.");

            // Description Rules
            RuleFor(x => x.Description).MaximumLength(500).WithMessage("Description must not exceed 500 characters.");

            // Price Rules
            RuleFor(x => x.Price).GreaterThan(0).WithMessage("Price must be greater than zero.");
            RuleFor(x => x.Price).LessThan(1000000).WithMessage("Price must be less than 1000000"); ;

            // Stock Rules
            RuleFor(x => x.UnitsInStock).GreaterThanOrEqualTo(0).WithMessage("Units in stock cannot be negative."); ;
        }
    }
}
