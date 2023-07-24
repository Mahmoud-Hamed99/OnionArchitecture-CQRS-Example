using MediatR;

namespace Products.Service
{
    public class GetProductsQuery : IRequest<List<ProductViewModel>>
    {

    }


}
