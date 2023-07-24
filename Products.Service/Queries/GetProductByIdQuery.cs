using MediatR;
using Products.Domain;

namespace Products.Service
{
    public class GetProductByIdQuery : IRequest<ProductViewModel>
    {
        public int _Id;

        public GetProductByIdQuery(int Id)
        {
            _Id = Id;
        }
    }
}
