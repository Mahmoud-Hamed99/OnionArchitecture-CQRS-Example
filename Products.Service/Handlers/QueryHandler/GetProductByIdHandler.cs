using AutoMapper;
using MediatR;
using Products.Domain;

namespace Products.Service
{
    public class GetProductByIdHandler : IRequestHandler<GetProductByIdQuery, ProductViewModel>
    {

        private readonly IProductQueryRepository _productQueryRepository;
        private IMapper _Mapper;

        public GetProductByIdHandler(IProductQueryRepository productQueryRepository, IMapper mapper)
        {
            _productQueryRepository = productQueryRepository;
            _Mapper = mapper;
        }

        public async Task<ProductViewModel> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var res =await  _productQueryRepository.GetById(request._Id);

            var product = _Mapper.Map<ProductViewModel>(res);

            return  product;
        }
    }
}
