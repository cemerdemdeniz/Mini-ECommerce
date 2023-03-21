using ECommerceAPI.Application.ViewModels.Products;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Application.Validators.Products
{
    public class CreateProductValidator : AbstractValidator<VM_Create_Product>
    {
        public CreateProductValidator()
        {
            RuleFor(p => p.Name).NotEmpty().NotNull().WithMessage("Please do not leave the product name blank.").MaximumLength(30).MinimumLength(5).WithMessage("Please set the product character as a value between 5 and 30");

            RuleFor(p => p.Stock).NotEmpty().NotEmpty().WithMessage("Please do not leave stock information blank.").Must(s => s >= 0).WithMessage("Stock information cannot be less than zero.");

            RuleFor(p => p.Price).NotEmpty().NotEmpty().WithMessage("Please do not leave price information blank.").Must(s => s >= 0).WithMessage("Price information cannot be less than zero.");
        }
    }
}
