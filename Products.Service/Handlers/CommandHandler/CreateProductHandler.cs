using AutoMapper;
using MediatR;
using Products.Domain;

namespace Products.Service
{
    public class CreateProductHandler : IRequestHandler<AddProductCommand, ProductViewModel>
    {
        private readonly IProductCommandRepository _productcommandRepository;
        private IMapper _Mapper;

        public CreateProductHandler(IProductCommandRepository productcommandRepository, IMapper mapper)
        {
            _productcommandRepository = productcommandRepository;
            _Mapper = mapper;
        }

        public async Task<ProductViewModel> Handle(AddProductCommand request, CancellationToken cancellationToken)
        {
            var entity = _Mapper.Map<Product>(request.ProductViewModel);
            var res =await _productcommandRepository.CreateProduct(entity);
            var returnModel = _Mapper.Map<ProductViewModel>(res);
            return returnModel;
        }
    }
}
