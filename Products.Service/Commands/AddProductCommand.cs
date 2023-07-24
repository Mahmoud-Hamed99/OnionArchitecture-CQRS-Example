using MediatR;
using Products.Domain;

namespace Products.Service
{
    public class AddProductCommand : IRequest<ProductViewModel>
    {
        public ProductViewModel ProductViewModel;

        public AddProductCommand(ProductViewModel productViewModel)
        {
            ProductViewModel = productViewModel;
        }
    }
}
