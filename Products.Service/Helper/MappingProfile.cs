using AutoMapper;
using Products.Domain;
using Products.Service;

namespace Products.Service
{
  
        public class MappingProfile : Profile
        {
            public MappingProfile()
            {
                // Add as many of these lines as you need to map your objects
            
            CreateMap<Product, ProductViewModel>();
                
            CreateMap<ProductViewModel,Product>();
            
            CreateMap<ProductDetail, ProductDetailsViewModel>();
           
            CreateMap< ProductDetailsViewModel, ProductDetail>();

            }
        }
    }

