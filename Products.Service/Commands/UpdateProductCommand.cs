using MediatR;

namespace Products.Service
{
    public class UpdateProductCommand :  IRequest<ProductViewModel>
    {
       public  ProductViewModel _model;

        public UpdateProductCommand(ProductViewModel model)
        {
             _model = model;
        }
    }
}
