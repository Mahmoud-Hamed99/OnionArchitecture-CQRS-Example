using Products.Domain;
using FluentValidation;

namespace Products.Service
{
    public class ProductViewModel
    {
        public int ProductId { get;  set; }

        public string? Name { get; set; } 

        public string? Brand { get; set; }

        public virtual ICollection<ProductDetailsViewModel> ProductDetails { get; set; } = new List<ProductDetailsViewModel>();
    }


    public class ProductValidator : AbstractValidator<ProductViewModel>
    {
        public ProductValidator()
        {
            RuleFor(obj=>obj.Name).NotEmpty().WithMessage("Name Cann't be Empty");
            RuleFor(obj=>obj.Name.Length).InclusiveBetween(5,20).WithMessage("Name length should be more than 5 chars and less than 20 chars ");
            RuleFor(obj => obj.Brand).NotEmpty().WithMessage("Brand cann't be empty");
        }
    }
}
