using AutoMapper;
using MediatR;
using Products.Domain;

namespace Products.Service
{
    public class GetProductsHandler : IRequestHandler<GetProductsQuery, List<ProductViewModel>>
    {
        private readonly IProductQueryRepository _productQueryRepository;
        private IMapper _Mapper;

        public GetProductsHandler(IProductQueryRepository productQueryRepository, IMapper mapper)
        {
            _productQueryRepository = productQueryRepository;
            _Mapper = mapper;
        }

        public async Task<List<ProductViewModel>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {

            var res = await _productQueryRepository.GetAll();

            var productsViewModelsList = _Mapper.Map<List<Product>, List<ProductViewModel>>(res);

            return productsViewModelsList;
        }
    }
}
