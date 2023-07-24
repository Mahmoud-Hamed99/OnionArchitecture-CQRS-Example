

using AutoMapper;
using MediatR;
using Products.Domain;

namespace Products.Service
{
    public class UpdateProductHandler : ProductViewModel, IRequestHandler<UpdateProductCommand, ProductViewModel>
    {
        private readonly IProductCommandRepository _productcommandRepository;
        private IMapper _Mapper;

        public UpdateProductHandler(IProductCommandRepository productcommandRepository, IMapper mapper)
        {
            _productcommandRepository = productcommandRepository;
            _Mapper = mapper;
        }

        public async Task<ProductViewModel> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var entity = _Mapper.Map<Product>(request._model);
            var res =await _productcommandRepository.UpdateProduct(entity);
            var mymodel = _Mapper.Map<ProductViewModel>(res);

            return mymodel;
        }
    }
}
