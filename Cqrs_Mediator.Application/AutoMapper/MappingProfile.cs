using AutoMapper;
using Cqrs_Mediator.Application.Features.Product.Queries.GetAllProduct;
using Cqrs_Mediator_Domain.Entities;
namespace Cqrs_Mediator.Application.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product,GetAllProductListDto>().ReverseMap();
        }

    }
}
